using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ArcheBuddy.Bot.Classes;

namespace AutoExp.Quests
{
    internal class Quest_1153 : Quest
    {
        public Quest_1153(int minLvl, int maxLvl, QuestRace race, uint[] reqQuests)
            : base(1153, minLvl, maxLvl, race, reqQuests)
        { }

        public override bool RunQuest(Host host)
        {
            if (!base.RunQuest(host))
                return false;

            if (!checkQuestCompletedOrPerfomed(1144))
                return false;
            if (!checkQuestCompletedOrPerfomed(1136))
                return false;
            if (!checkQuestCompletedOrAccepted(1137))
                return false;
            
            if (getQuest() == null)
            {
                if (!host.movementModule.GpsMove("Arcum_Mayam"))
                    return false;
                host.StartQuest(id);
                Thread.Sleep(1000);
            }

            ArcheBuddy.Bot.Classes.Quest quest = getQuest();

            if (quest != null && quest.status == QuestStatus.Accepted)
            {
                Zone zone = new RoundZone(22017.16, 6879.27, 80);
                if (!host.movementModule.GpsMove("Arcum_Mayam"))
                    return false;
                host.farmModule.SetFarmMobs(zone, new uint[] { 2214 }, new uint[] { 13986, 14009 });
                while (CheckWeCanContinueFarmQuest(quest.id) && host.farmModule.readyToActions && host.farmModule.farmState == Modules.FarmState.Enabled)
                    Thread.Sleep(100);
                host.farmModule.StopFarm();
                Thread.Sleep(1000);
            }
            

            if (quest != null && quest.status == ArcheBuddy.Bot.Classes.QuestStatus.Performed)
            {
                if (!host.movementModule.GpsMove("Arcum_Mayam"))
                    return false;
                host.CompleteQuest(id);
                Thread.Sleep(1000);
            }

            return true;
        }
    }
}
