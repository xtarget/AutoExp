using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ArcheBuddy.Bot.Classes;

namespace AutoExp.Quests
{
    internal class Quest_131 : Quest
    {
        public Quest_131(int minLvl, int maxLvl, QuestRace race, uint[] reqQuests)
            : base(131, minLvl, maxLvl, race, reqQuests)
        { }

        public void FarmSkeleta(string gpsPointName)
        {
            if (getQuest().status == QuestStatus.Accepted && host.isAlive())
            {
                if (!host.movementModule.GpsMove(gpsPointName)) return;
                Thread.Sleep(1000);
                var d = host.getNearestDoodad(880);
                if (d != null && host.dist(d) < 6)
                    host.farmModule.UseDoodadSkill(13121, d, true);
            }
        }

        public override bool RunQuest(Host host)
        {
            if (!base.RunQuest(host))
                return false;

            if (getQuest() == null)
            {
                if (!host.movementModule.GpsMove("White_Alana"))
                    return false;
                host.StartQuest(id);
                Thread.Sleep(1000);
            }

            if (!checkQuestCompletedOrPerfomed(132))
                return false;

            ArcheBuddy.Bot.Classes.Quest quest = getQuest();

            if (quest != null && quest.status == QuestStatus.Accepted)
            {
                FarmSkeleta("Quest_131_1");
                FarmSkeleta("Quest_131_2");
                FarmSkeleta("Quest_131_3");
                FarmSkeleta("Quest_131_4");
                FarmSkeleta("Quest_131_5");
                FarmSkeleta("Quest_131_10");
                FarmSkeleta("Quest_131_6");
                FarmSkeleta("Quest_131_7");
                FarmSkeleta("Quest_131_11");
                FarmSkeleta("Quest_131_8");
                FarmSkeleta("Quest_131_9");
                FarmSkeleta("Quest_131_12");
                FarmSkeleta("Quest_131_13");
                FarmSkeleta("Quest_131_14");
                FarmSkeleta("Quest_131_15");
                FarmSkeleta("Quest_131_16");
                FarmSkeleta("Quest_131_17");
                FarmSkeleta("Quest_131_18");
                FarmSkeleta("Quest_131_19");
                FarmSkeleta("Quest_131_20");
                FarmSkeleta("Quest_131_21");
                FarmSkeleta("Quest_131_22");
                FarmSkeleta("Quest_131_23");
            }
            
            if (quest != null && quest.status == QuestStatus.Performed)
            {
                if (!host.movementModule.GpsMove("White_Alana")) return false;
                Thread.Sleep(1000);
                host.CompleteQuest(id);
                Thread.Sleep(1000);
            }
            
            
            return true;
        }
    }
}
