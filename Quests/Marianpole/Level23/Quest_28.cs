using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ArcheBuddy.Bot.Classes;

namespace AutoExp.Quests
{
    internal class Quest_28 : Quest
    {
        public Quest_28(int minLvl, int maxLvl, QuestRace race, uint[] reqQuests)
            : base(28, minLvl, maxLvl, race, reqQuests)
        { }

        private uint mobsCountInZ(Zone zone)
        {
            uint result = 0;
            foreach (var m in host.getCreatures())
            {
                if ((m.creatureId == 10444 || m.creatureId == 10445) && m.isAlive() && zone.ObjInZone(m))
                    result++;
            }
            return result;
        }

        public override bool RunQuest(Host host)
        {
            if (!base.RunQuest(host))
                return false;

            if (getQuest() == null)
            {
                if (!host.movementModule.GpsMove("Merianhold_Djilian"))
                    return false;
                host.StartQuest(id);
                Thread.Sleep(1000);
            }

            if (!checkQuestCompletedOrPerfomed(258))
                return false;

            ArcheBuddy.Bot.Classes.Quest quest = getQuest();

            if (quest != null && quest.status == QuestStatus.Accepted)
            {
                int a = 1;
                Zone zone = null;
                Zone zone1 = new RoundZone(10491.38, 12196.06, 20);
                Zone zone2 = new RoundZone(10488.35, 12255.23, 20);
                Zone zone3 = new RoundZone(10540.48, 12309.64, 42);
                Zone zone4 = new RoundZone(10615.44, 12310.57, 39);

                zone = zone1;
                if (!host.movementModule.GpsMove("Quest_28_1")) return false;
                host.farmModule.SetFarmDoodadsFromMobs(zone, new uint[] { 10444, 10445 }, new uint[] { 10627 }, new uint[] { 21179 });
                while (CheckWeCanContinueFarmQuest(quest.id) && host.farmModule.readyToActions && host.farmModule.farmState == Modules.FarmState.DoodadsFromMobs)
                {
                    if (mobsCountInZ(zone) == 0 && a == 1)
                    {
                        a = 2;
                        zone = zone2;
                        host.farmModule.StopFarm();
                        if (!host.movementModule.GpsMove("Quest_28_2")) return false;
                        host.farmModule.SetFarmDoodadsFromMobs(zone, new uint[] { 10444, 10445 }, new uint[] { 10627 }, new uint[] { 21179 });
                    }
                    else if (mobsCountInZ(zone) == 0 && a == 2)
                    {
                        a = 3;
                        zone = zone3;
                        host.farmModule.StopFarm();
                        if (!host.movementModule.GpsMove("Quest_28_3")) return false;
                        host.farmModule.SetFarmDoodadsFromMobs(zone, new uint[] { 10444, 10445 }, new uint[] { 10627 }, new uint[] { 21179 });
                    }
                    else if (mobsCountInZ(zone) == 0 && a == 3)
                    {
                        a = 4;
                        zone = zone4;
                        host.farmModule.StopFarm();
                        if (!host.movementModule.GpsMove("Quest_28_4")) return false;
                        host.farmModule.SetFarmDoodadsFromMobs(zone, new uint[] { 10444, 10445 }, new uint[] { 10627 }, new uint[] { 21179 });
                    }
                    else if (mobsCountInZ(zone) == 0 && a == 4)
                    {
                        a = 1;
                        zone = zone1;
                        host.farmModule.StopFarm();
                        if (!host.movementModule.GpsMove("Quest_28_1")) return false;
                        host.farmModule.SetFarmDoodadsFromMobs(zone, new uint[] { 10444, 10445 }, new uint[] { 10627 }, new uint[] { 21179 });
                    }
                    
                    Thread.Sleep(100);
                }
                host.farmModule.StopFarm();
                Thread.Sleep(1000);
            }
            
            if (quest != null && quest.status == QuestStatus.Performed)
            {
                if (!host.movementModule.GpsMove("Merianhold_Djilian")) return false;
                Thread.Sleep(1000);
                CompleteQuestWithPrimaryWeaponSelect();
                Thread.Sleep(1000);
            }
            
            return true;
        }
    }
}
