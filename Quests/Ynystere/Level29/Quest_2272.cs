using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ArcheBuddy.Bot.Classes;

namespace AutoExp.Quests
{
    internal class Quest_2272 : Quest
    {
        public Quest_2272(int minLvl, int maxLvl, QuestRace race, uint[] reqQuests)
            : base(2272, minLvl, maxLvl, race, reqQuests)
        { }

        public override bool RunQuest(Host host)
        {
            if (!base.RunQuest(host))
                return false;

            if (getQuest() == null)
            {
                if (!host.movementModule.GpsMove("Inistra_Grendal"))
                    return false;
                host.StartQuest(id);
                Thread.Sleep(1000);
            }
            
            ArcheBuddy.Bot.Classes.Quest quest = getQuest();

            if (quest != null && quest.status == QuestStatus.Accepted)
            {
                Zone zone = new RoundZone(22246.24, 12993.06, 60);
                if (!host.movementModule.GpsMove("Quest_2272_1"))
                    return false;
                host.farmModule.SetFarmMobs(zone, new uint[] { 8021, 8041 });
                while (CheckWeCanContinueFarmQuest(quest.id) && host.farmModule.readyToActions && host.farmModule.farmState == Modules.FarmState.Enabled)
                {
                    if (quest.steps[0] >= 3)
                        host.farmModule.SetFarmMobs(zone, new uint[] { 8041 });
                    if (quest.steps[1] >= 3)
                        host.farmModule.SetFarmMobs(zone, new uint[] { 8021 });
                    Thread.Sleep(100);
                }
                host.farmModule.StopFarm();
                Thread.Sleep(1000);
            }

            if (quest != null && quest.status == QuestStatus.Performed)
            {
                if (!host.movementModule.GpsMove("Inistra_Grendal")) return false;
                Thread.Sleep(1000);
                CompleteQuestWithSecondaryWeaponSelect();
                Thread.Sleep(1000);
            }
            

            return true;
        }
    }
}
