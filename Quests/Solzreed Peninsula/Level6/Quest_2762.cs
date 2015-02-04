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
    internal class Quest_2762 : Quest
    {
        public Quest_2762(int minLvl, int maxLvl, QuestRace race, uint[] reqQuests)
            : base(2762, minLvl, maxLvl, race, reqQuests)
        { }

        private void MoveToAndWait(double X, double Y, double Z)
        {
            host.MoveTo(X, Y, Z);
            while (host.me.isMoving)
                Thread.Sleep(100);
            Thread.Sleep(400);
        }

        public override bool RunQuest(Host host)
        {
            if (!base.RunQuest(host))
                return false;

            if (!checkQuestCompletedOrPerfomed(354))
                return false;

            if (getQuest() == null)
            {
                if (!host.movementModule.GpsMove("Solrid_Malk"))
                    return false;
                host.StartQuest(id);
                Thread.Sleep(1000);
            }

            ArcheBuddy.Bot.Classes.Quest quest = getQuest();

            if (quest != null && quest.status == QuestStatus.Accepted)
            {
                MoveToAndWait(14890.13, 14481.78, 116.52);
                MoveToAndWait(14879.75, 14487.76, 120.89);
                MoveToAndWait(14877.94, 14480.74, 120.91);
                var door = host.getNearestDoodad(10521);
                if (door != null && host.dist(door) < 5)
                {
                    host.farmModule.UseDoodadSkill(16828, door, true);
                    Thread.Sleep(3000);
                }
                MoveToAndWait(14874.90, 14474.49, 120.91);
                MoveToAndWait(14878.98, 14469.67, 120.91);
                MoveToAndWait(14872.08, 14472.72, 120.91);
                MoveToAndWait(14875.50, 14476.24, 120.91);

                door = host.getNearestDoodad(10521);
                if (door != null && host.dist(door) < 5)
                {
                    host.farmModule.UseDoodadSkill(16828, door, true);
                    Thread.Sleep(3000);
                }

                MoveToAndWait(14878.90, 14482.45, 120.91);
                MoveToAndWait(14879.21, 14487.48, 120.89);
                MoveToAndWait(14890.70, 14481.85, 116.56);
                MoveToAndWait(14898.17, 14480.51, 116.62);
            }

            if (quest != null && quest.status == QuestStatus.Performed)
            {
                if (!host.movementModule.GpsMove("Solrid_Malk")) return false;
                Thread.Sleep(1000);
                host.CompleteQuest(id);
                Thread.Sleep(1000);
            }

            return true;
        }
    }
}
