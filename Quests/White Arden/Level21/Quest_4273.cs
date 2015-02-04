using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ArcheBuddy.Bot.Classes;

namespace AutoExp.Quests
{
    internal class Quest_4273 : Quest
    {
        public Quest_4273(int minLvl, int maxLvl, QuestRace race, uint[] reqQuests)
            : base(4273, minLvl, maxLvl, race, reqQuests)
        { }

        public override bool RunQuest(Host host)
        {
            if (!base.RunQuest(host))
                return false;

            if (getQuest() == null)
            {
                if (!checkQuestCompletedOrAccepted(150))
                    return false;
                if (!checkQuestCompletedOrAccepted(151))
                    return false;
                if (!checkQuestCompletedOrAccepted(152))
                    return false;
                if (!host.movementModule.GpsMove("White_Seimon"))
                    return false;
                host.StartQuest(id);
                Thread.Sleep(1000);
            }

            ArcheBuddy.Bot.Classes.Quest quest = getQuest();

            if (quest != null && quest.status == QuestStatus.Accepted)
            {
                if (host.itemCount(17677) == 0)
                {
                    while (host.isAlive() && host.itemCount(17677) == 0)
                    {
                        if (!host.movementModule.GpsMove("Quest_4273_1")) return false;
                        Thread.Sleep(1000);
                        host.farmModule.UseDoodadSkill(14503, host.getNearestDoodad(6967), true);
                        Thread.Sleep(1000);
                    }
                }
                if (host.itemCount(17678) == 0)
                {
                    while (host.isAlive() && host.itemCount(17678) == 0)
                    {
                        if (!host.movementModule.GpsMove("Quest_4273_2")) return false;
                        Thread.Sleep(1000);
                        host.farmModule.UseDoodadSkill(14502, host.getNearestDoodad(6958), true);
                        Thread.Sleep(1000);
                    }
                }
                if (host.itemCount(17676) == 0)
                {
                    while (host.isAlive() && host.itemCount(17676) == 0)
                    {
                        if (!host.movementModule.GpsMove("Quest_4273_3")) return false;
                        Thread.Sleep(1000);
                        host.farmModule.UseDoodadSkill(14501, host.getNearestDoodad(6954), true);
                        Thread.Sleep(1000);
                    }
                }
                if (host.itemCount(17676) > 0 && host.itemCount(17677) > 0 && host.itemCount(17678) > 0)
                {
                    host.farmModule.UseItemAndWait(17676);
                    Thread.Sleep(1000);
                }
            }

            if (!checkQuestCompletedOrPerfomed(152))
                return false;

            if (quest != null && quest.status == QuestStatus.Performed)
            {
                if (!host.movementModule.GpsMove("White_Seimon")) return false;
                Thread.Sleep(1000);
                host.CompleteQuest(id);
                Thread.Sleep(1000);
            }

            return true;
        }
    }
}
