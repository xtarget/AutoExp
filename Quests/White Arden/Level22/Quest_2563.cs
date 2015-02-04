using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ArcheBuddy.Bot.Classes;

namespace AutoExp.Quests
{
    internal class Quest_2563 : Quest
    {
        public Quest_2563(int minLvl, int maxLvl, QuestRace race, uint[] reqQuests)
            : base(2563, minLvl, maxLvl, race, reqQuests)
        { }

        public override bool RunQuest(Host host)
        {
            if (!base.RunQuest(host))
                return false;

            if (getQuest() == null)
            {
                
                if (!host.movementModule.GpsMove("White_Statya"))
                    return false;
                host.StartQuest(id);
                Thread.Sleep(1000);
            }

            if (!checkQuestCompletedOrAccepted(2564))
                return false;
            if (!checkQuestCompletedOrAccepted(4249))
                return false;

            ArcheBuddy.Bot.Classes.Quest quest = getQuest();

            if (quest != null && quest.status == QuestStatus.Accepted)
            {
                Zone zone = new RoundZone(10126.20, 12297.44, 50);
                if (!host.movementModule.GpsMove("Quest_2563_1"))
                    return false;
                host.farmModule.SetFarmDoodads(zone, new uint[] { });
                while (CheckWeCanContinueFarmQuest(quest.id) && host.farmModule.readyToActions && host.farmModule.farmState == Modules.FarmState.Doodads)
                {
                    if (host.itemCount(17640) == 0)
                        host.farmModule.SetFarmDoodads(zone, new uint[] { 6868 });
                    else if (host.itemCount(17641) == 0)
                        host.farmModule.SetFarmDoodads(zone, new uint[] { 6865 });
                    else if (host.itemCount(17639) == 0)
                        host.farmModule.SetFarmDoodads(zone, new uint[] { 6871 });
                    Thread.Sleep(100);
                }
                host.farmModule.StopFarm();
                Thread.Sleep(1000);
            }

            if (!checkQuestCompleted(4249))
                return false;

            if (quest != null && quest.status == QuestStatus.Performed)
            {
                if (!host.movementModule.GpsMove("White_Mogila")) return false;
                Thread.Sleep(1000);
                host.CompleteQuest(id);
                Thread.Sleep(1000);
            }
             

            return true;
        }
    }
}
