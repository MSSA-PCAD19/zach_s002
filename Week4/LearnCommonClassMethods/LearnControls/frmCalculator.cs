using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace LearnControls
{
    public partial class frmCalculator : Form
    {
        double op1;
        double op2;
        List<string> history = new List<string>();
        public frmCalculator()
        {
            InitializeComponent();
            this.AcceptButton = btnEqual;
            //this.UpdateDefaultButton();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (isValidInput(out op1))
            {
                lblResult.Text = op1.ToString() + "+";
                txtInput.Text = "";
            }

            else
                MessageBox.Show("Invalid Input", "Bad data!!",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation
                    );

            txtInput.Focus();
        }

        private bool isValidInput(out double op)
        {
            return double.TryParse(txtInput.Text, out op);
        }

        private void btnEqual_Click(object sender, EventArgs e)
        {
            if (isValidInput(out op2))
            {
                lblResult.Text += $"{op2.ToString()} = {op1 + op2}";
                history.Add(lblResult.Text);
                listView1.Clear();
                foreach (var item in history)
                {
                    listView1.Items.Add(new ListViewItem(item));
                }

            }
            else
                MessageBox.Show("Invalid Input", "Bad data!!",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation
                    );

            txtInput.Focus();
        }

        private void frmCalculator_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Add)
            {
                this.btnAdd_Click(sender, e);
            }
        }
    }
}
