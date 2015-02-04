using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ArcheBuddy.Bot.Classes;

namespace AutoExp.Quests
{
    internal class Quest_177 : Quest
    {
        public Quest_177(int minLvl, int maxLvl, QuestRace race, uint[] reqQuests)
            : base(177, minLvl, maxLvl, race, reqQuests)
        { }

        public override bool RunQuest(Host host)
        {
            if (!base.RunQuest(host))
                return false;

            if (getQuest() == null)
            {
                if (!host.movementModule.GpsMove("Stabler_50"))
                    return false;
                host.StartQuest(id);
                Thread.Sleep(1000);
            }
            
            ArcheBuddy.Bot.Classes.Quest quest = getQuest();

            if (!checkQuestCompletedOrAccepted(179))
                return false;

            if (quest != null && quest.status == QuestStatus.Accepted)
            {
                Zone zone = new RoundZone(11002.22, 11500.26, 100);
                if (!host.movementModule.GpsMove("Quest_177_1"))
                    return false;
                host.farmModule.SetFarmMobs(zone, new uint[] { 534, 535 });
                while (CheckWeCanContinueFarmQuest(quest.id) && host.farmModule.readyToActions && host.farmModule.farmState == Modules.FarmState.Enabled)
                    Thread.Sleep(100);
                host.farmModule.StopFarm();
                Thread.Sleep(1000);
            }

            if (quest != null && quest.status == QuestStatus.Performed)
            {
                if (!host.movementModule.GpsMove("Stabler_50")) return false;
                Thread.Sleep(1000);
                CompleteQuestWithArmorSelect();
                Thread.Sleep(1000);
            }
            

            return true;
        }
    }
}
