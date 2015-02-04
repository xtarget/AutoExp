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
    internal class Quest_521 : Quest
    {
        public Quest_521(int minLvl, int maxLvl, QuestRace race, uint[] reqQuests)
            : base(521, minLvl, maxLvl, race, reqQuests)
        { }

        public override bool RunQuest(Host host)
        {
            if (!base.RunQuest(host))
                return false;

            if (!checkQuestCompletedOrAccepted(527))
                return false;

            if (getQuest() == null)
            {
                if (!host.movementModule.GpsMove("Star_Deivs")) return false;
                Thread.Sleep(1000);
                host.StartQuest(id);
                Thread.Sleep(1000);
            }

            if (!checkQuestCompletedOrAccepted(520))
                return false;
            if (!checkQuestCompletedOrPerfomed(527))
                return false;

            ArcheBuddy.Bot.Classes.Quest quest = getQuest();

            if (quest != null && quest.status == QuestStatus.Accepted)
            {
                Zone zone = new RoundZone(14441.21, 11523.73, 40);
                if (!host.movementModule.GpsMove("Quest_521_1"))
                    return false;
                host.farmModule.SetFarmMobs(zone, new uint[] { 2315, 2318, 2316, 2317 });
                while (CheckWeCanContinueFarmQuest(quest.id) && host.farmModule.readyToActions && host.farmModule.farmState == Modules.FarmState.Enabled)
                    Thread.Sleep(100);
                host.farmModule.StopFarm();
                Thread.Sleep(1000);
            }

            if (!checkQuestCompleted(520))
                return false;

            if (quest != null && quest.status == QuestStatus.Performed)
            {
                if (!host.movementModule.GpsMove("Star_Deivs")) return false;
                Thread.Sleep(1000);
                CompleteQuestWithPrimaryWeaponSelect();
                Thread.Sleep(1000);
            }

            return true;
        }
    }
}
