using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ArcheBuddy.Bot.Classes;

namespace AutoExp.Quests
{
    internal class Quest_88 : Quest
    {
        public Quest_88(int minLvl, int maxLvl, QuestRace race, uint[] reqQuests)
            : base(88, minLvl, maxLvl, race, reqQuests)
        { }

        public override bool RunQuest(Host host)
        {
            if (!base.RunQuest(host))
                return false;

            if (getQuest() == null)
            {
                if (!host.movementModule.GpsMove("Stone_Table2"))
                    return false;
                host.StartQuest(id);
                Thread.Sleep(1000);
            }

            if (!checkQuestCompletedOrPerfomed(961))
                return false;

            ArcheBuddy.Bot.Classes.Quest quest = getQuest();

            if (quest != null && quest.status == QuestStatus.Accepted)
            {
                if (!host.movementModule.GpsMove("Quest_88_2"))
                    return false;
                Zone mob1Zone = new RoundZone(12414, 12843, 3);
                if (host.farmModule.mobsCountInZone(791, mob1Zone) > 0)
                {
                    host.farmModule.farmState = Modules.FarmState.Disabled;
                    host.SetTarget(host.farmModule.GetNearestCreatureById(791));
                    Thread.Sleep(3000);
                    host.farmModule.UseSkillAndWait(16064);
                    host.MoveTo(12393.45, 12865.69, 111.92);
                    Thread.Sleep(5000);
                    host.farmModule.farmState = Modules.FarmState.AttackOnlyAgro;
                }
                Zone zone = new RoundZone(12406.04, 12815.10, 10);
                if (!host.movementModule.GpsMove("Quest_88_1"))
                    return false;
                host.farmModule.SetFarmMobs(zone, new uint[] { 790 });
                while (CheckWeCanContinueFarmQuest(quest.id) && host.farmModule.readyToActions && host.farmModule.farmState == Modules.FarmState.Enabled)
                    Thread.Sleep(100);
                host.farmModule.StopFarm();
                Thread.Sleep(1000);
            }

            if (!checkQuestCompleted(935))
                return false;

            
            if (quest != null && quest.status == QuestStatus.Performed)
            {
                if (!host.movementModule.GpsMove("Stone_Yilson")) return false;
                Thread.Sleep(1000);
                host.CompleteQuest(id);
                Thread.Sleep(1000);
            }
            
            
            return true;
        }
    }
}
