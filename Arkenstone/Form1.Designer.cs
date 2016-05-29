namespace Arkenstone
{
    partial class Form1
    {
        /// <summary>
        /// Требуется переменная конструктора.
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
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            Dataweb.NShape.RoleBasedSecurityManager roleBasedSecurityManager4 = new Dataweb.NShape.RoleBasedSecurityManager();
            this.listView1 = new System.Windows.Forms.ListView();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.создатьНовуюСетьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сохранитьСетьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.загрузитьСетьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.выходToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.параметрыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.настройкиСетиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.пакетнаяЗагрузкаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.propertyGrid1 = new System.Windows.Forms.PropertyGrid();
            this.cachedRepository1 = new Dataweb.NShape.Advanced.CachedRepository();
            this.xmlStore1 = new Dataweb.NShape.XmlStore();
            this.diagramSetController1 = new Dataweb.NShape.Controllers.DiagramSetController();
            this.project1 = new Dataweb.NShape.Project(this.components);
            this.display1 = new Dataweb.NShape.WinFormsUI.Display();
            this.propertyController1 = new Dataweb.NShape.Controllers.PropertyController();
            this.propertyPresenter1 = new Dataweb.NShape.WinFormsUI.PropertyPresenter();
            this.toolSetController1 = new Dataweb.NShape.Controllers.ToolSetController();
            this.toolSetListViewPresenter1 = new Dataweb.NShape.WinFormsUI.ToolSetListViewPresenter(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.button4 = new System.Windows.Forms.Button();
            this.modelController1 = new Dataweb.NShape.Controllers.ModelController();
            this.button5 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.openFileDialog2 = new System.Windows.Forms.OpenFileDialog();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.button10 = new System.Windows.Forms.Button();
            this.button11 = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.button6 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button8 = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.button12 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.BackColor = System.Drawing.SystemColors.Menu;
            this.listView1.FullRowSelect = true;
            this.listView1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(12, 90);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.ShowItemToolTips = true;
            this.listView1.Size = new System.Drawing.Size(189, 318);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.параметрыToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1176, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.создатьНовуюСетьToolStripMenuItem,
            this.сохранитьСетьToolStripMenuItem,
            this.загрузитьСетьToolStripMenuItem,
            this.toolStripSeparator1,
            this.выходToolStripMenuItem});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // создатьНовуюСетьToolStripMenuItem
            // 
            this.создатьНовуюСетьToolStripMenuItem.Name = "создатьНовуюСетьToolStripMenuItem";
            this.создатьНовуюСетьToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.создатьНовуюСетьToolStripMenuItem.Text = "Создать новую сеть";
            // 
            // сохранитьСетьToolStripMenuItem
            // 
            this.сохранитьСетьToolStripMenuItem.Name = "сохранитьСетьToolStripMenuItem";
            this.сохранитьСетьToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.сохранитьСетьToolStripMenuItem.Text = "Сохранить сеть";
            // 
            // загрузитьСетьToolStripMenuItem
            // 
            this.загрузитьСетьToolStripMenuItem.Name = "загрузитьСетьToolStripMenuItem";
            this.загрузитьСетьToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.загрузитьСетьToolStripMenuItem.Text = "Загрузить сеть";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(179, 6);
            // 
            // выходToolStripMenuItem
            // 
            this.выходToolStripMenuItem.Name = "выходToolStripMenuItem";
            this.выходToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.выходToolStripMenuItem.Text = "Выход";
            // 
            // параметрыToolStripMenuItem
            // 
            this.параметрыToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.настройкиСетиToolStripMenuItem,
            this.пакетнаяЗагрузкаToolStripMenuItem});
            this.параметрыToolStripMenuItem.Name = "параметрыToolStripMenuItem";
            this.параметрыToolStripMenuItem.Size = new System.Drawing.Size(83, 20);
            this.параметрыToolStripMenuItem.Text = "Параметры";
            // 
            // настройкиСетиToolStripMenuItem
            // 
            this.настройкиСетиToolStripMenuItem.Name = "настройкиСетиToolStripMenuItem";
            this.настройкиСетиToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.настройкиСетиToolStripMenuItem.Text = "Настройки сети";
            this.настройкиСетиToolStripMenuItem.Click += new System.EventHandler(this.настройкиСетиToolStripMenuItem_Click);
            // 
            // пакетнаяЗагрузкаToolStripMenuItem
            // 
            this.пакетнаяЗагрузкаToolStripMenuItem.Name = "пакетнаяЗагрузкаToolStripMenuItem";
            this.пакетнаяЗагрузкаToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.пакетнаяЗагрузкаToolStripMenuItem.Text = "Пакетная загрузка";
            // 
            // propertyGrid1
            // 
            this.propertyGrid1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.propertyGrid1.CategoryForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.propertyGrid1.Location = new System.Drawing.Point(921, 283);
            this.propertyGrid1.Name = "propertyGrid1";
            this.propertyGrid1.Size = new System.Drawing.Size(243, 318);
            this.propertyGrid1.TabIndex = 2;
            // 
            // cachedRepository1
            // 
            this.cachedRepository1.ProjectName = null;
            this.cachedRepository1.Store = this.xmlStore1;
            this.cachedRepository1.Version = 0;
            this.cachedRepository1.ConnectionInserted += new System.EventHandler<Dataweb.NShape.RepositoryShapeConnectionEventArgs>(this.cachedRepository1_ConnectionInserted);
            // 
            // xmlStore1
            // 
            this.xmlStore1.DesignFileName = "";
            this.xmlStore1.DirectoryName = "";
            this.xmlStore1.FileExtension = ".xml";
            this.xmlStore1.ImageLocation = Dataweb.NShape.XmlStore.ImageFileLocation.Directory;
            this.xmlStore1.ProjectFilePath = ".xml";
            this.xmlStore1.ProjectName = "";
            // 
            // diagramSetController1
            // 
            this.diagramSetController1.ActiveTool = null;
            this.diagramSetController1.Project = this.project1;
            // 
            // project1
            // 
            this.project1.Description = null;
            this.project1.LibrarySearchPaths = ((System.Collections.Generic.IList<string>)(resources.GetObject("project1.LibrarySearchPaths")));
            this.project1.Name = null;
            this.project1.Repository = this.cachedRepository1;
            roleBasedSecurityManager4.CurrentRole = Dataweb.NShape.StandardRole.Administrator;
            roleBasedSecurityManager4.CurrentRoleName = "Administrator";
            this.project1.SecurityManager = roleBasedSecurityManager4;
            // 
            // display1
            // 
            this.display1.AllowDrop = true;
            this.display1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.display1.BackColorGradient = System.Drawing.SystemColors.ControlLight;
            this.display1.DiagramSetController = this.diagramSetController1;
            this.display1.GridColor = System.Drawing.Color.Gainsboro;
            this.display1.GridSize = 19;
            this.display1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.display1.Location = new System.Drawing.Point(207, 90);
            this.display1.Name = "display1";
            this.display1.PropertyController = this.propertyController1;
            this.display1.SelectionHilightColor = System.Drawing.Color.Firebrick;
            this.display1.SelectionInactiveColor = System.Drawing.Color.Gray;
            this.display1.SelectionInteriorColor = System.Drawing.Color.WhiteSmoke;
            this.display1.SelectionNormalColor = System.Drawing.Color.DarkGreen;
            this.display1.Size = new System.Drawing.Size(708, 482);
            this.display1.TabIndex = 3;
            this.display1.ToolPreviewBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(119)))), ((int)(((byte)(136)))), ((int)(((byte)(153)))));
            this.display1.ToolPreviewColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(70)))), ((int)(((byte)(130)))), ((int)(((byte)(180)))));
            this.display1.ShapesInserted += new System.EventHandler<Dataweb.NShape.Controllers.DiagramPresenterShapesEventArgs>(this.display1_ShapesInserted);
            // 
            // propertyController1
            // 
            this.propertyController1.Project = this.project1;
            this.propertyController1.PropertyDisplayMode = Dataweb.NShape.Controllers.NonEditableDisplayMode.ReadOnly;
            // 
            // propertyPresenter1
            // 
            this.propertyPresenter1.PrimaryPropertyGrid = this.propertyGrid1;
            this.propertyPresenter1.PropertyController = this.propertyController1;
            this.propertyPresenter1.SecondaryPropertyGrid = null;
            // 
            // toolSetController1
            // 
            this.toolSetController1.DiagramSetController = this.diagramSetController1;
            // 
            // toolSetListViewPresenter1
            // 
            this.toolSetListViewPresenter1.HideDeniedMenuItems = false;
            this.toolSetListViewPresenter1.ListView = this.listView1;
            this.toolSetListViewPresenter1.ShowDefaultContextMenu = true;
            this.toolSetListViewPresenter1.ToolSetController = this.toolSetController1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(40, 105);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(114, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "Открыть";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(40, 2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(10, 10);
            this.button2.TabIndex = 7;
            this.button2.Text = "Обучить";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(123, 28);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(99, 23);
            this.button3.TabIndex = 7;
            this.button3.Text = "Проход по сети";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(54, 3);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(100, 199);
            this.listBox1.TabIndex = 8;
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.button4.Location = new System.Drawing.Point(28, 2);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(10, 10);
            this.button4.TabIndex = 9;
            this.button4.Text = "2";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // modelController1
            // 
            this.modelController1.DiagramSetController = this.diagramSetController1;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(15, 2);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(10, 10);
            this.button5.TabIndex = 11;
            this.button5.Text = "1";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(3, 2);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(10, 10);
            this.button7.TabIndex = 14;
            this.button7.Text = "Открыть много";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // openFileDialog2
            // 
            this.openFileDialog2.FileName = "openFileDialog2";
            this.openFileDialog2.Multiselect = true;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(207, 578);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(708, 23);
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar1.TabIndex = 17;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // button10
            // 
            this.button10.Location = new System.Drawing.Point(160, 119);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(75, 23);
            this.button10.TabIndex = 18;
            this.button10.Text = "Пакетное";
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.button10_Click);
            // 
            // button11
            // 
            this.button11.Enabled = false;
            this.button11.Image = global::Arkenstone.Properties.Resources.cuda_mini;
            this.button11.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button11.Location = new System.Drawing.Point(1003, 0);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(173, 24);
            this.button11.TabIndex = 19;
            this.button11.Text = "Панель управления CUDA";
            this.button11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button11.UseVisualStyleBackColor = true;
            this.button11.Click += new System.EventHandler(this.button11_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(123, 3);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(64, 64);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox2.TabIndex = 6;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(53, 35);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(64, 64);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseClick);
            this.pictureBox1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDoubleClick);
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "sigmoida",
            "heavyside"});
            this.comboBox1.Location = new System.Drawing.Point(6, 30);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(106, 21);
            this.comboBox1.TabIndex = 20;
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(160, 148);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(75, 23);
            this.button6.TabIndex = 21;
            this.button6.Text = "STOP";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.listBox1);
            this.panel1.Controls.Add(this.button6);
            this.panel1.Controls.Add(this.button10);
            this.panel1.Location = new System.Drawing.Point(1169, 90);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(259, 211);
            this.panel1.TabIndex = 22;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(921, 90);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(243, 187);
            this.richTextBox1.TabIndex = 23;
            this.richTextBox1.Text = resources.GetString("richTextBox1.Text");
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.button8);
            this.panel2.Controls.Add(this.button1);
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Controls.Add(this.button2);
            this.panel2.Controls.Add(this.button4);
            this.panel2.Controls.Add(this.button5);
            this.panel2.Controls.Add(this.button7);
            this.panel2.Controls.Add(this.pictureBox2);
            this.panel2.Location = new System.Drawing.Point(12, 414);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(189, 187);
            this.panel2.TabIndex = 24;
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(40, 134);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(114, 23);
            this.button8.TabIndex = 15;
            this.button8.Text = "Пакетная вставка";
            this.button8.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.button12);
            this.panel3.Controls.Add(this.button9);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.comboBox1);
            this.panel3.Controls.Add(this.button3);
            this.panel3.Location = new System.Drawing.Point(12, 27);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1152, 57);
            this.panel3.TabIndex = 25;
            // 
            // button12
            // 
            this.button12.Location = new System.Drawing.Point(343, 28);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(108, 23);
            this.button12.TabIndex = 22;
            this.button12.Text = "Обновить сеть";
            this.button12.UseVisualStyleBackColor = true;
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(229, 28);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(108, 23);
            this.button9.TabIndex = 21;
            this.button9.Text = "Пакетный проход";
            this.button9.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Функция активации";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Arkenstone.Properties.Resources.arkfon;
            this.ClientSize = new System.Drawing.Size(1176, 613);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.button11);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.display1);
            this.Controls.Add(this.propertyGrid1);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Arkenstone";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.PropertyGrid propertyGrid1;
        private Dataweb.NShape.Advanced.CachedRepository cachedRepository1;
        private Dataweb.NShape.XmlStore xmlStore1;
        private Dataweb.NShape.Controllers.DiagramSetController diagramSetController1;
        private Dataweb.NShape.Project project1;
        private Dataweb.NShape.WinFormsUI.Display display1;
        private Dataweb.NShape.Controllers.PropertyController propertyController1;
        private Dataweb.NShape.WinFormsUI.PropertyPresenter propertyPresenter1;
        private Dataweb.NShape.Controllers.ToolSetController toolSetController1;
        private Dataweb.NShape.WinFormsUI.ToolSetListViewPresenter toolSetListViewPresenter1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button button4;
        private Dataweb.NShape.Controllers.ModelController modelController1;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.OpenFileDialog openFileDialog2;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.ToolStripMenuItem создатьНовуюСетьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сохранитьСетьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem загрузитьСетьToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem выходToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem параметрыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem настройкиСетиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem пакетнаяЗагрузкаToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button button12;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Label label1;
    }
}

