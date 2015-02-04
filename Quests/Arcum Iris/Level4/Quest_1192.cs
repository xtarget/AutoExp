using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ArcheBuddy.Bot.Classes;

namespace AutoExp.Quests
{
    internal class Quest_1192 : Quest
    {
        public Quest_1192(int minLvl, int maxLvl, QuestRace race, uint[] reqQuests)
            : base(1192, minLvl, maxLvl, race, reqQuests)
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


            if (getQuest() == null)
            {
                if (!host.movementModule.GpsMove("Arcum_Radia"))
                    return false;
                host.StartQuest(id);
                Thread.Sleep(1000);
            }

            ArcheBuddy.Bot.Classes.Quest quest = getQuest();

            if (quest != null && quest.status == ArcheBuddy.Bot.Classes.QuestStatus.Accepted)
            {
                if (!host.movementModule.GpsMove("Arcum_Radia"))
                    return false;
                MoveToAndWait(19975.86, 7672.63, 180.54);
                MoveToAndWait(19975.21, 7681.34, 183.57);
                MoveToAndWait(19968.09, 7681.23, 183.59);
                var door = host.getNearestDoodad(11163);
                if (door != null && host.dist(door) < 5)
                {
                    host.farmModule.UseDoodadSkill(16828, door, true);
                    Thread.Sleep(3000);
                }
                MoveToAndWait(19963.30, 7681.01, 183.59);
                MoveToAndWait(19959.86, 7683.67, 183.59);
                MoveToAndWait(19962.16, 7678.50, 183.59);
                MoveToAndWait(19958.60, 7681.58, 183.59);
                MoveToAndWait(19964.02, 7681.16, 183.59);

                door = host.getNearestDoodad(11163);
                if (door != null && host.dist(door) < 5)
                {
                    host.farmModule.UseDoodadSkill(16828, door, true);
                    Thread.Sleep(3000);
                }
                MoveToAndWait(19969.76, 7680.93, 183.59);
                MoveToAndWait(19974.91, 7683.41, 183.57);
                MoveToAndWait(19975.78, 7672.05, 180.52);
            }

            if (quest != null && quest.status == ArcheBuddy.Bot.Classes.QuestStatus.Performed)
            {
                if (!host.movementModule.GpsMove("Arcum_Radia"))
                    return false;
                host.CompleteQuest(id);
                Thread.Sleep(1000);
            }

            return true;
        }
    }
}
