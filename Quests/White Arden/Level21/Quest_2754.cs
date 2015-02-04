using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ArcheBuddy.Bot.Classes;

namespace AutoExp.Quests
{
    internal class Quest_2754 : Quest
    {
        public Quest_2754(int minLvl, int maxLvl, QuestRace race, uint[] reqQuests)
            : base(2754, minLvl, maxLvl, race, reqQuests)
        { }

        public override bool RunQuest(Host host)
        {
            if (!base.RunQuest(host))
                return false;

            if (getQuest() == null)
            {
                if (!host.movementModule.GpsMove("White_Xelmok"))
                    return false;
                host.StartQuest(id);
                Thread.Sleep(1000);
            }

            ArcheBuddy.Bot.Classes.Quest quest = getQuest();

            if (quest != null && quest.status == QuestStatus.Accepted)
            {
                if (!host.movementModule.GpsMove("White_Xelmok")) return false;
                Thread.Sleep(1000);
                host.farmModule.UseDoodadSkill(14847, host.getNearestDoodad(7446), true);
                Thread.Sleep(1000);
                var d = host.getNearestDoodad(7443);
                host.ComeTo(d, 1);
                host.farmModule.UseDoodadSkill(14846, d, true);
                Thread.Sleep(1000);
            }

            if (quest != null && quest.status == QuestStatus.Performed)
            {
                if (!host.movementModule.GpsMove("White_Deivin")) return false;
                Thread.Sleep(1000);
                host.CompleteQuest(id);
                Thread.Sleep(1000);
            }
             

            return true;
        }
    }
}
