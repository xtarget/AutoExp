using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ArcheBuddy.Bot.Classes;

namespace AutoExp.Quests
{
    internal class Quest_111 : Quest
    {
        public Quest_111(int minLvl, int maxLvl, QuestRace race, uint[] reqQuests)
            : base(111, minLvl, maxLvl, race, reqQuests)
        { }

        public override bool RunQuest(Host host)
        {
            if (!base.RunQuest(host))
                return false;

            if (getQuest() == null)
            {
                if (!host.movementModule.GpsMove("White_Mikael"))
                    return false;
                host.StartQuest(id);
                Thread.Sleep(1000);
            }

            if (!checkQuestCompletedOrAccepted(112))
                return false;
            if (!checkQuestCompletedOrAccepted(2498) && !checkQuestCompletedOrPerfomed(2498))
                return false;

            ArcheBuddy.Bot.Classes.Quest quest = getQuest();

            if (quest != null && quest.status == QuestStatus.Accepted)
            {
                int a = 0;
                Zone zone = new RoundZone(11104.77, 12902.22, 20);
                Zone zone1 = new RoundZone(11078.71, 12865.46, 30);
                Zone zone2 = new RoundZone(11060.32, 12968.87, 23);
                Zone zone3 = new RoundZone(11013.25, 12847.40, 25);
                Zone zone4 = new RoundZone(10979.49, 12907.52, 30);
                
                if (!host.movementModule.GpsMove("Quest_111_1"))
                    return false;
                host.farmModule.SetFarmDoodads(zone, new uint[] { 6676 });
                while (CheckWeCanContinueFarmQuest(quest.id) && host.farmModule.readyToActions && host.farmModule.farmState == Modules.FarmState.Doodads)
                {
                    Thread.Sleep(100);
                    if (host.farmModule.getDoodadsCountInZone(zone, 6676) == 0 && a == 0)
                    {
                        a = 1;
                        if (!host.movementModule.GpsMove("Quest_111_2"))
                            return false;
                        host.farmModule.SetFarmDoodads(zone1, new uint[] { 6676 });
                    }
                    if (host.farmModule.getDoodadsCountInZone(zone1, 6676) == 0 && a == 1)
                    {
                        a = 2;
                        if (!host.movementModule.GpsMove("Quest_111_3"))
                            return false;
                        host.farmModule.SetFarmDoodads(zone2, new uint[] { 6676 });
                    }
                    if (host.farmModule.getDoodadsCountInZone(zone2, 6676) == 0 && a == 2)
                    {
                        a = 3;
                        if (!host.movementModule.GpsMove("Quest_111_4"))
                            return false;
                        host.farmModule.SetFarmDoodads(zone3, new uint[] { 6676 }); 
                        
                    }
                    if (host.farmModule.getDoodadsCountInZone(zone3, 6676) == 0 && a == 3)
                    {
                        a = 4;
                        if (!host.movementModule.GpsMove("Quest_111_5"))
                            return false;
                        host.farmModule.SetFarmDoodads(zone4, new uint[] { 6676 });
                    }
                    if (host.farmModule.getDoodadsCountInZone(zone4, 6676) == 0 && a == 4)
                    {
                        a = 0;
                        if (!host.movementModule.GpsMove("Quest_111_1"))
                            return false;
                        host.farmModule.SetFarmDoodads(zone, new uint[] { 6676 });
                    }
                }
                host.farmModule.StopFarm();
                Thread.Sleep(1000);
            }
            
            if (quest != null && quest.status == QuestStatus.Performed)
            {
                if (!host.movementModule.GpsMove("White_Mikael")) return false;
                Thread.Sleep(1000);
                CompleteQuestWithSecondaryWeaponSelect();
                Thread.Sleep(1000);
            }
            
            return true;
        }
    }
}
