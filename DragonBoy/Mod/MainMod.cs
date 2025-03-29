using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace DragonBoy.Mod
{
    internal class MainMod
    {
        public static MainMod _Instance;

        public static int runSpeed = 8;

        public static MainMod getInstance()
        {
            if (_Instance == null)
            {
                _Instance = new MainMod();
            }
            return _Instance;
        }

        public static void update()
        {
            global::Char.myCharz().cspeed = runSpeed;
            PaintInfo.update();
        }

        public static void onChatFromMe(String text)
        {
            if (text.Contains("ahsnm"))
            {
                AutoSkill.isAutoBuff = !AutoSkill.isAutoBuff;
                if (AutoSkill.isAutoBuff)
                {
                    new Thread(new ThreadStart(AutoSkill.autoBuff)).Start();
                }
                GameScr.info1.addInfo("Auto hồi sinh namec: " + (AutoSkill.isAutoBuff ? "On" : "Off"), 0);
                text = string.Empty;
            }
        }
    }
}
