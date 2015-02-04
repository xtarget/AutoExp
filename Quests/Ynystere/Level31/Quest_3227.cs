using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ArcheBuddy.Bot.Classes;

namespace AutoExp.Quests
{
    internal class Quest_3227 : Quest
    {
        public Quest_3227(int minLvl, int maxLvl, QuestRace race, uint[] reqQuests)
            : base(3227, minLvl, maxLvl, race, reqQuests)
        { }

        public override bool RunQuest(Host host)
        {
            if (!base.RunQuest(host))
                return false;

            if (getQuest() == null)
            {
                if (!host.movementModule.GpsMove("Inistra_Tyra"))
                    return false;
                host.StartQuest(id);
                Thread.Sleep(1000);
            }

            ArcheBuddy.Bot.Classes.Quest quest = getQuest();

            if (quest != null && quest.status == QuestStatus.Accepted)
            {
                if (!host.movementModule.GpsMove("Inistra_Renata")) return false;
                Thread.Sleep(1000);
                host.TalkWithQuestNpc(id);
                Thread.Sleep(1000);
            }

            if (quest != null && quest.status == QuestStatus.Performed)
            {
                if (host.dist(20906.28, 13144.08, 114.41) < 1000)
                {
                    if (!host.movementModule.GpsMove("Inistra_Renata")) return false;
                    Thread.Sleep(1000);
                    host.MoveTo(20903.91, 13140.45, 114.71);
                    Thread.Sleep(1000);
                    host.farmModule.UseDoodadSkill(17557, host.getNearestDoodad(11368), true);
                    host.WaitTeleportCompleted(120000);
                    Thread.Sleep(60000);
                }
                if (!host.movementModule.GpsMove("Golden_Vervind")) return false;
                Thread.Sleep(1000);
                host.CompleteQuest(id);
                Thread.Sleep(1000);
            }
            
            return true;
        }
    }
}
