namespace WindowsFormsAppCalculateLab7
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.firsTextBox = new System.Windows.Forms.TextBox();
            this.secondTextBox = new System.Windows.Forms.TextBox();
            this.thistTextBoxResult = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.radioButton_Summ = new System.Windows.Forms.RadioButton();
            this.radioButton_Vechsty = new System.Windows.Forms.RadioButton();
            this.radioButton_umnojity = new System.Windows.Forms.RadioButton();
            this.radioButton_Razdelit = new System.Windows.Forms.RadioButton();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(42, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Первое число";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(42, 114);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Второе число";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(42, 174);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Результат";
            // 
            // firsTextBox
            // 
            this.firsTextBox.Location = new System.Drawing.Point(151, 41);
            this.firsTextBox.Name = "firsTextBox";
            this.firsTextBox.Size = new System.Drawing.Size(128, 22);
            this.firsTextBox.TabIndex = 3;
            // 
            // secondTextBox
            // 
            this.secondTextBox.Location = new System.Drawing.Point(151, 107);
            this.secondTextBox.Name = "secondTextBox";
            this.secondTextBox.Size = new System.Drawing.Size(128, 22);
            this.secondTextBox.TabIndex = 4;
            // 
            // thistTextBoxResult
            // 
            this.thistTextBoxResult.Location = new System.Drawing.Point(151, 167);
            this.thistTextBoxResult.Name = "thistTextBoxResult";
            this.thistTextBoxResult.Size = new System.Drawing.Size(128, 22);
            this.thistTextBoxResult.TabIndex = 5;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(45, 265);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(234, 41);
            this.button1.TabIndex = 6;
            this.button1.Text = "Вычислить";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // radioButton_Summ
            // 
            this.radioButton_Summ.AutoSize = true;
            this.radioButton_Summ.Location = new System.Drawing.Point(330, 46);
            this.radioButton_Summ.Name = "radioButton_Summ";
            this.radioButton_Summ.Size = new System.Drawing.Size(84, 20);
            this.radioButton_Summ.TabIndex = 8;
            this.radioButton_Summ.TabStop = true;
            this.radioButton_Summ.Text = "Сложить";
            this.radioButton_Summ.UseVisualStyleBackColor = true;
            // 
            // radioButton_Vechsty
            // 
            this.radioButton_Vechsty.AutoSize = true;
            this.radioButton_Vechsty.Location = new System.Drawing.Point(330, 109);
            this.radioButton_Vechsty.Name = "radioButton_Vechsty";
            this.radioButton_Vechsty.Size = new System.Drawing.Size(83, 20);
            this.radioButton_Vechsty.TabIndex = 9;
            this.radioButton_Vechsty.TabStop = true;
            this.radioButton_Vechsty.Text = "Вычесть";
            this.radioButton_Vechsty.UseVisualStyleBackColor = true;
            // 
            // radioButton_umnojity
            // 
            this.radioButton_umnojity.AutoSize = true;
            this.radioButton_umnojity.Location = new System.Drawing.Point(330, 169);
            this.radioButton_umnojity.Name = "radioButton_umnojity";
            this.radioButton_umnojity.Size = new System.Drawing.Size(93, 20);
            this.radioButton_umnojity.TabIndex = 10;
            this.radioButton_umnojity.TabStop = true;
            this.radioButton_umnojity.Text = "Умножить";
            this.radioButton_umnojity.UseVisualStyleBackColor = true;
            // 
            // radioButton_Razdelit
            // 
            this.radioButton_Razdelit.AutoSize = true;
            this.radioButton_Razdelit.Location = new System.Drawing.Point(330, 227);
            this.radioButton_Razdelit.Name = "radioButton_Razdelit";
            this.radioButton_Razdelit.Size = new System.Drawing.Size(99, 20);
            this.radioButton_Razdelit.TabIndex = 11;
            this.radioButton_Razdelit.TabStop = true;
            this.radioButton_Razdelit.Text = "Разделить";
            this.radioButton_Razdelit.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(45, 227);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(239, 20);
            this.checkBox1.TabIndex = 12;
            this.checkBox1.Text = "Выводить результат полностью";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(468, 350);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.radioButton_Razdelit);
            this.Controls.Add(this.radioButton_umnojity);
            this.Controls.Add(this.radioButton_Vechsty);
            this.Controls.Add(this.radioButton_Summ);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.thistTextBoxResult);
            this.Controls.Add(this.secondTextBox);
            this.Controls.Add(this.firsTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox firsTextBox;
        private System.Windows.Forms.TextBox secondTextBox;
        private System.Windows.Forms.TextBox thistTextBoxResult;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RadioButton radioButton_Summ;
        private System.Windows.Forms.RadioButton radioButton_Vechsty;
        private System.Windows.Forms.RadioButton radioButton_umnojity;
        private System.Windows.Forms.RadioButton radioButton_Razdelit;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}

