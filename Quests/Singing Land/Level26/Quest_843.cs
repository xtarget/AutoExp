using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ArcheBuddy.Bot.Classes;


namespace AutoExp.Quests
{
    //
    internal class Quest_843 : Quest
    {
        public Quest_843(int minLvl, int maxLvl, QuestRace race, uint[] reqQuests)
            : base(843, minLvl, maxLvl, race, reqQuests)
        { }

        public override bool RunQuest(Host host)
        {
            if (!base.RunQuest(host))
                return false;

            if (getQuest() == null)
            {
                if (!host.movementModule.GpsMove("Signland_Ubein")) return false;
                Thread.Sleep(1000);
                host.StartQuest(id);
                Thread.Sleep(1000);
            }

            ArcheBuddy.Bot.Classes.Quest quest = getQuest();

            if (!checkQuestCompletedOrPerfomed(839))
                return false;

            if (quest != null && quest.status == QuestStatus.Accepted)
            {
                if (!host.movementModule.GpsMove("Signland_Ubein")) return false;
                Thread.Sleep(1000);
                host.MoveTo(22485.69, 10682.27, 303.67);
                Thread.Sleep(1000);
                host.farmModule.UseItemAndWait(5137);
                Thread.Sleep(1000);

                if (quest.status == QuestStatus.Accepted)
                {
                    host.MoveTo(22482.82, 10680.88, 304.29);
                    Thread.Sleep(1000);
                    host.farmModule.UseItemAndWait(5137);
                    Thread.Sleep(1000);
                }
            }

            if (quest != null && quest.status == QuestStatus.Performed)
            {
                if (!host.movementModule.GpsMove("Signland_Ubein")) return false;
                Thread.Sleep(1000);
                host.CompleteQuest(id);
                Thread.Sleep(1000);
            }

            return true;
        }
    }
}
