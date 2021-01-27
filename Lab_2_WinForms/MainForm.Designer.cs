namespace Lab_2_WinForms
{
    partial class MainForm
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
            this.menuMain = new System.Windows.Forms.MenuStrip();
            this.menuOptions = new System.Windows.Forms.ToolStripMenuItem();
            this.toolLoad = new System.Windows.Forms.ToolStripMenuItem();
            this.toolSave = new System.Windows.Forms.ToolStripMenuItem();
            this.toolSaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.toolReset = new System.Windows.Forms.ToolStripMenuItem();
            this.menuInstruments = new System.Windows.Forms.ToolStripMenuItem();
            this.toolRegulations = new System.Windows.Forms.ToolStripMenuItem();
            this.toolDrawing = new System.Windows.Forms.ToolStripMenuItem();
            this.toolZoom = new System.Windows.Forms.ToolStripMenuItem();
            this.toolRotate = new System.Windows.Forms.ToolStripMenuItem();
            this.toolRotation = new System.Windows.Forms.ToolStripMenuItem();
            this.toolFlipHorizontal = new System.Windows.Forms.ToolStripMenuItem();
            this.toolFlipVertical = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.pnlDrawing = new System.Windows.Forms.Panel();
            this.trckbrBrushSize = new System.Windows.Forms.TrackBar();
            this.pnlBrushColor = new System.Windows.Forms.Panel();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.pnlZoom = new System.Windows.Forms.Panel();
            this.trckbrZoom = new System.Windows.Forms.TrackBar();
            this.picbxField = new System.Windows.Forms.PictureBox();
            this.pnlField = new System.Windows.Forms.Panel();
            this.pnlColours = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.trckbarContrast = new System.Windows.Forms.TrackBar();
            this.trckbarBright = new System.Windows.Forms.TrackBar();
            this.pnlRotation = new System.Windows.Forms.Panel();
            this.trckbrRotation = new System.Windows.Forms.TrackBar();
            this.menuMain.SuspendLayout();
            this.pnlDrawing.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trckbrBrushSize)).BeginInit();
            this.pnlZoom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trckbrZoom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picbxField)).BeginInit();
            this.pnlField.SuspendLayout();
            this.pnlColours.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trckbarContrast)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trckbarBright)).BeginInit();
            this.pnlRotation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trckbrRotation)).BeginInit();
            this.SuspendLayout();
            // 
            // menuMain
            // 
            this.menuMain.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuOptions,
            this.menuInstruments});
            this.menuMain.Location = new System.Drawing.Point(0, 0);
            this.menuMain.Name = "menuMain";
            this.menuMain.Size = new System.Drawing.Size(1360, 28);
            this.menuMain.TabIndex = 0;
            this.menuMain.Text = "menuStrip1";
            // 
            // menuOptions
            // 
            this.menuOptions.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolLoad,
            this.toolSave,
            this.toolSaveAs,
            this.toolReset});
            this.menuOptions.Name = "menuOptions";
            this.menuOptions.Size = new System.Drawing.Size(84, 24);
            this.menuOptions.Text = "Функции";
            // 
            // toolLoad
            // 
            this.toolLoad.Name = "toolLoad";
            this.toolLoad.Size = new System.Drawing.Size(260, 26);
            this.toolLoad.Text = "Загрузить изображение";
            this.toolLoad.Click += new System.EventHandler(this.toolLoad_Click);
            // 
            // toolSave
            // 
            this.toolSave.Name = "toolSave";
            this.toolSave.Size = new System.Drawing.Size(260, 26);
            this.toolSave.Text = "Сохранить";
            this.toolSave.Click += new System.EventHandler(this.toolSave_Click);
            // 
            // toolSaveAs
            // 
            this.toolSaveAs.Name = "toolSaveAs";
            this.toolSaveAs.Size = new System.Drawing.Size(260, 26);
            this.toolSaveAs.Text = "Сохранить как...";
            this.toolSaveAs.Click += new System.EventHandler(this.toolSaveAs_Click);
            // 
            // toolReset
            // 
            this.toolReset.Name = "toolReset";
            this.toolReset.Size = new System.Drawing.Size(260, 26);
            this.toolReset.Text = "Сбросить всё";
            this.toolReset.Click += new System.EventHandler(this.toolReset_Click);
            // 
            // menuInstruments
            // 
            this.menuInstruments.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolRegulations,
            this.toolDrawing,
            this.toolRotate,
            this.toolZoom});
            this.menuInstruments.Name = "menuInstruments";
            this.menuInstruments.Size = new System.Drawing.Size(117, 24);
            this.menuInstruments.Text = "Инструменты";
            // 
            // toolRegulations
            // 
            this.toolRegulations.Name = "toolRegulations";
            this.toolRegulations.Size = new System.Drawing.Size(253, 26);
            this.toolRegulations.Text = "Яркость\\контрастность";
            this.toolRegulations.Click += new System.EventHandler(this.toolRegulations_Click);
            // 
            // toolDrawing
            // 
            this.toolDrawing.Name = "toolDrawing";
            this.toolDrawing.Size = new System.Drawing.Size(253, 26);
            this.toolDrawing.Text = "Кисть";
            this.toolDrawing.Click += new System.EventHandler(this.toolDrawing_Click);
            // 
            // toolZoom
            // 
            this.toolZoom.Name = "toolZoom";
            this.toolZoom.Size = new System.Drawing.Size(253, 26);
            this.toolZoom.Text = "Увеличить\\уменьшить";
            this.toolZoom.Click += new System.EventHandler(this.toolZoom_Click);
            // 
            // toolRotate
            // 
            this.toolRotate.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolRotation,
            this.toolFlipHorizontal,
            this.toolFlipVertical});
            this.toolRotate.Name = "toolRotate";
            this.toolRotate.Size = new System.Drawing.Size(253, 26);
            this.toolRotate.Text = "Поворот\\отражение";
            // 
            // toolRotation
            // 
            this.toolRotation.Name = "toolRotation";
            this.toolRotation.Size = new System.Drawing.Size(271, 26);
            this.toolRotation.Text = "Выравнивание";
            this.toolRotation.Click += new System.EventHandler(this.toolRotation_Click);
            // 
            // toolFlipHorizontal
            // 
            this.toolFlipHorizontal.Name = "toolFlipHorizontal";
            this.toolFlipHorizontal.Size = new System.Drawing.Size(271, 26);
            this.toolFlipHorizontal.Text = "Отразить по горизонтали";
            this.toolFlipHorizontal.Click += new System.EventHandler(this.toolFlipHorizontal_Click);
            // 
            // toolFlipVertical
            // 
            this.toolFlipVertical.Name = "toolFlipVertical";
            this.toolFlipVertical.Size = new System.Drawing.Size(271, 26);
            this.toolFlipVertical.Text = "Отразить по вертикали";
            this.toolFlipVertical.Click += new System.EventHandler(this.toolFlipVertical_Click);
            // 
            // pnlDrawing
            // 
            this.pnlDrawing.Controls.Add(this.trckbrBrushSize);
            this.pnlDrawing.Controls.Add(this.pnlBrushColor);
            this.pnlDrawing.Location = new System.Drawing.Point(0, 31);
            this.pnlDrawing.Name = "pnlDrawing";
            this.pnlDrawing.Size = new System.Drawing.Size(343, 26);
            this.pnlDrawing.TabIndex = 2;
            // 
            // trckbrBrushSize
            // 
            this.trckbrBrushSize.AutoSize = false;
            this.trckbrBrushSize.Location = new System.Drawing.Point(3, 4);
            this.trckbrBrushSize.Name = "trckbrBrushSize";
            this.trckbrBrushSize.Size = new System.Drawing.Size(253, 22);
            this.trckbrBrushSize.TabIndex = 1;
            // 
            // pnlBrushColor
            // 
            this.pnlBrushColor.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.pnlBrushColor.Location = new System.Drawing.Point(262, 4);
            this.pnlBrushColor.Name = "pnlBrushColor";
            this.pnlBrushColor.Size = new System.Drawing.Size(78, 22);
            this.pnlBrushColor.TabIndex = 0;
            this.pnlBrushColor.Click += new System.EventHandler(this.pnlBrushColor_Click);
            // 
            // pnlZoom
            // 
            this.pnlZoom.AutoSize = true;
            this.pnlZoom.Controls.Add(this.trckbrZoom);
            this.pnlZoom.Location = new System.Drawing.Point(350, 31);
            this.pnlZoom.Name = "pnlZoom";
            this.pnlZoom.Size = new System.Drawing.Size(431, 29);
            this.pnlZoom.TabIndex = 3;
            // 
            // trckbrZoom
            // 
            this.trckbrZoom.AutoSize = false;
            this.trckbrZoom.Location = new System.Drawing.Point(3, 3);
            this.trckbrZoom.Maximum = 20;
            this.trckbrZoom.Name = "trckbrZoom";
            this.trckbrZoom.Size = new System.Drawing.Size(412, 23);
            this.trckbrZoom.TabIndex = 0;
            this.trckbrZoom.Scroll += new System.EventHandler(this.trckbrZoom_Scroll_1);
            // 
            // picbxField
            // 
            this.picbxField.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.picbxField.BackColor = System.Drawing.Color.Transparent;
            this.picbxField.ImageLocation = "";
            this.picbxField.Location = new System.Drawing.Point(0, 0);
            this.picbxField.Name = "picbxField";
            this.picbxField.Size = new System.Drawing.Size(405, 684);
            this.picbxField.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picbxField.TabIndex = 1;
            this.picbxField.TabStop = false;
            this.picbxField.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picbxField_MouseDown);
            this.picbxField.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picbxField_MouseMove);
            this.picbxField.MouseUp += new System.Windows.Forms.MouseEventHandler(this.picbxField_MouseUp);
            // 
            // pnlField
            // 
            this.pnlField.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlField.AutoScroll = true;
            this.pnlField.Controls.Add(this.picbxField);
            this.pnlField.Location = new System.Drawing.Point(3, 132);
            this.pnlField.Name = "pnlField";
            this.pnlField.Size = new System.Drawing.Size(1357, 836);
            this.pnlField.TabIndex = 4;
            // 
            // pnlColours
            // 
            this.pnlColours.Controls.Add(this.label2);
            this.pnlColours.Controls.Add(this.label1);
            this.pnlColours.Controls.Add(this.trckbarContrast);
            this.pnlColours.Controls.Add(this.trckbarBright);
            this.pnlColours.Location = new System.Drawing.Point(0, 64);
            this.pnlColours.Name = "pnlColours";
            this.pnlColours.Size = new System.Drawing.Size(781, 36);
            this.pnlColours.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(381, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Контраст";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Яркость";
            // 
            // trckbarContrast
            // 
            this.trckbarContrast.AutoSize = false;
            this.trckbarContrast.Location = new System.Drawing.Point(448, 6);
            this.trckbarContrast.Maximum = 200;
            this.trckbarContrast.Name = "trckbarContrast";
            this.trckbarContrast.Size = new System.Drawing.Size(303, 23);
            this.trckbarContrast.TabIndex = 1;
            this.trckbarContrast.TickFrequency = 20;
            this.trckbarContrast.Scroll += new System.EventHandler(this.trckbarContrast_Scroll);
            // 
            // trckbarBright
            // 
            this.trckbarBright.AutoSize = false;
            this.trckbarBright.Location = new System.Drawing.Point(72, 3);
            this.trckbarBright.Maximum = 45;
            this.trckbarBright.Minimum = -45;
            this.trckbarBright.Name = "trckbarBright";
            this.trckbarBright.Size = new System.Drawing.Size(303, 23);
            this.trckbarBright.TabIndex = 0;
            this.trckbarBright.TickFrequency = 9;
            this.trckbarBright.Scroll += new System.EventHandler(this.trckbarBright_Scroll);
            // 
            // pnlRotation
            // 
            this.pnlRotation.AutoSize = true;
            this.pnlRotation.Controls.Add(this.trckbrRotation);
            this.pnlRotation.Location = new System.Drawing.Point(0, 99);
            this.pnlRotation.Name = "pnlRotation";
            this.pnlRotation.Size = new System.Drawing.Size(424, 29);
            this.pnlRotation.TabIndex = 6;
            // 
            // trckbrRotation
            // 
            this.trckbrRotation.AutoSize = false;
            this.trckbrRotation.Location = new System.Drawing.Point(0, 3);
            this.trckbrRotation.Maximum = 45;
            this.trckbrRotation.Minimum = -45;
            this.trckbrRotation.Name = "trckbrRotation";
            this.trckbrRotation.Size = new System.Drawing.Size(412, 23);
            this.trckbrRotation.TabIndex = 7;
            this.trckbrRotation.TickFrequency = 9;
            this.trckbrRotation.Scroll += new System.EventHandler(this.trckbrRotation_Scroll);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1360, 903);
            this.Controls.Add(this.pnlRotation);
            this.Controls.Add(this.pnlColours);
            this.Controls.Add(this.pnlZoom);
            this.Controls.Add(this.pnlDrawing);
            this.Controls.Add(this.menuMain);
            this.Controls.Add(this.pnlField);
            this.MainMenuStrip = this.menuMain;
            this.MinimumSize = new System.Drawing.Size(850, 600);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.SizeChanged += new System.EventHandler(this.MainForm_SizeChanged);
            this.menuMain.ResumeLayout(false);
            this.menuMain.PerformLayout();
            this.pnlDrawing.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.trckbrBrushSize)).EndInit();
            this.pnlZoom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.trckbrZoom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picbxField)).EndInit();
            this.pnlField.ResumeLayout(false);
            this.pnlColours.ResumeLayout(false);
            this.pnlColours.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trckbarContrast)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trckbarBright)).EndInit();
            this.pnlRotation.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.trckbrRotation)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuMain;
        private System.Windows.Forms.ToolStripMenuItem menuOptions;
        private System.Windows.Forms.ToolStripMenuItem toolLoad;
        private System.Windows.Forms.ToolStripMenuItem toolSave;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ToolStripMenuItem toolSaveAs;
        private System.Windows.Forms.ToolStripMenuItem menuInstruments;
        private System.Windows.Forms.ToolStripMenuItem toolRotate;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.ToolStripMenuItem toolDrawing;
        private System.Windows.Forms.Panel pnlDrawing;
        private System.Windows.Forms.TrackBar trckbrBrushSize;
        private System.Windows.Forms.Panel pnlBrushColor;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.ToolStripMenuItem toolReset;
        private System.Windows.Forms.Panel pnlZoom;
        private System.Windows.Forms.TrackBar trckbrZoom;
        private System.Windows.Forms.PictureBox picbxField;
        private System.Windows.Forms.Panel pnlField;
        private System.Windows.Forms.ToolStripMenuItem toolZoom;
        private System.Windows.Forms.Panel pnlColours;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TrackBar trckbarContrast;
        private System.Windows.Forms.TrackBar trckbarBright;
        private System.Windows.Forms.ToolStripMenuItem toolRegulations;
        private System.Windows.Forms.ToolStripMenuItem toolRotation;
        private System.Windows.Forms.ToolStripMenuItem toolFlipHorizontal;
        private System.Windows.Forms.ToolStripMenuItem toolFlipVertical;
        private System.Windows.Forms.Panel pnlRotation;
        private System.Windows.Forms.TrackBar trckbrRotation;
    }
}