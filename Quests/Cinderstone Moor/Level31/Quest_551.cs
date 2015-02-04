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
    internal class Quest_551 : Quest
    {
        public Quest_551(int minLvl, int maxLvl, QuestRace race, uint[] reqQuests)
            : base(551, minLvl, maxLvl, race, reqQuests)
        { }

        public override bool RunQuest(Host host)
        {
            if (!base.RunQuest(host))
                return false;

            if (!checkQuestCompletedOrAccepted(547))
                return false;
            if (!checkQuestCompletedOrAccepted(548))
                return false;

            if (getQuest() == null)
            {
                if (!host.movementModule.GpsMove("Star_Nerius")) return false;
                Thread.Sleep(1000);
                host.StartQuest(id);
                Thread.Sleep(1000);
            }

            if (!checkQuestCompletedOrAccepted(3965))
                return false;

            ArcheBuddy.Bot.Classes.Quest quest = getQuest();

            if (quest != null && quest.status == QuestStatus.Accepted)
            {
                try
                {
                    host.farmModule.mobsToIgnore.Remove(2331);
                    host.farmModule.mobsToIgnore.Remove(2332);
                    host.farmModule.mobsToIgnore.Remove(4994);
                    host.farmModule.mobsToIgnore.Remove(4993);
                    host.movementModule.disableMounting = true;
                    host.StandFromMount();
                    Zone zone = new RoundZone(15477.49, 11703.88, 35);
                    if (!host.movementModule.GpsMove("Quest_551_1"))
                        return false;
                    host.farmModule.SetFarmMobs(zone, new uint[] { 2331, 2332, 4994 });
                    while (CheckWeCanContinueFarmQuest(quest.id) && host.farmModule.readyToActions && host.farmModule.farmState == Modules.FarmState.Enabled)
                    {
                        if (quest.steps[0] == 1 && quest.steps[1] == 1 && quest.steps[2] == 1)
                        {
                            zone = new RoundZone(15474.62, 11730.28, 40);
                            host.farmModule.SetFarmMobs(zone, new uint[] { 4994 });
                        }
                        Thread.Sleep(100);
                    }
                    host.farmModule.StopFarm();
                    Thread.Sleep(1000);
                }
                finally
                {
                    host.farmModule.mobsToIgnore.Add(2331);
                    host.farmModule.mobsToIgnore.Add(2332);
                    host.farmModule.mobsToIgnore.Add(4994);
                    host.farmModule.mobsToIgnore.Add(4993);
                    host.movementModule.disableMounting = false;
                }
            }

            if (!checkQuestCompletedOrPerfomed(548))
                return false;

            if (quest != null && quest.status == QuestStatus.Performed)
            {
                try
                {
                    host.movementModule.disableMounting = true;
                    host.StandFromMount();
                    if (!host.movementModule.GpsMove("Star_Nerius")) return false;
                    Thread.Sleep(1000);
                    host.CompleteQuest(id);
                    Thread.Sleep(1000);
                }
                finally
                {
                    host.movementModule.disableMounting = false;
                }
            }

            return true;
        }
    }
}
