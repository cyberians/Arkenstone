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
            Dataweb.NShape.RoleBasedSecurityManager roleBasedSecurityManager1 = new Dataweb.NShape.RoleBasedSecurityManager();
            this.listView1 = new System.Windows.Forms.ListView();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.button4 = new System.Windows.Forms.Button();
            this.modelController1 = new Dataweb.NShape.Controllers.ModelController();
            this.modelTreeViewPresenter1 = new Dataweb.NShape.WinFormsUI.ModelTreeViewPresenter();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.FullRowSelect = true;
            this.listView1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(12, 58);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.ShowItemToolTips = true;
            this.listView1.Size = new System.Drawing.Size(157, 350);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1184, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // propertyGrid1
            // 
            this.propertyGrid1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.propertyGrid1.Location = new System.Drawing.Point(929, 283);
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
            roleBasedSecurityManager1.CurrentRole = Dataweb.NShape.StandardRole.Administrator;
            roleBasedSecurityManager1.CurrentRoleName = "Administrator";
            this.project1.SecurityManager = roleBasedSecurityManager1;
            // 
            // display1
            // 
            this.display1.AllowDrop = true;
            this.display1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.display1.BackColorGradient = System.Drawing.SystemColors.Control;
            this.display1.DiagramSetController = this.diagramSetController1;
            this.display1.GridColor = System.Drawing.Color.Gainsboro;
            this.display1.GridSize = 19;
            this.display1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.display1.Location = new System.Drawing.Point(186, 58);
            this.display1.Name = "display1";
            this.display1.PropertyController = this.propertyController1;
            this.display1.SelectionHilightColor = System.Drawing.Color.Firebrick;
            this.display1.SelectionInactiveColor = System.Drawing.Color.Gray;
            this.display1.SelectionInteriorColor = System.Drawing.Color.WhiteSmoke;
            this.display1.SelectionNormalColor = System.Drawing.Color.DarkGreen;
            this.display1.Size = new System.Drawing.Size(737, 470);
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
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(49, 426);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(64, 64);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseClick);
            this.pictureBox1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDoubleClick);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(44, 507);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "Открыть";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(49, 542);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(64, 64);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox2.TabIndex = 6;
            this.pictureBox2.TabStop = false;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(186, 562);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 7;
            this.button2.Text = "Слой 1";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(319, 562);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 7;
            this.button3.Text = "слой 2";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(936, 58);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(100, 199);
            this.listBox1.TabIndex = 8;
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.button4.Location = new System.Drawing.Point(452, 561);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(104, 23);
            this.button4.TabIndex = 9;
            this.button4.Text = "Сделать магию";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // modelController1
            // 
            this.modelController1.DiagramSetController = this.diagramSetController1;
            // 
            // modelTreeViewPresenter1
            // 
            this.modelTreeViewPresenter1.HideDeniedMenuItems = false;
            this.modelTreeViewPresenter1.ModelTreeController = this.modelController1;
            this.modelTreeViewPresenter1.PropertyController = this.propertyController1;
            this.modelTreeViewPresenter1.ShowDefaultContextMenu = true;
            this.modelTreeViewPresenter1.TreeView = this.treeView1;
            // 
            // treeView1
            // 
            this.treeView1.FullRowSelect = true;
            this.treeView1.ImageIndex = 0;
            this.treeView1.Location = new System.Drawing.Point(1042, 58);
            this.treeView1.Name = "treeView1";
            this.treeView1.SelectedImageIndex = 0;
            this.treeView1.Size = new System.Drawing.Size(120, 199);
            this.treeView1.TabIndex = 10;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 613);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.display1);
            this.Controls.Add(this.propertyGrid1);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
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
        private Dataweb.NShape.WinFormsUI.ModelTreeViewPresenter modelTreeViewPresenter1;
        private System.Windows.Forms.TreeView treeView1;
    }
}

