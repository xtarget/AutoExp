using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ArcheBuddy.Bot.Classes;

namespace AutoExp.Quests
{
    internal class Quest_2486 : Quest
    {
        public Quest_2486(int minLvl, int maxLvl, QuestRace race, uint[] reqQuests)
            : base(2486, minLvl, maxLvl, race, reqQuests)
        { }

        public override bool RunQuest(Host host)
        {
            if (!base.RunQuest(host))
                return false;

            if (getQuest() == null)
            {
                if (!host.movementModule.GpsMove("Liliot_Masden"))
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
                    if (!host.movementModule.GpsMove("Liliot_Malcolm")) return false;
                    Thread.Sleep(1000);
                    var d = host.getNearestDoodad(5194);
                    if (d != null && host.dist(d) < 5)
                    {
                        host.farmModule.UseDoodadSkill(13439, d, true);
                        Thread.Sleep(3000);
                    }
                    host.MoveTo(13527.98, 15927.91, 170.81);
                    host.TalkWithQuestNpc(id, host.farmModule.GetNearestCreatureById(10586));
                    Thread.Sleep(1000);
                    host.MoveTo(13527.98, 15927.91, 170.81);
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
                    if (!host.movementModule.GpsMove("Liliot_Masden")) return false;
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
