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
    internal class Quest_937 : Quest
    {
        public Quest_937(int minLvl, int maxLvl, QuestRace race, uint[] reqQuests)
            : base(937, minLvl, maxLvl, race, reqQuests)
        { }

        public override bool RunQuest(Host host)
        {
            if (!base.RunQuest(host))
                return false;

            if (getQuest() == null)
            {
                if (!host.movementModule.GpsMove("Star_Lindsi")) return false;
                Thread.Sleep(1000);
                host.StartQuest(id);
                Thread.Sleep(1000);
            }

            ArcheBuddy.Bot.Classes.Quest quest = getQuest();

            if (quest != null && quest.status == QuestStatus.Accepted)
            {
                try
                {
                    host.movementModule.disableMounting = true;
                    host.StandFromMount();
                    if (!host.movementModule.GpsMove("Quest_545_1")) return false;
                    Thread.Sleep(1000);
                    host.farmModule.Climb(host.getNearestDoodad(83));
                    Thread.Sleep(1500);
                    host.ClimbUp();
                    Thread.Sleep(1000);
                    host.SetTarget(host.farmModule.GetNearestCreatureById(2444));
                    host.farmModule.UseItemAndWait(4959);
                    host.farmModule.UseItemAndWait(7742);
                    Thread.Sleep(1000);
                    host.MoveTo(15558.55, 11560.40, 156.25);
                    Thread.Sleep(1000);
                    host.farmModule.Climb(host.getNearestDoodad(83));
                    Thread.Sleep(1500);
                    host.ClimbDown();
                    Thread.Sleep(1000);
                }
                finally
                {
                    host.movementModule.disableMounting = false;
                }
            }

            if (quest != null && quest.status == QuestStatus.Performed)
            {
                try
                {
                    host.movementModule.disableMounting = true;
                    host.StandFromMount();
                    if (!host.movementModule.GpsMove("Star_Lindsi")) return false;
                    Thread.Sleep(1000);
                    host.CompleteQuest(id);
                    Thread.Sleep(1000);
                }
                finally
                {
                    host.movementModule.disableMounting = false;
                }
            }

            return true;
        }
    }
}
