using System;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;


namespace differencialCourse
{
    using static Convert;


    public partial class Form1 : Form
    {
        private readonly double[] initialValues_ = new double[4]; 


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

            var selectedMethod = methodList.CheckedIndices;

            if (selectedMethod.Count == 0)
            {
                MessageBox.Show("ни один метод не выбран");

                return;
            }

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
                initialValues_[0] = ToDouble(leftBorderBox.Text.Replace('.', ',')); 
            }
            catch
            {
                MessageBox.Show("неверно введена левая граница");  

                return false;
            }

            try
            {
                initialValues_[1] = ToDouble(rightBorderBox.Text.Replace('.', ','));    
            }
            catch
            {
                MessageBox.Show("неверно введена правая граница");

                return false;
            }

            try
            {
                initialValues_[2] = ToDouble(stepBox.Text.Replace('.', ','));   
            }
            catch
            {
                MessageBox.Show("некорректный шаг");

                return false;
            }

            try
            {
                initialValues_[3] = ToDouble(yTextBox.Text.Replace('.', ','));  
            }
            catch
            {
                MessageBox.Show("неверное значение y0");

                return false;
            }

            if  (initialValues_[0] > initialValues_[1]) {
                MessageBox.Show("левая граница должна быть больше правой границы");

                return false;
            }

            if (initialValues_[1] - initialValues_[0] < initialValues_[2]) {
                MessageBox.Show ("шаг должен быть меньше разница между правой и левой границами");

                return false;
            }

            return true;    
        }


        private void eulerMethod()  
        {
            dataGridView1.Rows.Clear();    

            Stopwatch watch = new Stopwatch();
            watch.Start();

            var step = initialValues_[2]; 

            dataGridView1.Rows.Add();  
            dataGridView1.Rows[0].Cells[0].Value = initialValues_.First();   
            dataGridView1.Rows[0].Cells[1].Value = initialValues_.Last();    


            var k = 0;  
            double previousY = initialValues_.Last();   
            double previousYd = 0;  
            for (var i = initialValues_[0]; i < initialValues_[1]; i += step)
            { 
                dataGridView1.Rows.Add();
                //previousY = ToDouble(calculatedData.Rows[k].Cells[1].Value);   
                previousYd = step * F(i, previousY);   

                dataGridView1.Rows[k].Cells[2].Value = previousYd; 
                k++;

                previousY += previousYd;
                dataGridView1.Rows[k].Cells[0].Value = i + step;   
                dataGridView1.Rows[k].Cells[1].Value = previousY; 
            }

            watch.Stop();

            eulerTimer.Text = $"Метод Эйлера: {watch.Elapsed}";
        }


        private void rungeKutteMethod() 
        {
            dataGridView2.Rows.Clear();

            Stopwatch watch = new Stopwatch();
            watch.Start();

            var step = initialValues_[2];

            dataGridView2.Rows.Add();
            dataGridView2.Rows[0].Cells[0].Value = initialValues_.First();
            dataGridView2.Rows[0].Cells[1].Value = initialValues_.Last();

            var k = 0;
            double k1 = 0;  
            double k2 = 0;
            double k3 = 0;
            double k4 = 0;
            double previousY = initialValues_.Last();
            double previousYd = 0;
            for (var i = initialValues_[0]; i < initialValues_[1]; i += step)
            {
                dataGridView2.Rows.Add();

                k1 = step * F(i, previousY);
                k2 = step * F(i + step / 2.0, previousY + k1 / 2.0);
                k3 = step * F(i + step / 2.0, previousY + k2 / 2.0);
                k4 = step * F(i + step, previousY + k3);
                dataGridView2.Rows[k].Cells[2].Value = k1;
                dataGridView2.Rows[k].Cells[3].Value = k2;
                dataGridView2.Rows[k].Cells[4].Value = k3;
                dataGridView2.Rows[k].Cells[5].Value = k4;

                previousYd = 1.0 / 6.0 * (k1 + (2 * k2) + (2 * k3) + k4);

                dataGridView2.Rows[k].Cells[6].Value = previousYd;
                k++;

                previousY += previousYd;
                dataGridView2.Rows[k].Cells[0].Value = i + step;
                dataGridView2.Rows[k].Cells[1].Value = previousY;
            }

            watch.Stop();

            rungeTimer.Text = $"Метод Рунге-Кутта: {watch.Elapsed}";
        }


        private double F (double x, double y)
        {
            return (10 - 2 * Math.Sin (3 * x + y));
        }
    }
}