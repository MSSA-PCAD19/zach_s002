namespace LearnControls
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
            button1 = new Button(); // this creates a new instance, instantiates button and associates it with a variable
            chkRememberMe = new CheckBox(); //so does this
            lblMessage = new Label(); // and this
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(144, 320);
            button1.Name = "button1";
            button1.Size = new Size(394, 29);
            button1.TabIndex = 0;
            button1.Text = "Change Background";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // chkRememberMe
            // 
            chkRememberMe.AutoSize = true;
            chkRememberMe.Location = new Point(557, 320);
            chkRememberMe.Name = "chkRememberMe";
            chkRememberMe.Size = new Size(136, 24);
            chkRememberMe.TabIndex = 1;
            chkRememberMe.Text = "Remember Me?";
            chkRememberMe.UseVisualStyleBackColor = true;
            // 
            // lblMessage
            // 
            lblMessage.AutoSize = true;
            lblMessage.Location = new Point(12, 9);
            lblMessage.Name = "lblMessage";
            lblMessage.Size = new Size(0, 20);
            lblMessage.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new SizeF(8F, 20F); // the this. is implied, can be written but not needed
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(800, 450);
            this.Controls.Add(lblMessage);
            this.Controls.Add(chkRememberMe);
            this.Controls.Add(button1);
            this.Name = "Form1";
            this.Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private CheckBox chkRememberMe;
        private Label lblMessage;
    }
}
