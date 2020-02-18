/*
 * This file is highly inspired by the Server/Engines/Quests/Core/QuestSerializer.cs file
 * 
 * Therefore no copyright is put on it except the general GPL that is on the whole project RunUO
 * 
 * Thanx to the people who made this project
 */
 

/*
 * This file serializes and deserializes LoggedQuestInfo objects... It handles the possible subclasses that
 * a programmer can put up to handle the quests...
 */
 
using System;

namespace Server.Fearyourself.Quests.Core
{
    public class LoggedQuestInfoSerializer
	{
		public static object Construct( Type type )
		{
			try
			{
				return Activator.CreateInstance( type );
			}
			catch
			{
				return null;
			}
		}

		public static void Write( Type type, Type[] referenceTable, GenericWriter writer )
		{
			if ( type == null )
			{
				writer.WriteEncodedInt( (int) 0x00 );
			}
			else
			{
				for ( int i = 0; i < referenceTable.Length; ++i )
				{
					if ( referenceTable[i] == type )
					{
						writer.WriteEncodedInt( (int) 0x01 );
						writer.WriteEncodedInt( (int) i );
						return;
					}
				}

				writer.WriteEncodedInt( (int) 0x02 );
				writer.Write( type.FullName );
			}
		}

		public static Type ReadType( Type[] referenceTable, GenericReader reader )
		{
			int encoding = reader.ReadEncodedInt();

			switch ( encoding )
			{
				default:
				case 0x00: // null
				{
					return null;
				}
				case 0x01: // indexed
				{
					int index = reader.ReadEncodedInt();

					if ( index >= 0 && index < referenceTable.Length )
						return referenceTable[index];

					return null;
				}
				case 0x02: // by name
				{
					string fullName = reader.ReadString();

					if ( fullName == null )
						return null;

					return ScriptCompiler.FindTypeByFullName( fullName, false );
				}
			}
		}

		public static LoggedQuestInfo Deserialize( GenericReader reader )
		{
			int encoding = reader.ReadEncodedInt();

			switch ( encoding )
			{
				default:
				case 0x00: // null
				{
					return null;
				}
				case 0x01:
				{
					Type type = ReadType( LoggedQuestInfo.InfoTypes, reader );
                    
					LoggedQuestInfo lqi = Construct( type ) as LoggedQuestInfo;

					if ( lqi != null )
						lqi.BaseDeserialize( reader );

					return lqi;
				}
			}
		}

		public static void Serialize( LoggedQuestInfo lqi, GenericWriter writer )
		{
            if (lqi == null)
			{
				writer.WriteEncodedInt( 0x00 );
			}
			else
			{
				writer.WriteEncodedInt( 0x01 );

                Write( lqi.GetType(), LoggedQuestInfo.InfoTypes, writer);

				lqi.BaseSerialize( writer );
			}
		}
	}
}