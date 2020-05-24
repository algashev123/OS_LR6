namespace Client
{
    partial class BossForm
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
            this.buttonConectScout = new System.Windows.Forms.Button();
            this.InputCountScouts = new System.Windows.Forms.TextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.LogBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonLoadLog = new System.Windows.Forms.Button();
            this.buttonSaveLog = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonConectScout
            // 
            this.buttonConectScout.Location = new System.Drawing.Point(317, 368);
            this.buttonConectScout.Name = "buttonConectScout";
            this.buttonConectScout.Size = new System.Drawing.Size(169, 70);
            this.buttonConectScout.TabIndex = 0;
            this.buttonConectScout.Text = "Подключить шпионов";
            this.buttonConectScout.UseVisualStyleBackColor = true;
            this.buttonConectScout.Click += new System.EventHandler(this.button1_Click);
            // 
            // InputCountScouts
            // 
            this.InputCountScouts.Location = new System.Drawing.Point(355, 340);
            this.InputCountScouts.Name = "InputCountScouts";
            this.InputCountScouts.Size = new System.Drawing.Size(93, 22);
            this.InputCountScouts.TabIndex = 1;
            this.InputCountScouts.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // LogBox
            // 
            this.LogBox.Location = new System.Drawing.Point(49, 89);
            this.LogBox.Multiline = true;
            this.LogBox.Name = "LogBox";
            this.LogBox.ReadOnly = true;
            this.LogBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.LogBox.Size = new System.Drawing.Size(704, 218);
            this.LogBox.TabIndex = 3;
            this.LogBox.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Modern No. 20", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(332, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 31);
            this.label1.TabIndex = 4;
            this.label1.Text = "Резидент";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // buttonLoadLog
            // 
            this.buttonLoadLog.Location = new System.Drawing.Point(86, 368);
            this.buttonLoadLog.Name = "buttonLoadLog";
            this.buttonLoadLog.Size = new System.Drawing.Size(169, 70);
            this.buttonLoadLog.TabIndex = 5;
            this.buttonLoadLog.Text = "Загрузить лог";
            this.buttonLoadLog.UseVisualStyleBackColor = true;
            this.buttonLoadLog.Click += new System.EventHandler(this.button2_Click);
            // 
            // buttonSaveLog
            // 
            this.buttonSaveLog.Location = new System.Drawing.Point(570, 368);
            this.buttonSaveLog.Name = "buttonSaveLog";
            this.buttonSaveLog.Size = new System.Drawing.Size(169, 70);
            this.buttonSaveLog.TabIndex = 6;
            this.buttonSaveLog.Text = "Сохранить лог";
            this.buttonSaveLog.UseVisualStyleBackColor = true;
            this.buttonSaveLog.Click += new System.EventHandler(this.button3_Click);
            // 
            // BossForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buttonSaveLog);
            this.Controls.Add(this.buttonLoadLog);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.LogBox);
            this.Controls.Add(this.InputCountScouts);
            this.Controls.Add(this.buttonConectScout);
            this.Name = "BossForm";
            this.Text = "Server";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.BossForm_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonConectScout;
        private System.Windows.Forms.TextBox InputCountScouts;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.TextBox LogBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonLoadLog;
        private System.Windows.Forms.Button buttonSaveLog;
    }
}

