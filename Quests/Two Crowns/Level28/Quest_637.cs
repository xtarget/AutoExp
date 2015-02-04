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
    internal class Quest_637 : Quest
    {
        public Quest_637(int minLvl, int maxLvl, QuestRace race, uint[] reqQuests)
            : base(637, minLvl, maxLvl, race, reqQuests)
        { }

        public override bool RunQuest(Host host)
        {
            if (!base.RunQuest(host))
                return false;

            if (getQuest() == null)
            {
                if (!host.movementModule.GpsMove("TwoCrown_Ulios")) return false;
                Thread.Sleep(1000);
                host.StartQuest(id);
                Thread.Sleep(1000);
            }

            if (!checkQuestCompletedOrAccepted(4117))
                return false;
            if (!checkQuestCompletedOrAccepted(4118))
                return false;
            if (!checkQuestCompletedOrAccepted(4119))
                return false;
            if (!checkQuestCompletedOrAccepted(4120))
                return false;

            ArcheBuddy.Bot.Classes.Quest quest = getQuest();

            if (quest != null && quest.status == QuestStatus.Accepted)
            {
                if (!host.movementModule.GpsMove("Quest_637_1")) return false;
                Thread.Sleep(1000);
                host.farmModule.UseDoodadSkill(14532, host.getNearestDoodad(1420), true);
                Thread.Sleep(1000);
            }

            if (!checkQuestCompleted(2481))
                return false;

            if (quest != null && quest.status == QuestStatus.Performed)
            {
                if (!host.movementModule.GpsMove("TwoCrown_Illias")) return false;
                Thread.Sleep(1000);
                host.CompleteQuest(id);
                Thread.Sleep(1000);
            }

            return true;
        }
    }
}
