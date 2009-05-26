namespace ISBNextractor
{
    partial class Main
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.booklist = new System.Windows.Forms.ListView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.OpenBook = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.Add = new System.Windows.Forms.ToolStripMenuItem();
            this.stateImages = new System.Windows.Forms.ImageList(this.components);
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusInfo = new System.Windows.Forms.ToolStripStatusLabel();
            this.rightPanel = new System.Windows.Forms.TabControl();
            this.Start = new System.Windows.Forms.TabPage();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Book = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.propISBN = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.propRelease = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.propPages = new System.Windows.Forms.TextBox();
            this.addPublisher = new System.Windows.Forms.Button();
            this.propPublisher = new System.Windows.Forms.ComboBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.addLanguage = new System.Windows.Forms.Button();
            this.propLanguage = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.propAuthors = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.propTitle2 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.propTitle = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.zarn = new System.Windows.Forms.CheckedListBox();
            this.dodZarn = new System.Windows.Forms.TextBox();
            this.addTag = new System.Windows.Forms.Button();
            this.SaveBookChanges = new System.Windows.Forms.Button();
            this.Abstract = new System.Windows.Forms.TabPage();
            this.button8 = new System.Windows.Forms.Button();
            this.propAbstract = new System.Windows.Forms.RichTextBox();
            this.isDone = new System.Windows.Forms.Timer(this.components);
            this.saveTimer = new System.Windows.Forms.Timer(this.components);
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.searchOnAmazon = new System.Windows.Forms.Button();
            this.fromClipboard = new System.Windows.Forms.Button();
            this.fromDisk = new System.Windows.Forms.Button();
            this.slika = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.saveBooks = new System.Windows.Forms.ToolStripButton();
            this.saveButt = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.openButt = new System.Windows.Forms.ToolStripButton();
            this.contextMenuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.rightPanel.SuspendLayout();
            this.Start.SuspendLayout();
            this.Book.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.Abstract.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // booklist
            // 
            this.booklist.ContextMenuStrip = this.contextMenuStrip1;
            this.booklist.Location = new System.Drawing.Point(1, 32);
            this.booklist.MultiSelect = false;
            this.booklist.Name = "booklist";
            this.booklist.Size = new System.Drawing.Size(318, 410);
            this.booklist.SmallImageList = this.stateImages;
            this.booklist.StateImageList = this.stateImages;
            this.booklist.TabIndex = 0;
            this.booklist.UseCompatibleStateImageBehavior = false;
            this.booklist.View = System.Windows.Forms.View.List;
            this.booklist.ItemActivate += new System.EventHandler(this.booklist_ItemActivate);
            this.booklist.SelectedIndexChanged += new System.EventHandler(this.booklist_SelectedIndexChanged);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OpenBook,
            this.toolStripMenuItem1,
            this.Add});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(117, 54);
            // 
            // OpenBook
            // 
            this.OpenBook.Name = "OpenBook";
            this.OpenBook.Size = new System.Drawing.Size(116, 22);
            this.OpenBook.Text = "Open";
            this.OpenBook.Click += new System.EventHandler(this.OpenBook_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(113, 6);
            // 
            // Add
            // 
            this.Add.Name = "Add";
            this.Add.Size = new System.Drawing.Size(116, 22);
            this.Add.Text = "Delete";
            this.Add.Click += new System.EventHandler(this.Add_Click);
            // 
            // stateImages
            // 
            this.stateImages.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("stateImages.ImageStream")));
            this.stateImages.TransparentColor = System.Drawing.Color.Transparent;
            this.stateImages.Images.SetKeyName(0, "doc.png");
            this.stateImages.Images.SetKeyName(1, "todo.png");
            this.stateImages.Images.SetKeyName(2, "video.png");
            this.stateImages.Images.SetKeyName(3, "flag green.png");
            this.stateImages.Images.SetKeyName(4, "flag yellow.png");
            this.stateImages.Images.SetKeyName(5, "flag red.png");
            this.stateImages.Images.SetKeyName(6, "flag gray.png");
            this.stateImages.Images.SetKeyName(7, "package.png");
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(22, 22);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripSeparator1,
            this.toolStripButton2,
            this.saveBooks,
            this.toolStripSeparator2,
            this.openButt,
            this.saveButt,
            this.toolStripSeparator3,
            this.toolStripButton3});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(667, 29);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 29);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 29);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripProgressBar1,
            this.toolStripStatusLabel3,
            this.toolStripStatusLabel1,
            this.statusInfo});
            this.statusStrip1.Location = new System.Drawing.Point(0, 445);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(667, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Size = new System.Drawing.Size(100, 16);
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(19, 17);
            this.toolStripStatusLabel3.Text = "    ";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(42, 17);
            this.toolStripStatusLabel1.Text = "Status:";
            // 
            // statusInfo
            // 
            this.statusInfo.Name = "statusInfo";
            this.statusInfo.Size = new System.Drawing.Size(126, 17);
            this.statusInfo.Text = "Select eBooks to process";
            // 
            // rightPanel
            // 
            this.rightPanel.Controls.Add(this.Start);
            this.rightPanel.Controls.Add(this.Book);
            this.rightPanel.Controls.Add(this.Abstract);
            this.rightPanel.Location = new System.Drawing.Point(320, 12);
            this.rightPanel.Name = "rightPanel";
            this.rightPanel.SelectedIndex = 0;
            this.rightPanel.Size = new System.Drawing.Size(346, 434);
            this.rightPanel.TabIndex = 3;
            // 
            // Start
            // 
            this.Start.Controls.Add(this.pictureBox1);
            this.Start.Controls.Add(this.label2);
            this.Start.Controls.Add(this.label1);
            this.Start.Location = new System.Drawing.Point(4, 22);
            this.Start.Name = "Start";
            this.Start.Padding = new System.Windows.Forms.Padding(3);
            this.Start.Size = new System.Drawing.Size(338, 408);
            this.Start.TabIndex = 0;
            this.Start.Text = "Start";
            this.Start.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 151);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(299, 195);
            this.label2.TabIndex = 1;
            this.label2.Text = resources.GetString("label2.Text");
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 127);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(232, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "<< Add  PDF or CHM eBooks (Green (+) button)";
            // 
            // Book
            // 
            this.Book.Controls.Add(this.groupBox1);
            this.Book.Controls.Add(this.SaveBookChanges);
            this.Book.Location = new System.Drawing.Point(4, 22);
            this.Book.Name = "Book";
            this.Book.Padding = new System.Windows.Forms.Padding(3);
            this.Book.Size = new System.Drawing.Size(338, 408);
            this.Book.TabIndex = 1;
            this.Book.Text = "Book";
            this.Book.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.searchOnAmazon);
            this.groupBox1.Controls.Add(this.propISBN);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.propRelease);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.propPages);
            this.groupBox1.Controls.Add(this.addPublisher);
            this.groupBox1.Controls.Add(this.propPublisher);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.addLanguage);
            this.groupBox1.Controls.Add(this.propLanguage);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.propAuthors);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.propTitle2);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.propTitle);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Location = new System.Drawing.Point(6, 14);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(324, 356);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Book Info:";
            // 
            // propISBN
            // 
            this.propISBN.Location = new System.Drawing.Point(55, 22);
            this.propISBN.Name = "propISBN";
            this.propISBN.Size = new System.Drawing.Size(122, 20);
            this.propISBN.TabIndex = 0;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(163, 211);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(49, 13);
            this.label9.TabIndex = 47;
            this.label9.Text = "Release:";
            // 
            // propRelease
            // 
            this.propRelease.Location = new System.Drawing.Point(213, 208);
            this.propRelease.Name = "propRelease";
            this.propRelease.Size = new System.Drawing.Size(105, 20);
            this.propRelease.TabIndex = 46;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(163, 186);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(62, 13);
            this.label8.TabIndex = 45;
            this.label8.Text = "Nmr Pages:";
            // 
            // propPages
            // 
            this.propPages.Location = new System.Drawing.Point(234, 183);
            this.propPages.Name = "propPages";
            this.propPages.Size = new System.Drawing.Size(84, 20);
            this.propPages.TabIndex = 44;
            // 
            // addPublisher
            // 
            this.addPublisher.Location = new System.Drawing.Point(294, 156);
            this.addPublisher.Name = "addPublisher";
            this.addPublisher.Size = new System.Drawing.Size(24, 21);
            this.addPublisher.TabIndex = 43;
            this.addPublisher.Text = "+";
            this.addPublisher.UseVisualStyleBackColor = true;
            this.addPublisher.Click += new System.EventHandler(this.addPublisher_Click);
            // 
            // propPublisher
            // 
            this.propPublisher.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.propPublisher.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.propPublisher.FormattingEnabled = true;
            this.propPublisher.Location = new System.Drawing.Point(163, 156);
            this.propPublisher.Name = "propPublisher";
            this.propPublisher.Size = new System.Drawing.Size(125, 21);
            this.propPublisher.TabIndex = 42;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.fromClipboard);
            this.groupBox3.Controls.Add(this.fromDisk);
            this.groupBox3.Controls.Add(this.slika);
            this.groupBox3.Location = new System.Drawing.Point(6, 122);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(151, 221);
            this.groupBox3.TabIndex = 41;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Slika:";
            // 
            // addLanguage
            // 
            this.addLanguage.Location = new System.Drawing.Point(294, 127);
            this.addLanguage.Name = "addLanguage";
            this.addLanguage.Size = new System.Drawing.Size(24, 21);
            this.addLanguage.TabIndex = 38;
            this.addLanguage.Text = "+";
            this.addLanguage.UseVisualStyleBackColor = true;
            this.addLanguage.Click += new System.EventHandler(this.addLanguage_Click);
            // 
            // propLanguage
            // 
            this.propLanguage.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.propLanguage.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.propLanguage.FormattingEnabled = true;
            this.propLanguage.Location = new System.Drawing.Point(163, 127);
            this.propLanguage.Name = "propLanguage";
            this.propLanguage.Size = new System.Drawing.Size(125, 21);
            this.propLanguage.TabIndex = 37;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(7, 104);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(46, 13);
            this.label7.TabIndex = 8;
            this.label7.Text = "Authors:";
            // 
            // propAuthors
            // 
            this.propAuthors.Location = new System.Drawing.Point(55, 100);
            this.propAuthors.Name = "propAuthors";
            this.propAuthors.Size = new System.Drawing.Size(263, 20);
            this.propAuthors.TabIndex = 7;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(16, 78);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(36, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "Title2:";
            // 
            // propTitle2
            // 
            this.propTitle2.Location = new System.Drawing.Point(55, 74);
            this.propTitle2.Name = "propTitle2";
            this.propTitle2.Size = new System.Drawing.Size(263, 20);
            this.propTitle2.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(23, 53);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(30, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Title:";
            // 
            // propTitle
            // 
            this.propTitle.Location = new System.Drawing.Point(55, 49);
            this.propTitle.Name = "propTitle";
            this.propTitle.Size = new System.Drawing.Size(233, 20);
            this.propTitle.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(4, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "ID(ISBN):";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.zarn);
            this.groupBox2.Controls.Add(this.dodZarn);
            this.groupBox2.Controls.Add(this.addTag);
            this.groupBox2.Location = new System.Drawing.Point(163, 234);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(155, 109);
            this.groupBox2.TabIndex = 40;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Tags:";
            // 
            // zarn
            // 
            this.zarn.BackColor = System.Drawing.Color.White;
            this.zarn.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.zarn.CheckOnClick = true;
            this.zarn.ForeColor = System.Drawing.SystemColors.InfoText;
            this.zarn.FormattingEnabled = true;
            this.zarn.Location = new System.Drawing.Point(8, 40);
            this.zarn.Name = "zarn";
            this.zarn.Size = new System.Drawing.Size(139, 62);
            this.zarn.TabIndex = 9;
            this.zarn.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.zarn_ItemCheck);
            // 
            // dodZarn
            // 
            this.dodZarn.Location = new System.Drawing.Point(8, 17);
            this.dodZarn.Name = "dodZarn";
            this.dodZarn.Size = new System.Drawing.Size(114, 20);
            this.dodZarn.TabIndex = 10;
            this.dodZarn.TextChanged += new System.EventHandler(this.Tag_TextChanged);
            // 
            // addTag
            // 
            this.addTag.Location = new System.Drawing.Point(123, 17);
            this.addTag.Name = "addTag";
            this.addTag.Size = new System.Drawing.Size(24, 20);
            this.addTag.TabIndex = 11;
            this.addTag.Text = "+";
            this.addTag.UseVisualStyleBackColor = true;
            this.addTag.Click += new System.EventHandler(this.InsertTag_Click);
            // 
            // SaveBookChanges
            // 
            this.SaveBookChanges.Location = new System.Drawing.Point(177, 379);
            this.SaveBookChanges.Name = "SaveBookChanges";
            this.SaveBookChanges.Size = new System.Drawing.Size(154, 23);
            this.SaveBookChanges.TabIndex = 1;
            this.SaveBookChanges.Text = "Save Changes / Resolve";
            this.SaveBookChanges.UseVisualStyleBackColor = true;
            this.SaveBookChanges.Click += new System.EventHandler(this.SaveBookChanges_Click);
            // 
            // Abstract
            // 
            this.Abstract.Controls.Add(this.button8);
            this.Abstract.Controls.Add(this.propAbstract);
            this.Abstract.Location = new System.Drawing.Point(4, 22);
            this.Abstract.Name = "Abstract";
            this.Abstract.Padding = new System.Windows.Forms.Padding(3);
            this.Abstract.Size = new System.Drawing.Size(338, 408);
            this.Abstract.TabIndex = 2;
            this.Abstract.Text = "Abstract";
            this.Abstract.UseVisualStyleBackColor = true;
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(177, 379);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(154, 23);
            this.button8.TabIndex = 2;
            this.button8.Text = "Save Changes / Resolve";
            this.button8.UseVisualStyleBackColor = true;
            // 
            // propAbstract
            // 
            this.propAbstract.Location = new System.Drawing.Point(2, 5);
            this.propAbstract.Name = "propAbstract";
            this.propAbstract.Size = new System.Drawing.Size(330, 373);
            this.propAbstract.TabIndex = 0;
            this.propAbstract.Text = "";
            // 
            // isDone
            // 
            this.isDone.Tick += new System.EventHandler(this.isDone_Tick);
            // 
            // saveTimer
            // 
            this.saveTimer.Tick += new System.EventHandler(this.saveTimer_Tick);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 29);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::ISBNextractor.Properties.Resources.logoeLib;
            this.pictureBox1.Location = new System.Drawing.Point(60, 21);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(208, 81);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // searchOnAmazon
            // 
            this.searchOnAmazon.Image = global::ISBNextractor.Properties.Resources.web_search;
            this.searchOnAmazon.Location = new System.Drawing.Point(291, 47);
            this.searchOnAmazon.Name = "searchOnAmazon";
            this.searchOnAmazon.Size = new System.Drawing.Size(27, 23);
            this.searchOnAmazon.TabIndex = 48;
            this.searchOnAmazon.UseVisualStyleBackColor = true;
            this.searchOnAmazon.Click += new System.EventHandler(this.searchOnAmazon_Click);
            // 
            // fromClipboard
            // 
            this.fromClipboard.Image = global::ISBNextractor.Properties.Resources.paste;
            this.fromClipboard.Location = new System.Drawing.Point(106, 183);
            this.fromClipboard.Name = "fromClipboard";
            this.fromClipboard.Size = new System.Drawing.Size(41, 34);
            this.fromClipboard.TabIndex = 2;
            this.fromClipboard.UseVisualStyleBackColor = true;
            this.fromClipboard.Click += new System.EventHandler(this.fromClipboard_Click);
            // 
            // fromDisk
            // 
            this.fromDisk.Image = global::ISBNextractor.Properties.Resources.folder_image;
            this.fromDisk.Location = new System.Drawing.Point(67, 183);
            this.fromDisk.Name = "fromDisk";
            this.fromDisk.Size = new System.Drawing.Size(41, 34);
            this.fromDisk.TabIndex = 1;
            this.fromDisk.UseVisualStyleBackColor = true;
            this.fromDisk.Click += new System.EventHandler(this.button5_Click);
            // 
            // slika
            // 
            this.slika.Image = global::ISBNextractor.Properties.Resources.noImage;
            this.slika.Location = new System.Drawing.Point(4, 15);
            this.slika.Name = "slika";
            this.slika.Size = new System.Drawing.Size(143, 169);
            this.slika.TabIndex = 0;
            this.slika.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Image = global::ISBNextractor.Properties.Resources.globe;
            this.button2.Location = new System.Drawing.Point(180, 20);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(27, 23);
            this.button2.TabIndex = 1;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = global::ISBNextractor.Properties.Resources.addd;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(26, 26);
            this.toolStripButton1.Text = "Add book";
            this.toolStripButton1.Click += new System.EventHandler(this.AddBookToList_Click);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Image = global::ISBNextractor.Properties.Resources.play;
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(26, 26);
            this.toolStripButton2.Text = "Start Processing";
            this.toolStripButton2.Click += new System.EventHandler(this.StartProcessing_Click);
            // 
            // saveBooks
            // 
            this.saveBooks.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.saveBooks.Image = global::ISBNextractor.Properties.Resources.up;
            this.saveBooks.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveBooks.Name = "saveBooks";
            this.saveBooks.Size = new System.Drawing.Size(26, 26);
            this.saveBooks.Text = "Generate ebook.zip";
            this.saveBooks.Click += new System.EventHandler(this.saveBooks_Click);
            // 
            // saveButt
            // 
            this.saveButt.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.saveButt.Image = ((System.Drawing.Image)(resources.GetObject("saveButt.Image")));
            this.saveButt.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveButt.Name = "saveButt";
            this.saveButt.Size = new System.Drawing.Size(26, 26);
            this.saveButt.Text = "Save Session";
            this.saveButt.ToolTipText = "Save Session";
            this.saveButt.Click += new System.EventHandler(this.saveButt_Click);
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton3.Image = global::ISBNextractor.Properties.Resources.info;
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(26, 26);
            this.toolStripButton3.Text = "toolStripButton3";
            this.toolStripButton3.Click += new System.EventHandler(this.toolStripButton3_Click);
            // 
            // openButt
            // 
            this.openButt.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.openButt.Image = ((System.Drawing.Image)(resources.GetObject("openButt.Image")));
            this.openButt.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.openButt.Name = "openButt";
            this.openButt.Size = new System.Drawing.Size(26, 26);
            this.openButt.Text = "Open Session";
            this.openButt.Click += new System.EventHandler(this.openButt_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(667, 467);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.rightPanel);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.booklist);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Main";
            this.Text = "ISBN Extractor - by Teo";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.rightPanel.ResumeLayout(false);
            this.Start.ResumeLayout(false);
            this.Start.PerformLayout();
            this.Book.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.Abstract.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView booklist;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.TabControl rightPanel;
        private System.Windows.Forms.TabPage Start;
        private System.Windows.Forms.TabPage Book;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem Add;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ImageList stateImages;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.ToolStripStatusLabel statusInfo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolStripButton saveBooks;
        private System.Windows.Forms.Button SaveBookChanges;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox propISBN;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox propTitle2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox propTitle;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox propAuthors;
        private System.Windows.Forms.Button addTag;
        private System.Windows.Forms.TextBox dodZarn;
        private System.Windows.Forms.CheckedListBox zarn;
        private System.Windows.Forms.Button addLanguage;
        private System.Windows.Forms.ComboBox propLanguage;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button slika;
        private System.Windows.Forms.Button fromDisk;
        private System.Windows.Forms.Button fromClipboard;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.Button addPublisher;
        private System.Windows.Forms.ComboBox propPublisher;
        private System.Windows.Forms.TabPage Abstract;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.RichTextBox propAbstract;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox propPages;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox propRelease;
        private System.Windows.Forms.ToolStripMenuItem OpenBook;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.Timer isDone;
        private System.Windows.Forms.Button searchOnAmazon;
        private System.Windows.Forms.Timer saveTimer;
        private System.Windows.Forms.ToolStripButton saveButt;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton openButt;
    }
}

