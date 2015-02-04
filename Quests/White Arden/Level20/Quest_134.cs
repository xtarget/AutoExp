using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ArcheBuddy.Bot.Classes;

namespace AutoExp.Quests
{
    internal class Quest_134 : Quest
    {
        public Quest_134(int minLvl, int maxLvl, QuestRace race, uint[] reqQuests)
            : base(134, minLvl, maxLvl, race, reqQuests)
        { }

        public override bool RunQuest(Host host)
        {
            if (!base.RunQuest(host))
                return false;

            if (getQuest() == null)
            {
                if (!host.movementModule.GpsMove("White_Serifal"))
                    return false;
                host.StartQuest(id);
                Thread.Sleep(1000);
            }

            if (!checkQuestCompletedOrAccepted(135))
                return false;
            if (!checkQuestCompletedOrAccepted(1702))
                return false;
            if (!checkQuestCompletedOrAccepted(4256))
                return false;
            if (!checkQuestCompletedOrPerfomed(3985))
                return false;

            ArcheBuddy.Bot.Classes.Quest quest = getQuest();

            if (quest != null && quest.status == QuestStatus.Accepted)
            {
                Zone zone = new RoundZone(11102.39, 13262.44, 50);
                if (!host.movementModule.GpsMove("Quest_134_1"))
                    return false;
                host.farmModule.SetFarmDoodadsFromMobs(zone, new uint[] { 2036, 2037, 2038 }, new uint[] {1126}, new uint[] { 3999, 4000 });
                while (CheckWeCanContinueFarmQuest(quest.id) && host.farmModule.readyToActions && host.farmModule.farmState == Modules.FarmState.DoodadsFromMobs)
                    Thread.Sleep(100);
                host.farmModule.StopFarm();
                Thread.Sleep(1000);
            }

            if (!checkQuestCompleted(133))
                return false;

            if (quest != null && quest.status == QuestStatus.Performed)
            {
                if (!host.movementModule.GpsMove("White_Alana")) return false;
                Thread.Sleep(1000);
                host.CompleteQuest(id);
                Thread.Sleep(1000);
            }

            return true;
        }
    }
}
