using System;
using System.Windows.Forms;

namespace AnfiniL.SqlExpressProfiler.Controls
{
    public partial class NewIssueForm : Form
    {
        public NewIssueForm()
        {
            InitializeComponent();
        }
        
        public string IssueText
        {
            get
            {
                return exceptionTextBox.Text;
            }
            set
            {
                exceptionTextBox.Text = value;
            }
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void linkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Utils.OpenBrowser(linkLabel.Text);
        }
    }
}