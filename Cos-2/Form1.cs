using Cos_2.Lib;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Cos_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            Program.f1 = this;
            InitializeComponent();
            distributionTypes = new List<DistributionType>();
            distributionsList = new List<Distribution>();
            chAmp.MouseWheel += ch_MouseWheel;
            chPha.MouseWheel += ch_MouseWheel;
            chFlower.MouseWheel += ch_MouseWheel;
            polyY = new double[Int32.Parse(tbN.Text)];
            polyX = new double[Int32.Parse(tbN.Text)];
        }

        private double[] SinSpectrum { get; set; }
        private double[] CosSpectrum { get; set; }
        private double[] AmplitudeSpectrum { get; set; }
        private double[] PhaseSpectrum { get; set; }

        private double[] polyY;
        private double[] polyX;
        private double[] restoredY;

        private List<DistributionType> distributionTypes;
        private List<Distribution> distributionsList;

        private void btAdd_Click(object sender, EventArgs e)
        {
            restoredY = new double[Int32.Parse(tbN.Text)];
            Distribution distribution = new Cos(1, 1, 0, 128);
            chDist.Series[2].Points.Clear();

            if (rbCos.Checked)
            {
                distribution = new Cos(float.Parse(tbA.Text), float.Parse(tbF.Text), float.Parse(tbFi0.Text), Int32.Parse(tbN.Text));
                for (int i = 0; i < Int32.Parse(tbN.Text); i++)
                {
                    chDist.Series[2].Points.AddXY(distribution.Points[i].X, distribution.Points[i].Y);
                    polyY[i] += distribution.Points[i].Y;
                    polyX[i] += distribution.Points[i].X;
                }
                distributionTypes.Add(DistributionType.Cos);
                distributionsList.Add(distribution);

            }
            else if (rbSin.Checked)
            {
                distribution = new Sin(float.Parse(tbA.Text), float.Parse(tbF.Text), float.Parse(tbFi0.Text), Int32.Parse(tbN.Text));
                for (int i = 0; i < Int32.Parse(tbN.Text); i++)
                {
                    chDist.Series[2].Points.AddXY(distribution.Points[i].X, distribution.Points[i].Y);
                    polyY[i] += distribution.Points[i].Y;
                    polyX[i] += distribution.Points[i].X;
                }
                distributionTypes.Add(DistributionType.Sin);
                distributionsList.Add(distribution);
            }
            else if (rbPulse.Checked)
            {
                distribution = new Pulse(float.Parse(tbA.Text), float.Parse(tbF.Text), float.Parse(tbFi0.Text), Int32.Parse(tbN.Text));
                for (int i = 0; i < Int32.Parse(tbN.Text); i++)
                {
                    chDist.Series[2].Points.AddXY(distribution.Points[i].X, distribution.Points[i].Y);
                    polyY[i] += distribution.Points[i].Y;
                    polyX[i] += distribution.Points[i].X;
                }
                distributionTypes.Add(DistributionType.Pulse);
                distributionsList.Add(distribution);
            }
            else if (rbTrian.Checked)
            {
                distribution = new Trian(float.Parse(tbA.Text), float.Parse(tbF.Text), float.Parse(tbFi0.Text), Int32.Parse(tbN.Text));
                for (int i = 0; i < Int32.Parse(tbN.Text); i++)
                {
                    chDist.Series[2].Points.AddXY(distribution.Points[i].X, distribution.Points[i].Y);
                    polyY[i] += distribution.Points[i].Y;
                    polyX[i] += distribution.Points[i].X;
                }
                distributionTypes.Add(DistributionType.Trian);
                distributionsList.Add(distribution);
            }
            else if (rbSaw.Checked)
            {
                distribution = new Sawtooth(float.Parse(tbA.Text), float.Parse(tbF.Text), float.Parse(tbFi0.Text), Int32.Parse(tbN.Text));
                for (int i = 0; i < Int32.Parse(tbN.Text); i++)
                {
                    chDist.Series[2].Points.AddXY(distribution.Points[i].X, distribution.Points[i].Y);
                    polyY[i] += distribution.Points[i].Y;
                    polyX[i] += distribution.Points[i].X;
                }
                distributionTypes.Add(DistributionType.Saw);
                distributionsList.Add(distribution);
            }


            //chDist.Series[2].Color = Color.FromArgb(255 - distributionsList.Count * 20, 0 + distributionsList.Count*20, 255 - distributionsList.Count*10);

            CompAndDraw();
        }

        private void btClear_Click(object sender, EventArgs e)
        {
            chDist.Series[0].Points.Clear();
            chDist.Series[1].Points.Clear();
            chDist.Series[2].Points.Clear();
            chAmp.Series[0].Points.Clear();
            chPha.Series[0].Points.Clear();
            chFlower.Series[0].Points.Clear();
            polyY = new double[Int32.Parse(tbN.Text)];
            polyX = new double[Int32.Parse(tbN.Text)];
            distributionTypes.Clear();
            distributionsList.Clear();
        }

        private void tbN_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                polyY = new double[Int32.Parse(tbN.Text)];
                polyX = new double[Int32.Parse(tbN.Text)];

                DistributionRedraw(polyX, polyY);
            }
        }

        private void tbK_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                CompAndDraw();
            }

        }

        private void tbA_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                polyY = new double[Int32.Parse(tbN.Text)];
                polyX = new double[Int32.Parse(tbN.Text)];
                DistributionRedrawA(float.Parse(tbA.Text));
            }
        }

        private void tbF_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                polyY = new double[Int32.Parse(tbN.Text)];
                polyX = new double[Int32.Parse(tbN.Text)];
                DistributionRedrawF(float.Parse(tbF.Text));
            }
        }

        private void tbFi0_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                polyY = new double[Int32.Parse(tbN.Text)];
                polyX = new double[Int32.Parse(tbN.Text)];
                DistributionRedrawFi0(float.Parse(tbFi0.Text));
            }
        }

        private void ch_MouseWheel(object sender, MouseEventArgs e)
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
            }
            catch { }
        }

        private void DistributionRedraw(double[] polyX, double[] polyY)
        {
            Distribution distrib;
            for(int i = 0; i < distributionsList.Count; i++)
            {
                if (distributionTypes[i] == DistributionType.Saw)
                {
                    distrib = new Sawtooth(distributionsList[i].a, distributionsList[i].f, distributionsList[i].fi0, Int32.Parse(tbN.Text));
                    distributionsList[i] = distrib;
                    distributionsList[i] = distrib;
                    for (int j = 0; j < Int32.Parse(tbN.Text); j++)
                    {
                        polyY[j] += distrib.Points[j].Y;
                        polyX[j] += distrib.Points[j].X;
                    }
                }
                else if (distributionTypes[i] == DistributionType.Cos)
                {
                    distrib = new Cos(distributionsList[i].a, distributionsList[i].f, distributionsList[i].fi0, Int32.Parse(tbN.Text));
                    distributionsList[i] = distrib;
                    for (int j = 0; j < Int32.Parse(tbN.Text); j++)
                    {
                        polyY[j] += distrib.Points[j].Y;
                        polyX[j] += distrib.Points[j].X;
                    }

                }
                else if (distributionTypes[i] == DistributionType.Sin)
                {
                    distrib = new Sin(distributionsList[i].a, distributionsList[i].f, distributionsList[i].fi0, Int32.Parse(tbN.Text));
                    distributionsList[i] = distrib;
                    for (int j = 0; j < Int32.Parse(tbN.Text); j++)
                    {
                        polyY[j] += distrib.Points[j].Y;
                        polyX[j] += distrib.Points[j].X;
                    }

                }
                else if (distributionTypes[i] == DistributionType.Trian)
                {
                    distrib = new Trian(distributionsList[i].a, distributionsList[i].f, distributionsList[i].fi0, Int32.Parse(tbN.Text));
                    distributionsList[i] = distrib;
                    for (int j = 0; j < Int32.Parse(tbN.Text); j++)
                    {
                        polyY[j] += distrib.Points[j].Y;
                        polyX[j] += distrib.Points[j].X;
                    }
                }
                else if (distributionTypes[i] == DistributionType.Pulse)
                {
                    distrib = new Pulse(distributionsList[i].a, distributionsList[i].f, distributionsList[i].fi0, Int32.Parse(tbN.Text));
                    distributionsList[i] = distrib;
                    for (int j = 0; j < Int32.Parse(tbN.Text); j++)
                    {
                        polyY[j] += distrib.Points[j].Y;
                        polyX[j] += distrib.Points[j].X;
                    }
                }

                CompAndDraw();
            }

        }

        private void DistributionRedrawA(float a)
        {
            Distribution distrib;
            for (int i = 0; i < distributionsList.Count; i++)
            {
                if (distributionTypes[i] == DistributionType.Saw)
                {
                    distrib = new Sawtooth(a, distributionsList[i].f, distributionsList[i].fi0, distributionsList[i].n);
                    distributionsList[i] = distrib;
                    for (int j = 0; j < Int32.Parse(tbN.Text); j++)
                    {
                        polyY[j] += distrib.Points[j].Y;
                        polyX[j] += distrib.Points[j].X;
                    }
                }
                else if (distributionTypes[i] == DistributionType.Cos)
                {
                    distrib = new Cos(a, distributionsList[i].f, distributionsList[i].fi0, distributionsList[i].n);
                    distributionsList[i] = distrib;
                    for (int j = 0; j < Int32.Parse(tbN.Text); j++)
                    {
                        polyY[j] += distrib.Points[j].Y;
                        polyX[j] += distrib.Points[j].X;
                    }

                }
                else if (distributionTypes[i] == DistributionType.Sin)
                {
                    distrib = new Sin(a, distributionsList[i].f, distributionsList[i].fi0, distributionsList[i].n);
                    distributionsList[i] = distrib;
                    for (int j = 0; j < Int32.Parse(tbN.Text); j++)
                    {
                        polyY[j] += distrib.Points[j].Y;
                        polyX[j] += distrib.Points[j].X;
                    }

                }
                else if (distributionTypes[i] == DistributionType.Trian)
                {
                    distrib = new Trian(a, distributionsList[i].f, distributionsList[i].fi0, distributionsList[i].n);
                    distributionsList[i] = distrib;
                    for (int j = 0; j < Int32.Parse(tbN.Text); j++)
                    {
                        polyY[j] += distrib.Points[j].Y;
                        polyX[j] += distrib.Points[j].X;
                    }
                }
                else if (distributionTypes[i] == DistributionType.Pulse)
                {
                    distrib = new Pulse(a, distributionsList[i].f, distributionsList[i].fi0, distributionsList[i].n);
                    distributionsList[i] = distrib;
                    for (int j = 0; j < Int32.Parse(tbN.Text); j++)
                    {
                        polyY[j] += distrib.Points[j].Y;
                        polyX[j] += distrib.Points[j].X;
                    }
                }

                CompAndDraw();
            }

        }

        private void DistributionRedrawF(float f)
        {
            Distribution distrib;
            for (int i = 0; i < distributionsList.Count; i++)
            {
                if (distributionTypes[i] == DistributionType.Saw)
                {
                    distrib = new Sawtooth(distributionsList[i].a, f, distributionsList[i].fi0, distributionsList[i].n);
                    distributionsList[i] = distrib;
                    for (int j = 0; j < Int32.Parse(tbN.Text); j++)
                    {
                        polyY[j] += distrib.Points[j].Y;
                        polyX[j] += distrib.Points[j].X;
                    }
                }
                else if (distributionTypes[i] == DistributionType.Cos)
                {
                    distrib = new Cos(distributionsList[i].a, f, distributionsList[i].fi0, distributionsList[i].n);
                    distributionsList[i] = distrib;
                    for (int j = 0; j < Int32.Parse(tbN.Text); j++)
                    {
                        polyY[j] += distrib.Points[j].Y;
                        polyX[j] += distrib.Points[j].X;
                    }

                }
                else if (distributionTypes[i] == DistributionType.Sin)
                {
                    distrib = new Sin(distributionsList[i].a, f, distributionsList[i].fi0, distributionsList[i].n);
                    distributionsList[i] = distrib;
                    for (int j = 0; j < Int32.Parse(tbN.Text); j++)
                    {
                        polyY[j] += distrib.Points[j].Y;
                        polyX[j] += distrib.Points[j].X;
                    }

                }
                else if (distributionTypes[i] == DistributionType.Trian)
                {
                    distrib = new Trian(distributionsList[i].a, f, distributionsList[i].fi0, distributionsList[i].n);
                    distributionsList[i] = distrib;
                    for (int j = 0; j < Int32.Parse(tbN.Text); j++)
                    {
                        polyY[j] += distrib.Points[j].Y;
                        polyX[j] += distrib.Points[j].X;
                    }
                }
                else if (distributionTypes[i] == DistributionType.Pulse)
                {
                    distrib = new Pulse(distributionsList[i].a, f, distributionsList[i].fi0, distributionsList[i].n);
                    distributionsList[i] = distrib;
                    for (int j = 0; j < Int32.Parse(tbN.Text); j++)
                    {
                        polyY[j] += distrib.Points[j].Y;
                        polyX[j] += distrib.Points[j].X;
                    }
                }

                CompAndDraw();
            }

        }
        private void DistributionRedrawFi0(float fi0)
        {
            Distribution distrib;
            for (int i = 0; i < distributionsList.Count; i++)
            {
                if (distributionTypes[i] == DistributionType.Saw)
                {
                    distrib = new Sawtooth(distributionsList[i].a, distributionsList[i].f, fi0, distributionsList[i].n);
                    distributionsList[i] = distrib;
                    for (int j = 0; j < Int32.Parse(tbN.Text); j++)
                    {
                        polyY[j] += distrib.Points[j].Y;
                        polyX[j] += distrib.Points[j].X;
                    }
                }
                else if (distributionTypes[i] == DistributionType.Cos)
                {
                    distrib = new Cos(distributionsList[i].a, distributionsList[i].f, fi0, distributionsList[i].n);
                    distributionsList[i] = distrib;
                    for (int j = 0; j < Int32.Parse(tbN.Text); j++)
                    {
                        polyY[j] += distrib.Points[j].Y;
                        polyX[j] += distrib.Points[j].X;
                    }

                }
                else if (distributionTypes[i] == DistributionType.Sin)
                {
                    distrib = new Sin(distributionsList[i].a, distributionsList[i].f, fi0, distributionsList[i].n);
                    distributionsList[i] = distrib;
                    for (int j = 0; j < Int32.Parse(tbN.Text); j++)
                    {
                        polyY[j] += distrib.Points[j].Y;
                        polyX[j] += distrib.Points[j].X;
                    }

                }
                else if (distributionTypes[i] == DistributionType.Trian)
                {
                    distrib = new Trian(distributionsList[i].a, distributionsList[i].f, fi0, distributionsList[i].n);
                    distributionsList[i] = distrib;
                    for (int j = 0; j < Int32.Parse(tbN.Text); j++)
                    {
                        polyY[j] += distrib.Points[j].Y;
                        polyX[j] += distrib.Points[j].X;
                    }
                }
                else if (distributionTypes[i] == DistributionType.Pulse)
                {
                    distrib = new Pulse(distributionsList[i].a, distributionsList[i].f, fi0, distributionsList[i].n);
                    distributionsList[i] = distrib;
                    for (int j = 0; j < Int32.Parse(tbN.Text); j++)
                    {
                        polyY[j] += distrib.Points[j].Y;
                        polyX[j] += distrib.Points[j].X;
                    }
                }

                CompAndDraw();
            }

        }


        private void CompAndDraw()
        {
            chDist.Series[0].Points.Clear();
            chDist.Series[1].Points.Clear();
            //chDist.Series[2].Points.Clear();
            chAmp.Series[0].Points.Clear();
            chPha.Series[0].Points.Clear();
            chFlower.Series[0].Points.Clear();

            SinSpectrum = SpectrumMath.SinSpectrum(polyY, Int32.Parse(tbK.Text), Int32.Parse(tbN.Text));
            CosSpectrum = SpectrumMath.CosSpectrum(polyY, Int32.Parse(tbK.Text), Int32.Parse(tbN.Text));
            AmplitudeSpectrum = SpectrumMath.AmplitudeSpectrum(Int32.Parse(tbK.Text), SinSpectrum, CosSpectrum);
            PhaseSpectrum = SpectrumMath.PhaseSpectrum(Int32.Parse(tbK.Text), SinSpectrum, CosSpectrum);
            restoredY = SpectrumMath.RestoredSignal(Int32.Parse(tbK.Text), Int32.Parse(tbN.Text), AmplitudeSpectrum, PhaseSpectrum);


            for (int i = 0; i < Int32.Parse(tbN.Text); i++)
            {
                chDist.Series[0].Points.AddXY(polyX[i], polyY[i]);
                chDist.Series[1].Points.AddXY(polyX[i], restoredY[i]);
            }

            for (int i = 0; i < AmplitudeSpectrum.Length; i++)
            {
                chAmp.Series[0].Points.AddXY(i, AmplitudeSpectrum[i]);
                chPha.Series[0].Points.AddXY(i, PhaseSpectrum[i]);
                //chFlower.Series[0].Points.AddXY(CosSpectrum[i], SinSpectrum[i]);
            }
        }

        private void chDist_DoubleClick(object sender, EventArgs e)
        {
            Form2 frm = new Form2();
            frm.Show();
        }
    }
}
