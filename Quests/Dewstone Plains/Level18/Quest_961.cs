using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ArcheBuddy.Bot.Classes;

namespace AutoExp.Quests
{
    internal class Quest_961 : Quest
    {
        public Quest_961(int minLvl, int maxLvl, QuestRace race, uint[] reqQuests)
            : base(961, minLvl, maxLvl, race, reqQuests)
        { }

        public override bool RunQuest(Host host)
        {
            if (!base.RunQuest(host))
                return false;

            if (getQuest() == null)
            {
                if (!host.movementModule.GpsMove("Stone_Balma"))
                    return false;
                host.StartQuest(id);
                Thread.Sleep(1000);
            }

            if (!checkQuestCompleted(3747))
                return false;

            ArcheBuddy.Bot.Classes.Quest quest = getQuest();

            if (quest != null && quest.status == QuestStatus.Accepted)
            {
                if (quest.steps[0] < 5)
                {
                    Zone zone = new RoundZone(12459.88, 12928.60, 60);
                    if (!host.movementModule.GpsMove("Quest_961_1"))
                        return false;
                    host.farmModule.SetFarmMobs(zone, new uint[] { 792, 793 });
                    while (host.farmModule.readyToActions && host.farmModule.farmState == Modules.FarmState.Enabled && quest.steps[0] < 5)
                        Thread.Sleep(100);
                    host.farmModule.StopFarm();
                    Thread.Sleep(1000);
                }
                if (quest.steps[1] < 5)
                {
                    Zone zone = new RoundZone(12537.44, 12661.45, 100);
                    if (!host.movementModule.GpsMove("Quest_961_2"))
                        return false;
                    host.farmModule.SetFarmMobs(zone, new uint[] { 794, 795, 796 });
                    while (host.farmModule.readyToActions && host.farmModule.farmState == Modules.FarmState.Enabled && quest.steps[1] < 5)
                        Thread.Sleep(100);
                    host.farmModule.StopFarm();
                    Thread.Sleep(1000);
                }
            }

            if (!checkQuestCompleted(1661))
                return false;
            
            if (quest != null && quest.status == QuestStatus.Performed)
            {
                if (!host.movementModule.GpsMove("Stone_Selma")) return false;
                Thread.Sleep(1000);
                host.CompleteQuest(id);
                Thread.Sleep(1000);
            }
            
            
            return true;
        }
    }
}
