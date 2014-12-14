namespace NES
{
	partial class Form1
	{
		/// <summary>
		/// Variable nécessaire au concepteur.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Nettoyage des ressources utilisées.
		/// </summary>
		/// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Code généré par le Concepteur Windows Form

		/// <summary>
		/// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
		/// le contenu de cette méthode avec l'éditeur de code.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
			this.SourceCodeBox = new System.Windows.Forms.ListBox();
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.StepButton = new System.Windows.Forms.Button();
			this.StackListBox = new System.Windows.Forms.ListBox();
			this.StackGroupBox = new System.Windows.Forms.GroupBox();
			this.label1 = new System.Windows.Forms.Label();
			this.ABox = new System.Windows.Forms.TextBox();
			this.XBox = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.PBox = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.PCBox = new System.Windows.Forms.TextBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.FlagB = new System.Windows.Forms.CheckBox();
			this.FlagC = new System.Windows.Forms.CheckBox();
			this.FlagU = new System.Windows.Forms.CheckBox();
			this.FlagZ = new System.Windows.Forms.CheckBox();
			this.FlagI = new System.Windows.Forms.CheckBox();
			this.FlagV = new System.Windows.Forms.CheckBox();
			this.FlagD = new System.Windows.Forms.CheckBox();
			this.FlagN = new System.Windows.Forms.CheckBox();
			this.toolStrip1 = new System.Windows.Forms.ToolStrip();
			this.ouvrirToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
			this.ToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.ResetBox = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.label7 = new System.Windows.Forms.Label();
			this.BankBox = new System.Windows.Forms.ComboBox();
			this.MemoryBox = new System.Windows.Forms.TextBox();
			this.StepOverButton = new System.Windows.Forms.Button();
			this.RunButton = new System.Windows.Forms.Button();
			this.label5 = new System.Windows.Forms.Label();
			this.YBox = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.SPBox = new System.Windows.Forms.TextBox();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.groupBox4 = new System.Windows.Forms.GroupBox();
			this.StopButton = new System.Windows.Forms.Button();
			this.hexBox1 = new Be.Windows.Forms.HexBox();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.ROMBox = new System.Windows.Forms.ListBox();
			this.GroupBox12 = new System.Windows.Forms.GroupBox();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.groupBox5 = new System.Windows.Forms.GroupBox();
			this.ROMInfoView = new System.Windows.Forms.ListView();
			this.PropertyCol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.ValueCol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.StackGroupBox.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.toolStrip1.SuspendLayout();
			this.menuStrip1.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.groupBox4.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.GroupBox12.SuspendLayout();
			this.groupBox5.SuspendLayout();
			this.SuspendLayout();
			// 
			// SourceCodeBox
			// 
			this.SourceCodeBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.SourceCodeBox.BackColor = System.Drawing.SystemColors.Window;
			this.SourceCodeBox.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.SourceCodeBox.FormattingEnabled = true;
			this.SourceCodeBox.ItemHeight = 14;
			this.SourceCodeBox.Location = new System.Drawing.Point(12, 63);
			this.SourceCodeBox.Name = "SourceCodeBox";
			this.SourceCodeBox.Size = new System.Drawing.Size(279, 368);
			this.SourceCodeBox.TabIndex = 0;
			this.SourceCodeBox.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
			// 
			// statusStrip1
			// 
			this.statusStrip1.Location = new System.Drawing.Point(0, 705);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size(1209, 22);
			this.statusStrip1.TabIndex = 1;
			this.statusStrip1.Text = "statusStrip1";
			// 
			// StepButton
			// 
			this.StepButton.Location = new System.Drawing.Point(6, 18);
			this.StepButton.Name = "StepButton";
			this.StepButton.Size = new System.Drawing.Size(75, 23);
			this.StepButton.TabIndex = 2;
			this.StepButton.Text = "Step (F10)";
			this.StepButton.UseVisualStyleBackColor = true;
			this.StepButton.Click += new System.EventHandler(this.StepButton_Click);
			// 
			// StackListBox
			// 
			this.StackListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.StackListBox.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.StackListBox.FormattingEnabled = true;
			this.StackListBox.ItemHeight = 14;
			this.StackListBox.Location = new System.Drawing.Point(6, 19);
			this.StackListBox.Name = "StackListBox";
			this.StackListBox.Size = new System.Drawing.Size(77, 270);
			this.StackListBox.TabIndex = 3;
			// 
			// StackGroupBox
			// 
			this.StackGroupBox.Controls.Add(this.StackListBox);
			this.StackGroupBox.Location = new System.Drawing.Point(480, 63);
			this.StackGroupBox.Name = "StackGroupBox";
			this.StackGroupBox.Size = new System.Drawing.Size(95, 304);
			this.StackGroupBox.TabIndex = 4;
			this.StackGroupBox.TabStop = false;
			this.StackGroupBox.Text = "Stack :";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(11, 50);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(14, 13);
			this.label1.TabIndex = 5;
			this.label1.Text = "A";
			// 
			// ABox
			// 
			this.ABox.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.ABox.Location = new System.Drawing.Point(38, 47);
			this.ABox.MaxLength = 2;
			this.ABox.Name = "ABox";
			this.ABox.Size = new System.Drawing.Size(25, 22);
			this.ABox.TabIndex = 6;
			this.ABox.TextChanged += new System.EventHandler(this.ABox_TextChanged);
			// 
			// XBox
			// 
			this.XBox.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.XBox.Location = new System.Drawing.Point(38, 75);
			this.XBox.MaxLength = 2;
			this.XBox.Name = "XBox";
			this.XBox.Size = new System.Drawing.Size(25, 22);
			this.XBox.TabIndex = 8;
			this.XBox.TextChanged += new System.EventHandler(this.XBox_TextChanged);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(11, 78);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(14, 13);
			this.label2.TabIndex = 7;
			this.label2.Text = "X";
			// 
			// PBox
			// 
			this.PBox.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.PBox.Location = new System.Drawing.Point(95, 47);
			this.PBox.MaxLength = 2;
			this.PBox.Name = "PBox";
			this.PBox.ReadOnly = true;
			this.PBox.Size = new System.Drawing.Size(66, 22);
			this.PBox.TabIndex = 10;
			this.PBox.TextChanged += new System.EventHandler(this.YBox_TextChanged);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(75, 50);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(14, 13);
			this.label3.TabIndex = 9;
			this.label3.Text = "P";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(11, 22);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(21, 13);
			this.label4.TabIndex = 5;
			this.label4.Text = "PC";
			// 
			// PCBox
			// 
			this.PCBox.AcceptsReturn = true;
			this.PCBox.CausesValidation = false;
			this.PCBox.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.PCBox.Location = new System.Drawing.Point(38, 19);
			this.PCBox.MaxLength = 4;
			this.PCBox.Name = "PCBox";
			this.PCBox.Size = new System.Drawing.Size(37, 22);
			this.PCBox.TabIndex = 6;
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.FlagB);
			this.groupBox2.Controls.Add(this.FlagC);
			this.groupBox2.Controls.Add(this.FlagU);
			this.groupBox2.Controls.Add(this.FlagZ);
			this.groupBox2.Controls.Add(this.FlagI);
			this.groupBox2.Controls.Add(this.FlagV);
			this.groupBox2.Controls.Add(this.FlagD);
			this.groupBox2.Controls.Add(this.FlagN);
			this.groupBox2.Location = new System.Drawing.Point(297, 294);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(169, 73);
			this.groupBox2.TabIndex = 11;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Status flags :";
			// 
			// FlagB
			// 
			this.FlagB.AutoSize = true;
			this.FlagB.Location = new System.Drawing.Point(127, 19);
			this.FlagB.Name = "FlagB";
			this.FlagB.Size = new System.Drawing.Size(33, 17);
			this.FlagB.TabIndex = 0;
			this.FlagB.Text = "B";
			this.FlagB.UseVisualStyleBackColor = true;
			this.FlagB.CheckedChanged += new System.EventHandler(this.FlagB_CheckedChanged);
			// 
			// FlagC
			// 
			this.FlagC.AutoSize = true;
			this.FlagC.Location = new System.Drawing.Point(127, 43);
			this.FlagC.Name = "FlagC";
			this.FlagC.Size = new System.Drawing.Size(33, 17);
			this.FlagC.TabIndex = 0;
			this.FlagC.Text = "C";
			this.FlagC.UseVisualStyleBackColor = true;
			this.FlagC.CheckedChanged += new System.EventHandler(this.FlagC_CheckedChanged);
			// 
			// FlagU
			// 
			this.FlagU.AutoSize = true;
			this.FlagU.Location = new System.Drawing.Point(87, 19);
			this.FlagU.Name = "FlagU";
			this.FlagU.Size = new System.Drawing.Size(34, 17);
			this.FlagU.TabIndex = 0;
			this.FlagU.Text = "U";
			this.FlagU.UseVisualStyleBackColor = true;
			this.FlagU.CheckedChanged += new System.EventHandler(this.FlagU_CheckedChanged);
			// 
			// FlagZ
			// 
			this.FlagZ.AutoSize = true;
			this.FlagZ.Location = new System.Drawing.Point(87, 43);
			this.FlagZ.Name = "FlagZ";
			this.FlagZ.Size = new System.Drawing.Size(33, 17);
			this.FlagZ.TabIndex = 0;
			this.FlagZ.Text = "Z";
			this.FlagZ.UseVisualStyleBackColor = true;
			this.FlagZ.CheckedChanged += new System.EventHandler(this.FlagZ_CheckedChanged);
			// 
			// FlagI
			// 
			this.FlagI.AutoSize = true;
			this.FlagI.Location = new System.Drawing.Point(47, 43);
			this.FlagI.Name = "FlagI";
			this.FlagI.Size = new System.Drawing.Size(29, 17);
			this.FlagI.TabIndex = 0;
			this.FlagI.Text = "I";
			this.FlagI.UseVisualStyleBackColor = true;
			this.FlagI.CheckedChanged += new System.EventHandler(this.FlagI_CheckedChanged);
			// 
			// FlagV
			// 
			this.FlagV.AutoSize = true;
			this.FlagV.Location = new System.Drawing.Point(47, 20);
			this.FlagV.Name = "FlagV";
			this.FlagV.Size = new System.Drawing.Size(33, 17);
			this.FlagV.TabIndex = 0;
			this.FlagV.Text = "V";
			this.FlagV.UseVisualStyleBackColor = true;
			this.FlagV.CheckedChanged += new System.EventHandler(this.FlagV_CheckedChanged);
			// 
			// FlagD
			// 
			this.FlagD.AutoSize = true;
			this.FlagD.Location = new System.Drawing.Point(7, 43);
			this.FlagD.Name = "FlagD";
			this.FlagD.Size = new System.Drawing.Size(34, 17);
			this.FlagD.TabIndex = 0;
			this.FlagD.Text = "D";
			this.FlagD.UseVisualStyleBackColor = true;
			this.FlagD.CheckedChanged += new System.EventHandler(this.FlagD_CheckedChanged);
			// 
			// FlagN
			// 
			this.FlagN.AutoSize = true;
			this.FlagN.Location = new System.Drawing.Point(7, 20);
			this.FlagN.Name = "FlagN";
			this.FlagN.Size = new System.Drawing.Size(34, 17);
			this.FlagN.TabIndex = 0;
			this.FlagN.Text = "N";
			this.FlagN.UseVisualStyleBackColor = true;
			this.FlagN.CheckedChanged += new System.EventHandler(this.FlagN_CheckedChanged);
			// 
			// toolStrip1
			// 
			this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
			this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ouvrirToolStripButton,
            this.toolStripSeparator,
            this.ToolStripButton});
			this.toolStrip1.Location = new System.Drawing.Point(0, 24);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
			this.toolStrip1.Size = new System.Drawing.Size(1209, 25);
			this.toolStrip1.TabIndex = 12;
			this.toolStrip1.Text = "toolStrip1";
			// 
			// ouvrirToolStripButton
			// 
			this.ouvrirToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.ouvrirToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("ouvrirToolStripButton.Image")));
			this.ouvrirToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.ouvrirToolStripButton.Name = "ouvrirToolStripButton";
			this.ouvrirToolStripButton.Size = new System.Drawing.Size(23, 22);
			this.ouvrirToolStripButton.Text = "&Ouvrir";
			// 
			// toolStripSeparator
			// 
			this.toolStripSeparator.Name = "toolStripSeparator";
			this.toolStripSeparator.Size = new System.Drawing.Size(6, 25);
			// 
			// ToolStripButton
			// 
			this.ToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.ToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("ToolStripButton.Image")));
			this.ToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.ToolStripButton.Name = "ToolStripButton";
			this.ToolStripButton.Size = new System.Drawing.Size(23, 22);
			this.ToolStripButton.Text = "&?";
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(1209, 24);
			this.menuStrip1.TabIndex = 13;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// fileToolStripMenuItem
			// 
			this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
			this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
			this.fileToolStripMenuItem.Text = "File";
			// 
			// exitToolStripMenuItem
			// 
			this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
			this.exitToolStripMenuItem.Size = new System.Drawing.Size(92, 22);
			this.exitToolStripMenuItem.Text = "Exit";
			// 
			// ResetBox
			// 
			this.ResetBox.Location = new System.Drawing.Point(5, 76);
			this.ResetBox.Name = "ResetBox";
			this.ResetBox.Size = new System.Drawing.Size(75, 23);
			this.ResetBox.TabIndex = 2;
			this.ResetBox.Text = "Reset";
			this.ResetBox.UseVisualStyleBackColor = true;
			this.ResetBox.Click += new System.EventHandler(this.ResetBox_Click);
			// 
			// groupBox1
			// 
			this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.groupBox1.Controls.Add(this.label7);
			this.groupBox1.Controls.Add(this.BankBox);
			this.groupBox1.Controls.Add(this.MemoryBox);
			this.groupBox1.Location = new System.Drawing.Point(580, 63);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(614, 174);
			this.groupBox1.TabIndex = 14;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Memory :";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(6, 22);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(38, 13);
			this.label7.TabIndex = 3;
			this.label7.Text = "Bank :";
			// 
			// BankBox
			// 
			this.BankBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.BankBox.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.BankBox.FormattingEnabled = true;
			this.BankBox.Items.AddRange(new object[] {
            "00 - $0000 to $0FFF",
            "01 - $1000 to $1FFF",
            "02 - $2000 to $2FFF",
            "03 - $3000 to $3FFF",
            "04 - $4000 to $4FFF",
            "05 - $5000 to $5FFF",
            "06 - $6000 to $6FFF",
            "07 - $7000 to $7FFF",
            "08 - $8000 to $8FFF",
            "09 - $9000 to $9FFF",
            "10 - $A000 to $AFFF",
            "11 - $B000 to $BFFF",
            "12 - $C000 to $CFFF",
            "13 - $D000 to $DFFF",
            "14 - $E000 to $EFFF",
            "15 - $F000 to $FFFF"});
			this.BankBox.Location = new System.Drawing.Point(50, 20);
			this.BankBox.Name = "BankBox";
			this.BankBox.Size = new System.Drawing.Size(206, 22);
			this.BankBox.TabIndex = 2;
			this.BankBox.SelectedIndexChanged += new System.EventHandler(this.BankBox_SelectedIndexChanged);
			// 
			// MemoryBox
			// 
			this.MemoryBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.MemoryBox.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.MemoryBox.Location = new System.Drawing.Point(6, 47);
			this.MemoryBox.Multiline = true;
			this.MemoryBox.Name = "MemoryBox";
			this.MemoryBox.ReadOnly = true;
			this.MemoryBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.MemoryBox.Size = new System.Drawing.Size(602, 121);
			this.MemoryBox.TabIndex = 0;
			this.MemoryBox.Text = resources.GetString("MemoryBox.Text");
			// 
			// StepOverButton
			// 
			this.StepOverButton.Location = new System.Drawing.Point(87, 17);
			this.StepOverButton.Name = "StepOverButton";
			this.StepOverButton.Size = new System.Drawing.Size(75, 23);
			this.StepOverButton.TabIndex = 2;
			this.StepOverButton.Text = "Step over (F11)";
			this.StepOverButton.UseVisualStyleBackColor = true;
			this.StepOverButton.Click += new System.EventHandler(this.StepOverButton_Click);
			// 
			// RunButton
			// 
			this.RunButton.Location = new System.Drawing.Point(6, 47);
			this.RunButton.Name = "RunButton";
			this.RunButton.Size = new System.Drawing.Size(75, 23);
			this.RunButton.TabIndex = 2;
			this.RunButton.Text = "Run";
			this.RunButton.UseVisualStyleBackColor = true;
			this.RunButton.Click += new System.EventHandler(this.RunButton_Click);
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(76, 78);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(14, 13);
			this.label5.TabIndex = 9;
			this.label5.Text = "Y";
			// 
			// YBox
			// 
			this.YBox.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.YBox.Location = new System.Drawing.Point(96, 75);
			this.YBox.MaxLength = 2;
			this.YBox.Name = "YBox";
			this.YBox.Size = new System.Drawing.Size(25, 22);
			this.YBox.TabIndex = 10;
			this.YBox.TextChanged += new System.EventHandler(this.YBox_TextChanged);
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(84, 22);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(21, 13);
			this.label6.TabIndex = 15;
			this.label6.Text = "SP";
			// 
			// SPBox
			// 
			this.SPBox.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.SPBox.Location = new System.Drawing.Point(111, 19);
			this.SPBox.MaxLength = 2;
			this.SPBox.Name = "SPBox";
			this.SPBox.Size = new System.Drawing.Size(25, 22);
			this.SPBox.TabIndex = 16;
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.PCBox);
			this.groupBox3.Controls.Add(this.SPBox);
			this.groupBox3.Controls.Add(this.label1);
			this.groupBox3.Controls.Add(this.label6);
			this.groupBox3.Controls.Add(this.ABox);
			this.groupBox3.Controls.Add(this.label4);
			this.groupBox3.Controls.Add(this.label2);
			this.groupBox3.Controls.Add(this.XBox);
			this.groupBox3.Controls.Add(this.YBox);
			this.groupBox3.Controls.Add(this.label3);
			this.groupBox3.Controls.Add(this.label5);
			this.groupBox3.Controls.Add(this.PBox);
			this.groupBox3.Location = new System.Drawing.Point(297, 179);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(177, 109);
			this.groupBox3.TabIndex = 17;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Registers :";
			// 
			// groupBox4
			// 
			this.groupBox4.Controls.Add(this.StepButton);
			this.groupBox4.Controls.Add(this.StepOverButton);
			this.groupBox4.Controls.Add(this.StopButton);
			this.groupBox4.Controls.Add(this.RunButton);
			this.groupBox4.Controls.Add(this.ResetBox);
			this.groupBox4.Location = new System.Drawing.Point(297, 63);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new System.Drawing.Size(177, 110);
			this.groupBox4.TabIndex = 1;
			this.groupBox4.TabStop = false;
			this.groupBox4.Text = "Controls :";
			// 
			// StopButton
			// 
			this.StopButton.Enabled = false;
			this.StopButton.Location = new System.Drawing.Point(87, 46);
			this.StopButton.Name = "StopButton";
			this.StopButton.Size = new System.Drawing.Size(75, 23);
			this.StopButton.TabIndex = 2;
			this.StopButton.Text = "Stop";
			this.StopButton.UseVisualStyleBackColor = true;
			this.StopButton.Click += new System.EventHandler(this.StopButton_Click);
			// 
			// hexBox1
			// 
			this.hexBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.hexBox1.ColumnInfoVisible = true;
			this.hexBox1.Font = new System.Drawing.Font("Segoe UI", 9F);
			this.hexBox1.LineInfoVisible = true;
			this.hexBox1.Location = new System.Drawing.Point(581, 243);
			this.hexBox1.Name = "hexBox1";
			this.hexBox1.ShadowSelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(60)))), ((int)(((byte)(188)))), ((int)(((byte)(255)))));
			this.hexBox1.Size = new System.Drawing.Size(613, 210);
			this.hexBox1.StringViewVisible = true;
			this.hexBox1.TabIndex = 18;
			this.hexBox1.UseFixedBytesPerLine = true;
			this.hexBox1.VScrollBarVisible = true;
			this.hexBox1.Click += new System.EventHandler(this.hexBox1_Click);
			// 
			// pictureBox1
			// 
			this.pictureBox1.BackColor = System.Drawing.Color.Black;
			this.pictureBox1.Location = new System.Drawing.Point(297, 373);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(256, 240);
			this.pictureBox1.TabIndex = 19;
			this.pictureBox1.TabStop = false;
			// 
			// ROMBox
			// 
			this.ROMBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.ROMBox.FormattingEnabled = true;
			this.ROMBox.Location = new System.Drawing.Point(6, 19);
			this.ROMBox.Name = "ROMBox";
			this.ROMBox.Size = new System.Drawing.Size(255, 56);
			this.ROMBox.TabIndex = 20;
			this.ROMBox.SelectedIndexChanged += new System.EventHandler(this.ROMBox_SelectedIndexChanged);
			// 
			// GroupBox12
			// 
			this.GroupBox12.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.GroupBox12.Controls.Add(this.ROMBox);
			this.GroupBox12.Location = new System.Drawing.Point(297, 619);
			this.GroupBox12.Name = "GroupBox12";
			this.GroupBox12.Size = new System.Drawing.Size(270, 83);
			this.GroupBox12.TabIndex = 21;
			this.GroupBox12.TabStop = false;
			this.GroupBox12.Text = "ROM :";
			// 
			// timer1
			// 
			this.timer1.Interval = 50;
			this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
			// 
			// groupBox5
			// 
			this.groupBox5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.groupBox5.Controls.Add(this.ROMInfoView);
			this.groupBox5.Location = new System.Drawing.Point(12, 440);
			this.groupBox5.Name = "groupBox5";
			this.groupBox5.Size = new System.Drawing.Size(279, 262);
			this.groupBox5.TabIndex = 22;
			this.groupBox5.TabStop = false;
			this.groupBox5.Text = "ROM Informations :";
			// 
			// ROMInfoView
			// 
			this.ROMInfoView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.PropertyCol,
            this.ValueCol});
			this.ROMInfoView.GridLines = true;
			this.ROMInfoView.Location = new System.Drawing.Point(6, 19);
			this.ROMInfoView.Name = "ROMInfoView";
			this.ROMInfoView.Size = new System.Drawing.Size(267, 235);
			this.ROMInfoView.Sorting = System.Windows.Forms.SortOrder.Ascending;
			this.ROMInfoView.TabIndex = 3;
			this.ROMInfoView.UseCompatibleStateImageBehavior = false;
			this.ROMInfoView.View = System.Windows.Forms.View.Details;
			// 
			// PropertyCol
			// 
			this.PropertyCol.Text = "Property";
			this.PropertyCol.Width = 150;
			// 
			// ValueCol
			// 
			this.ValueCol.Text = "Value";
			this.ValueCol.Width = 100;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1209, 727);
			this.Controls.Add(this.groupBox5);
			this.Controls.Add(this.GroupBox12);
			this.Controls.Add(this.pictureBox1);
			this.Controls.Add(this.hexBox1);
			this.Controls.Add(this.groupBox4);
			this.Controls.Add(this.groupBox3);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.toolStrip1);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.StackGroupBox);
			this.Controls.Add(this.statusStrip1);
			this.Controls.Add(this.menuStrip1);
			this.Controls.Add(this.SourceCodeBox);
			this.MainMenuStrip = this.menuStrip1;
			this.MinimumSize = new System.Drawing.Size(1225, 765);
			this.Name = "Form1";
			this.Text = "NES";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.StackGroupBox.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.toolStrip1.ResumeLayout(false);
			this.toolStrip1.PerformLayout();
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.groupBox3.ResumeLayout(false);
			this.groupBox3.PerformLayout();
			this.groupBox4.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.GroupBox12.ResumeLayout(false);
			this.groupBox5.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ListBox SourceCodeBox;
		private System.Windows.Forms.StatusStrip statusStrip1;
		private System.Windows.Forms.Button StepButton;
		private System.Windows.Forms.ListBox StackListBox;
		private System.Windows.Forms.GroupBox StackGroupBox;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox ABox;
		private System.Windows.Forms.TextBox XBox;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox PBox;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox PCBox;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.CheckBox FlagB;
		private System.Windows.Forms.CheckBox FlagC;
		private System.Windows.Forms.CheckBox FlagU;
		private System.Windows.Forms.CheckBox FlagZ;
		private System.Windows.Forms.CheckBox FlagI;
		private System.Windows.Forms.CheckBox FlagV;
		private System.Windows.Forms.CheckBox FlagD;
		private System.Windows.Forms.CheckBox FlagN;
		private System.Windows.Forms.ToolStrip toolStrip1;
		private System.Windows.Forms.ToolStripButton ouvrirToolStripButton;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
		private System.Windows.Forms.ToolStripButton ToolStripButton;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
		private System.Windows.Forms.Button ResetBox;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Button StepOverButton;
		private System.Windows.Forms.Button RunButton;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox YBox;
		private System.Windows.Forms.TextBox MemoryBox;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox SPBox;
		private System.Windows.Forms.GroupBox groupBox4;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.ComboBox BankBox;
		private Be.Windows.Forms.HexBox hexBox1;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.ListBox ROMBox;
		private System.Windows.Forms.GroupBox GroupBox12;
		private System.Windows.Forms.Timer timer1;
		private System.Windows.Forms.Button StopButton;
		private System.Windows.Forms.GroupBox groupBox5;
		private System.Windows.Forms.ListView ROMInfoView;
		private System.Windows.Forms.ColumnHeader PropertyCol;
		private System.Windows.Forms.ColumnHeader ValueCol;
	}
}

