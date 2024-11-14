namespace ProiectContabilitate
{
    partial class Operatii_contabile
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
            this.components = new System.ComponentModel.Container();
            this.dgvConturi = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAfisareOperatiiContabile = new System.Windows.Forms.Button();
            this.btnConturi = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnSoldTotal = new System.Windows.Forms.Button();
            this.tbSoldTotal = new System.Windows.Forms.TextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolAfisareOperatiiContabile = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolCalculSoldTotal = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dgvConturi)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.contextMenuStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvConturi
            // 
            this.dgvConturi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvConturi.Location = new System.Drawing.Point(30, 92);
            this.dgvConturi.Name = "dgvConturi";
            this.dgvConturi.RowHeadersWidth = 51;
            this.dgvConturi.RowTemplate.Height = 24;
            this.dgvConturi.Size = new System.Drawing.Size(485, 250);
            this.dgvConturi.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(227, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Operatii contabile";
            // 
            // btnAfisareOperatiiContabile
            // 
            this.btnAfisareOperatiiContabile.Location = new System.Drawing.Point(177, 369);
            this.btnAfisareOperatiiContabile.Name = "btnAfisareOperatiiContabile";
            this.btnAfisareOperatiiContabile.Size = new System.Drawing.Size(175, 23);
            this.btnAfisareOperatiiContabile.TabIndex = 2;
            this.btnAfisareOperatiiContabile.Text = "Afisare operatii contabile!";
            this.btnAfisareOperatiiContabile.UseVisualStyleBackColor = true;
            this.btnAfisareOperatiiContabile.Click += new System.EventHandler(this.btnAfisareOperatiiContabile_Click);
            // 
            // btnConturi
            // 
            this.btnConturi.Location = new System.Drawing.Point(669, 415);
            this.btnConturi.Name = "btnConturi";
            this.btnConturi.Size = new System.Drawing.Size(119, 23);
            this.btnConturi.TabIndex = 3;
            this.btnConturi.Text = "Conturi";
            this.btnConturi.UseVisualStyleBackColor = true;
            this.btnConturi.Click += new System.EventHandler(this.btnConturi_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 28);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(46, 24);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // btnSoldTotal
            // 
            this.btnSoldTotal.Location = new System.Drawing.Point(596, 92);
            this.btnSoldTotal.Name = "btnSoldTotal";
            this.btnSoldTotal.Size = new System.Drawing.Size(143, 23);
            this.btnSoldTotal.TabIndex = 5;
            this.btnSoldTotal.Text = "Calcul sold total";
            this.btnSoldTotal.UseVisualStyleBackColor = true;
            this.btnSoldTotal.Click += new System.EventHandler(this.btnSoldTotal_Click);
            // 
            // tbSoldTotal
            // 
            this.tbSoldTotal.Location = new System.Drawing.Point(613, 150);
            this.tbSoldTotal.Name = "tbSoldTotal";
            this.tbSoldTotal.ReadOnly = true;
            this.tbSoldTotal.Size = new System.Drawing.Size(115, 22);
            this.tbSoldTotal.TabIndex = 6;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolAfisareOperatiiContabile});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(247, 28);
            // 
            // toolAfisareOperatiiContabile
            // 
            this.toolAfisareOperatiiContabile.Name = "toolAfisareOperatiiContabile";
            this.toolAfisareOperatiiContabile.Size = new System.Drawing.Size(246, 24);
            this.toolAfisareOperatiiContabile.Text = "Afisare operatii contabile";
            this.toolAfisareOperatiiContabile.Click += new System.EventHandler(this.toolAfisareOperatiiContabile_Click);
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolCalculSoldTotal});
            this.contextMenuStrip2.Name = "contextMenuStrip2";
            this.contextMenuStrip2.Size = new System.Drawing.Size(186, 28);
            this.contextMenuStrip2.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip2_Opening);
            // 
            // toolCalculSoldTotal
            // 
            this.toolCalculSoldTotal.Name = "toolCalculSoldTotal";
            this.toolCalculSoldTotal.Size = new System.Drawing.Size(185, 24);
            this.toolCalculSoldTotal.Text = "Calcul sold total";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // Operatii_contabile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tbSoldTotal);
            this.Controls.Add(this.btnSoldTotal);
            this.Controls.Add(this.btnConturi);
            this.Controls.Add(this.btnAfisareOperatiiContabile);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvConturi);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Operatii_contabile";
            this.Text = "Operatii_contabile";
            ((System.ComponentModel.ISupportInitialize)(this.dgvConturi)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.contextMenuStrip2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvConturi;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAfisareOperatiiContabile;
        private System.Windows.Forms.Button btnConturi;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.Button btnSoldTotal;
        private System.Windows.Forms.TextBox tbSoldTotal;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.ToolStripMenuItem toolCalculSoldTotal;
        private System.Windows.Forms.ToolStripMenuItem toolAfisareOperatiiContabile;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
    }
}