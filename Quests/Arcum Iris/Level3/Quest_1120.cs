using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ArcheBuddy.Bot.Classes;

namespace AutoExp.Quests
{
    internal class Quest_1120 : Quest
    {
        public Quest_1120(int minLvl, int maxLvl, QuestRace race, uint[] reqQuests)
            : base(1120, minLvl, maxLvl, race, reqQuests)
        { }

        public override bool RunQuest(Host host)
        {
            if (!base.RunQuest(host))
                return false;

            if (getQuest() == null)
            {
                if (!host.movementModule.GpsMove("Arcum_Myrtaz"))
                    return false;
                host.StartQuest(id);
                Thread.Sleep(1000);
            }

            ArcheBuddy.Bot.Classes.Quest quest = getQuest();

            if (quest != null && quest.status == ArcheBuddy.Bot.Classes.QuestStatus.Accepted)
            {
                if (!host.movementModule.GpsMove("Quest_1120_1"))
                    return false;
                host.farmModule.UseDoodadSkill(15461, host.getNearestDoodad(14049), true, 3);
                host.farmModule.UseDoodadSkill(15461, host.getNearestDoodad(6435), true, 3);
                host.farmModule.UseDoodadSkill(15461, host.getNearestDoodad(14050), true, 3);
            }

            if (quest != null && quest.status == ArcheBuddy.Bot.Classes.QuestStatus.Performed)
            {
                if (!host.movementModule.GpsMove("Arcum_Myrtaz"))
                    return false;
                host.CompleteQuest(id);
                Thread.Sleep(1000);
            }

            return true;
        }
    }
}
