using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ArcheBuddy.Bot.Classes;

namespace AutoExp.Quests
{
    internal class Quest_1182 : Quest
    {
        public Quest_1182(int minLvl, int maxLvl, QuestRace race, uint[] reqQuests)
            : base(1182, minLvl, maxLvl, race, reqQuests)
        { }

        public override bool RunQuest(Host host)
        {
            if (!base.RunQuest(host))
                return false;

            if (getQuest() == null)
            {
                if (!host.movementModule.GpsMove("Arcum_Yamani"))
                    return false;
                host.StartQuest(id);
                Thread.Sleep(1000);
            }

            ArcheBuddy.Bot.Classes.Quest quest = getQuest();

            if (quest != null && quest.status == QuestStatus.Accepted)
            {
                if (!host.movementModule.GpsMove("Arcum_PlantFarm_1")) return false;
                RoundZone zone = new RoundZone(host.me.X, host.me.Y, 10);
                while (zone.ObjInZone(host.me) && host.itemCount(15694) < 3 && host.me.isAlive())
                {
                    host.farmModule.UseDoodadSkill(13154, host.getNearestDoodad(7345), true);
                    Thread.Sleep(1000);
                }

                if (host.itemCount(23686) > 0)
                {
                    host.PlantItemsInZone(23686, zone, 1);
                    Thread.Sleep(2000);
                }

                var myPet = getMyDoodadById(12893);
                if (myPet != null)
                {
                    if (host.dist(myPet) > 2)
                        host.ComeTo(myPet, 1, 1);
                    host.farmModule.UseDoodadSkill(18035, myPet, true);
                    Thread.Sleep(2000);
                }

                myPet = getMyDoodadById(12894);
                if (myPet != null)
                {
                    if (host.dist(myPet) > 2)
                        host.ComeTo(myPet, 1, 1);
                    host.farmModule.UseDoodadSkill(25961, myPet, true);
                    Thread.Sleep(32000);
                }

                myPet = getMyDoodadById(12898);
                if (myPet != null)
                {
                    if (host.dist(myPet) > 2)
                        host.ComeTo(myPet, 1, 1);
                    host.farmModule.UseDoodadSkill(18037, myPet, true);
                    Thread.Sleep(2000);
                }

                myPet = getMyDoodadById(12899);
                if (myPet != null)
                {
                    if (host.dist(myPet) > 2)
                        host.ComeTo(myPet, 1, 1);
                    host.farmModule.UseDoodadSkill(25962, myPet, true);
                    Thread.Sleep(32000);
                }

                myPet = getMyDoodadById(12903);
                if (myPet != null)
                {
                    if (host.dist(myPet) > 2)
                        host.ComeTo(myPet, 1, 1);
                    host.farmModule.UseDoodadSkill(17355, myPet, true);
                    Thread.Sleep(15000);
                }

                myPet = getMyDoodadById(12906);
                if (myPet != null)
                {
                    if (host.dist(myPet) > 2)
                        host.ComeTo(myPet, 1, 1);
                    host.farmModule.UseDoodadSkill(17387, myPet, true);
                    Thread.Sleep(3000);
                }
            }

            if (quest != null && quest.status == ArcheBuddy.Bot.Classes.QuestStatus.Performed)
            {
                if (!host.movementModule.GpsMove("Arcum_Yamani"))
                    return false;
                host.CompleteQuest(id);
                Thread.Sleep(1000);
            }

            return true;
        }
    }
}
