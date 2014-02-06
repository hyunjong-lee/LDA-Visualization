namespace TopicVisualizer
{
    partial class WordTopicControl
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

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // WordTopicControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Malgun Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "WordTopicControl";
            this.Size = new System.Drawing.Size(375, 372);
            this.Load += new System.EventHandler(this.WordTopicControl_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.WordTopicControl_Paint);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.WordTopicControl_MouseDown);
            this.MouseLeave += new System.EventHandler(this.WordTopicControl_MouseLeave);
            this.MouseHover += new System.EventHandler(this.WordTopicControl_MouseHover);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.WordTopicControl_MouseUp);
            this.ResumeLayout(false);

        }

        #endregion

    }
}
