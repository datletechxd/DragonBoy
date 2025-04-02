using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DragonBoy.Mod.Utils
{
    internal class Boss
    {
        public string NameBoss;

        public string MapName;

        public int MapId;

        public DateTime AppearTime;

        public Boss(string chatVip)
        {
            chatVip = chatVip.Replace("BOSS ", "").Replace(" vừa xuất hiện tại ", "|").Replace(" appear at ", "|");
            string[] array = chatVip.Split(new char[]
            {
                '|'
            });
            NameBoss = array[0].Trim();
            MapName = array[1].Trim();
            MapId = getMapID(MapName);
            AppearTime = DateTime.Now;
        }

        public int getMapID(string mapName)
        {
            for (int i = 0; i < TileMap.mapNames.Length; i++)
            {
                if (TileMap.mapNames[i].Equals(mapName))
                {
                    return i;
                }
            }
            return -1;
        }

        public void paint(mGraphics g, int x, int y, int align)
        {
            TimeSpan timeSpan = DateTime.Now.Subtract(AppearTime);
            int num = (int)timeSpan.TotalSeconds;
            mFont mFont = mFont.tahoma_7_yellow;
            if (TileMap.mapID == MapId)
            {
                mFont = mFont.tahoma_7_red;
                for (int i = 0; i < GameScr.vCharInMap.size(); i++)
                {
                    if (((Char)GameScr.vCharInMap.elementAt(i)).cName.Equals(NameBoss))
                    {
                        mFont = mFont.tahoma_7b_red;
                        break;
                    }
                }
            }
            mFont.drawString(g, string.Concat(new string[]
            {
                NameBoss,
                " - ",
                MapName,
                " - ",
                num < 60 ? num.ToString() + "s" : timeSpan.Minutes.ToString() + "ph",
                " trước"
            }), x, y, align);
        }
    }
}
