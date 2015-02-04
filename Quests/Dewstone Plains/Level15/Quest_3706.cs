using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ArcheBuddy.Bot.Classes;

namespace AutoExp.Quests
{
    internal class Quest_3706 : Quest
    {
        public Quest_3706(int minLvl, int maxLvl, QuestRace race, uint[] reqQuests)
            : base(3706, minLvl, maxLvl, race, reqQuests)
        { }

        public override bool RunQuest(Host host)
        {
            if (!base.RunQuest(host))
                return false;

            if (!checkQuestCompletedOrPerfomed(1631))
                return false;

            if (getQuest() == null)
            {
                if (!host.movementModule.GpsMove("Stone_Albert"))
                    return false;
                host.StartQuest(id);
                Thread.Sleep(1000);
            }

            ArcheBuddy.Bot.Classes.Quest quest = getQuest();

            if (quest != null && quest.status == QuestStatus.Accepted)
            {
                if (!host.movementModule.GpsMove("Stone_Albert")) return false;
                Thread.Sleep(1000);
                var d = host.farmModule.GetNearestCreatureById(707);
                while (host.farmModule.readyToActions && quest.status == QuestStatus.Accepted && host.isAlive() && host.isExists(d))
                {
                    host.SetTarget(d);
                    Thread.Sleep(1000);
                    host.ComeTo(d, 2);
                    while (host.me.isMoving)
                        Thread.Sleep(200);
                    host.farmModule.UseSkillAndWait(16519);
                }
            }

            if (quest != null && quest.status == QuestStatus.Performed)
            {
                if (!host.movementModule.GpsMove("Stone_Roister")) return false;
                Thread.Sleep(1000);
                host.CompleteQuest(id);
                Thread.Sleep(1000);
            }
            
            return true;
        }
    }
}
