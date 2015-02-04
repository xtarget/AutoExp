using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ArcheBuddy.Bot.Classes;

namespace AutoExp.Quests
{
    internal class Quest_1590 : Quest
    {
        public Quest_1590(int minLvl, int maxLvl, QuestRace race, uint[] reqQuests, uint[] reqUncompleteQuests)
            : base(1590, minLvl, maxLvl, race, reqQuests, reqUncompleteQuests)
        { }

        public override bool RunQuest(Host host)
        {
            if (!base.RunQuest(host))
                return false;

            if (getQuest() == null)
            {
                if (!host.movementModule.GpsMove("Liliot_Table1"))
                    return false;
                host.StartQuest(id);
                Thread.Sleep(1000);
            }

            if (!checkQuestCompletedOrPerfomed(1690))
                return false;

            ArcheBuddy.Bot.Classes.Quest quest = getQuest();

            if (quest != null && quest.status == QuestStatus.Accepted)
            {
                Zone zone = new RoundZone(13013.96, 15690.20, 60);
                if (!host.movementModule.GpsMove("Liliot_Table1"))
                    return false;
                host.farmModule.SetFarmMobs(zone, new uint[] { 7052, 6994 });
                while (CheckWeCanContinueFarmQuest(quest.id) && host.farmModule.readyToActions && host.farmModule.farmState == Modules.FarmState.Enabled)
                    Thread.Sleep(100);
                host.farmModule.StopFarm();
                Thread.Sleep(1000);
            }
            
            
            return true;
        }
    }
}
