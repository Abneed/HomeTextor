namespace HomeTextor
{
    partial class FormSample
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
            this.tabControlSample = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cerrarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cerrarTodosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cerrarTodosExceptoEstaVentanaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.richTextBox2 = new System.Windows.Forms.RichTextBox();
            this.tabControlSample.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControlSample
            // 
            this.tabControlSample.AllowDrop = true;
            this.tabControlSample.ContextMenuStrip = this.contextMenuStrip1;
            this.tabControlSample.Controls.Add(this.tabPage1);
            this.tabControlSample.Controls.Add(this.tabPage2);
            this.tabControlSample.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tabControlSample.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlSample.HotTrack = true;
            this.tabControlSample.Location = new System.Drawing.Point(0, 0);
            this.tabControlSample.Name = "tabControlSample";
            this.tabControlSample.SelectedIndex = 0;
            this.tabControlSample.Size = new System.Drawing.Size(284, 261);
            this.tabControlSample.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.richTextBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(276, 235);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.richTextBox2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(276, 235);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cerrarToolStripMenuItem,
            this.cerrarTodosToolStripMenuItem,
            this.cerrarTodosExceptoEstaVentanaToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(208, 70);
            // 
            // cerrarToolStripMenuItem
            // 
            this.cerrarToolStripMenuItem.Name = "cerrarToolStripMenuItem";
            this.cerrarToolStripMenuItem.Size = new System.Drawing.Size(207, 22);
            this.cerrarToolStripMenuItem.Text = "Cerrar";
            this.cerrarToolStripMenuItem.Click += new System.EventHandler(this.cerrarToolStripMenuItem_Click);
            // 
            // cerrarTodosToolStripMenuItem
            // 
            this.cerrarTodosToolStripMenuItem.Name = "cerrarTodosToolStripMenuItem";
            this.cerrarTodosToolStripMenuItem.Size = new System.Drawing.Size(207, 22);
            this.cerrarTodosToolStripMenuItem.Text = "Cerrar todos";
            this.cerrarTodosToolStripMenuItem.Click += new System.EventHandler(this.cerrarTodosToolStripMenuItem_Click);
            // 
            // cerrarTodosExceptoEstaVentanaToolStripMenuItem
            // 
            this.cerrarTodosExceptoEstaVentanaToolStripMenuItem.Name = "cerrarTodosExceptoEstaVentanaToolStripMenuItem";
            this.cerrarTodosExceptoEstaVentanaToolStripMenuItem.Size = new System.Drawing.Size(207, 22);
            this.cerrarTodosExceptoEstaVentanaToolStripMenuItem.Text = "Cerrar todos excepto esta";
            this.cerrarTodosExceptoEstaVentanaToolStripMenuItem.Click += new System.EventHandler(this.cerrarTodosExceptoEstaVentanaToolStripMenuItem_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox1.Location = new System.Drawing.Point(3, 3);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(270, 229);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            // 
            // richTextBox2
            // 
            this.richTextBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox2.Location = new System.Drawing.Point(3, 3);
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.Size = new System.Drawing.Size(270, 229);
            this.richTextBox2.TabIndex = 0;
            this.richTextBox2.Text = "";
            // 
            // FormSample
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.tabControlSample);
            this.Name = "FormSample";
            this.Text = "FormSample";
            this.tabControlSample.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControlSample;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem cerrarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cerrarTodosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cerrarTodosExceptoEstaVentanaToolStripMenuItem;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.RichTextBox richTextBox2;
    }
}