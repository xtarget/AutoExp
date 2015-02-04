namespace AutoExp.Forms
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.farmModuleLabel = new System.Windows.Forms.Label();
            this.questModuleLabel = new System.Windows.Forms.Label();
            this.movementModuleLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.labelBestMob = new System.Windows.Forms.Label();
            this.labelBestDoodad = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // farmModuleLabel
            // 
            this.farmModuleLabel.AutoSize = true;
            this.farmModuleLabel.Location = new System.Drawing.Point(12, 37);
            this.farmModuleLabel.Name = "farmModuleLabel";
            this.farmModuleLabel.Size = new System.Drawing.Size(33, 13);
            this.farmModuleLabel.TabIndex = 1;
            this.farmModuleLabel.Text = "Farm:";
            // 
            // questModuleLabel
            // 
            this.questModuleLabel.AutoSize = true;
            this.questModuleLabel.Location = new System.Drawing.Point(12, 53);
            this.questModuleLabel.Name = "questModuleLabel";
            this.questModuleLabel.Size = new System.Drawing.Size(38, 13);
            this.questModuleLabel.TabIndex = 3;
            this.questModuleLabel.Text = "Quest:";
            // 
            // movementModuleLabel
            // 
            this.movementModuleLabel.AutoSize = true;
            this.movementModuleLabel.Location = new System.Drawing.Point(12, 69);
            this.movementModuleLabel.Name = "movementModuleLabel";
            this.movementModuleLabel.Size = new System.Drawing.Size(60, 13);
            this.movementModuleLabel.TabIndex = 4;
            this.movementModuleLabel.Text = "Movement:";
            this.movementModuleLabel.Click += new System.EventHandler(this.movementModuleLabel_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 130);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(284, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Thanks to everyone for the donations that you have made!";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 145);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(127, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "It is very important for me.";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(320, 24);
            this.menuStrip1.TabIndex = 8;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(58, 20);
            this.settingsToolStripMenuItem.Text = "Settings";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
            // 
            // labelBestMob
            // 
            this.labelBestMob.AutoSize = true;
            this.labelBestMob.Location = new System.Drawing.Point(12, 85);
            this.labelBestMob.Name = "labelBestMob";
            this.labelBestMob.Size = new System.Drawing.Size(71, 13);
            this.labelBestMob.TabIndex = 9;
            this.labelBestMob.Text = "BestMob: null";
            // 
            // labelBestDoodad
            // 
            this.labelBestDoodad.AutoSize = true;
            this.labelBestDoodad.Location = new System.Drawing.Point(12, 101);
            this.labelBestDoodad.Name = "labelBestDoodad";
            this.labelBestDoodad.Size = new System.Drawing.Size(88, 13);
            this.labelBestDoodad.TabIndex = 10;
            this.labelBestDoodad.Text = "BestDoodad: null";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(320, 162);
            this.Controls.Add(this.labelBestDoodad);
            this.Controls.Add(this.labelBestMob);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.movementModuleLabel);
            this.Controls.Add(this.questModuleLabel);
            this.Controls.Add(this.farmModuleLabel);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Main";
            this.Text = "AutoExp v0.7";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label farmModuleLabel;
        private System.Windows.Forms.Label questModuleLabel;
        private System.Windows.Forms.Label movementModuleLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.Label labelBestMob;
        private System.Windows.Forms.Label labelBestDoodad;
    }
}