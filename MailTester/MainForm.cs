using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MailSender;

namespace MailTester
{
    public partial class MainForm : Form
    {
        private void showSelectFromList()
        {
            using (var personForm = new PersonForm())
            {
                if (personForm.ShowDialog() == DialogResult.OK)
                {
                    tbTo.Text = string.Join(";", personForm.emailList);
                }

            }
        }

        public MainForm()
        {
            InitializeComponent();
            showSelectFromList();
        }

        private void SendButton_Click(object sender, EventArgs e)
        {
            try
            {
                MailModel model = new MailModel(tbTo.Text, tbFrom.Text, tbTitle.Text, rtbBody.Text);

                if (!MailService.Send(model))
                    MessageBox.Show("Mail sent successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (IncorrectRecipientException exception)
            {
                MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (IncorrectSenderException exception)
            {
                MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (MailServiceException exception)
            {
                MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void label1_MouseHover(object sender, EventArgs e)
        {
            label2.Visible = true;
        }

        private void label1_MouseLeave(object sender, EventArgs e)
        {
            label2.Visible = false;
        }

        private void buttonList_Click(object sender, EventArgs e)
        {
            showSelectFromList();
        }
    }
}
