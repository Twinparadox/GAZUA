namespace GAZUAClient
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
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.lvMyState = new System.Windows.Forms.ListView();
            this.groupBoxMyData = new System.Windows.Forms.GroupBox();
            this.tbEarningRate = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbAssets = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbMoney = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lvStockState = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnStockName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnPrice = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnSub = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnSubRatio = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHigh = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnLow = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBoxStockData = new System.Windows.Forms.GroupBox();
            this.tcTrade = new System.Windows.Forms.TabControl();
            this.tabBuy = new System.Windows.Forms.TabPage();
            this.tbBuy = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbBuyPrice = new System.Windows.Forms.TextBox();
            this.btnMaxBuy = new System.Windows.Forms.Button();
            this.lbPrice = new System.Windows.Forms.Label();
            this.btnBuy = new System.Windows.Forms.Button();
            this.tabSell = new System.Windows.Forms.TabPage();
            this.tbSell = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbSellPrice = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnMaxSell = new System.Windows.Forms.Button();
            this.btnSell = new System.Windows.Forms.Button();
            this.chartStock = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnTurnOver = new System.Windows.Forms.Button();
            this.btnRanking = new System.Windows.Forms.Button();
            this.btnConnect = new System.Windows.Forms.Button();
            this.tbPort = new System.Windows.Forms.TextBox();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStrip();
            this.tbNickName = new System.Windows.Forms.TextBox();
            this.groupBoxMyData.SuspendLayout();
            this.groupBoxStockData.SuspendLayout();
            this.tcTrade.SuspendLayout();
            this.tabBuy.SuspendLayout();
            this.tabSell.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartStock)).BeginInit();
            this.SuspendLayout();
            // 
            // lvMyState
            // 
            this.lvMyState.HideSelection = false;
            this.lvMyState.Location = new System.Drawing.Point(4, 59);
            this.lvMyState.Name = "lvMyState";
            this.lvMyState.Size = new System.Drawing.Size(600, 107);
            this.lvMyState.TabIndex = 3;
            this.lvMyState.UseCompatibleStateImageBehavior = false;
            // 
            // groupBoxMyData
            // 
            this.groupBoxMyData.Controls.Add(this.tbEarningRate);
            this.groupBoxMyData.Controls.Add(this.label4);
            this.groupBoxMyData.Controls.Add(this.tbAssets);
            this.groupBoxMyData.Controls.Add(this.label3);
            this.groupBoxMyData.Controls.Add(this.tbMoney);
            this.groupBoxMyData.Controls.Add(this.label1);
            this.groupBoxMyData.Controls.Add(this.lvMyState);
            this.groupBoxMyData.Location = new System.Drawing.Point(12, 497);
            this.groupBoxMyData.Name = "groupBoxMyData";
            this.groupBoxMyData.Size = new System.Drawing.Size(610, 172);
            this.groupBoxMyData.TabIndex = 9;
            this.groupBoxMyData.TabStop = false;
            this.groupBoxMyData.Text = "내 정보";
            // 
            // tbEarningRate
            // 
            this.tbEarningRate.Font = new System.Drawing.Font("굴림", 11F);
            this.tbEarningRate.Location = new System.Drawing.Point(504, 29);
            this.tbEarningRate.Name = "tbEarningRate";
            this.tbEarningRate.ReadOnly = true;
            this.tbEarningRate.Size = new System.Drawing.Size(100, 24);
            this.tbEarningRate.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("굴림", 11F);
            this.label4.Location = new System.Drawing.Point(446, 32);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 15);
            this.label4.TabIndex = 8;
            this.label4.Text = "수익률";
            // 
            // tbAssets
            // 
            this.tbAssets.Font = new System.Drawing.Font("굴림", 11F);
            this.tbAssets.Location = new System.Drawing.Point(289, 29);
            this.tbAssets.Name = "tbAssets";
            this.tbAssets.ReadOnly = true;
            this.tbAssets.Size = new System.Drawing.Size(100, 24);
            this.tbAssets.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("굴림", 11F);
            this.label3.Location = new System.Drawing.Point(216, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 15);
            this.label3.TabIndex = 6;
            this.label3.Text = "보유자산";
            // 
            // tbMoney
            // 
            this.tbMoney.Font = new System.Drawing.Font("굴림", 11F);
            this.tbMoney.Location = new System.Drawing.Point(79, 29);
            this.tbMoney.Name = "tbMoney";
            this.tbMoney.ReadOnly = true;
            this.tbMoney.Size = new System.Drawing.Size(100, 24);
            this.tbMoney.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("굴림", 11F);
            this.label1.Location = new System.Drawing.Point(6, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 15);
            this.label1.TabIndex = 4;
            this.label1.Text = "보유현금";
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
            this.lvStockState.Location = new System.Drawing.Point(6, 332);
            this.lvStockState.Name = "lvStockState";
            this.lvStockState.ShowItemToolTips = true;
            this.lvStockState.Size = new System.Drawing.Size(600, 141);
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
            // groupBoxStockData
            // 
            this.groupBoxStockData.Controls.Add(this.tcTrade);
            this.groupBoxStockData.Controls.Add(this.chartStock);
            this.groupBoxStockData.Controls.Add(this.lvStockState);
            this.groupBoxStockData.Location = new System.Drawing.Point(16, 12);
            this.groupBoxStockData.Name = "groupBoxStockData";
            this.groupBoxStockData.Size = new System.Drawing.Size(916, 479);
            this.groupBoxStockData.TabIndex = 11;
            this.groupBoxStockData.TabStop = false;
            this.groupBoxStockData.Text = "현재 주가 정보";
            // 
            // tcTrade
            // 
            this.tcTrade.Controls.Add(this.tabBuy);
            this.tcTrade.Controls.Add(this.tabSell);
            this.tcTrade.Location = new System.Drawing.Point(612, 332);
            this.tcTrade.Name = "tcTrade";
            this.tcTrade.SelectedIndex = 0;
            this.tcTrade.Size = new System.Drawing.Size(298, 141);
            this.tcTrade.TabIndex = 3;
            // 
            // tabBuy
            // 
            this.tabBuy.BackColor = System.Drawing.SystemColors.Control;
            this.tabBuy.Controls.Add(this.tbBuy);
            this.tabBuy.Controls.Add(this.label2);
            this.tabBuy.Controls.Add(this.tbBuyPrice);
            this.tabBuy.Controls.Add(this.btnMaxBuy);
            this.tabBuy.Controls.Add(this.lbPrice);
            this.tabBuy.Controls.Add(this.btnBuy);
            this.tabBuy.Location = new System.Drawing.Point(4, 22);
            this.tabBuy.Name = "tabBuy";
            this.tabBuy.Padding = new System.Windows.Forms.Padding(3);
            this.tabBuy.Size = new System.Drawing.Size(290, 115);
            this.tabBuy.TabIndex = 0;
            this.tabBuy.Text = "매수";
            // 
            // tbBuy
            // 
            this.tbBuy.Location = new System.Drawing.Point(95, 35);
            this.tbBuy.Name = "tbBuy";
            this.tbBuy.Size = new System.Drawing.Size(189, 21);
            this.tbBuy.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 12);
            this.label2.TabIndex = 6;
            this.label2.Text = "매수량(주)";
            // 
            // tbBuyPrice
            // 
            this.tbBuyPrice.Location = new System.Drawing.Point(94, 6);
            this.tbBuyPrice.Name = "tbBuyPrice";
            this.tbBuyPrice.ReadOnly = true;
            this.tbBuyPrice.Size = new System.Drawing.Size(190, 21);
            this.tbBuyPrice.TabIndex = 5;
            // 
            // btnMaxBuy
            // 
            this.btnMaxBuy.Location = new System.Drawing.Point(3, 77);
            this.btnMaxBuy.Name = "btnMaxBuy";
            this.btnMaxBuy.Size = new System.Drawing.Size(120, 35);
            this.btnMaxBuy.TabIndex = 4;
            this.btnMaxBuy.Text = "최대수량";
            this.btnMaxBuy.UseVisualStyleBackColor = true;
            this.btnMaxBuy.Click += new System.EventHandler(this.btnMaxBuy_Click);
            // 
            // lbPrice
            // 
            this.lbPrice.AutoSize = true;
            this.lbPrice.Location = new System.Drawing.Point(6, 9);
            this.lbPrice.Name = "lbPrice";
            this.lbPrice.Size = new System.Drawing.Size(57, 12);
            this.lbPrice.TabIndex = 3;
            this.lbPrice.Text = "현재 주가";
            // 
            // btnBuy
            // 
            this.btnBuy.Location = new System.Drawing.Point(167, 77);
            this.btnBuy.Name = "btnBuy";
            this.btnBuy.Size = new System.Drawing.Size(120, 35);
            this.btnBuy.TabIndex = 0;
            this.btnBuy.Text = "매수";
            this.btnBuy.UseVisualStyleBackColor = true;
            this.btnBuy.Click += new System.EventHandler(this.btnBuy_Click);
            // 
            // tabSell
            // 
            this.tabSell.BackColor = System.Drawing.SystemColors.Control;
            this.tabSell.Controls.Add(this.tbSell);
            this.tabSell.Controls.Add(this.label5);
            this.tabSell.Controls.Add(this.tbSellPrice);
            this.tabSell.Controls.Add(this.label6);
            this.tabSell.Controls.Add(this.btnMaxSell);
            this.tabSell.Controls.Add(this.btnSell);
            this.tabSell.Location = new System.Drawing.Point(4, 22);
            this.tabSell.Name = "tabSell";
            this.tabSell.Padding = new System.Windows.Forms.Padding(3);
            this.tabSell.Size = new System.Drawing.Size(290, 115);
            this.tabSell.TabIndex = 1;
            this.tabSell.Text = "매도";
            // 
            // tbSell
            // 
            this.tbSell.Location = new System.Drawing.Point(94, 35);
            this.tbSell.Name = "tbSell";
            this.tbSell.Size = new System.Drawing.Size(189, 21);
            this.tbSell.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 44);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 12);
            this.label5.TabIndex = 10;
            this.label5.Text = "매수량(주)";
            // 
            // tbSellPrice
            // 
            this.tbSellPrice.Location = new System.Drawing.Point(94, 6);
            this.tbSellPrice.Name = "tbSellPrice";
            this.tbSellPrice.ReadOnly = true;
            this.tbSellPrice.Size = new System.Drawing.Size(190, 21);
            this.tbSellPrice.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(57, 12);
            this.label6.TabIndex = 8;
            this.label6.Text = "현재 주가";
            // 
            // btnMaxSell
            // 
            this.btnMaxSell.Location = new System.Drawing.Point(3, 77);
            this.btnMaxSell.Name = "btnMaxSell";
            this.btnMaxSell.Size = new System.Drawing.Size(120, 35);
            this.btnMaxSell.TabIndex = 5;
            this.btnMaxSell.Text = "최대수량";
            this.btnMaxSell.UseVisualStyleBackColor = true;
            this.btnMaxSell.Click += new System.EventHandler(this.btnMaxSell_Click);
            // 
            // btnSell
            // 
            this.btnSell.Location = new System.Drawing.Point(167, 77);
            this.btnSell.Name = "btnSell";
            this.btnSell.Size = new System.Drawing.Size(120, 35);
            this.btnSell.TabIndex = 1;
            this.btnSell.Text = "매도";
            this.btnSell.UseVisualStyleBackColor = true;
            this.btnSell.Click += new System.EventHandler(this.btnSell_Click);
            // 
            // chartStock
            // 
            chartArea2.AxisX.MajorGrid.LineWidth = 0;
            chartArea2.AxisY.MajorGrid.LineWidth = 0;
            chartArea2.Name = "ChartArea1";
            this.chartStock.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chartStock.Legends.Add(legend2);
            this.chartStock.Location = new System.Drawing.Point(6, 20);
            this.chartStock.Name = "chartStock";
            this.chartStock.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.None;
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            series2.YValuesPerPoint = 2;
            this.chartStock.Series.Add(series2);
            this.chartStock.Size = new System.Drawing.Size(904, 306);
            this.chartStock.TabIndex = 2;
            this.chartStock.Text = "chart1";
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(0, 0);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(200, 100);
            this.tabPage2.TabIndex = 0;
            this.tabPage2.Text = "tabPage2";
            // 
            // btnTurnOver
            // 
            this.btnTurnOver.Location = new System.Drawing.Point(812, 628);
            this.btnTurnOver.Name = "btnTurnOver";
            this.btnTurnOver.Size = new System.Drawing.Size(120, 35);
            this.btnTurnOver.TabIndex = 12;
            this.btnTurnOver.Text = "턴 종료";
            this.btnTurnOver.UseVisualStyleBackColor = true;
            this.btnTurnOver.Click += new System.EventHandler(this.btnTurnOver_Click);
            // 
            // btnRanking
            // 
            this.btnRanking.Location = new System.Drawing.Point(628, 628);
            this.btnRanking.Name = "btnRanking";
            this.btnRanking.Size = new System.Drawing.Size(120, 35);
            this.btnRanking.TabIndex = 13;
            this.btnRanking.Text = "랭킹";
            this.btnRanking.UseVisualStyleBackColor = true;
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(812, 498);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(120, 35);
            this.btnConnect.TabIndex = 14;
            this.btnConnect.Text = "서버 접속";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // tbPort
            // 
            this.tbPort.Font = new System.Drawing.Font("굴림", 18F);
            this.tbPort.Location = new System.Drawing.Point(628, 498);
            this.tbPort.Name = "tbPort";
            this.tbPort.Size = new System.Drawing.Size(162, 35);
            this.tbPort.TabIndex = 15;
            this.tbPort.Text = "5000";
            this.tbPort.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbPort_KeyPress);
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStripStatusLabel.Location = new System.Drawing.Point(0, 0);
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(944, 25);
            this.toolStripStatusLabel.TabIndex = 16;
            // 
            // tbNickName
            // 
            this.tbNickName.Font = new System.Drawing.Font("굴림", 18F);
            this.tbNickName.Location = new System.Drawing.Point(628, 539);
            this.tbNickName.Name = "tbNickName";
            this.tbNickName.Size = new System.Drawing.Size(162, 35);
            this.tbNickName.TabIndex = 17;
            this.tbNickName.Text = "5000";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(944, 681);
            this.Controls.Add(this.tbNickName);
            this.Controls.Add(this.toolStripStatusLabel);
            this.Controls.Add(this.tbPort);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.btnRanking);
            this.Controls.Add(this.btnTurnOver);
            this.Controls.Add(this.groupBoxStockData);
            this.Controls.Add(this.groupBoxMyData);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "GAZUA - Client";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.groupBoxMyData.ResumeLayout(false);
            this.groupBoxMyData.PerformLayout();
            this.groupBoxStockData.ResumeLayout(false);
            this.tcTrade.ResumeLayout(false);
            this.tabBuy.ResumeLayout(false);
            this.tabBuy.PerformLayout();
            this.tabSell.ResumeLayout(false);
            this.tabSell.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartStock)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListView lvMyState;
        private System.Windows.Forms.GroupBox groupBoxMyData;
        private System.Windows.Forms.ListView lvStockState;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnStockName;
        private System.Windows.Forms.ColumnHeader columnPrice;
        private System.Windows.Forms.ColumnHeader columnSub;
        private System.Windows.Forms.ColumnHeader columnSubRatio;
        private System.Windows.Forms.ColumnHeader columnHigh;
        private System.Windows.Forms.ColumnHeader columnLow;
        private System.Windows.Forms.GroupBox groupBoxStockData;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartStock;
        private System.Windows.Forms.TabControl tcTrade;
        private System.Windows.Forms.TabPage tabBuy;
        private System.Windows.Forms.Button btnBuy;
        private System.Windows.Forms.TabPage tabSell;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button btnSell;
        private System.Windows.Forms.Button btnTurnOver;
        private System.Windows.Forms.Label lbPrice;
        private System.Windows.Forms.TextBox tbMoney;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbAssets;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbEarningRate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnMaxBuy;
        private System.Windows.Forms.Button btnMaxSell;
        private System.Windows.Forms.Button btnRanking;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.TextBox tbPort;
        private System.Windows.Forms.ToolStrip toolStripStatusLabel;
        private System.Windows.Forms.TextBox tbNickName;
        private System.Windows.Forms.TextBox tbBuy;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbBuyPrice;
        private System.Windows.Forms.TextBox tbSell;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbSellPrice;
        private System.Windows.Forms.Label label6;
    }
}

