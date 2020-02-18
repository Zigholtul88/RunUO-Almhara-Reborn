using System;
using System.Collections.Generic;
using Server.Items;

namespace Server.Items
{
        public sealed class KeyStoragePouch : PouchOfKeyStorage
        {
                public override Type[] m_AllowedKeys
                {
                        get
                        {
                                return new Type[]
                                {
                                        typeof( CairnForlornKey ), 
                                        typeof( FortCalcifinaKey ),
                                        typeof( SagittaResidenceKey ),

                                        typeof( MongbatHideoutBossKey ), 
                                        typeof( AgurastAscensionKey ), 
                                        typeof( AgurastAscensionBossKey ), 
                                        typeof( SpecializedForestHartShard ),
                                        typeof( MurkmereDwellingBossKey ),

                                        typeof( GuardiansDesertBunkerKey ),
                                        typeof( GuardiansHorizonGateKey ), 
                                        typeof( RoyalTombPyramidKey ),

                                        typeof( IguanaCoveBossKey ), 
                                        typeof( WhisperingHollowDungeonKey ),
                                        typeof( WhisperingHollowBossKey ), 
                                        typeof( PassageOfLostSoulsKey ) 
                                };
                        }
                }

                [Constructable]
                public KeyStoragePouch(): this( 1 )
                {
                }

                [Constructable]
                public KeyStoragePouch( int maxKeys ): base( maxKeys )
                {
                        Name = "Key Storage Pouch - (1 Key Each)";
                }

                public KeyStoragePouch(Serial serial): base(serial)
                {
                }

                public override void Serialize(GenericWriter writer)
                {
                        base.Serialize(writer);
                        writer.WriteEncodedInt(0); // version
                }

                public override void Deserialize(GenericReader reader)
                {
                        base.Deserialize(reader);
                        int version = reader.ReadEncodedInt();
                }
        }
}