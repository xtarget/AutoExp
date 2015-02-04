using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ArcheBuddy.Bot.Classes;

namespace AutoExp.Quests
{
    internal class Quest_2494 : Quest
    {
        public Quest_2494(int minLvl, int maxLvl, QuestRace race, uint[] reqQuests)
            : base(2494, minLvl, maxLvl, race, reqQuests)
        { }

        public override bool RunQuest(Host host)
        {
            if (!base.RunQuest(host))
                return false;

            if (getQuest() == null)
            {
                if (!host.movementModule.GpsMove("Stone_Bella"))
                    return false;
                host.StartQuest(id);
                Thread.Sleep(1000);
            }

            ArcheBuddy.Bot.Classes.Quest quest = getQuest();

            if (quest != null && quest.status == QuestStatus.Accepted)
            {
                try
                {
                    host.movementModule.disableMounting = true;
                    host.StandFromMount();
                    if (!host.movementModule.GpsMove("Stone_Dom")) return false;
                    Thread.Sleep(1000);
                    var d = host.getNearestDoodad(1445);
                    if (d != null && host.dist(d) < 7)
                    {
                        host.farmModule.UseDoodadSkill(11629, d, true);
                        Thread.Sleep(1500);
                    }
                    Zone zone = new RoundZone(12118.89, 13361.46, 10);
                    host.farmModule.SetFarmMobs(zone, new uint[] { 10759 });
                    while (CheckWeCanContinueFarmQuest(quest.id) && host.farmModule.readyToActions && host.farmModule.farmState == Modules.FarmState.Enabled)
                        Thread.Sleep(100);
                    host.farmModule.StopFarm();
                    Thread.Sleep(1000);
                    d = host.getNearestDoodad(1445);
                    if (d != null && host.dist(d) < 7)
                    {
                        host.farmModule.UseDoodadSkill(11629, d, true);
                        Thread.Sleep(1500);
                    }
                }
                finally
                {
                    host.movementModule.disableMounting = false;
                }
            }

            if (quest != null && quest.status == QuestStatus.Performed)
            {
                try
                {
                    host.movementModule.disableMounting = true;
                    host.StandFromMount();
                    if (!host.movementModule.GpsMove("Stone_Bella")) return false;
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
