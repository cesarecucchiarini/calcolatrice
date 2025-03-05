namespace calcolatrice
{
    public partial class Form1 : Form
    {
        int operatore = 0;
        bool punto = true, meno = true;
        public Form1()
        {
            InitializeComponent();
        }
        private void btn_1_Click(object sender, EventArgs e)
        {
            Button bottone = sender as Button;
            if (operatore == 0)
                lbl_op1.Text += bottone.Text;
            else
                lbl_op2.Text += bottone.Text;
        }
        private void btn_piu_Click(object sender, EventArgs e)
        {
            lbl_operazione.Text = btn_piu.Text;
            operatore = 1;
            meno = punto = true;
        }

        private void btn_meno_Click(object sender, EventArgs e)
        {
            lbl_operazione.Text = btn_meno.Text;
            operatore = 1;
            meno = punto = true;
        }

        private void btn_per_Click(object sender, EventArgs e)
        {
            lbl_operazione.Text = btn_per.Text;
            operatore = 1;
            meno = punto = true;
        }

        private void btn_div_Click(object sender, EventArgs e)
        {
            lbl_operazione.Text = btn_div.Text;
            operatore = 1;
            meno = punto = true;
        }

        private void btn_ris_Click(object sender, EventArgs e)
        {
            if (lbl_operazione.Text != "" && lbl_op2.Text != "" && lbl_op1.Text != "")
            {
                double op1 = double.Parse(lbl_op1.Text);
                double op2 = double.Parse(lbl_op2.Text);
                double ris;
                operatore = 0;
                punto = meno = true;
                if (lbl_operazione.Text == "+")
                    ris = op1 + op2;
                else if (lbl_operazione.Text == "-")
                    ris = op1 - op2;
                else if (lbl_operazione.Text == "x")
                    ris = op1 * op2;
                else
                    ris = op1 / op2;
                lbl_risultato.Text = ris.ToString();
            }
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            lbl_operazione.Text = lbl_op2.Text = lbl_op1.Text = lbl_risultato.Text = "";
            operatore = 0;
            punto = meno = true;
        }

        private void btn_dec_Click(object sender, EventArgs e)
        {
            if (operatore == 0)
            {
                if (punto && lbl_op1.Text.Length > 0)
                {
                    lbl_op1.Text += ",";
                    punto = false;
                }
            }
            else
            {
                if (punto && lbl_op2.Text.Length > 0)
                {
                    lbl_op2.Text += ",";
                    punto = false;
                }
            }
        }

        private void btn_neg_Click(object sender, EventArgs e)
        {
            if (operatore == 0)
            {
                if (meno && lbl_op1.Text.Length == 0)
                {
                    lbl_op1.Text += "-";
                    meno = false;
                }
            }
            else
            {
                if (meno && lbl_op2.Text.Length == 0)
                {
                    lbl_op2.Text += "-";
                    meno = false;
                }
            }
        }
    }
}
