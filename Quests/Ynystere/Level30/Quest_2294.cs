using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ArcheBuddy.Bot.Classes;

namespace AutoExp.Quests
{
    internal class Quest_2294 : Quest
    {
        public Quest_2294(int minLvl, int maxLvl, QuestRace race, uint[] reqQuests)
            : base(2294, minLvl, maxLvl, race, reqQuests)
        { }

        public override bool RunQuest(Host host)
        {
            if (!base.RunQuest(host))
                return false;

            if (getQuest() == null)
            {
                if (!host.movementModule.GpsMove("Inistra_Olafsen"))
                    return false;
                host.StartQuest(id);
                Thread.Sleep(1000);
            }

            ArcheBuddy.Bot.Classes.Quest quest = getQuest();

            if (quest != null && quest.status == QuestStatus.Accepted)
            {
                if (host.itemCount(17341) < 5)
                {
                    Zone zone = new RoundZone(21646.56, 12536.50, 15);
                    if (!host.movementModule.GpsMove("Quest_2294_1"))
                        return false;
                    host.farmModule.SetFarmDoodads(zone, new uint[] { 8225 });
                    while (host.farmModule.readyToActions && host.farmModule.farmState == Modules.FarmState.Doodads && host.itemCount(17341) < 5)
                        Thread.Sleep(100);
                    host.farmModule.StopFarm();
                    Thread.Sleep(1000);
                }
                if (!host.movementModule.GpsMove("Quest_2294_2")) return false;
                Thread.Sleep(1000);
                host.farmModule.UseDoodadSkill(15280, host.getNearestDoodad(7828), true);
                Thread.Sleep(1000);
            }

            if (quest != null && quest.status == QuestStatus.Performed)
            {
                if (!host.movementModule.GpsMove("Inistra_Edvir")) return false;
                Thread.Sleep(1000);
                host.CompleteQuest(id);
                Thread.Sleep(1000);
            }

            return true;
        }
    }
}
