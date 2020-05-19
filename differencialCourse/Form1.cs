using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;


namespace differencialCourse
{
    using static Convert;


    public partial class Form1 : Form
    {
        private readonly double[] startValues_ = new double[4]; //входные значения будут хваниться тут


        public Form1()
        {
            InitializeComponent();
        }


        private void calculateButton_Click(object sender, EventArgs e) //нажатие на кнопку рассчета штука
        {
            if (initializeField() == false)
            {   //функция проверки входных параметров
                MessageBox.Show("input correct values");   //сообщения о неправильном вводе

                return;
            }

            var selectedMethod = methodComboBox.SelectedIndex;  //сохранение индекса выбранного способо решения

            var dropDownMethod = methodComboBox.SelectedIndex;  //сохранение индекса выбранного способо решения

            if (dropDownMethod != -1) calculatedData.Rows.Clear();  //очистка таблицы, чтобы она пересоздавалась

            if (dropDownMethod == 0)
                eulerMethod();  //если выбран эйлер, то эйлер
            else
                rungeKutteMethod();
        }


        private bool initializeField()
        {
            try
            {
                startValues_[0] = ToDouble(leftBorderBox.Text.Replace('.', ',')); //левая граница и по совместительству х0
            }
            catch
            {
                MessageBox.Show("incorrect left border");  //иначе сообщить пользователю и возврат 

                return false;
            }

            try
            {
                startValues_[1] = ToDouble(rightBorderBox.Text.Replace('.', ','));    //правая граница интервала
            }
            catch
            {
                MessageBox.Show("incorrect right border");

                return false;
            }

            try
            {
                startValues_[2] = ToDouble(stepBox.Text.Replace('.', ','));   //шаг
            }
            catch
            {
                MessageBox.Show("incorrect step");

                return false;
            }

            try
            {
                startValues_[3] = ToDouble(yTextBox.Text.Replace('.', ','));  //у0
            }
            catch
            {
                MessageBox.Show("incorrect y0");

                return false;
            }

            return true;    //если все нормально считалось, то выполнение программы продолжается
        }


        private void methodComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (methodComboBox.SelectedIndex == 0)
            {
                calculatedData.Visible = true;
                rungeData.Visible = false;
            }
            else
            {
                if (methodComboBox.SelectedIndex == 1)
                {
                    calculatedData.Visible = false;
                    rungeData.Visible = true;
                }
            }
        }


        private void eulerMethod()  //эйлер
        {
            calculatedData.Rows.Clear();    //таблица для эйлера

            var step = startValues_[2]; //значения шага внутри функции

            calculatedData.Rows.Add();  //добавление строки в таблицу
            calculatedData.Rows[0].Cells[0].Value = startValues_.First();   //внос в таблицу х0
            calculatedData.Rows[0].Cells[1].Value = startValues_.Last();    //у0


            var k = 0;  //номер строки, с которой работаем
            double previousY = 0;   //предыдущий вычисленный y0
            double previousYd = 0;  //предыдущая вычисленная производная от у
            for (var i = startValues_[0]; i < startValues_[1]; i += step)
            { //проход по всему интервалу с шагом
                calculatedData.Rows.Add();
                previousY = ToDouble(calculatedData.Rows[k].Cells[1].Value);   //достаем из таблицы последний вычисленный y
                previousYd = step * F(i, previousY);   //вычисляем новую производную от y

                calculatedData.Rows[k].Cells[2].Value = previousYd; //записываем в таблицу
                k++;    //переходим на следующую строку

                calculatedData.Rows[k].Cells[0].Value = i + step;   //записываем в таблицу новый х (xi + 1)
                calculatedData.Rows[k].Cells[1].Value = previousYd + previousY; //новый y (yi)
            }
        }


        private void rungeKutteMethod() //рунге кутты (тут все то же самое, но с промежуточным вычисление коэффициентов)
        {
            rungeData.Rows.Clear(); //таблица для рунге кутты

            var step = startValues_[2];

            rungeData.Rows.Add();
            rungeData.Rows[0].Cells[0].Value = startValues_.First();
            rungeData.Rows[0].Cells[1].Value = startValues_.Last();

            var k = 0;
            double k1 = 0;  //переменные для коэффициентов
            double k2 = 0;
            double k3 = 0;
            double k4 = 0;
            double previousY = 0;
            double previousYd = 0;
            for (var i = startValues_[0]; i < startValues_[1]; i += step)
            {
                rungeData.Rows.Add();
                previousY = ToDouble(rungeData.Rows[k].Cells[1].Value);   //запись предыдущего у в переменную

                k1 = step * F(i, previousY);   //вычисление к1
                k2 = step * F(i + step / 2.0, previousY + k1 / 2.0);
                k3 = step * F(i + step / 2.0, previousY + k2 / 2.0);
                k4 = step * F(i + step, previousY + k3);
                rungeData.Rows[k].Cells[2].Value = k1;  //внесение коэффов в таблицу
                rungeData.Rows[k].Cells[3].Value = k2;
                rungeData.Rows[k].Cells[4].Value = k3;
                rungeData.Rows[k].Cells[5].Value = k4;

                previousYd = 1.0 / 6.0 * (k1 + (2 * k2) + (2 * k3) + k4);   //вычисление производной от у

                rungeData.Rows[k].Cells[6].Value = previousYd; //добавление ее в таблицу
                k++;

                rungeData.Rows[k].Cells[0].Value = i + step;   //добавление след х
                rungeData.Rows[k].Cells[1].Value = previousYd + previousY; //след у
            }
        }


        private double F (double x, double y)   //заданная функция
        {
            return x + y * Math.Cos (x);
        }
    }
}