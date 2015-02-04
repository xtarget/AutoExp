using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ArcheBuddy.Bot.Classes;

namespace AutoExp.Quests
{
    internal class Quest_4224 : Quest
    {
        public Quest_4224(int minLvl, int maxLvl, QuestRace race, uint[] reqQuests)
            : base(4224, minLvl, maxLvl, race, reqQuests)
        { }

        public override bool RunQuest(Host host)
        {
            if (!base.RunQuest(host))
                return false;

            if (getQuest() == null)
            {
                if (!host.movementModule.GpsMove("White_Deivin"))
                    return false;
                host.StartQuest(id);
                Thread.Sleep(1000);
            }

            ArcheBuddy.Bot.Classes.Quest quest = getQuest();

            if (quest != null && quest.status == QuestStatus.Accepted)
            {
                Zone zone = new RoundZone(10135.57, 13015.56, 120);
                if (!host.movementModule.GpsMove("Quest_4224_1"))
                    return false;
                host.farmModule.SetFarmMobs(zone, new uint[] { 10589, 10590 });
                while (CheckWeCanContinueFarmQuest(quest.id) && host.farmModule.readyToActions && host.farmModule.farmState == Modules.FarmState.Enabled)
                {
                    if (quest.steps[0] >= 5)
                        host.farmModule.SetFarmMobs(zone, new uint[] { 10590 });
                    if (quest.steps[1] >= 5)
                        host.farmModule.SetFarmMobs(zone, new uint[] { 10589 });
                    Thread.Sleep(100);
                }
                host.farmModule.StopFarm();
                Thread.Sleep(1000);
            }

            if (quest != null && quest.status == QuestStatus.Performed)
            {
                if (!host.movementModule.GpsMove("White_Deivin")) return false;
                Thread.Sleep(1000);
                host.CompleteQuest(id);
                Thread.Sleep(1000);
            }
             

            return true;
        }
    }
}
