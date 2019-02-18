using PersonList;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace MailTester
{
    public partial class PersonForm : Form
    {
        public List<string> emailList { get; set; } = new List<string>();

        public PersonForm()
        {
            InitializeComponent();
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            if (radioButtonAll.Checked)
            {
                PersonsList.Persons.ForEach(p => emailList.Add(p.Mail));
            }
            else if (radioButtonFirst.Checked)
            {
                emailList.Add(PersonsList.Persons.First().Mail);
            }
            else if (radioButtonCustom.Checked)
            {
                emailList.AddRange(PersonsList.Persons
                    .Where(p => p.Name.Contains(textBoxCustom.Text) || p.LastName.Contains(textBoxCustom.Text))
                    .Select(p => p.Mail));
            }
        }

        private void textBoxCustom_Enter(object sender, EventArgs e)
        {
            radioButtonCustom.Checked = true;
        }
    }
}
