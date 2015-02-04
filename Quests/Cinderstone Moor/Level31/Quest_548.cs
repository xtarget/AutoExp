using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ArcheBuddy.Bot.Classes;


namespace AutoExp.Quests
{
    //
    internal class Quest_548 : Quest
    {
        public Quest_548(int minLvl, int maxLvl, QuestRace race, uint[] reqQuests)
            : base(548, minLvl, maxLvl, race, reqQuests)
        { }

        public override bool RunQuest(Host host)
        {
            if (!base.RunQuest(host))
                return false;

            if (getQuest() == null)
            {
                if (!host.movementModule.GpsMove("Star_Margo")) return false;
                Thread.Sleep(1000);
                host.StartQuest(id);
                Thread.Sleep(1000);
            }

            if (!checkQuestCompletedOrPerfomed(547))
                return false;
            if (!checkQuestCompletedOrPerfomed(3965))
                return false;
            if (!checkQuestCompletedOrPerfomed(551))
                return false;

            ArcheBuddy.Bot.Classes.Quest quest = getQuest();

            if (quest != null && quest.status == QuestStatus.Accepted)
            {
                try
                {
                    host.movementModule.disableMounting = true;
                    host.StandFromMount();
                    if (!host.movementModule.GpsMove("Quest_548_1")) return false;
                    Thread.Sleep(1000);
                    host.farmModule.UseDoodadSkill(11683, host.getNearestDoodad(2019), true);
                    Thread.Sleep(2000);
                    host.MoveTo(15521.53, 11720.95, 148.89);
                    host.MoveTo(15517.11, 11721.00, 149.05);
                    host.MoveTo(15516.98, 11724.79, 149.05);
                    Thread.Sleep(1500);
                    host.farmModule.UseDoodadSkill(11630, host.getNearestDoodad(1327), true);
                    host.MoveTo(15519.05, 11720.82, 149.05);
                    Thread.Sleep(7500);
                    host.farmModule.UseDoodadSkill(11683, host.getNearestDoodad(2019), true);
                    Thread.Sleep(2000);
                    host.MoveTo(15523.44, 11719.96, 148.89);
                }
                finally
                {
                    host.movementModule.disableMounting = false;
                }
            }

            if (!checkQuestCompleted(547))
                return false;

            if (quest != null && quest.status == QuestStatus.Performed)
            {
                try
                {
                    host.movementModule.disableMounting = true;
                    host.StandFromMount();
                    if (!host.movementModule.GpsMove("Star_Margo")) return false;
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
