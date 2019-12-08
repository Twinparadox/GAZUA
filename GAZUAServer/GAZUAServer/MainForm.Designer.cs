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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
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
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnUserName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnUserMoney = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnUserStock = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnUserAsset = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnReady = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBoxStockData = new System.Windows.Forms.GroupBox();
            this.groupBoxUserData = new System.Windows.Forms.GroupBox();
            this.groupBoxRank = new System.Windows.Forms.GroupBox();
            this.lvUserRanking = new System.Windows.Forms.ListView();
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnRank = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnAsset = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBoxServerInfo = new System.Windows.Forms.GroupBox();
            this.rtbServerState = new System.Windows.Forms.RichTextBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnGameStart = new System.Windows.Forms.Button();
            this.btnListen = new System.Windows.Forms.Button();
            this.btnNextTurn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.chartStock)).BeginInit();
            this.groupBoxStockData.SuspendLayout();
            this.groupBoxUserData.SuspendLayout();
            this.groupBoxRank.SuspendLayout();
            this.groupBoxServerInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // chartStock
            // 
            chartArea2.AxisX.MajorGrid.LineWidth = 0;
            chartArea2.AxisY.MajorGrid.LineWidth = 0;
            chartArea2.Name = "ChartArea1";
            this.chartStock.ChartAreas.Add(chartArea2);
            this.chartStock.Location = new System.Drawing.Point(4, 20);
            this.chartStock.Name = "chartStock";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series2.Name = "Series1";
            this.chartStock.Series.Add(series2);
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
            this.lvStockState.SelectedIndexChanged += new System.EventHandler(this.lvStockState_SelectedIndexChanged);
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
            this.lvUserState.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2,
            this.columnUserName,
            this.columnUserMoney,
            this.columnUserStock,
            this.columnUserAsset,
            this.columnReady});
            this.lvUserState.HideSelection = false;
            this.lvUserState.Location = new System.Drawing.Point(4, 18);
            this.lvUserState.Name = "lvUserState";
            this.lvUserState.ShowItemToolTips = true;
            this.lvUserState.Size = new System.Drawing.Size(600, 148);
            this.lvUserState.TabIndex = 3;
            this.lvUserState.UseCompatibleStateImageBehavior = false;
            this.lvUserState.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Width = 0;
            // 
            // columnUserName
            // 
            this.columnUserName.Text = "ID";
            this.columnUserName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnUserName.Width = 100;
            // 
            // columnUserMoney
            // 
            this.columnUserMoney.Text = "보유자산(현금)";
            this.columnUserMoney.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnUserMoney.Width = 150;
            // 
            // columnUserStock
            // 
            this.columnUserStock.Text = "보유자산(주식)";
            this.columnUserStock.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnUserStock.Width = 150;
            // 
            // columnUserAsset
            // 
            this.columnUserAsset.Text = "보유자산(총액)";
            this.columnUserAsset.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnUserAsset.Width = 150;
            // 
            // columnReady
            // 
            this.columnReady.Text = "상태";
            this.columnReady.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnReady.Width = 45;
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
            this.lvUserRanking.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3,
            this.columnRank,
            this.columnID,
            this.columnAsset});
            this.lvUserRanking.HideSelection = false;
            this.lvUserRanking.Location = new System.Drawing.Point(6, 20);
            this.lvUserRanking.Name = "lvUserRanking";
            this.lvUserRanking.Size = new System.Drawing.Size(292, 146);
            this.lvUserRanking.TabIndex = 0;
            this.lvUserRanking.UseCompatibleStateImageBehavior = false;
            this.lvUserRanking.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Width = 0;
            // 
            // columnRank
            // 
            this.columnRank.Text = "순위";
            this.columnRank.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // columnID
            // 
            this.columnID.Text = "ID";
            this.columnID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnID.Width = 100;
            // 
            // columnAsset
            // 
            this.columnAsset.Text = "자산(천)";
            this.columnAsset.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnAsset.Width = 128;
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
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(787, 521);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(145, 49);
            this.btnClose.TabIndex = 10;
            this.btnClose.Text = "서버 종료";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnGameStart
            // 
            this.btnGameStart.Location = new System.Drawing.Point(628, 632);
            this.btnGameStart.Name = "btnGameStart";
            this.btnGameStart.Size = new System.Drawing.Size(144, 49);
            this.btnGameStart.TabIndex = 11;
            this.btnGameStart.Text = "게임 시작";
            this.btnGameStart.UseVisualStyleBackColor = true;
            this.btnGameStart.Click += new System.EventHandler(this.btnGameStart_Click);
            // 
            // btnListen
            // 
            this.btnListen.Location = new System.Drawing.Point(628, 521);
            this.btnListen.Name = "btnListen";
            this.btnListen.Size = new System.Drawing.Size(145, 49);
            this.btnListen.TabIndex = 7;
            this.btnListen.Text = "서버 시작";
            this.btnListen.UseVisualStyleBackColor = true;
            this.btnListen.Click += new System.EventHandler(this.btnListen_Click);
            // 
            // btnNextTurn
            // 
            this.btnNextTurn.Location = new System.Drawing.Point(787, 632);
            this.btnNextTurn.Name = "btnNextTurn";
            this.btnNextTurn.Size = new System.Drawing.Size(144, 49);
            this.btnNextTurn.TabIndex = 12;
            this.btnNextTurn.Text = "다음 턴 진행";
            this.btnNextTurn.UseVisualStyleBackColor = true;
            this.btnNextTurn.Visible = false;
            this.btnNextTurn.Click += new System.EventHandler(this.btnNextTurn_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(947, 711);
            this.Controls.Add(this.btnNextTurn);
            this.Controls.Add(this.btnGameStart);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.groupBoxServerInfo);
            this.Controls.Add(this.groupBoxRank);
            this.Controls.Add(this.btnListen);
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
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnGameStart;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnUserName;
        private System.Windows.Forms.ColumnHeader columnUserMoney;
        private System.Windows.Forms.ColumnHeader columnUserStock;
        private System.Windows.Forms.ColumnHeader columnUserAsset;
        private System.Windows.Forms.ColumnHeader columnReady;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnRank;
        private System.Windows.Forms.ColumnHeader columnID;
        private System.Windows.Forms.ColumnHeader columnAsset;
        private System.Windows.Forms.Button btnListen;
        private System.Windows.Forms.Button btnNextTurn;
    }
}

