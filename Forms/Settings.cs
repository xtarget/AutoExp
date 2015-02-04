using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace AutoExp.Forms
{
    public partial class Settings : Form
    {
        private Dictionary<string, int> abilities = new Dictionary<string, int>();
        internal Host host;
        private string cfgName = "";
        private XmlDocument doc;
        private bool createNewSettings;
        public CharacterSettings characterSettings;
        public Settings(Host host, bool createNewSettings)
        {
            try
            {
                InitializeComponent();
                abilities.Add("Battlerage", 1);
                abilities.Add("Witchcraft", 2);
                abilities.Add("Defense", 3);
                abilities.Add("Auramancy", 4);
                abilities.Add("Occultism", 5);
                abilities.Add("Archery", 6);
                abilities.Add("Sorcery", 7);
                abilities.Add("Shadowplay", 8);
                abilities.Add("Songcraft", 9);
                abilities.Add("Vitalism", 10);
                for (int i = 0; i < 10; i++)
                {
                    skillset1.Items.Add(abilities.Keys.ElementAt(i));
                    skillset2.Items.Add(abilities.Keys.ElementAt(i));
                    skillset3.Items.Add(abilities.Keys.ElementAt(i));
                }
                this.host = host;
                this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
                cfgName = Host.AssemblyDirectory + "\\Configs\\" + host.me.name + "[" + host.serverName() + "_" + host.me.uniqId + "].xml";

                this.createNewSettings = createNewSettings;


                if (!createNewSettings)
                {
                    checkBox7.Checked = host.characterSettings.overachieveQuests;
                    checkBox6.Checked = host.characterSettings.autoRaidRadiusInvite;
                    checkBox5.Checked = host.characterSettings.autoRestoreExp;
                    checkBox4.Checked = host.characterSettings.rideOnMount;
                    checkBox3.Checked = host.characterSettings.autoUseMount;
                    checkBox2.Checked = host.characterSettings.autoDisenchant;
                    checkBox1.Checked = host.characterSettings.autoOpenCoinpurses;
                    comboBox1.SelectedIndex = host.characterSettings.armorSet;
                    comboBox2.SelectedIndex = host.characterSettings.weaponPriority;
                    skillset1.SelectedItem = abilities.Keys.ElementAt(host.characterSettings.skillset1 - 1);
                    skillset2.SelectedItem = abilities.Keys.ElementAt(host.characterSettings.skillset2 - 1);
                    skillset3.SelectedItem = abilities.Keys.ElementAt(host.characterSettings.skillset3 - 1);
                    comboBox3.SelectedItem = host.characterSettings.expTill.ToString();
                }
                var myAbilities = host.getAbilities();
                if (myAbilities.Count > 0)
                {
                    skillset1.SelectedItem = abilities.Keys.ElementAt((int)myAbilities[0].id - 1);
                    skillset1.Enabled = false;
                    skillset2.Items.Remove(skillset1.SelectedItem);
                    skillset3.Items.Remove(skillset1.SelectedItem);
                }
                if (myAbilities.Count > 1)
                {
                    skillset2.SelectedItem = abilities.Keys.ElementAt((int)myAbilities[1].id - 1);
                    skillset2.Enabled = false;
                    skillset3.Items.Remove(skillset1.SelectedItem);
                }
                if (myAbilities.Count > 2)
                {
                    skillset3.SelectedItem = abilities.Keys.ElementAt((int)myAbilities[2].id - 1);
                    skillset3.Enabled = false;
                }

                

                skillset2.SelectedIndexChanged += skillset2_SelectedIndexChanged;
                skillset3.SelectedIndexChanged += skillset3_SelectedIndexChanged;
            }
            catch (Exception error)
            {
                Console.WriteLine(error.ToString());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (skillset1.SelectedIndex < 0 || skillset2.SelectedIndex < 0 || skillset3.SelectedIndex < 0 || comboBox1.SelectedIndex < 0 || comboBox2.SelectedIndex < 0)
                return;
            try
            {
                characterSettings = new CharacterSettings();
                characterSettings.skillset1 = abilities[skillset1.SelectedItem.ToString()];
                characterSettings.skillset2 = abilities[skillset2.SelectedItem.ToString()];
                characterSettings.skillset3 = abilities[skillset3.SelectedItem.ToString()];
                characterSettings.weaponPriority = comboBox2.SelectedIndex;
                characterSettings.armorSet = comboBox1.SelectedIndex;
                characterSettings.autoDisenchant = checkBox2.Checked;
                characterSettings.autoUseMount = checkBox3.Checked;
                characterSettings.rideOnMount = checkBox4.Checked;
                characterSettings.autoRestoreExp = checkBox5.Checked;
                characterSettings.autoRaidRadiusInvite = checkBox6.Checked;
                characterSettings.overachieveQuests = checkBox7.Checked;

                int expTill = 50;
                if (comboBox3.SelectedItem != null)
                    Int32.TryParse(comboBox3.SelectedItem.ToString(), out expTill);
                characterSettings.expTill = expTill;
                characterSettings.autoOpenCoinpurses = checkBox1.Checked;
                System.Xml.Serialization.XmlSerializer writer = new System.Xml.Serialization.XmlSerializer(typeof(CharacterSettings));
                using (var fs = File.Open(cfgName, FileMode.Create, FileAccess.ReadWrite, FileShare.ReadWrite))
                {
                    writer.Serialize(fs, characterSettings);
                }
            }
            catch (Exception error)
            {
                Console.WriteLine(error.ToString());
            }

            doc = new XmlDocument();
            try
            {
                doc.Load(cfgName);
            }
            catch
            {
                this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
                return;
            }
            this.DialogResult = System.Windows.Forms.DialogResult.OK;

        }

        private void skillset2_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                skillset2.SelectedIndexChanged -= skillset2_SelectedIndexChanged;
                skillset3.SelectedIndexChanged -= skillset3_SelectedIndexChanged;
                var skillset3SelectedItem = skillset3.SelectedItem;
                skillset3.Items.Clear();
                for (int i = 0; i < 10; i++)
                {
                    skillset3.Items.Add(abilities.Keys.ElementAt(i));
                }
                if (skillset1.SelectedItem != null)
                    skillset3.Items.Remove(skillset1.SelectedItem);
                if (skillset2.SelectedItem != null)
                    skillset3.Items.Remove(skillset2.SelectedItem);
                skillset3.SelectedItem = skillset3SelectedItem;
                skillset2.SelectedIndexChanged += skillset2_SelectedIndexChanged;
                skillset3.SelectedIndexChanged += skillset3_SelectedIndexChanged;
            }
            catch (Exception error)
            {
                Console.WriteLine(error.ToString());
            }
        }

        private void skillset3_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                skillset2.SelectedIndexChanged -= skillset2_SelectedIndexChanged;
                skillset3.SelectedIndexChanged -= skillset3_SelectedIndexChanged;
                var skillset2SelectedItem = skillset2.SelectedItem;
                skillset2.Items.Clear();
                for (int i = 0; i < 10; i++)
                {
                    skillset2.Items.Add(abilities.Keys.ElementAt(i));
                }
                if (skillset1.SelectedItem != null)
                    skillset2.Items.Remove(skillset1.SelectedItem);
                if (skillset3.SelectedItem != null)
                    skillset2.Items.Remove(skillset3.SelectedItem);
                skillset2.SelectedItem = skillset2SelectedItem;
                skillset2.SelectedIndexChanged += skillset2_SelectedIndexChanged;
                skillset3.SelectedIndexChanged += skillset3_SelectedIndexChanged;
            }
            catch (Exception error)
            {
                Console.WriteLine(error.ToString());
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
