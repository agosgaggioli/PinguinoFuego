namespace UI
{
    partial class FormDashboard
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            dataGridView1 = new DataGridView();
            groupBox1 = new GroupBox();
            button4 = new Button();
            button3 = new Button();
            button2 = new Button();
            groupBox2 = new GroupBox();
            textBox1 = new TextBox();
            dataGridView2 = new DataGridView();
            label5 = new Label();
            chart2 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            groupBox3 = new GroupBox();
            textBox2 = new TextBox();
            label6 = new Label();
            label7 = new Label();
            chart3 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            label8 = new Label();
            groupBox4 = new GroupBox();
            textBox3 = new TextBox();
            ((System.ComponentModel.ISupportInitialize)chart1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)chart2).BeginInit();
            groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)chart3).BeginInit();
            groupBox4.SuspendLayout();
            SuspendLayout();
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            chart1.Legends.Add(legend1);
            chart1.Location = new Point(74, 494);
            chart1.Name = "chart1";
            chart1.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Pastel;
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            chart1.Series.Add(series1);
            chart1.Size = new Size(416, 262);
            chart1.TabIndex = 0;
            chart1.Text = "chart1";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(170, 448);
            label1.Name = "label1";
            label1.Size = new Size(217, 30);
            label1.TabIndex = 1;
            label1.Text = "Ventas por vendedor";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(170, 695);
            label2.Name = "label2";
            label2.Size = new Size(0, 17);
            label2.TabIndex = 2;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(906, 424);
            label3.Name = "label3";
            label3.Size = new Size(0, 15);
            label3.TabIndex = 3;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(242, 9);
            label4.Name = "label4";
            label4.Size = new Size(84, 30);
            label4.TabIndex = 4;
            label4.Text = "Ventas ";
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(12, 42);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(540, 167);
            dataGridView1.TabIndex = 5;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(button4);
            groupBox1.Controls.Add(button3);
            groupBox1.Controls.Add(button2);
            groupBox1.Location = new Point(12, 228);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(540, 76);
            groupBox1.TabIndex = 6;
            groupBox1.TabStop = false;
            groupBox1.Text = "Seccion fechas";
            // 
            // button4
            // 
            button4.Location = new Point(339, 32);
            button4.Name = "button4";
            button4.Size = new Size(107, 26);
            button4.TabIndex = 3;
            button4.Text = "Todas";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // button3
            // 
            button3.Location = new Point(211, 32);
            button3.Name = "button3";
            button3.Size = new Size(107, 26);
            button3.TabIndex = 2;
            button3.Text = "1 año";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button2
            // 
            button2.Location = new Point(89, 32);
            button2.Name = "button2";
            button2.Size = new Size(107, 26);
            button2.TabIndex = 1;
            button2.Text = "1 mes";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(textBox1);
            groupBox2.Location = new Point(107, 324);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(157, 76);
            groupBox2.TabIndex = 7;
            groupBox2.TabStop = false;
            groupBox2.Text = "Importe Facturado";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(22, 35);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(117, 23);
            textBox1.TabIndex = 0;
            // 
            // dataGridView2
            // 
            dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView2.Location = new Point(682, 42);
            dataGridView2.Name = "dataGridView2";
            dataGridView2.Size = new Size(420, 167);
            dataGridView2.TabIndex = 8;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(814, 9);
            label5.Name = "label5";
            label5.Size = new Size(178, 30);
            label5.TabIndex = 9;
            label5.Text = "Stock Disponible";
            // 
            // chart2
            // 
            chartArea2.Name = "ChartArea1";
            chart2.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            chart2.Legends.Add(legend2);
            chart2.Location = new Point(771, 347);
            chart2.Name = "chart2";
            chart2.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Pastel;
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            chart2.Series.Add(series2);
            chart2.Size = new Size(254, 175);
            chart2.TabIndex = 10;
            chart2.Text = "chart2";
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(textBox2);
            groupBox3.Location = new Point(301, 324);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(157, 76);
            groupBox3.TabIndex = 8;
            groupBox3.TabStop = false;
            groupBox3.Text = "Ventas Totales";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(22, 35);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(117, 23);
            textBox2.TabIndex = 0;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(800, 314);
            label6.Name = "label6";
            label6.Size = new Size(189, 30);
            label6.TabIndex = 11;
            label6.Text = "Ventas por marca:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.Location = new Point(825, 548);
            label7.Name = "label7";
            label7.Size = new Size(167, 30);
            label7.TabIndex = 14;
            label7.Text = "Ventas por año:";
            label7.Click += label7_Click;
            // 
            // chart3
            // 
            chartArea3.Name = "ChartArea1";
            chart3.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            chart3.Legends.Add(legend3);
            chart3.Location = new Point(771, 581);
            chart3.Name = "chart3";
            chart3.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Pastel;
            series3.ChartArea = "ChartArea1";
            series3.Legend = "Legend1";
            series3.Name = "Series1";
            chart3.Series.Add(series3);
            chart3.Size = new Size(254, 175);
            chart3.TabIndex = 13;
            chart3.Text = "chart3";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(906, 658);
            label8.Name = "label8";
            label8.Size = new Size(0, 15);
            label8.TabIndex = 12;
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(textBox3);
            groupBox4.Location = new Point(682, 228);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(428, 76);
            groupBox4.TabIndex = 9;
            groupBox4.TabStop = false;
            groupBox4.Text = "Proveedor mas frecuente";
            // 
            // textBox3
            // 
            textBox3.Location = new Point(22, 35);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(397, 23);
            textBox3.TabIndex = 0;
            // 
            // FormDashboard
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1149, 777);
            Controls.Add(groupBox4);
            Controls.Add(label7);
            Controls.Add(chart3);
            Controls.Add(label8);
            Controls.Add(groupBox3);
            Controls.Add(label6);
            Controls.Add(chart2);
            Controls.Add(label5);
            Controls.Add(dataGridView2);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(dataGridView1);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(chart1);
            Name = "FormDashboard";
            Text = "FormDashboard";
            Load += FormDashboard_Load;
            ((System.ComponentModel.ISupportInitialize)chart1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).EndInit();
            ((System.ComponentModel.ISupportInitialize)chart2).EndInit();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)chart3).EndInit();
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private DataGridView dataGridView1;
        private GroupBox groupBox1;
        private Button button4;
        private Button button3;
        private Button button2;
        private GroupBox groupBox2;
        private TextBox textBox1;
        private DataGridView dataGridView2;
        private Label label5;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart2;
        private GroupBox groupBox3;
        private TextBox textBox2;
        private Label label6;
        private Label label7;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart3;
        private Label label8;
        private GroupBox groupBox4;
        private TextBox textBox3;
    }
}