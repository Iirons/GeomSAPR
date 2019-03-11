using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace OLS
{
    public partial class Form1 : Form
    {
        //TODO: delete points by cursor, get y by typing specific x for each line, coeff output


        public Form1()
        {
            InitializeComponent();
        }

        bool Drawing = false, Deleting = false;
        public List<PointD> newpoints = new List<PointD>();
        LSM lsm2 = new LSM();
        LSM lsm3 = new LSM();
        Lab2 lab2cl = new Lab2();
        bool lab1 = true;
        bool lab2 = false;

        private void Form1_Load(object sender, EventArgs e)
        {
            chart1.ChartAreas[0].AxisX.ScaleView.Zoomable = true;
            chart1.ChartAreas[0].AxisY.ScaleView.Zoomable = true;
            chart1.Series["PointSeries"].XValueMember = "X_Value";
            chart1.Series["PointSeries"].YValueMembers = "Y_Value";
            chart1.ChartAreas[0].AxisY.LabelStyle.Format = "";
            chart1.Series["PointSeries"].Points.AddXY(0, 0);
            chart1.Series["PointSeries"].Points.AddXY(100, 100);
            dataGridView1.Columns.Add("x", "X");
            dataGridView1.Columns.Add("y", "Y");
            chart1.MouseWheel += chart1_MouseWheel;

            lab1 = false;
            lab2 = true;
            LSM2checkBox.Text = "PL";
            LSM3checkBox.Text = "Lagrange";



        }
        

        private void DrawButton_Click(object sender, EventArgs e)
        {
            if (Drawing)
            {
                chart1.Series["PointSeries"].Points.Clear();
                dataGridView1.Rows.Clear();
                int i = 0;
                newpoints = newpoints.OrderBy(v => v.X).ToList();
                foreach (var p in newpoints){
                    dataGridView1.Rows.Add();
                    dataGridView1[0, i].Value = newpoints[i].X;
                    dataGridView1[1, i].Value = newpoints[i].Y;
                    chart1.Series["PointSeries"].Points.AddXY(newpoints[i].X, newpoints[i].Y);
                    i++;
                }
                Drawing = false;
                DrawButton.Text = "Draw";
            }
            else
            {
                newpoints.Clear();
                Drawing = true;
                DrawButton.Text = "Stop Drawing";
            }
        }

        private void chart1_MouseClick(object sender, MouseEventArgs e)
        {
            var pos = LocationInChart(e.X, e.Y);
            if (Drawing)
            {
                //1var pos = LocationInChart(e.X, e.Y);

                chart1.Series["PointSeries"].Points.AddXY(pos.X, pos.Y);
                newpoints.Add(new PointD(pos.X, pos.Y));

                //label1.Text = string.Format("({0}, {1}) ... ({2}, {3})", e.X, e.Y, pos.X, pos.Y);

                //2

                //chart1.ChartAreas[0].CursorX.SetCursorPixelPosition(new PointF(e.X, e.Y), true);
                //chart1.ChartAreas[0].CursorY.SetCursorPixelPosition(new PointF(e.X, e.Y), true);

                //double x = chart1.ChartAreas[0].CursorX.Position;
                //double y = chart1.ChartAreas[0].CursorY.Position;
                //chart1.Series["PointSeries"].Points.AddXY(x,y);
                //newpoints.Add(new PointD(x, y));
            }
            if (Deleting && newpoints.Count != 0)
            {
                double x1 = pos.X, y1 = pos.Y;
                double x2 = newpoints[0].X, y2 = newpoints[0].Y;
                double jdist = Math.Sqrt(((x1-x2)* (x1 - x2) + (y1-y2)* (y1 - y2)));
                int j =0; // index to delete
                for(int k =1; k< newpoints.Count; k++)
                {
                    x2 = newpoints[k].X;
                    y2 = newpoints[k].Y;
                    double newdist = Math.Sqrt(((x1 - x2) * (x1 - x2) + (y1 - y2) * (y1 - y2)));
                    if ( newdist < jdist){
                        j = k;
                        jdist = newdist;
                    }
                }
                newpoints.RemoveAt(j);


                chart1.Series["PointSeries"].Points.Clear();
                dataGridView1.Rows.Clear();
                int i = 0;
                foreach (var p in newpoints)
                {
                    dataGridView1.Rows.Add();
                    dataGridView1[0, i].Value = newpoints[i].X;
                    dataGridView1[1, i].Value = newpoints[i].Y;
                    chart1.Series["PointSeries"].Points.AddXY(newpoints[i].X, newpoints[i].Y);
                    i++;
                }

            }
        }

        private int FZoomLevel = 0;
        double CZoomScale = 1.5;

        private void Chart1_MouseEnter(object sender, EventArgs e)
        {
            if (!chart1.Focused)
                chart1.Focus();
        }

        private void Chart1_MouseLeave(object sender, EventArgs e)
        {
            if (chart1.Focused)
                chart1.Parent.Focus();
        }

        private void chart1_MouseWheel(object sender, MouseEventArgs e)
        {
            var chart = (Chart)sender;
            var xAxis = chart.ChartAreas[0].AxisX;
            var yAxis = chart.ChartAreas[0].AxisY;
            try
            {
                if (e.Delta < 0) // Scrolled down.
                {
                    xAxis.ScaleView.ZoomReset();
                    yAxis.ScaleView.ZoomReset();
                }
                else if (e.Delta > 0) // Scrolled up.
                {
                    var xMin = xAxis.ScaleView.ViewMinimum;
                    var xMax = xAxis.ScaleView.ViewMaximum;
                    var yMin = yAxis.ScaleView.ViewMinimum;
                    var yMax = yAxis.ScaleView.ViewMaximum;

                    var posXStart = xAxis.PixelPositionToValue(e.Location.X) - (xMax - xMin) / 4;
                    var posXFinish = xAxis.PixelPositionToValue(e.Location.X) + (xMax - xMin) / 4;
                    var posYStart = yAxis.PixelPositionToValue(e.Location.Y) - (yMax - yMin) / 4;
                    var posYFinish = yAxis.PixelPositionToValue(e.Location.Y) + (yMax - yMin) / 4;

                    xAxis.ScaleView.Zoom(posXStart, posXFinish);
                    yAxis.ScaleView.Zoom(posYStart, posYFinish);
                }



                //Axis xAxis = chart1.ChartAreas[0].AxisX;
                //double xMin = xAxis.ScaleView.ViewMinimum;
                //double xMax = xAxis.ScaleView.ViewMaximum;
                //double xPixelPos = xAxis.PixelPositionToValue(e.Location.X);

                //if (e.Delta < 0 && FZoomLevel > 0)
                //{
                //    // Scrolled down, meaning zoom out
                //    if (--FZoomLevel <= 0)
                //    {
                //        FZoomLevel = 0;
                //        xAxis.ScaleView.ZoomReset();
                //    }
                //    else
                //    {
                //        double xStartPos = Math.Max(xPixelPos - (xPixelPos - xMin) * CZoomScale, 0);
                //        double xEndPos = Math.Min(xStartPos + (xMax - xMin) * CZoomScale, xAxis.Maximum);
                //        xAxis.ScaleView.Zoom(xStartPos, xEndPos);
                //    }
                //}
                //else if (e.Delta > 0)
                //{
                //    // Scrolled up, meaning zoom in
                //    double xStartPos = Math.Max(xPixelPos - (xPixelPos - xMin) / CZoomScale, 0);
                //    double xEndPos = Math.Min(xStartPos + (xMax - xMin) / CZoomScale, xAxis.Maximum);
                //    xAxis.ScaleView.Zoom(xStartPos, xEndPos);
                //    FZoomLevel++;
                //}

                //Axis yAxis = chart1.ChartAreas[0].AxisY;
                //double yMin = yAxis.ScaleView.ViewMinimum;
                //double yMax = yAxis.ScaleView.ViewMaximum;
                //double yPixelPos = yAxis.PixelPositionToValue(e.Location.Y);

                //if (e.Delta < 0 && FZoomLevel > 0)
                //{
                //    // Scrolled down, meaning zoom out
                //    if (--FZoomLevel <= 0)
                //    {
                //        FZoomLevel = 0;
                //        yAxis.ScaleView.ZoomReset();
                //    }
                //    else
                //    {
                //        double yStartPos = Math.Max(yPixelPos - (yPixelPos - yMin) * CZoomScale, 0);
                //        double yEndPos = Math.Min(yStartPos + (yMax - yMin) * CZoomScale, yAxis.Maximum);
                //        yAxis.ScaleView.Zoom(yStartPos, yEndPos);
                //    }
                //}
                //else if (e.Delta > 0)
                //{
                //    // Scrolled up, meaning zoom in
                //    double yStartPos = Math.Max(yPixelPos - (yPixelPos - yMin) / CZoomScale, 0);
                //    double yEndPos = Math.Min(yStartPos + (yMax - yMin) / CZoomScale, yAxis.Maximum);
                //    yAxis.ScaleView.Zoom(yStartPos, yEndPos);
                //    FZoomLevel++;
                //}
            }
            catch { }
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {

            List<PointD> newpoints1 = new List<PointD>();
            double x, y;

            try
            {
                for (int i = 0; i < dataGridView1.Rows.Count-1; i++)
                {
                    x = Convert.ToDouble(dataGridView1[0, i].Value);
                    y = Convert.ToDouble(dataGridView1[1, i].Value);
                    newpoints1.Add(new PointD(x, y));
                }
                newpoints = newpoints1;
                chart1.Series["PointSeries"].Points.Clear();
                foreach (var p in newpoints)
                {
                    chart1.Series["PointSeries"].Points.AddXY(p.X, p.Y);
                }
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }


        }

        private void CalculateLSMButton_Click(object sender, EventArgs e)
        {
            chart1.Series["LineSeries1"].Points.Clear();
            chart1.Series["LineSeries2"].Points.Clear();
            if (lab1)
            {
                lsm2.FillTheMatrix2(newpoints);
                lsm3.FillTheMatrix3(newpoints);
                if (LSM2checkBox.Checked)
                {
                    for (double i = newpoints[0].X - 1; i < newpoints[newpoints.Count - 1].X + 1; i++)
                    {
                        chart1.Series["LineSeries1"].Points.AddXY(i, lsm2.C0 + lsm2.C1 * i);
                    }
                }
                if (LSM3checkBox.Checked)
                {
                    for (double i = newpoints[0].X - 1; i < newpoints[newpoints.Count - 1].X + 1; i++)
                    {
                        chart1.Series["LineSeries2"].Points.AddXY(i, lsm3.C0 + lsm3.C1 * i + lsm3.C2 * i * i);
                    }
                }
            }
            else
            {
                List<double> xValues = newpoints.Select(obj => obj.X).ToList();
                List<double> yValues = newpoints.Select(obj => obj.Y).ToList();
                if (LSM2checkBox.Checked)//PL
                {
                    for (double i = newpoints[0].X; i <= newpoints[newpoints.Count-1].X; i++)
                    {
                        chart1.Series["LineSeries1"].Points.AddXY(i, lab2cl.GetYPL(i,xValues,yValues));
                    }
                }
                if (LSM3checkBox.Checked)//Lagrange
                {
                    for (double i = newpoints[0].X; i <= newpoints[newpoints.Count-1].X; i++)
                    {
                        chart1.Series["LineSeries2"].Points.AddXY(i, lab2cl.InterpolateLagrangePolynomial(i, xValues, yValues, xValues.Count));
                    }
                }
            }
            

        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            chart1.Series["LineSeries2"].Points.Clear();
            chart1.Series["LineSeries1"].Points.Clear();
        }

        private PointD LocationInChart(double xMouse, double yMouse)
        {
            var ca = chart1.ChartAreas[0];

            //Position inside the control, from 0 to 100
            var relPosInControl = new PointD
            (
              ((double)xMouse / (double)chart1.Width) * 100,
              ((double)yMouse / (double)chart1.Height) * 100
            );

            //Verify we are inside the Chart Area
            if (relPosInControl.X < ca.Position.X || relPosInControl.X > ca.Position.Right
            || relPosInControl.Y < ca.Position.Y || relPosInControl.Y > ca.Position.Bottom) return new PointD(double.NaN, double.NaN);

            //Position inside the Chart Area, from 0 to 100
            var relPosInChartArea = new PointD
            (
              ((relPosInControl.X - ca.Position.X) / ca.Position.Width) * 100,
              ((relPosInControl.Y - ca.Position.Y) / ca.Position.Height) * 100
            );

            //Verify we are inside the Plot Area
            if (relPosInChartArea.X < ca.InnerPlotPosition.X || relPosInChartArea.X > ca.InnerPlotPosition.Right
            || relPosInChartArea.Y < ca.InnerPlotPosition.Y || relPosInChartArea.Y > ca.InnerPlotPosition.Bottom) return new PointD(double.NaN, double.NaN);

            //Position inside the Plot Area, 0 to 1
            var relPosInPlotArea = new PointD
            (
              ((relPosInChartArea.X - ca.InnerPlotPosition.X) / ca.InnerPlotPosition.Width),
              ((relPosInChartArea.Y - ca.InnerPlotPosition.Y) / ca.InnerPlotPosition.Height)
            );

            var X = relPosInPlotArea.X * (ca.AxisX.Maximum - ca.AxisX.Minimum) + ca.AxisX.Minimum;
            var Y = (1 - relPosInPlotArea.Y) * (ca.AxisY.Maximum - ca.AxisY.Minimum) + ca.AxisY.Minimum;

            return new PointD(X, Y);
        }

        private void GetYButton_Click(object sender, EventArgs e)
        {
            string YText = "";
            if(XTextBox.Text != "")
            {
                double x = Convert.ToDouble(XTextBox.Text);
                YText = "For x = " + XTextBox.Text + "\n";

                if (lab1)
                {
                    if (LSM2checkBox.Checked)
                    {
                        YText += "LSM 2 y value = " + (lsm2.C0 + lsm2.C1 * x) + "\n";
                    }
                    if (LSM3checkBox.Checked)
                    {
                        YText += "LSM 3 y value = " + (lsm3.C0 + lsm3.C1 * x + lsm3.C2 * x * x) + "\n";
                    }
                }
                else if (lab2)
                {
                    List<double> xValues = newpoints.Select(obj => obj.X).ToList();
                    List<double> yValues = newpoints.Select(obj => obj.Y).ToList();
                    if (x < xValues[0] || x > xValues[xValues.Count - 1])
                    {
                        MessageBox.Show("Wrong X Value");
                    }
                    else
                    {
                        if (LSM2checkBox.Checked)
                        {
                            YText += "PL y value = " + (lab2cl.GetYPL(x, xValues, yValues)) + "\n";
                        }
                        if (LSM3checkBox.Checked)
                        {
                            YText += "Lagrange y value = " + (lab2cl.InterpolateLagrangePolynomial(x, xValues, yValues, xValues.Count)) + "\n";
                        }
                    }
                }
                MessageBox.Show(YText);
            }
            else
            {
                MessageBox.Show("Wrong X Value");
            }
        }

        private void DeletePointButton_Click(object sender, EventArgs e)
        {
            if (Deleting)
            {
                Deleting = false;
                DeletePointButton.Text = "Delete Points";
            }
            else
            {
                if (Drawing)
                {
                    DrawButton_Click(this,new EventArgs());
                }
                Deleting = true;
                DeletePointButton.Text = "Stop Deleting";
            }
        }

        private void GetCoefButton_Click(object sender, EventArgs e)
        {
            try
            {
                string text = "";
                if (lab1)
                {
                    if (LSM2checkBox.Checked)
                    {
                        text += "Coefficients for LSM2 are:\nC0 = " + lsm2.C0 + "\nC1 = " + lsm2.C1 + "\n";
                    }
                    if (LSM3checkBox.Checked)
                    {
                        text += "Coefficients for LSM3 are:\nC0 = " + lsm3.C0 + "\nC1 = " + lsm3.C1 + "\nC2 = " + lsm3.C2;
                    }
                }
                else if (lab2)
                {
                    if (LSM2checkBox.Checked)
                    {
                        text += "Coefficients for LSM2 are:\nC0 = "  + "\nC1 = "  + "\n";
                    }
                    if (LSM3checkBox.Checked)
                    {
                        text += "Coefficients for LSM3 are:\nC0 = "  + "\nC1 = "  + "\nC2 = " + lsm3.C2;
                    }
                }
                MessageBox.Show(text);
            }catch(Exception er)
            {
                MessageBox.Show(er.Message);
            }
        }
    }

    public struct PointD
    {
        public double X;
        public double Y;
        public PointD(double X, double Y)
        {
            this.X = X;
            this.Y = Y;
        }
    }


}
