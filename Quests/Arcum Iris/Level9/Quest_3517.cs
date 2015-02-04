using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ArcheBuddy.Bot.Classes;

namespace AutoExp.Quests
{
    internal class Quest_3517 : Quest
    {
        public Quest_3517(int minLvl, int maxLvl, QuestRace race, uint[] reqQuests)
            : base(3517, minLvl, maxLvl, race, reqQuests)
        { }

        public override bool RunQuest(Host host)
        {
            if (!base.RunQuest(host))
                return false;

            if (getQuest() == null)
            {
                if (!host.movementModule.GpsMove("Arcum_Osman1"))
                    return false;
                host.StartQuest(id);
                Thread.Sleep(1000);
            }

            ArcheBuddy.Bot.Classes.Quest quest = getQuest();

            if (!checkQuestCompletedOrAccepted(4742))
                return false;
            if (!checkQuestCompletedOrPerfomed(1169))
                return false;

            if (quest != null && quest.status == QuestStatus.Accepted)
            {
                Zone zone = new RoundZone(22088.17, 7178.51, 80);
                if (!host.movementModule.GpsMove("Quest_1169_1"))
                    return false;
                host.farmModule.SetFarmMobs(zone, new uint[] { 10050 });
                while (CheckWeCanContinueFarmQuest(quest.id) && host.farmModule.readyToActions && host.farmModule.farmState == Modules.FarmState.Enabled)
                    Thread.Sleep(100);
                host.farmModule.StopFarm();
                host.MoveTo(22070.95, 7208.16, 251.98);
                Thread.Sleep(1000);
            }

            if (!checkQuestCompletedOrPerfomed(4742))
                return false;
            
            if (quest != null && quest.status == ArcheBuddy.Bot.Classes.QuestStatus.Performed)
            {
                if (!host.movementModule.GpsMove("Arcum_Dervish"))
                    return false;
                host.CompleteQuest(id);
                Thread.Sleep(1000);
            }

            return true;
        }
    }
}
