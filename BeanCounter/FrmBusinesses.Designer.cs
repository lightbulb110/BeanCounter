using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace BeanCounter
{
    partial class FrmBusinesses
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components;

        private GroupBox gbBusinesses;

        private DataGridView dgvBusinesses;

        private ContextMenuStrip cmsDelete;

        private ToolStripMenuItem tsmiDelete;

        private Label lblBusinessType;

        private ComboBox cbBusinessType;

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
            this.gbBusinesses = new System.Windows.Forms.GroupBox();
            this.lblBusinessType = new System.Windows.Forms.Label();
            this.cbBusinessType = new System.Windows.Forms.ComboBox();
            this.dgvBusinesses = new System.Windows.Forms.DataGridView();
            this.cmsDelete = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.gbBusinesses.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBusinesses)).BeginInit();
            this.cmsDelete.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbBusinesses
            // 
            this.gbBusinesses.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbBusinesses.Controls.Add(this.lblBusinessType);
            this.gbBusinesses.Controls.Add(this.cbBusinessType);
            this.gbBusinesses.Controls.Add(this.dgvBusinesses);
            this.gbBusinesses.Location = new System.Drawing.Point(12, 12);
            this.gbBusinesses.Name = "gbBusinesses";
            this.gbBusinesses.Size = new System.Drawing.Size(611, 448);
            this.gbBusinesses.TabIndex = 0;
            this.gbBusinesses.TabStop = false;
            // 
            // lblBusinessType
            // 
            this.lblBusinessType.AutoSize = true;
            this.lblBusinessType.Location = new System.Drawing.Point(194, 22);
            this.lblBusinessType.Name = "lblBusinessType";
            this.lblBusinessType.Size = new System.Drawing.Size(308, 13);
            this.lblBusinessType.TabIndex = 4;
            this.lblBusinessType.Text = " * Needs to be a exact match in order to automatically categoize";
            // 
            // cbBusinessType
            // 
            this.cbBusinessType.FormattingEnabled = true;
            this.cbBusinessType.Items.AddRange(new object[] {
            "Local Businesses *",
            "National Businesses *"});
            this.cbBusinessType.Location = new System.Drawing.Point(9, 19);
            this.cbBusinessType.Name = "cbBusinessType";
            this.cbBusinessType.Size = new System.Drawing.Size(179, 21);
            this.cbBusinessType.TabIndex = 3;
            this.cbBusinessType.Text = "National Businesses *";
            this.cbBusinessType.SelectedIndexChanged += new System.EventHandler(this.cbBusinessType_SelectedIndexChanged);
            // 
            // dgvBusinesses
            // 
            this.dgvBusinesses.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvBusinesses.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvBusinesses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBusinesses.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke;
            this.dgvBusinesses.Location = new System.Drawing.Point(9, 55);
            this.dgvBusinesses.Name = "dgvBusinesses";
            this.dgvBusinesses.Size = new System.Drawing.Size(596, 387);
            this.dgvBusinesses.TabIndex = 2;
            this.dgvBusinesses.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvBusinesses_CellContentClick);
            this.dgvBusinesses.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvBusinesses_CellMouseClick);
            this.dgvBusinesses.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgvBusinesses_EditingControlShowing);
            this.dgvBusinesses.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvBusinesses_RowEnter);
            this.dgvBusinesses.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvBusinesses_RowHeaderMouseClick);
            // 
            // cmsDelete
            // 
            this.cmsDelete.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiDelete});
            this.cmsDelete.Name = "contextMenuStrip1";
            this.cmsDelete.Size = new System.Drawing.Size(108, 26);
            // 
            // tsmiDelete
            // 
            this.tsmiDelete.Name = "tsmiDelete";
            this.tsmiDelete.Size = new System.Drawing.Size(107, 22);
            this.tsmiDelete.Text = "Delete";
            this.tsmiDelete.Click += new System.EventHandler(this.tsmiDelete_Click);
            // 
            // FrmBusinesses
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(635, 471);
            this.Controls.Add(this.gbBusinesses);
            this.Name = "FrmBusinesses";
            this.Text = "Businesses";
            this.Load += new System.EventHandler(this.Businesses_Load);
            this.gbBusinesses.ResumeLayout(false);
            this.gbBusinesses.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBusinesses)).EndInit();
            this.cmsDelete.ResumeLayout(false);
            this.ResumeLayout(false);

        }
    }
    #endregion
}