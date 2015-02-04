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
    internal class Quest_4119 : Quest
    {
        public Quest_4119(int minLvl, int maxLvl, QuestRace race, uint[] reqQuests)
            : base(4119, minLvl, maxLvl, race, reqQuests)
        { }

        public override bool RunQuest(Host host)
        {
            if (!base.RunQuest(host))
                return false;

            if (getQuest() == null)
            {
                if (!host.movementModule.GpsMove("TwoCrown_Ulios")) return false;
                Thread.Sleep(1000);
                host.StartQuest(id);
                Thread.Sleep(1000);
            }

            if (!checkQuestCompletedOrAccepted(4117))
                return false;
            if (!checkQuestCompletedOrAccepted(4118))
                return false;
            if (!checkQuestCompletedOrPerfomed(637))
                return false;
            if (!checkQuestCompletedOrAccepted(4120))
                return false;

            ArcheBuddy.Bot.Classes.Quest quest = getQuest();

            if (quest != null && quest.status == QuestStatus.Accepted)
            {
                Zone zone = new RoundZone(12964.25, 11589.92, 30);
                if (!host.movementModule.GpsMove("Quest_4119_1"))
                    return false;
                host.farmModule.SetFarmMobs(zone, new uint[] { 1598, 1606 });
                while (CheckWeCanContinueFarmQuest(quest.id) && host.farmModule.readyToActions && host.farmModule.farmState == Modules.FarmState.Enabled)
                    Thread.Sleep(100);
                host.farmModule.StopFarm();
                Thread.Sleep(1000);
            }
            
            return true;
        }
    }
}
