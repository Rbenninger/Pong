namespace PongBounceTest
{
    partial class BouceTest
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BouceTest));
            this.BounceBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.BounceBox)).BeginInit();
            this.SuspendLayout();
            // 
            // BounceBox
            // 
            this.BounceBox.BackColor = System.Drawing.Color.Black;
            this.BounceBox.Location = new System.Drawing.Point(0, 0);
            this.BounceBox.Name = "BounceBox";
            this.BounceBox.Size = new System.Drawing.Size(400, 400);
            this.BounceBox.TabIndex = 0;
            this.BounceBox.TabStop = false;
            this.BounceBox.Paint += new System.Windows.Forms.PaintEventHandler(this.BounceBox_Paint_1);
            // 
            // BouceTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 361);
            this.Controls.Add(this.BounceBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "BouceTest";
            this.Text = "Bounce Test";
            this.Load += new System.EventHandler(this.BouceTest_Load);
            ((System.ComponentModel.ISupportInitialize)(this.BounceBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox BounceBox;
    }
}

