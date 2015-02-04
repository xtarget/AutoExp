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
    internal class Quest_252 : Quest
    {
        public Quest_252(int minLvl, int maxLvl, QuestRace race, uint[] reqQuests)
            : base(252, minLvl, maxLvl, race, reqQuests)
        { }

        public override bool RunQuest(Host host)
        {
            if (!base.RunQuest(host))
                return false;

            if (getQuest() == null)
            {
                if (!host.movementModule.GpsMove("Solrid_Gilbert"))
                    return false;
                host.StartQuest(id);
                Thread.Sleep(1000);
            }

            ArcheBuddy.Bot.Classes.Quest quest = getQuest();

            if (!checkQuestCompletedOrPerfomed(2532))
                return false;
            if (!checkQuestCompletedOrPerfomed(324))
                return false;

            if (quest != null && quest.status == QuestStatus.Accepted)
            {
                host.farmModule.UseItemAndWait(7738);
                Thread.Sleep(1000);
            }

            return true;
        }
    }
}
