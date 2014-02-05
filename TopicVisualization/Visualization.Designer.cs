namespace TopicVisualization
{
    partial class Visualization
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
            this.panelWordTopicDist = new System.Windows.Forms.Panel();
            this.wordTopicControl = new TopicVisualizer.WordTopicControl();
            this.panelWordTopicDist.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelWordTopicDist
            // 
            this.panelWordTopicDist.AutoScroll = true;
            this.panelWordTopicDist.Controls.Add(this.wordTopicControl);
            this.panelWordTopicDist.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelWordTopicDist.Location = new System.Drawing.Point(0, 0);
            this.panelWordTopicDist.Name = "panelWordTopicDist";
            this.panelWordTopicDist.Size = new System.Drawing.Size(834, 437);
            this.panelWordTopicDist.TabIndex = 0;
            // 
            // wordTopicControl
            // 
            this.wordTopicControl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.wordTopicControl.BackColor = System.Drawing.Color.White;
            this.wordTopicControl.Font = new System.Drawing.Font("Malgun Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.wordTopicControl.Location = new System.Drawing.Point(3, 4);
            this.wordTopicControl.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.wordTopicControl.Name = "wordTopicControl";
            this.wordTopicControl.Size = new System.Drawing.Size(831, 578);
            this.wordTopicControl.TabIndex = 1;
            // 
            // Visualization
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(834, 437);
            this.Controls.Add(this.panelWordTopicDist);
            this.Font = new System.Drawing.Font("Malgun Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Visualization";
            this.Text = "Topic Visualization";
            this.Load += new System.EventHandler(this.Visualization_Load);
            this.panelWordTopicDist.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelWordTopicDist;
        private TopicVisualizer.WordTopicControl wordTopicControl;
    }
}

