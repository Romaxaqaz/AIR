namespace TPL_Lab
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.BSA_Result = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.BSA_STOP = new System.Windows.Forms.Button();
            this.StartBestSampleAlgorithm = new System.Windows.Forms.Button();
            this.BSA_ProgressBar = new System.Windows.Forms.ProgressBar();
            this.BSA_FunctionText = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.progressBar2 = new System.Windows.Forms.ProgressBar();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.Start_All = new System.Windows.Forms.Button();
            this.Stop_All_Button = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.BSA_Result);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.BSA_STOP);
            this.groupBox1.Controls.Add(this.StartBestSampleAlgorithm);
            this.groupBox1.Controls.Add(this.BSA_ProgressBar);
            this.groupBox1.Controls.Add(this.BSA_FunctionText);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(188, 273);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Рома";
            // 
            // BSA_Result
            // 
            this.BSA_Result.AutoSize = true;
            this.BSA_Result.Location = new System.Drawing.Point(6, 188);
            this.BSA_Result.Name = "BSA_Result";
            this.BSA_Result.Size = new System.Drawing.Size(21, 13);
            this.BSA_Result.TabIndex = 7;
            this.BSA_Result.Text = "res";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 165);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Результат:";
            // 
            // BSA_STOP
            // 
            this.BSA_STOP.Location = new System.Drawing.Point(90, 127);
            this.BSA_STOP.Name = "BSA_STOP";
            this.BSA_STOP.Size = new System.Drawing.Size(75, 23);
            this.BSA_STOP.TabIndex = 5;
            this.BSA_STOP.Text = "Очистить";
            this.BSA_STOP.UseVisualStyleBackColor = true;
            // 
            // StartBestSampleAlgorithm
            // 
            this.StartBestSampleAlgorithm.Location = new System.Drawing.Point(9, 127);
            this.StartBestSampleAlgorithm.Name = "StartBestSampleAlgorithm";
            this.StartBestSampleAlgorithm.Size = new System.Drawing.Size(75, 23);
            this.StartBestSampleAlgorithm.TabIndex = 4;
            this.StartBestSampleAlgorithm.Text = "Старт";
            this.StartBestSampleAlgorithm.UseVisualStyleBackColor = true;
            this.StartBestSampleAlgorithm.Click += new System.EventHandler(this.StartBestSampleAlgorithm_Click);
            // 
            // BSA_ProgressBar
            // 
            this.BSA_ProgressBar.Location = new System.Drawing.Point(9, 97);
            this.BSA_ProgressBar.Name = "BSA_ProgressBar";
            this.BSA_ProgressBar.Size = new System.Drawing.Size(173, 23);
            this.BSA_ProgressBar.TabIndex = 3;
            // 
            // BSA_FunctionText
            // 
            this.BSA_FunctionText.Location = new System.Drawing.Point(9, 71);
            this.BSA_FunctionText.Name = "BSA_FunctionText";
            this.BSA_FunctionText.Size = new System.Drawing.Size(173, 20);
            this.BSA_FunctionText.TabIndex = 2;
            this.BSA_FunctionText.Text = "POW(y-POW(x,2),2) + POW(1-x,2)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Функция: ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(139, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Метод - Наилучшей пробы";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.button2);
            this.groupBox2.Controls.Add(this.progressBar1);
            this.groupBox2.Controls.Add(this.textBox1);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(206, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(205, 273);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Илья";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(3, 165);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(62, 13);
            this.label8.TabIndex = 10;
            this.label8.Text = "Результат:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(87, 127);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 9;
            this.button1.Text = "Очистить";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(6, 127);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 8;
            this.button2.Text = "Старт";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(6, 97);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(193, 23);
            this.progressBar1.TabIndex = 7;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(9, 71);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(190, 20);
            this.textBox1.TabIndex = 4;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 55);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 13);
            this.label6.TabIndex = 3;
            this.label6.Text = "Функция: ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 28);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Метод ";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.button3);
            this.groupBox3.Controls.Add(this.button4);
            this.groupBox3.Controls.Add(this.progressBar2);
            this.groupBox3.Controls.Add(this.textBox2);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Location = new System.Drawing.Point(417, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(205, 273);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Антон";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 165);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(62, 13);
            this.label9.TabIndex = 10;
            this.label9.Text = "Результат:";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(90, 127);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 9;
            this.button3.Text = "Очистить";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(9, 127);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 8;
            this.button4.Text = "Старт";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // progressBar2
            // 
            this.progressBar2.Location = new System.Drawing.Point(9, 97);
            this.progressBar2.Name = "progressBar2";
            this.progressBar2.Size = new System.Drawing.Size(190, 23);
            this.progressBar2.TabIndex = 7;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(9, 71);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(190, 20);
            this.textBox2.TabIndex = 4;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 55);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 13);
            this.label7.TabIndex = 3;
            this.label7.Text = "Функция: ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 28);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(39, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "Метод";
            // 
            // Start_All
            // 
            this.Start_All.Location = new System.Drawing.Point(628, 21);
            this.Start_All.Name = "Start_All";
            this.Start_All.Size = new System.Drawing.Size(151, 23);
            this.Start_All.TabIndex = 3;
            this.Start_All.Text = "Запустить все";
            this.Start_All.UseVisualStyleBackColor = true;
            this.Start_All.Click += new System.EventHandler(this.Start_All_Click);
            // 
            // Stop_All_Button
            // 
            this.Stop_All_Button.Location = new System.Drawing.Point(628, 50);
            this.Stop_All_Button.Name = "Stop_All_Button";
            this.Stop_All_Button.Size = new System.Drawing.Size(151, 23);
            this.Stop_All_Button.TabIndex = 4;
            this.Stop_All_Button.Text = "Очистить все";
            this.Stop_All_Button.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(791, 422);
            this.Controls.Add(this.Stop_All_Button);
            this.Controls.Add(this.Start_All);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label BSA_Result;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button BSA_STOP;
        private System.Windows.Forms.Button StartBestSampleAlgorithm;
        private System.Windows.Forms.ProgressBar BSA_ProgressBar;
        private System.Windows.Forms.TextBox BSA_FunctionText;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.ProgressBar progressBar2;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button Start_All;
        private System.Windows.Forms.Button Stop_All_Button;
    }
}

