namespace TextReplacer
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

            if (writer != null)
            {
                writer.Dispose();
            }
            if (modifier != null)
            {
                modifier.Dispose();
            }
            if (reader != null)
            {
                reader.Dispose();
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
            this.tabControl = new System.Windows.Forms.TabControl();
            this.sourceTab = new System.Windows.Forms.TabPage();
            this.richTextBoxSource = new System.Windows.Forms.RichTextBox();
            this.destTab = new System.Windows.Forms.TabPage();
            this.richTextBoxDestination = new System.Windows.Forms.RichTextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.replaceBox = new System.Windows.Forms.TextBox();
            this.findBox = new System.Windows.Forms.TextBox();
            this.replaceLabel = new System.Windows.Forms.Label();
            this.findLabel = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openTextFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyButton = new System.Windows.Forms.Button();
            this.resetButton = new System.Windows.Forms.Button();
            this.countLabel = new System.Windows.Forms.Label();
            this.notifyBox = new System.Windows.Forms.CheckBox();
            this.saveDestinationFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.tabControl.SuspendLayout();
            this.sourceTab.SuspendLayout();
            this.destTab.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.sourceTab);
            this.tabControl.Controls.Add(this.destTab);
            this.tabControl.Location = new System.Drawing.Point(13, 183);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(816, 416);
            this.tabControl.TabIndex = 0;
            // 
            // sourceTab
            // 
            this.sourceTab.Controls.Add(this.richTextBoxSource);
            this.sourceTab.Location = new System.Drawing.Point(4, 22);
            this.sourceTab.Name = "sourceTab";
            this.sourceTab.Padding = new System.Windows.Forms.Padding(3);
            this.sourceTab.Size = new System.Drawing.Size(808, 390);
            this.sourceTab.TabIndex = 0;
            this.sourceTab.Text = "Source";
            this.sourceTab.UseVisualStyleBackColor = true;
            // 
            // richTextBoxSource
            // 
            this.richTextBoxSource.Location = new System.Drawing.Point(3, 3);
            this.richTextBoxSource.Name = "richTextBoxSource";
            this.richTextBoxSource.ReadOnly = true;
            this.richTextBoxSource.Size = new System.Drawing.Size(802, 384);
            this.richTextBoxSource.TabIndex = 0;
            this.richTextBoxSource.Text = "";
            // 
            // destTab
            // 
            this.destTab.Controls.Add(this.richTextBoxDestination);
            this.destTab.Location = new System.Drawing.Point(4, 22);
            this.destTab.Name = "destTab";
            this.destTab.Padding = new System.Windows.Forms.Padding(3);
            this.destTab.Size = new System.Drawing.Size(808, 390);
            this.destTab.TabIndex = 1;
            this.destTab.Text = "Destination";
            this.destTab.UseVisualStyleBackColor = true;
            // 
            // richTextBoxDestination
            // 
            this.richTextBoxDestination.Location = new System.Drawing.Point(3, 3);
            this.richTextBoxDestination.Name = "richTextBoxDestination";
            this.richTextBoxDestination.ReadOnly = true;
            this.richTextBoxDestination.Size = new System.Drawing.Size(802, 384);
            this.richTextBoxDestination.TabIndex = 0;
            this.richTextBoxDestination.Text = "";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.notifyBox);
            this.groupBox1.Controls.Add(this.countLabel);
            this.groupBox1.Controls.Add(this.replaceBox);
            this.groupBox1.Controls.Add(this.findBox);
            this.groupBox1.Controls.Add(this.replaceLabel);
            this.groupBox1.Controls.Add(this.findLabel);
            this.groupBox1.Location = new System.Drawing.Point(13, 46);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(567, 122);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // replaceBox
            // 
            this.replaceBox.Location = new System.Drawing.Point(93, 54);
            this.replaceBox.Name = "replaceBox";
            this.replaceBox.Size = new System.Drawing.Size(100, 20);
            this.replaceBox.TabIndex = 3;
            // 
            // findBox
            // 
            this.findBox.Location = new System.Drawing.Point(93, 28);
            this.findBox.Name = "findBox";
            this.findBox.Size = new System.Drawing.Size(100, 20);
            this.findBox.TabIndex = 2;
            // 
            // replaceLabel
            // 
            this.replaceLabel.AutoSize = true;
            this.replaceLabel.Location = new System.Drawing.Point(15, 57);
            this.replaceLabel.Name = "replaceLabel";
            this.replaceLabel.Size = new System.Drawing.Size(72, 13);
            this.replaceLabel.TabIndex = 1;
            this.replaceLabel.Text = "Replace with:";
            // 
            // findLabel
            // 
            this.findLabel.AutoSize = true;
            this.findLabel.Location = new System.Drawing.Point(15, 31);
            this.findLabel.Name = "findLabel";
            this.findLabel.Size = new System.Drawing.Size(30, 13);
            this.findLabel.TabIndex = 0;
            this.findLabel.Text = "Find:";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(841, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openTextFileToolStripMenuItem,
            this.saveDestinationFileToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openTextFileToolStripMenuItem
            // 
            this.openTextFileToolStripMenuItem.Name = "openTextFileToolStripMenuItem";
            this.openTextFileToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.openTextFileToolStripMenuItem.Text = "Open Text File";
            this.openTextFileToolStripMenuItem.Click += new System.EventHandler(this.openTextFileToolStripMenuItem_Click);
            // 
            // copyButton
            // 
            this.copyButton.Location = new System.Drawing.Point(622, 128);
            this.copyButton.Name = "copyButton";
            this.copyButton.Size = new System.Drawing.Size(203, 23);
            this.copyButton.TabIndex = 4;
            this.copyButton.Text = "Copy to Destination Tab";
            this.copyButton.UseVisualStyleBackColor = true;
            this.copyButton.Click += new System.EventHandler(this.copyButton_Click);
            // 
            // resetButton
            // 
            this.resetButton.Location = new System.Drawing.Point(622, 154);
            this.resetButton.Name = "resetButton";
            this.resetButton.Size = new System.Drawing.Size(203, 23);
            this.resetButton.TabIndex = 5;
            this.resetButton.Text = "Clear Dest. and remove marks";
            this.resetButton.UseVisualStyleBackColor = true;
            this.resetButton.Click += new System.EventHandler(this.resetButton_Click);
            // 
            // countLabel
            // 
            this.countLabel.AutoSize = true;
            this.countLabel.Location = new System.Drawing.Point(413, 92);
            this.countLabel.Name = "countLabel";
            this.countLabel.Size = new System.Drawing.Size(98, 13);
            this.countLabel.TabIndex = 6;
            this.countLabel.Text = "No. Replacements:";
            // 
            // notifyBox
            // 
            this.notifyBox.AutoSize = true;
            this.notifyBox.Location = new System.Drawing.Point(93, 87);
            this.notifyBox.Name = "notifyBox";
            this.notifyBox.Size = new System.Drawing.Size(158, 17);
            this.notifyBox.TabIndex = 7;
            this.notifyBox.Text = "Notify user on every match?";
            this.notifyBox.UseVisualStyleBackColor = true;
            // 
            // saveDestinationFileToolStripMenuItem
            // 
            this.saveDestinationFileToolStripMenuItem.Name = "saveDestinationFileToolStripMenuItem";
            this.saveDestinationFileToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.saveDestinationFileToolStripMenuItem.Text = "Save Destination File";
            this.saveDestinationFileToolStripMenuItem.Click += new System.EventHandler(this.saveDestinationFileToolStripMenuItem_Click);
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.saveFileDialog1_FileOk);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(841, 611);
            this.Controls.Add(this.resetButton);
            this.Controls.Add(this.copyButton);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "TextReplacer";
            this.tabControl.ResumeLayout(false);
            this.sourceTab.ResumeLayout(false);
            this.destTab.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage sourceTab;
        private System.Windows.Forms.RichTextBox richTextBoxSource;
        private System.Windows.Forms.TabPage destTab;
        private System.Windows.Forms.RichTextBox richTextBoxDestination;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox replaceBox;
        private System.Windows.Forms.TextBox findBox;
        private System.Windows.Forms.Label replaceLabel;
        private System.Windows.Forms.Label findLabel;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openTextFileToolStripMenuItem;
        private System.Windows.Forms.Button copyButton;
        private System.Windows.Forms.Button resetButton;
        private System.Windows.Forms.Label countLabel;
        private System.Windows.Forms.CheckBox notifyBox;
        private System.Windows.Forms.ToolStripMenuItem saveDestinationFileToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    }
}

