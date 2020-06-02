using System;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;


namespace differencialCourse
{
    using static Convert;


    public partial class Form1 : Form
    {
        private readonly double[] initialValues_ = new double[4];   //массив с изначальными значениями a, b, h, y0


        public Form1()
        {
            InitializeComponent();
        }


        private void calculateButton_Click(object sender, EventArgs e)
        {
            if (initializeField() == false) //если были введены неверные значения, то вводить заново
            {   
                MessageBox.Show("введите корректные значения");   

                return;
            }

            var selectedMethod = methodList.CheckedIndices; //получение индексов выбранных методов

            if (selectedMethod.Count == 0)  //если ни один не выбран
            {
                MessageBox.Show("ни один метод не выбран");

                return;
            }

            if (selectedMethod.Count == 1) {    //если выбран один из методов
                if (selectedMethod[0] == 0) //то запустить соответствующий
                    eulerMethod();
                else
                    rungeKutteMethod();
            } else {    //если выбрано больше одного, то запустить все 
                eulerMethod();
                rungeKutteMethod();
            }
        }


        private bool initializeField()
        {
            try
            {
                initialValues_[0] = ToDouble(leftBorderBox.Text.Replace('.', ','));     //если введены неверные числа для левой границы
            }
            catch
            {
                MessageBox.Show("неверно введена левая граница");  

                return false;
            }

            try
            {
                initialValues_[1] = ToDouble(rightBorderBox.Text.Replace('.', ','));    //для правой
            }
            catch
            {
                MessageBox.Show("неверно введена правая граница");

                return false;
            }

            try
            {
                initialValues_[2] = ToDouble(stepBox.Text.Replace('.', ','));   //для шага
            }
            catch
            {
                MessageBox.Show("некорректный шаг");

                return false;
            }

            try
            {
                initialValues_[3] = ToDouble(yTextBox.Text.Replace('.', ','));  //для y0
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
            dataGridView1.Rows.Clear();    //очистика таблицы от предыдущего вычисления

            Stopwatch watch = new Stopwatch();  //запуск таймера
            watch.Start();

            var step = initialValues_[2];   //переменная под шаг

            dataGridView1.Rows.Add();  
            dataGridView1.Rows[0].Cells[0].Value = initialValues_.First();  //добавление в таблицу х0   
            dataGridView1.Rows[0].Cells[1].Value = initialValues_.Last();   //у0


            var k = 0;  
            double previousY = initialValues_.Last();   //установка у = у0
            double previousYd = 0;  
            for (var i = initialValues_[0]; i < initialValues_[1]; i += step)   //пока не дойдем до правой границы
            { 
                dataGridView1.Rows.Add(); 
                previousYd = step * F(i, previousY);   //вычисление дельта у

                dataGridView1.Rows[k].Cells[2].Value = previousYd; //добавление его в таблицу
                k++;

                previousY += previousYd;    //вычисление значения дифференциала в следующей точке
                dataGridView1.Rows[k].Cells[0].Value = i + step;   //добавление следующего х
                dataGridView1.Rows[k].Cells[1].Value = previousY;   //и последнего вычисленного у
            }

            watch.Stop();   //остановка таймера

            eulerTimer.Text = $"Метод Эйлера: {watch.Elapsed}"; //вывод затраченного времени
        }


        private void rungeKutteMethod() 
        {
            dataGridView2.Rows.Clear();

            Stopwatch watch = new Stopwatch();
            watch.Start();

            var step = initialValues_[2];

            dataGridView2.Rows.Add();
            dataGridView2.Rows[0].Cells[0].Value = initialValues_.First();
            dataGridView2.Rows[0].Cells[1].Value = initialValues_.Last();   //до сюда все то же самое, что и в эйлере

            var k = 0;
            double k1 = 0;  //переменные под k  
            double k2 = 0;
            double k3 = 0;
            double k4 = 0;
            double previousY = initialValues_.Last();
            double previousYd = 0;
            for (var i = initialValues_[0]; i < initialValues_[1]; i += step)
            {
                dataGridView2.Rows.Add();

                k1 = step * F(i, previousY);    //вычисление коэфф
                k2 = step * F(i + step / 2.0, previousY + k1 / 2.0);
                k3 = step * F(i + step / 2.0, previousY + k2 / 2.0);
                k4 = step * F(i + step, previousY + k3);
                dataGridView2.Rows[k].Cells[2].Value = k1;  //добавление коэфф в таблицу
                dataGridView2.Rows[k].Cells[3].Value = k2;
                dataGridView2.Rows[k].Cells[4].Value = k3;
                dataGridView2.Rows[k].Cells[5].Value = k4;

                previousYd = 1.0 / 6.0 * (k1 + (2 * k2) + (2 * k3) + k4);   //вычисление дельта у

                dataGridView2.Rows[k].Cells[6].Value = previousYd;  //добавление в таблицу
                k++;

                previousY += previousYd;    //вычисление значения дифференциала в следующей точке
                dataGridView2.Rows[k].Cells[0].Value = i + step;    //доавление следующего х
                dataGridView2.Rows[k].Cells[1].Value = previousY;   //вычисленного у
            }

            watch.Stop();   //остановка таймера

            rungeTimer.Text = $"Метод Рунге-Кутта: {watch.Elapsed}";    //вывод затраченного времени
        }


        private double F (double x, double y)   //сама функция
        {
            return (10 - 2 * Math.Sin (3 * x + y));
        }
    }
}