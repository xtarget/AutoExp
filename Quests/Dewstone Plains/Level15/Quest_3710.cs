using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ArcheBuddy.Bot.Classes;

namespace AutoExp.Quests
{
    internal class Quest_3710 : Quest
    {
        public Quest_3710(int minLvl, int maxLvl, QuestRace race, uint[] reqQuests)
            : base(3710, minLvl, maxLvl, race, reqQuests)
        { }

        public override bool RunQuest(Host host)
        {
            if (!base.RunQuest(host))
                return false;

            if (getQuest() == null)
            {
                if (!host.movementModule.GpsMove("Stone_Sten"))
                    return false;
                host.StartQuest(id);
                Thread.Sleep(1000);
            }

            if (!checkQuestCompletedOrPerfomed(3712))
                return false;

            ArcheBuddy.Bot.Classes.Quest quest = getQuest();

            if (quest != null && quest.status == QuestStatus.Accepted)
            {
                Zone zone = new RoundZone(13277.13, 14136.39, 100);
                if (!host.movementModule.GpsMove("Quest_3710_1"))
                    return false;
                host.farmModule.SetFarmMobs(zone, new uint[] { 10000, 10001, 10003 }); //3 сороконожка, 1 паук, 0 муравей
                while (CheckWeCanContinueFarmQuest(quest.id) && host.farmModule.readyToActions && host.farmModule.farmState == Modules.FarmState.Enabled)
                {
                    if (quest.steps[2] != 0 && quest.steps[1] == 0 && quest.steps[0] == 0)
                        host.farmModule.SetFarmMobs(zone, new uint[] { 10000, 10003 });
                    if (quest.steps[0] != 0 && quest.steps[1] == 0 && quest.steps[2] == 0)
                        host.farmModule.SetFarmMobs(zone, new uint[] { 10001, 10003 });
                    if (quest.steps[1] != 0 && quest.steps[0] == 0 && quest.steps[2] == 0)
                        host.farmModule.SetFarmMobs(zone, new uint[] { 10001, 10000 });
                    
                    if (quest.steps[0] != 0 && quest.steps[1] != 0 && quest.steps[2] == 0)
                        host.farmModule.SetFarmMobs(zone, new uint[] { 10001 });
                    if (quest.steps[0] != 0 && quest.steps[2] != 0 && quest.steps[1] == 0)
                        host.farmModule.SetFarmMobs(zone, new uint[] { 10003 });
                    if (quest.steps[1] != 0 && quest.steps[2] != 0 && quest.steps[0] == 0)
                        host.farmModule.SetFarmMobs(zone, new uint[] { 10000 });
                    Thread.Sleep(100);
                }
                
                host.farmModule.StopFarm();
                Thread.Sleep(1000);
            }

            if (!checkQuestCompleted(3714))
                return false;

            if (quest != null && quest.status == QuestStatus.Performed)
            {
                if (!host.movementModule.GpsMove("Stone_Sten")) return false;
                Thread.Sleep(1000);
                host.CompleteQuest(id);
                Thread.Sleep(1000);
            }

            return true;
        }
    }
}
