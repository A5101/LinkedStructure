
namespace LinkedForm
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
            this.SelectedStructure = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.открытьФайлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сохранитьФайлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.данныеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.добавитьЗначениеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.вНачалоToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.вКонецToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.удалитьЗначениеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сНачалаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сКонцаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CurrentStructure = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // SelectedStructure
            // 
            this.SelectedStructure.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.SelectedStructure.FormattingEnabled = true;
            this.SelectedStructure.Items.AddRange(new object[] {
            "Дек",
            "Двусвязный список",
            "Односвязный список",
            "Очередь",
            "Список",
            "Стек"});
            this.SelectedStructure.Location = new System.Drawing.Point(190, 33);
            this.SelectedStructure.Name = "SelectedStructure";
            this.SelectedStructure.Size = new System.Drawing.Size(201, 24);
            this.SelectedStructure.TabIndex = 1;
            this.SelectedStructure.SelectedIndexChanged += new System.EventHandler(this.SelectedStructure_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(175, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Выбор структуры данных";
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.данныеToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(403, 28);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.открытьФайлToolStripMenuItem,
            this.сохранитьФайлToolStripMenuItem});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(59, 24);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // открытьФайлToolStripMenuItem
            // 
            this.открытьФайлToolStripMenuItem.Name = "открытьФайлToolStripMenuItem";
            this.открытьФайлToolStripMenuItem.Size = new System.Drawing.Size(205, 26);
            this.открытьФайлToolStripMenuItem.Text = "Открыть файл";
            // 
            // сохранитьФайлToolStripMenuItem
            // 
            this.сохранитьФайлToolStripMenuItem.Name = "сохранитьФайлToolStripMenuItem";
            this.сохранитьФайлToolStripMenuItem.Size = new System.Drawing.Size(205, 26);
            this.сохранитьФайлToolStripMenuItem.Text = "Сохранить файл";
            // 
            // данныеToolStripMenuItem
            // 
            this.данныеToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.добавитьЗначениеToolStripMenuItem,
            this.удалитьЗначениеToolStripMenuItem});
            this.данныеToolStripMenuItem.Name = "данныеToolStripMenuItem";
            this.данныеToolStripMenuItem.Size = new System.Drawing.Size(78, 24);
            this.данныеToolStripMenuItem.Text = "Данные";
            // 
            // добавитьЗначениеToolStripMenuItem
            // 
            this.добавитьЗначениеToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.вНачалоToolStripMenuItem,
            this.вКонецToolStripMenuItem});
            this.добавитьЗначениеToolStripMenuItem.Name = "добавитьЗначениеToolStripMenuItem";
            this.добавитьЗначениеToolStripMenuItem.Size = new System.Drawing.Size(229, 26);
            this.добавитьЗначениеToolStripMenuItem.Text = "Добавить значение";
            // 
            // вНачалоToolStripMenuItem
            // 
            this.вНачалоToolStripMenuItem.Name = "вНачалоToolStripMenuItem";
            this.вНачалоToolStripMenuItem.Size = new System.Drawing.Size(155, 26);
            this.вНачалоToolStripMenuItem.Text = "В начало";
            this.вНачалоToolStripMenuItem.Click += new System.EventHandler(this.вНачалоToolStripMenuItem_Click);
            // 
            // вКонецToolStripMenuItem
            // 
            this.вКонецToolStripMenuItem.Name = "вКонецToolStripMenuItem";
            this.вКонецToolStripMenuItem.Size = new System.Drawing.Size(155, 26);
            this.вКонецToolStripMenuItem.Text = "В конец";
            this.вКонецToolStripMenuItem.Click += new System.EventHandler(this.вКонецToolStripMenuItem_Click);
            // 
            // удалитьЗначениеToolStripMenuItem
            // 
            this.удалитьЗначениеToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.сНачалаToolStripMenuItem,
            this.сКонцаToolStripMenuItem});
            this.удалитьЗначениеToolStripMenuItem.Name = "удалитьЗначениеToolStripMenuItem";
            this.удалитьЗначениеToolStripMenuItem.Size = new System.Drawing.Size(229, 26);
            this.удалитьЗначениеToolStripMenuItem.Text = "Удалить значение";
            // 
            // сНачалаToolStripMenuItem
            // 
            this.сНачалаToolStripMenuItem.Name = "сНачалаToolStripMenuItem";
            this.сНачалаToolStripMenuItem.Size = new System.Drawing.Size(154, 26);
            this.сНачалаToolStripMenuItem.Text = "С начала";
            this.сНачалаToolStripMenuItem.Click += new System.EventHandler(this.сНачалаToolStripMenuItem_Click);
            // 
            // сКонцаToolStripMenuItem
            // 
            this.сКонцаToolStripMenuItem.Name = "сКонцаToolStripMenuItem";
            this.сКонцаToolStripMenuItem.Size = new System.Drawing.Size(154, 26);
            this.сКонцаToolStripMenuItem.Text = "С конца";
            this.сКонцаToolStripMenuItem.Click += new System.EventHandler(this.сКонцаToolStripMenuItem_Click);
            // 
            // CurrentStructure
            // 
            this.CurrentStructure.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CurrentStructure.Location = new System.Drawing.Point(12, 93);
            this.CurrentStructure.Multiline = true;
            this.CurrentStructure.Name = "CurrentStructure";
            this.CurrentStructure.Size = new System.Drawing.Size(379, 367);
            this.CurrentStructure.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(136, 17);
            this.label3.TabIndex = 7;
            this.label3.Text = "Текущая структура";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(403, 472);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.CurrentStructure);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.SelectedStructure);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(421, 519);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox SelectedStructure;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem открытьФайлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сохранитьФайлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem данныеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem добавитьЗначениеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem удалитьЗначениеToolStripMenuItem;
        private System.Windows.Forms.TextBox CurrentStructure;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ToolStripMenuItem вНачалоToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem вКонецToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сНачалаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сКонцаToolStripMenuItem;
    }
}

