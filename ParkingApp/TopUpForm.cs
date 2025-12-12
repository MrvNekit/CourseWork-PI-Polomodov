using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ParkingApp {
    public partial class TopUpForm : Form {
        public decimal Amount { get; private set; }

        // Добавляем ссылку на пользователя
        private User _currentUser;

        // Конструктор принимает пользователя
        public TopUpForm(User currentUser) {
            _currentUser = currentUser;
            InitializeComponent();
            InitializeCustomComponents();
        }

        private void InitializeCustomComponents() {
            // Обновляем информацию о балансе
            lblCurrentBalance.Text = $"Текущий баланс: {_currentUser?.Balance ?? 0} ₽";

            // Привязываем обработчики событий к кнопкам
            btnAmount100.Click += AmountButton_Click;
            btnAmount500.Click += AmountButton_Click;
            btnAmount1000.Click += AmountButton_Click;
            btnAmount2000.Click += AmountButton_Click;
            btnCustomAmount.Click += btnCustomAmount_Click;
            btnConfirm.Click += btnConfirm_Click;
            btnCancel.Click += btnCancel_Click;
        }

        private void AmountButton_Click(object sender,EventArgs e) {
            var button = sender as Button;
            if (button != null) {
                // Парсим сумму из текста кнопки
                string text = button.Text.Replace(" ₽","");
                if (decimal.TryParse(text,out decimal amount)) {
                    Amount = amount;
                    lblSelectedAmount.Text = $"Выбрано: {amount} ₽";
                }
            }
        }

        private void btnCustomAmount_Click(object sender,EventArgs e) {
            using (var inputForm = new Form()) {
                inputForm.Text = "Введите сумму";
                inputForm.Size = new Size(300,150);
                inputForm.StartPosition = FormStartPosition.CenterParent;
                inputForm.FormBorderStyle = FormBorderStyle.FixedDialog;

                var label = new Label {
                    Text = "Введите сумму для пополнения:",
                    Location = new Point(20,20),
                    Size = new Size(250,25)
                };

                var textBox = new TextBox {
                    Location = new Point(20,50),
                    Size = new Size(240,25)
                };

                var btnOk = new Button {
                    Text = "OK",
                    Location = new Point(60,85),
                    Size = new Size(80,30)
                };

                var btnCancelForm = new Button {
                    Text = "Отмена",
                    Location = new Point(150,85),
                    Size = new Size(80,30)
                };

                btnOk.Click += (s,args) => {
                    if (decimal.TryParse(textBox.Text,out decimal amount) && amount > 0) {
                        Amount = amount;
                        lblSelectedAmount.Text = $"Выбрано: {amount} ₽";
                        inputForm.Close();
                    }
                    else {
                        MessageBox.Show("Введите корректную сумму","Ошибка",
                            MessageBoxButtons.OK,MessageBoxIcon.Warning);
                    }
                };

                btnCancelForm.Click += (s,args) => inputForm.Close();

                inputForm.Controls.Add(label);
                inputForm.Controls.Add(textBox);
                inputForm.Controls.Add(btnOk);
                inputForm.Controls.Add(btnCancelForm);

                inputForm.ShowDialog();
            }
        }

        private void btnConfirm_Click(object sender,EventArgs e) {
            if (Amount > 0) {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else {
                MessageBox.Show("Выберите сумму для пополнения","Ошибка",
                    MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
        }

        private void btnCancel_Click(object sender,EventArgs e) {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
