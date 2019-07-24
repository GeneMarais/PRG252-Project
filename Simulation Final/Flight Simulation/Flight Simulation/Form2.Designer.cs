namespace Flight_Simulation
{
    partial class Form2
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
            this.lblTimeOfStrike = new System.Windows.Forms.Label();
            this.lblTime = new System.Windows.Forms.Label();
            this.lblReport = new System.Windows.Forms.Label();
            this.lblTargetLocation = new System.Windows.Forms.Label();
            this.lblTarget = new System.Windows.Forms.Label();
            this.lblHitLocation = new System.Windows.Forms.Label();
            this.lblHit = new System.Windows.Forms.Label();
            this.lblObstaclesIdentified = new System.Windows.Forms.Label();
            this.rtbIdentified = new System.Windows.Forms.RichTextBox();
            this.btnExit = new System.Windows.Forms.Button();
            this.dataGridView7 = new System.Windows.Forms.DataGridView();
            this.btnReturn = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTimeOfStrike
            // 
            this.lblTimeOfStrike.AutoSize = true;
            this.lblTimeOfStrike.Location = new System.Drawing.Point(41, 41);
            this.lblTimeOfStrike.Name = "lblTimeOfStrike";
            this.lblTimeOfStrike.Size = new System.Drawing.Size(75, 13);
            this.lblTimeOfStrike.TabIndex = 0;
            this.lblTimeOfStrike.Text = "Time of Strike:";
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.Location = new System.Drawing.Point(136, 41);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(35, 13);
            this.lblTime.TabIndex = 1;
            this.lblTime.Text = "label1";
            this.lblTime.Click += new System.EventHandler(this.lblTime_Click);
            // 
            // lblReport
            // 
            this.lblReport.AutoSize = true;
            this.lblReport.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Italic | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReport.Location = new System.Drawing.Point(12, 9);
            this.lblReport.Name = "lblReport";
            this.lblReport.Size = new System.Drawing.Size(64, 22);
            this.lblReport.TabIndex = 2;
            this.lblReport.Text = "Report";
            // 
            // lblTargetLocation
            // 
            this.lblTargetLocation.AutoSize = true;
            this.lblTargetLocation.Location = new System.Drawing.Point(31, 66);
            this.lblTargetLocation.Name = "lblTargetLocation";
            this.lblTargetLocation.Size = new System.Drawing.Size(85, 13);
            this.lblTargetLocation.TabIndex = 3;
            this.lblTargetLocation.Text = "Target Location:";
            // 
            // lblTarget
            // 
            this.lblTarget.AutoSize = true;
            this.lblTarget.Location = new System.Drawing.Point(136, 66);
            this.lblTarget.Name = "lblTarget";
            this.lblTarget.Size = new System.Drawing.Size(35, 13);
            this.lblTarget.TabIndex = 4;
            this.lblTarget.Text = "label1";
            // 
            // lblHitLocation
            // 
            this.lblHitLocation.AutoSize = true;
            this.lblHitLocation.Location = new System.Drawing.Point(49, 94);
            this.lblHitLocation.Name = "lblHitLocation";
            this.lblHitLocation.Size = new System.Drawing.Size(67, 13);
            this.lblHitLocation.TabIndex = 5;
            this.lblHitLocation.Text = "Hit Location:";
            // 
            // lblHit
            // 
            this.lblHit.AutoSize = true;
            this.lblHit.Location = new System.Drawing.Point(136, 94);
            this.lblHit.Name = "lblHit";
            this.lblHit.Size = new System.Drawing.Size(35, 13);
            this.lblHit.TabIndex = 6;
            this.lblHit.Text = "label1";
            // 
            // lblObstaclesIdentified
            // 
            this.lblObstaclesIdentified.AutoSize = true;
            this.lblObstaclesIdentified.Location = new System.Drawing.Point(13, 124);
            this.lblObstaclesIdentified.Name = "lblObstaclesIdentified";
            this.lblObstaclesIdentified.Size = new System.Drawing.Size(103, 13);
            this.lblObstaclesIdentified.TabIndex = 7;
            this.lblObstaclesIdentified.Text = "Obstacles Identified:";
            // 
            // rtbIdentified
            // 
            this.rtbIdentified.Location = new System.Drawing.Point(139, 121);
            this.rtbIdentified.Name = "rtbIdentified";
            this.rtbIdentified.Size = new System.Drawing.Size(100, 96);
            this.rtbIdentified.TabIndex = 8;
            this.rtbIdentified.Text = "";
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(96, 368);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 9;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // dataGridView7
            // 
            this.dataGridView7.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView7.GridColor = System.Drawing.SystemColors.ControlLightLight;
            this.dataGridView7.Location = new System.Drawing.Point(479, 34);
            this.dataGridView7.Name = "dataGridView7";
            this.dataGridView7.Size = new System.Drawing.Size(452, 119);
            this.dataGridView7.TabIndex = 10;
            this.dataGridView7.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView7_CellContentClick);
            // 
            // btnReturn
            // 
            this.btnReturn.Location = new System.Drawing.Point(12, 368);
            this.btnReturn.Name = "btnReturn";
            this.btnReturn.Size = new System.Drawing.Size(75, 23);
            this.btnReturn.TabIndex = 11;
            this.btnReturn.Text = "Return Simulation";
            this.btnReturn.UseVisualStyleBackColor = true;
            this.btnReturn.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(382, 242);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(549, 119);
            this.dataGridView1.TabIndex = 12;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(476, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 17);
            this.label1.TabIndex = 13;
            this.label1.Text = "Inventory:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(379, 212);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 17);
            this.label2.TabIndex = 14;
            this.label2.Text = "Aircrafts:";
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(943, 403);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnReturn);
            this.Controls.Add(this.dataGridView7);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.rtbIdentified);
            this.Controls.Add(this.lblObstaclesIdentified);
            this.Controls.Add(this.lblHit);
            this.Controls.Add(this.lblHitLocation);
            this.Controls.Add(this.lblTarget);
            this.Controls.Add(this.lblTargetLocation);
            this.Controls.Add(this.lblReport);
            this.Controls.Add(this.lblTime);
            this.Controls.Add(this.lblTimeOfStrike);
            this.Name = "Form2";
            this.Text = "Report";
            this.Load += new System.EventHandler(this.Form2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTimeOfStrike;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Label lblReport;
        private System.Windows.Forms.Label lblTargetLocation;
        private System.Windows.Forms.Label lblTarget;
        private System.Windows.Forms.Label lblHitLocation;
        private System.Windows.Forms.Label lblHit;
        private System.Windows.Forms.Label lblObstaclesIdentified;
        private System.Windows.Forms.RichTextBox rtbIdentified;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.DataGridView dataGridView7;
        private System.Windows.Forms.Button btnReturn;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}