using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ArcheBuddy.Bot.Classes;

namespace AutoExp.Quests
{
    internal class Quest_4243 : Quest
    {
        public Quest_4243(int minLvl, int maxLvl, QuestRace race, uint[] reqQuests)
            : base(4243, minLvl, maxLvl, race, reqQuests)
        { }

        public override bool RunQuest(Host host)
        {
            if (!base.RunQuest(host))
                return false;

            if (getQuest() == null)
            {
                if (!host.movementModule.GpsMove("White_Ryark"))
                    return false;
                host.StartQuest(id);
                Thread.Sleep(1000);
            }

            ArcheBuddy.Bot.Classes.Quest quest = getQuest();

            if (quest != null && quest.status == QuestStatus.Accepted)
            {
                if (!host.movementModule.GpsMove("Quest_4243_1")) return false;
                Thread.Sleep(1000);
                host.farmModule.UseDoodadSkill(14560, host.getNearestDoodad(5919), true);
                Thread.Sleep(1000);
            }

            return true;
        }
    }
}
