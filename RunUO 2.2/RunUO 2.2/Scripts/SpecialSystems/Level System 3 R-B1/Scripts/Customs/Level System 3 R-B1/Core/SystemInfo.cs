using System;
using System.IO;
using System.Xml;
using System.Collections;
using System.Collections.Generic;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Network;

namespace Server
{
    public static class SystemInfo
    {
        public const string FileName = "LevelInfo.xml";
        public const string FilePath = @"Saves/Level System/";

        public static Dictionary<int, InfoList> PlayerInfo;

        static SystemInfo()
        {
            PlayerInfo = new Dictionary<int, InfoList>();
        }

        public static void Initialize()
        {
            LoadPlayers(false);
            EventSink.Login += new LoginEventHandler(EventSink_Login);
            EventSink.WorldSave += new WorldSaveEventHandler(EventSink_Save);
        }

        public static void LoadPlayers(bool Reload)
        {
            string Root = null;
            string Parent = null;
            int PlayersLoaded = 0;
            Setup set = new Setup();
            DateTime Start = DateTime.Now;

            ConsoleColor col = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.DarkGreen;

            if (Reload)
            {
                PlayerInfo.Clear();
                Console.Write("Level System: Reloading... ");
            }
            else
                Console.Write("Level System: Loading... ");

            if (!Directory.Exists(FilePath))
                Directory.CreateDirectory(FilePath);

            if (!File.Exists(FilePath + FileName))
            {
                Console.WriteLine("-No Save Found- Done!");
                Console.ForegroundColor = col;
                return;
            }

            XmlDocument doc = new XmlDocument();
            doc.Load(FilePath + FileName);

            if (doc.DocumentElement != null)
                Root = doc.DocumentElement.Name;

            if (doc.DocumentElement.FirstChild != null)
                Parent = doc.DocumentElement.FirstChild.Name;

            if (Root == null | Parent == null)
            {
                Console.WriteLine("-Empty Save- Done!");
                Console.ForegroundColor = col;
                return;
            }

            XmlNodeList IDList = doc.SelectNodes("/" + Root + "/" + Parent);

            foreach (XmlNode id in IDList)
            {
                try
                {
                    int ID = Convert.ToInt32(id.Attributes["Serial"].Value);

                    int Level = Convert.ToInt32(id.SelectSingleNode("Level").InnerText);
                    int LevelCap = Convert.ToInt32(id.SelectSingleNode("LevelCap").InnerText);
                    double KillExp = Convert.ToDouble(id.SelectSingleNode("KillExp").InnerText);
                    double AccKillExp = Convert.ToDouble(id.SelectSingleNode("AccKillExp").InnerText);
                    int LevelAt = Convert.ToInt32(id.SelectSingleNode("LevelAt").InnerText);
                    int AccLevelAt = Convert.ToInt32(id.SelectSingleNode("AccLevelAt").InnerText);

                    if (!PlayerInfo.ContainsKey(ID))
                        PlayerInfo.Add(ID, new InfoList(Level, LevelCap, KillExp, AccKillExp, LevelAt, AccLevelAt));

                    PlayersLoaded++;
                }
                catch (Exception e)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine();
                    Console.WriteLine("ERROR: " + e);
                }
            }

            if (!Reload || Reload && set.TimeReload)
                Console.WriteLine("Done! ({0} players, {1:F1} seconds)", PlayersLoaded, (DateTime.Now - Start).TotalSeconds);

            if (Reload)
            {
                if (!set.TimeReload)
                    Console.WriteLine("Done!");

                Console.ForegroundColor = col;
                Console.Write("Save ");
            }
            Console.ForegroundColor = col;
        }
        public static void EventSink_Login(LoginEventArgs args)
        {
            Setup set = new Setup();

            NetState ns = args.Mobile.NetState;
            PlayerMobile pm = args.Mobile as PlayerMobile;

            if (PlayerInfo.ContainsKey(Convert.ToInt32(pm.Serial)))//Loaded
            {
                InfoList info = PlayerInfo[Convert.ToInt32(pm.Serial)];
                
                if (pm.Level > info.Level | pm.KillExp > info.KillExp)//Login-Logout-Login Saftey:
                    return;

                pm.Level = info.Level;
                pm.LevelCap = info.LevelCap;
                pm.KillExp = info.KillExp;
                pm.AccKillExp = info.AccKillExp;
                pm.LevelAt = info.LevelAt;
                pm.AccLevelAt = info.AccLevelAt;
            }
            else//Newbie
            {
                pm.Level = 1;
                pm.LevelCap = set.StartingLevelCap;
                pm.KillExp = 0;
                pm.AccKillExp = 0;
                pm.LevelAt = set.NextLevelAt;
                pm.AccLevelAt = set.NextLevelAt;

                PlayerInfo.Add(Convert.ToInt32(pm.Serial),
                    new InfoList(pm.Level, pm.LevelCap, pm.KillExp, pm.AccKillExp, pm.LevelAt, pm.AccLevelAt));
            }
        }

        public static void EventSink_Save(WorldSaveEventArgs args)
        {
            ConsoleColor col = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.DarkGreen;

            Console.WriteLine();
            Console.Write("Level System: Saving... ");
            Setup set = new Setup();
            DateTime Start = DateTime.Now;

            if (!Directory.Exists(FilePath))
                Directory.CreateDirectory(FilePath);

            if (File.Exists(FilePath + FileName))
                File.Delete(FilePath + FileName);

            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.IndentChars = "	";

            XmlWriter writer = XmlWriter.Create(FilePath + FileName, settings);
            writer.WriteStartElement("Info");

            string ID;

            foreach (Mobile mob in World.Mobiles.Values)
            {
                if (mob is PlayerMobile)
                {
                    PlayerMobile pm = mob as PlayerMobile;

                    if (PlayerInfo.ContainsKey(Convert.ToInt32(pm.Serial)))
                    {
                        InfoList info = PlayerInfo[Convert.ToInt32(pm.Serial)];

                        ID = Convert.ToString(Convert.ToInt32(pm.Serial));
                        writer.WriteStartElement("ID");
                        writer.WriteStartAttribute("", "Serial", "");
                        writer.WriteString(ID);
                        writer.WriteEndAttribute();

                        if (info.Level > pm.Level && pm.Level == 0 || info.KillExp > pm.KillExp && pm.KillExp == 0)
                        {   //Login-Save-Restart-No Login-Save Saftey
                            SystemInfo.SaveValue("Level", info.Level, 0, writer);
                            SystemInfo.SaveValue("LevelCap", info.LevelCap, 0, writer);
                            SystemInfo.SaveValue("KillExp", info.KillExp, 1, writer);
                            SystemInfo.SaveValue("AccKillExp", info.AccKillExp, 1, writer);
                            SystemInfo.SaveValue("LevelAt", info.LevelAt, 0, writer);
                            SystemInfo.SaveValue("AccLevelAt", info.LevelAt, 0, writer);
                        }
                        else
                        {
                            SystemInfo.SaveValue("Level", pm.Level, 0, writer);
                            SystemInfo.SaveValue("LevelCap", pm.LevelCap, 0, writer);
                            SystemInfo.SaveValue("KillExp", pm.KillExp, 1, writer);
                            SystemInfo.SaveValue("AccKillExp", pm.AccKillExp, 1, writer);
                            SystemInfo.SaveValue("LevelAt", pm.LevelAt, 0, writer);
                            SystemInfo.SaveValue("AccLevelAt", pm.LevelAt, 0, writer);
                        }

                        writer.WriteEndElement();
                    }
                }
            }

            writer.WriteEndElement();
            writer.Close();

            if (set.TimeSave)
                Console.WriteLine("Done! ({0:F1} seconds)", (DateTime.Now - Start).TotalSeconds);
            else
                Console.WriteLine("Done!");

            Console.ForegroundColor = col;
            LoadPlayers(true);
        }
        internal static void SaveValue(string Name, object Value, int ValueType, XmlWriter writer)
        {
            switch (ValueType)
            {
                case 0://Int
                    {
                        writer.WriteStartElement(Name);
                        writer.WriteValue((int)Value);
                        writer.WriteEndElement();
                        break;
                    }
                case 1://Double
                    {
                        writer.WriteStartElement(Name);
                        writer.WriteValue((double)Value);
                        writer.WriteEndElement();
                        break;
                    }
            }
        }
    }

    public class InfoList
    {
        public int Level;
        public int LevelCap;
        public double KillExp;
        public double AccKillExp;
        public int LevelAt;
        public int AccLevelAt;

        public InfoList(int Level, int LevelCap, double KillExp, double AccKillExp, int LevelAt, int AccLevelAt)
        {
            this.Level = Level;
            this.LevelCap = LevelCap;
            this.KillExp = KillExp;
            this.AccKillExp = AccKillExp;
            this.LevelAt = LevelAt;
            this.AccLevelAt = AccLevelAt;
        }
    }
}