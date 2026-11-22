namespace laba_3._1
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            menuStrip1 = new MenuStrip();
            кРУГToolStripMenuItem = new ToolStripMenuItem();
            пРЯМОУГОЛЬНИКToolStripMenuItem = new ToolStripMenuItem();
            тРЕУГОЛЬНИКToolStripMenuItem = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { кРУГToolStripMenuItem, пРЯМОУГОЛЬНИКToolStripMenuItem, тРЕУГОЛЬНИКToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 28);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // кРУГToolStripMenuItem
            // 
            кРУГToolStripMenuItem.Name = "кРУГToolStripMenuItem";
            кРУГToolStripMenuItem.Size = new Size(56, 24);
            кРУГToolStripMenuItem.Text = "КРУГ";
            кРУГToolStripMenuItem.Click += кРУГToolStripMenuItem_Click;
            // 
            // пРЯМОУГОЛЬНИКToolStripMenuItem
            // 
            пРЯМОУГОЛЬНИКToolStripMenuItem.Name = "пРЯМОУГОЛЬНИКToolStripMenuItem";
            пРЯМОУГОЛЬНИКToolStripMenuItem.Size = new Size(152, 24);
            пРЯМОУГОЛЬНИКToolStripMenuItem.Text = "ПРЯМОУГОЛЬНИК";
            пРЯМОУГОЛЬНИКToolStripMenuItem.Click += пРЯМОУГОЛЬНИКToolStripMenuItem_Click;
            // 
            // тРЕУГОЛЬНИКToolStripMenuItem
            // 
            тРЕУГОЛЬНИКToolStripMenuItem.Name = "тРЕУГОЛЬНИКToolStripMenuItem";
            тРЕУГОЛЬНИКToolStripMenuItem.Size = new Size(124, 24);
            тРЕУГОЛЬНИКToolStripMenuItem.Text = "ТРЕУГОЛЬНИК";
            тРЕУГОЛЬНИКToolStripMenuItem.Click += тРЕУГОЛЬНИКToolStripMenuItem_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "Form1";
            Text = "Form1";
            FormClosing += Form1_FormClosing;
            Paint += Form1_Paint;
            KeyDown += Form1_KeyDown;
            MouseDown += Form1_MouseDown;
            Resize += Form1_Resize;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem кРУГToolStripMenuItem;
        private ToolStripMenuItem пРЯМОУГОЛЬНИКToolStripMenuItem;
        private ToolStripMenuItem тРЕУГОЛЬНИКToolStripMenuItem;
    }
}
