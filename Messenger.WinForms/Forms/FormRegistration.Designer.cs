namespace ShkiperWinForms
{
    partial class FormRegistration
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
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.textBoxLogin = new System.Windows.Forms.TextBox();
            this.textBoxPw = new System.Windows.Forms.TextBox();
            this.textBoxPwAgain = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(107, 194);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 15);
            this.label4.TabIndex = 12;
            this.label4.Text = "Password";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(127, 165);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 15);
            this.label3.TabIndex = 11;
            this.label3.Text = "Login";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(192, 115);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 15);
            this.label2.TabIndex = 8;
            this.label2.Text = "REGISTRATION";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(125, 136);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 15);
            this.label1.TabIndex = 16;
            this.label1.Text = "Name";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(68, 222);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(96, 15);
            this.label5.TabIndex = 18;
            this.label5.Text = "Repeat Password";
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(168, 133);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(128, 23);
            this.textBoxName.TabIndex = 19;
            // 
            // textBoxLogin
            // 
            this.textBoxLogin.Location = new System.Drawing.Point(168, 162);
            this.textBoxLogin.Name = "textBoxLogin";
            this.textBoxLogin.Size = new System.Drawing.Size(128, 23);
            this.textBoxLogin.TabIndex = 20;
            // 
            // textBoxPw
            // 
            this.textBoxPw.Location = new System.Drawing.Point(168, 191);
            this.textBoxPw.Name = "textBoxPw";
            this.textBoxPw.Size = new System.Drawing.Size(128, 23);
            this.textBoxPw.TabIndex = 21;
            // 
            // textBoxPwAgain
            // 
            this.textBoxPwAgain.Location = new System.Drawing.Point(168, 219);
            this.textBoxPwAgain.Name = "textBoxPwAgain";
            this.textBoxPwAgain.Size = new System.Drawing.Size(128, 23);
            this.textBoxPwAgain.TabIndex = 22;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(168, 248);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(128, 27);
            this.button1.TabIndex = 23;
            this.button1.Text = "Move";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FormRegistration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(449, 371);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBoxPwAgain);
            this.Controls.Add(this.textBoxPw);
            this.Controls.Add(this.textBoxLogin);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Name = "FormRegistration";
            this.Text = "FormRegistration";
            this.Load += new System.EventHandler(this.FormRegistration_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private Label label5;
        private TextBox textBoxName;
        private TextBox textBoxLogin;
        private TextBox textBoxPw;
        private TextBox textBoxPwAgain;
        private Button button1;
    }
}