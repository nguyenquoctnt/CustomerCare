namespace CustomerCare
{
    partial class FormRemin
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
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.phone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.link = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.remind = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ordered = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToOrderColumns = true;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.name,
            this.phone,
            this.date,
            this.link,
            this.remind,
            this.ordered});
            this.dataGridView.Location = new System.Drawing.Point(0, -1);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            this.dataGridView.Size = new System.Drawing.Size(804, 402);
            this.dataGridView.TabIndex = 0;
            this.dataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_CellContentClick);
            this.dataGridView.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dataGridView_DataBindingComplete);
            this.dataGridView.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.dataGridView_RowPrePaint);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(664, 407);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(131, 42);
            this.btnUpdate.TabIndex = 1;
            this.btnUpdate.Text = "Cập nhật dữ liệu";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // id
            // 
            this.id.DataPropertyName = "id";
            this.id.Frozen = true;
            this.id.HeaderText = "Mã KH";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            // 
            // name
            // 
            this.name.DataPropertyName = "name";
            this.name.FillWeight = 150F;
            this.name.Frozen = true;
            this.name.HeaderText = "Tên KH";
            this.name.Name = "name";
            this.name.ReadOnly = true;
            this.name.Width = 150;
            // 
            // phone
            // 
            this.phone.DataPropertyName = "phone";
            this.phone.Frozen = true;
            this.phone.HeaderText = "Số Điện Thoại";
            this.phone.Name = "phone";
            this.phone.ReadOnly = true;
            // 
            // date
            // 
            this.date.DataPropertyName = "date";
            this.date.FillWeight = 80F;
            this.date.Frozen = true;
            this.date.HeaderText = "Ngày Đi";
            this.date.Name = "date";
            this.date.ReadOnly = true;
            this.date.Width = 80;
            // 
            // link
            // 
            this.link.DataPropertyName = "link";
            this.link.FillWeight = 230F;
            this.link.HeaderText = "Facebook";
            this.link.Name = "link";
            this.link.ReadOnly = true;
            this.link.Width = 230;
            // 
            // remind
            // 
            this.remind.DataPropertyName = "remind";
            this.remind.FillWeight = 70F;
            this.remind.HeaderText = "Nhắc Nhở";
            this.remind.Name = "remind";
            this.remind.ReadOnly = true;
            this.remind.Width = 70;
            // 
            // ordered
            // 
            this.ordered.DataPropertyName = "ordered";
            this.ordered.FillWeight = 30F;
            this.ordered.HeaderText = "Chốt";
            this.ordered.Name = "ordered";
            this.ordered.ReadOnly = true;
            this.ordered.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ordered.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ordered.Width = 30;
            // 
            // FormRemin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.dataGridView);
            this.Name = "FormRemin";
            this.Text = "Chăm Sóc Khách Hàng";
            this.Load += new System.EventHandler(this.FormRemin_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn phone;
        private System.Windows.Forms.DataGridViewTextBoxColumn date;
        private System.Windows.Forms.DataGridViewTextBoxColumn link;
        private System.Windows.Forms.DataGridViewCheckBoxColumn remind;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ordered;
    }
}