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
    internal class Quest_588 : Quest
    {
        public Quest_588(int minLvl, int maxLvl, QuestRace race, uint[] reqQuests)
            : base(588, minLvl, maxLvl, race, reqQuests)
        { }

        public override bool RunQuest(Host host)
        {
            if (!base.RunQuest(host))
                return false;

            if ((host.gameTime() < 300 ||  host.gameTime() > 1080) && !checkQuestCompleted(557))
                return false;

            if (getQuest() == null)
            {
                if (!host.movementModule.GpsMove("Star_Djenner")) return false;
                Thread.Sleep(1000);
                host.StartQuest(id);
                Thread.Sleep(1000);
            }
            
            ArcheBuddy.Bot.Classes.Quest quest = getQuest();

            if (quest != null && quest.status == QuestStatus.Accepted)
            {
                Zone zone = new RoundZone(15533.88, 12379.91, 100);
                if (!host.movementModule.GpsMove("Star_Djenner"))
                    return false;
                host.farmModule.SetFarmDoodads(zone, new uint[] { 1332 });
                while (CheckWeCanContinueFarmQuest(quest.id) && host.farmModule.readyToActions && host.farmModule.farmState == Modules.FarmState.Doodads)
                {
                    if (host.farmModule.getDoodadsCountInZone(zone, 1332) == 0)
                        host.farmModule.SetFarmDoodads(zone, new uint[] { 1332, 1330 });
                    else
                        host.farmModule.SetFarmDoodads(zone, new uint[] { 1332 });
                    Thread.Sleep(100);
                }
                host.farmModule.StopFarm();
                Thread.Sleep(1000);
            }

            if (quest != null && quest.status == QuestStatus.Performed)
            {
                if (!host.movementModule.GpsMove("Star_Djenner")) return false;
                Thread.Sleep(1000);
                host.CompleteQuest(id);
                Thread.Sleep(1000);
            }

            return true;
        }
    }
}
