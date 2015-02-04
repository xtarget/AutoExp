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
    internal class Quest_2764 : Quest
    {
        public Quest_2764(int minLvl, int maxLvl, QuestRace race, uint[] reqQuests)
            : base(2764, minLvl, maxLvl, race, reqQuests)
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

            if (!checkQuestCompletedOrAccepted(3440))
                return false;

            if (getQuest() == null)
            {
                if (!host.movementModule.GpsMove("Ferre_Murana")) return false;
                host.StartQuest(id);
                Thread.Sleep(1000);
            }

            ArcheBuddy.Bot.Classes.Quest quest = getQuest();

            if (quest != null && quest.status == QuestStatus.Accepted)
            {
                if (!host.movementModule.GpsMove("Ferre_Murana")) return false;
                host.MoveTo(24032.69, 8822.09, 578.33);
                host.MoveTo(24035.42, 8832.46, 579.82);
                host.MoveTo(24032.87, 8862.39, 580.92);
                MoveToAndWait(24038.81, 8863.76, 580.98);
                MoveToAndWait(24040.42, 8856.18, 582.88);
                MoveToAndWait(24048.06, 8858.59, 582.90);
                var door = host.getNearestDoodad(11163);
                if (door != null && host.dist(door) < 5)
                {
                    host.farmModule.UseDoodadSkill(16828, door, true);
                    Thread.Sleep(3000);
                }
                MoveToAndWait(24046.10, 8858.19, 582.90);
                MoveToAndWait(24051.85, 8859.36, 582.90);
                MoveToAndWait(24052.98, 8857.27, 582.90);
                MoveToAndWait(24055.84, 8858.17, 582.90);
                MoveToAndWait(24052.50, 8861.73, 582.90);
                MoveToAndWait(24050.76, 8869.22, 582.90);
                MoveToAndWait(24052.17, 8863.24, 582.90);
                MoveToAndWait(24053.00, 8860.33, 582.90);
                MoveToAndWait(24055.94, 8859.29, 582.90);
                MoveToAndWait(24051.67, 8859.37, 582.90);
                
                door = host.getNearestDoodad(11163);
                if (door != null && host.dist(door) < 5)
                {
                    host.farmModule.UseDoodadSkill(16828, door, true);
                    Thread.Sleep(3000);
                }
                MoveToAndWait(24053.39, 8859.61, 582.90);
                MoveToAndWait(24046.18, 8858.55, 582.90);
                MoveToAndWait(24040.67, 8855.88, 582.88);
                MoveToAndWait(24038.58, 8863.73, 580.97);
                host.MoveTo(24032.00, 8859.19, 580.85);
                host.MoveTo(24033.76, 8826.44, 579.13);
                host.MoveTo(24018.87, 8812.81, 577.47);
            }

            return true;
        }
    }
}
