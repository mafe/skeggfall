namespace SkeggFallLevelDesigner
{
    partial class Form1
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.Main_Panel = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.dateiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.optionenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kartengrößeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.klein600X300ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mittel900X600ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groß1200X900ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.debugToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.stopToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.invalidateclearToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.neuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.beendenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Main_Panel.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Main_Panel
            // 
            this.Main_Panel.AccessibleRole = System.Windows.Forms.AccessibleRole.Application;
            this.Main_Panel.AutoSize = true;
            this.Main_Panel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Main_Panel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Main_Panel.Controls.Add(this.label1);
            this.Main_Panel.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.Main_Panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Main_Panel.Location = new System.Drawing.Point(0, 0);
            this.Main_Panel.Name = "Main_Panel";
            this.Main_Panel.Padding = new System.Windows.Forms.Padding(0, 25, 0, 0);
            this.Main_Panel.Size = new System.Drawing.Size(537, 395);
            this.Main_Panel.TabIndex = 1;
            this.Main_Panel.Paint += new System.Windows.Forms.PaintEventHandler(this.Main_Panel_Paint);
            this.Main_Panel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Main_Panel_MouseDown);
            this.Main_Panel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Main_Panel_MouseMove);
            this.Main_Panel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Main_Panel_MouseUp);
            this.Main_Panel.Move += new System.EventHandler(this.Main_Panel_Move);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 372);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "label1";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dateiToolStripMenuItem,
            this.optionenToolStripMenuItem,
            this.debugToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(537, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // dateiToolStripMenuItem
            // 
            this.dateiToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.neuToolStripMenuItem,
            this.loadToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.beendenToolStripMenuItem});
            this.dateiToolStripMenuItem.Name = "dateiToolStripMenuItem";
            this.dateiToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.dateiToolStripMenuItem.Text = "Datei";
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.loadToolStripMenuItem.Text = "Laden";
            this.loadToolStripMenuItem.Click += new System.EventHandler(this.loadToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.saveToolStripMenuItem.Text = "Speichern";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // optionenToolStripMenuItem
            // 
            this.optionenToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.kartengrößeToolStripMenuItem});
            this.optionenToolStripMenuItem.Name = "optionenToolStripMenuItem";
            this.optionenToolStripMenuItem.Size = new System.Drawing.Size(69, 20);
            this.optionenToolStripMenuItem.Text = "Optionen";
            // 
            // kartengrößeToolStripMenuItem
            // 
            this.kartengrößeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.klein600X300ToolStripMenuItem,
            this.mittel900X600ToolStripMenuItem,
            this.groß1200X900ToolStripMenuItem});
            this.kartengrößeToolStripMenuItem.Name = "kartengrößeToolStripMenuItem";
            this.kartengrößeToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.kartengrößeToolStripMenuItem.Text = "Kartengröße";
            // 
            // klein600X300ToolStripMenuItem
            // 
            this.klein600X300ToolStripMenuItem.Name = "klein600X300ToolStripMenuItem";
            this.klein600X300ToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.klein600X300ToolStripMenuItem.Text = "Klein     (600 x 300)";
            this.klein600X300ToolStripMenuItem.Click += new System.EventHandler(this.klein600X300ToolStripMenuItem_Click);
            // 
            // mittel900X600ToolStripMenuItem
            // 
            this.mittel900X600ToolStripMenuItem.Checked = true;
            this.mittel900X600ToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.mittel900X600ToolStripMenuItem.Name = "mittel900X600ToolStripMenuItem";
            this.mittel900X600ToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.mittel900X600ToolStripMenuItem.Text = "Mittel   (900 x 600)";
            this.mittel900X600ToolStripMenuItem.Click += new System.EventHandler(this.mittel900X600ToolStripMenuItem_Click);
            // 
            // groß1200X900ToolStripMenuItem
            // 
            this.groß1200X900ToolStripMenuItem.Name = "groß1200X900ToolStripMenuItem";
            this.groß1200X900ToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.groß1200X900ToolStripMenuItem.Text = "Groß   (1200 x 900)";
            this.groß1200X900ToolStripMenuItem.Click += new System.EventHandler(this.groß1200X900ToolStripMenuItem_Click);
            // 
            // debugToolStripMenuItem
            // 
            this.debugToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startToolStripMenuItem1,
            this.stopToolStripMenuItem1,
            this.invalidateclearToolStripMenuItem1});
            this.debugToolStripMenuItem.Name = "debugToolStripMenuItem";
            this.debugToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
            this.debugToolStripMenuItem.Text = "Debug";
            // 
            // startToolStripMenuItem1
            // 
            this.startToolStripMenuItem1.Name = "startToolStripMenuItem1";
            this.startToolStripMenuItem1.Size = new System.Drawing.Size(158, 22);
            this.startToolStripMenuItem1.Text = "Start";
            this.startToolStripMenuItem1.Click += new System.EventHandler(this.startToolStripMenuItem1_Click);
            // 
            // stopToolStripMenuItem1
            // 
            this.stopToolStripMenuItem1.Name = "stopToolStripMenuItem1";
            this.stopToolStripMenuItem1.Size = new System.Drawing.Size(158, 22);
            this.stopToolStripMenuItem1.Text = "Stop";
            this.stopToolStripMenuItem1.Click += new System.EventHandler(this.stopToolStripMenuItem1_Click);
            // 
            // invalidateclearToolStripMenuItem1
            // 
            this.invalidateclearToolStripMenuItem1.Name = "invalidateclearToolStripMenuItem1";
            this.invalidateclearToolStripMenuItem1.Size = new System.Drawing.Size(158, 22);
            this.invalidateclearToolStripMenuItem1.Text = "Invalidate(clear)";
            this.invalidateclearToolStripMenuItem1.Click += new System.EventHandler(this.invalidateclearToolStripMenuItem1_Click);
            // 
            // neuToolStripMenuItem
            // 
            this.neuToolStripMenuItem.Name = "neuToolStripMenuItem";
            this.neuToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.neuToolStripMenuItem.Text = "Neu";
            this.neuToolStripMenuItem.Click += new System.EventHandler(this.neuToolStripMenuItem_Click);
            // 
            // beendenToolStripMenuItem
            // 
            this.beendenToolStripMenuItem.Name = "beendenToolStripMenuItem";
            this.beendenToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.beendenToolStripMenuItem.Text = "Beenden";
            this.beendenToolStripMenuItem.Click += new System.EventHandler(this.beendenToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(537, 395);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.Main_Panel);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "SkeggFall - Leveleditor";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Main_Panel.ResumeLayout(false);
            this.Main_Panel.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel Main_Panel;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem dateiToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ToolStripMenuItem optionenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kartengrößeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem klein600X300ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mittel900X600ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem groß1200X900ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem debugToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem startToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem stopToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem invalidateclearToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem neuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem beendenToolStripMenuItem;
    }
}

