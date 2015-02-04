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
    internal class Quest_806 : Quest
    {
        public Quest_806(int minLvl, int maxLvl, QuestRace race, uint[] reqQuests)
            : base(806, minLvl, maxLvl, race, reqQuests)
        { }

        public override bool RunQuest(Host host)
        {
            if (!base.RunQuest(host))
                return false;

            if (getQuest() == null)
            {
                if (!host.movementModule.GpsMove("SigningLand_Siu")) return false;
                host.StartQuest(id);
                Thread.Sleep(1000);
            }

            ArcheBuddy.Bot.Classes.Quest quest = getQuest();

            if (host.me.charRace == CharRace.Ferre && !checkQuestCompletedOrPerfomed(3479))
                return false;
            if (host.me.charRace == CharRace.Hariharan && !checkQuestCompletedOrPerfomed(3557))
                return false;
            

            if (quest != null && quest.status == QuestStatus.Accepted)
            {
                try
                {
                    host.movementModule.disableMounting = true;
                    host.StandFromMount();
                    if (quest.steps[1] == 0)
                    {
                        if (!host.movementModule.GpsMove("Quest_806_1")) return false;
                        Thread.Sleep(1000);
                        host.farmModule.UseDoodadSkill(13911, host.getNearestDoodad(1437), true);
                        Thread.Sleep(1000);
                    }
                    if (quest.steps[0] == 0)
                    {
                        if (!host.movementModule.GpsMove("Quest_806_2")) return false;
                        Thread.Sleep(1000);
                        var d = host.getNearestDoodad(2542);
                        if (d != null && host.dist(d) < 2)
                        {
                            host.farmModule.UseDoodadSkill(13911, d, true);
                            Thread.Sleep(1000);
                        }
                    }
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
                    host.movementModule.disableMounting = true;
                    host.StandFromMount();
                    if (!host.movementModule.GpsMove("SigningLand_Siu")) return false;
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
