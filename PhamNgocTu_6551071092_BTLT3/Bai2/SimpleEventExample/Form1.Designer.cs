namespace SimpleEventExample
{
    partial class frmSimpleEvent
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
            btnClickMe = new Button();
            SuspendLayout();
            // 
            // btnClickMe
            // 
            btnClickMe.FlatAppearance.BorderColor = SystemColors.HotTrack;
            btnClickMe.FlatAppearance.BorderSize = 2;
            btnClickMe.FlatStyle = FlatStyle.Flat;
            btnClickMe.Font = new Font("Segoe UI", 36F, FontStyle.Bold);
            btnClickMe.ForeColor = Color.DarkRed;
            btnClickMe.Location = new Point(185, 105);
            btnClickMe.Name = "btnClickMe";
            btnClickMe.Size = new Size(421, 186);
            btnClickMe.TabIndex = 0;
            btnClickMe.Text = "Click Me";
            btnClickMe.UseVisualStyleBackColor = true;
            btnClickMe.Click += btnClickMe_Click;
            // 
            // frmSimpleEvent
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(800, 450);
            Controls.Add(btnClickMe);
            Name = "frmSimpleEvent";
            Text = "Simple event example";
            Load += frmSimpleEvent_Load;
            Click += frmSimpleEvent_Click;
            ResumeLayout(false);
        }

        #endregion

        private Button btnClickMe;
    }
}
