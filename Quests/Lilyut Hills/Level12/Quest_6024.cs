using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ArcheBuddy.Bot.Classes;

namespace AutoExp.Quests
{
    internal class Quest_6024 : Quest
    {
        public Quest_6024(int minLvl, int maxLvl, QuestRace race, uint[] reqQuests)
            : base(6024, minLvl, maxLvl, race, reqQuests)
        { }

        public override bool RunQuest(Host host)
        {
            if (!base.RunQuest(host))
                return false;

            if (!checkQuestCompletedOrPerfomed(1582))
                return false;

            if (getQuest() == null)
            {
                if (!host.movementModule.GpsMove("Liliot_Barwen"))
                    return false;
                host.StartQuest(id);
                Thread.Sleep(1000);
            }

            if (!checkQuestCompleted(1638))
                return false;

            ArcheBuddy.Bot.Classes.Quest quest = getQuest();

            if (quest != null && quest.status == QuestStatus.Accepted)
            {
                if ((host.clientVersion == ClientVersion.RussiaMailRu && (host.itemCount(8343) >= 5 && host.itemCount(8327) >= 3)) || (host.clientVersion != ClientVersion.RussiaMailRu && (host.itemCount(8343) >= 3 && host.itemCount(8327) >= 1)))
                {
                    if (!host.movementModule.GpsMove("Blacksmith_33")) return false;
                    Thread.Sleep(1000);
                    host.CraftItems(5462, 1);
                    Thread.Sleep(1000);
                }
                else
                    return false;
            }
            
            return true;
        }
    }
}
