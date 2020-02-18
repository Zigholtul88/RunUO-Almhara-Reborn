using System;
using System.Collections.Generic;
using Server.Items;

namespace Server.Items
{
        public sealed class MonsterPartStoragePouch : PouchOfMonsterPartStorage
        {
                public override Type[] m_AllowedMonsterParts
                {
                        get
                        {
                                return new Type[]
                                {
                                        typeof( AlligatorMeat ), 
                                        typeof( BlackLizardMeat ), 
                                        typeof( FaerieBeetleCollectorMeat ), 
                                        typeof( FaerieBeetleMeat ),
                                        typeof( GreySquirrelMeat ), 
                                        typeof( HillToadMeat ), 
                                        typeof( LargeFrogMeat ),
                                        typeof( RawDireWolfLeg ),
                                        typeof( RawForestBatRibs ), 
                                        typeof( RawGizzardRibs ), 
                                        typeof( RawGreyWolfLeg ), 
                                        typeof( RawHarpyRibs ), 
                                        typeof( SandCrabMeat ),
                                        typeof( SewerBeef ), 
                                        typeof( WaterLizardMeat ), 
                                        typeof( WyvernMeat ),
                                        typeof( RawBird ),
                                        typeof( RawChicken ), 
                                        typeof( RawChickenLeg ), 
                                        typeof( RawDuck ), 
                                        typeof( RawDuckLeg ), 
                                        typeof( RawTurkey ),
                                        typeof( RawTurkeyLeg ), 
                                        typeof( RawRibs ), 
                                        typeof( RawLambLeg ),
                                        typeof( RawChickenLeg ),
                                        typeof( RawFishSteak ), 
                                        typeof( SmallStarLakeCrabEgg ), 
                                        typeof( LargeStarLakeCrabEgg ), 
                                        typeof( AdamantoiseCarapace ),
                                        typeof( AdamantoiseEgg ),
                                        typeof( AdamantoiseTooth ), 
                                        typeof( AdjuleTooth ), 
                                        typeof( AlmirajHorn ), 
                                        typeof( AlPacaEye ),
                                        typeof( AlytharrGrassSnakeSkin ), 
                                        typeof( AnnihilationBeetleCarapace ),
                                        typeof( AntLionCarapace ),
                                        typeof( AntLionEgg ), 
                                        typeof( AntLionTooth ), 
                                        typeof( BarghestClaw ),
                                        typeof( BarghestTooth ),
                                        typeof( BeachBeetleSerum ), 
                                        typeof( BlackLizardEyeBall ),
                                        typeof( BogCreeperCarapace ), 
                                        typeof( BulletAntStinger ), 
                                        typeof( CaveBearClaw ), 
                                        typeof( CavernMongbatClaw ),
                                        typeof( CavernScorpionCarapace ),
                                        typeof( CharredSpriteWings ),
                                        typeof( CentaurClaw ),
                                        typeof( CliffStriderPowder ), 
                                        typeof( CrushedShatterGlass ), 
                                        typeof( DragonHeart ), 
                                        typeof( DeathwatchBeetleEgg ),
                                        typeof( DesertOstardEgg ),
                                        typeof( EttinTooth ),
                                        typeof( FaerieBeetleCarapace ), 
                                        typeof( ForestBatClaw ), 
                                        typeof( ForestHartShard ),
                                        typeof( ForestOstardEgg ),
                                        typeof( GiantToadEye ),
                                        typeof( GratNectar ), 
                                        typeof( GreenAllosaurClaw ), 
                                        typeof( GreenAllosaurTooth ),
                                        typeof( GreenSlimeVial ), 
                                        typeof( GrobusFur ), 
                                        typeof( GryphonBeak ), 
                                        typeof( GryphonClaw ), 
                                        typeof( HarpyTalon ), 
                                        typeof( HillToadEye ), 
                                        typeof( ImpClaw ), 
                                        typeof( KelpieEye ),
                                        typeof( KitsuneClaw ),
                                        typeof( LamiaScale ), 
                                        typeof( LesserAntlionCarapace ), 
                                        typeof( LionPelt ),
                                        typeof( LionTooth ),
                                        typeof( MesmenirHorn ),
                                        typeof( MinorBloodVial ),
                                        typeof( MummyBandage ), 
                                        typeof( OgreEye ), 
                                        typeof( OphidianEye ), 
                                        typeof( PeltedMinotaurFur ),
                                        typeof( PookahEye ), 
                                        typeof( RawDireWolfLeg ), 
                                        typeof( RawGreyWolfLeg ), 
                                        typeof( RazorbackTooth ),
                                        typeof( RedbarkPoisonGland ),
                                        typeof( RedbarkScorpionCarapace ), 
                                        typeof( RidgebackEgg ),
                                        typeof( RoseOfJubokko ),
                                        typeof( RoseOfQingniao ), 
                                        typeof( RoseOfQuagmire ), 
                                        typeof( RoseOfShangyang ), 
                                        typeof( RoseOfUmdhlebi ), 
                                        typeof( SahaginScale ),
                                        typeof( SalivaEye ),
                                        typeof( SandCrabCarapace ),
                                        typeof( SandCrabMeat ),
                                        typeof( SandStreakerWings ), 
                                        typeof( SeekerEye ), 
                                        typeof( SmallBlackAntEgg ), 
                                        typeof( SwampVineAppendages ), 
                                        typeof( TerathanEye ),
                                        typeof( TrollTooth ), 
                                        typeof( VampireBatClaw ), 
                                        typeof( VerdantSpriteWings ),
                                        typeof( WaterLizardEyeBall ),
                                        typeof( WhippingVineAppendages ), 
                                        typeof( WyvernTooth )
                                };
                        }
                }

                [Constructable]
                public MonsterPartStoragePouch(): this( 20 )
                {
                }

                [Constructable]
                public MonsterPartStoragePouch( int maxMonsterParts ): base( maxMonsterParts )
                {
                        Name = "Monster Parts Storage Pouch - (20 Parts Each)";
                }

                public MonsterPartStoragePouch(Serial serial): base(serial)
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