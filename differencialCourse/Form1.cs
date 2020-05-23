using System;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;


namespace differencialCourse
{
    using static Convert;


    public partial class Form1 : Form
    {
        private readonly double[] startValues_ = new double[4]; 


        public Form1()
        {
            InitializeComponent();
        }


        private void calculateButton_Click(object sender, EventArgs e) 
        {
            if (initializeField() == false)
            {   
                MessageBox.Show("input correct values");   

                return;
            }

            var selectedMethod = methodListBox.SelectedIndices;

            if (selectedMethod.Count == 1) {
                if (selectedMethod[0] == 0)
                    eulerMethod();
                else
                    rungeKutteMethod();
            } else {
                eulerMethod();
                rungeKutteMethod();
            }
            
        }


        private bool initializeField()
        {
            try
            {
                startValues_[0] = ToDouble(leftBorderBox.Text.Replace('.', ',')); 
            }
            catch
            {
                MessageBox.Show("incorrect left border");  

                return false;
            }

            try
            {
                startValues_[1] = ToDouble(rightBorderBox.Text.Replace('.', ','));    
            }
            catch
            {
                MessageBox.Show("incorrect right border");

                return false;
            }

            try
            {
                startValues_[2] = ToDouble(stepBox.Text.Replace('.', ','));   
            }
            catch
            {
                MessageBox.Show("incorrect step");

                return false;
            }

            try
            {
                startValues_[3] = ToDouble(yTextBox.Text.Replace('.', ','));  
            }
            catch
            {
                MessageBox.Show("incorrect y0");

                return false;
            }

            if  (startValues_[0] > startValues_[1]) {
                MessageBox.Show("left border must be lesser than right");

                return false;
            }

            return true;    
        }


        private void eulerMethod()  
        {
            calculatedData.Rows.Clear();    

            Stopwatch watch = new Stopwatch();
            watch.Start();

            var step = startValues_[2]; 

            calculatedData.Rows.Add();  
            calculatedData.Rows[0].Cells[0].Value = startValues_.First();   
            calculatedData.Rows[0].Cells[1].Value = startValues_.Last();    


            var k = 0;  
            double previousY = 0;   
            double previousYd = 0;  
            for (var i = startValues_[0]; i < startValues_[1]; i += step)
            { 
                calculatedData.Rows.Add();
                previousY = ToDouble(calculatedData.Rows[k].Cells[1].Value);   
                previousYd = step * F(i, previousY);   

                calculatedData.Rows[k].Cells[2].Value = previousYd; 
                k++;    

                calculatedData.Rows[k].Cells[0].Value = i + step;   
                calculatedData.Rows[k].Cells[1].Value = previousYd + previousY; 
            }

            watch.Stop();

            eulerTimer.Text = $"Метод Эйлера: {watch.Elapsed}";
        }


        private void rungeKutteMethod() 
        {
            rungeData.Rows.Clear();

            Stopwatch watch = new Stopwatch();
            watch.Start();

            var step = startValues_[2];

            rungeData.Rows.Add();
            rungeData.Rows[0].Cells[0].Value = startValues_.First();
            rungeData.Rows[0].Cells[1].Value = startValues_.Last();

            var k = 0;
            double k1 = 0;  
            double k2 = 0;
            double k3 = 0;
            double k4 = 0;
            double previousY = 0;
            double previousYd = 0;
            for (var i = startValues_[0]; i < startValues_[1]; i += step)
            {
                rungeData.Rows.Add();
                previousY = ToDouble(rungeData.Rows[k].Cells[1].Value);

                k1 = step * F(i, previousY);
                k2 = step * F(i + step / 2.0, previousY + k1 / 2.0);
                k3 = step * F(i + step / 2.0, previousY + k2 / 2.0);
                k4 = step * F(i + step, previousY + k3);
                rungeData.Rows[k].Cells[2].Value = k1;
                rungeData.Rows[k].Cells[3].Value = k2;
                rungeData.Rows[k].Cells[4].Value = k3;
                rungeData.Rows[k].Cells[5].Value = k4;

                previousYd = 1.0 / 6.0 * (k1 + (2 * k2) + (2 * k3) + k4);

                rungeData.Rows[k].Cells[6].Value = previousYd;
                k++;

                rungeData.Rows[k].Cells[0].Value = i + step;
                rungeData.Rows[k].Cells[1].Value = previousYd + previousY;
            }

            watch.Stop();

            rungeTimer.Text = $"Метод Эйлера: {watch.Elapsed}";
        }


        private double F(double x1, double y1)   
        {
            return (2 * x1 * x1) + (7 * y1) - (4 * y1 * y1);//(5 * x1 * y1) + (2 * y1) - x1);
        }
    }
}