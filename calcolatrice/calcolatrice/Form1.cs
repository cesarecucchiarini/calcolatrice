namespace calcolatrice
{
    public partial class Form1 : Form
    {
        int operatore = 0;
        bool punto = true, meno = true;
        double ris = 0;
        public Form1()
        {
            InitializeComponent();
        }

        //NUMERI
        private void btn_1_Click(object sender, EventArgs e)
        {
            Button bottone = sender as Button;
            if (operatore == 0)
                lbl_op1.Text += bottone.Text;
            else
                lbl_op2.Text += bottone.Text;
        }

        //OPERAZIONI
        private void btn_op_Click(object sender, EventArgs e)
        {
            Button bottone = sender as Button;
            lbl_operazione.Text = bottone.Text;
            operatore = 1;
            meno = punto = true;
        }

        //UGUALE
        private void btn_ris_Click(object sender, EventArgs e)
        {
            if (lbl_operazione.Text != "" && lbl_op2.Text != "" && lbl_op1.Text != "")
            {
                double op1 = double.Parse(lbl_op1.Text);
                double op2 = double.Parse(lbl_op2.Text);
                operatore = 0;
                punto = meno = true;
                if (lbl_operazione.Text == "+")
                    ris = op1 + op2;
                else if (lbl_operazione.Text == "-")
                    ris = op1 - op2;
                else if (lbl_operazione.Text == "x")
                    ris = op1 * op2;
                else if (lbl_operazione.Text == "÷")
                    ris = op1 / op2;
                else if (lbl_operazione.Text == "^")
                    ris = Math.Pow(op1, op2);
                else if (lbl_operazione.Text == "√")
                    ris = Math.Pow(op2, 1 / op1);
                lbl_risultato.Text = ris.ToString();
            }
        }

        //PULISCI
        private void btn_cancel_Click(object sender, EventArgs e)
        {
            lbl_operazione.Text = lbl_op2.Text = lbl_op1.Text = lbl_risultato.Text = "";
            operatore = 0;
            punto = meno = true;
        }

        //VIRGOLA
        private void btn_dec_Click(object sender, EventArgs e)
        {
            if (operatore == 0)
            {
                if (punto && lbl_op1.Text.Length >= 2 || punto && lbl_op1.Text.Length >= 1 && meno)
                {
                    lbl_op1.Text += ",";
                    punto = false;
                }
            }
            else
            {
                if (punto && lbl_op2.Text.Length >= 2 || punto && lbl_op2.Text.Length >= 1 && meno)
                {
                    lbl_op2.Text += ",";
                    punto = false;
                }
            }
        }

        //NEGATIVO
        private void btn_neg_Click(object sender, EventArgs e)
        {
            if (operatore == 0)
            {
                if (lbl_op1.Text.Length == 0)
                {
                    lbl_op1.Text += "-";
                    meno = false;
                }
            }
            else
            {
                if (lbl_op2.Text.Length == 0)
                {
                    lbl_op2.Text += "-";
                    meno = false;
                }
            }
        }

        //INDIETRO
        private void btn_undo_Click(object sender, EventArgs e)
        {
            if (operatore == 0)
            {
                if (lbl_op1.Text.Length > 0)
                {
                    if (lbl_op1.Text[lbl_op1.Text.Length - 1] == '-')
                        meno = true;
                    else if (lbl_op1.Text[lbl_op1.Text.Length - 1] == ',')
                        punto = true;
                    lbl_op1.Text = lbl_op1.Text.Substring(0, lbl_op1.Text.Length - 1);
                }
            }
            else
            {
                if (lbl_op2.Text.Length > 0)
                {
                    if (lbl_op2.Text[lbl_op2.Text.Length - 1] == '-')
                        meno = true;
                    else if (lbl_op2.Text[lbl_op2.Text.Length - 1] == ',')
                        punto = true;
                    lbl_op2.Text = lbl_op2.Text.Substring(0, lbl_op2.Text.Length - 1);
                }
                else
                {
                    operatore = 0;
                    if (lbl_op1.Text.Length > 0)
                        lbl_op1.Text = lbl_op1.Text.Substring(0, lbl_op1.Text.Length - 1);
                }
            }
        }

        //ANSWER
        private void btn_ans_Click(object sender, EventArgs e)
        {
            if (operatore == 0)
            {
                lbl_op1.Text = ris.ToString();
                operatore = 1;
            }
            else
            {
                lbl_op2.Text = ris.ToString();
                btn_ris_Click(sender, e);
            }
        }

        private void btn_info_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Puoi digitare i numeri grazie ai tasti, puoi creare numeri decimali grazie al\n" +
                "bottone a sinistra dello 0 e negativi grazie al bottone a destra dello 0.\n" +
                "I pulsanti a sinistra dei numeri permettono di: cancellare l'ultimo carattere scritto, \n" +
                "cancellare tutti i numeri e segni di operazione e il pulsante per inserire l'ultimo risultato.\n" +
                "I pulsanti a destra dei numeri permettono di fare: una somma, una sottrazione\n" +
                "una moltiplicazione e una divisione.\n" +
                "Infine i due bottoni a sinistra permettono di fare una potenza (l'esponente sarà il secondo operatore)\n" +
                "e una radice (l'indice della radice sarà il primo operatore).\n" +
                "Per vedere il risutato delle operazioni clicca sul pulsante sotto lo 0.\n" +
                "RICORDA! puoi solo eseguire un'operazione alla volta.", "INFO");
        }
    }
}
