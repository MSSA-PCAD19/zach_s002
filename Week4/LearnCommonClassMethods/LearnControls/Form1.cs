namespace LearnControls
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) // note, method does not have a static keyword, so the method is part of which class? Form1
        {
            // this method is an instance member of the Form1 class
            // there is no static keyword in method definition
            this.button1.Text = this.Text;
            //Form1 f2 = new Form1();
            //f2.Show(); // this results in a new form every time you click

            this.button1.BackColor = Color.Coral;
            this.button1.ForeColor = Color.Black;
            this.button1.Top = 100;
            this.button1.Left = 100;

            if (chkRememberMe.Checked)
            {
                lblMessage.Text = "We will remember you.";
            }
            else
            {
                lblMessage.Text = "We will not remember you.";
            }
        }
    }
}
