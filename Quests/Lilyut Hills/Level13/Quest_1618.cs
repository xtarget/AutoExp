using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ArcheBuddy.Bot.Classes;

namespace AutoExp.Quests
{
    internal class Quest_1618 : Quest
    {
        public Quest_1618(int minLvl, int maxLvl, QuestRace race, uint[] reqQuests)
            : base(1618, minLvl, maxLvl, race, reqQuests)
        { }

        public override bool RunQuest(Host host)
        {
            if (!base.RunQuest(host))
                return false;

            if (getQuest() == null)
            {
                if (!host.movementModule.GpsMove("Liliot_Kranog"))
                    return false;
                host.StartQuest(id);
                Thread.Sleep(1000);
            }

            if (!checkQuestCompleted(1593) && !checkQuestCompletedOrAccepted(1593))
                return false;

            ArcheBuddy.Bot.Classes.Quest quest = getQuest();

            if (quest != null && quest.status == QuestStatus.Accepted)
            {
                if (host.itemCount(24362) == 0)
                {
                    if (!host.movementModule.GpsMove("Liliot_Kranog")) return false;
                    Thread.Sleep(1000);
                    host.farmModule.UseDoodadSkill(18546, host.getNearestDoodad(3656), true);
                    Thread.Sleep(1000);
                    host.farmModule.UseDoodadSkill(12478, host.getNearestDoodad(3658), true);
                    Thread.Sleep(1000);
                }
                if (host.itemCount(24362) > 0)
                {
                    if (!host.movementModule.GpsMove("Quest_1593_1")) return false;
                    Thread.Sleep(1000);
                    var d = host.getNearestDoodad(3654);
                    if (d != null && host.dist(d) < 10)
                    {
                        host.Equip(24362);
                        Thread.Sleep(1200);
                        host.farmModule.UseDoodadSkill(12477, d, true);
                        Thread.Sleep(4000);
                        host.MoveTo(12831.54, 16348.31, 364.45);
                        host.commonModule.EquipBestArmorAndWeapon();
                    }

                    if (!host.movementModule.GpsMove("Quest_1618_1")) return false;
                    Thread.Sleep(1000);
                    host.MoveTo(12748.69, 16318.21, 329.27);
                    
                    while (host.isAlive() && host.me.Z < 359)
                        Thread.Sleep(100);
                    host.movementModule.GpsMove("Quest_1618_2");
                    Thread.Sleep(2000);
                    while (host.farmModule.readyToActions && host.isAlive() && quest.status == QuestStatus.Accepted)
                    {
                        host.farmModule.UseDoodadSkill(12476, host.getNearestDoodad(3652), true);
                        Thread.Sleep(1000);
                    }
                    if (!host.movementModule.GpsMove("Quest_1618_3")) return false;
                    host.MoveTo(12757.94, 16321.22, 335.87);
                    while (host.isAlive() && host.me.Z > 337)
                        Thread.Sleep(100);
                    if (!host.movementModule.GpsMove("Quest_1618_4")) return false;
                    Thread.Sleep(1000);
                    d = host.getNearestDoodad(3654);
                    if (d != null && host.dist(d) < 25)
                    {
                        host.Equip(24362);
                        Thread.Sleep(1200);
                        host.farmModule.UseDoodadSkill(12477, d, true, 5);
                        Thread.Sleep(4000);
                        host.MoveTo(12843.87, 16314.35, 367.96);
                        host.commonModule.EquipBestArmorAndWeapon();
                    }
                }
            }

            if (quest != null && quest.status == QuestStatus.Performed)
            {
                if (!host.movementModule.GpsMove("Liliot_Saimon")) return false;
                Thread.Sleep(1000);
                host.CompleteQuest(id);
                Thread.Sleep(1000);
            }

            return true;
        }
    }
}
