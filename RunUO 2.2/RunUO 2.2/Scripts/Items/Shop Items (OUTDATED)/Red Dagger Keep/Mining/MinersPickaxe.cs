using System;
using Server;
namespace Server.Items
{
        public class MinersPickaxe : Pickaxe, ITokunoDyable
        {
                public override int InitMinHits { get { return 50; } }
                public override int InitMaxHits { get { return 55; } }

                [Constructable]
                public MinersPickaxe()
                {
                        Name = "Miner's Pickaxe";
		        Hue = 974;
                        Attributes.WeaponDamage = 25;
                        Attributes.AttackChance = 25;
                        Attributes.DefendChance = 25;
                        WeaponAttributes.HitLowerAttack = 35;
                        Attributes.Luck = 100;
                        Attributes.ReflectPhysical = 15;
                        Attributes.WeaponSpeed = 20;
                 }

                 public MinersPickaxe( Serial serial ): base( serial )
                 {
                 }

                 public override void Serialize( GenericWriter writer )
                 {
                        base.Serialize( writer );
                        writer.Write( (int)0 );
                 }

                 public override void Deserialize( GenericReader reader )
                 {
                        base.Deserialize( reader );
                        int version = reader.ReadInt();
                 }
        }
}
