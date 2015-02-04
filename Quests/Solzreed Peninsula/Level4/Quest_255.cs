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
    internal class Quest_255 : Quest
    {
        public Quest_255(int minLvl, int maxLvl, QuestRace race, uint[] reqQuests)
            : base(255, minLvl, maxLvl, race, reqQuests)
        { }

        public override bool RunQuest(Host host)
        {
            if (!base.RunQuest(host))
                return false;

            if (getQuest() == null)
            {
                if (!host.movementModule.GpsMove("Solrid_Djenni"))
                    return false;
                host.StartQuest(id);
                Thread.Sleep(1000);
            }

            ArcheBuddy.Bot.Classes.Quest quest = getQuest();

            if (quest != null && quest.status == QuestStatus.Accepted)
            {
                if (!host.movementModule.GpsMove("Solrid_Djenni")) return false;
                Thread.Sleep(1000);
                host.farmModule.Climb(host.getNearestDoodad(34));
                Thread.Sleep(1000);
                try
                {
                    host.MoveForward(true);
                    Thread.Sleep(16000);
                }
                finally
                {
                    host.MoveForward(false);
                }
                if (host.me.Z > 160)
                {
                    while (host.farmModule.readyToActions && host.isAlive() && host.me.Z > 160 && quest.status == QuestStatus.Accepted)
                    {
                        var d = host.getNearestDoodad(242);
                        if (d != null && host.dist(d) < 5)
                            host.farmModule.UseDoodadSkill(11787, d);
                        Thread.Sleep(100);
                    }
                }
                host.ClimbDown();
            }

            if (quest != null && quest.status == QuestStatus.Performed)
            {
                if (!host.movementModule.GpsMove("Solrid_Djenni")) return false;
                Thread.Sleep(1000);
                host.CompleteQuest(id);
                Thread.Sleep(1000);
            }

            return true;
        }
    }
}
