using System;
using Server;
using Server.Mobiles;

namespace Server.Items
{
        public class StupidFishingRod : FishingPole
        {
                public override bool OnEquip( Mobile from )
                {
                        if ( !base.OnEquip( from ) )
                        {
                                return false;
                        }
                        else if ( from.Mounted )
                        {
                                from.SendMessage( "You cannot use this while mounted. Stupid." );
                                return false;
                        }
                        else if ( from.Flying )
                        {
                                from.SendMessage( "You can't use this while flying. Stupid." ); 
                                return false;
                        }
                        else if ( from.IsBodyMod )
                        {
                                from.SendMessage( "You may only change forms while in your original body. Stupid." );
                                return false;
                        }

                        return true;
                }

                public override void OnAdded( object parent )
                {
                        base.OnAdded( parent );

                        if ( parent is Mobile )
                        {
                                Mobile from = parent as Mobile;

                                from.FixedParticles( 0x3728, 1, 13, 5042, EffectLayer.Waist );
                                from.PlaySound( Utility.RandomList( 1346,1344,1354 ) );

                                from.BodyMod = 430;
                                from.HueMod = 0;
                        }
                }

                public override void OnRemoved( object parent )
                {
                        base.OnRemoved( parent );

                        if ( parent is Mobile && !Deleted )
                        {
                                Mobile m = ( Mobile )parent;

                                m.BodyMod = 0;
                                m.HueMod = -1;
                                m.FixedParticles( 0x3728, 1, 13, 5042, EffectLayer.Waist );
                        }
                }

                [Constructable]
                public StupidFishingRod()
                {
			Name = "Stupid Fishing Rod - Quest Item";
                }

                public StupidFishingRod( Serial serial ) : base( serial )
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
                                }
                        }
                }
        }
}       