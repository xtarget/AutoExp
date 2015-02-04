using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ArcheBuddy.Bot.Classes;


namespace AutoExp.Quests
{
    internal class Quest_859 : Quest
    {
        public Quest_859(int minLvl, int maxLvl, QuestRace race, uint[] reqQuests)
            : base(859, minLvl, maxLvl, race, reqQuests)
        { }

        public override bool RunQuest(Host host)
        {
            if (!base.RunQuest(host))
                return false;
            
            if (host.me.charRace == CharRace.Hariharan && !checkQuestCompletedOrPerfomed(3531))
                return false;
            if (host.me.charRace == CharRace.Ferre && !checkQuestCompletedOrAccepted(3455))
                return false;
            if (!checkQuestCompletedOrAccepted(2129))
                return false;

            if (getQuest() == null)
            {
                if (!host.movementModule.GpsMove("Mahadevi_Volata")) return false;
                Thread.Sleep(1000);
                host.StartQuest(id);
                Thread.Sleep(1000);
            }

            ArcheBuddy.Bot.Classes.Quest quest = getQuest();

            if (quest != null && quest.status == QuestStatus.Accepted)
            {
                Zone zone = new RoundZone(20149.54, 8656.33, 60);
                if (!zone.ObjInZone(host.me))
                    if (!host.movementModule.GpsMove("Quest_859_1")) return false;
                host.farmModule.SetFarmDoodads(zone, new uint[] { 1458 });
                while (CheckWeCanContinueFarmQuest(quest.id) && host.farmModule.readyToActions && host.farmModule.farmState == Modules.FarmState.Doodads)
                    Thread.Sleep(100);
                host.farmModule.StopFarm();
                Thread.Sleep(1000);
            }

            if (!checkQuestCompleted(893))
                return false;

            if (quest.status == QuestStatus.Performed)
            {
                if (!host.movementModule.GpsMove("Mahadevi_Volata")) return false;
                Thread.Sleep(1000);
                host.CompleteQuest(id);
                Thread.Sleep(1000);
            }

            return true;
        }
    }
}
