﻿namespace СельскоеХозяйство
{
    partial class ОкноПросмотраТехники
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ОкноПросмотраТехники));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.сельскоеХозяйствоDataSet = new СельскоеХозяйство.СельскоеХозяйствоDataSet();
            this.техникаBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.техникаTableAdapter = new СельскоеХозяйство.СельскоеХозяйствоDataSetTableAdapters.ТехникаTableAdapter();
            this.номерТехникиDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.наименованиеТехникиDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.номерТипаТехникиDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.цветТехникиDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.мощностьТехникиDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.сельскоеХозяйствоDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.техникаBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.MediumBlue;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(-1, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1261, 123);
            this.panel1.TabIndex = 26;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(557, 36);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(180, 54);
            this.label1.TabIndex = 1;
            this.label1.Text = "Техника";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, -1);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(151, 124);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.button1.Location = new System.Drawing.Point(15, 608);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(189, 68);
            this.button1.TabIndex = 27;
            this.button1.Text = "Назад";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.SystemColors.Control;
            this.label2.Location = new System.Drawing.Point(1033, 179);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 32);
            this.label2.TabIndex = 38;
            this.label2.Text = "Поиск";
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.textBox1.Location = new System.Drawing.Point(915, 215);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(331, 39);
            this.textBox1.TabIndex = 42;
            // 
            // button4
            // 
            this.button4.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.button4.Location = new System.Drawing.Point(915, 534);
            this.button4.Margin = new System.Windows.Forms.Padding(4);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(331, 68);
            this.button4.TabIndex = 41;
            this.button4.Text = "Удалить запись";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.button3.Location = new System.Drawing.Point(915, 429);
            this.button3.Margin = new System.Windows.Forms.Padding(4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(331, 82);
            this.button3.TabIndex = 40;
            this.button3.Text = "Редактировать информацию о технике";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.button2.Location = new System.Drawing.Point(915, 338);
            this.button2.Margin = new System.Windows.Forms.Padding(4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(331, 68);
            this.button2.TabIndex = 39;
            this.button2.Text = "Добавить технику";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 12F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.номерТехникиDataGridViewTextBoxColumn,
            this.наименованиеТехникиDataGridViewTextBoxColumn,
            this.номерТипаТехникиDataGridViewTextBoxColumn,
            this.цветТехникиDataGridViewTextBoxColumn,
            this.мощностьТехникиDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.техникаBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(15, 179);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(893, 422);
            this.dataGridView1.TabIndex = 37;
            // 
            // сельскоеХозяйствоDataSet
            // 
            this.сельскоеХозяйствоDataSet.DataSetName = "СельскоеХозяйствоDataSet";
            this.сельскоеХозяйствоDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // техникаBindingSource
            // 
            this.техникаBindingSource.DataMember = "Техника";
            this.техникаBindingSource.DataSource = this.сельскоеХозяйствоDataSet;
            // 
            // техникаTableAdapter
            // 
            this.техникаTableAdapter.ClearBeforeFill = true;
            // 
            // номерТехникиDataGridViewTextBoxColumn
            // 
            this.номерТехникиDataGridViewTextBoxColumn.DataPropertyName = "НомерТехники";
            this.номерТехникиDataGridViewTextBoxColumn.HeaderText = "Номер техники";
            this.номерТехникиDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.номерТехникиDataGridViewTextBoxColumn.Name = "номерТехникиDataGridViewTextBoxColumn";
            this.номерТехникиDataGridViewTextBoxColumn.ReadOnly = true;
            this.номерТехникиDataGridViewTextBoxColumn.Width = 150;
            // 
            // наименованиеТехникиDataGridViewTextBoxColumn
            // 
            this.наименованиеТехникиDataGridViewTextBoxColumn.DataPropertyName = "НаименованиеТехники";
            this.наименованиеТехникиDataGridViewTextBoxColumn.HeaderText = "Наименование техники";
            this.наименованиеТехникиDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.наименованиеТехникиDataGridViewTextBoxColumn.Name = "наименованиеТехникиDataGridViewTextBoxColumn";
            this.наименованиеТехникиDataGridViewTextBoxColumn.ReadOnly = true;
            this.наименованиеТехникиDataGridViewTextBoxColumn.Width = 200;
            // 
            // номерТипаТехникиDataGridViewTextBoxColumn
            // 
            this.номерТипаТехникиDataGridViewTextBoxColumn.DataPropertyName = "НомерТипаТехники";
            this.номерТипаТехникиDataGridViewTextBoxColumn.HeaderText = "Номер типа техники";
            this.номерТипаТехникиDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.номерТипаТехникиDataGridViewTextBoxColumn.Name = "номерТипаТехникиDataGridViewTextBoxColumn";
            this.номерТипаТехникиDataGridViewTextBoxColumn.ReadOnly = true;
            this.номерТипаТехникиDataGridViewTextBoxColumn.Width = 200;
            // 
            // цветТехникиDataGridViewTextBoxColumn
            // 
            this.цветТехникиDataGridViewTextBoxColumn.DataPropertyName = "ЦветТехники";
            this.цветТехникиDataGridViewTextBoxColumn.HeaderText = "Цвет техники";
            this.цветТехникиDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.цветТехникиDataGridViewTextBoxColumn.Name = "цветТехникиDataGridViewTextBoxColumn";
            this.цветТехникиDataGridViewTextBoxColumn.ReadOnly = true;
            this.цветТехникиDataGridViewTextBoxColumn.Width = 200;
            // 
            // мощностьТехникиDataGridViewTextBoxColumn
            // 
            this.мощностьТехникиDataGridViewTextBoxColumn.DataPropertyName = "МощностьТехники";
            this.мощностьТехникиDataGridViewTextBoxColumn.HeaderText = "Мощность техники";
            this.мощностьТехникиDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.мощностьТехникиDataGridViewTextBoxColumn.Name = "мощностьТехникиDataGridViewTextBoxColumn";
            this.мощностьТехникиDataGridViewTextBoxColumn.ReadOnly = true;
            this.мощностьТехникиDataGridViewTextBoxColumn.Width = 200;
            // 
            // ОкноПросмотраТехники
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.HotTrack;
            this.ClientSize = new System.Drawing.Size(1259, 690);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.button1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(1274, 728);
            this.Name = "ОкноПросмотраТехники";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Сельское хозяйство";
            this.Load += new System.EventHandler(this.ОкноПросмотраТехники_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.сельскоеХозяйствоDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.техникаBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private СельскоеХозяйствоDataSet сельскоеХозяйствоDataSet;
        private System.Windows.Forms.BindingSource техникаBindingSource;
        private СельскоеХозяйствоDataSetTableAdapters.ТехникаTableAdapter техникаTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn номерТехникиDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn наименованиеТехникиDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn номерТипаТехникиDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn цветТехникиDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn мощностьТехникиDataGridViewTextBoxColumn;
    }
}

