using System;
using Server;
using Server.Network;

namespace Server.Mobiles
{
	[CorpseName( "a hare corpse" )]
	public class EnragedRabbit : BaseEnraged
	{
		public EnragedRabbit( Mobile summoner ) : base( summoner )
		{
			Name = "a rabbit";
			Body = 0xcd;
		}

		public override int GetAttackSound() 
		{ 
			return 0xC9; 
		} 

		public override int GetHurtSound() 
		{ 
			return 0xCA; 
		} 

		public override int GetDeathSound() 
		{ 
			return 0xCB; 
		} 

		public EnragedRabbit( Serial serial ) : base( serial )
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

	[CorpseName( "a deer corpse" )]
	public class EnragedHart : BaseEnraged
	{
		public EnragedHart( Mobile summoner ) : base( summoner )
		{
			Name = "a great hart";
			Body = 0xea;
		}

		public override int GetAttackSound() 
		{ 
			return 0x82; 
		} 

		public override int GetHurtSound() 
		{ 
			return 0x83; 
		} 

		public override int GetDeathSound() 
		{ 
			return 0x84; 
		} 

		public EnragedHart( Serial serial ) : base( serial )
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

	[CorpseName( "a deer corpse" )]
	public class EnragedHind : BaseEnraged
	{
		public EnragedHind( Mobile summoner ) : base( summoner )
		{
			Name = "a hind";
			Body = 0xed;
		}
		public override int GetAttackSound() 
		{ 
			return 0x82; 
		} 

		public override int GetHurtSound() 
		{ 
			return 0x83; 
		} 

		public override int GetDeathSound() 
		{ 
			return 0x84; 
		} 

		public EnragedHind( Serial serial ) : base( serial )
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

	[CorpseName( "a bear corpse" )]
	public class EnragedBlackBear : BaseEnraged
	{
		public EnragedBlackBear( Mobile summoner ) : base( summoner )
		{
			Name = "a black bear";
			Body = 0xd3;
			BaseSoundID = 0xa3;
		}
		public EnragedBlackBear( Serial serial ) : base( serial )
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

	[CorpseName( "an eagle corpse" )]
	public class EnragedEagle : BaseEnraged
	{
		public EnragedEagle( Mobile summoner ) : base( summoner )
		{
			Name = "an eagle";
			Body = 0x5;
			BaseSoundID = 0x2ee;
		}
		public EnragedEagle( Serial serial ) : base( serial )
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

	[CorpseName( "a forest bat corpse" )]
	public class EnragedForestBat: BaseEnraged
	{
		public EnragedForestBat( Mobile summoner ) : base( summoner )
		{
			Name = "a forest bat";
			Body = 317;
                        Hue = 1237;
			BaseSoundID = 0x270;
		}
		public EnragedForestBat( Serial serial ) : base( serial )
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

	[CorpseName( "a large frog corpse" )]
	public class EnragedLargeFrog: BaseEnraged
	{
		public EnragedLargeFrog( Mobile summoner ) : base( summoner )
		{
			Name = "a large frog";
			Body = 80;
                        Hue = 663;
			BaseSoundID = 0x26B;
		}
		public EnragedLargeFrog( Serial serial ) : base( serial )
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

	[CorpseName( "a dark rose corpse" )]
	public class EnragedDarkRose: BaseEnraged
	{
		public EnragedDarkRose( Mobile summoner ) : base( summoner )
		{
			Name = "a dark rose";
			Body = 789;
                        Hue = 1172; 
		}

		public override int GetIdleSound() { return 0x017; }
		public override int GetAngerSound() { return 0x018; }
		public override int GetAttackSound() { return 0x01E; }
		public override int GetHurtSound() { return 0x01D; }
		public override int GetDeathSound() { return 0x01A; }

		public EnragedDarkRose( Serial serial ) : base( serial )
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

	[CorpseName( "a desert rose corpse" )]
	public class EnragedDesertRose: BaseEnraged
	{
		public EnragedDesertRose( Mobile summoner ) : base( summoner )
		{
			Name = "a desert rose";
			Body = 789;
                        Hue = 251;
			BaseSoundID = 352;
		}
		public EnragedDesertRose( Serial serial ) : base( serial )
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

	[CorpseName( "a bloated spider corpse" )]
	public class EnragedOboruBloatedSpider: BaseEnraged
	{
		public EnragedOboruBloatedSpider( Mobile summoner ) : base( summoner )
		{
			Name = "a bloated spider";
			Body = 735;
                        Hue = 1058;
		}

		public override int GetIdleSound() { return 1605; }
		public override int GetAngerSound() { return 1602; }
		public override int GetHurtSound() { return 1604; }
		public override int GetDeathSound() { return 1603; }

		public EnragedOboruBloatedSpider( Serial serial ) : base( serial )
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

	[CorpseName( "a pair of pants" )]
	public class EnragedRunningPants: BaseEnraged
	{
		public EnragedRunningPants( Mobile summoner ) : base( summoner )
		{
			Name = NameList.RandomName( "parrot" );
			Title = "pair of running pants";
			Body = 430;
		}

		public override int GetIdleSound() { return 1320; }
		public override int GetAttackSound() { return 1346; }
		public override int GetAngerSound() { return 1354; }
		public override int GetHurtSound() { return 1344; }
		public override int GetDeathSound() { return 1343; }

		public EnragedRunningPants( Serial serial ) : base( serial )
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

	[CorpseName( "a skittering hopper corpse" )]
	public class EnragedSkitteringHopper: BaseEnraged
	{
		public EnragedSkitteringHopper( Mobile summoner ) : base( summoner )
		{
			Name = "a skittering hopper";
			Body = 302;
			BaseSoundID = 959;
		}
		public EnragedSkitteringHopper( Serial serial ) : base( serial )
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

	[CorpseName( "a swamp vine corpse" )]
	public class EnragedSwampVine: BaseEnraged
	{
		public EnragedSwampVine( Mobile summoner ) : base( summoner )
		{
			Name = "a swamp vine";
			Body = 8;
                        Hue = 768;
			BaseSoundID = 684;
		}
		public EnragedSwampVine( Serial serial ) : base( serial )
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

	[CorpseName( "a quagmire corpse" )]
	public class EnragedQuagmire: BaseEnraged
	{
		public EnragedQuagmire( Mobile summoner ) : base( summoner )
		{
			Name = "a quagmire";
			Body = 789;
		}

		public override int GetIdleSound() { return 0x017; }
		public override int GetAngerSound() { return 0x018; }
		public override int GetAttackSound() { return 0x01E; }
		public override int GetHurtSound() { return 0x01D; }
		public override int GetDeathSound() { return 0x01A; }

		public EnragedQuagmire( Serial serial ) : base( serial )
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


	public class BaseEnraged : BaseCreature
	{
		public BaseEnraged( Mobile summoner ) 
			: base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			SetStr( 50, 200 );
			SetDex( 50, 200 );
			SetHits( 50, 200 );
			SetStam( 50, 200 );

			/* 
				On OSI, all stats are random 50-200, but
				str is never less than hits, and dex is never
				less than stam.
			*/

			if( Str < Hits )
				Str = Hits;
			if( Dex < Stam )
				Dex = Stam;

			Karma = -1000;
			Tamable = false;

			SummonMaster = summoner;
		}

		public override void OnThink()
		{

			if( SummonMaster == null || SummonMaster.Deleted )
			{
				Delete();
			}

			/*
				On OSI, without combatant, they behave as if they have been
				given "come" command, ie they wander towards their summoner,
				but never actually "follow".
			*/

			else if( !Combat( this ))
			{
				if( AIObject != null )
				{
					AIObject.MoveTo( SummonMaster, false , 5 );
				}
			}

			/*
				On OSI, if the summon attacks a mobile, the summoner meer also
				attacks them, regardless of karma, etc. as long as the combatant
				is a player or controlled/summoned, and the summoner is not already
				engaged in combat.
			*/

			else if( !Combat( SummonMaster ))
			{
				BaseCreature bc = null;
				if( Combatant is BaseCreature )
				{
					bc = (BaseCreature)Combatant;
				}
				if( Combatant.Player || ( bc != null && ( bc.Controlled || bc.SummonMaster != null )))
				{
					SummonMaster.Combatant = Combatant;
				}
			}
			else
			{
				base.OnThink();
			}
		}

		private bool Combat( Mobile mobile )
		{
			Mobile combatant = mobile.Combatant;
			if( combatant == null || combatant.Deleted )
			{	
				return false;
			}
			else if ( combatant.IsDeadBondedPet || !combatant.Alive )
			{
				return false;
			}
			return true;
		}

		public override void OnSingleClick( Mobile from )
		{
			base.OnSingleClick( from );
			PrivateOverheadMessage( MessageType.Regular, 0x3B2, 1060768, from.NetState ); // enraged
		}

		public override void AddNameProperties( ObjectPropertyList list )
		{
			base.AddNameProperties( list );
			list.Add( 1060768 ); // enraged
		}

		public BaseEnraged( Serial serial ) : base( serial )
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

