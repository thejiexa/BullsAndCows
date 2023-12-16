namespace BullsAndCows
{
    partial class MainForm
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
            pveRb = new RadioButton();
            pvpRb = new RadioButton();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            button1 = new Button();
            button2 = new Button();
            listBox1 = new ListBox();
            listBox2 = new ListBox();
            cheatCb = new CheckBox();
            SuspendLayout();
            // 
            // pveRb
            // 
            pveRb.BackgroundImageLayout = ImageLayout.Zoom;
            pveRb.Checked = true;
            pveRb.Cursor = Cursors.Hand;
            pveRb.Location = new Point(25, 12);
            pveRb.Name = "pveRb";
            pveRb.Size = new Size(143, 106);
            pveRb.TabIndex = 0;
            pveRb.TabStop = true;
            pveRb.UseVisualStyleBackColor = true;
            pveRb.CheckedChanged += RadioButton_CheckedChanged;
            // 
            // pvpRb
            // 
            pvpRb.BackgroundImageLayout = ImageLayout.Zoom;
            pvpRb.Cursor = Cursors.Hand;
            pvpRb.Location = new Point(25, 124);
            pvpRb.Name = "pvpRb";
            pvpRb.Size = new Size(143, 106);
            pvpRb.TabIndex = 1;
            pvpRb.UseVisualStyleBackColor = true;
            pvpRb.CheckedChanged += RadioButton_CheckedChanged;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(187, 25);
            textBox1.MaxLength = 4;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(100, 37);
            textBox1.TabIndex = 2;
            textBox1.UseSystemPasswordChar = true;
            textBox1.KeyDown += TextBox1_KeyDown;
            textBox1.KeyPress += TextBox_KeyPress;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(530, 25);
            textBox2.MaxLength = 4;
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(100, 37);
            textBox2.TabIndex = 3;
            textBox2.UseSystemPasswordChar = true;
            textBox2.KeyDown += TextBox2_KeyDown;
            textBox2.KeyPress += TextBox_KeyPress;
            // 
            // button1
            // 
            button1.Cursor = Cursors.Hand;
            button1.Location = new Point(294, 23);
            button1.Name = "button1";
            button1.Size = new Size(205, 40);
            button1.TabIndex = 4;
            button1.Text = "Set a number";
            button1.UseVisualStyleBackColor = true;
            button1.Click += Button1_Click;
            // 
            // button2
            // 
            button2.Cursor = Cursors.Hand;
            button2.Location = new Point(637, 25);
            button2.Name = "button2";
            button2.Size = new Size(205, 40);
            button2.TabIndex = 5;
            button2.Text = "Player 2 is AI";
            button2.UseVisualStyleBackColor = true;
            button2.Click += Button2_Click;
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 29;
            listBox1.Location = new Point(187, 73);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(312, 62);
            listBox1.TabIndex = 6;
            // 
            // listBox2
            // 
            listBox2.FormattingEnabled = true;
            listBox2.ItemHeight = 29;
            listBox2.Location = new Point(530, 73);
            listBox2.Name = "listBox2";
            listBox2.Size = new Size(312, 62);
            listBox2.TabIndex = 7;
            // 
            // cheatCb
            // 
            cheatCb.AutoSize = true;
            cheatCb.Location = new Point(27, 512);
            cheatCb.Name = "cheatCb";
            cheatCb.Size = new Size(15, 14);
            cheatCb.TabIndex = 9;
            cheatCb.UseVisualStyleBackColor = true;
            cheatCb.CheckedChanged += CheatCb_CheckedChanged;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(12F, 29F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightPink;
            ClientSize = new Size(870, 576);
            Controls.Add(cheatCb);
            Controls.Add(listBox2);
            Controls.Add(listBox1);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(pvpRb);
            Controls.Add(pveRb);
            Font = new Font("Calibri", 18F, FontStyle.Bold, GraphicsUnit.Point, 204);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Margin = new Padding(5, 6, 5, 6);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Bulls And Cows";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private RadioButton pveRb;
        private RadioButton pvpRb;
        private TextBox textBox1;
        private TextBox textBox2;
        private Button button1;
        private Button button2;
        private ListBox listBox1;
        private ListBox listBox2;
        private CheckBox cheatCb;
    }
}
