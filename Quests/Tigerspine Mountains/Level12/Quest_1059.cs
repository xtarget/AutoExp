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
    internal class Quest_1059 : Quest
    {
        public Quest_1059(int minLvl, int maxLvl, QuestRace race, uint[] reqQuests)
            : base(1059, minLvl, maxLvl, race, reqQuests)
        { }

        public override bool RunQuest(Host host)
        {
            if (!base.RunQuest(host))
                return false;

            if (getQuest() == null)
            {
                if (!host.movementModule.GpsMove("Tiger_Molly")) return false;
                Thread.Sleep(1000);
                host.StartQuest(id);
                Thread.Sleep(1000);
            }

            ArcheBuddy.Bot.Classes.Quest quest = getQuest();

            if (quest != null && quest.status == QuestStatus.Accepted)
            {
                Zone zone = new PolygonZone(new List<ZonePoint>() { new ZonePoint(21830.24, 8313.45), new ZonePoint(21830.65, 8351.15), new ZonePoint(21861.15, 8334.90), new ZonePoint(21888.82, 8256.44), new ZonePoint(21846.16, 8272.88), new ZonePoint(21792.07, 8254.78), new ZonePoint(21764.62, 8299.35), new ZonePoint(21792.49, 8311.71), new ZonePoint(21829.19, 8311.20) });
                Zone zone1 = new RoundZone(21760.99, 8315.03, 23);
                int z = 0;
                if (!host.movementModule.GpsMove("Quest_1059_1")) return false;
                host.farmModule.SetFarmDoodads(zone, new uint[] { 2433 });
                while (CheckWeCanContinueFarmQuest(quest.id) && host.farmModule.readyToActions && host.farmModule.farmState == Modules.FarmState.Doodads)
                {
                    if (host.farmModule.getDoodadsCountInZone(zone, 2433) == 0 && z == 0)
                    {
                        host.farmModule.StopFarm();
                        if (!host.movementModule.GpsMove("Quest_1059_2")) return false;
                        z = 1;
                        host.farmModule.SetFarmDoodads(zone1, new uint[] { 2433 });
                    }
                    if (host.farmModule.getDoodadsCountInZone(zone1, 2433) == 0 && z == 1)
                    {
                        host.farmModule.StopFarm();
                        if (!host.movementModule.GpsMove("Quest_1059_1")) return false;
                        z = 0;
                        host.farmModule.SetFarmDoodads(zone, new uint[] { 2433 });
                    }
                    Thread.Sleep(100);
                }
                host.farmModule.StopFarm();
                Thread.Sleep(1000);

                
            }

            if (quest != null && quest.status == QuestStatus.Performed)
            {
                if (!host.movementModule.GpsMove("Tiger_Molly")) return false;
                Thread.Sleep(1000);
                host.CompleteQuest(id);
                Thread.Sleep(1000);
            }



            return true;
        }
    }
}
