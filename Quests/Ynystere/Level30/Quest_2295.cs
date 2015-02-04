using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ArcheBuddy.Bot.Classes;

namespace AutoExp.Quests
{
    internal class Quest_2295 : Quest
    {
        public Quest_2295(int minLvl, int maxLvl, QuestRace race, uint[] reqQuests)
            : base(2295, minLvl, maxLvl, race, reqQuests)
        { }

        public override bool RunQuest(Host host)
        {
            if (!base.RunQuest(host))
                return false;

            if (getQuest() == null)
            {
                if (!host.movementModule.GpsMove("Inistra_Edvir"))
                    return false;
                host.StartQuest(id);
                Thread.Sleep(1000);
            }

            if (!checkQuestCompletedOrAccepted(2298))
                return false;

            ArcheBuddy.Bot.Classes.Quest quest = getQuest();

            if (quest != null && quest.status == QuestStatus.Accepted)
            {
                if (quest.steps[0] == 0)
                {
                    if (!host.movementModule.GpsMove("Quest_2295_1")) return false;
                    Thread.Sleep(1000);
                    host.farmModule.UseDoodadSkill(15272, host.getNearestDoodad(8685), true);
                    Thread.Sleep(1000);
                }
                else if (quest.steps[1] == 0)
                {
                    if (!host.movementModule.GpsMove("Quest_2295_2")) return false;
                    Thread.Sleep(1000);
                    host.farmModule.UseDoodadSkill(15272, host.getNearestDoodad(8429), true);
                    Thread.Sleep(1000);
                }
                else if (quest.steps[2] == 0)
                {
                    if (!host.movementModule.GpsMove("Quest_2295_3")) return false;
                    Thread.Sleep(1000);
                    host.farmModule.UseDoodadSkill(15272, host.getNearestDoodad(8431), true);
                    Thread.Sleep(1000);
                }
            }

            if (!checkQuestCompleted(2298))
                return false;

            if (quest != null && quest.status == QuestStatus.Performed)
            {
                if (!host.movementModule.GpsMove("Inistra_Helmi")) return false;
                Thread.Sleep(1000);
                host.CompleteQuest(id);
                Thread.Sleep(1000);
            }

            return true;
        }
    }
}
