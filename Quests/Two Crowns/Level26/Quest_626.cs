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
    internal class Quest_626 : Quest
    {
        public Quest_626(int minLvl, int maxLvl, QuestRace race, uint[] reqQuests)
            : base(626, minLvl, maxLvl, race, reqQuests)
        { }

        public override bool RunQuest(Host host)
        {
            if (!base.RunQuest(host))
                return false;

            if (getQuest() == null)
            {
                if (!host.movementModule.GpsMove("TwoCrown_Dominika")) return false;
                Thread.Sleep(1000);
                host.StartQuest(id);
                Thread.Sleep(1000);
            }

            if (!checkQuestCompletedOrPerfomed(609))
                return false;

            ArcheBuddy.Bot.Classes.Quest quest = getQuest();

            if (quest != null && quest.status == QuestStatus.Accepted)
            {
                if (!host.movementModule.GpsMove("Quest_626_1"))
                    return false;
                Thread.Sleep(1000);
                host.farmModule.UseDoodadSkill(14032,host.getNearestDoodad(7021),true);
                Thread.Sleep(1000);
            }
            
            return true;
        }
    }
}
