namespace ShkiperWinForms
{
    partial class FormReady
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
            this.textBoxMessage = new System.Windows.Forms.TextBox();
            this.listBoxChat = new System.Windows.Forms.ListBox();
            this.ChatPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxSearchChat = new System.Windows.Forms.TextBox();
            this.ActionsPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // textBoxMessage
            // 
            this.textBoxMessage.BackColor = System.Drawing.SystemColors.Menu;
            this.textBoxMessage.Location = new System.Drawing.Point(133, 327);
            this.textBoxMessage.Name = "textBoxMessage";
            this.textBoxMessage.Size = new System.Drawing.Size(415, 23);
            this.textBoxMessage.TabIndex = 1;
            // 
            // listBoxChat
            // 
            this.listBoxChat.FormattingEnabled = true;
            this.listBoxChat.ItemHeight = 15;
            this.listBoxChat.Location = new System.Drawing.Point(133, 32);
            this.listBoxChat.Name = "listBoxChat";
            this.listBoxChat.Size = new System.Drawing.Size(415, 289);
            this.listBoxChat.TabIndex = 2;
            // 
            // ChatPanel
            // 
            this.ChatPanel.AutoScroll = true;
            this.ChatPanel.Location = new System.Drawing.Point(12, 61);
            this.ChatPanel.Name = "ChatPanel";
            this.ChatPanel.Size = new System.Drawing.Size(115, 353);
            this.ChatPanel.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(50, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 15);
            this.label1.TabIndex = 4;
            this.label1.Text = "Chats";
            // 
            // textBoxSearchChat
            // 
            this.textBoxSearchChat.Location = new System.Drawing.Point(12, 32);
            this.textBoxSearchChat.Name = "textBoxSearchChat";
            this.textBoxSearchChat.Size = new System.Drawing.Size(115, 23);
            this.textBoxSearchChat.TabIndex = 5;
            // 
            // ActionsPanel
            // 
            this.ActionsPanel.AutoScroll = true;
            this.ActionsPanel.Location = new System.Drawing.Point(554, 32);
            this.ActionsPanel.Name = "ActionsPanel";
            this.ActionsPanel.Size = new System.Drawing.Size(101, 353);
            this.ActionsPanel.TabIndex = 6;
            // 
            // FormReady
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(666, 459);
            this.Controls.Add(this.ActionsPanel);
            this.Controls.Add(this.textBoxSearchChat);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ChatPanel);
            this.Controls.Add(this.listBoxChat);
            this.Controls.Add(this.textBoxMessage);
            this.Name = "FormReady";
            this.Text = "FormReady";
            this.Load += new System.EventHandler(this.FormReady_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private TextBox textBoxMessage;
        private ListBox listBoxChat;
        private FlowLayoutPanel ChatPanel;
        private Label label1;
        private TextBox textBoxSearchChat;
        private FlowLayoutPanel ActionsPanel;
    }
}