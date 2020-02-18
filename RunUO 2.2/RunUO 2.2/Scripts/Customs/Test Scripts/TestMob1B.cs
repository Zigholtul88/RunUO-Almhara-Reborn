using System;
using System.Collections.Generic;
using Server;
using Server.Items;
using Server.Misc;
using Server.Mobiles;
using Server.Spells;
using Server.Spells.Third;
using Server.Spells.Sixth;
using Server.Targeting;

namespace Server.Mobiles
{
	[CorpseName( "a corpse" )]
	public class TestMob1B : BaseCreature
	{
		public virtual int StrikingRange{ get{ return 12; } }

		[Constructable]
		public TestMob1B() : base( AIType.AI_Animal, FightMode.Aggressor, 10, 1, 0.175, 0.350 )
		{
			Name = "Bob";
			Title = "the Gate Keeper";
			Body = 0x1D;
			BaseSoundID = 0x9E;

			SetStr( 47, 70 );
			SetDex( 49, 63 );
			SetInt( 18, 29 );

			SetHits( 275, 300 );

			SetDamage( 2, 5 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 18 );

			SetSkill( SkillName.MagicResist, 18.9, 25.8 );
			SetSkill( SkillName.Tactics, 32.5, 46.9 );
			SetSkill( SkillName.Wrestling, 50.7, 59.6 );

			Fame = 1500;
			Karma = -1500;

			m_Stomp = DateTime.UtcNow;

			PackGold( 2, 5 );
			AddItem( new MagicalShortbow() );
			PackItem( new Arrow( Utility.RandomMinMax( 5, 7 ) ) );

			PackItem( new FishScale( Utility.RandomMinMax( 6, 12 ) ) );
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Meager, 2 );
		}

		public override void OnThink()
		{
			base.OnThink();
			
			if ( Combatant != null )
			{
				if ( m_Stomp < DateTime.UtcNow && Utility.RandomDouble() < 0.1 )
					HoofStomp();
			}
		}

		public TestMob1B( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			
			int version = reader.ReadInt();
			
                        m_Stomp = DateTime.UtcNow;
		}
		
		private DateTime m_Stomp;
		
		public void HoofStomp()
		{
                        IPooledEnumerable eable = this.GetMobilesInRange( StrikingRange );
			foreach ( Mobile m in eable )
			{
				Mobile valid = Validate( m );

                                if (valid != null && Affect(valid))
                                {
                                        double percent = m.Skills.MagicResist.Value / 100;
                                        double malas = -20 + (percent * 5.2);

                                        m.AddStatMod(new StatMod(StatType.Str, "DreadHornStr", (int)malas, TimeSpan.FromSeconds(60)));
                                        m.AddStatMod(new StatMod(StatType.Dex, "DreadHornDex", (int)malas, TimeSpan.FromSeconds(60)));
                                        m.AddStatMod(new StatMod(StatType.Int, "DreadHornInt", (int)malas, TimeSpan.FromSeconds(60)));

                                        valid.SendLocalizedMessage(1075081); // *Dreadhorn?s eyes light up, his mouth almost a grin, as he slams one hoof to the ground!*
                                }
			}
                        eable.Free();

			// earthquake
			PlaySound( 0x2F3 );
				
			Timer.DelayCall( TimeSpan.FromSeconds( 30 ), new TimerCallback( delegate{ StopAffecting(); } ) );
						
			m_Stomp = DateTime.UtcNow + TimeSpan.FromSeconds( Utility.RandomMinMax( 60, 80 ) );
		}
		
		public Mobile Validate( Mobile m )
		{			
			Mobile agro;
					
			if ( m is BaseCreature )
				agro = ( (BaseCreature) m ).ControlMaster;
			else
				agro = m;
			
			if ( !CanBeHarmful( agro, false ) || !agro.Player /*|| Combatant == agro*/ )
				return null;	
			
			return agro;
		}
		
		private static Dictionary<Mobile,bool> m_Affected;
		
		public static bool IsUnderInfluence( Mobile mobile )
		{
			if ( m_Affected != null )
			{
				if ( m_Affected.ContainsKey( mobile ) )
					return true;
			}
			
			return false;
		}
		
		public static bool Affect( Mobile mobile )
		{
			if ( m_Affected == null )
				m_Affected = new Dictionary<Mobile,bool>();
				
			if ( !m_Affected.ContainsKey( mobile ) )
			{
				m_Affected.Add( mobile, true );
				return true;
			}
			
			return false;
		}
		
		public static void StopAffecting()
		{
			if ( m_Affected != null )
				m_Affected.Clear();
		}
	}
}