using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ArcheBuddy.Bot.Classes;


namespace AutoExp.Quests
{
    internal class Quest_3652 : Quest
    {
        public Quest_3652(int minLvl, int maxLvl, QuestRace race, uint[] reqQuests)
            : base(3652, minLvl, maxLvl, race, reqQuests)
        { }

        public override bool RunQuest(Host host)
        {
            if (!base.RunQuest(host))
                return false;

            if (getQuest() == null)
            {
                if (!host.movementModule.GpsMove("Headlands_Kapur")) return false;
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
                    if (!host.movementModule.GpsMove("Quest_3652_1")) return false;
                    host.MoveTo(16855.18, 7975.51, 161.86);
                    Thread.Sleep(1500);
                    host.farmModule.Climb(host.getNearestDoodad(30));
                    Thread.Sleep(1500);
                    host.ClimbUp();
                    Thread.Sleep(2000);
                    host.farmModule.UseDoodadSkill(16352, host.getNearestDoodad(9800), true);
                    Thread.Sleep(1000);
                    host.farmModule.Climb(host.getNearestDoodad(30));
                    Thread.Sleep(1500);
                    host.ClimbDown();
                    Thread.Sleep(2000);
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
                    if (!host.movementModule.GpsMove("Headlands_Kapur")) return false;
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
