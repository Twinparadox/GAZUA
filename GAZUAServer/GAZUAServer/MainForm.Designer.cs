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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chartStock = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.lvStockState = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnStockName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnPrice = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnSub = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnSubRatio = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHigh = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnLow = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lvUserState = new System.Windows.Forms.ListView();
            this.groupBoxStockData = new System.Windows.Forms.GroupBox();
            this.groupBoxUserData = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBoxRank = new System.Windows.Forms.GroupBox();
            this.lvUserRanking = new System.Windows.Forms.ListView();
            this.groupBoxServerInfo = new System.Windows.Forms.GroupBox();
            this.rtbServerState = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.chartStock)).BeginInit();
            this.groupBoxStockData.SuspendLayout();
            this.groupBoxUserData.SuspendLayout();
            this.groupBoxRank.SuspendLayout();
            this.groupBoxServerInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // chartStock
            // 
            chartArea1.Name = "ChartArea1";
            this.chartStock.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartStock.Legends.Add(legend1);
            this.chartStock.Location = new System.Drawing.Point(4, 20);
            this.chartStock.Name = "chartStock";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chartStock.Series.Add(series1);
            this.chartStock.Size = new System.Drawing.Size(600, 300);
            this.chartStock.TabIndex = 0;
            this.chartStock.Text = "chart1";
            this.chartStock.Click += new System.EventHandler(this.chart1_Click);
            // 
            // lvStockState
            // 
            this.lvStockState.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnStockName,
            this.columnPrice,
            this.columnSub,
            this.columnSubRatio,
            this.columnHigh,
            this.columnLow});
            this.lvStockState.FullRowSelect = true;
            this.lvStockState.GridLines = true;
            this.lvStockState.HideSelection = false;
            this.lvStockState.Location = new System.Drawing.Point(4, 331);
            this.lvStockState.Name = "lvStockState";
            this.lvStockState.ShowItemToolTips = true;
            this.lvStockState.Size = new System.Drawing.Size(600, 172);
            this.lvStockState.TabIndex = 1;
            this.lvStockState.UseCompatibleStateImageBehavior = false;
            this.lvStockState.View = System.Windows.Forms.View.Details;
            this.lvStockState.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lvStockState_MouseDoubleClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Width = 0;
            // 
            // columnStockName
            // 
            this.columnStockName.Tag = "";
            this.columnStockName.Text = "기업명";
            this.columnStockName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnStockName.Width = 145;
            // 
            // columnPrice
            // 
            this.columnPrice.Text = "현재가";
            this.columnPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnPrice.Width = 100;
            // 
            // columnSub
            // 
            this.columnSub.Text = "전일비";
            this.columnSub.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnSub.Width = 100;
            // 
            // columnSubRatio
            // 
            this.columnSubRatio.Text = "등락률";
            this.columnSubRatio.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnSubRatio.Width = 50;
            // 
            // columnHigh
            // 
            this.columnHigh.Text = "기간 내 고가";
            this.columnHigh.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHigh.Width = 100;
            // 
            // columnLow
            // 
            this.columnLow.Text = "기간 내 저가";
            this.columnLow.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnLow.Width = 100;
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
            this.groupBoxStockData.Controls.Add(this.chartStock);
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
            ((System.ComponentModel.ISupportInitialize)(this.chartStock)).EndInit();
            this.groupBoxStockData.ResumeLayout(false);
            this.groupBoxUserData.ResumeLayout(false);
            this.groupBoxRank.ResumeLayout(false);
            this.groupBoxServerInfo.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chartStock;
        private System.Windows.Forms.ListView lvStockState;
        private System.Windows.Forms.ListView lvUserState;
        private System.Windows.Forms.GroupBox groupBoxStockData;
        private System.Windows.Forms.GroupBox groupBoxUserData;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBoxRank;
        private System.Windows.Forms.ListView lvUserRanking;
        private System.Windows.Forms.GroupBox groupBoxServerInfo;
        private System.Windows.Forms.RichTextBox rtbServerState;
        private System.Windows.Forms.ColumnHeader columnStockName;
        private System.Windows.Forms.ColumnHeader columnPrice;
        private System.Windows.Forms.ColumnHeader columnSub;
        private System.Windows.Forms.ColumnHeader columnSubRatio;
        private System.Windows.Forms.ColumnHeader columnHigh;
        private System.Windows.Forms.ColumnHeader columnLow;
        private System.Windows.Forms.ColumnHeader columnHeader1;
    }
}

