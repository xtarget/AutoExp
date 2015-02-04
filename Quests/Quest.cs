using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArcheBuddy.Bot.Classes;

namespace AutoExp.Quests
{
    [Flags]
    enum QuestRace
    { 
        Nuian = 1,
        Elf = 2,
        Ferre = 4,
        Hariharan = 8,
        All = 15
    }

    internal class Quest
    {
        public uint id = 0;
        protected int minLvl = 0;
        protected int maxLvl = 0;
        protected QuestRace race = QuestRace.All;
        protected uint[] reqQuests = new uint[0];
        protected uint[] reqUncompleteQuests = null;
        protected Host host;
        protected string name;

        public Quest(uint id, int minLvl, int maxLvl, QuestRace race, uint[] reqQuests, uint[] reqUncompleteQuests = null)
        {
            this.id = id;
            this.minLvl = minLvl;
            this.maxLvl = maxLvl;
            this.race = race;
            this.reqQuests = reqQuests;
            this.reqUncompleteQuests = reqUncompleteQuests;
            name = "";
        }

        public void CompleteQuestWithPrimaryWeaponSelect()
        {
            //1 = 1h Sword
            //2 = 2h Sword
            //3 = 2h Mage staff
            if (host.characterSettings.weaponPriority == 0)
                host.CompleteQuest(id, 3); 
            if (host.characterSettings.weaponPriority == 1)
                host.CompleteQuest(id, 1);
            if (host.characterSettings.weaponPriority == 2)
                host.CompleteQuest(id, 1);
        }

        

        public void CompleteQuestWithSecondaryWeaponSelect()
        {
            /*
             2249 - Solrid+
             1584 - Liliot+
             44 - Stone+
             111 - White+
             13 - Merianhold+
             609 - TwoCrown+
             520 - Star+

             1151 - Arcum+
             2533 - Ferre+
             1051 - Tiger+
             2124 - Mahadevi+
             1667 - Headlands+
             798 - Singland+
             1306 - OldForest+
             2272 - Inistra+
             */


            //1 = Bow
            //2 = Shield
            //3 = Lute
            //4 = Heal 2h Blunt (only europe)
            if (host.clientVersion == ClientVersion.RussiaMailRu)
            {
                if (host.characterSettings.weaponPriority == 0)
                    host.CompleteQuest(id, 1);
                if (host.characterSettings.weaponPriority == 1)
                    host.CompleteQuest(id, 1);
                if (host.characterSettings.weaponPriority == 2)
                    host.CompleteQuest(id, 2);
            }
            else
            {
                if (host.characterSettings.weaponPriority == 0) //Mage
                    host.CompleteQuest(id, 1);
                if (host.isAbilityTaken(Ability.Vitalism))
                {
                    if (id == 1584 || id == 1051 || id == 111 || id == 1667 || id == 609 || id == 1306)
                    {
                        //Тут берем лук
                        if (host.characterSettings.weaponPriority == 1)
                            host.CompleteQuest(id, 1);
                        if (host.characterSettings.weaponPriority == 2)
                            host.CompleteQuest(id, 1);
                    }
                    if (id == 2249 || id == 1151 || id == 2533 || id == 44 || id == 2124 || id == 13 || id == 798 || id == 2272 || id == 520)
                    {
                        //Тут берем двуручный хил блант
                        if (host.characterSettings.weaponPriority == 1)
                            host.CompleteQuest(id, 4);
                        if (host.characterSettings.weaponPriority == 2)
                            host.CompleteQuest(id, 4);
                    }
                }
                else
                {
                    if (host.characterSettings.weaponPriority == 1)
                        host.CompleteQuest(id, 1);
                    if (host.characterSettings.weaponPriority == 2)
                        host.CompleteQuest(id, 2);
                }
            }
        }

        public void CompleteQuestWithArmorSelect()
        {
            if (id == 1136 || id == 2246 || id == 2248 || id == 300 || id == 1367 || id == 1696 || id == 6353 || id == 4742 || id == 1142)
            {
                if (host.characterSettings.armorSet == 0)
                    host.CompleteQuest(id, 2);
                if (host.characterSettings.armorSet == 1)
                    host.CompleteQuest(id, 2);
                if (host.characterSettings.armorSet == 2)
                    host.CompleteQuest(id, 1);
            }
            else
            {
                if (host.characterSettings.armorSet == 0)
                    host.CompleteQuest(id, 3);
                if (host.characterSettings.armorSet == 1)
                    host.CompleteQuest(id, 2);
                if (host.characterSettings.armorSet == 2)
                    host.CompleteQuest(id, 1);
            }
        }

        public virtual bool RunQuest(Host host)
        {
            this.host = host;

            //if (host.me.level < minLvl || host.me.level > maxLvl)
                //return false;
            if (host.characterSettings.expTill <= host.me.level)
                return false;
            if (host.getCompletedQuest(id) != null) //already done
            {
                host.questModule.questsCanBeRun.Remove(this);
                return false;
            }
            if (host.me.charRace == ArcheBuddy.Bot.Classes.CharRace.Nuian && (race & QuestRace.Nuian) != QuestRace.Nuian )
            {
                host.questModule.questsCanBeRun.Remove(this);
                return false;
            }
            if (host.me.charRace == ArcheBuddy.Bot.Classes.CharRace.Elf && (race & QuestRace.Elf) != QuestRace.Elf)
            {
                host.questModule.questsCanBeRun.Remove(this);
                return false;
            }
            if (host.me.charRace == ArcheBuddy.Bot.Classes.CharRace.Ferre && (race & QuestRace.Ferre) != QuestRace.Ferre)
            {
                host.questModule.questsCanBeRun.Remove(this);
                return false;
            }
            if (host.me.charRace == ArcheBuddy.Bot.Classes.CharRace.Hariharan && (race & QuestRace.Hariharan) != QuestRace.Hariharan)
            {
                host.questModule.questsCanBeRun.Remove(this);
                return false;
            }
            if (reqUncompleteQuests != null)
            {
                for (int i = 0; i < reqUncompleteQuests.Length; i++)
                {
                    if (checkQuestCompleted(reqUncompleteQuests[i]))
                        return false;
                }
            }

            List<uint> reqQuestList = reqQuests.ToList();
            foreach (var q in host.getCompletedQuests())
            {
                if (q.id == id)
                    return false;
                if (reqQuestList.Contains(q.id))
                    reqQuestList.Remove(q.id);
            }
            if (reqQuestList.Count > 0)
                return false;

            if (host.sqlCore.sqlQuestContexts.ContainsKey(id))
                host.mainForm.SetQuestModuleText(host.sqlCore.sqlQuestContexts[id].name + "[" + id + "]");
            return true;
        }

        protected ArcheBuddy.Bot.Classes.Quest getQuest()
        {
            return host.getQuest(id);
        }

        protected ArcheBuddy.Bot.Classes.Quest getQuest(uint id)
        {
            return host.getQuest(id);
        }

        protected bool checkQuestCompleted(uint id)
        {
            return host.getCompletedQuest(id) != null;
        }

        protected bool checkQuestAccepted(uint id)
        {
            return host.getQuest(id) != null && host.getQuest(id).status == QuestStatus.Accepted;
        }

        protected bool checkQuestCompletedOrAccepted(uint id)
        {
            return (host.getCompletedQuest(id) != null || host.getQuest(id) != null);
        }

        protected bool checkQuestCompletedOrPerfomed(uint id)
        {
            var q = host.getQuest(id);
            return (host.getCompletedQuest(id) != null || (q != null && q.status == QuestStatus.Performed));
        }

        public bool CheckWeCanContinueFarmQuest(uint id)
        {
            var q = host.getQuest(id);
            if (!host.characterSettings.overachieveQuests)
                return q.status == QuestStatus.Accepted;
            if (!q.db.letItDone)
                return q.status == QuestStatus.Accepted;
            bool result = true;
            int i = 0;
            if (q.db.score == 0)
            {
                bool allStepsDone = true;
                foreach (var c in q.db.components)
                {
                    if (c.kindId == 4)
                    {
                        uint maxQStep = 0;
                        foreach (var a in c.actsObjMonsterGroupHunt)
                        {
                            if (a.count > maxQStep)
                                maxQStep = a.count;
                        }
                        foreach (var a in c.actsObjMonsterHunt)
                        {
                            if (a.count > maxQStep)
                                maxQStep = a.count;
                        }
                        foreach (var a in c.actsObjItemGroupGather)
                        {
                            if (a.count > maxQStep)
                                maxQStep = a.count;
                        }
                        foreach (var a in c.actsObjItemGather)
                        {
                            if (a.count > maxQStep)
                                maxQStep = a.count;
                        }
                        if (q.steps[i] < (Math.Ceiling(maxQStep * 1.5)))
                            allStepsDone = false;
                        i++;
                    }
                }
                if (allStepsDone)
                    result = false;
                else
                    result = true;
            }
            if (q.db.score > 0)
            {
                uint curScore = 0;
                foreach (var c in q.db.components)
                {
                    if (c.kindId == 4)
                    {
                        foreach (var a in c.actsObjMonsterGroupHunt)
                        {
                            curScore += (uint)(q.steps[i] * a.count);
                        }
                        foreach (var a in c.actsObjMonsterHunt)
                        {
                            curScore += (uint)(q.steps[i] * a.count);
                        }
                        foreach (var a in c.actsObjItemGroupGather)
                        {
                            curScore += (uint)(q.steps[i] * a.count);
                        }
                        foreach (var a in c.actsObjItemGather)
                        {
                            curScore += (uint)(q.steps[i] * a.count);
                        }
                        i++;
                    }
                }
                result = curScore < (Math.Ceiling(q.db.score * 1.5));
            }
            return result;
        }

        protected DoodadObject getMyDoodadById(uint id)
        {
            double dist = 999999;
            DoodadObject doodad = null;
            foreach (var d in host.getDoodads())
            {
                if (d.uniqOwnerId == host.me.uniqId && host.me.dist(d) < dist && d.dbFuncGroup.id == id)
                {
                    dist = host.me.dist(d);
                    doodad = d;
                }
            }
            if (doodad != null)
            {
                return doodad;
            }
            return null;
        }
    }
}
