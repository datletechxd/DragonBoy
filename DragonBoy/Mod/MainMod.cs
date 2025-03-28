using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
        }
    }
}
