using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ArcheBuddy.Bot.Classes;

namespace AutoExp.Quests
{
    internal class Quest_4220 : Quest
    {
        public Quest_4220(int minLvl, int maxLvl, QuestRace race, uint[] reqQuests)
            : base(4220, minLvl, maxLvl, race, reqQuests)
        { }

        public override bool RunQuest(Host host)
        {
            if (!base.RunQuest(host))
                return false;

            if (!checkQuestCompletedOrAccepted(4248))
                return false;

            if (getQuest() == null)
            {
                if (!host.movementModule.GpsMove("White_Frandel1"))
                    return false;
                host.StartQuest(id);
                Thread.Sleep(1000);
            }

            ArcheBuddy.Bot.Classes.Quest quest = getQuest();

            if (quest != null && quest.status == QuestStatus.Accepted)
            {
                if (!host.movementModule.GpsMove("White_Grob")) return false;
                Thread.Sleep(1000);
                host.farmModule.UseDoodadSkill(17473,host.getNearestDoodad(11158),true);
                Thread.Sleep(3000);
                if (!host.movementModule.GpsMove("White_Frandel1")) return false;
            }

            if (quest != null && quest.status == QuestStatus.Performed)
            {
                if (!host.movementModule.GpsMove("White_Frandel1")) return false;
                Thread.Sleep(1000);
                host.CompleteQuest(id);
                Thread.Sleep(1000);
            }
             

            return true;
        }
    }
}
