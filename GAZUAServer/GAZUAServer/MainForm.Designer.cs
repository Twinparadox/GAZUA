namespace GAZUAServer
{
    partial class MainForm
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend4 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.lvStockState = new System.Windows.Forms.ListView();
            this.lvUserState = new System.Windows.Forms.ListView();
            this.groupBoxStockData = new System.Windows.Forms.GroupBox();
            this.groupBoxUserData = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBoxRank = new System.Windows.Forms.GroupBox();
            this.lvUserRanking = new System.Windows.Forms.ListView();
            this.groupBoxServerInfo = new System.Windows.Forms.GroupBox();
            this.rtbServerState = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.groupBoxStockData.SuspendLayout();
            this.groupBoxUserData.SuspendLayout();
            this.groupBoxRank.SuspendLayout();
            this.groupBoxServerInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // chart1
            // 
            chartArea4.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea4);
            legend4.Name = "Legend1";
            this.chart1.Legends.Add(legend4);
            this.chart1.Location = new System.Drawing.Point(4, 20);
            this.chart1.Name = "chart1";
            series4.ChartArea = "ChartArea1";
            series4.Legend = "Legend1";
            series4.Name = "Series1";
            this.chart1.Series.Add(series4);
            this.chart1.Size = new System.Drawing.Size(600, 300);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            // 
            // lvStockState
            // 
            this.lvStockState.HideSelection = false;
            this.lvStockState.Location = new System.Drawing.Point(4, 331);
            this.lvStockState.Name = "lvStockState";
            this.lvStockState.Size = new System.Drawing.Size(600, 172);
            this.lvStockState.TabIndex = 1;
            this.lvStockState.UseCompatibleStateImageBehavior = false;
            // 
            // lvUserState
            // 
            this.lvUserState.HideSelection = false;
            this.lvUserState.Location = new System.Drawing.Point(4, 18);
            this.lvUserState.Name = "lvUserState";
            this.lvUserState.Size = new System.Drawing.Size(600, 148);
            this.lvUserState.TabIndex = 3;
            this.lvUserState.UseCompatibleStateImageBehavior = false;
            // 
            // groupBoxStockData
            // 
            this.groupBoxStockData.Controls.Add(this.lvStockState);
            this.groupBoxStockData.Controls.Add(this.chart1);
            this.groupBoxStockData.Location = new System.Drawing.Point(12, 190);
            this.groupBoxStockData.Name = "groupBoxStockData";
            this.groupBoxStockData.Size = new System.Drawing.Size(610, 509);
            this.groupBoxStockData.TabIndex = 5;
            this.groupBoxStockData.TabStop = false;
            this.groupBoxStockData.Text = "현재 주가 정보";
            // 
            // groupBoxUserData
            // 
            this.groupBoxUserData.Controls.Add(this.lvUserState);
            this.groupBoxUserData.Location = new System.Drawing.Point(12, 12);
            this.groupBoxUserData.Name = "groupBoxUserData";
            this.groupBoxUserData.Size = new System.Drawing.Size(610, 172);
            this.groupBoxUserData.TabIndex = 6;
            this.groupBoxUserData.TabStop = false;
            this.groupBoxUserData.Text = "유저 정보";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(634, 521);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(298, 49);
            this.button1.TabIndex = 7;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // groupBoxRank
            // 
            this.groupBoxRank.Controls.Add(this.lvUserRanking);
            this.groupBoxRank.Location = new System.Drawing.Point(628, 12);
            this.groupBoxRank.Name = "groupBoxRank";
            this.groupBoxRank.Size = new System.Drawing.Size(304, 172);
            this.groupBoxRank.TabIndex = 8;
            this.groupBoxRank.TabStop = false;
            this.groupBoxRank.Text = "유저 랭킹";
            // 
            // lvUserRanking
            // 
            this.lvUserRanking.HideSelection = false;
            this.lvUserRanking.Location = new System.Drawing.Point(6, 20);
            this.lvUserRanking.Name = "lvUserRanking";
            this.lvUserRanking.Size = new System.Drawing.Size(292, 146);
            this.lvUserRanking.TabIndex = 0;
            this.lvUserRanking.UseCompatibleStateImageBehavior = false;
            // 
            // groupBoxServerInfo
            // 
            this.groupBoxServerInfo.Controls.Add(this.rtbServerState);
            this.groupBoxServerInfo.Location = new System.Drawing.Point(628, 190);
            this.groupBoxServerInfo.Name = "groupBoxServerInfo";
            this.groupBoxServerInfo.Size = new System.Drawing.Size(304, 320);
            this.groupBoxServerInfo.TabIndex = 9;
            this.groupBoxServerInfo.TabStop = false;
            this.groupBoxServerInfo.Text = "서버 상태";
            // 
            // rtbServerState
            // 
            this.rtbServerState.Location = new System.Drawing.Point(6, 20);
            this.rtbServerState.Name = "rtbServerState";
            this.rtbServerState.ReadOnly = true;
            this.rtbServerState.Size = new System.Drawing.Size(292, 294);
            this.rtbServerState.TabIndex = 0;
            this.rtbServerState.Text = "";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(944, 711);
            this.Controls.Add(this.groupBoxServerInfo);
            this.Controls.Add(this.groupBoxRank);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBoxUserData);
            this.Controls.Add(this.groupBoxStockData);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "GAZUA - Server";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.groupBoxStockData.ResumeLayout(false);
            this.groupBoxUserData.ResumeLayout(false);
            this.groupBoxRank.ResumeLayout(false);
            this.groupBoxServerInfo.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.ListView lvStockState;
        private System.Windows.Forms.ListView lvUserState;
        private System.Windows.Forms.GroupBox groupBoxStockData;
        private System.Windows.Forms.GroupBox groupBoxUserData;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBoxRank;
        private System.Windows.Forms.ListView lvUserRanking;
        private System.Windows.Forms.GroupBox groupBoxServerInfo;
        private System.Windows.Forms.RichTextBox rtbServerState;
    }
}

