using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ArcheBuddy.Bot.Classes;

namespace AutoExp.Quests
{
    internal class Quest_4248 : Quest
    {
        public Quest_4248(int minLvl, int maxLvl, QuestRace race, uint[] reqQuests)
            : base(4248, minLvl, maxLvl, race, reqQuests)
        { }

        public override bool RunQuest(Host host)
        {
            if (!base.RunQuest(host))
                return false;

            if (getQuest() == null)
            {
                if (!host.movementModule.GpsMove("White_Gein"))
                    return false;
                host.StartQuest(id);
                Thread.Sleep(1000);
            }

            if (!checkQuestCompletedOrPerfomed(2563))
                return false;
            if (!checkQuestCompletedOrPerfomed(121))
                return false;

            ArcheBuddy.Bot.Classes.Quest quest = getQuest();

            if (quest != null && quest.status == QuestStatus.Accepted)
            {
                if (host.itemCount(23411) == 0)
                {
                    Zone zone = new RoundZone(9966.03, 12284.82, 35);
                    if (!host.movementModule.GpsMove("White_Frandel1"))
                        return false;
                    host.farmModule.SetFarmDoodads(zone, new uint[] { 11210 });
                    while (host.farmModule.readyToActions && host.farmModule.farmState == Modules.FarmState.Doodads && host.itemCount(23411) == 0)
                        Thread.Sleep(100);
                    host.farmModule.StopFarm();
                    Thread.Sleep(1000);
                }
                if (!host.movementModule.GpsMove("Quest_4248_1")) return false;
                Thread.Sleep(1000);
                host.farmModule.UseDoodadSkill(18098, host.getNearestDoodad(11211), true);
                Thread.Sleep(1000);
                
            }

            if (quest != null && quest.status == QuestStatus.Performed)
            {
                if (!host.movementModule.GpsMove("White_Gein")) return false;
                Thread.Sleep(1000);
                host.CompleteQuest(id);
                Thread.Sleep(1000);
            }
             

            return true;
        }
    }
}
