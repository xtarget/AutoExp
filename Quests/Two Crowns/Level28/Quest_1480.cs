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
    internal class Quest_1480 : Quest
    {
        public Quest_1480(int minLvl, int maxLvl, QuestRace race, uint[] reqQuests)
            : base(1480, minLvl, maxLvl, race, reqQuests)
        { }

        public override bool RunQuest(Host host)
        {
            if (!base.RunQuest(host))
                return false;

            if (getQuest() == null)
            {
                if (!host.movementModule.GpsMove("TwoCrown_Romyl")) return false;
                Thread.Sleep(1000);
                host.StartQuest(id);
                Thread.Sleep(1000);
            }

            if (!checkQuestCompletedOrAccepted(2484))
                return false;
            if (!checkQuestCompletedOrAccepted(2478))
                return false;

            ArcheBuddy.Bot.Classes.Quest quest = getQuest();

            if (quest != null && quest.status == QuestStatus.Accepted)
            {
                Zone zone = new RoundZone(13417.35, 11617.68, 50);
                if (!host.movementModule.GpsMove("Quest_1480_1"))
                    return false;
                host.farmModule.SetFarmMobs(zone, new uint[] { 8204 });
                while (CheckWeCanContinueFarmQuest(quest.id) && host.farmModule.readyToActions && host.farmModule.farmState == Modules.FarmState.Enabled)
                    Thread.Sleep(100);
                host.farmModule.StopFarm();
                Thread.Sleep(1000);
            }

            if (!checkQuestCompletedOrPerfomed(2484))
                return false;

            if (quest != null && quest.status == QuestStatus.Performed)
            {
                if (!host.movementModule.GpsMove("TwoCrown_Romyl")) return false;
                Thread.Sleep(1000);
                CompleteQuestWithArmorSelect();
                Thread.Sleep(1000);
            }

            return true;
        }
    }
}
