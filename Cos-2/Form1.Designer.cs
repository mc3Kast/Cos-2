namespace Cos_2
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series6 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chDist = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chAmp = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chPha = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.btAdd = new System.Windows.Forms.Button();
            this.tbA = new System.Windows.Forms.TextBox();
            this.lbA = new System.Windows.Forms.Label();
            this.lbFi0 = new System.Windows.Forms.Label();
            this.tbFi0 = new System.Windows.Forms.TextBox();
            this.lbF = new System.Windows.Forms.Label();
            this.tbF = new System.Windows.Forms.TextBox();
            this.lbD = new System.Windows.Forms.Label();
            this.tbD = new System.Windows.Forms.TextBox();
            this.lbK = new System.Windows.Forms.Label();
            this.tbK = new System.Windows.Forms.TextBox();
            this.lbN = new System.Windows.Forms.Label();
            this.tbN = new System.Windows.Forms.TextBox();
            this.rbCos = new System.Windows.Forms.RadioButton();
            this.rbTrian = new System.Windows.Forms.RadioButton();
            this.rbSin = new System.Windows.Forms.RadioButton();
            this.rbPulse = new System.Windows.Forms.RadioButton();
            this.rbSaw = new System.Windows.Forms.RadioButton();
            this.btClear = new System.Windows.Forms.Button();
            this.chFlower = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.chDist)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chAmp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chPha)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chFlower)).BeginInit();
            this.SuspendLayout();
            // 
            // chDist
            // 
            chartArea1.AxisX.Minimum = 0D;
            chartArea1.Name = "ChartArea1";
            this.chDist.ChartAreas.Add(chartArea1);
            this.chDist.Location = new System.Drawing.Point(1, 318);
            this.chDist.Name = "chDist";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
            series1.Name = "Series1";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
            series2.Name = "Series2";
            this.chDist.Series.Add(series1);
            this.chDist.Series.Add(series2);
            this.chDist.Size = new System.Drawing.Size(477, 401);
            this.chDist.TabIndex = 0;
            this.chDist.Text = "chart1";
            // 
            // chAmp
            // 
            chartArea2.AxisX.Minimum = 0D;
            chartArea2.Name = "ChartArea1";
            this.chAmp.ChartAreas.Add(chartArea2);
            this.chAmp.Location = new System.Drawing.Point(475, 318);
            this.chAmp.Name = "chAmp";
            series3.ChartArea = "ChartArea1";
            series3.Name = "Series1";
            this.chAmp.Series.Add(series3);
            this.chAmp.Size = new System.Drawing.Size(449, 401);
            this.chAmp.TabIndex = 1;
            this.chAmp.Text = "chart2";
            // 
            // chPha
            // 
            chartArea3.AxisX.Minimum = 0D;
            chartArea3.Name = "ChartArea1";
            this.chPha.ChartAreas.Add(chartArea3);
            this.chPha.Location = new System.Drawing.Point(917, 318);
            this.chPha.Name = "chPha";
            series4.ChartArea = "ChartArea1";
            series4.Name = "Series1";
            this.chPha.Series.Add(series4);
            this.chPha.Size = new System.Drawing.Size(449, 401);
            this.chPha.TabIndex = 2;
            this.chPha.Text = "chart3";
            // 
            // btAdd
            // 
            this.btAdd.Location = new System.Drawing.Point(451, 59);
            this.btAdd.Name = "btAdd";
            this.btAdd.Size = new System.Drawing.Size(75, 23);
            this.btAdd.TabIndex = 3;
            this.btAdd.Text = "bip";
            this.btAdd.UseVisualStyleBackColor = true;
            this.btAdd.Click += new System.EventHandler(this.btAdd_Click);
            // 
            // tbA
            // 
            this.tbA.Location = new System.Drawing.Point(12, 28);
            this.tbA.Name = "tbA";
            this.tbA.Size = new System.Drawing.Size(113, 20);
            this.tbA.TabIndex = 4;
            this.tbA.Text = "1";
            this.tbA.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbA_KeyPress);
            // 
            // lbA
            // 
            this.lbA.AutoSize = true;
            this.lbA.Location = new System.Drawing.Point(9, 12);
            this.lbA.Name = "lbA";
            this.lbA.Size = new System.Drawing.Size(17, 13);
            this.lbA.TabIndex = 5;
            this.lbA.Text = "A:";
            // 
            // lbFi0
            // 
            this.lbFi0.AutoSize = true;
            this.lbFi0.Location = new System.Drawing.Point(139, 12);
            this.lbFi0.Name = "lbFi0";
            this.lbFi0.Size = new System.Drawing.Size(21, 13);
            this.lbFi0.TabIndex = 7;
            this.lbFi0.Text = "fi0:";
            // 
            // tbFi0
            // 
            this.tbFi0.Location = new System.Drawing.Point(142, 28);
            this.tbFi0.Name = "tbFi0";
            this.tbFi0.Size = new System.Drawing.Size(113, 20);
            this.tbFi0.TabIndex = 6;
            this.tbFi0.Text = "0";
            this.tbFi0.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbFi0_KeyPress);
            // 
            // lbF
            // 
            this.lbF.AutoSize = true;
            this.lbF.Location = new System.Drawing.Point(9, 80);
            this.lbF.Name = "lbF";
            this.lbF.Size = new System.Drawing.Size(13, 13);
            this.lbF.TabIndex = 9;
            this.lbF.Text = "f:";
            // 
            // tbF
            // 
            this.tbF.Location = new System.Drawing.Point(12, 96);
            this.tbF.Name = "tbF";
            this.tbF.Size = new System.Drawing.Size(113, 20);
            this.tbF.TabIndex = 8;
            this.tbF.Text = "1";
            this.tbF.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbF_KeyPress);
            // 
            // lbD
            // 
            this.lbD.AutoSize = true;
            this.lbD.Location = new System.Drawing.Point(139, 80);
            this.lbD.Name = "lbD";
            this.lbD.Size = new System.Drawing.Size(16, 13);
            this.lbD.TabIndex = 11;
            this.lbD.Text = "d:";
            // 
            // tbD
            // 
            this.tbD.Location = new System.Drawing.Point(142, 96);
            this.tbD.Name = "tbD";
            this.tbD.Size = new System.Drawing.Size(113, 20);
            this.tbD.TabIndex = 10;
            this.tbD.Text = "0.5";
            // 
            // lbK
            // 
            this.lbK.AutoSize = true;
            this.lbK.Location = new System.Drawing.Point(279, 80);
            this.lbK.Name = "lbK";
            this.lbK.Size = new System.Drawing.Size(17, 13);
            this.lbK.TabIndex = 15;
            this.lbK.Text = "K:";
            // 
            // tbK
            // 
            this.tbK.Location = new System.Drawing.Point(282, 96);
            this.tbK.Name = "tbK";
            this.tbK.Size = new System.Drawing.Size(113, 20);
            this.tbK.TabIndex = 14;
            this.tbK.Text = "64";
            this.tbK.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbK_KeyPress);
            // 
            // lbN
            // 
            this.lbN.AutoSize = true;
            this.lbN.Location = new System.Drawing.Point(279, 12);
            this.lbN.Name = "lbN";
            this.lbN.Size = new System.Drawing.Size(18, 13);
            this.lbN.TabIndex = 13;
            this.lbN.Text = "N:";
            // 
            // tbN
            // 
            this.tbN.Location = new System.Drawing.Point(282, 28);
            this.tbN.Name = "tbN";
            this.tbN.Size = new System.Drawing.Size(113, 20);
            this.tbN.TabIndex = 12;
            this.tbN.Text = "128";
            this.tbN.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbN_KeyPress);
            // 
            // rbCos
            // 
            this.rbCos.AutoSize = true;
            this.rbCos.Location = new System.Drawing.Point(12, 146);
            this.rbCos.Name = "rbCos";
            this.rbCos.Size = new System.Drawing.Size(43, 17);
            this.rbCos.TabIndex = 16;
            this.rbCos.TabStop = true;
            this.rbCos.Text = "Cos";
            this.rbCos.UseVisualStyleBackColor = true;
            // 
            // rbTrian
            // 
            this.rbTrian.AutoSize = true;
            this.rbTrian.Location = new System.Drawing.Point(124, 146);
            this.rbTrian.Name = "rbTrian";
            this.rbTrian.Size = new System.Drawing.Size(49, 17);
            this.rbTrian.TabIndex = 17;
            this.rbTrian.TabStop = true;
            this.rbTrian.Text = "Trian";
            this.rbTrian.UseVisualStyleBackColor = true;
            // 
            // rbSin
            // 
            this.rbSin.AutoSize = true;
            this.rbSin.Location = new System.Drawing.Point(12, 185);
            this.rbSin.Name = "rbSin";
            this.rbSin.Size = new System.Drawing.Size(40, 17);
            this.rbSin.TabIndex = 18;
            this.rbSin.TabStop = true;
            this.rbSin.Text = "Sin";
            this.rbSin.UseVisualStyleBackColor = true;
            // 
            // rbPulse
            // 
            this.rbPulse.AutoSize = true;
            this.rbPulse.Location = new System.Drawing.Point(124, 185);
            this.rbPulse.Name = "rbPulse";
            this.rbPulse.Size = new System.Drawing.Size(51, 17);
            this.rbPulse.TabIndex = 19;
            this.rbPulse.TabStop = true;
            this.rbPulse.Text = "Pulse";
            this.rbPulse.UseVisualStyleBackColor = true;
            // 
            // rbSaw
            // 
            this.rbSaw.AutoSize = true;
            this.rbSaw.Location = new System.Drawing.Point(240, 146);
            this.rbSaw.Name = "rbSaw";
            this.rbSaw.Size = new System.Drawing.Size(46, 17);
            this.rbSaw.TabIndex = 20;
            this.rbSaw.TabStop = true;
            this.rbSaw.Text = "Saw";
            this.rbSaw.UseVisualStyleBackColor = true;
            // 
            // btClear
            // 
            this.btClear.Location = new System.Drawing.Point(558, 59);
            this.btClear.Name = "btClear";
            this.btClear.Size = new System.Drawing.Size(75, 23);
            this.btClear.TabIndex = 21;
            this.btClear.Text = "clear";
            this.btClear.UseVisualStyleBackColor = true;
            this.btClear.Click += new System.EventHandler(this.btClear_Click);
            // 
            // chFlower
            // 
            chartArea4.Name = "ChartArea1";
            this.chFlower.ChartAreas.Add(chartArea4);
            this.chFlower.Location = new System.Drawing.Point(953, 12);
            this.chFlower.Name = "chFlower";
            series5.ChartArea = "ChartArea1";
            series5.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
            series5.Name = "Series1";
            series6.ChartArea = "ChartArea1";
            series6.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
            series6.Name = "Series2";
            this.chFlower.Series.Add(series5);
            this.chFlower.Series.Add(series6);
            this.chFlower.Size = new System.Drawing.Size(373, 288);
            this.chFlower.TabIndex = 22;
            this.chFlower.Text = "chart1";
            this.chFlower.TextAntiAliasingQuality = System.Windows.Forms.DataVisualization.Charting.TextAntiAliasingQuality.SystemDefault;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1378, 744);
            this.Controls.Add(this.chFlower);
            this.Controls.Add(this.btClear);
            this.Controls.Add(this.rbSaw);
            this.Controls.Add(this.rbPulse);
            this.Controls.Add(this.rbSin);
            this.Controls.Add(this.rbTrian);
            this.Controls.Add(this.rbCos);
            this.Controls.Add(this.lbK);
            this.Controls.Add(this.tbK);
            this.Controls.Add(this.lbN);
            this.Controls.Add(this.tbN);
            this.Controls.Add(this.lbD);
            this.Controls.Add(this.tbD);
            this.Controls.Add(this.lbF);
            this.Controls.Add(this.tbF);
            this.Controls.Add(this.lbFi0);
            this.Controls.Add(this.tbFi0);
            this.Controls.Add(this.lbA);
            this.Controls.Add(this.tbA);
            this.Controls.Add(this.btAdd);
            this.Controls.Add(this.chPha);
            this.Controls.Add(this.chAmp);
            this.Controls.Add(this.chDist);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.chDist)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chAmp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chPha)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chFlower)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chDist;
        private System.Windows.Forms.DataVisualization.Charting.Chart chAmp;
        private System.Windows.Forms.DataVisualization.Charting.Chart chPha;
        private System.Windows.Forms.Button btAdd;
        private System.Windows.Forms.TextBox tbA;
        private System.Windows.Forms.Label lbA;
        private System.Windows.Forms.Label lbFi0;
        private System.Windows.Forms.TextBox tbFi0;
        private System.Windows.Forms.Label lbF;
        private System.Windows.Forms.TextBox tbF;
        private System.Windows.Forms.Label lbD;
        private System.Windows.Forms.TextBox tbD;
        private System.Windows.Forms.Label lbK;
        private System.Windows.Forms.TextBox tbK;
        private System.Windows.Forms.Label lbN;
        private System.Windows.Forms.TextBox tbN;
        private System.Windows.Forms.RadioButton rbCos;
        private System.Windows.Forms.RadioButton rbTrian;
        private System.Windows.Forms.RadioButton rbSin;
        private System.Windows.Forms.RadioButton rbPulse;
        private System.Windows.Forms.RadioButton rbSaw;
        private System.Windows.Forms.Button btClear;
        private System.Windows.Forms.DataVisualization.Charting.Chart chFlower;
    }
}

