namespace LoadDistribution
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.справочникиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.учителяToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.дисциплиныToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.группыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.работаСПреподавателямиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.данныеОГруппахИДисциплинахToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.выдачаУчебныхПорученийToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.справочникиToolStripMenuItem,
            this.работаСПреподавателямиToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // справочникиToolStripMenuItem
            // 
            this.справочникиToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.учителяToolStripMenuItem,
            this.дисциплиныToolStripMenuItem,
            this.группыToolStripMenuItem});
            this.справочникиToolStripMenuItem.Name = "справочникиToolStripMenuItem";
            this.справочникиToolStripMenuItem.Size = new System.Drawing.Size(94, 20);
            this.справочникиToolStripMenuItem.Text = "Справочники";
            // 
            // учителяToolStripMenuItem
            // 
            this.учителяToolStripMenuItem.Name = "учителяToolStripMenuItem";
            this.учителяToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.учителяToolStripMenuItem.Text = "Преподаватели";
            this.учителяToolStripMenuItem.Click += new System.EventHandler(this.учителяToolStripMenuItem_Click);
            // 
            // дисциплиныToolStripMenuItem
            // 
            this.дисциплиныToolStripMenuItem.Name = "дисциплиныToolStripMenuItem";
            this.дисциплиныToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.дисциплиныToolStripMenuItem.Text = "Дисциплины";
            this.дисциплиныToolStripMenuItem.Click += new System.EventHandler(this.дисциплиныToolStripMenuItem_Click);
            // 
            // группыToolStripMenuItem
            // 
            this.группыToolStripMenuItem.Name = "группыToolStripMenuItem";
            this.группыToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.группыToolStripMenuItem.Text = "Группы";
            this.группыToolStripMenuItem.Click += new System.EventHandler(this.группыToolStripMenuItem_Click);
            // 
            // работаСПреподавателямиToolStripMenuItem
            // 
            this.работаСПреподавателямиToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.данныеОГруппахИДисциплинахToolStripMenuItem,
            this.выдачаУчебныхПорученийToolStripMenuItem});
            this.работаСПреподавателямиToolStripMenuItem.Name = "работаСПреподавателямиToolStripMenuItem";
            this.работаСПреподавателямиToolStripMenuItem.Size = new System.Drawing.Size(167, 20);
            this.работаСПреподавателямиToolStripMenuItem.Text = "Работа с преподавателями";
            // 
            // данныеОГруппахИДисциплинахToolStripMenuItem
            // 
            this.данныеОГруппахИДисциплинахToolStripMenuItem.Name = "данныеОГруппахИДисциплинахToolStripMenuItem";
            this.данныеОГруппахИДисциплинахToolStripMenuItem.Size = new System.Drawing.Size(260, 22);
            this.данныеОГруппахИДисциплинахToolStripMenuItem.Text = "Данные о группах и дисциплинах";
            this.данныеОГруппахИДисциплинахToolStripMenuItem.Click += new System.EventHandler(this.данныеОГруппахИДисциплинахToolStripMenuItem_Click);
            // 
            // выдачаУчебныхПорученийToolStripMenuItem
            // 
            this.выдачаУчебныхПорученийToolStripMenuItem.Name = "выдачаУчебныхПорученийToolStripMenuItem";
            this.выдачаУчебныхПорученийToolStripMenuItem.Size = new System.Drawing.Size(260, 22);
            this.выдачаУчебныхПорученийToolStripMenuItem.Text = "Выдача учебных поручений";
            this.выдачаУчебныхПорученийToolStripMenuItem.Click += new System.EventHandler(this.выдачаУчебныхПорученийToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Система распределения нагрузки";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem справочникиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem учителяToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem дисциплиныToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem группыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem работаСПреподавателямиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem данныеОГруппахИДисциплинахToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem выдачаУчебныхПорученийToolStripMenuItem;
    }
}

