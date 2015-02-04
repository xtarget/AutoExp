using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ArcheBuddy.Bot.Classes;

namespace AutoExp.Quests
{
    internal class Quest_1141 : Quest
    {
        public Quest_1141(int minLvl, int maxLvl, QuestRace race, uint[] reqQuests)
            : base(1141, minLvl, maxLvl, race, reqQuests)
        { }

        public override bool RunQuest(Host host)
        {
            if (!base.RunQuest(host))
                return false;

            if (getQuest() == null)
            {
                if (!host.movementModule.GpsMove("Arcum_Megrab"))
                    return false;
                host.StartQuest(id);
                Thread.Sleep(1000);
            }

            if (!checkQuestCompletedOrAccepted(1142))
                return false;

            ArcheBuddy.Bot.Classes.Quest quest = getQuest();

            if (quest != null && quest.status == ArcheBuddy.Bot.Classes.QuestStatus.Accepted)
            {
                if (!host.movementModule.GpsMove("Quest_1141_1"))
                    return false;
                var d = host.getNearestDoodad(3074);
                if (d != null && host.dist(d) < 10)
                    host.farmModule.UseItemAndWait(13993);
                Thread.Sleep(1500);
            }

            if (!checkQuestCompletedOrPerfomed(1142))
                return false;

            if (quest != null && quest.status == ArcheBuddy.Bot.Classes.QuestStatus.Performed)
            {
                if (!host.movementModule.GpsMove("Arcum_Megrab"))
                    return false;
                host.CompleteQuest(id);
                Thread.Sleep(1000);
            }
            

            return true;
        }
    }
}
