using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ArcheBuddy.Bot.Classes;

namespace AutoExp.Quests
{
    internal class Quest_2314 : Quest
    {
        public Quest_2314(int minLvl, int maxLvl, QuestRace race, uint[] reqQuests)
            : base(2314, minLvl, maxLvl, race, reqQuests)
        { }

        public override bool RunQuest(Host host)
        {
            if (!base.RunQuest(host))
                return false;

            if (getQuest() == null)
            {
                if (!host.movementModule.GpsMove("Inistra_Pair"))
                    return false;
                host.StartQuest(id);
                Thread.Sleep(1000);
            }

            ArcheBuddy.Bot.Classes.Quest quest = getQuest();

            if (quest != null && quest.status == QuestStatus.Accepted)
            {
                if (quest.steps[2] == 0)
                {
                    if (!host.movementModule.GpsMove("Quest_2314_1")) return false;
                    Thread.Sleep(1000);
                    host.farmModule.UseDoodadSkill(15199, host.getNearestDoodad(7848), true);
                    Thread.Sleep(1000);
                }
                if (quest.steps[1] == 0)
                {
                    if (!host.movementModule.GpsMove("Quest_2314_2")) return false;
                    Thread.Sleep(1000);
                    host.farmModule.UseDoodadSkill(15200, host.getNearestDoodad(7846), true);
                    Thread.Sleep(1000);
                }
                if (quest.steps[0] == 0)
                {
                    if (!host.movementModule.GpsMove("Quest_2314_3")) return false;
                    Thread.Sleep(1000);
                    host.farmModule.UseDoodadSkill(15201, host.getNearestDoodad(7856), true);
                    Thread.Sleep(1000);
                }
            }
            
            if (quest != null && quest.status == QuestStatus.Performed)
            {
                if (!host.movementModule.GpsMove("Inistra_Pair")) return false;
                Thread.Sleep(1000);
                host.CompleteQuest(id);
                Thread.Sleep(1000);
            }

            return true;
        }
    }
}
