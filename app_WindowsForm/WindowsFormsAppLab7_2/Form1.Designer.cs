namespace WindowsFormsAppLab7_2
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
            this.listBoxLeft = new System.Windows.Forms.ListBox();
            this.listBoxRight = new System.Windows.Forms.ListBox();
            this.textBoxHead = new System.Windows.Forms.TextBox();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.buttonCalculate = new System.Windows.Forms.Button();
            this.buttonMove = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listBoxLeft
            // 
            this.listBoxLeft.BackColor = System.Drawing.SystemColors.Info;
            this.listBoxLeft.FormattingEnabled = true;
            this.listBoxLeft.ItemHeight = 16;
            this.listBoxLeft.Location = new System.Drawing.Point(22, 95);
            this.listBoxLeft.Name = "listBoxLeft";
            this.listBoxLeft.Size = new System.Drawing.Size(247, 324);
            this.listBoxLeft.TabIndex = 0;
            this.listBoxLeft.SelectedIndexChanged += new System.EventHandler(this.listBoxLeft_SelectedIndexChanged);
            // 
            // listBoxRight
            // 
            this.listBoxRight.BackColor = System.Drawing.SystemColors.Info;
            this.listBoxRight.FormattingEnabled = true;
            this.listBoxRight.ItemHeight = 16;
            this.listBoxRight.Location = new System.Drawing.Point(302, 95);
            this.listBoxRight.Name = "listBoxRight";
            this.listBoxRight.Size = new System.Drawing.Size(264, 324);
            this.listBoxRight.TabIndex = 1;
            this.listBoxRight.SelectedIndexChanged += new System.EventHandler(this.listBoxRight_SelectedIndexChanged);
            // 
            // textBoxHead
            // 
            this.textBoxHead.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.textBoxHead.Location = new System.Drawing.Point(22, 41);
            this.textBoxHead.Name = "textBoxHead";
            this.textBoxHead.Size = new System.Drawing.Size(544, 22);
            this.textBoxHead.TabIndex = 2;
            // 
            // buttonAdd
            // 
            this.buttonAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.buttonAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonAdd.Location = new System.Drawing.Point(628, 95);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(128, 42);
            this.buttonAdd.TabIndex = 3;
            this.buttonAdd.Text = "Добавить";
            this.buttonAdd.UseVisualStyleBackColor = false;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // buttonCalculate
            // 
            this.buttonCalculate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonCalculate.Location = new System.Drawing.Point(628, 167);
            this.buttonCalculate.Name = "buttonCalculate";
            this.buttonCalculate.Size = new System.Drawing.Size(128, 42);
            this.buttonCalculate.TabIndex = 4;
            this.buttonCalculate.Text = "Подсчёт";
            this.buttonCalculate.UseVisualStyleBackColor = true;
            this.buttonCalculate.Click += new System.EventHandler(this.buttonCalculate_Click);
            // 
            // buttonMove
            // 
            this.buttonMove.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonMove.Location = new System.Drawing.Point(628, 237);
            this.buttonMove.Name = "buttonMove";
            this.buttonMove.Size = new System.Drawing.Size(128, 42);
            this.buttonMove.TabIndex = 5;
            this.buttonMove.Text = "Перенести";
            this.buttonMove.UseVisualStyleBackColor = true;
            this.buttonMove.Click += new System.EventHandler(this.buttonMove_Click);
            // 
            // buttonDelete
            // 
            this.buttonDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonDelete.Location = new System.Drawing.Point(628, 309);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(128, 42);
            this.buttonDelete.TabIndex = 6;
            this.buttonDelete.Text = "Удалить";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buttonDelete);
            this.Controls.Add(this.buttonMove);
            this.Controls.Add(this.buttonCalculate);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.textBoxHead);
            this.Controls.Add(this.listBoxRight);
            this.Controls.Add(this.listBoxLeft);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxLeft;
        private System.Windows.Forms.ListBox listBoxRight;
        private System.Windows.Forms.TextBox textBoxHead;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Button buttonCalculate;
        private System.Windows.Forms.Button buttonMove;
        private System.Windows.Forms.Button buttonDelete;

    }
}

