
namespace WinForms_Draft_2
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            splitContainer2 = new System.Windows.Forms.SplitContainer();
            splitContainer4 = new System.Windows.Forms.SplitContainer();
            leftTextBox = new SyncTextBox();
            rightTextBox = new SyncTextBox();
            VScrollBar1 = new System.Windows.Forms.VScrollBar();
            openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            panel3 = new System.Windows.Forms.Panel();
            pervDifferenceButton = new System.Windows.Forms.Button();
            nextDifferenceButton = new System.Windows.Forms.Button();
            CompareButton = new System.Windows.Forms.Button();
            splitContainer3 = new System.Windows.Forms.SplitContainer();
            leftPathBox = new System.Windows.Forms.TextBox();
            leftChooseButton = new System.Windows.Forms.Button();
            rightPathBox = new System.Windows.Forms.TextBox();
            rightChooseButton = new System.Windows.Forms.Button();
            textBoxPanel = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)splitContainer2).BeginInit();
            splitContainer2.Panel1.SuspendLayout();
            splitContainer2.Panel2.SuspendLayout();
            splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer4).BeginInit();
            splitContainer4.Panel1.SuspendLayout();
            splitContainer4.Panel2.SuspendLayout();
            splitContainer4.SuspendLayout();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer3).BeginInit();
            splitContainer3.Panel1.SuspendLayout();
            splitContainer3.Panel2.SuspendLayout();
            splitContainer3.SuspendLayout();
            textBoxPanel.SuspendLayout();
            SuspendLayout();
            // 
            // splitContainer2
            // 
            splitContainer2.Cursor = System.Windows.Forms.Cursors.VSplit;
            splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            splitContainer2.IsSplitterFixed = true;
            splitContainer2.Location = new System.Drawing.Point(0, 0);
            splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            splitContainer2.Panel1.Controls.Add(splitContainer4);
            // 
            // splitContainer2.Panel2
            // 
            splitContainer2.Panel2.BackColor = System.Drawing.SystemColors.ControlDark;
            splitContainer2.Panel2.Controls.Add(rightTextBox);
            splitContainer2.Size = new System.Drawing.Size(982, 366);
            splitContainer2.SplitterDistance = 500;
            splitContainer2.SplitterWidth = 1;
            splitContainer2.TabIndex = 1;
            // 
            // splitContainer4
            // 
            splitContainer4.Cursor = System.Windows.Forms.Cursors.VSplit;
            splitContainer4.Dock = System.Windows.Forms.DockStyle.Fill;
            splitContainer4.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            splitContainer4.IsSplitterFixed = true;
            splitContainer4.Location = new System.Drawing.Point(0, 0);
            splitContainer4.Name = "splitContainer4";
            // 
            // splitContainer4.Panel1
            // 
            splitContainer4.Panel1.Controls.Add(leftTextBox);
            splitContainer4.Panel1MinSize = 16;
            // 
            // splitContainer4.Panel2
            // 
            splitContainer4.Panel2.Controls.Add(VScrollBar1);
            splitContainer4.Panel2MinSize = 16;
            splitContainer4.Size = new System.Drawing.Size(500, 366);
            splitContainer4.SplitterDistance = 474;
            splitContainer4.SplitterWidth = 1;
            splitContainer4.TabIndex = 5;
            // 
            // leftTextBox
            // 
            leftTextBox.BackColor = System.Drawing.Color.White;
            leftTextBox.Buddy = rightTextBox;
            leftTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            leftTextBox.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            leftTextBox.ForeColor = System.Drawing.Color.Black;
            leftTextBox.Location = new System.Drawing.Point(0, 0);
            leftTextBox.Name = "leftTextBox";
            leftTextBox.ReadOnly = true;
            leftTextBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            leftTextBox.SelectionHighlightEnabled = false;
            leftTextBox.Size = new System.Drawing.Size(474, 366);
            leftTextBox.TabIndex = 3;
            leftTextBox.Text = "";
            // 
            // rightTextBox
            // 
            rightTextBox.BackColor = System.Drawing.Color.White;
            rightTextBox.Buddy = leftTextBox;
            rightTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            rightTextBox.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            rightTextBox.ForeColor = System.Drawing.SystemColors.Desktop;
            rightTextBox.Location = new System.Drawing.Point(0, 0);
            rightTextBox.Name = "rightTextBox";
            rightTextBox.ReadOnly = true;
            rightTextBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            rightTextBox.SelectionHighlightEnabled = false;
            rightTextBox.Size = new System.Drawing.Size(481, 366);
            rightTextBox.TabIndex = 3;
            rightTextBox.Text = "";
            // 
            // VScrollBar1
            // 
            VScrollBar1.Dock = System.Windows.Forms.DockStyle.Fill;
            VScrollBar1.Location = new System.Drawing.Point(0, 0);
            VScrollBar1.Name = "VScrollBar1";
            VScrollBar1.Size = new System.Drawing.Size(25, 366);
            VScrollBar1.TabIndex = 4;
            VScrollBar1.Scroll += VScrollBar1_Scroll;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // panel3
            // 
            panel3.Controls.Add(pervDifferenceButton);
            panel3.Controls.Add(nextDifferenceButton);
            panel3.Controls.Add(CompareButton);
            panel3.Controls.Add(splitContainer3);
            panel3.Dock = System.Windows.Forms.DockStyle.Top;
            panel3.Location = new System.Drawing.Point(0, 0);
            panel3.Name = "panel3";
            panel3.Size = new System.Drawing.Size(982, 55);
            panel3.TabIndex = 2;
            // 
            // pervDifferenceButton
            // 
            pervDifferenceButton.Dock = System.Windows.Forms.DockStyle.Left;
            pervDifferenceButton.Location = new System.Drawing.Point(400, 27);
            pervDifferenceButton.Name = "pervDifferenceButton";
            pervDifferenceButton.Size = new System.Drawing.Size(200, 28);
            pervDifferenceButton.TabIndex = 3;
            pervDifferenceButton.Text = "Предыдущее различие";
            pervDifferenceButton.UseVisualStyleBackColor = true;
            pervDifferenceButton.Click += pervDifferenceButton_Click;
            // 
            // nextDifferenceButton
            // 
            nextDifferenceButton.Dock = System.Windows.Forms.DockStyle.Left;
            nextDifferenceButton.Location = new System.Drawing.Point(200, 27);
            nextDifferenceButton.Name = "nextDifferenceButton";
            nextDifferenceButton.Size = new System.Drawing.Size(200, 28);
            nextDifferenceButton.TabIndex = 2;
            nextDifferenceButton.Text = "Следущее различие";
            nextDifferenceButton.UseVisualStyleBackColor = true;
            nextDifferenceButton.Click += nextDifferenceButton_Click;
            // 
            // CompareButton
            // 
            CompareButton.Dock = System.Windows.Forms.DockStyle.Left;
            CompareButton.Location = new System.Drawing.Point(0, 27);
            CompareButton.Name = "CompareButton";
            CompareButton.Size = new System.Drawing.Size(200, 28);
            CompareButton.TabIndex = 1;
            CompareButton.Text = "Сравнить";
            CompareButton.UseVisualStyleBackColor = true;
            CompareButton.Click += CompareButton_Click;
            // 
            // splitContainer3
            // 
            splitContainer3.Cursor = System.Windows.Forms.Cursors.VSplit;
            splitContainer3.Dock = System.Windows.Forms.DockStyle.Top;
            splitContainer3.IsSplitterFixed = true;
            splitContainer3.Location = new System.Drawing.Point(0, 0);
            splitContainer3.Name = "splitContainer3";
            // 
            // splitContainer3.Panel1
            // 
            splitContainer3.Panel1.Controls.Add(leftPathBox);
            splitContainer3.Panel1.Controls.Add(leftChooseButton);
            // 
            // splitContainer3.Panel2
            // 
            splitContainer3.Panel2.Controls.Add(rightPathBox);
            splitContainer3.Panel2.Controls.Add(rightChooseButton);
            splitContainer3.Size = new System.Drawing.Size(982, 27);
            splitContainer3.SplitterDistance = 485;
            splitContainer3.TabIndex = 0;
            // 
            // leftPathBox
            // 
            leftPathBox.Dock = System.Windows.Forms.DockStyle.Fill;
            leftPathBox.Location = new System.Drawing.Point(0, 0);
            leftPathBox.Name = "leftPathBox";
            leftPathBox.Size = new System.Drawing.Size(452, 27);
            leftPathBox.TabIndex = 1;
            leftPathBox.KeyPress += leftPathBox_KeyPress;
            // 
            // leftChooseButton
            // 
            leftChooseButton.Cursor = System.Windows.Forms.Cursors.Hand;
            leftChooseButton.Dock = System.Windows.Forms.DockStyle.Right;
            leftChooseButton.Location = new System.Drawing.Point(452, 0);
            leftChooseButton.Name = "leftChooseButton";
            leftChooseButton.Size = new System.Drawing.Size(33, 27);
            leftChooseButton.TabIndex = 0;
            leftChooseButton.Text = ">>";
            leftChooseButton.UseVisualStyleBackColor = true;
            leftChooseButton.Click += leftChooseButton_Click;
            // 
            // rightPathBox
            // 
            rightPathBox.Dock = System.Windows.Forms.DockStyle.Fill;
            rightPathBox.Location = new System.Drawing.Point(0, 0);
            rightPathBox.Name = "rightPathBox";
            rightPathBox.Size = new System.Drawing.Size(460, 27);
            rightPathBox.TabIndex = 2;
            rightPathBox.KeyPress += rightPathBox_KeyPress;
            // 
            // rightChooseButton
            // 
            rightChooseButton.Cursor = System.Windows.Forms.Cursors.Hand;
            rightChooseButton.Dock = System.Windows.Forms.DockStyle.Right;
            rightChooseButton.Location = new System.Drawing.Point(460, 0);
            rightChooseButton.Name = "rightChooseButton";
            rightChooseButton.Size = new System.Drawing.Size(33, 27);
            rightChooseButton.TabIndex = 1;
            rightChooseButton.Text = ">>";
            rightChooseButton.UseVisualStyleBackColor = true;
            rightChooseButton.Click += rightChooseButton_Click;
            // 
            // textBoxPanel
            // 
            textBoxPanel.Controls.Add(splitContainer2);
            textBoxPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            textBoxPanel.Location = new System.Drawing.Point(0, 55);
            textBoxPanel.Name = "textBoxPanel";
            textBoxPanel.Size = new System.Drawing.Size(982, 366);
            textBoxPanel.TabIndex = 3;
            // 
            // Form1
            // 
            ClientSize = new System.Drawing.Size(982, 421);
            Controls.Add(textBoxPanel);
            Controls.Add(panel3);
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            MaximumSize = new System.Drawing.Size(1500, 700);
            MinimumSize = new System.Drawing.Size(930, 400);
            Name = "Form1";
            splitContainer2.Panel1.ResumeLayout(false);
            splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer2).EndInit();
            splitContainer2.ResumeLayout(false);
            splitContainer4.Panel1.ResumeLayout(false);
            splitContainer4.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer4).EndInit();
            splitContainer4.ResumeLayout(false);
            panel3.ResumeLayout(false);
            splitContainer3.Panel1.ResumeLayout(false);
            splitContainer3.Panel1.PerformLayout();
            splitContainer3.Panel2.ResumeLayout(false);
            splitContainer3.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer3).EndInit();
            splitContainer3.ResumeLayout(false);
            textBoxPanel.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private SyncTextBox leftTextBox;
        private SyncTextBox rightTextBox;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.Button leftChooseButton;
        private System.Windows.Forms.Button rightChooseButton;
        private System.Windows.Forms.TextBox leftPathBox;
        private System.Windows.Forms.TextBox rightPathBox;
        private System.Windows.Forms.Button CompareButton;
        private System.Windows.Forms.Panel textBoxPanel;
        private System.Windows.Forms.VScrollBar VScrollBar1;
        private System.Windows.Forms.SplitContainer splitContainer4;
        private System.Windows.Forms.Button nextDifferenceButton;
        private System.Windows.Forms.Button pervDifferenceButton;
    }
}

