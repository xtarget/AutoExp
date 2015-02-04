using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ArcheBuddy.Bot.Classes;

namespace AutoExp.Quests
{
    internal class Quest_3730 : Quest
    {
        public Quest_3730(int minLvl, int maxLvl, QuestRace race, uint[] reqQuests)
            : base(3730, minLvl, maxLvl, race, reqQuests)
        { }

        public override bool RunQuest(Host host)
        {
            if (!base.RunQuest(host))
                return false;

            if (getQuest() == null)
            {
                if (!host.movementModule.GpsMove("Stone_Nick"))
                    return false;
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
                    if (!host.movementModule.GpsMove("Quest_3730_1")) return false;
                    Thread.Sleep(1000);
                    host.farmModule.Climb(host.getNearestDoodad(140));
                    Thread.Sleep(1500);
                    host.ClimbDown();
                    Thread.Sleep(1500);
                    host.farmModule.UseItemAndWait(20019);
                    Thread.Sleep(1000);
                    host.farmModule.Climb(host.getNearestDoodad(140));
                    Thread.Sleep(1500);
                    host.ClimbUp();
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
                    if (!host.movementModule.GpsMove("Stone_Nick")) return false;
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
