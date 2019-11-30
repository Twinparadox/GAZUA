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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.lvMyState = new System.Windows.Forms.ListView();
            this.groupBoxMyData = new System.Windows.Forms.GroupBox();
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
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.tabSell = new System.Windows.Forms.TabPage();
            this.button2 = new System.Windows.Forms.Button();
            this.chartStock = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnTurnOver = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.label1 = new System.Windows.Forms.Label();
            this.tbGold = new System.Windows.Forms.TextBox();
            this.tb = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
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
            this.groupBoxMyData.Controls.Add(this.tb);
            this.groupBoxMyData.Controls.Add(this.label3);
            this.groupBoxMyData.Controls.Add(this.tbGold);
            this.groupBoxMyData.Controls.Add(this.label1);
            this.groupBoxMyData.Controls.Add(this.lvMyState);
            this.groupBoxMyData.Location = new System.Drawing.Point(12, 497);
            this.groupBoxMyData.Name = "groupBoxMyData";
            this.groupBoxMyData.Size = new System.Drawing.Size(610, 172);
            this.groupBoxMyData.TabIndex = 9;
            this.groupBoxMyData.TabStop = false;
            this.groupBoxMyData.Text = "내 정보";
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
            this.tabBuy.Controls.Add(this.listView1);
            this.tabBuy.Controls.Add(this.label2);
            this.tabBuy.Controls.Add(this.button1);
            this.tabBuy.Location = new System.Drawing.Point(4, 22);
            this.tabBuy.Name = "tabBuy";
            this.tabBuy.Padding = new System.Windows.Forms.Padding(3);
            this.tabBuy.Size = new System.Drawing.Size(290, 115);
            this.tabBuy.TabIndex = 0;
            this.tabBuy.Text = "매수";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "label2";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(165, 73);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(120, 35);
            this.button1.TabIndex = 0;
            this.button1.Text = "매수";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // tabSell
            // 
            this.tabSell.BackColor = System.Drawing.SystemColors.Control;
            this.tabSell.Controls.Add(this.button2);
            this.tabSell.Location = new System.Drawing.Point(4, 22);
            this.tabSell.Name = "tabSell";
            this.tabSell.Padding = new System.Windows.Forms.Padding(3);
            this.tabSell.Size = new System.Drawing.Size(290, 115);
            this.tabSell.TabIndex = 1;
            this.tabSell.Text = "매도";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(165, 73);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(120, 35);
            this.button2.TabIndex = 1;
            this.button2.Text = "매도";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // chartStock
            // 
            chartArea1.AxisX.MajorGrid.LineWidth = 0;
            chartArea1.AxisY.MajorGrid.LineWidth = 0;
            chartArea1.Name = "ChartArea1";
            this.chartStock.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartStock.Legends.Add(legend1);
            this.chartStock.Location = new System.Drawing.Point(6, 20);
            this.chartStock.Name = "chartStock";
            this.chartStock.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.None;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            series1.YValuesPerPoint = 2;
            this.chartStock.Series.Add(series1);
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
            // listView1
            // 
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(6, 6);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(278, 45);
            this.listView1.TabIndex = 4;
            this.listView1.UseCompatibleStateImageBehavior = false;
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
            // tbGold
            // 
            this.tbGold.Font = new System.Drawing.Font("굴림", 11F);
            this.tbGold.Location = new System.Drawing.Point(79, 29);
            this.tbGold.Name = "tbGold";
            this.tbGold.ReadOnly = true;
            this.tbGold.Size = new System.Drawing.Size(100, 24);
            this.tbGold.TabIndex = 5;
            // 
            // tb
            // 
            this.tb.Font = new System.Drawing.Font("굴림", 11F);
            this.tb.Location = new System.Drawing.Point(289, 29);
            this.tb.Name = "tb";
            this.tb.ReadOnly = true;
            this.tb.Size = new System.Drawing.Size(100, 24);
            this.tb.TabIndex = 7;
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
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(944, 681);
            this.Controls.Add(this.btnTurnOver);
            this.Controls.Add(this.groupBoxStockData);
            this.Controls.Add(this.groupBoxMyData);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "GAZUA - Client";
            this.groupBoxMyData.ResumeLayout(false);
            this.groupBoxMyData.PerformLayout();
            this.groupBoxStockData.ResumeLayout(false);
            this.tcTrade.ResumeLayout(false);
            this.tabBuy.ResumeLayout(false);
            this.tabBuy.PerformLayout();
            this.tabSell.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartStock)).EndInit();
            this.ResumeLayout(false);

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
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TabPage tabSell;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnTurnOver;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbGold;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.TextBox tb;
        private System.Windows.Forms.Label label3;
    }
}

