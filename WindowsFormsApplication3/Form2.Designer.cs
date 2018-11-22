namespace WindowsFormsApplication3
{
    partial class Form2
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.создатьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.вызодToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.упорядовачиваниеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.каскадToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.горизонтальноеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.вертикальноеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.создатьToolStripMenuItem,
            this.вызодToolStripMenuItem,
            this.упорядовачиваниеToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1142, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // создатьToolStripMenuItem
            // 
            this.создатьToolStripMenuItem.Name = "создатьToolStripMenuItem";
            this.создатьToolStripMenuItem.Size = new System.Drawing.Size(62, 20);
            this.создатьToolStripMenuItem.Text = "Создать";
            this.создатьToolStripMenuItem.Click += new System.EventHandler(this.создатьToolStripMenuItem_Click);
            // 
            // вызодToolStripMenuItem
            // 
            this.вызодToolStripMenuItem.Name = "вызодToolStripMenuItem";
            this.вызодToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.вызодToolStripMenuItem.Text = "Выход";
            this.вызодToolStripMenuItem.Click += new System.EventHandler(this.вызодToolStripMenuItem_Click);
            // 
            // упорядовачиваниеToolStripMenuItem
            // 
            this.упорядовачиваниеToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.каскадToolStripMenuItem,
            this.горизонтальноеToolStripMenuItem,
            this.вертикальноеToolStripMenuItem});
            this.упорядовачиваниеToolStripMenuItem.Name = "упорядовачиваниеToolStripMenuItem";
            this.упорядовачиваниеToolStripMenuItem.Size = new System.Drawing.Size(124, 20);
            this.упорядовачиваниеToolStripMenuItem.Text = "Упорядовачивание";
            // 
            // каскадToolStripMenuItem
            // 
            this.каскадToolStripMenuItem.Name = "каскадToolStripMenuItem";
            this.каскадToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.каскадToolStripMenuItem.Text = "Каскад";
            this.каскадToolStripMenuItem.Click += new System.EventHandler(this.каскадToolStripMenuItem_Click);
            // 
            // горизонтальноеToolStripMenuItem
            // 
            this.горизонтальноеToolStripMenuItem.Name = "горизонтальноеToolStripMenuItem";
            this.горизонтальноеToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.горизонтальноеToolStripMenuItem.Text = "Горизонтальное";
            this.горизонтальноеToolStripMenuItem.Click += new System.EventHandler(this.горизонтальноеToolStripMenuItem_Click);
            // 
            // вертикальноеToolStripMenuItem
            // 
            this.вертикальноеToolStripMenuItem.Name = "вертикальноеToolStripMenuItem";
            this.вертикальноеToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.вертикальноеToolStripMenuItem.Text = "Вертикальное";
            this.вертикальноеToolStripMenuItem.Click += new System.EventHandler(this.вертикальноеToolStripMenuItem_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1142, 517);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form2";
            this.Text = "Form2";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem создатьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem вызодToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem упорядовачиваниеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem каскадToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem горизонтальноеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem вертикальноеToolStripMenuItem;
    }
}