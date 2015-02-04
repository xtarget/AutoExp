using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ArcheBuddy.Bot.Classes;

namespace AutoExp.Quests
{
    internal class Quest_186 : Quest
    {
        public Quest_186(int minLvl, int maxLvl, QuestRace race, uint[] reqQuests)
            : base(186, minLvl, maxLvl, race, reqQuests)
        { }

        public override bool RunQuest(Host host)
        {
            if (!base.RunQuest(host))
                return false;

            if (getQuest() == null)
            {
                if (!host.movementModule.GpsMove("Marianpole_Lester"))
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
                    if (!host.movementModule.GpsMove("Quest_186_1")) return false;
                    Thread.Sleep(1000);
                    host.farmModule.UseDoodadSkill(12774, host.getNearestDoodad(3983), true);
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
                    if (!host.movementModule.GpsMove("Marianpole_Lester")) return false;
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
