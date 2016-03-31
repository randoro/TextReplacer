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

            writer.Dispose();
            reader.Dispose();

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
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openTextFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyButton = new System.Windows.Forms.Button();
            this.resetButton = new System.Windows.Forms.Button();
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
            this.groupBox1.Controls.Add(this.textBox2);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(13, 46);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(567, 122);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(93, 54);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 20);
            this.textBox2.TabIndex = 3;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(93, 28);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(52, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "label2";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(52, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "label1";
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
            this.openTextFileToolStripMenuItem});
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
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openTextFileToolStripMenuItem;
        private System.Windows.Forms.Button copyButton;
        private System.Windows.Forms.Button resetButton;
    }
}

