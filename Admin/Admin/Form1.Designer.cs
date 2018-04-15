namespace Admin
{
    partial class Admin
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Admin));
            this.MainPanel = new System.Windows.Forms.Panel();
            this.OpenMeshBtn = new System.Windows.Forms.Button();
            this.TrafficTable = new System.Windows.Forms.FlowLayoutPanel();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label2 = new System.Windows.Forms.Label();
            this.conctdNodeLbl = new System.Windows.Forms.Label();
            this.KickBtn = new System.Windows.Forms.Button();
            this.NodeList = new System.Windows.Forms.ListBox();
            this.RefreshTimer = new System.Windows.Forms.Timer(this.components);
            this.UpdateTrafficTimer = new System.Windows.Forms.Timer(this.components);
            this.MainPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // MainPanel
            // 
            this.MainPanel.Controls.Add(this.OpenMeshBtn);
            this.MainPanel.Controls.Add(this.TrafficTable);
            this.MainPanel.Controls.Add(this.chart1);
            this.MainPanel.Controls.Add(this.label2);
            this.MainPanel.Controls.Add(this.conctdNodeLbl);
            this.MainPanel.Controls.Add(this.KickBtn);
            this.MainPanel.Controls.Add(this.NodeList);
            this.MainPanel.Location = new System.Drawing.Point(0, 3);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Size = new System.Drawing.Size(709, 547);
            this.MainPanel.TabIndex = 0;
            // 
            // OpenMeshBtn
            // 
            this.OpenMeshBtn.Location = new System.Drawing.Point(158, 498);
            this.OpenMeshBtn.Name = "OpenMeshBtn";
            this.OpenMeshBtn.Size = new System.Drawing.Size(89, 23);
            this.OpenMeshBtn.TabIndex = 7;
            this.OpenMeshBtn.Text = "Open Grid View";
            this.OpenMeshBtn.UseVisualStyleBackColor = true;
            this.OpenMeshBtn.Click += new System.EventHandler(this.OpenMeshBtn_Click);
            // 
            // TrafficTable
            // 
            this.TrafficTable.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TrafficTable.AutoScroll = true;
            this.TrafficTable.BackColor = System.Drawing.SystemColors.Window;
            this.TrafficTable.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TrafficTable.Location = new System.Drawing.Point(158, 45);
            this.TrafficTable.Name = "TrafficTable";
            this.TrafficTable.Size = new System.Drawing.Size(542, 446);
            this.TrafficTable.TabIndex = 6;
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(504, 246);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(8, 8);
            this.chart1.TabIndex = 5;
            this.chart1.Text = "chart1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(155, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "Live Traffic:";
            // 
            // conctdNodeLbl
            // 
            this.conctdNodeLbl.AutoSize = true;
            this.conctdNodeLbl.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.conctdNodeLbl.Location = new System.Drawing.Point(9, 30);
            this.conctdNodeLbl.Name = "conctdNodeLbl";
            this.conctdNodeLbl.Size = new System.Drawing.Size(126, 15);
            this.conctdNodeLbl.TabIndex = 3;
            this.conctdNodeLbl.Text = "Connected Nodes:";
            // 
            // KickBtn
            // 
            this.KickBtn.Location = new System.Drawing.Point(39, 497);
            this.KickBtn.Name = "KickBtn";
            this.KickBtn.Size = new System.Drawing.Size(75, 23);
            this.KickBtn.TabIndex = 2;
            this.KickBtn.Text = "Kick";
            this.KickBtn.UseVisualStyleBackColor = true;
            this.KickBtn.Click += new System.EventHandler(this.KickBtn_Click);
            // 
            // NodeList
            // 
            this.NodeList.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.NodeList.FormattingEnabled = true;
            this.NodeList.ItemHeight = 17;
            this.NodeList.Location = new System.Drawing.Point(12, 45);
            this.NodeList.Name = "NodeList";
            this.NodeList.Size = new System.Drawing.Size(140, 446);
            this.NodeList.TabIndex = 0;
            // 
            // RefreshTimer
            // 
            this.RefreshTimer.Enabled = true;
            this.RefreshTimer.Interval = 20000;
            this.RefreshTimer.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // UpdateTrafficTimer
            // 
            this.UpdateTrafficTimer.Enabled = true;
            this.UpdateTrafficTimer.Tick += new System.EventHandler(this.UpdateTrafficTimer_Tick);
            // 
            // Admin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(712, 548);
            this.Controls.Add(this.MainPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Admin";
            this.Text = "Admin";
            this.MainPanel.ResumeLayout(false);
            this.MainPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel MainPanel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label conctdNodeLbl;
        private System.Windows.Forms.Button KickBtn;
        private System.Windows.Forms.ListBox NodeList;
        private System.Windows.Forms.Timer RefreshTimer;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.FlowLayoutPanel TrafficTable;
        private System.Windows.Forms.Timer UpdateTrafficTimer;
        private System.Windows.Forms.Button OpenMeshBtn;
    }
}

