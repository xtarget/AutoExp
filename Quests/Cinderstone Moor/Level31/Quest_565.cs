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
    internal class Quest_565 : Quest
    {
        public Quest_565(int minLvl, int maxLvl, QuestRace race, uint[] reqQuests)
            : base(565, minLvl, maxLvl, race, reqQuests)
        { }

        public override bool RunQuest(Host host)
        {
            if (!base.RunQuest(host))
                return false;

            if ((host.gameTime() < 300 ||  host.gameTime() > 1080) && !checkQuestCompleted(557))
                return false;

            if (getQuest() == null)
            {
                if (!host.movementModule.GpsMove("Star_Lenton")) return false;
                Thread.Sleep(1000);
                host.StartQuest(id);
                Thread.Sleep(1000);
            }

            if (!checkQuestCompletedOrAccepted(571))
                return false;
            if (!checkQuestCompletedOrAccepted(580))
                return false;

            ArcheBuddy.Bot.Classes.Quest quest = getQuest();

            if (quest != null && quest.status == QuestStatus.Accepted)
            {
                Zone zone = new RoundZone(14998.81, 12099.68, 100);
                if (!host.movementModule.GpsMove("Quest_565_1"))
                    return false;
                host.farmModule.SetFarmMobs(zone, new uint[] { 2336 });
                while (CheckWeCanContinueFarmQuest(quest.id) && host.farmModule.readyToActions && host.farmModule.farmState == Modules.FarmState.Enabled)
                    Thread.Sleep(100);
                host.farmModule.StopFarm();
                Thread.Sleep(1000);
            }

            if (!checkQuestCompleted(552))
                return false;
            if (!checkQuestCompletedOrPerfomed(571))
                return false;
            if (!checkQuestCompletedOrPerfomed(580))
                return false;

            if (quest != null && quest.status == QuestStatus.Performed)
            {
                if (!host.movementModule.GpsMove("Star_Sandra")) return false;
                Thread.Sleep(1000);
                host.CompleteQuest(id);
                Thread.Sleep(1000);
            }

            return true;
        }
    }
}
