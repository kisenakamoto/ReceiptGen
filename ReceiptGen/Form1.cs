using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Printing;

namespace ReceiptGen
{
    
    public partial class Form1 : Form
    {
        PrintDocument document = new PrintDocument();
        PrintDialog dialog = new PrintDialog();

        public Form1()
        {
            InitializeComponent();
            document.PrintPage += new PrintPageEventHandler(document_PrintPage);

            groupBox1.Parent = pictureBox1;
            groupBox1.BackColor = Color.Transparent;
            label25.Parent = pictureBox1;
            label25.BackColor = Color.Transparent;

            groupBox2.Parent = pictureBox1;
            groupBox2.BackColor = Color.Transparent;

            button3.Enabled = false;
            button4.Enabled = false;
            textBox1.ReadOnly = true;
            textBox2.ReadOnly = true;
            textBox3.ReadOnly = true;
            richTextBox1.ReadOnly = true;
        }

        //Reset
        private void button1_Click(object sender, EventArgs e)
        {
            numericUpDown1.Value = 0;
            numericUpDown2.Value = 0;
            numericUpDown3.Value = 0;
            numericUpDown4.Value = 0;
            numericUpDown5.Value = 0;
            numericUpDown6.Value = 0;
            numericUpDown7.Value = 0;
            numericUpDown8.Value = 0;
            numericUpDown9.Value = 0;

            richTextBox1.Text = "";
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            button3.Enabled = false;
            button4.Enabled = false;
            textBox1.ReadOnly = true;
            textBox2.ReadOnly = true;
            textBox3.ReadOnly = true;
            richTextBox1.ReadOnly = true;
        }

        //Order
        private void button2_Click(object sender, EventArgs e)
        {
            Order order = new Order();
            order.SetUpDown1(numericUpDown1.Value);
            order.SetUpDown2(numericUpDown2.Value);
            order.SetUpDown3(numericUpDown3.Value);
            order.SetUpDown4(numericUpDown4.Value);
            order.SetUpDown5(numericUpDown5.Value);
            order.SetUpDown6(numericUpDown6.Value);
            order.SetUpDown7(numericUpDown7.Value);
            order.SetUpDown8(numericUpDown8.Value);
            order.SetUpDown9(numericUpDown9.Value);


            if (order.GetOrder1() == 0 && order.GetOrder2() == 0 && order.GetOrder3() == 0 && 
                order.GetOrder4() == 0 && order.GetOrder5() == 0 && order.GetOrder6() == 0 &&
                order.GetOrder7() == 0 && order.GetOrder8() == 0 && order.GetOrder9() == 0)
            {
                MessageBox.Show("No order input. ", "Error");
            }
            else
            {
                button2.Enabled = false;
                button3.Enabled = true;
                button4.Enabled = false;
                button1.Enabled = false;
                textBox2.ReadOnly = false;

                numericUpDown1.Enabled = false;
                numericUpDown2.Enabled = false;
                numericUpDown3.Enabled = false;
                numericUpDown4.Enabled = false;
                numericUpDown5.Enabled = false;
                numericUpDown6.Enabled = false;
                numericUpDown7.Enabled = false;
                numericUpDown8.Enabled = false;
                numericUpDown9.Enabled = false;

                string or1 = "";
                if (numericUpDown1.Value > 0)
                    {
                    decimal qty1 = numericUpDown1.Value;
                    decimal cost1 = order.GetOrder1();
                    or1 = "  Classic Burger...." + qty1 + "......₱" + cost1 + "\n";
                    }
                if (numericUpDown2.Value > 0)
                    {
                        decimal qty2 = numericUpDown2.Value;
                        decimal cost2 = order.GetOrder2();
                        or1 = or1 + "  Cheese Burger....." + qty2 + "......₱" + cost2 + "\n";

                    }
                if (numericUpDown3.Value > 0)
                    {
                        decimal qty3 = numericUpDown3.Value;
                        decimal cost3 = order.GetOrder3();
                        or1 = or1 + "  Double Cheese....." + qty3 + "......₱" + cost3 + "\n";
                    }

                if (numericUpDown4.Value > 0)
                    {
                        decimal qty4 = numericUpDown4.Value;
                        decimal cost4 = order.GetOrder4();
                        or1 = or1 + "  Chicken Burger...." + qty4 + "......₱" + cost4 + "\n";
                    }

                if (numericUpDown5.Value > 0)
                    {
                        decimal qty5 = numericUpDown5.Value;
                        decimal cost5 = order.GetOrder5();
                        or1 = or1 + "  Pizza Burger......" + qty5 + "......₱" + cost5 + "\n";
                    }

                if (numericUpDown6.Value > 0)
                    {
                        decimal qty6 = numericUpDown6.Value;
                        decimal cost6 = order.GetOrder6();
                        or1 = or1 + "  Water............." + qty6 + "......₱" + cost6 + "\n";
                    }

                if (numericUpDown7.Value > 0)
                    {
                        decimal qty7 = numericUpDown7.Value;
                        decimal cost7 = order.GetOrder7();
                        or1 = or1 + "  Softdrinks........" + qty7 + "......₱" + cost7 + "\n";
                    }

                if (numericUpDown8.Value > 0)
                    {
                        decimal qty8 = numericUpDown8.Value;
                        decimal cost8 = order.GetOrder8();
                        or1 = or1 + "  Iced Tea.........." + qty8 + "......₱" + cost8 + "\n";
                    }

                if (numericUpDown9.Value > 0)
                    {
                    decimal qty9 = numericUpDown9.Value;
                    decimal cost9 = order.GetOrder9();
                    or1 = or1 + "  Gulaman..........." + qty9 + "......₱" + cost9 + "\n";
                    }
                

                decimal total = order.GetTotal();
                textBox1.Text = "₱" + total.ToString();
                DialogResult dialogResult = MessageBox.Show("\t\t Preparing your order. " +
                    "\nPlease input your cash amount in the Total Payment text box.", "Reminder", MessageBoxButtons.OKCancel);
                if (dialogResult == DialogResult.OK)
                {
                    i++;
                    richTextBox1.Text = "\n\n           Burger House \n          Silang, Cavite     \n\n      "
                                            + DateTime.Now + "\n       Receipt# " + DateTime.Now.ToString("yyyMMdd")
                                            + "00" + i + "\n  ------------------------------\n"
                                            + "\n   Order           Qty.  SubTotal \n"
                                            + or1 + "\n  ------------------------------\n\n";
                    textBox2.Text = "0";
                    dialog.Document = document;
                    document.Print();
                    
                }
                else if(dialogResult == DialogResult.Cancel)
                {
                    MessageBox.Show("Order Cancelled.");
                    button4_Click(this, new EventArgs());
                    this.ActiveControl = numericUpDown1;
                }
            }
        }
        private static int i;

        //Calculate Change
        private void button3_Click(object sender, EventArgs e)
        {
            button2.Enabled = false;
            button4.Enabled = true;
            button1.Enabled = false;


            Order order = new Order();
            order.SetUpDown1(numericUpDown1.Value);
            order.SetUpDown2(numericUpDown2.Value);
            order.SetUpDown3(numericUpDown3.Value);
            order.SetUpDown4(numericUpDown4.Value);
            order.SetUpDown5(numericUpDown5.Value);
            order.SetUpDown6(numericUpDown6.Value);
            order.SetUpDown7(numericUpDown7.Value);
            order.SetUpDown8(numericUpDown8.Value);
            order.SetUpDown9(numericUpDown9.Value);

            decimal total = order.GetTotal();
            decimal vat = 0.12M;
            decimal vatable = total * vat;
            decimal cash;
            cash = decimal.Parse(textBox2.Text);

            if (cash < total || string.IsNullOrWhiteSpace(textBox2.Text))
            {
                button3.Enabled = true;
                button4.Enabled = false;
                textBox2.ReadOnly = false;
                MessageBox.Show("Insufficient cash. Please enter amount greater than the total order cost.", "Error");
            }
            else
            {
                button4.Enabled = true;
                button3.Enabled = false;
                textBox2.ReadOnly = true;
                textBox2.Text = "₱" + cash;

                decimal change = cash - total;
                textBox3.Text = "₱" + change.ToString();

                string or1 = "";
                    if (numericUpDown1.Value > 0)
                    {
                    decimal qty1 = numericUpDown1.Value;
                    decimal cost1 = order.GetOrder1();
                    or1 = "  Classic Burger...." + qty1 + "......₱" + cost1 + "\n";
                    }

                    if (numericUpDown2.Value > 0)
                    {
                        decimal qty2 = numericUpDown2.Value;
                        decimal cost2 = order.GetOrder2();
                        or1 = or1 + "  Cheese Burger....." + qty2 + "......₱" + cost2 + "\n";
                    }

                    if (numericUpDown3.Value > 0)
                    {
                        decimal qty3 = numericUpDown3.Value;
                        decimal cost3 = order.GetOrder3();
                        or1 = or1 + "  Double Cheese....." + qty3 + "......₱" + cost3 + "\n";
                    }

                    if (numericUpDown4.Value > 0)
                    {
                        decimal qty4 = numericUpDown4.Value;
                        decimal cost4 = order.GetOrder4();
                        or1 = or1 + "  Chicken Burger...." + qty4 + "......₱" + cost4 + "\n";
                    }

                    if (numericUpDown5.Value > 0)
                    {
                        decimal qty5 = numericUpDown5.Value;
                        decimal cost5 = order.GetOrder5();
                        or1 = or1 + "  Pizza Burger......" + qty5 + "......₱" + cost5 + "\n";
                    }

                    if (numericUpDown6.Value > 0)
                    {
                        decimal qty6 = numericUpDown6.Value;
                        decimal cost6 = order.GetOrder6();
                        or1 = or1 + "  Water............." + qty6 + "......₱" + cost6 + "\n";
                    }

                    if (numericUpDown7.Value > 0)
                    {
                        decimal qty7 = numericUpDown7.Value;
                        decimal cost7 = order.GetOrder7();
                        or1 = or1 + "  Softdrinks........" + qty7 + "......₱" + cost7 + "\n";
                    }

                    if (numericUpDown8.Value > 0)
                    {
                        decimal qty8 = numericUpDown8.Value;
                        decimal cost8 = order.GetOrder8();
                        or1 = or1 + "  Iced Tea.........." + qty8 + "......₱" + cost8 + "\n";
                    }

                    if (numericUpDown9.Value > 0)
                    {
                        decimal qty9 = numericUpDown9.Value;
                        decimal cost9 = order.GetOrder9();
                        or1 = or1 + "  Gulaman..........." + qty9 + "......₱" + cost9 + "\n";
                    }
                richTextBox1.Text = "\n\n           Burger House \n          Silang, Cavite     \n\n      "
                                  + DateTime.Now + "\n       Receipt# " + DateTime.Now.ToString("yyyMMdd")
                                  + "00" + i + "\n  ------------------------------\n"
                                  + "\n   Order           Qty.  SubTotal \n"
                                  + or1 + "\n  ------------------------------\n\n" + "   Total VAT...............₱"
                                  + vatable + "\n   Total Amount............₱"
                                  + total + "\n   Cash Paid...............₱" + cash
                                  + "\n   Change..................₱" + change
                                  + "\n\n\n    This serves as an official \n  receipt. Thank you, come again!";

                DialogResult dialogResult = MessageBox.Show("Do you want to print the receipt?",
                                                            "Print Dialog", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    dialog.Document = document;
                    if (dialog.ShowDialog() == DialogResult.OK)
                    {
                        document.Print();
                    }
                }
            }
        }

        //Print
        void document_PrintPage(object sender, PrintPageEventArgs e)
        {
            e.Graphics.DrawString(richTextBox1.Text, new Font("Consolas", 8, 
                                  FontStyle.Regular), Brushes.Black, 20, 20);
        }

        //Exit
        private void button5_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Closing this application. Click OK to proceed and CANCEL to go back. ",
                                                            "Confirmation", MessageBoxButtons.OKCancel);
            if (dialogResult == DialogResult.OK)
            {
                Application.Exit();
            }
        }

        //Next Order
        private void button4_Click(object sender, EventArgs e)
        {
            button1.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = false;
            button4.Enabled = false;
            textBox1.ReadOnly = true;
            textBox2.ReadOnly = true;
            textBox3.ReadOnly = true;
            richTextBox1.ReadOnly = true;

            numericUpDown1.Value = 0;
            numericUpDown2.Value = 0;
            numericUpDown3.Value = 0;
            numericUpDown4.Value = 0;
            numericUpDown5.Value = 0;
            numericUpDown6.Value = 0;
            numericUpDown7.Value = 0;
            numericUpDown8.Value = 0;
            numericUpDown9.Value = 0;

            numericUpDown1.Enabled = true;
            numericUpDown2.Enabled = true;
            numericUpDown3.Enabled = true;
            numericUpDown4.Enabled = true;
            numericUpDown5.Enabled = true;
            numericUpDown6.Enabled = true;
            numericUpDown7.Enabled = true;
            numericUpDown8.Enabled = true;
            numericUpDown9.Enabled = true;

            richTextBox1.Text = "";
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
        }

        //Enter Change
        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
                if (e.KeyCode == Keys.Enter)
                {
                    button3_Click(this, new EventArgs());
                }
        }
        //Textbox2 Number only
        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);   
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            textBox2.MaxLength = 6;
        }
    }
}
