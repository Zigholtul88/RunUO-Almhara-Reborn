using System;
using Server.Mobiles;
using Server;
using Server.Items;

namespace Server.Items
{
        public class YoureFuckedCloak : Cloak
        {
                public override bool OnEquip( Mobile from )
                {
                        if ( !base.OnEquip( from ) )
                        {
                            return false;
                        }
                        else if ( from.Mounted )
                        {
                            from.SendLocalizedMessage( 1010097 ); // You cannot use this while mounted.
                            return false;
                        }
                        else if ( from.Flying )
                        {
                            from.SendLocalizedMessage( 1113414 ); // You can't use this while flying!
                            return false;
                        }
                        else if ( from.IsBodyMod )
                        {
                            from.SendLocalizedMessage( 1111896 ); // You may only change forms while in your original body.
                            return false;
                        }

                        return true;
                }

                public override void OnAdded( object parent )
                {
                    base.OnAdded( parent );

                    if (parent is Mobile)
                    {
                        Mobile from = parent as Mobile;

                        from.FixedParticles( 0x3728, 1, 13, 5042, EffectLayer.Waist );

                        from.BodyMod = 430;
                        from.HueMod = 0;

		        ResistanceMod mod1 = new ResistanceMod( ResistanceType.Physical, - 50 );
		        ResistanceMod mod2 = new ResistanceMod( ResistanceType.Fire, - 50 );
		        ResistanceMod mod3 = new ResistanceMod( ResistanceType.Cold, - 50 );
		        ResistanceMod mod4 = new ResistanceMod( ResistanceType.Poison, - 50 );
		        ResistanceMod mod5 = new ResistanceMod( ResistanceType.Energy, - 50 );

		        from.AddResistanceMod( mod1 );
		        from.AddResistanceMod( mod2 );
		        from.AddResistanceMod( mod3 );
		        from.AddResistanceMod( mod4 );
		        from.AddResistanceMod( mod5 );
                    }
                }

                public override void OnRemoved( object parent )
                {
                    base.OnRemoved(parent);

                    if ( parent is Mobile && !Deleted )
                    {
                        Mobile m = ( Mobile )parent;

                        m.BodyMod = 0;
                        m.HueMod = -1;
                        m.FixedParticles( 0x3728, 1, 13, 5042, EffectLayer.Waist );

		        ResistanceMod mod1 = new ResistanceMod( ResistanceType.Physical, 0 );
		        ResistanceMod mod2 = new ResistanceMod( ResistanceType.Fire, 0 );
		        ResistanceMod mod3 = new ResistanceMod( ResistanceType.Cold, 0 );
		        ResistanceMod mod4 = new ResistanceMod( ResistanceType.Poison, 0 );
		        ResistanceMod mod5 = new ResistanceMod( ResistanceType.Energy, 0 );

		        m.AddResistanceMod( mod1 );
		        m.AddResistanceMod( mod2 );
		        m.AddResistanceMod( mod3 );
		        m.AddResistanceMod( mod4 );
		        m.AddResistanceMod( mod5 );
                    }
                }

                [Constructable]
                public YoureFuckedCloak()
                {
			Name = "Good luck removing this";
                        LootType = LootType.Blessed;
                        Movable = false;
                }

                public YoureFuckedCloak( Serial serial ) : base( serial )
                {
                }

                public override void Serialize( GenericWriter writer )
                {
                    base.Serialize(writer);

                    writer.Write((int)1);
                }

                public override void Deserialize( GenericReader reader )
                {
                        base.Deserialize(reader);

                        int version = reader.ReadInt();

                        if (version == 0)
                        {
                            reader.ReadInt();
                            reader.ReadInt();
                        }

                        if ( Parent is Mobile )
                        {
                                Mobile m = ( Mobile )Parent;

                                if ( !m.Mounted && !m.Flying && !m.IsBodyMod )
                                {
                                     m.BodyMod = 430;
                                     m.HueMod = 0;
		                     ResistanceMod mod1 = new ResistanceMod( ResistanceType.Physical, - 50 );
		                     ResistanceMod mod2 = new ResistanceMod( ResistanceType.Fire, - 50 );
		                     ResistanceMod mod3 = new ResistanceMod( ResistanceType.Cold, - 50 );
		                     ResistanceMod mod4 = new ResistanceMod( ResistanceType.Poison, - 50 );
		                     ResistanceMod mod5 = new ResistanceMod( ResistanceType.Energy, - 50 );

		                     m.AddResistanceMod( mod1 );
		                     m.AddResistanceMod( mod2 );
		                     m.AddResistanceMod( mod3 );
		                     m.AddResistanceMod( mod4 );
		                     m.AddResistanceMod( mod5 );
                                }
                        }
                }
        }
}       