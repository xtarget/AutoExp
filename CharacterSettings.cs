using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoExp
{
    [Serializable]
    public class CharacterSettings
    {
        public int skillset1;
        public int skillset2;
        public int skillset3;
        public bool autoDisenchant = true;
        public bool autoRestoreExp = true;
        public bool autoOpenCoinpurses = true;
        public bool autoUseMount = true;
        public bool rideOnMount = true;
        public bool autoRaidRadiusInvite = true;
        public bool overachieveQuests = true;
        public int expTill = 50;
        public int weaponPriority;
        public int armorSet;
    }
}
