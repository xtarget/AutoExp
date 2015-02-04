using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ArcheBuddy.Bot.Classes;

namespace AutoExp.Quests
{
    internal class Quest_84 : Quest
    {
        public Quest_84(int minLvl, int maxLvl, QuestRace race, uint[] reqQuests)
            : base(84, minLvl, maxLvl, race, reqQuests)
        { }

        public override bool RunQuest(Host host)
        {
            if (!base.RunQuest(host))
                return false;

            if (getQuest() == null)
            {
                if (!host.movementModule.GpsMove("Stone_Edvina"))
                    return false;
                host.StartQuest(id);
                Thread.Sleep(1000);
            }

            ArcheBuddy.Bot.Classes.Quest quest = getQuest();

            if (quest != null && quest.status == QuestStatus.Accepted)
            {
                if (!host.movementModule.GpsMove("Stone_Yilson")) return false;
                Thread.Sleep(1000);
                host.farmModule.UseDoodadSkill(12806, host.getNearestDoodad(3646), true);
                Thread.Sleep(1000);
                if (host.isMounted())
                {
                    host.StandFromMount();
                    while (host.me.isMoving)
                        Thread.Sleep(100);
                    Thread.Sleep(250);
                }
                host.UseItem(1843,host.me.X,host.me.Y+1,host.me.Z);
                Thread.Sleep(1000);
            }
            

            if (quest != null && quest.status == QuestStatus.Performed)
            {
                if (!host.movementModule.GpsMove("Stone_Yilson")) return false;
                Thread.Sleep(1000);
                host.CompleteQuest(id);
                Thread.Sleep(1000);
            }
            
            
            return true;
        }
    }
}
