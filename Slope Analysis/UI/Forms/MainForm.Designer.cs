namespace Slope_Analysis.UI.Forms
{
    partial class MainForm
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
            this.btnSelectFloors = new System.Windows.Forms.Button();
            this.lblSelectedCount = new System.Windows.Forms.Label();
            this.btnAnalysis = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.grpSlopeRange = new System.Windows.Forms.GroupBox();
            this.txtEndRange = new System.Windows.Forms.TextBox();
            this.txtStartRange = new System.Windows.Forms.TextBox();
            this.lblEndRange = new System.Windows.Forms.Label();
            this.lblStartRange = new System.Windows.Forms.Label();
            this.grpSlopeRange.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSelectFloors
            // 
            this.btnSelectFloors.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(115)))), ((int)(((byte)(223)))));
            this.btnSelectFloors.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSelectFloors.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSelectFloors.ForeColor = System.Drawing.Color.White;
            this.btnSelectFloors.Location = new System.Drawing.Point(28, 72);
            this.btnSelectFloors.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSelectFloors.Name = "btnSelectFloors";
            this.btnSelectFloors.Size = new System.Drawing.Size(232, 49);
            this.btnSelectFloors.TabIndex = 0;
            this.btnSelectFloors.Text = "Select Floors";
            this.btnSelectFloors.UseVisualStyleBackColor = false;
            this.btnSelectFloors.Click += new System.EventHandler(this.btnSelectFloors_Click);
            // 
            // lblSelectedCount
            // 
            this.lblSelectedCount.AutoSize = true;
            this.lblSelectedCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSelectedCount.Location = new System.Drawing.Point(283, 92);
            this.lblSelectedCount.Name = "lblSelectedCount";
            this.lblSelectedCount.Size = new System.Drawing.Size(134, 29);
            this.lblSelectedCount.TabIndex = 1;
            this.lblSelectedCount.Text = "Selected: 0";
            // 
            // btnAnalysis
            // 
            this.btnAnalysis.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(200)))), ((int)(((byte)(138)))));
            this.btnAnalysis.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAnalysis.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAnalysis.ForeColor = System.Drawing.Color.White;
            this.btnAnalysis.Location = new System.Drawing.Point(72, 308);
            this.btnAnalysis.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnAnalysis.Name = "btnAnalysis";
            this.btnAnalysis.Size = new System.Drawing.Size(232, 49);
            this.btnAnalysis.TabIndex = 2;
            this.btnAnalysis.Text = "Analysis";
            this.btnAnalysis.UseVisualStyleBackColor = false;
            this.btnAnalysis.Click += new System.EventHandler(this.btnAnalysis_Click);
            // 
            // btnReset
            // 
            this.btnReset.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(74)))), ((int)(((byte)(59)))));
            this.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReset.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReset.ForeColor = System.Drawing.Color.White;
            this.btnReset.Location = new System.Drawing.Point(415, 308);
            this.btnReset.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(232, 49);
            this.btnReset.TabIndex = 3;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = false;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // grpSlopeRange
            // 
            this.grpSlopeRange.Controls.Add(this.txtEndRange);
            this.grpSlopeRange.Controls.Add(this.txtStartRange);
            this.grpSlopeRange.Controls.Add(this.lblEndRange);
            this.grpSlopeRange.Controls.Add(this.lblStartRange);
            this.grpSlopeRange.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpSlopeRange.Location = new System.Drawing.Point(28, 138);
            this.grpSlopeRange.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grpSlopeRange.Name = "grpSlopeRange";
            this.grpSlopeRange.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grpSlopeRange.Size = new System.Drawing.Size(649, 151);
            this.grpSlopeRange.TabIndex = 4;
            this.grpSlopeRange.TabStop = false;
            this.grpSlopeRange.Text = "Define Slope Range (%)";
            // 
            // txtEndRange
            // 
            this.txtEndRange.Location = new System.Drawing.Point(387, 95);
            this.txtEndRange.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtEndRange.Name = "txtEndRange";
            this.txtEndRange.Size = new System.Drawing.Size(246, 38);
            this.txtEndRange.TabIndex = 8;
            // 
            // txtStartRange
            // 
            this.txtStartRange.Location = new System.Drawing.Point(45, 95);
            this.txtStartRange.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtStartRange.Name = "txtStartRange";
            this.txtStartRange.Size = new System.Drawing.Size(246, 38);
            this.txtStartRange.TabIndex = 7;
            // 
            // lblEndRange
            // 
            this.lblEndRange.AutoSize = true;
            this.lblEndRange.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEndRange.Location = new System.Drawing.Point(381, 47);
            this.lblEndRange.Name = "lblEndRange";
            this.lblEndRange.Size = new System.Drawing.Size(139, 29);
            this.lblEndRange.TabIndex = 6;
            this.lblEndRange.Text = "End Range:";
            // 
            // lblStartRange
            // 
            this.lblStartRange.AutoSize = true;
            this.lblStartRange.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStartRange.Location = new System.Drawing.Point(39, 47);
            this.lblStartRange.Name = "lblStartRange";
            this.lblStartRange.Size = new System.Drawing.Size(145, 29);
            this.lblStartRange.TabIndex = 5;
            this.lblStartRange.Text = "Start Range:";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(711, 394);
            this.Controls.Add(this.grpSlopeRange);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnAnalysis);
            this.Controls.Add(this.lblSelectedCount);
            this.Controls.Add(this.btnSelectFloors);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "MainForm";
            this.Padding = new System.Windows.Forms.Padding(24, 68, 24, 22);
            this.Text = "Slope Analysis";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.grpSlopeRange.ResumeLayout(false);
            this.grpSlopeRange.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSelectFloors;
        private System.Windows.Forms.Label lblSelectedCount;
        private System.Windows.Forms.Button btnAnalysis;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.GroupBox grpSlopeRange;
        private System.Windows.Forms.Label lblStartRange;
        private System.Windows.Forms.TextBox txtEndRange;
        private System.Windows.Forms.TextBox txtStartRange;
        private System.Windows.Forms.Label lblEndRange;
    }
}