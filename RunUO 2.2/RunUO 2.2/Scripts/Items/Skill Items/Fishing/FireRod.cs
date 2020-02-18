using System;
using System.Collections;
using System.Collections.Generic;
using Server.ContextMenus;
using Server.Engines.Harvest;
using Server.Items;
using Server.Targeting;

namespace Server.Items
{
	[FlipableAttribute( 15906, 15907 )]
	public class FireRod : BaseStaff
	{
		public override int AosStrengthReq{ get{ return 10; } }
		public override int AosMinDamage{ get{ return 1; } }
		public override int AosMaxDamage{ get{ return 2; } }
		public override float MlSpeed{ get{ return 2.50f; } }

		public override int InitMinHits{ get{ return 5; } }
		public override int InitMaxHits{ get{ return 10; } }

		[Constructable]
		public FireRod() : base( 15906 )
		{
                        Name = "Fire Rod";
			Hue = 1360;
			Layer = Layer.OneHanded;
			Weight = 9.0;

			WeaponAttributes.HitFireball = 5;
			Attributes.SpellChanneling = 1;
		}

		public override void GetDamageTypes( Mobile wielder, out int phys, out int fire, out int cold, out int pois, out int nrgy, out int chaos, out int direct )
		{
			chaos = direct = cold = pois = nrgy = 0;
                        phys = 20;
                        fire = 80;
		}

		public override void OnDoubleClick( Mobile from )
		{
			Fishing.System.BeginHarvesting( from, this );
		}

		public override void GetContextMenuEntries( Mobile from, List<ContextMenuEntry> list )
		{
			base.GetContextMenuEntries( from, list );

			BaseHarvestTool.AddContextMenuEntries( from, this, list, Fishing.System );
		}

		public override bool OnEquip( Mobile from )
		{
			from.Skills[SkillName.Fishing].Base += 5;
			return base.OnEquip( from );
		}

		public override void OnRemoved( object parent )
		{
			if ( parent is Mobile )
			{
				Mobile m = (Mobile)parent;
				m.Skills[SkillName.Fishing].Base -= 5;
			}

			base.OnRemoved( parent );
		}

		public FireRod( Serial serial ) : base( serial )
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