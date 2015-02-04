using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ArcheBuddy.Bot.Classes;

namespace AutoExp.Quests
{
    internal class Quest_1118 : Quest
    {
        public Quest_1118(int minLvl, int maxLvl, QuestRace race, uint[] reqQuests)
            : base(1118, minLvl, maxLvl, race, reqQuests)
        { }

        public override bool RunQuest(Host host)
        {
            if (!base.RunQuest(host))
                return false;

            if (getQuest() == null)
            {
                if (!host.movementModule.GpsMove("Arcum_Lidiya"))
                    return false;
                host.StartQuest(id);
                Thread.Sleep(1000);
            }

            ArcheBuddy.Bot.Classes.Quest quest = getQuest();

            if (!checkQuestCompletedOrPerfomed(3515))
                return false;
            
            if (quest != null && quest.status == ArcheBuddy.Bot.Classes.QuestStatus.Performed)
            {
                if (host.dist(21155.16, 6640.02, 134.47) < 50)
                {
                    host.farmModule.UseDoodadSkill(13876, host.getNearestDoodad(6547), true);
                    Thread.Sleep(60000);
                }
                if (!host.movementModule.GpsMove("Arcum_Megrab"))
                    return false;
                host.CompleteQuest(id);
                Thread.Sleep(1000);
            }

            return true;
        }
    }
}
