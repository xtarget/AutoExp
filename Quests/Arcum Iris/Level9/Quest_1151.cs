using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ArcheBuddy.Bot.Classes;

namespace AutoExp.Quests
{
    internal class Quest_1151 : Quest
    {
        public Quest_1151(int minLvl, int maxLvl, QuestRace race, uint[] reqQuests)
            : base(1151, minLvl, maxLvl, race, reqQuests)
        { }

        public override bool RunQuest(Host host)
        {
            if (!base.RunQuest(host))
                return false;
           
            if (getQuest() == null)
            {
                if (!host.movementModule.GpsMove("Arcum_Kiki"))
                    return false;
                host.StartQuest(id);
                Thread.Sleep(1000);
            }

            if (!checkQuestCompletedOrPerfomed(3516))
                return false;

            ArcheBuddy.Bot.Classes.Quest quest = getQuest();

            if (quest != null && quest.status == ArcheBuddy.Bot.Classes.QuestStatus.Performed)
            {
                if (!host.movementModule.GpsMove("Arcum_Maran"))
                    return false;
                CompleteQuestWithSecondaryWeaponSelect();
                Thread.Sleep(1000);
            }

            return true;
        }
    }
}
