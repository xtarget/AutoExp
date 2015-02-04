using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ArcheBuddy.Bot.Classes;

namespace AutoExp.Quests
{
    internal class Quest_4742 : Quest
    {
        public Quest_4742(int minLvl, int maxLvl, QuestRace race, uint[] reqQuests)
            : base(4742, minLvl, maxLvl, race, reqQuests)
        { }

        public override bool RunQuest(Host host)
        {
            if (!base.RunQuest(host))
                return false;

            if (getQuest() == null)
            {
                if (!host.movementModule.GpsMove("Arcum_Mystan"))
                    return false;
                host.StartQuest(id);
                Thread.Sleep(1000);
            }

            ArcheBuddy.Bot.Classes.Quest quest = getQuest();
            
            if (!checkQuestCompletedOrPerfomed(1169))
                return false;
            if (!checkQuestCompletedOrPerfomed(3517))
                return false;

            if (quest != null && quest.status == QuestStatus.Accepted)
            {
                Zone zone = new RoundZone(22109.97, 7272.65, 50);
                if (!host.movementModule.GpsMove("Quest_4742_1"))
                    return false;
                host.farmModule.SetFarmMobs(zone, new uint[] { 11954 });
                while (CheckWeCanContinueFarmQuest(quest.id) && host.farmModule.readyToActions && host.farmModule.farmState == Modules.FarmState.Enabled)
                    Thread.Sleep(100);
                host.farmModule.StopFarm();
                Thread.Sleep(1000);
            }

            if (!checkQuestCompleted(3517))
                return false;
            
            if (quest != null && quest.status == ArcheBuddy.Bot.Classes.QuestStatus.Performed)
            {
                if (!host.movementModule.GpsMove("Arcum_Mystan"))
                    return false;
                CompleteQuestWithArmorSelect();
                Thread.Sleep(1000);
            }

            return true;
        }
    }
}
