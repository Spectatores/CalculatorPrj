using CalculatorPrj.Operator;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalculatorPrj
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
        }

        private double num1 = 0;
        private double num2 = 0;
        private double endNum = 0;
        private bool isNum1 = true;
        private bool hasNum2 = false;
        private MyOperator opt;
        private string optText;        

        private List<string> numberList = new List<string>()
        {
            "0","1","2","3","4","5","6","7","8","9",".","+/-"
        };

        private List<string> operatorList = new List<string>()
        {
            "+","-","x","/","%","="
        };

        private List<string> specialOptList = new List<string>()
        {
            "1/X","X*X","开方"
        };

        private List<string> delList = new List<string>()
        {
            "CE","C","<-"
        };

        private void OnNumberBtnClick(object sender, EventArgs e)
        {
            var numText = (sender as Button).Text;
            if(numText == "+/-")
            {
                var num = (Convert.ToDouble(label1.Text) * -1).ToString();
                label1.Text = num.ToString();
            }
            else label1.Text += numText;
            if (isNum1)
            {
                num1 = Convert.ToDouble(label1.Text);
            }
            else
            {
                hasNum2 = true;
                num2 = Convert.ToDouble(label1.Text);
            }
        }
        private void OnOperatorBtnClick(object sender, EventArgs e)
        {
            optText = (sender as Button).Text;
            if ((optText == "=" && opt != null))
            {
                if (!hasNum2) num2 = num1;
                endNum = opt.GetResult(num1, num2);
                label1.Text = endNum.ToString();
                label2.Text += num2.ToString() + optText;
                num1 = endNum; num2 = 0;
                return;
            }
            
            isNum1 = false;
            label1.Text = "";
            label2.Text = num1.ToString() + optText;
            opt = OperatorFactory.GetOperator(optText);

            
        }

        

        private void OnSpecialOptBtnClick(object sender, EventArgs e)
        {

        }

        private void OnDeleteBtnClick(object sender, EventArgs e)
        {
            var delText = (sender as Button).Text;
            if(delText == "<-")
            {
                if (isNum1)
                {
                    num1 = Convert.ToDouble(label1.Text.Substring(0, label1.Text.Length - 1));
                    label1.Text = num1.ToString();
                }
                else
                {
                    num2 = Convert.ToDouble(label1.Text.Substring(0, label1.Text.Length - 1));
                    label1.Text = num2.ToString();
                }
            }
            else
            {
                ResetVariabel();
                label1.Text = "";
                label2.Text = "";
            }
        }

        private void ResetVariabel()
        {
            num1 = 0;
            num2 = 0;
            endNum = 0;
            isNum1 = true;
            hasNum2 = false;
            opt = null;
            optText = "";
        }
        private void OnBtnClick(object sender, EventArgs e)
        {
            if (numberList.Contains((sender as Button).Text))
                OnNumberBtnClick(sender, e);
            else if (operatorList.Contains((sender as Button).Text))
                OnOperatorBtnClick(sender, e);
            else if (specialOptList.Contains((sender as Button).Text))
                OnSpecialOptBtnClick(sender, e);
            else if (delList.Contains((sender as Button).Text))
                OnDeleteBtnClick(sender, e);
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
