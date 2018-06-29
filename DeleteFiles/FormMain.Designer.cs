namespace DeleteFiles
{
    partial class FormMain
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
      this.buttonDeleteFiles = new System.Windows.Forms.Button();
      this.listBoxFilesDeleted = new System.Windows.Forms.ListBox();
      this.listBoxDrivesUsed = new System.Windows.Forms.ListBox();
      this.SuspendLayout();
      // 
      // buttonDeleteFiles
      // 
      this.buttonDeleteFiles.Location = new System.Drawing.Point(12, 28);
      this.buttonDeleteFiles.Name = "buttonDeleteFiles";
      this.buttonDeleteFiles.Size = new System.Drawing.Size(75, 23);
      this.buttonDeleteFiles.TabIndex = 0;
      this.buttonDeleteFiles.Text = "Delete";
      this.buttonDeleteFiles.UseVisualStyleBackColor = true;
      this.buttonDeleteFiles.Click += new System.EventHandler(this.buttonDeleteFiles_Click);
      // 
      // listBoxFilesDeleted
      // 
      this.listBoxFilesDeleted.FormattingEnabled = true;
      this.listBoxFilesDeleted.Location = new System.Drawing.Point(138, 66);
      this.listBoxFilesDeleted.Name = "listBoxFilesDeleted";
      this.listBoxFilesDeleted.Size = new System.Drawing.Size(477, 459);
      this.listBoxFilesDeleted.TabIndex = 1;
      // 
      // listBoxDrivesUsed
      // 
      this.listBoxDrivesUsed.FormattingEnabled = true;
      this.listBoxDrivesUsed.Location = new System.Drawing.Point(12, 66);
      this.listBoxDrivesUsed.Name = "listBoxDrivesUsed";
      this.listBoxDrivesUsed.Size = new System.Drawing.Size(106, 459);
      this.listBoxDrivesUsed.TabIndex = 2;
      // 
      // FormMain
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(1265, 593);
      this.Controls.Add(this.listBoxDrivesUsed);
      this.Controls.Add(this.listBoxFilesDeleted);
      this.Controls.Add(this.buttonDeleteFiles);
      this.Name = "FormMain";
      this.Text = "Delete Files";
      this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonDeleteFiles;
        private System.Windows.Forms.ListBox listBoxFilesDeleted;
        private System.Windows.Forms.ListBox listBoxDrivesUsed;
    }
}

