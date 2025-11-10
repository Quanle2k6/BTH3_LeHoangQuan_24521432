namespace Bai02
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        /// 
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            if (disposing)
            {
                if (CustomFont != null)
                    CustomFont.Dispose();
                if (CustomBrush != null)
                    CustomBrush.Dispose();
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
            this.ButtonDraw = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ButtonDraw
            // 
            this.ButtonDraw.Location = new System.Drawing.Point(12, 26);
            this.ButtonDraw.Name = "ButtonDraw";
            this.ButtonDraw.Size = new System.Drawing.Size(97, 23);
            this.ButtonDraw.TabIndex = 0;
            this.ButtonDraw.Text = "Paint";
            this.ButtonDraw.UseVisualStyleBackColor = true;
            this.ButtonDraw.Click += new System.EventHandler(this.ButtonDraw_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ButtonDraw);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button ButtonDraw;
    }
}

