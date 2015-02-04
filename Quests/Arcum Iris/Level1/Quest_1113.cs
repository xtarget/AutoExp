using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AutoExp.Quests
{
    internal class Quest_1113 : Quest
    {
        public Quest_1113(int minLvl, int maxLvl, QuestRace race, uint[] reqQuests)
            : base(1113, minLvl, maxLvl, race, reqQuests)
        { }

        public override bool RunQuest(Host host)
        {
            if (!base.RunQuest(host))
                return false;
            if (getQuest() == null)
            {
                if (!host.movementModule.GpsMove("Arcum_Ifendi"))
                    return false;
                host.StartQuest(id);
                Thread.Sleep(1000);
            }

            ArcheBuddy.Bot.Classes.Quest quest = getQuest();

            if (quest != null && quest.status == ArcheBuddy.Bot.Classes.QuestStatus.Accepted)
            {
                if (!host.movementModule.GpsMove("Quest_1113_1"))
                    return false;
                Thread.Sleep(1000);
                host.farmModule.UseDoodadSkill(12131, host.getNearestDoodad(3078), true);
            }

            if (quest != null && quest.status == ArcheBuddy.Bot.Classes.QuestStatus.Performed)
            {
                if (!host.movementModule.GpsMove("Arcum_Hassan"))
                    return false;
                host.CompleteQuest(id);
                Thread.Sleep(1000);
            }

            return true;
        }
    }
}
