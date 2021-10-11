using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task1
{
    public partial class Form1 : Form
    {
        private Triangle triangle;
        private EquilateralTriangle equitTriangle;
        public Form1()
        {
            InitializeComponent();
        }

        private void sidesChangeBtn_Click(object sender, EventArgs e)
        {
            triangle = new Triangle();

            try
            {
                if(!(triangle.ChangeSide(Convert.ToDouble(side1tb.Text), 0) && triangle.ChangeSide(Convert.ToDouble(side2tb.Text), 1) &&
                triangle.ChangeSide(Convert.ToDouble(side3tb.Text), 2)))
                {
                    MessageBox.Show("Sides should be > 0 and sum of each two sides is bigger than another side.");
                    return;
                }
            }
            catch(FormatException)
            {
                MessageBox.Show("Print numbers > 0");
                return;
            }

            double[] angles = triangle.GetAngles();
            angle1tb.Text = angles[0].ToString();
            angle2tb.Text = angles[1].ToString();
            angle3tb.Text = angles[2].ToString();

            perimeterTb.Text = triangle.GetPerimeter().ToString();
        }

        private void equilTriangleSidebtn_Click(object sender, EventArgs e)
        {
            equitTriangle = new EquilateralTriangle();
            try
            {
                if (!(equitTriangle.ChangeSide(Convert.ToDouble(equitTriangleSideTb.Text), 0)))
                {
                    MessageBox.Show("Side should be > 0");
                    return;
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Print numbers > 0");
                return;
            }

            equitTrSquareTb.Text = equitTriangle.GetSquare().ToString();
        }
    }
}
