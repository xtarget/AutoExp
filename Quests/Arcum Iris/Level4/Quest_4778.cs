using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ArcheBuddy.Bot.Classes;

namespace AutoExp.Quests
{
    internal class Quest_4778 : Quest
    {
        public Quest_4778(int minLvl, int maxLvl, QuestRace race, uint[] reqQuests)
            : base(4778, minLvl, maxLvl, race, reqQuests)
        { }

        public override bool RunQuest(Host host)
        {
            if (!base.RunQuest(host))
                return false;

            if (!checkQuestCompletedOrPerfomed(1123))
                return false;

            if (getQuest() == null)
            {
                if (!host.movementModule.GpsMove("Arcum_Tai"))
                    return false;
                host.StartQuest(id);
                Thread.Sleep(1000);
            }

            ArcheBuddy.Bot.Classes.Quest quest = getQuest();

            if (quest != null && quest.status == QuestStatus.Accepted)
            {
                if (!host.movementModule.GpsMove("Arcum_Tai"))
                    return false;
                host.MoveTo(20306.00, 7409.42, 189.37);
                Thread.Sleep(750);
                host.farmModule.Climb(host.getNearestDoodad(30));
                Thread.Sleep(750);
                host.ClimbUp();
                Thread.Sleep(750);
                host.farmModule.UseDoodadSkill(18879,host.getNearestDoodad(13768));
                Thread.Sleep(750);
                host.farmModule.Climb(host.getNearestDoodad(30));
                Thread.Sleep(750);
                host.ClimbDown();
                Thread.Sleep(1500);
                host.farmModule.UseItemAndWait(25065);
            }
            return true;
        }
    }
}
