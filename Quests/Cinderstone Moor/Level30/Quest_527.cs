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
    internal class Quest_527 : Quest
    {
        public Quest_527(int minLvl, int maxLvl, QuestRace race, uint[] reqQuests)
            : base(527, minLvl, maxLvl, race, reqQuests)
        { }

        public override bool RunQuest(Host host)
        {
            if (!base.RunQuest(host))
                return false;

            if (getQuest() == null)
            {
                if (host.dist(14317.82, 11399.04, 194.25) > 6)
                {
                    if (!host.movementModule.GpsMove("Star_Istvyd")) return false;
                    Thread.Sleep(1000);
                    host.farmModule.Climb(host.getNearestDoodad(83));
                    Thread.Sleep(1500);
                    host.ClimbUp();
                    Thread.Sleep(1500);
                }
                host.StartQuest(id);
                Thread.Sleep(1000);
            }

            if (!checkQuestCompletedOrAccepted(521))
                return false;
            if (!checkQuestCompletedOrAccepted(520))
                return false;

            ArcheBuddy.Bot.Classes.Quest quest = getQuest();

            if (quest != null && quest.status == QuestStatus.Accepted)
            {
                if (!host.movementModule.GpsMove("Quest_527_1")) return false;
                Thread.Sleep(1000);
                host.farmModule.UseDoodadSkill(11339, host.getNearestDoodad(1283), true);
                Thread.Sleep(1000);
            }

            if (!checkQuestCompleted(521))
                return false;

            if (quest != null && quest.status == QuestStatus.Performed)
            {
                if (host.dist(14317.82, 11399.04, 194.25) > 6)
                {
                    if (!host.movementModule.GpsMove("Star_Istvyd")) return false;
                    Thread.Sleep(1000);
                    host.farmModule.Climb(host.getNearestDoodad(83));
                    Thread.Sleep(1500);
                    host.ClimbUp();
                    Thread.Sleep(1500);
                }
                host.CompleteQuest(id);
                Thread.Sleep(1000);
            }

            return true;
        }
    }
}
