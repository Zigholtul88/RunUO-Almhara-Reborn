using System; 
using System.Collections; 
using Server.Misc; 
using Server.Items; 
using Server.Mobiles; 

namespace Server.Mobiles 
{ 
	public class ElandrimNurShazFortressGuard : BaseGuardian
	{ 
		[Constructable] 
		public ElandrimNurShazFortressGuard() : base( AIType.AI_Melee, FightMode.Closest, 15, 1, 0.1, 0.2 ) 
		{ 
			Title = "Fortress Guard of Elandrim Nur Shaz"; 
			Hue = Utility.RandomList( 1002,1023,1024 );

			SetStr( 950, 1000 );
			SetDex( 300, 500 );
			SetInt( 100, 200 );

			SetHits( 1500, 2000 );

			SetDamage( 10, 15 );

			SetSkill( SkillName.Anatomy, 100.0, 100.0);
			SetSkill( SkillName.Fencing, 100.0, 100.0 );
			SetSkill( SkillName.Healing, 25.0, 35.0 );
			SetSkill( SkillName.Lumberjacking, 100.0, 100.0 );
			SetSkill( SkillName.MagicResist, 100.0, 100.0 );
			SetSkill( SkillName.Swords, 100.0, 100.0 );
			SetSkill( SkillName.Tactics, 100.0, 100.0 );

			Karma = 10000;

			PackItem( new Bandage( Utility.RandomMinMax( 15, 20 ) ) );

			AddItem( new RadiantScimitar() );
			AddItem( new ElvenBoots(773) );
			AddItem( new WoodlandBelt(763) );
			AddItem( new Cloak(763) );

			ElvenPlateHelm helm = new ElvenPlateHelm();
			helm.Hue = 763;
			helm.Movable = true;
			AddItem( helm );

			ElvenPlateArms arms = new ElvenPlateArms();
			arms.Hue = 783;
			arms.Movable = true;
			AddItem( arms );

			ElvenPlateChest chest = new ElvenPlateChest();
			chest.Hue = 773;
			chest.Movable = true;
			AddItem( chest );

			ElvenPlateLegs legs = new ElvenPlateLegs();
			legs.Hue = 783;
			legs.Movable = true;
			AddItem( legs );


			if ( Female = Utility.RandomBool() ) 
			{ 
				Body = 606; 
				Name = NameList.RandomName( "elven female" );
								
			}
			else 
			{ 
				Body = 605; 			
				Name = NameList.RandomName( "elven male" ); 
			}

			Utility.AssignRandomHair( this );
		}

//<*************//Summon Forest Minions
		public override void OnGotMeleeAttack( Mobile attacker )
		{
			base.OnGotMeleeAttack( attacker );

			DoSpecialAbility( attacker );
		}

		public override void OnGaveMeleeAttack( Mobile defender )
		{
			base.OnGaveMeleeAttack( defender );

			DoSpecialAbility( defender );
		}

		public void DoSpecialAbility( Mobile target )
		{
			if ( 0.1 >= Utility.RandomDouble() ) // 10% chance to spawn forest minions
				SpawnMobiles( target );
		}

		public void SpawnMobiles( Mobile target )
		{
			Map map = this.Map;

			if ( map == null )
				return;

			int red = 0;

			foreach ( Mobile m in this.GetMobilesInRange( 10 ) )
			{
				if ( m is WoodlandProtector || m is WoodlandGuardian )
					++red;
			}

			if ( red < 5 )
			{
				PlaySound( 0x51A );

				int newblue = Utility.RandomMinMax( 1, 2 );

				for ( int i = 0; i < newblue; ++i )
				{
					BaseCreature yellow;

					switch ( Utility.Random( 2 ) )
					{
						default:
						case 0: yellow = new WoodlandProtector(); break;
						case 1: yellow = new WoodlandGuardian(); break;
					}

					yellow.Team = this.Team;

					bool validLocation = false;
					Point3D loc = this.Location;

					for ( int j = 0; !validLocation && j < 10; ++j )
					{
						int x = X + Utility.Random( 3 ) - 1;
						int y = Y + Utility.Random( 3 ) - 1;
						int z = map.GetAverageZ( x, y );

						if ( validLocation = map.CanFit( x, y, this.Z, 16, false, false ) )
							loc = new Point3D( x, y, Z );
						else if ( validLocation = map.CanFit( x, y, z, 16, false, false ) )
							loc = new Point3D( x, y, z );
					}

					yellow.MoveToWorld( loc, map );
					yellow.Combatant = target;
				}
			}
		}
//<*************//end summon forest minions

		public override bool BardImmune{ get{ return !Core.AOS; } }
		public override bool Unprovokable{ get{ return Core.AOS; } }
		public override bool AreaPeaceImmune{ get{ return Core.AOS; } }

		public ElandrimNurShazFortressGuard( Serial serial ) : base( serial ) 
		{ 
		} 

		public override void Serialize( GenericWriter writer ) 
		{ 
			base.Serialize( writer ); 

			writer.Write( (int) 0 ); // version 
		} 

		public override void Deserialize( GenericReader reader ) 
		{ 
			base.Deserialize( reader ); 

			int version = reader.ReadInt(); 
		} 
	} 
}   