namespace NugetBuilder
{
    partial class BuildDetails
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
            this.lblVersion = new System.Windows.Forms.Label();
            this.lblReleaseNotes = new System.Windows.Forms.Label();
            this.txtVersion = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.btnBuild = new System.Windows.Forms.Button();
            this.cmbBuild = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblProjectLocation = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblVersion
            // 
            this.lblVersion.AutoSize = true;
            this.lblVersion.Location = new System.Drawing.Point(12, 69);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(42, 13);
            this.lblVersion.TabIndex = 0;
            this.lblVersion.Text = "Version";
            // 
            // lblReleaseNotes
            // 
            this.lblReleaseNotes.AutoSize = true;
            this.lblReleaseNotes.Location = new System.Drawing.Point(12, 105);
            this.lblReleaseNotes.Name = "lblReleaseNotes";
            this.lblReleaseNotes.Size = new System.Drawing.Size(77, 13);
            this.lblReleaseNotes.TabIndex = 1;
            this.lblReleaseNotes.Text = "Release Notes";
            // 
            // txtVersion
            // 
            this.txtVersion.Location = new System.Drawing.Point(97, 69);
            this.txtVersion.Name = "txtVersion";
            this.txtVersion.Size = new System.Drawing.Size(100, 20);
            this.txtVersion.TabIndex = 2;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(97, 105);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(408, 138);
            this.textBox2.TabIndex = 3;
            // 
            // btnBuild
            // 
            this.btnBuild.Location = new System.Drawing.Point(430, 249);
            this.btnBuild.Name = "btnBuild";
            this.btnBuild.Size = new System.Drawing.Size(75, 23);
            this.btnBuild.TabIndex = 4;
            this.btnBuild.Text = "Build";
            this.btnBuild.UseVisualStyleBackColor = true;
            this.btnBuild.Click += new System.EventHandler(this.btnBuild_Click);
            // 
            // cmbBuild
            // 
            this.cmbBuild.FormattingEnabled = true;
            this.cmbBuild.Location = new System.Drawing.Point(97, 37);
            this.cmbBuild.Name = "cmbBuild";
            this.cmbBuild.Size = new System.Drawing.Size(121, 21);
            this.cmbBuild.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Build";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Project Location";
            // 
            // lblProjectLocation
            // 
            this.lblProjectLocation.AutoSize = true;
            this.lblProjectLocation.Location = new System.Drawing.Point(106, 9);
            this.lblProjectLocation.Name = "lblProjectLocation";
            this.lblProjectLocation.Size = new System.Drawing.Size(35, 13);
            this.lblProjectLocation.TabIndex = 9;
            this.lblProjectLocation.Text = "label4";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(217, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(183, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "(leave blank to use assembly version)";
            // 
            // BuildDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(781, 322);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblProjectLocation);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbBuild);
            this.Controls.Add(this.btnBuild);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.txtVersion);
            this.Controls.Add(this.lblReleaseNotes);
            this.Controls.Add(this.lblVersion);
            this.Name = "BuildDetails";
            this.Text = "Nuget Builder";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblVersion;
        private System.Windows.Forms.Label lblReleaseNotes;
        private System.Windows.Forms.TextBox txtVersion;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button btnBuild;
        private System.Windows.Forms.ComboBox cmbBuild;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblProjectLocation;
        private System.Windows.Forms.Label label2;
    }
}