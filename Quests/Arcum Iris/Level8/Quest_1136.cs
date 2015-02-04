using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ArcheBuddy.Bot.Classes;

namespace AutoExp.Quests
{
    internal class Quest_1136 : Quest
    {
        public Quest_1136(int minLvl, int maxLvl, QuestRace race, uint[] reqQuests)
            : base(1136, minLvl, maxLvl, race, reqQuests)
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

            if (!checkQuestCompleted(1145))
                return false;

            ArcheBuddy.Bot.Classes.Quest quest = getQuest();

            if (quest != null && quest.status == QuestStatus.Accepted)
            {
                if (!host.movementModule.GpsMove("Arcum_Orlhoi"))
                    return false;
                Thread.Sleep(1000);
                host.farmModule.UseDoodadSkill(14073, host.getNearestDoodad(3071), true);
                Thread.Sleep(1000);
            }

            if (!checkQuestCompleted(1137))
                return false;

            if (quest != null && quest.status == ArcheBuddy.Bot.Classes.QuestStatus.Performed)
            {
                if (!host.movementModule.GpsMove("Arcum_Mystan"))
                    return false;
                CompleteQuestWithArmorSelect();
                Thread.Sleep(1000);
            }

            return true;
        }
    }
}
