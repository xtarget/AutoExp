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
    internal class Quest_3974 : Quest
    {
        public Quest_3974(int minLvl, int maxLvl, QuestRace race, uint[] reqQuests)
            : base(3974, minLvl, maxLvl, race, reqQuests)
        { }

        public override bool RunQuest(Host host)
        {
            if (!base.RunQuest(host))
                return false;

            if ((host.gameTime() < 300 ||  host.gameTime() > 1080) && !checkQuestCompleted(557))
                return false;

            if (getQuest() == null)
            {
                if (!host.movementModule.GpsMove("Star_Airon")) return false;
                Thread.Sleep(1000);
                host.StartQuest(id);
                Thread.Sleep(1000);
            }

            if (!checkQuestCompletedOrAccepted(583))
                return false;
            if (!checkQuestCompletedOrAccepted(577))
                return false;

            ArcheBuddy.Bot.Classes.Quest quest = getQuest();


            if (quest != null && quest.status == QuestStatus.Accepted)
            {
                if (!host.movementModule.GpsMove("Quest_3974_1"))  return false;
                Thread.Sleep(1000);
                host.farmModule.UseDoodadSkill(17203, host.getNearestDoodad(10789), true);
                Thread.Sleep(1000);
            }

            if (!checkQuestCompleted(583))
                return false;

            if (quest != null && quest.status == QuestStatus.Performed)
            {
                if (!host.movementModule.GpsMove("Star_RedBandit")) return false;
                Thread.Sleep(1000);
                host.CompleteQuest(id);
                Thread.Sleep(1000);
            }

            return true;
        }
    }
}
