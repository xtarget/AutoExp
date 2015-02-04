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
    internal class Quest_597 : Quest
    {
        public Quest_597(int minLvl, int maxLvl, QuestRace race, uint[] reqQuests)
            : base(597, minLvl, maxLvl, race, reqQuests)
        { }

        public override bool RunQuest(Host host)
        {
            if (!base.RunQuest(host))
                return false;

            if ((host.gameTime() < 300 ||  host.gameTime() > 1080) && !checkQuestCompleted(557))
                return false;

            if (getQuest() == null)
            {
                if (!host.movementModule.GpsMove("Star_Kamrodi")) return false;
                Thread.Sleep(1000);
                host.StartQuest(id);
                Thread.Sleep(1000);
            }

            if (!checkQuestCompleted(593))
                return false;

            ArcheBuddy.Bot.Classes.Quest quest = getQuest();

            if (quest != null && quest.status == QuestStatus.Accepted)
            {
                if (!host.movementModule.GpsMove("Quest_577_1")) return false;
                Thread.Sleep(1000);
                var d = host.getNearestDoodad(1723);
                if (d != null && host.dist(d) < 4)
                {
                    host.farmModule.UseDoodadSkill(14895, d, true);
                    Thread.Sleep(2000);
                }
                host.MoveTo(15529.33, 12491.38, 153.33);
                host.MoveTo(15534.95, 12493.13, 153.33);
                Thread.Sleep(1500);
                host.farmModule.UseDoodadSkill(13545, host.getNearestDoodad(1340), true);
                host.MoveTo(15529.75, 12490.63, 153.33);
                Thread.Sleep(9000);
                d = host.getNearestDoodad(1723);
                if (d != null && host.dist(d) < 4)
                {
                    host.farmModule.UseDoodadSkill(14895, d, true);
                    Thread.Sleep(2000);
                }
                host.MoveTo(15531.46, 12486.07, 153.02);
            }

            if (quest != null && quest.status == QuestStatus.Performed)
            {
                if (!host.movementModule.GpsMove("Star_Kamrodi")) return false;
                Thread.Sleep(1000);
                host.CompleteQuest(id);
                Thread.Sleep(1000);
            }

            return true;
        }
    }
}
