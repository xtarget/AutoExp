using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ArcheBuddy.Bot.Classes;


namespace AutoExp.Quests
{
    internal class Quest_1776 : Quest
    {
        public Quest_1776(int minLvl, int maxLvl, QuestRace race, uint[] reqQuests)
            : base(1776, minLvl, maxLvl, race, reqQuests)
        { }

        public override bool RunQuest(Host host)
        {
            if (!base.RunQuest(host))
                return false;

            if (getQuest() == null)
            {
                if (!host.movementModule.GpsMove("Golden_Tryp2"))
                    return false;
                host.StartQuest(id);
                Thread.Sleep(1000);
            }

            if (!checkQuestCompletedOrAccepted(1774))
                return false;
            if (!checkQuestCompletedOrAccepted(1773))
                return false;
            if (!checkQuestCompletedOrAccepted(1784))
                return false;

            ArcheBuddy.Bot.Classes.Quest quest = getQuest();

            if (quest != null && quest.status == QuestStatus.Accepted)
            {
                if (!host.movementModule.GpsMove("Golden_Gibson")) return false;
                Thread.Sleep(1000);
                host.TalkWithQuestNpc(id, host.farmModule.GetNearestCreatureById(2807));
                Thread.Sleep(1000);
                if (!host.movementModule.GpsMove("Golden_Elli")) return false;
                Thread.Sleep(1000);
                host.TalkWithQuestNpc(id, host.farmModule.GetNearestCreatureById(2806));
                Thread.Sleep(1000);
                if (!host.movementModule.GpsMove("Golden_Lili")) return false;
                Thread.Sleep(1000);
                host.TalkWithQuestNpc(id, host.farmModule.GetNearestCreatureById(2851));
                Thread.Sleep(1000);
            }

            return true;
        }
    }
}
