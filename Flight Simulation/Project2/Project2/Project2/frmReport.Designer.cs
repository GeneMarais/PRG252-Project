namespace Project2
{
    partial class frmReport
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
            this.btnReturn = new System.Windows.Forms.Button();
            this.dgvDetails = new System.Windows.Forms.DataGridView();
            this.btnExit = new System.Windows.Forms.Button();
            this.rtbIdentified = new System.Windows.Forms.RichTextBox();
            this.lblObstaclesIdentified = new System.Windows.Forms.Label();
            this.lblHit = new System.Windows.Forms.Label();
            this.lblHitLocation = new System.Windows.Forms.Label();
            this.lblTarget = new System.Windows.Forms.Label();
            this.lblTargetLocation = new System.Windows.Forms.Label();
            this.lblReport = new System.Windows.Forms.Label();
            this.lblTime = new System.Windows.Forms.Label();
            this.lblTimeOfStrike = new System.Windows.Forms.Label();
            this.lblInventory = new System.Windows.Forms.Label();
            this.lblAircrafts = new System.Windows.Forms.Label();
            this.dgvAircrafts = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAircrafts)).BeginInit();
            this.SuspendLayout();
            // 
            // btnReturn
            // 
            this.btnReturn.Font = new System.Drawing.Font("MS Reference Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReturn.Location = new System.Drawing.Point(156, 343);
            this.btnReturn.Margin = new System.Windows.Forms.Padding(2);
            this.btnReturn.Name = "btnReturn";
            this.btnReturn.Size = new System.Drawing.Size(105, 57);
            this.btnReturn.TabIndex = 23;
            this.btnReturn.Text = "Return Simulation";
            this.btnReturn.UseVisualStyleBackColor = true;
            this.btnReturn.Click += new System.EventHandler(this.btnReturn_Click);
            // 
            // dgvDetails
            // 
            this.dgvDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetails.GridColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgvDetails.Location = new System.Drawing.Point(557, 101);
            this.dgvDetails.Margin = new System.Windows.Forms.Padding(2);
            this.dgvDetails.Name = "dgvDetails";
            this.dgvDetails.Size = new System.Drawing.Size(549, 80);
            this.dgvDetails.TabIndex = 22;
            // 
            // btnExit
            // 
            this.btnExit.Font = new System.Drawing.Font("MS Reference Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Location = new System.Drawing.Point(44, 343);
            this.btnExit.Margin = new System.Windows.Forms.Padding(2);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(98, 57);
            this.btnExit.TabIndex = 21;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // rtbIdentified
            // 
            this.rtbIdentified.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.rtbIdentified.Font = new System.Drawing.Font("MS Reference Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbIdentified.Location = new System.Drawing.Point(353, 250);
            this.rtbIdentified.Margin = new System.Windows.Forms.Padding(2);
            this.rtbIdentified.Name = "rtbIdentified";
            this.rtbIdentified.Size = new System.Drawing.Size(154, 90);
            this.rtbIdentified.TabIndex = 20;
            this.rtbIdentified.Text = "";
            // 
            // lblObstaclesIdentified
            // 
            this.lblObstaclesIdentified.AutoSize = true;
            this.lblObstaclesIdentified.BackColor = System.Drawing.Color.Transparent;
            this.lblObstaclesIdentified.Font = new System.Drawing.Font("MS Reference Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblObstaclesIdentified.ForeColor = System.Drawing.Color.White;
            this.lblObstaclesIdentified.Location = new System.Drawing.Point(87, 244);
            this.lblObstaclesIdentified.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblObstaclesIdentified.Name = "lblObstaclesIdentified";
            this.lblObstaclesIdentified.Size = new System.Drawing.Size(231, 24);
            this.lblObstaclesIdentified.TabIndex = 19;
            this.lblObstaclesIdentified.Text = "Obstacles Identified:";
            // 
            // lblHit
            // 
            this.lblHit.AutoSize = true;
            this.lblHit.BackColor = System.Drawing.Color.Transparent;
            this.lblHit.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHit.ForeColor = System.Drawing.Color.White;
            this.lblHit.Location = new System.Drawing.Point(300, 187);
            this.lblHit.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblHit.Name = "lblHit";
            this.lblHit.Size = new System.Drawing.Size(53, 20);
            this.lblHit.TabIndex = 18;
            this.lblHit.Text = "____";
            // 
            // lblHitLocation
            // 
            this.lblHitLocation.AutoSize = true;
            this.lblHitLocation.BackColor = System.Drawing.Color.Transparent;
            this.lblHitLocation.Font = new System.Drawing.Font("MS Reference Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHitLocation.ForeColor = System.Drawing.Color.White;
            this.lblHitLocation.Location = new System.Drawing.Point(136, 178);
            this.lblHitLocation.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblHitLocation.Name = "lblHitLocation";
            this.lblHitLocation.Size = new System.Drawing.Size(147, 24);
            this.lblHitLocation.TabIndex = 17;
            this.lblHitLocation.Text = "Hit Location:";
            // 
            // lblTarget
            // 
            this.lblTarget.AutoSize = true;
            this.lblTarget.BackColor = System.Drawing.Color.Transparent;
            this.lblTarget.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTarget.ForeColor = System.Drawing.Color.White;
            this.lblTarget.Location = new System.Drawing.Point(300, 148);
            this.lblTarget.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTarget.Name = "lblTarget";
            this.lblTarget.Size = new System.Drawing.Size(53, 20);
            this.lblTarget.TabIndex = 16;
            this.lblTarget.Text = "____";
            // 
            // lblTargetLocation
            // 
            this.lblTargetLocation.AutoSize = true;
            this.lblTargetLocation.BackColor = System.Drawing.Color.Transparent;
            this.lblTargetLocation.Font = new System.Drawing.Font("MS Reference Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTargetLocation.ForeColor = System.Drawing.Color.White;
            this.lblTargetLocation.Location = new System.Drawing.Point(99, 140);
            this.lblTargetLocation.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTargetLocation.Name = "lblTargetLocation";
            this.lblTargetLocation.Size = new System.Drawing.Size(184, 24);
            this.lblTargetLocation.TabIndex = 15;
            this.lblTargetLocation.Text = "Target Location:";
            // 
            // lblReport
            // 
            this.lblReport.AutoSize = true;
            this.lblReport.BackColor = System.Drawing.Color.Transparent;
            this.lblReport.Font = new System.Drawing.Font("MS Reference Sans Serif", 24F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReport.ForeColor = System.Drawing.Color.White;
            this.lblReport.Location = new System.Drawing.Point(21, 18);
            this.lblReport.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblReport.Name = "lblReport";
            this.lblReport.Size = new System.Drawing.Size(130, 40);
            this.lblReport.TabIndex = 14;
            this.lblReport.Text = "Report";
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.BackColor = System.Drawing.Color.Transparent;
            this.lblTime.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTime.ForeColor = System.Drawing.Color.White;
            this.lblTime.Location = new System.Drawing.Point(300, 109);
            this.lblTime.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(53, 20);
            this.lblTime.TabIndex = 13;
            this.lblTime.Text = "____";
            // 
            // lblTimeOfStrike
            // 
            this.lblTimeOfStrike.AutoSize = true;
            this.lblTimeOfStrike.BackColor = System.Drawing.Color.Transparent;
            this.lblTimeOfStrike.Font = new System.Drawing.Font("MS Reference Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTimeOfStrike.ForeColor = System.Drawing.Color.White;
            this.lblTimeOfStrike.Location = new System.Drawing.Point(113, 101);
            this.lblTimeOfStrike.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTimeOfStrike.Name = "lblTimeOfStrike";
            this.lblTimeOfStrike.Size = new System.Drawing.Size(170, 24);
            this.lblTimeOfStrike.TabIndex = 12;
            this.lblTimeOfStrike.Text = "Time of Strike:";
            // 
            // lblInventory
            // 
            this.lblInventory.AutoSize = true;
            this.lblInventory.BackColor = System.Drawing.Color.Transparent;
            this.lblInventory.Font = new System.Drawing.Font("MS Reference Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInventory.ForeColor = System.Drawing.Color.White;
            this.lblInventory.Location = new System.Drawing.Point(553, 51);
            this.lblInventory.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblInventory.Name = "lblInventory";
            this.lblInventory.Size = new System.Drawing.Size(121, 24);
            this.lblInventory.TabIndex = 24;
            this.lblInventory.Text = "Inventory:";
            // 
            // lblAircrafts
            // 
            this.lblAircrafts.AutoSize = true;
            this.lblAircrafts.BackColor = System.Drawing.Color.Transparent;
            this.lblAircrafts.Font = new System.Drawing.Font("MS Reference Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAircrafts.ForeColor = System.Drawing.Color.White;
            this.lblAircrafts.Location = new System.Drawing.Point(553, 211);
            this.lblAircrafts.Name = "lblAircrafts";
            this.lblAircrafts.Size = new System.Drawing.Size(109, 24);
            this.lblAircrafts.TabIndex = 26;
            this.lblAircrafts.Text = "Aircrafts:";
            // 
            // dgvAircrafts
            // 
            this.dgvAircrafts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAircrafts.Location = new System.Drawing.Point(557, 250);
            this.dgvAircrafts.Name = "dgvAircrafts";
            this.dgvAircrafts.Size = new System.Drawing.Size(549, 119);
            this.dgvAircrafts.TabIndex = 25;
            // 
            // frmReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Project2.Properties.Resources.Blue;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1146, 422);
            this.Controls.Add(this.lblAircrafts);
            this.Controls.Add(this.dgvAircrafts);
            this.Controls.Add(this.lblInventory);
            this.Controls.Add(this.btnReturn);
            this.Controls.Add(this.dgvDetails);
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
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmReport";
            this.Text = "frmReport";
            this.Load += new System.EventHandler(this.frmReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetails)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAircrafts)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnReturn;
        private System.Windows.Forms.DataGridView dgvDetails;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.RichTextBox rtbIdentified;
        private System.Windows.Forms.Label lblObstaclesIdentified;
        private System.Windows.Forms.Label lblHit;
        private System.Windows.Forms.Label lblHitLocation;
        private System.Windows.Forms.Label lblTarget;
        private System.Windows.Forms.Label lblTargetLocation;
        private System.Windows.Forms.Label lblReport;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Label lblTimeOfStrike;
        private System.Windows.Forms.Label lblInventory;
        private System.Windows.Forms.Label lblAircrafts;
        private System.Windows.Forms.DataGridView dgvAircrafts;
    }
}