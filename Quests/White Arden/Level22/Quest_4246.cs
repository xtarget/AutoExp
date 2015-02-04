using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ArcheBuddy.Bot.Classes;

namespace AutoExp.Quests
{
    internal class Quest_4246 : Quest
    {
        public Quest_4246(int minLvl, int maxLvl, QuestRace race, uint[] reqQuests)
            : base(4246, minLvl, maxLvl, race, reqQuests)
        { }

        public override bool RunQuest(Host host)
        {
            if (!base.RunQuest(host))
                return false;

            if (getQuest() == null)
            {
                if (!host.movementModule.GpsMove("White_Kallahan"))
                    return false;
                host.StartQuest(id);
                Thread.Sleep(1000);
            }

            if (!checkQuestCompletedOrAccepted(4245))
                return false;

            ArcheBuddy.Bot.Classes.Quest quest = getQuest();

            if (quest != null && quest.status == QuestStatus.Accepted)
            {
                Zone zone = new RoundZone(9263.05, 13044.54, 65);
                if (!host.movementModule.GpsMove("Quest_4246_1"))
                    return false;

                host.farmModule.SetFarmAggros();
                while (host.farmModule.readyToActions && host.farmModule.farmState == Modules.FarmState.AttackOnlyAgro && quest.status == QuestStatus.Accepted)
                {
                    if (!host.me.inFight)
                    {
                        var d = host.getNearestDoodad(11184);
                        if (d != null && zone.ObjInZone(d))
                        {
                            host.ComeTo(d, 1);
                            Thread.Sleep(750);
                            if (host.isMounted())
                            {
                                host.StandFromMount();
                                while (host.me.isMoving)
                                    Thread.Sleep(100);
                                Thread.Sleep(250);
                            }
                            host.UseItem(23415, d.X, d.Y, d.Z);
                            Thread.Sleep(1000);
                        }
                    }
                    Thread.Sleep(100);
                }
                host.farmModule.StopFarm();
                Thread.Sleep(1000);
            }

            if (!checkQuestCompleted(4245))
                return false;

            if (quest != null && quest.status == QuestStatus.Performed)
            {
                if (!host.movementModule.GpsMove("White_Kallahan")) return false;
                Thread.Sleep(1000);
                host.CompleteQuest(id);
                Thread.Sleep(1000);
            }
             

            return true;
        }
    }
}
