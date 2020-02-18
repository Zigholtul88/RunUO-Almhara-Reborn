using System; 
using Server; 
using Server.Network; 

namespace Server.Items 
{ 
   public class BaseElixir : Item 
   { 
      private SkillName m_Skill; 

      [CommandProperty( AccessLevel.GameMaster )] 
      public SkillName Skill 
      { 
         get { return m_Skill; } 
         set { m_Skill = value; } 
      } 

      [Constructable] 
      public BaseElixir() : this( (SkillName)Utility.RandomMinMax( 0, 51 ) ) 
      { 
      } 

      [Constructable] 
      public BaseElixir( SkillName skill ) : base( 0xe2a ) 
      { 
         Hue = 0x290; 
         Weight = 1.0; 

         m_Skill = skill; 
      } 

      public BaseElixir( Serial serial ) : base( serial ) 
      { 
      } 

      public override void Serialize( GenericWriter writer ) 
      { 
         base.Serialize( writer ); 

         writer.Write( (int) 0 ); // version 

         writer.Write( (int) m_Skill ); 
      } 

      public override void Deserialize( GenericReader reader ) 
      { 
         base.Deserialize( reader ); 

         int version = reader.ReadInt(); 

         switch ( version ) 
         { 
            case 0: 
            { 
               m_Skill = (SkillName)reader.ReadInt(); 
               break; 
            } 
         } 
      } 

      private string GetName() 
      { 
         int index = (int)m_Skill; 
         SkillInfo[] table = SkillInfo.Table; 

         if ( index >= 0 && index < table.Length ) 
            return table[index].Name.ToLower(); 
         else 
            return "???"; 
      } 

      public override void AddNameProperty( ObjectPropertyList list ) 
      { 
         list.Add( string.Format( "elixir of {0}", GetName() ) ); 
      } 

        public override void OnDoubleClick( Mobile from ) 
      { 
         if ( Deleted ) 
            return; 

         if ( RootParent == from ) 
         { 
            Skill skill = from.Skills[m_Skill]; 

            if ( skill != null ) 
            { 
               if ( skill.Base < skill.Cap ) 
               { 
                  double newskill = skill.Base + 1; 

                  if ( newskill > skill.Cap ) 
                     newskill = skill.Cap; 

                  from.Skills[m_Skill].Base = newskill; 
                  from.PlaySound( 0x2D6 ); 
                  Delete(); 

                  from.SendMessage( "You feel a surge of magic as the elixir enhances your " + GetName() ); 
               } 
               else 
               { 
                  from.SendMessage( "You cannot reap the benefits of the elixir of " + GetName() +"." ); 
               } 
            } 
         } 
         else 
         { 
            from.SendLocalizedMessage( 1042001 ); // That must be in your pack for you to use it. 
         } 
      } 
   } 
}