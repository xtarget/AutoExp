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
    internal class Quest_2408 : Quest
    {
        public Quest_2408(int minLvl, int maxLvl, QuestRace race, uint[] reqQuests)
            : base(2408, minLvl, maxLvl, race, reqQuests)
        { }

        public override bool RunQuest(Host host)
        {
            if (!base.RunQuest(host))
                return false;

            if (getQuest() == null)
            {
                if (!host.movementModule.GpsMove("Twocrown_Berrado")) return false;
                Thread.Sleep(1000);
                host.StartQuest(id);
                Thread.Sleep(1000);
            }

            if (!checkQuestCompletedOrPerfomed(2460))
                return false;

            ArcheBuddy.Bot.Classes.Quest quest = getQuest();

            if (quest != null && quest.status == QuestStatus.Accepted)
            {
                Zone zone = new RoundZone(12677.09, 11950.22, 20);
                if (!host.movementModule.GpsMove("Quest_2408_1"))
                    return false;
                host.farmModule.SetFarmMobs(zone, new uint[] { 7985, 7984 });
                while (CheckWeCanContinueFarmQuest(quest.id) && host.farmModule.readyToActions && host.farmModule.farmState == Modules.FarmState.Enabled)
                {
                    if (host.farmModule.getCreatureCountInZone(zone, 7984) == 0 && host.farmModule.getCreatureCountInZone(zone, 7985) == 0)
                        host.farmModule.SetFarmMobs(zone, new uint[] { 7985, 7984, 7773 });
                    Thread.Sleep(100);
                }
                host.farmModule.StopFarm();
                Thread.Sleep(1000);
            }

            if (!checkQuestCompleted(2460))
                return false;

            if (quest != null && quest.status == QuestStatus.Performed)
            {
                if (!host.movementModule.GpsMove("Twocrown_Vittorio")) return false;
                Thread.Sleep(1000);
                host.CompleteQuest(id);
                Thread.Sleep(1000);
            }
            return true;
        }
    }
}
