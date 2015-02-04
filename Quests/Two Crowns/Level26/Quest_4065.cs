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
    internal class Quest_4065 : Quest
    {
        public Quest_4065(int minLvl, int maxLvl, QuestRace race, uint[] reqQuests, uint[] reqUncompleteQuests)
            : base(4065, minLvl, maxLvl, race, reqQuests, reqUncompleteQuests)
        { }

        public override bool RunQuest(Host host)
        {
            if (!base.RunQuest(host))
                return false;

            if (getQuest() == null)
            {
                if (!host.movementModule.GpsMove("TwoCrown_Chezario")) return false;
                Thread.Sleep(1000);
                host.StartQuest(id);
                Thread.Sleep(1000);
            }

            if (!checkQuestCompletedOrAccepted(609))
                return false;
            if (!checkQuestCompletedOrAccepted(626))
                return false;
            

            ArcheBuddy.Bot.Classes.Quest quest = getQuest();

            if (quest != null && quest.status == QuestStatus.Accepted)
            {
                Zone zone = new RoundZone(12448.64, 11264.29, 55);
                if (!host.movementModule.GpsMove("Quest_4065_1"))
                    return false;
                host.farmModule.SetFarmMobs(zone, new uint[] { 8002 });
                while (CheckWeCanContinueFarmQuest(quest.id) && host.farmModule.readyToActions && host.farmModule.farmState == Modules.FarmState.Enabled)
                {
                    if (!checkQuestCompletedOrPerfomed(609))
                        host.farmModule.SetFarmMobs(zone, new uint[] { 8002, 8005, 8006 });
                    else
                        host.farmModule.SetFarmMobs(zone, new uint[] { 8002 });
                    Thread.Sleep(100);
                }
                host.farmModule.StopFarm();
                Thread.Sleep(1000);
            }

            return true;
        }
    }
}
