namespace ParkingApp {
    partial class TopUpForm {
        private System.ComponentModel.IContainer components = null;

        // Объявляем ВСЕ элементы управления
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblCurrentBalance;
        private System.Windows.Forms.Label lblChooseAmount;
        private System.Windows.Forms.Button btnAmount100;
        private System.Windows.Forms.Button btnAmount500;
        private System.Windows.Forms.Button btnAmount1000;
        private System.Windows.Forms.Button btnAmount2000;
        private System.Windows.Forms.Label lblOr;
        private System.Windows.Forms.Button btnCustomAmount;
        private System.Windows.Forms.Label lblSelectedAmount;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnConfirm;

        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код конструктора форм

        private void InitializeComponent() {
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblCurrentBalance = new System.Windows.Forms.Label();
            this.lblChooseAmount = new System.Windows.Forms.Label();
            this.btnAmount100 = new System.Windows.Forms.Button();
            this.btnAmount500 = new System.Windows.Forms.Button();
            this.btnAmount1000 = new System.Windows.Forms.Button();
            this.btnAmount2000 = new System.Windows.Forms.Button();
            this.lblOr = new System.Windows.Forms.Label();
            this.btnCustomAmount = new System.Windows.Forms.Button();
            this.lblSelectedAmount = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.SuspendLayout();

            // lblTitle
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI",14F,System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(100,20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(220,32);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Пополнение баланса";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // lblCurrentBalance
            this.lblCurrentBalance.AutoSize = true;
            this.lblCurrentBalance.Font = new System.Drawing.Font("Segoe UI",11F);
            this.lblCurrentBalance.Location = new System.Drawing.Point(100,60);
            this.lblCurrentBalance.Name = "lblCurrentBalance";
            this.lblCurrentBalance.Size = new System.Drawing.Size(200,25);
            this.lblCurrentBalance.TabIndex = 1;
            this.lblCurrentBalance.Text = "Текущий баланс: 0 ₽";
            this.lblCurrentBalance.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // lblChooseAmount
            this.lblChooseAmount.AutoSize = true;
            this.lblChooseAmount.Font = new System.Drawing.Font("Segoe UI",10F);
            this.lblChooseAmount.Location = new System.Drawing.Point(80,100);
            this.lblChooseAmount.Name = "lblChooseAmount";
            this.lblChooseAmount.Size = new System.Drawing.Size(240,23);
            this.lblChooseAmount.TabIndex = 2;
            this.lblChooseAmount.Text = "Выберите сумму для пополнения:";

            // btnAmount100
            this.btnAmount100.BackColor = System.Drawing.Color.LightGray;
            this.btnAmount100.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAmount100.Font = new System.Drawing.Font("Segoe UI",10F,System.Drawing.FontStyle.Bold);
            this.btnAmount100.Location = new System.Drawing.Point(30,130);
            this.btnAmount100.Name = "btnAmount100";
            this.btnAmount100.Size = new System.Drawing.Size(80,40);
            this.btnAmount100.TabIndex = 3;
            this.btnAmount100.Text = "100 ₽";
            this.btnAmount100.UseVisualStyleBackColor = false;

            // btnAmount500
            this.btnAmount500.BackColor = System.Drawing.Color.LightGray;
            this.btnAmount500.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAmount500.Font = new System.Drawing.Font("Segoe UI",10F,System.Drawing.FontStyle.Bold);
            this.btnAmount500.Location = new System.Drawing.Point(120,130);
            this.btnAmount500.Name = "btnAmount500";
            this.btnAmount500.Size = new System.Drawing.Size(80,40);
            this.btnAmount500.TabIndex = 4;
            this.btnAmount500.Text = "500 ₽";
            this.btnAmount500.UseVisualStyleBackColor = false;

            // btnAmount1000
            this.btnAmount1000.BackColor = System.Drawing.Color.LightGray;
            this.btnAmount1000.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAmount1000.Font = new System.Drawing.Font("Segoe UI",10F,System.Drawing.FontStyle.Bold);
            this.btnAmount1000.Location = new System.Drawing.Point(210,130);
            this.btnAmount1000.Name = "btnAmount1000";
            this.btnAmount1000.Size = new System.Drawing.Size(80,40);
            this.btnAmount1000.TabIndex = 5;
            this.btnAmount1000.Text = "1000 ₽";
            this.btnAmount1000.UseVisualStyleBackColor = false;

            // btnAmount2000
            this.btnAmount2000.BackColor = System.Drawing.Color.LightGray;
            this.btnAmount2000.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAmount2000.Font = new System.Drawing.Font("Segoe UI",10F,System.Drawing.FontStyle.Bold);
            this.btnAmount2000.Location = new System.Drawing.Point(300,130);
            this.btnAmount2000.Name = "btnAmount2000";
            this.btnAmount2000.Size = new System.Drawing.Size(80,40);
            this.btnAmount2000.TabIndex = 6;
            this.btnAmount2000.Text = "2000 ₽";
            this.btnAmount2000.UseVisualStyleBackColor = false;

            // lblOr
            this.lblOr.AutoSize = true;
            this.lblOr.Font = new System.Drawing.Font("Segoe UI",10F);
            this.lblOr.Location = new System.Drawing.Point(185,180);
            this.lblOr.Name = "lblOr";
            this.lblOr.Size = new System.Drawing.Size(30,23);
            this.lblOr.TabIndex = 7;
            this.lblOr.Text = "или";

            // btnCustomAmount
            this.btnCustomAmount.BackColor = System.Drawing.Color.Gold;
            this.btnCustomAmount.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCustomAmount.Font = new System.Drawing.Font("Segoe UI",10F,System.Drawing.FontStyle.Bold);
            this.btnCustomAmount.Location = new System.Drawing.Point(100,210);
            this.btnCustomAmount.Name = "btnCustomAmount";
            this.btnCustomAmount.Size = new System.Drawing.Size(200,40);
            this.btnCustomAmount.TabIndex = 8;
            this.btnCustomAmount.Text = "Другая сумма";
            this.btnCustomAmount.UseVisualStyleBackColor = false;

            // lblSelectedAmount
            this.lblSelectedAmount.AutoSize = true;
            this.lblSelectedAmount.Font = new System.Drawing.Font("Segoe UI",11F,System.Drawing.FontStyle.Bold);
            this.lblSelectedAmount.ForeColor = System.Drawing.Color.DarkGreen;
            this.lblSelectedAmount.Location = new System.Drawing.Point(100,260);
            this.lblSelectedAmount.Name = "lblSelectedAmount";
            this.lblSelectedAmount.Size = new System.Drawing.Size(200,25);
            this.lblSelectedAmount.TabIndex = 9;
            this.lblSelectedAmount.Text = "Выбрано: 0 ₽";
            this.lblSelectedAmount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // btnCancel
            this.btnCancel.BackColor = System.Drawing.Color.Silver;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI",10F);
            this.btnCancel.Location = new System.Drawing.Point(50,300);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(120,40);
            this.btnCancel.TabIndex = 10;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = false;

            // btnConfirm
            this.btnConfirm.BackColor = System.Drawing.Color.LimeGreen;
            this.btnConfirm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfirm.Font = new System.Drawing.Font("Segoe UI",10F,System.Drawing.FontStyle.Bold);
            this.btnConfirm.ForeColor = System.Drawing.Color.White;
            this.btnConfirm.Location = new System.Drawing.Point(230,300);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(120,40);
            this.btnConfirm.TabIndex = 11;
            this.btnConfirm.Text = "Пополнить";
            this.btnConfirm.UseVisualStyleBackColor = false;

            // TopUpForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F,16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(420,360);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.lblSelectedAmount);
            this.Controls.Add(this.btnCustomAmount);
            this.Controls.Add(this.lblOr);
            this.Controls.Add(this.btnAmount2000);
            this.Controls.Add(this.btnAmount1000);
            this.Controls.Add(this.btnAmount500);
            this.Controls.Add(this.btnAmount100);
            this.Controls.Add(this.lblChooseAmount);
            this.Controls.Add(this.lblCurrentBalance);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TopUpForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Пополнение баланса";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
        #endregion
    }
}