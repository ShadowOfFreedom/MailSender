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
        public MainForm()
        {
            InitializeComponent();
        }

        private void SendButton_Click(object sender, EventArgs e)
        {
            try
            {
                MailModel model = new MailModel(tbTo.Text, tbFrom.Text, tbTitle.Text, rtbBody.Text);

                MailService.Send(model);
            }
            catch (IncorrectRecipientException exception)
            {
                MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tbTo.Clear();
            }
            catch (IncorrectSenderException exception)
            {
                MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tbFrom.Clear();
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
    }
}
