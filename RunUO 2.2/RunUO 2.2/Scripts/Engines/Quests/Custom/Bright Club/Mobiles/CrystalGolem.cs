using System;
using System.Collections;
using System.Collections.Generic;
using Server;
using Server.ContextMenus;
using Server.Items;
using Server.Mobiles;
using Server.Misc;
using Server.Network;
using Server.Targeting;
using Server.Engines.Quests;
using Server.Engines.Quests.BrightClub;

namespace Server.Mobiles
{
	[CorpseName( "a crystal golem corpse" )]
	public class CrystalGolem : BaseCreature
	{
		[Constructable]
		public CrystalGolem() : base( AIType.AI_Melee, FightMode.Aggressor, 10, 5, 2, 1.5 )
		{		
			Name = "A Crystal Golem";
			Body = 752;
			BaseSoundID = 541;
			Hue = 1153;

			SetStr( 500 );
			SetDex( 350 );
			SetInt( 250 );

			SetHits( 4000, 4500 );

			SetDamage( 25, 35 );

			SetDamageType( ResistanceType.Physical, 50 );
			SetDamageType( ResistanceType.Energy, 50 );

			SetResistance( ResistanceType.Physical, 50 );
			SetResistance( ResistanceType.Fire, 50 );
			SetResistance( ResistanceType.Cold, 50 );
			SetResistance( ResistanceType.Energy, 50 );
			SetResistance( ResistanceType.Poison, 50 );

			SetSkill( SkillName.Anatomy, 120.0 );
			SetSkill( SkillName.Focus, 100.0 );
			SetSkill( SkillName.MagicResist, 100.0 );
			SetSkill( SkillName.Tactics, 150.0 );
			SetSkill( SkillName.Wrestling, 150.0 );

			Fame = 1;
			Karma = 1;

			AddItem( new LightSource() );

			PackGold( 2700, 3900 );
			PackReg( 150, 200 );
		}

                public void AwardLoot()
                {
                      List<Mobile> list = new List<Mobile>();

                      foreach ( Mobile m in GetMobilesInRange( 12 ) )
                      {
                             if ( !CanBeHarmful ( m ) )
                             continue;

                             if ( m.Player )
                             list.Add ( m );
                      }

                      foreach ( Mobile m in list )
                      {
			    LightEnhancingCrystal crystal = new LightEnhancingCrystal();
				
		            PlayerMobile player = m as PlayerMobile;
			    QuestSystem qs = player.Quest;

			    if ( qs is BrightClubQuest && qs.IsObjectiveInProgress( typeof( KillGolemObjective ) ) )
			    {
				       qs.AddObjective( new ReturnToLighthouseObjective() );

                                       m.AddToBackpack( new LightEnhancingCrystal() );
                                       m.SendMessage( "You receive a light enhancing crystal." ); 
                                       DoHarmful( m );
			    }
                            else
                            {
                                       m.AddToBackpack( new Diamond(10) );
                                       DoHarmful( m ); 
                            }
                      }
                }

		public override bool OnBeforeDeath() //what happens before it dies
		{
		      AwardLoot();
                      return base.OnBeforeDeath();
                }

		public CrystalGolem( Serial serial ) : base( serial )
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
		}
	}
}