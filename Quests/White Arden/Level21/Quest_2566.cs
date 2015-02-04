using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ArcheBuddy.Bot.Classes;

namespace AutoExp.Quests
{
    internal class Quest_2566 : Quest
    {
        public Quest_2566(int minLvl, int maxLvl, QuestRace race, uint[] reqQuests)
            : base(2566, minLvl, maxLvl, race, reqQuests)
        { }

        public override bool RunQuest(Host host)
        {
            if (!base.RunQuest(host))
                return false;

            if (!checkQuestCompletedOrPerfomed(149))
                return false;

            if (getQuest() == null)
            {
                if (!host.movementModule.GpsMove("White_Shtols"))
                    return false;
                host.StartQuest(id);
                Thread.Sleep(1000);
            }

            if (!checkQuestCompletedOrPerfomed(2567))
                return false;

            ArcheBuddy.Bot.Classes.Quest quest = getQuest();

            if (quest != null && quest.status == QuestStatus.Accepted)
            {
                if (host.itemCount(17635) > 0)
                {
                    if (!host.movementModule.GpsMove("Quest_2566_1")) return false;
                    Thread.Sleep(1000);
                    host.farmModule.UseItemAndWait(17635);
                    Thread.Sleep(1000);
                }
                if (host.itemCount(17634) > 0)
                {
                    if (!host.movementModule.GpsMove("Quest_2566_2")) return false;
                    Thread.Sleep(1000);
                    var d = host.getNearestDoodad(83);
                    if (d != null)
                    {
                        host.ComeTo(d, 1);
                        host.MoveTo(9652.41, 12830.01, 164.95);
                        Thread.Sleep(1500);
                        host.farmModule.Climb(d);
                        Thread.Sleep(1500);
                        host.ClimbUp();
                        Thread.Sleep(2000);
                    }
                    host.farmModule.UseItemAndWait(17634);
                    Thread.Sleep(1000);
                    host.MoveTo(9654.72, 12834.25, 163.88);
                }
            }
            

            if (quest != null && quest.status == QuestStatus.Performed)
            {
                if (!host.movementModule.GpsMove("White_Shtols")) return false;
                Thread.Sleep(1000);
                host.CompleteQuest(id);
                Thread.Sleep(1000);
            }
             

            return true;
        }
    }
}
