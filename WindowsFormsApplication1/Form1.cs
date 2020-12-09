using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        private double[] _coefArray;//a0,a1,a2,a3,a4,a5,a6
        public double[] _CoefArray
        {
            get { return _coefArray; }
        }

        System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        
        public Form1()
        {
            InitializeComponent();
            HideAll();
            chart1 = new Chart();
        }

        public double ParceInstrument(string buf)
        {
            double number;
            if (Double.TryParse(buf, out number))
            {
                return number;
            }
            else return Int32.MinValue;
        }
        private void showGraph(int N)
        {

            chart1.Series.Clear();
            var series1 = new System.Windows.Forms.DataVisualization.Charting.Series
            {
                IsVisibleInLegend = false,
                IsXValueIndexed = true,
                ChartType = SeriesChartType.Line
            };
            this.chart1.Series.Add(series1);


            if (N == 2)
                for (int i = -10; i < 10; i++)
                {
                    series1.Points.AddXY(i, F2(i));
                }
            else if (N == 3)
            {
                for (int i = -10; i < 10; i++)
                {
                    series1.Points.AddXY(i, F3(i));
                }
            }
            else if (N == 1)
            {
                for (int i = -10; i < 10; i++)
                {
                    series1.Points.AddXY(i, F1(i));
                }
            }
            else if (N == 5)
            {
                for (int i = -10; i < 10; i++)
                {
                    series1.Points.AddXY(i, F5(i));
                }
            }
            else if (N == 4)
            {
                for (int i = -10; i < 10; i++)
                {
                    series1.Points.AddXY(i, F4(i));
                }
            }
            //chart1.Invalidate();
            if (this.chart1.ChartAreas.Count == 0)
            {
                System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
                System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
                ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
                this.SuspendLayout();
                //chartArea1.Name = "ChartArea1 " + N.ToString();
                this.chart1.ChartAreas.Add(chartArea1);
                //this.chart1.Dock = System.Windows.Forms.DockStyle.Fill;
                legend1.Name = "Legend1";

                this.chart1.Legends.Add(legend1);
                this.chart1.Location = new System.Drawing.Point(0, 120);
                this.chart1.Name = "chart1";
                this.chart1.TabIndex = 0;
                this.chart1.Text = "chart1";
                //
                // Form1
                //
                this.Controls.Add(this.chart1);
                this.Load += new System.EventHandler(this.Form1_Load);
                ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
                this.ResumeLayout(false);
            }

        }

        public void ShowAll() {
            evaluateButton.Show();
            a.Visible = true;
            x0.Visible = true;
            b.Visible = true;
            x1.Visible = true;
            c.Visible = true;
            x2.Visible = true;
            d.Visible = true;
            x3.Visible = true;
            ee.Visible = true;
            x4.Visible = true;
        }

        public void HideAll()
        {
            clearSolution.Visible = false;
            a.Visible = false;
            x0.Visible = false;
            b.Visible = false;
            x1.Visible = false;
            c.Visible = false;
            x2.Visible = false;
            d.Visible = false;
            x3.Visible = false;
            ee.Visible = false;
            x4.Visible = false;
        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void CbState_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowAll();
            a.Clear();
            b.Clear();
            c.Clear();
            d.Clear();
            ee.Clear();
            f.Clear();
            //Array.Clear(_coefArray, 0, _coefArray.Length);
            int A = int.Parse(CbState.Text);
            _coefArray = new double[A+1];
            //RootOutput.Text = _coefArray.Length.ToString();
            if (A == 5) { 
            
            }
            else if (A == 4)
            {
                a.Visible = false;
                x0.Visible = false;
            }
            else if (A == 3)
            {
                a.Visible = false;
                x0.Visible = false;
                b.Visible = false;
                x1.Visible = false;
            }
            else if (A == 2)
            {
                a.Visible = false;
                x0.Visible = false;
                b.Visible = false;
                x1.Visible = false;
                c.Visible = false;
                x2.Visible = false;
            }
            else if (A == 1)
            {
                a.Visible = false;
                x0.Visible = false;
                b.Visible = false;
                x1.Visible = false;
                c.Visible = false;
                x2.Visible = false;
                d.Visible = false;
                x3.Visible = false;
            }
        }

        private void a_TextChanged_1(object sender, EventArgs e)
        {
            _coefArray[5] = ParceInstrument(a.Text);
        }

        private void b_TextChanged(object sender, EventArgs e)
        {
            _coefArray[4] = ParceInstrument(b.Text);
        }

        private void c_TextChanged(object sender, EventArgs e)
        {
            _coefArray[3] = ParceInstrument(c.Text);
        }

        private void d_TextChanged(object sender, EventArgs e)
        {
            _coefArray[2] = ParceInstrument(d.Text);
        }

        private void e_TextChanged(object sender, EventArgs e)
        {
            _coefArray[1] = ParceInstrument(ee.Text);
        }

        private void f_TextChanged(object sender, EventArgs e)
        {
            _coefArray[0] = ParceInstrument(f.Text);
        }


        private double F1(double x) {

            return _coefArray[1] * x + _coefArray[0];
        
        }
        
        private double F2(double x)
        {
            return _coefArray[2] * x * x + _coefArray[1] * x + _coefArray[0];
        }

        private double F3(double x)
        {
            return _coefArray[3] * x * x * x + _coefArray[2] * x * x + _coefArray[1] * x + _coefArray[0];
        }

        private double F4(double x)
        {
            return _coefArray[4] * x * x * x * x + _coefArray[3] * x * x * x + _coefArray[2] * x * x + _coefArray[1] * x + _coefArray[0];
        }

        private double F5(double x)
        {
            return _coefArray[5] * x * x * x * x * x + _coefArray[4] * x * x * x * x + _coefArray[3] * x * x * x + _coefArray[2] * x * x + _coefArray[1] * x + _coefArray[0];
        }

        private void UpdateChart()
        {
            if (chart1.InvokeRequired)
            {
                chart1.Invoke(new Action(() =>
                {
                    UpdateChart();
                }
                ));
            }
            else
            {
                chart1.Series[0].Points.AddXY(100, 200);
            }

        } 

        private void equate() 
        {
            Equation newEquation = new Equation(_coefArray);
            double[] arr = newEquation.Evaluate(int.Parse(CbState.Text));
            if (int.Parse(CbState.Text) == 2 && arr[2] == 1)
            {
                RootOutput.Text += "\n";
                RootOutput.Text += "X1 = " + arr[0].ToString() + " + i*" + arr[1].ToString();
                RootOutput.Text += "\n";
                RootOutput.Text += "X2 = " + arr[0].ToString() + " - i*" + arr[1].ToString();
                RootCheck.Text = "Can't check complex roots!";
            }
            else if (int.Parse(CbState.Text) == 3 && arr[3] == 0)//WP
            {
                RootOutput.Text += "\n";
                RootOutput.Text += "X1 = " + arr[0] + "\n";

                RootCheck.Text += "\n" + "F(x1) = " + F3(arr[0]).ToString() + "\n";

                RootOutput.Text += "X2 = " + arr[1].ToString() + " + i*" + arr[2].ToString() + "\n";
                RootOutput.Text += "X2 = " + arr[1].ToString() + " - i*" + arr[2].ToString() + "\n";

                RootCheck.Text += "Can't check complex roots!";

            }
            else if (int.Parse(CbState.Text) == 3 && arr[3] == 1) //WP
            {
                RootOutput.Text += "\n";
                RootOutput.Text += "X1 = " + arr[0].ToString();
                RootCheck.Text += "\n" + "F(x1) = " + F3(arr[0]).ToString() + "\n";
                RootOutput.Text += "X2 = " + arr[1].ToString();
                RootCheck.Text += "\n" + "F(x2) = " + F3(arr[1]).ToString() + "\n";
                RootOutput.Text += "X3 = " + arr[1].ToString();
                RootCheck.Text += "\n" + "F(x3) = " + F3(arr[1]).ToString() + "\n";
            }
            else if (int.Parse(CbState.Text) == 3 && arr[3] == 2) //WP
            {
                RootOutput.Text += "\n";
                RootOutput.Text += "X1 =" + arr[0].ToString() + "\n";
                RootCheck.Text += "\n" + "F(x1) = " + F3(arr[0]).ToString() + "\n";
                RootOutput.Text += "X2 =" + arr[1].ToString() + "\n";
                RootCheck.Text += "\n" + "F(x1) = " + F3(arr[1]).ToString() + "\n";
                RootOutput.Text += "X3 =" + arr[2].ToString() + "\n";
                RootCheck.Text += "\n" + "F(x1) = " + F3(arr[2]).ToString() + "\n";

            }
            else if (int.Parse(CbState.Text) == 2)
            {
                for (int i = 0; i < int.Parse(CbState.Text); i++)
                {
                    RootOutput.Text += "X" + (i + 1).ToString() + " = " + arr[i].ToString() + "\n";
                    RootCheck.Text += "\n" + "F(x" + (i + 1).ToString() + ") = " + F2(arr[i]).ToString() + "\n";
                }
            }
            else if (int.Parse(CbState.Text) == 1)
            {
                RootOutput.Text += "X" + (1).ToString() + " = " + arr[0].ToString() + "\n";
                RootCheck.Text += "\n" + "F(x" + (1).ToString() + ") = " + F1(arr[0]).ToString() + "\n";

            }
            else
            {
                if (int.Parse(CbState.Text) <= 3)
                {
                    RootOutput.Text += "X" + (1).ToString() + " = " + arr[0].ToString() + "\n";
                    RootCheck.Text += "\n" + "F(x" + (1).ToString() + ") = " + F1(arr[0]).ToString() + "\n";
                }
            }        
        }

        private void evaluateButton_Click(object sender, EventArgs e)
        {
            if (acceptable(int.Parse(CbState.Text))) {
                clearSolution.Visible = true;
                RootCheck.Text = "";
                RootOutput.Text = "";
                showGraph(int.Parse(CbState.Text));
                equate();
                Array.Clear(_coefArray, 0, _coefArray.Length);
                //chart1.Series.Clear();
                evaluateButton.Hide();
            }
            else{
                Prompt.ShowDialog();
            }
            
        }

        private void test(int n) 
        {
            _coefArray = new double[n+1];
            switch (n){                    
                case 1:
                    _coefArray[1] = 1;
                    _coefArray[0] = 2;
                    showGraph(1);
                    break;
                case 2:
                    _coefArray[2] = 1;
                    _coefArray[1] = 2;
                    _coefArray[0] = 2;
                    showGraph(2);
                    break;
                case 3:
                    _coefArray[3] = 1;
                    _coefArray[2] = 2;
                    _coefArray[1] = 2;
                    _coefArray[0] = 2;
                    showGraph(3);
                    break;
                case 4:
                    _coefArray[4] = 1;
                    _coefArray[3] = 1;
                    _coefArray[2] = 2;
                    _coefArray[1] = 2;
                    _coefArray[0] = 2;
                    showGraph(4);
                    break;
                case 5:
                    _coefArray[5] = 1;
                    _coefArray[4] = 1;
                    _coefArray[3] = 1;
                    _coefArray[2] = 2;
                    _coefArray[1] = 2;
                    _coefArray[0] = 2;
                    showGraph(5);
                    break;
            }
        }


        private void RootOutput_Click(object sender, EventArgs e)
        {

        }

        private void TestButton_Click(object sender, EventArgs e)
        {
            if (CbState.Text != "")
            {
                test(int.Parse(CbState.Text));
            }
            else test(5);
        }

        private void clearSolution_Click(object sender, EventArgs e)
        {
            clearAll();    
        }

        private void clearAll() 
        {
            a.Clear();
            b.Clear();
            c.Clear();
            d.Clear();
            ee.Clear();
            f.Clear();
            RootCheck.Text = "RootCheck:";
            RootOutput.Text = "RootOutput:";
            CbState.Text = "";
            this.chart1.Series.Clear();
        }

        private bool acceptable(int n){

            switch (n){
                case 1:
                    if (ParceInstrument(ee.Text) != Int32.MinValue && ParceInstrument(f.Text) != Int32.MinValue)
                    {
                        return true;
                    }
                    break;
                case 2:
                    if (ParceInstrument(ee.Text) != Int32.MinValue 
                        && ParceInstrument(f.Text) != Int32.MinValue
                        && ParceInstrument(d.Text) != Int32.MinValue
                        )
                    {
                        return true;
                    }
                    break;
                case 3:
                    if (ParceInstrument(ee.Text) != Int32.MinValue
                        && ParceInstrument(f.Text) != Int32.MinValue
                        && ParceInstrument(d.Text) != Int32.MinValue
                        && ParceInstrument(c.Text) != Int32.MinValue
                        )
                    {
                        return true;
                    }
                    break;
            }
            clearCoef();
            return false;
        }

        private void clearCoef() {
            a.Clear();
            b.Clear();
            c.Clear();
            d.Clear();
            ee.Clear();
            f.Clear();
        }


    }
}

public static class Prompt
{
    public static void ShowDialog()
    {
        string text = "Please enter correct values";
        string caption = "Please enter correct values";
        Form prompt = new Form();
        prompt.Width = 500;
        prompt.Height = 200;
        prompt.Text = caption;
        Label textLabel = new Label() { Left = 50, Top = 20, Text = text, Width = 300 };
        Button confirmation = new Button() { Text = "Ok", Left = 350, Width = 100, Top = 70 };
        confirmation.Click += (sender, e) => { prompt.Close(); };
        prompt.Controls.Add(confirmation);
        prompt.Controls.Add(textLabel);
        prompt.ShowDialog();
    }
}