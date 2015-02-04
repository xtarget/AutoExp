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
    internal class Quest_4064 : Quest
    {
        public Quest_4064(int minLvl, int maxLvl, QuestRace race, uint[] reqQuests)
            : base(4064, minLvl, maxLvl, race, reqQuests)
        { }

        public override bool RunQuest(Host host)
        {
            if (!base.RunQuest(host))
                return false;

            if (!checkQuestCompletedOrPerfomed(4411))
                return false;

            if (getQuest() == null)
            {
                if (!host.movementModule.GpsMove("Twocrown_Yorgis")) return false;
                Thread.Sleep(1000);
                host.StartQuest(id);
                Thread.Sleep(1000);
            }

            ArcheBuddy.Bot.Classes.Quest quest = getQuest();

            if (quest != null && quest.status == QuestStatus.Accepted)
            {
                Zone zone = new RoundZone(12367.92, 12085.47, 30);
                if (!host.movementModule.GpsMove("Quest_4064_1"))
                    return false;
                host.farmModule.SetFarmDoodads(zone, new uint[] { 6668 });
                while (CheckWeCanContinueFarmQuest(quest.id) && host.farmModule.readyToActions && host.farmModule.farmState == Modules.FarmState.Doodads)
                    Thread.Sleep(100);
                host.farmModule.StopFarm();
                Thread.Sleep(1000);
            }

            if (quest != null && quest.status == QuestStatus.Performed)
            {
                if (!host.movementModule.GpsMove("Twocrown_Yorgis")) return false;
                Thread.Sleep(1000);
                host.CompleteQuest(id);
                Thread.Sleep(1000);
            }
            return true;
        }
    }
}
