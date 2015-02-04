using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ArcheBuddy.Bot.Classes;

namespace AutoExp.Quests
{
    internal class Quest_2567 : Quest
    {
        public Quest_2567(int minLvl, int maxLvl, QuestRace race, uint[] reqQuests)
            : base(2567, minLvl, maxLvl, race, reqQuests)
        { }

        public override bool RunQuest(Host host)
        {
            if (!base.RunQuest(host))
                return false;

            if (!checkQuestCompletedOrPerfomed(149))
                return false;

            if (getQuest() == null)
            {
                if (!host.movementModule.GpsMove("White_Shtols"))
                    return false;
                host.StartQuest(id);
                Thread.Sleep(1000);
            }

            if (!checkQuestCompletedOrAccepted(2566))
                return false;

            ArcheBuddy.Bot.Classes.Quest quest = getQuest();

            if (quest != null && quest.status == QuestStatus.Accepted)
            {
                if (!host.movementModule.GpsMove("Quest_2567_2")) return false;
                Thread.Sleep(1000);
                var d = host.getNearestDoodad(5194);
                if (d != null && host.dist(d) < 4)
                {
                    host.farmModule.UseDoodadSkill(13439, d);
                    Thread.Sleep(2000);
                }
                
                host.movementModule.GpsMove("Quest_2567_1");
                Thread.Sleep(1000);
                host.farmModule.UseDoodadSkill(14379, host.getNearestDoodad(6862), true);
                Thread.Sleep(3500);
                while (host.farmModule.aggroMobsCount() > 0)
                    Thread.Sleep(500);

                host.movementModule.GpsMove("Quest_2567_3");
                Thread.Sleep(1000);
                host.MoveTo(9658.56, 12825.18, 165.48);
                Thread.Sleep(1000);
                d = host.getNearestDoodad(5194);
                if (d != null && host.dist(d) < 4)
                {
                    host.farmModule.UseDoodadSkill(13439, d);
                    Thread.Sleep(2000);
                }
                host.MoveTo(9656.75, 12834.44, 163.92);
            }

            if (!checkQuestCompleted(2566))
                return false;

            if (quest != null && quest.status == QuestStatus.Performed)
            {
                if (!host.movementModule.GpsMove("White_Shtols")) return false;
                Thread.Sleep(1000);
                host.CompleteQuest(id);
                Thread.Sleep(1000);
            }
             

            return true;
        }
    }
}
