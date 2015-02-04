using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ArcheBuddy.Bot.Classes;

namespace AutoExp.Quests
{
    internal class Quest_2937 : Quest
    {
        public Quest_2937(int minLvl, int maxLvl, QuestRace race, uint[] reqQuests, uint[] reqUncompleteQuests)
            : base(2937, minLvl, maxLvl, race, reqQuests, reqUncompleteQuests)
        { }

        public override bool RunQuest(Host host)
        {
            if (!base.RunQuest(host))
                return false;

            if (getQuest() == null)
            {
                if (!host.movementModule.GpsMove("Inistra_Table2"))
                    return false;
                host.StartQuest(id);
                Thread.Sleep(1000);
            }

            if (!checkQuestCompletedOrPerfomed(4214))
                return false;

            ArcheBuddy.Bot.Classes.Quest quest = getQuest();

            if (quest != null && quest.status == QuestStatus.Accepted)
            {
                Zone zone = new RoundZone(20536.82, 12834.78, 40);
                if (!host.movementModule.GpsMove("Quest_4214_1"))
                    return false;
                host.farmModule.SetFarmMobs(zone, new uint[] { 8029, 8030 });
                while (CheckWeCanContinueFarmQuest(quest.id) && host.farmModule.readyToActions && host.farmModule.farmState == Modules.FarmState.Enabled)
                    Thread.Sleep(100);
                host.farmModule.StopFarm();
                Thread.Sleep(1000);
            }
            
            return true;
        }
    }
}
