namespace ResetNetworkAdapter
{
    partial class RestEthernetForm
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
            btnReset = new Button();
            SuspendLayout();
            // 
            // btnReset
            // 
            btnReset.FlatStyle = FlatStyle.System;
            btnReset.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnReset.Location = new Point(70, 67);
            btnReset.Name = "btnReset";
            btnReset.Size = new Size(245, 77);
            btnReset.TabIndex = 0;
            btnReset.Text = "Reset Ethernet";
            btnReset.UseVisualStyleBackColor = true;
            btnReset.Click += btnReset_Click;
            // 
            // RestEthernetForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(413, 221);
            Controls.Add(btnReset);
            Name = "RestEthernetForm";
            Text = "Reset Ethernet Adapter";
            ResumeLayout(false);
        }

        #endregion

        private Button btnReset;
    }
}
