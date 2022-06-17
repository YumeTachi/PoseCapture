
namespace posertrimer
{
    partial class ToolForm
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
            this.buttonScaleUp = new System.Windows.Forms.Button();
            this.buttonScaleDown = new System.Windows.Forms.Button();
            this.buttonCounterClockwise = new System.Windows.Forms.Button();
            this.buttonClockwise = new System.Windows.Forms.Button();
            this.buttonChangeFillMode = new System.Windows.Forms.Button();
            this.buttonCapture = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonScaleUp
            // 
            this.buttonScaleUp.Location = new System.Drawing.Point(12, 12);
            this.buttonScaleUp.Name = "buttonScaleUp";
            this.buttonScaleUp.Size = new System.Drawing.Size(47, 46);
            this.buttonScaleUp.TabIndex = 2;
            this.buttonScaleUp.Text = "＋";
            this.buttonScaleUp.UseVisualStyleBackColor = true;
            this.buttonScaleUp.Click += new System.EventHandler(this.buttonScaleUp_Click);
            // 
            // buttonScaleDown
            // 
            this.buttonScaleDown.Location = new System.Drawing.Point(61, 12);
            this.buttonScaleDown.Name = "buttonScaleDown";
            this.buttonScaleDown.Size = new System.Drawing.Size(47, 46);
            this.buttonScaleDown.TabIndex = 3;
            this.buttonScaleDown.Text = "‐";
            this.buttonScaleDown.UseVisualStyleBackColor = true;
            this.buttonScaleDown.Click += new System.EventHandler(this.buttonScaleDown_Click);
            // 
            // buttonCounterClockwise
            // 
            this.buttonCounterClockwise.Location = new System.Drawing.Point(12, 64);
            this.buttonCounterClockwise.Name = "buttonCounterClockwise";
            this.buttonCounterClockwise.Size = new System.Drawing.Size(47, 46);
            this.buttonCounterClockwise.TabIndex = 4;
            this.buttonCounterClockwise.Text = "←";
            this.buttonCounterClockwise.UseVisualStyleBackColor = true;
            this.buttonCounterClockwise.Click += new System.EventHandler(this.buttonCounterClockwise_Click);
            // 
            // buttonClockwise
            // 
            this.buttonClockwise.Location = new System.Drawing.Point(61, 64);
            this.buttonClockwise.Name = "buttonClockwise";
            this.buttonClockwise.Size = new System.Drawing.Size(47, 46);
            this.buttonClockwise.TabIndex = 5;
            this.buttonClockwise.Text = "→";
            this.buttonClockwise.UseVisualStyleBackColor = true;
            this.buttonClockwise.Click += new System.EventHandler(this.buttonClockwise_Click);
            // 
            // buttonChangeFillMode
            // 
            this.buttonChangeFillMode.Location = new System.Drawing.Point(12, 116);
            this.buttonChangeFillMode.Name = "buttonChangeFillMode";
            this.buttonChangeFillMode.Size = new System.Drawing.Size(47, 46);
            this.buttonChangeFillMode.TabIndex = 6;
            this.buttonChangeFillMode.Text = "塗";
            this.buttonChangeFillMode.UseVisualStyleBackColor = true;
            this.buttonChangeFillMode.Click += new System.EventHandler(this.buttonChangeFillMode_Click);
            // 
            // buttonCapture
            // 
            this.buttonCapture.Location = new System.Drawing.Point(61, 116);
            this.buttonCapture.Name = "buttonCapture";
            this.buttonCapture.Size = new System.Drawing.Size(47, 46);
            this.buttonCapture.TabIndex = 7;
            this.buttonCapture.Text = "写";
            this.buttonCapture.UseVisualStyleBackColor = true;
            this.buttonCapture.Click += new System.EventHandler(this.buttonCapture_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Location = new System.Drawing.Point(12, 165);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 49);
            this.label1.TabIndex = 8;
            this.label1.Text = "Ctrl+押下で↑\r\n保存Dialogが\r\n開きます";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // ToolForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(120, 223);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonCapture);
            this.Controls.Add(this.buttonChangeFillMode);
            this.Controls.Add(this.buttonClockwise);
            this.Controls.Add(this.buttonCounterClockwise);
            this.Controls.Add(this.buttonScaleDown);
            this.Controls.Add(this.buttonScaleUp);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ToolForm";
            this.ShowInTaskbar = false;
            this.Text = "ToolForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ToolForm_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonScaleUp;
        private System.Windows.Forms.Button buttonScaleDown;
        private System.Windows.Forms.Button buttonCounterClockwise;
        private System.Windows.Forms.Button buttonClockwise;
        private System.Windows.Forms.Button buttonChangeFillMode;
        private System.Windows.Forms.Button buttonCapture;
        private System.Windows.Forms.Label label1;
    }
}