using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
    
namespace BaseConverter
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            textBox1.TextChanged += TextBox_TextChanged;
            textBox1.MouseClick += TextBox_MouseClick;

            textBox2.TextChanged += TextBox_TextChanged;
            textBox2.MouseClick += TextBox_MouseClick;

            textBox3.TextChanged += TextBox_TextChanged;
            textBox3.MouseClick += TextBox_MouseClick;

            textBox4.TextChanged += TextBox_TextChanged;
            textBox4.MouseClick += TextBox_MouseClick;

            button1.MouseEnter += BTN_MouseEnter;
            button1.MouseLeave += BTN_MouseLeave;
            button1.MouseClick += BTN_MouseClick;
            
            button2.MouseEnter += BTN_MouseEnter;
            button2.MouseLeave += BTN_MouseLeave;
            button2.MouseClick += BTN_MouseClick;

            button3.MouseEnter += BTN_MouseEnter;
            button3.MouseLeave += BTN_MouseLeave;
            button3.MouseClick += BTN_MouseClick;

            button4.MouseEnter += BTN_MouseEnter;
            button4.MouseLeave += BTN_MouseLeave;
            button4.MouseClick += BTN_MouseClick;
        }
        
        private void TextBox_MouseClick(object sender, EventArgs e)
        {
            TextBox TBox = sender as TextBox;
            TBox.SelectAll();
        }
        
        string TempButtonText = "";
        private void BTN_MouseEnter(object sender, EventArgs e)
        {
            Button BTN = sender as Button;
            BTN.BackgroundImage = Properties.Resources.Copy_Icon;
            TempButtonText = BTN.Text;
            BTN.Text = "";
        }

        private void BTN_MouseLeave(object sender, EventArgs e)
        {
            Button BTN = sender as Button;
            BTN.BackgroundImage = null;
            BTN.Text = TempButtonText;
        }

        private void BTN_MouseClick(object sender, EventArgs e)
        {
            Button BTN = sender as Button;
            switch (BTN.Name)
            {
                case "button1":
                    if (textBox1.Text.Length > 0)
                    {
                        Clipboard.SetText(textBox1.Text);
                    }
                    break;
                case "button2":
                    if (textBox2.Text.Length > 0)
                    {
                        Clipboard.SetText(textBox2.Text);
                    }
                    break;
                case "button3":
                    if (textBox3.Text.Length > 0)
                    {
                        Clipboard.SetText(textBox3.Text);
                    }
                    break;
                case "button4":
                    if (textBox4.Text.Length > 0)
                    { 
                        Clipboard.SetText(textBox4.Text);
                    }
                    break;
                default:
                    break;
            }
        }
        
        private void FromBinary (string BIN)
        {
            if(BIN.Length > 0)
            {
                textBox2.Text = Convert.ToInt64(BIN, 2).ToString();
                textBox3.Text = Convert.ToString(Convert.ToInt64(BIN, 2), 8);
                textBox4.Text = Convert.ToInt64(BIN, 2).ToString("X");
                return;
            }
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
        }

        private void FromDecimal(string DEC)
        {
            if (DEC.Length > 0)
            {
                /*Int64 x64 = 0;
                Int64.TryParse(DEC, out x64);
                if (Convert.ToInt64(DEC, 10) >= Int64.MaxValue)
                if(x64 > Int64.MaxValue)
                {
                    MessageBox.Show("Out of Bounds!", "int-64");
                    return;
                }*/
                textBox1.Text = Convert.ToString(Convert.ToInt64(DEC, 10), 2);
                textBox3.Text = Convert.ToString(Convert.ToInt64(DEC, 10), 8);
                textBox4.Text = Convert.ToString(Convert.ToInt64(DEC, 10), 16);
                return;
            }
            textBox1.Clear();
            textBox3.Clear();
            textBox4.Clear();
        }

        private void FromOctal(string OCT)
        {
            if (OCT.Length > 0)
            {
                textBox1.Text = Convert.ToString(Convert.ToInt64(OCT, 8), 2);
                textBox2.Text = Convert.ToString(Convert.ToInt64(OCT, 8), 10);
                textBox4.Text = Convert.ToString(Convert.ToInt64(OCT, 8), 16);
                return;
            }
            textBox1.Clear();
            textBox2.Clear();
            textBox4.Clear();
        }
        
        private void FromHexadecimal(string HEX)
        {
            if (HEX.Length > 0)
            {
                textBox1.Text = Convert.ToString(Convert.ToInt64(HEX, 16), 2);
                textBox2.Text = Convert.ToString(Convert.ToInt64(HEX, 16), 10);
                textBox3.Text = Convert.ToString(Convert.ToInt64(HEX, 16), 8);
                return;
            }
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
        }
        
        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            TextBox TBox = sender as TextBox;
            TBox.CharacterCasing = CharacterCasing.Upper;
            char[] OriginalText = TBox.Text.ToCharArray();

            // Test for Binary input
            if (TBox.Name == "textBox1")
            {
                foreach (char c in OriginalText)
                {
                    if (TBox.Text.Length != 0)
                    {
                        if (c != '0' && c != '1')
                        {
                            TBox.Text = TBox.Text.Substring(0, (TBox.TextLength - 1));
                            MessageBox.Show("Not a Binary.","Gotcha!");
                        }
                    }

                    
                }
                TBox.Select(TBox.Text.Length, 0);
                FromBinary(TBox.Text);
            }

            // Test for Decimal input
            if (TBox.Name == "textBox2")
            {
                foreach (char c in OriginalText)
                {
                    if (TBox.Text.Length != 0)
                    {
                        
                        if (!(Char.IsNumber(c)))
                        {
                            TBox.Text = TBox.Text.Substring(0, (TBox.TextLength - 1));
                            MessageBox.Show("Not a Number.", "Gotcha!");
                        }
                    }
                }
                TBox.Select(TBox.Text.Length, 0);
                FromDecimal(TBox.Text);
            }

            // Test for Octal input
            if (TBox.Name == "textBox3")
            {
                char[] OctAllowed = { '0', '1', '2', '3', '4', '5', '6', '7' };
                foreach (char c in OriginalText)
                {
                    if (TBox.Text.Length != 0)
                    {
                        if (!OctAllowed.Contains(c))
                        {
                            TBox.Text = TBox.Text.Substring(0, (TBox.TextLength - 1));
                            MessageBox.Show("Not an Octal.", "Gotcha!");
                        }
                    }
                }
                TBox.Select(TBox.Text.Length, 0);
                FromOctal(TBox.Text);
            }

            // Test for Hexadecimal input
            if (TBox.Name == "textBox4")
            {
                char[] HexAllowed = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'A', 'B', 'C', 'D', 'E', 'F'};
                foreach (char c in OriginalText)
                {
                    if (TBox.Text.Length != 0)
                    {
                        if (!HexAllowed.Contains(c))
                        {
                            TBox.Text = TBox.Text.Substring(0, (TBox.TextLength - 1));
                            MessageBox.Show("What the Hex!", "Gotcha!");
                        }
                    }   
                }
                TBox.Select(TBox.Text.Length, 0);
                FromHexadecimal(TBox.Text);
            }

        }
        
    }
}
