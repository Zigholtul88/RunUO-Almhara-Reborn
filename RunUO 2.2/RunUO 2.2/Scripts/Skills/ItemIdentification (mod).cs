using System;
using Server;
using Server.Targeting;
using Server.Mobiles;

namespace Server.Items
{
	public class ItemIdentification
	{
		public static void Initialize()
		{
			SkillInfo.Table[(int)SkillName.ItemID].Callback = new SkillUseCallback( OnUse );
		}

		public static TimeSpan OnUse( Mobile from )
		{
			from.SendLocalizedMessage( 500343 ); // What do you wish to appraise and identify?
			from.Target = new InternalTarget();

			return TimeSpan.FromSeconds( 1.0 );
		}

		[PlayerVendorTarget]
		private class InternalTarget : Target
		{
			public InternalTarget() :  base ( 8, false, TargetFlags.None )
			{
				AllowNonlocal = true;
			}

			protected override void OnTarget( Mobile from, object o )
			{
				if ( o is Item )
				{
					if ( from.CheckTargetSkill( SkillName.ItemID, o, 0, 100 ) )
					{
						if ( !Core.AOS )
							((Item)o).OnSingleClick( from );

					//ItemID Mods Begin
						if ( o is BaseArmor )
                                                {
							((BaseArmor)o).Identified = true;
                                                }
						else if ( o is BaseClothing )
                                                {
							((BaseClothing)o).Identified = true;
                                                }
						else if ( o is BaseJewel )
                                                {
							((BaseJewel)o).Identified = true;
                                                }
					//ItemID Mods End

				                else if ( o is BaseAxe )
				                {
					                if ( from.CheckTargetSkill( SkillName.ItemID, o, 40.0, 100 ) )
					                {
							        ((BaseAxe)o).Identified = true;

		                                                from.BoltEffect( 0x480 );
                                                                from.PlaySound(Utility.RandomList( 0x028,0x029,0x206 ) );

                                                                Effects.SendLocationParticles( EffectItem.Create( from.Location, from.Map, EffectItem.DefaultDuration ), 0, 0, 0, 0, 0, 5060, 0 );
                                                                Effects.PlaySound( from.Location, from.Map, 0x232 );
                                                                Effects.SendMovingParticles( new Entity( Serial.Zero, new Point3D( from.X - 6, from.Y - 6, from.Z + 15 ), from.Map ), from, 0x36D4, 7, 0, false, true, 0x497, 0, 9502, 1, 0, (EffectLayer)255, 0x100 );
                                                                Effects.SendMovingParticles( new Entity( Serial.Zero, new Point3D( from.X - 4, from.Y - 6, from.Z + 15 ), from.Map ), from, 0x36D4, 7, 0, false, true, 0x497, 0, 9502, 1, 0, (EffectLayer)255, 0x100 );
                                                                Effects.SendMovingParticles( new Entity( Serial.Zero, new Point3D( from.X - 6, from.Y - 4, from.Z + 15 ), from.Map ), from, 0x36D4, 7, 0, false, true, 0x497, 0, 9502, 1, 0, (EffectLayer)255, 0x100 );
                                                        }
                                                }
				                else if ( o is BaseBashing )
				                {
					                if ( from.CheckTargetSkill( SkillName.ItemID, o, 30.0, 100 ) )
					                {
							        ((BaseBashing)o).Identified = true;

		                                                from.BoltEffect( 0x480 );
                                                                from.PlaySound(Utility.RandomList( 0x028,0x029,0x206 ) );

                                                                Effects.SendLocationParticles( EffectItem.Create( from.Location, from.Map, EffectItem.DefaultDuration ), 0, 0, 0, 0, 0, 5060, 0 );
                                                                Effects.PlaySound( from.Location, from.Map, 0x233 );
                                                                Effects.SendMovingParticles( new Entity( Serial.Zero, new Point3D( from.X - 6, from.Y - 6, from.Z + 15 ), from.Map ), from, 0x36D4, 7, 0, false, true, 0x497, 0, 9502, 1, 0, (EffectLayer)255, 0x100 );
                                                                Effects.SendMovingParticles( new Entity( Serial.Zero, new Point3D( from.X - 4, from.Y - 6, from.Z + 15 ), from.Map ), from, 0x36D4, 7, 0, false, true, 0x497, 0, 9502, 1, 0, (EffectLayer)255, 0x100 );
                                                                Effects.SendMovingParticles( new Entity( Serial.Zero, new Point3D( from.X - 6, from.Y - 4, from.Z + 15 ), from.Map ), from, 0x36D4, 7, 0, false, true, 0x497, 0, 9502, 1, 0, (EffectLayer)255, 0x100 );
                                                        }
                                                }
				                else if ( o is BaseKnife )
				                {
					                if ( from.CheckTargetSkill( SkillName.ItemID, o, 15.0, 100 ) )
					                {
							        ((BaseKnife)o).Identified = true;

		                                                from.BoltEffect( 0x480 );
                                                                from.PlaySound(Utility.RandomList( 0x028,0x029,0x206 ) );

                                                                Effects.SendLocationParticles( EffectItem.Create( from.Location, from.Map, EffectItem.DefaultDuration ), 0, 0, 0, 0, 0, 5060, 0 );
                                                                Effects.PlaySound( from.Location, from.Map, 0x23B );
                                                                Effects.SendMovingParticles( new Entity( Serial.Zero, new Point3D( from.X - 6, from.Y - 6, from.Z + 15 ), from.Map ), from, 0x36D4, 7, 0, false, true, 0x497, 0, 9502, 1, 0, (EffectLayer)255, 0x100 );
                                                                Effects.SendMovingParticles( new Entity( Serial.Zero, new Point3D( from.X - 4, from.Y - 6, from.Z + 15 ), from.Map ), from, 0x36D4, 7, 0, false, true, 0x497, 0, 9502, 1, 0, (EffectLayer)255, 0x100 );
                                                                Effects.SendMovingParticles( new Entity( Serial.Zero, new Point3D( from.X - 6, from.Y - 4, from.Z + 15 ), from.Map ), from, 0x36D4, 7, 0, false, true, 0x497, 0, 9502, 1, 0, (EffectLayer)255, 0x100 );
                                                        }
                                                }
				                else if ( o is BasePoleArm )
				                {
					                if ( from.CheckTargetSkill( SkillName.ItemID, o, 70.0, 100 ) )
					                {
							        ((BasePoleArm)o).Identified = true;

		                                                from.BoltEffect( 0x480 );
                                                                from.PlaySound(Utility.RandomList( 0x028,0x029,0x206 ) );

                                                                Effects.SendLocationParticles( EffectItem.Create( from.Location, from.Map, EffectItem.DefaultDuration ), 0, 0, 0, 0, 0, 5060, 0 );
                                                                Effects.PlaySound( from.Location, from.Map, 0x237 );
                                                                Effects.SendMovingParticles( new Entity( Serial.Zero, new Point3D( from.X - 6, from.Y - 6, from.Z + 15 ), from.Map ), from, 0x36D4, 7, 0, false, true, 0x497, 0, 9502, 1, 0, (EffectLayer)255, 0x100 );
                                                                Effects.SendMovingParticles( new Entity( Serial.Zero, new Point3D( from.X - 4, from.Y - 6, from.Z + 15 ), from.Map ), from, 0x36D4, 7, 0, false, true, 0x497, 0, 9502, 1, 0, (EffectLayer)255, 0x100 );
                                                                Effects.SendMovingParticles( new Entity( Serial.Zero, new Point3D( from.X - 6, from.Y - 4, from.Z + 15 ), from.Map ), from, 0x36D4, 7, 0, false, true, 0x497, 0, 9502, 1, 0, (EffectLayer)255, 0x100 );
                                                        }
                                                }
				                else if ( o is BaseRanged )
				                {
					                if ( from.CheckTargetSkill( SkillName.ItemID, o, 25.0, 100 ) )
					                {
							        ((BaseRanged)o).Identified = true;

		                                                from.BoltEffect( 0x480 );
                                                                from.PlaySound(Utility.RandomList( 0x028,0x029,0x206 ) );

                                                                Effects.SendLocationParticles( EffectItem.Create( from.Location, from.Map, EffectItem.DefaultDuration ), 0, 0, 0, 0, 0, 5060, 0 );
                                                                Effects.PlaySound( from.Location, from.Map, 0x234 );
                                                                Effects.SendMovingParticles( new Entity( Serial.Zero, new Point3D( from.X - 6, from.Y - 6, from.Z + 15 ), from.Map ), from, 0x36D4, 7, 0, false, true, 0x497, 0, 9502, 1, 0, (EffectLayer)255, 0x100 );
                                                                Effects.SendMovingParticles( new Entity( Serial.Zero, new Point3D( from.X - 4, from.Y - 6, from.Z + 15 ), from.Map ), from, 0x36D4, 7, 0, false, true, 0x497, 0, 9502, 1, 0, (EffectLayer)255, 0x100 );
                                                                Effects.SendMovingParticles( new Entity( Serial.Zero, new Point3D( from.X - 6, from.Y - 4, from.Z + 15 ), from.Map ), from, 0x36D4, 7, 0, false, true, 0x497, 0, 9502, 1, 0, (EffectLayer)255, 0x100 );
                                                        }
                                                }
				                else if ( o is BaseSpear )
				                {
					                if ( from.CheckTargetSkill( SkillName.ItemID, o, 50.0, 100 ) )
					                {
							        ((BaseSpear)o).Identified = true;

		                                                from.BoltEffect( 0x480 );
                                                                from.PlaySound(Utility.RandomList( 0x028,0x029,0x206 ) );

                                                                Effects.SendLocationParticles( EffectItem.Create( from.Location, from.Map, EffectItem.DefaultDuration ), 0, 0, 0, 0, 0, 5060, 0 );
                                                                Effects.PlaySound( from.Location, from.Map, 0x23C );
                                                                Effects.SendMovingParticles( new Entity( Serial.Zero, new Point3D( from.X - 6, from.Y - 6, from.Z + 15 ), from.Map ), from, 0x36D4, 7, 0, false, true, 0x497, 0, 9502, 1, 0, (EffectLayer)255, 0x100 );
                                                                Effects.SendMovingParticles( new Entity( Serial.Zero, new Point3D( from.X - 4, from.Y - 6, from.Z + 15 ), from.Map ), from, 0x36D4, 7, 0, false, true, 0x497, 0, 9502, 1, 0, (EffectLayer)255, 0x100 );
                                                                Effects.SendMovingParticles( new Entity( Serial.Zero, new Point3D( from.X - 6, from.Y - 4, from.Z + 15 ), from.Map ), from, 0x36D4, 7, 0, false, true, 0x497, 0, 9502, 1, 0, (EffectLayer)255, 0x100 );
                                                        }
                                                }
				                else if ( o is BaseStaff )
				                {
					                if ( from.CheckTargetSkill( SkillName.ItemID, o, 35.0, 100 ) )
					                {
							        ((BaseStaff)o).Identified = true;

		                                                from.BoltEffect( 0x480 );
                                                                from.PlaySound(Utility.RandomList( 0x028,0x029,0x206 ) );

                                                                Effects.SendLocationParticles( EffectItem.Create( from.Location, from.Map, EffectItem.DefaultDuration ), 0, 0, 0, 0, 0, 5060, 0 );
                                                                Effects.PlaySound( from.Location, from.Map, 0x233 );
                                                                Effects.SendMovingParticles( new Entity( Serial.Zero, new Point3D( from.X - 6, from.Y - 6, from.Z + 15 ), from.Map ), from, 0x36D4, 7, 0, false, true, 0x497, 0, 9502, 1, 0, (EffectLayer)255, 0x100 );
                                                                Effects.SendMovingParticles( new Entity( Serial.Zero, new Point3D( from.X - 4, from.Y - 6, from.Z + 15 ), from.Map ), from, 0x36D4, 7, 0, false, true, 0x497, 0, 9502, 1, 0, (EffectLayer)255, 0x100 );
                                                                Effects.SendMovingParticles( new Entity( Serial.Zero, new Point3D( from.X - 6, from.Y - 4, from.Z + 15 ), from.Map ), from, 0x36D4, 7, 0, false, true, 0x497, 0, 9502, 1, 0, (EffectLayer)255, 0x100 );
                                                        }
                                                }
				                else if ( o is BaseSword )
				                {
					                if ( from.CheckTargetSkill( SkillName.ItemID, o, 25.0, 100 ) )
					                {
							        ((BaseSword)o).Identified = true;

		                                                from.BoltEffect( 0x480 );
                                                                from.PlaySound(Utility.RandomList( 0x028,0x029,0x206 ) );

                                                                Effects.SendLocationParticles( EffectItem.Create( from.Location, from.Map, EffectItem.DefaultDuration ), 0, 0, 0, 0, 0, 5060, 0 );
                                                                Effects.PlaySound( from.Location, from.Map, 0x237 );
                                                                Effects.SendMovingParticles( new Entity( Serial.Zero, new Point3D( from.X - 6, from.Y - 6, from.Z + 15 ), from.Map ), from, 0x36D4, 7, 0, false, true, 0x497, 0, 9502, 1, 0, (EffectLayer)255, 0x100 );
                                                                Effects.SendMovingParticles( new Entity( Serial.Zero, new Point3D( from.X - 4, from.Y - 6, from.Z + 15 ), from.Map ), from, 0x36D4, 7, 0, false, true, 0x497, 0, 9502, 1, 0, (EffectLayer)255, 0x100 );
                                                                Effects.SendMovingParticles( new Entity( Serial.Zero, new Point3D( from.X - 6, from.Y - 4, from.Z + 15 ), from.Map ), from, 0x36D4, 7, 0, false, true, 0x497, 0, 9502, 1, 0, (EffectLayer)255, 0x100 );
                                                        }
                                                }
                                        }
					else
					{
						from.SendLocalizedMessage( 500353 ); // You are not certain...
					}
				}
                                else if ( o is Corpse )
                                {
                                        PlayerMobile pm = from as PlayerMobile;
 
                                        if ( pm.Skills[SkillName.ItemID].Base >= 100.0 )
                                        {
                                               Container cont = ( Container )o;
                                               foreach ( Item item in cont.Items )
                                               {
                                                      if ( item is BaseWeapon )
                                                            ((BaseWeapon)item).Identified = true;
                                                      else if ( item is BaseArmor )
                                                            ((BaseArmor)item).Identified = true;
                                               }
                                        }
                                }
				else if ( o is Mobile )
				{
					((Mobile)o).OnSingleClick( from );
				}
				else
				{
					from.SendLocalizedMessage( 500353 ); // You are not certain...
				}
			}
		}
	}
}