using System;
using Server;
using System.Collections;
using Server.Items;

namespace Server.Mobiles
{
	[CorpseName( "a cold drake corpse" )]
	public class ColdDrake : BaseCreature
	{
		[Constructable]
		public ColdDrake () : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "a cold drake";
			Body = Utility.RandomList( 60, 61 );
			BaseSoundID = 362;

            if (Body == 60)
                Hue = Utility.RandomList(1303, 1349);
            else if (Body == 61)
                Hue = 1349;

			SetStr( 606, 606 );
			SetDex( 150, 150 );
			SetInt( 345, 345 );

			SetHits( 481, 481 );

			SetDamage( 17, 20 );

			SetDamageType( ResistanceType.Physical, 50 );
			SetDamageType( ResistanceType.Cold, 50 );

			SetResistance( ResistanceType.Physical, 63, 63 );
			SetResistance( ResistanceType.Fire, 37, 37 );
			SetResistance( ResistanceType.Cold, 83, 83 );
			SetResistance( ResistanceType.Poison, 52, 52 );
			SetResistance( ResistanceType.Energy, 44, 44 );

            SetSkill(SkillName.MagicResist, 100.9, 100.9);
            SetSkill(SkillName.Tactics, 129.1, 129.1);
            SetSkill(SkillName.Wrestling, 117.6, 117.6);

			Fame = 18000;
            Karma = -18000;

			VirtualArmor = 46;

			PackReg( 3 );
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Rich, 2 );
			AddLoot( LootPack.MedScrolls, 2 );
		}

		public override bool ReacquireOnMovement{ get{ return true; } }
		public override int TreasureMapLevel{ get{ return 3; } }
		public override int Meat{ get{ return 10; } }
		public override int Hides{ get{ return 20; } }
		public override int Scales{ get{ return 2; } }
		public override ScaleType ScaleType{ get{ return ( Body == 60 ? ScaleType.Yellow : ScaleType.Red ); } }

		public override FoodType FavoriteFood{ get{ return FoodType.Meat | FoodType.Fish; } }

        public ColdDrake(Serial serial) : base(serial)
		{
		}

        public override void OnGaveMeleeAttack(Mobile defender)
        {
            base.OnGaveMeleeAttack(defender);

            if (this.Map == null)
                return;

            if (defender is BaseCreature && ((BaseCreature)defender).BardProvoked)
                return;

            if (0.25 > Utility.RandomDouble())
            {
                Mobile target = null;

                if (defender is BaseCreature)
                {
                    Mobile m = ((BaseCreature)defender).GetMaster();

                    if (m != null)
                        target = m;
                }

                if (target == null || !target.InRange(this, 18))
                    target = defender;

                this.Animate(10, 4, 1, true, false, 0);

                ArrayList targets = new ArrayList();

                foreach (Mobile m in target.GetMobilesInRange(8))
                {
                    if (m == this || !CanBeHarmful(m))
                        continue;

                    if (m is BaseCreature && (((BaseCreature)m).Controlled || ((BaseCreature)m).Summoned || ((BaseCreature)m).Team != this.Team))
                        targets.Add(m);
                    else if (m.Player && m.Alive)
                        targets.Add(m);
                }

                for (int i = 0; i < targets.Count; ++i)
                {
                    Mobile m = (Mobile)targets[i];

                    DoHarmful(m);

                    AOS.Damage(m, this, Utility.RandomMinMax(10, 20), true, 0, 0, 100, 0, 0);

                    m.FixedParticles(0x36BD, 1, 10, 0x1F78, 0x849, 0, (EffectLayer)255);
                }
            }
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