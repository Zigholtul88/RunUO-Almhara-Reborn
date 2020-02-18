using System;
using Server;
using Server.Multis;
using System.Collections.Generic;
using Server.Items;

namespace Server.Mobiles
{
	[CorpseName( "the corpse of roger" )]
	public class TestMob4 : BaseCreature
	{
                public static readonly TimeSpan SpawnRate = TimeSpan.FromSeconds(30);
                public static readonly int SpawnMax = 25;

                private List<Mobile> m_Eels = new List<Mobile>();
                private DateTime m_NextSpawn;
                private DateTime m_NextSpecial;
                private DateTime m_NextWaterBall;

		[Constructable]
		public TestMob4() : base( AIType.AI_Animal, FightMode.Aggressor, 10, 1, 0.2, 0.4 )
		{
			Name = "test mob 4";
			Body = 248;

			SetStr( 146, 175 );
			SetDex( 111, 150 );
			SetInt( 46, 60 );

			SetHits( 131, 160 );
			SetMana( 0 );

			SetDamage( 6, 11 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 50, 70 );
			SetResistance( ResistanceType.Fire, 30, 50 );
			SetResistance( ResistanceType.Cold, 30, 50 );
			SetResistance( ResistanceType.Poison, 40, 60 );
			SetResistance( ResistanceType.Energy, 30, 50 );

			SetSkill( SkillName.MagicResist, 37.6, 42.5 );
			SetSkill( SkillName.Tactics, 70.6, 83.0 );
			SetSkill( SkillName.Wrestling, 50.1, 57.5 );

			Fame = 2000;
			Karma = -2000;

                        m_NextSpawn = DateTime.UtcNow + SpawnRate;
                        m_NextSpecial = DateTime.UtcNow;
                        m_NextWaterBall = DateTime.UtcNow;

			Tamable = true;
			ControlSlots = 1;
			MinTameSkill = 68.7;
		}

		public override int GetAngerSound() { return 0x4F8; }
		public override int GetIdleSound() { return 0x4F7; }
		public override int GetAttackSound() { return 0x4F6; }  
		public override int GetHurtSound() { return 0x4F9; } 
		public override int GetDeathSound() { return 0x4F5; }

		public override int Meat{ get{ return 10; } }
		public override int Hides{ get{ return 15; } }
		public override FoodType FavoriteFood{ get{ return FoodType.GrainsAndHay; } }

                public void AddEel(Mobile eel)
                {
                        if (!m_Eels.Contains(eel) && eel is ParasiticEel)
                             m_Eels.Add(eel);
                }

                public void RemoveEel(Mobile eel)
                {
                        if (m_Eels.Contains(eel))
                            m_Eels.Remove(eel);
                }

                public override void OnDamagedBySpell(Mobile from)
                {
                         base.OnDamagedBySpell(from);

                         if (m_NextSpawn < DateTime.UtcNow && m_Eels.Count < SpawnMax && 0.25 > Utility.RandomDouble())
                             SpawnEel(from);
                }

                public override void OnGotMeleeAttack(Mobile attacker)
                {
                         base.OnGotMeleeAttack(attacker);

                         if (attacker.Weapon is BaseRanged && m_NextSpawn < DateTime.UtcNow && m_Eels.Count < SpawnMax && 0.25 > Utility.RandomDouble())
                             SpawnEel(attacker);
                }

                public override void OnThink()
                {
                        base.OnThink();

                        if (m_NextSpecial < DateTime.UtcNow)
                        DoAreaExplosion();
                }

                public override void OnActionCombat()
                {
                        Mobile combatant = this.Combatant as Mobile;

                        if (combatant == null || combatant.Deleted || combatant.Map != this.Map || !this.InRange(combatant, 12) || !this.CanBeHarmful(combatant) || !this.InLOS(combatant))
                            return;

                        if (DateTime.UtcNow >= this.m_NextWaterBall)
                        {
                                double damage = combatant.Hits * 0.3;

                                if (damage < 10.0)
                                    damage = 10.0;
                                else if (damage > 40.0)
                                    damage = 40.0;

                                this.DoHarmful(combatant);
                                this.MovingParticles(combatant, 0x36D4, 5, 0, false, false, 195, 0, 9502, 3006, 0, 0, 0);
                                AOS.Damage(combatant, this, (int)damage, 100, 0, 0, 0, 0);

                                m_NextWaterBall = DateTime.UtcNow + TimeSpan.FromMinutes(1);
                        }
                }

                public void SpawnEel(Mobile m)
                {
                        Map map = this.Map;

                        int x = m.X; int y = m.Y; int z = m.Z;

                        Point3D loc = m.Location;

                        for (int j = 0; j < 3; j++)
                        {
                                for (int i = 0; i < 25; i++)
                                {
                                        x = Utility.RandomMinMax(loc.X - 1, loc.X + 1);
                                        y = Utility.RandomMinMax(loc.Y - 1, loc.Y + 1);

                                        if (Spells.SpellHelper.CheckMulti(new Point3D(x, y, m.Z), map) || map.CanSpawnMobile(x, y, z))
                                        {
                                                ParasiticEel eel = new ParasiticEel(this);
                                                eel.MoveToWorld(new Point3D(x, y, loc.Z), map);

                                                if (m is PlayerMobile)
                                                    eel.Combatant = m;

                                                break;
                                         }
                                }
                        }

                        m_NextSpawn = DateTime.UtcNow + SpawnRate;
                }

                public void DoAreaExplosion()
                {
                        List<Mobile> toExplode = new List<Mobile>();

                        IPooledEnumerable eable = this.GetMobilesInRange(8);
                        foreach (Mobile mob in eable)
                        {
                                if(!CanBeHarmful(mob, false) || mob == this || (mob is BaseCreature && ((BaseCreature)mob).GetMaster() == this))
                                    continue;
                                if(mob.Player)
                                    toExplode.Add(mob);
                                if (mob is BaseCreature && (((BaseCreature)mob).Controlled || ((BaseCreature)mob).Summoned || ((BaseCreature)mob).Team != this.Team))
                                    toExplode.Add(mob);
                         }
                         eable.Free();

                         foreach (Mobile mob in toExplode)
                         {
                                 mob.FixedParticles(0x36BD, 20, 10, 5044, EffectLayer.Head);
                                 mob.PlaySound(0x307);

                                 int damage = Utility.RandomMinMax(50, 125);
                                 AOS.Damage(mob, this, damage, 0, 100, 0, 0, 0);
                         }

                         m_NextSpecial = DateTime.UtcNow + TimeSpan.FromSeconds(Utility.RandomMinMax(15, 20));
                }

                public override void Delete()
                {
                        if (m_Eels != null)
                        {
                                List<Mobile> eels = new List<Mobile>(m_Eels);
                                for (int i = 0; i < eels.Count; i++)
                                {
                                        if (eels[i] != null)
                                            eels[i].Kill();
                                }
                        }

                        base.Delete();
                }

		public TestMob4( Serial serial ) : base( serial )
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

                        m_NextSpawn = DateTime.UtcNow;
                        m_NextSpecial = DateTime.UtcNow;
                        m_NextWaterBall = DateTime.UtcNow;
		}
	}

        public class ParasiticEel : BaseCreature
        {
                private Mobile m_Master;

                public ParasiticEel(Mobile master): base(AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4)
                {
                        if (master is TestMob4)
                        {
                                m_Master = master;
                                ((TestMob4)master).AddEel(this);
                        }

                        Name = "a parasitic eel";
                        Body = 0x34;
                        //BaseSoundID = 589; 

                        //CanSwim = true;
                        //CantWalk = true;

                        SetStr(80, 125);
                        SetDex(150, 250);
                        SetInt(20, 40);

                        SetHits(100);

                        SetDamage(4, 12);

                        SetDamageType(ResistanceType.Physical, 25);
                        SetDamageType(ResistanceType.Cold, 25);
                        SetDamageType(ResistanceType.Poison, 50);

                        SetResistance(ResistanceType.Physical, 20);
                        SetResistance(ResistanceType.Fire, 10, 25);
                        SetResistance(ResistanceType.Cold, 10, 25);
                        SetResistance(ResistanceType.Poison, 99);
                        SetResistance(ResistanceType.Energy, 5, 10);

                        SetSkill(SkillName.Wrestling, 52.0, 70.0);
                        SetSkill(SkillName.Tactics, 0.0);
                        SetSkill(SkillName.MagicResist, 100.4, 113.5);
                        SetSkill(SkillName.Anatomy, 1.0, 0.0);
                        SetSkill(SkillName.Magery, 60.2, 72.4);
                        SetSkill(SkillName.EvalInt, 60.1, 73.4);
                        SetSkill(SkillName.Meditation, 100.0);

                        Fame = 2500;
                        Karma = -2500;
                }

                public override void Delete()
                {
                       if (m_Master != null && m_Master is TestMob4)
                          ((TestMob4)m_Master).RemoveEel(this);

                        base.Delete();
                }

                public override void GenerateLoot()
                {
                        AddLoot(LootPack.FilthyRich, 1);
                }

                public ParasiticEel(Serial serial): base(serial)
                {
                }

                public override void Serialize(GenericWriter writer)
                {
                        base.Serialize(writer);
                        writer.Write((int)0);
                        writer.Write(m_Master);
                }

                public override void Deserialize(GenericReader reader)
                {
                        base.Deserialize(reader);
                        int version = reader.ReadInt();
                        m_Master = reader.ReadMobile();
                }
        }
}
