namespace NavagationPage_Winform
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
            this.panel_Background = new System.Windows.Forms.Panel();
            this.panel_State = new System.Windows.Forms.Panel();
            this.label_Time = new System.Windows.Forms.Label();
            this.panel_Navigation = new System.Windows.Forms.Panel();
            this.panel_Title = new System.Windows.Forms.Panel();
            this.label_Title = new System.Windows.Forms.Label();
            this.panel_Background.SuspendLayout();
            this.panel_State.SuspendLayout();
            this.panel_Title.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel_Background
            // 
            this.panel_Background.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel_Background.Controls.Add(this.panel_State);
            this.panel_Background.Controls.Add(this.panel_Navigation);
            this.panel_Background.Controls.Add(this.panel_Title);
            this.panel_Background.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_Background.Location = new System.Drawing.Point(0, 0);
            this.panel_Background.Name = "panel_Background";
            this.panel_Background.Size = new System.Drawing.Size(800, 450);
            this.panel_Background.TabIndex = 0;
            // 
            // panel_State
            // 
            this.panel_State.Controls.Add(this.label_Time);
            this.panel_State.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel_State.Location = new System.Drawing.Point(250, 325);
            this.panel_State.Name = "panel_State";
            this.panel_State.Size = new System.Drawing.Size(550, 125);
            this.panel_State.TabIndex = 2;
            // 
            // label_Time
            // 
            this.label_Time.AutoSize = true;
            this.label_Time.Dock = System.Windows.Forms.DockStyle.Left;
            this.label_Time.Font = new System.Drawing.Font("Mistral", 22.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.label_Time.Location = new System.Drawing.Point(0, 0);
            this.label_Time.Name = "label_Time";
            this.label_Time.Size = new System.Drawing.Size(93, 44);
            this.label_Time.TabIndex = 0;
            this.label_Time.Text = "label1";
            // 
            // panel_Navigation
            // 
            this.panel_Navigation.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel_Navigation.Location = new System.Drawing.Point(0, 125);
            this.panel_Navigation.Name = "panel_Navigation";
            this.panel_Navigation.Size = new System.Drawing.Size(250, 325);
            this.panel_Navigation.TabIndex = 1;
            // 
            // panel_Title
            // 
            this.panel_Title.Controls.Add(this.label_Title);
            this.panel_Title.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_Title.Location = new System.Drawing.Point(0, 0);
            this.panel_Title.Name = "panel_Title";
            this.panel_Title.Size = new System.Drawing.Size(800, 125);
            this.panel_Title.TabIndex = 0;
            // 
            // label_Title
            // 
            this.label_Title.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Title.Font = new System.Drawing.Font("Matura MT Script Capitals", 24F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.label_Title.Location = new System.Drawing.Point(0, 0);
            this.label_Title.Name = "label_Title";
            this.label_Title.Size = new System.Drawing.Size(800, 125);
            this.label_Title.TabIndex = 0;
            this.label_Title.Text = "label1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel_Background);
            this.Name = "Form1";
            this.Text = "Form1";
            this.panel_Background.ResumeLayout(false);
            this.panel_State.ResumeLayout(false);
            this.panel_State.PerformLayout();
            this.panel_Title.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panel_Background;
        private Panel panel_Navigation;
        private Panel panel_Title;
        private Label label_Title;
        private Panel panel_State;
        private Label label_Time;
    }
}