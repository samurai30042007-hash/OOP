namespace WinFormsApp1
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
            label1 = new Label();
            textBox1 = new TextBox();
            trackBar1 = new TrackBar();
            trackBar2 = new TrackBar();
            textBox2 = new TextBox();
            trackBar3 = new TrackBar();
            textBox3 = new TextBox();
            Save = new Button();
            Load = new Button();
            numericUpDown1 = new NumericUpDown();
            numericUpDown2 = new NumericUpDown();
            numericUpDown3 = new NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)trackBar1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBar2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBar3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown3).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 60F);
            label1.Location = new Point(72, 51);
            label1.Name = "label1";
            label1.Size = new Size(621, 133);
            label1.TabIndex = 0;
            label1.Text = "A <= B <= C";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(84, 211);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(125, 27);
            textBox1.TabIndex = 1;
            // 
            // trackBar1
            // 
            trackBar1.Location = new Point(84, 352);
            trackBar1.Name = "trackBar1";
            trackBar1.Size = new Size(130, 56);
            trackBar1.TabIndex = 2;
            // 
            // trackBar2
            // 
            trackBar2.Location = new Point(327, 352);
            trackBar2.Name = "trackBar2";
            trackBar2.Size = new Size(130, 56);
            trackBar2.TabIndex = 5;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(327, 211);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(125, 27);
            textBox2.TabIndex = 4;
            // 
            // trackBar3
            // 
            trackBar3.Location = new Point(568, 352);
            trackBar3.Name = "trackBar3";
            trackBar3.Size = new Size(130, 56);
            trackBar3.TabIndex = 8;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(568, 211);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(125, 27);
            textBox3.TabIndex = 7;
            // 
            // Save
            // 
            Save.Location = new Point(794, 294);
            Save.Name = "Save";
            Save.Size = new Size(94, 29);
            Save.TabIndex = 10;
            Save.Text = "Сохранить";
            Save.UseVisualStyleBackColor = true;
            Save.Click += Save_Click;
            // 
            // Load
            // 
            Load.Location = new Point(794, 167);
            Load.Name = "Load";
            Load.Size = new Size(94, 29);
            Load.TabIndex = 11;
            Load.Text = "Загрузить";
            Load.UseVisualStyleBackColor = true;
            Load.Click += Load_Click;
            // 
            // numericUpDown1
            // 
            numericUpDown1.Location = new Point(84, 282);
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(150, 27);
            numericUpDown1.TabIndex = 12;
            // 
            // numericUpDown2
            // 
            numericUpDown2.Location = new Point(327, 282);
            numericUpDown2.Name = "numericUpDown2";
            numericUpDown2.Size = new Size(150, 27);
            numericUpDown2.TabIndex = 13;
            // 
            // numericUpDown3
            // 
            numericUpDown3.Location = new Point(568, 282);
            numericUpDown3.Name = "numericUpDown3";
            numericUpDown3.Size = new Size(150, 27);
            numericUpDown3.TabIndex = 14;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(958, 470);
            Controls.Add(numericUpDown3);
            Controls.Add(numericUpDown2);
            Controls.Add(numericUpDown1);
            Controls.Add(Load);
            Controls.Add(Save);
            Controls.Add(trackBar3);
            Controls.Add(textBox3);
            Controls.Add(trackBar2);
            Controls.Add(textBox2);
            Controls.Add(trackBar1);
            Controls.Add(textBox1);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)trackBar1).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackBar2).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackBar3).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown2).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown3).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox textBox1;
        private TrackBar trackBar1;
        private TrackBar trackBar2;
        private TextBox textBox2;
        private TrackBar trackBar3;
        private TextBox textBox3;
        private Button Save;
        private Button Load;
        private NumericUpDown numericUpDown1;
        private NumericUpDown numericUpDown2;
        private NumericUpDown numericUpDown3;
    }
}
