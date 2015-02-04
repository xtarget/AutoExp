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
    internal class Quest_4120 : Quest
    {
        public Quest_4120(int minLvl, int maxLvl, QuestRace race, uint[] reqQuests)
            : base(4120, minLvl, maxLvl, race, reqQuests)
        { }

        public override bool RunQuest(Host host)
        {
            if (!base.RunQuest(host))
                return false;

            if (getQuest() == null)
            {
                if (!host.movementModule.GpsMove("TwoCrown_Onorio")) return false;
                Thread.Sleep(1000);
                host.StartQuest(id);
                Thread.Sleep(1000);
            }

            if (!checkQuestCompleted(4118))
                return false;

            ArcheBuddy.Bot.Classes.Quest quest = getQuest();

            if (quest != null && quest.status == QuestStatus.Accepted)
            {
                Zone zone = new RoundZone(13154.72, 11629.97, 50);
                if (!host.movementModule.GpsMove("Quest_4120_1"))
                    return false;
                host.farmModule.SetFarmMobs(zone, new uint[] { 1772 });
                while (CheckWeCanContinueFarmQuest(quest.id) && host.farmModule.readyToActions && host.farmModule.farmState == Modules.FarmState.Enabled)
                {
                    if (host.farmModule.mobsCountInZone(1772, zone) == 0)
                    {
                        host.SetTarget(host.farmModule.GetNearestCreatureById(1659));
                        host.farmModule.UseItemAndWait(17254);
                        Thread.Sleep(5000);
                    }
                    Thread.Sleep(100);
                }
                host.farmModule.StopFarm();
                Thread.Sleep(1000);
            }
            
            
            if (quest != null && quest.status == QuestStatus.Performed)
            {
                if (!host.movementModule.GpsMove("TwoCrown_Djilbo")) return false;
                Thread.Sleep(1000);
                host.CompleteQuest(id);
                Thread.Sleep(1000);
            }

            return true;
        }
    }
}
