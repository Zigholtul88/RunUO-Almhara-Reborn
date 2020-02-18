using System;
using Server;
using System.Collections;
using Server.Items;

namespace Server.Mobiles
{
    [CorpseName("a frost dragon corpse")]
	public class FrostDragon : BaseCreature
	{
		[Constructable]
		public FrostDragon() : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "a frost dragon";

			Body = Utility.RandomList( 12, 59 );
            if (Body == 12)
                Hue = Utility.RandomList(1303, 1349);
            else if (Body == 59)
                Hue = 1349;

			BaseSoundID = 362;

			SetStr( 1328, 1340 );
			SetDex( 110, 112 );
			SetInt( 617, 680 );

			SetHits( 2045, 2221 );

			SetDamage( 26, 35 );

            SetDamageType(ResistanceType.Physical, 50);
            SetDamageType(ResistanceType.Cold, 50);

			SetResistance( ResistanceType.Physical, 89, 91 );
			SetResistance( ResistanceType.Fire, 59, 68 );
			SetResistance( ResistanceType.Cold, 85, 90 );
			SetResistance( ResistanceType.Poison, 65, 70 );
			SetResistance( ResistanceType.Energy, 65, 75 );

			SetSkill( SkillName.EvalInt, 50.1, 57.0 );
			SetSkill( SkillName.Magery, 121.7, 127.3 );
			SetSkill( SkillName.MagicResist, 117.2, 130.7 );
			SetSkill( SkillName.Tactics, 124.9, 132.9 );
			SetSkill( SkillName.Wrestling, 123.8, 127.8 );

			Fame = 25000;
			Karma = -25000;

			VirtualArmor = 60;

            PackItem(new Gold(Utility.Random(500) + 300));
		}

		public override void GenerateLoot()
		{
            AddLoot(LootPack.AosUltraRich, 1);
		}

		public override bool ReacquireOnMovement{ get{ return !Controlled; } }
		public override bool AutoDispel{ get{ return !Controlled; } }
		public override int TreasureMapLevel{ get{ return 5; } }
		public override int Meat{ get{ return 19; } }
		public override int Hides{ get{ return 33; } }
        public override FoodType FavoriteFood{ get{ return FoodType.Meat; } }

        public FrostDragon(Serial serial) : base(serial)
		{
		}

        public override void OnGaveMeleeAttack(Mobile defender)
        {
            base.OnGaveMeleeAttack(defender);

            if (this.Map == null)
                return;

            if (defender is BaseCreature && ((BaseCreature)defender).BardProvoked)
                return;

            if (0.4 > Utility.RandomDouble())
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

                    AOS.Damage(m, this, Utility.RandomMinMax(15, 30), true, 0, 0, 100, 0, 0);

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