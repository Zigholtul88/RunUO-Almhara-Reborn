using System;
using Server;
namespace Server.Items
{
        public class LongShot : CompositeBow, ITokunoDyable
        {
                public override int InitMinHits { get { return 50; } }
                public override int InitMaxHits { get { return 55; } }

                [Constructable]
                public LongShot()
                {
                        Name = "Long Shot";
                        Hue = 1195;
                        Attributes.WeaponDamage = 15;
                        Attributes.AttackChance = 25;
                        WeaponAttributes.HitLightning = 25;
                        Attributes.RegenHits = 1;
                        Attributes.SpellChanneling = 1;
                }

                public LongShot( Serial serial ): base( serial )
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
