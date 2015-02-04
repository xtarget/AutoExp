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
    internal class Quest_2457 : Quest
    {
        public Quest_2457(int minLvl, int maxLvl, QuestRace race, uint[] reqQuests)
            : base(2457, minLvl, maxLvl, race, reqQuests)
        { }

        public override bool RunQuest(Host host)
        {
            if (!base.RunQuest(host))
                return false;

            if (getQuest() == null)
            {
                if (!host.movementModule.GpsMove("TwoCrown_Valerios")) return false;
                Thread.Sleep(1000);
                host.StartQuest(id);
                Thread.Sleep(1000);
            }

            if (!checkQuestCompletedOrPerfomed(2416))
                return false;

            ArcheBuddy.Bot.Classes.Quest quest = getQuest();

            if (quest != null && quest.status == QuestStatus.Accepted)
            {
                Zone zone = new RoundZone(12287.02, 10834.74, 50);
                if (!host.movementModule.GpsMove("Quest_4115_1"))
                    return false;
                host.farmModule.SetFarmMobs(zone, new uint[] { 1581 });
                while (CheckWeCanContinueFarmQuest(quest.id) && host.farmModule.readyToActions && host.farmModule.farmState == Modules.FarmState.Enabled)
                {
                    if (host.farmModule.getCreatureCountInZone(zone, 1581) == 0)
                        host.farmModule.SetFarmMobs(zone, new uint[] { 1581, 1580 });
                    else
                        host.farmModule.SetFarmMobs(zone, new uint[] { 1581 });
                    Thread.Sleep(100);
                }
                host.farmModule.StopFarm();
                Thread.Sleep(1000);
            }

            if (!checkQuestCompleted(614))
                return false;

            if (quest != null && quest.status == QuestStatus.Performed)
            {
                if (!host.movementModule.GpsMove("TwoCrown_Valerios")) return false;
                Thread.Sleep(1000);
                host.CompleteQuest(id);
                Thread.Sleep(1000);
            }

            return true;
        }
    }
}
