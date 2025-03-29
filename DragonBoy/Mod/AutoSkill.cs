using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;

namespace DragonBoy.Mod
{
    internal class AutoSkill
    {
        public static bool isAutoBuff;

        public static sbyte ID_SKILL_BUFF = 7;

        public static MyVector getMyVector()
        {
            MyVector myVector = new MyVector();
            myVector.addElement(global::Char.myCharz());
            return myVector;
        }

        public static bool isSkillAvailable(out Skill skill)
        {
            skill = global::Char.myCharz().getSkill(new SkillTemplate { id = ID_SKILL_BUFF });
            if (skill == null)
            {
                GameScr.info1.addInfo("Không tìm thấy kỹ năng trị thương.", 0);
                return false;
            }
            return true;
        }

        public static void autoBuff()
        {
            while (isAutoBuff)
            {
                Skill skill;
                if (isSkillAvailable(out skill))
                {
                    if (mSystem.currentTimeMillis() - skill.lastTimeUseThisSkill > skill.coolDown)
                    {
                        Service.gI().selectSkill((int)ID_SKILL_BUFF);
                        Service.gI().sendPlayerAttack(new MyVector(), getMyVector(), -1);
                        Service.gI().selectSkill((int)global::Char.myCharz().myskill.template.id);
                        skill.lastTimeUseThisSkill = mSystem.currentTimeMillis();
                    }
                }
                Thread.Sleep(skill.coolDown);
            }
        }
    }
}
