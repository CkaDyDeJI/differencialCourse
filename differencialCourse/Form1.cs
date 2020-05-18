using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace differencialCourse
{
    using static System.Convert;

    public partial class Form1 : Form
    {
        double[] startValues_ = new double[4];


        public Form1 ()
        {
            InitializeComponent ();
        }


        private void calculateButton_Click (object sender, EventArgs e)
        {
            if (initializeField() == false) {
                MessageBox.Show ("input correct values");

                return;
            }



            int dropDownMethod = methodComboBox.SelectedIndex;

            if (dropDownMethod != -1) {
                calculatedData.Rows.Clear();
            }

            if (dropDownMethod == 0)
                eulerMethod();
            else {
                if (dropDownMethod == 1)
                    rungeKutteMethod();
                else 
                    adamsMethod();
            }
        }


        private bool initializeField()
        {
            try {
                startValues_[0] = ToDouble ((leftBorderBox.Text).Replace ('.', ','));
            }
            catch {
                MessageBox.Show ("incorrect left border");

                return false;
            }

            try {
                startValues_[1] = ToDouble ((rightBorderBox.Text).Replace ('.', ','));
            }
            catch {
                MessageBox.Show ( "incorrect right border" );

                return false;
            }

            try {
                startValues_[2] = ToDouble ((stepBox.Text).Replace ('.', ','));
            }
            catch {
                MessageBox.Show ( "incorrect step" );

                return false;
            }

            try {
                startValues_[3] = ToDouble ((yTextBox.Text).Replace ('.', ','));
            }
            catch {
                MessageBox.Show ("incorrect y0");

                return false;
            }

            return true;
        }


        private void eulerMethod()
        {
            double step = startValues_[2];

            calculatedData.Rows.Add ();
            calculatedData.Rows[0].Cells[0].Value = startValues_.First();
            calculatedData.Rows[0].Cells[1].Value = startValues_.Last();


            int k = 0;
            double previousY = 0;
            double previousYd = 0;
            for (double i = startValues_[0]; i < startValues_[1]; i += step)
            {
                calculatedData.Rows.Add ();
                previousY = ToDouble ( calculatedData.Rows[k].Cells[1].Value );
                previousYd = step * F ( i, previousY );

                calculatedData.Rows[k].Cells[2].Value = previousYd;
                k++;

                calculatedData.Rows[k].Cells[0].Value = i + step;
                calculatedData.Rows[k].Cells[1].Value = previousYd + previousY;
            }
        }


        private void rungeKutteMethod()
        {
            double step = startValues_[2];

            calculatedData.Rows.Add ();
            calculatedData.Rows[0].Cells[0].Value = startValues_.First ();
            calculatedData.Rows[0].Cells[1].Value = startValues_.Last ();

            int k = 0;
            double k1 = 0;
            double k2 = 0;
            double k3 = 0;
            double k4 = 0;
            double previousY = 0;
            double previousYd = 0;
            for (double i = startValues_[0]; i < startValues_[1]; i += step)
            {
                calculatedData.Rows.Add ();
                previousY = ToDouble ( calculatedData.Rows[k].Cells[1].Value );
                k1 = step * F (i, previousY);
                k2 = step * F (i + step / 2.0, previousY + k1 / 2.0);
                k3 = step * F (i + step / 2.0, previousY + k2 / 2.0);
                k4 = step * F (i + step, previousY + k3);

                previousYd = 1.0 / 6.0 * (k1 + 2 * k2 + 2 * k3 + k4);

                calculatedData.Rows[k].Cells[2].Value = previousYd;
                k++;

                calculatedData.Rows[k].Cells[0].Value = i + step;
                calculatedData.Rows[k].Cells[1].Value = previousYd + previousY;
            }
        }


        private void adamsMethod()
        {

        }


        private double F (double x, double y)
        {
            return x + y * Math.Cos (x);
            //return x * x - 2 * y;
            //return 0.1 * x * y;
            //return (5 * x * y) + (2 * y) - x;
        }
    }
}