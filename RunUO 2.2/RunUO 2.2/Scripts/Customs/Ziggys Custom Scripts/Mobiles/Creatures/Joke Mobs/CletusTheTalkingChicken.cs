using System;
using Server;
using System.Collections;
using Server.ContextMenus;
using Server.Items;
using Server.Misc;
using Server.Network;
using Server.Spells;
using Server.Spells.Seventh;
using Server.Spells.Fifth;

namespace Server.Mobiles 
{ 
	[CorpseName( "suck my cock bitch i ain't giving you shit" )]
	public class CletusTheTalkingChicken : BaseCreature
	{
		public static TimeSpan TalkDelay = TimeSpan.FromSeconds( 30.0 ); //the delay between talks is 30 seconds
		public DateTime m_NextTalk;

		[Constructable] 
		public CletusTheTalkingChicken() : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 ) 
		{ 
			Name = "Cletus the Talking Chicken";
			Body = 0xD0;
			Hue = 33784;
			SpeechHue = 2124;
                        BaseSoundID = 0x6E;
			VirtualArmor = 50;
			AddItem( new LightSource() );

			SetStr( 1000 );
			SetDex( 1000 );
			SetInt( 1000 );

			SetHits( 2500 );

			SetDamage( 1, 10 );

			SetDamageType( ResistanceType.Physical, 20 );
			SetDamageType( ResistanceType.Fire, 20 );
			SetDamageType( ResistanceType.Cold, 20 );
			SetDamageType( ResistanceType.Poison, 20 );
			SetDamageType( ResistanceType.Energy, 20 );

			SetResistance( ResistanceType.Physical, 50 );
			SetResistance( ResistanceType.Fire, 50 );
			SetResistance( ResistanceType.Cold, 50 );
			SetResistance( ResistanceType.Poison, 50 );
			SetResistance( ResistanceType.Energy, 50 );

			SetSkill( SkillName.Anatomy, 100.0 );
			SetSkill( SkillName.MagicResist, 50.0 );
			SetSkill( SkillName.Tactics, 100.0 );
			SetSkill( SkillName.Wrestling, 100.0 );

			Fame = 25000;
			Karma = -25000;
		} 

		public override void GenerateLoot()
		{
			AddLoot( LootPack.UltraRich, 5 );
			AddLoot( LootPack.HighScrolls, 5 );
			AddLoot( LootPack.Gems, 5 );
		}

		public void Polymorph( Mobile m )
		{
			if ( !m.CanBeginAction( typeof( PolymorphSpell ) ) || !m.CanBeginAction( typeof( IncognitoSpell ) ) || m.IsBodyMod )
				return;

			IMount mount = m.Mount;

			if ( mount != null )
				mount.Rider = null;

			if ( m.Mounted )
				return;

			if ( m.BeginAction( typeof( PolymorphSpell ) ) )
			{
				Item disarm = m.FindItemOnLayer( Layer.OneHanded );

				if ( disarm != null && disarm.Movable )
					m.AddToBackpack( disarm );

				disarm = m.FindItemOnLayer( Layer.TwoHanded );

				if ( disarm != null && disarm.Movable )
					m.AddToBackpack( disarm );

				m.BodyMod = 0xD0;
				m.HueMod = 0;

				new ExpirePolymorphTimer( m ).Start();
			}
		}

		private class ExpirePolymorphTimer : Timer
		{
			private Mobile m_Owner;

			public ExpirePolymorphTimer( Mobile owner ) : base( TimeSpan.FromMinutes( 3.0 ) )
			{
				m_Owner = owner;

				Priority = TimerPriority.OneSecond;
			}

			protected override void OnTick()
			{
				if ( !m_Owner.CanBeginAction( typeof( PolymorphSpell ) ) )
				{
					m_Owner.BodyMod = 0;
					m_Owner.HueMod = -1;
					m_Owner.EndAction( typeof( PolymorphSpell ) );
				}
			}
		}

		public void SpawnMobiles( Mobile target )
		{
			Map map = this.Map;

			if ( map == null )
				return;

			int red = 0;

			foreach ( Mobile m in this.GetMobilesInRange( 10 ) )
			{
				if ( m is Gizzard || m is Gizzard )
					++red;
			}

			if ( red < 5 )
			{
				PlaySound( 1087 );

				int newblue = Utility.RandomMinMax( 1, 2 );

				for ( int i = 0; i < newblue; ++i )
				{
					BaseCreature yellow;

					switch ( Utility.Random( 2 ) )
					{
						default:
						case 0: yellow = new Gizzard(); break;
						case 1: yellow = new Gizzard(); break;
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

		public void DoSpecialAbility( Mobile target )
		{
			if ( target == null || target.Deleted ) //sanity
				return;
			if ( 0.6 >= Utility.RandomDouble() ) // 60% chance to polymorph attacker into a chicken
				Polymorph( target );

			if ( 0.2 >= Utility.RandomDouble() ) // 20% chance to spawn gizzards
				SpawnMobiles( target );
		}

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

		public override void OnMovement( Mobile m, Point3D oldLocation )
		{
			if ( DateTime.Now >= m_NextTalk && InRange( m, 10 ) && InLOS( m ) && m is PlayerMobile ) // check if it's time to talk & mobile in range & in los.
			{
				m_NextTalk = DateTime.Now + TalkDelay; // set next talk time 
				switch ( Utility.Random( 20 ))
				{
					case 0: Say("Nigga you just fucked with the wrong chicken! I'm so gonna have fun with you tonight!"); 
						break;
					case 1: Say("Oh you love my 10 foot cock? Well your ass will say otherwise once I'm done with you!"); 
						break;	
					case 2: Say("Fuckadoodle Doo I see you, and now you're gonna get raped now!"); 
						break;	
					case 3: Say("Nigga what the fuck is this shit? Go back to Trammel along with the rest of the Care Bear faggots!"); 
						break;	
					case 4: Say("Oh you think I'm just a harmless chicken? Well prepare for the fight of a life time you little shit!"); 
						break;	
					case 5: Say("Oh you thought the Yamandon was such tough shit? I will fuck you so hard that you'll eventually begin to enjoy it!"); 
						break;	
					case 6: Say("Give me some titties and beer and I will become a happy little cockle! Wait why am I mentioning that? I'm suppose to be fucking up your day!"); 
						break;	
					case 7: Say("Booty Butt, Booty Butt, Booty Butt Cheeks! Booty Butt, Booty Butt, Booty Butt Cheeks!"); 
						break;	
					case 8: Say("Man fuck the chicken of Bristol! Nigga owes me big time and as for you! Suck on this bitch!"); 
						break;	
					case 9: Say("Hey babe, why don't I flip you over and see whether you're a lemon or a rosebud!"); 
						break;	
					case 10: Say("Ah look at the little Britannian! They think they're people now!"); 
						break;	
					case 11: Say("Behold the glory of the mighty and proud cock of the walk!"); 
						break;	
					case 12: Say("Make me into chicken stew, oh you are getting fucked tonight!"); 
						break;	
					case 13: Say("Bawk, bawk, bawk, bawk, bawk, bawk, that's what you sound like!"); 
						break;	
					case 14: Say("Did I ever mention how fucking stupid you look?"); 
						break;	
					case 15: Say("Never again will I ever screw a human woman! Bitch wanted to cook me into fried chicken!"); 
						break;	
					case 16: Say("Black, white, its all the same! They taste like chicken and you look very lame!"); 
						break;	
					case 17: Say("I am the pillager of feminine glory holes! I am Cocktopus!.......... Wait scratch that!"); 
						break;	
					case 18: Say("Yeah you better run away! Come back when you can face the great, almighty Cockasaurus!"); 
						break;
					case 19: Say("Nigga, nigga, nigga, nigga, nigga, nigga, nigga! I'm 200% Nigga!"); 
						break;
				};
			}
		}

		public CletusTheTalkingChicken( Serial serial ) : base( serial ) 
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
