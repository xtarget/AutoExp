using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ArcheBuddy.Bot.Classes;

namespace AutoExp.Quests
{
    internal class Quest_604 : Quest
    {
        public Quest_604(int minLvl, int maxLvl, QuestRace race, uint[] reqQuests)
            : base(604, minLvl, maxLvl, race, reqQuests)
        { }

        public override bool RunQuest(Host host)
        {
            if (!base.RunQuest(host))
                return false;

            if (getQuest() == null)
            {
                if (!host.movementModule.GpsMove("Marianpole_Table2"))
                    return false;
                host.StartQuest(id);
                Thread.Sleep(1000);
            }

            ArcheBuddy.Bot.Classes.Quest quest = getQuest();

            if (quest != null && quest.status == QuestStatus.Accepted)
            {
                if (quest.steps[1] == 0)
                {
                    if (!host.movementModule.GpsMove("Quest_604_1")) return false;
                    Thread.Sleep(1000);
                    host.farmModule.Climb(host.getNearestDoodad(83));
                    Thread.Sleep(1500);
                    host.ClimbUp();
                    Thread.Sleep(1500);
                    host.MoveTo(11085.25, 11865.04, 151.63);
                    Thread.Sleep(1000);
                    host.MoveTo(11083.87, 11860.29, 151.56);
                    Thread.Sleep(1000);
                    host.farmModule.Climb(host.getNearestDoodad(83));
                    Thread.Sleep(1500);
                    host.ClimbDown();
                    Thread.Sleep(1000);
                }
                if (quest.steps[2] == 0)
                {
                    if (!host.movementModule.GpsMove("Quest_604_2")) return false;
                    Thread.Sleep(1000);
                    host.farmModule.Climb(host.getNearestDoodad(30));
                    Thread.Sleep(1500);
                    host.ClimbUp();
                    Thread.Sleep(1500);
                    host.MoveTo(11181.87, 11887.81, 168.63);
                    Thread.Sleep(1000);
                    host.MoveTo(11171.26, 11882.81, 168.63);
                    Thread.Sleep(1000);
                    host.farmModule.Climb(host.getNearestDoodad(30));
                    Thread.Sleep(1500);
                    host.ClimbDown();
                    Thread.Sleep(1000);
                }
                if (quest.steps[0] == 0)
                {
                    if (!host.movementModule.GpsMove("Quest_604_3")) return false;
                    Thread.Sleep(1000);
                    host.farmModule.Climb(host.getNearestDoodad(83));
                    Thread.Sleep(1500);
                    host.ClimbUp();
                    Thread.Sleep(1500);
                    host.MoveTo(11068.42, 12043.11, 182.90);
                    Thread.Sleep(1000);
                    host.MoveTo(11068.79, 12045.72, 182.52);
                    Thread.Sleep(1000);
                    host.farmModule.Climb(host.getNearestDoodad(83));
                    Thread.Sleep(1500);
                    host.ClimbDown();
                    Thread.Sleep(1000);
                }
            }

            if (quest != null && quest.status == QuestStatus.Performed)
            {
                if (!host.movementModule.GpsMove("Marianpole_Konstanciya")) return false;
                Thread.Sleep(1000);
                host.CompleteQuest(id);
                Thread.Sleep(1000);
            }
            

            return true;
        }
    }
}
