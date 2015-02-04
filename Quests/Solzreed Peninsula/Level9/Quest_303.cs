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
    internal class Quest_303 : Quest
    {
        public Quest_303(int minLvl, int maxLvl, QuestRace race, uint[] reqQuests)
            : base(303, minLvl, maxLvl, race, reqQuests)
        { }

        public override bool RunQuest(Host host)
        {
            if (!base.RunQuest(host))
                return false;

            if (getQuest() == null)
            {
                if (!host.movementModule.GpsMove("Blacksmith_31"))
                    return false;
                host.StartQuest(id);
                Thread.Sleep(1000);
            }

            ArcheBuddy.Bot.Classes.Quest quest = getQuest();

            if (!checkQuestCompletedOrPerfomed(2265))
                return false;
            if (!checkQuestCompletedOrPerfomed(5146))
                return false;
            if (!checkQuestCompletedOrAccepted(298))
                return false;

            if (quest != null && quest.status == QuestStatus.Accepted)
            {
                Zone zone = new RoundZone(13804.36, 14999.51, 100);
                if (!host.movementModule.GpsMove("Quest_303_1"))
                    return false;
                host.farmModule.SetFarmMobs(zone, new uint[] { 3454, 3459, 3457 });
                while (CheckWeCanContinueFarmQuest(quest.id) && host.farmModule.readyToActions && host.farmModule.farmState == Modules.FarmState.Enabled)
                    Thread.Sleep(100);
                host.farmModule.StopFarm();
                Thread.Sleep(1000);
            }
            
            if (quest != null && quest.status == QuestStatus.Performed)
            {
                if (!host.movementModule.GpsMove("Solrid_Kaifas")) return false;
                Thread.Sleep(1000);
                host.CompleteQuest(id);
                Thread.Sleep(1000);
            }
             

            return true;
        }
    }
}
