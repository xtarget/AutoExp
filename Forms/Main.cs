using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoExp.Forms
{
    public partial class Main : Form
    {
        private Host host;
        public Main()
        {
            InitializeComponent();
        }

        public void SetHost(Host host)
        {
            this.host = host;
        }

        public void SetQuestModuleText(string text)
        {
            if (questModuleLabel.InvokeRequired)
                questModuleLabel.Invoke(new Action(() => { questModuleLabel.Text = "Q: " + text; }));
            else
                questModuleLabel.Text = "Q: " + text;
        }

        public void SetMovementModuleText(string text)
        {
            if (movementModuleLabel.InvokeRequired)
                movementModuleLabel.Invoke(new Action(() => { movementModuleLabel.Text = "M: " + text; }));
            else
                movementModuleLabel.Text = "M: " + text;
        }

        public void SetFarmModuleText(string text)
        {
            if (farmModuleLabel.InvokeRequired)
                farmModuleLabel.Invoke(new Action(() => { farmModuleLabel.Text = "F: " + text; }));
            else
                farmModuleLabel.Text = "F: " + text;
        }

        public void SetBestMobText(string text)
        {
            if (labelBestMob.InvokeRequired)
                labelBestMob.Invoke(new Action(() => { labelBestMob.Text = "BestMob: " + text; }));
            else
                labelBestMob.Text = "F: " + text;
        }

        public void SetBestDoodadText(string text)
        {
            if (labelBestDoodad.InvokeRequired)
                labelBestDoodad.Invoke(new Action(() => { labelBestDoodad.Text = "BestDoodad: " + text; }));
            else
                labelBestDoodad.Text = "F: " + text;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var settingsForm = new Settings(host, false);
            if (settingsForm.ShowDialog() == DialogResult.OK)
            {
                host.ApplySettings();
                host.commonModule.InitSkillSets();
                host.commonModule.InitEquipConfig();
            }
        }

        private void movementModuleLabel_Click(object sender, EventArgs e)
        {

        }
    }
}
