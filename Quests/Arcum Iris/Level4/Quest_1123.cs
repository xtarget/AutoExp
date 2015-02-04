using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ArcheBuddy.Bot.Classes;

namespace AutoExp.Quests
{
    internal class Quest_1123 : Quest
    {
        public Quest_1123(int minLvl, int maxLvl, QuestRace race, uint[] reqQuests)
            : base(1123, minLvl, maxLvl, race, reqQuests)
        { }

        public override bool RunQuest(Host host)
        {
            if (!base.RunQuest(host))
                return false;


            if (getQuest() == null)
            {
                if (!host.movementModule.GpsMove("Arcum_Tamir"))
                    return false;
                host.StartQuest(id);
                Thread.Sleep(1000);
            }

            if (!checkQuestCompletedOrPerfomed(3510))
                return false;

            ArcheBuddy.Bot.Classes.Quest quest = getQuest();

            if (quest != null && quest.status == QuestStatus.Accepted)
            {
                Zone zone = new RoundZone(20070.99, 7471.78, 100);
                if (!host.movementModule.GpsMove("Quest_1123_1"))
                    return false;
                host.farmModule.SetFarmMobs(zone, new uint[] { 2204 });
                while (CheckWeCanContinueFarmQuest(quest.id) && host.farmModule.readyToActions && host.farmModule.farmState == Modules.FarmState.Enabled)
                    Thread.Sleep(100);
                host.farmModule.StopFarm();
                Thread.Sleep(1000);
            }

            if (!checkQuestCompleted(3510))
                return false;

            if (quest != null && quest.status == ArcheBuddy.Bot.Classes.QuestStatus.Performed)
            {
                if (!host.movementModule.GpsMove("Arcum_Margen"))
                    return false;
                host.CompleteQuest(id);
                Thread.Sleep(1000);
            }

            return true;
        }
    }
}
