namespace CustomerCare
{
    partial class Form1
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
            this.btnRemin = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnRemin
            // 
            this.btnRemin.Location = new System.Drawing.Point(28, 42);
            this.btnRemin.Name = "btnRemin";
            this.btnRemin.Size = new System.Drawing.Size(87, 36);
            this.btnRemin.TabIndex = 0;
            this.btnRemin.Text = "Nhắc Nhở KH";
            this.btnRemin.UseVisualStyleBackColor = true;
            this.btnRemin.Click += new System.EventHandler(this.btnRemin_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(131, 42);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(81, 36);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Text = "Thêm Mới KH";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(291, 102);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnRemin);
            this.Name = "Form1";
            this.Text = "Chăm Sóc Khách Hàng";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnRemin;
        private System.Windows.Forms.Button btnAdd;
    }
}

