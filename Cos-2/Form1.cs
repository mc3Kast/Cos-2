using Cos_2.Lib;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Cos_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            distributionTypes = new List<DistributionType>();
            distributionsList = new List<Distribution>();
            chAmp.MouseWheel += ch_MouseWheel;
            chPha.MouseWheel += ch_MouseWheel;
        }

        public double[] SinSpectrum { get; set; }
        public double[] CosSpectrum { get; set; }
        public double[] AmplitudeSpectrum { get; set; }
        public double[] PhaseSpectrum { get; set; }

        public double[] polyY;
        public double[] polyX;
        public double[] restoredY;

        public List<DistributionType> distributionTypes;
        public List<Distribution> distributionsList;

        private void btAdd_Click(object sender, EventArgs e)
        {
            restoredY = new double[Int32.Parse(tbN.Text)];
            Distribution distribution = new Cos(1, 1, 0, 128);

            if (rbCos.Checked)
            {
                distribution = new Cos(float.Parse(tbA.Text), float.Parse(tbF.Text), float.Parse(tbFi0.Text), Int32.Parse(tbN.Text));
                for (int i = 0; i < Int32.Parse(tbN.Text); i++)
                {
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
                    polyY[i] += distribution.Points[i].Y;
                    polyX[i] += distribution.Points[i].X;
                }
                distributionTypes.Add(DistributionType.Saw);
                distributionsList.Add(distribution);
            }

            CompAndDraw();
        }

        private void btClear_Click(object sender, EventArgs e)
        {
            chDist.Series[0].Points.Clear();
            chDist.Series[1].Points.Clear();
            chAmp.Series[0].Points.Clear();
            chPha.Series[0].Points.Clear();

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
            int i = 0;
            foreach (Distribution dist in distributionsList)
            {
                if (distributionTypes[i] == DistributionType.Saw)
                {
                    distrib = new Sawtooth(dist.a, dist.f, dist.fi0, Int32.Parse(tbN.Text));
                    for (int j = 0; j < Int32.Parse(tbN.Text); j++)
                    {
                        polyY[j] += distrib.Points[j].Y;
                        polyX[j] += distrib.Points[j].X;
                    }
                }
                else if (distributionTypes[i] == DistributionType.Cos)
                {
                    distrib = new Cos(dist.a, dist.f, dist.fi0, Int32.Parse(tbN.Text));
                    for (int j = 0; j < Int32.Parse(tbN.Text); j++)
                    {
                        polyY[j] += distrib.Points[j].Y;
                        polyX[j] += distrib.Points[j].X;
                    }

                }
                else if (distributionTypes[i] == DistributionType.Sin)
                {
                    distrib = new Sin(dist.a, dist.f, dist.fi0, Int32.Parse(tbN.Text));
                    for (int j = 0; j < Int32.Parse(tbN.Text); j++)
                    {
                        polyY[j] += distrib.Points[j].Y;
                        polyX[j] += distrib.Points[j].X;
                    }

                }
                else if (distributionTypes[i] == DistributionType.Trian)
                {
                    distrib = new Trian(dist.a, dist.f, dist.fi0, Int32.Parse(tbN.Text));
                    for (int j = 0; j < Int32.Parse(tbN.Text); j++)
                    {
                        polyY[j] += distrib.Points[j].Y;
                        polyX[j] += distrib.Points[j].X;
                    }
                }
                else if (distributionTypes[i] == DistributionType.Pulse)
                {
                    distrib = new Pulse(dist.a, dist.f, dist.fi0, Int32.Parse(tbN.Text));
                    for (int j = 0; j < Int32.Parse(tbN.Text); j++)
                    {
                        polyY[j] += distrib.Points[j].Y;
                        polyX[j] += distrib.Points[j].X;
                    }
                }

                CompAndDraw();
                i++;
            }

        }

        private void DistributionRedrawA(float a)
        {
            Distribution distrib;
            int i = 0;
            foreach (Distribution dist in distributionsList)
            {
                if (distributionTypes[i] == DistributionType.Saw)
                {
                    distrib = new Sawtooth(a, dist.f, dist.fi0, dist.n);
                    for (int j = 0; j < Int32.Parse(tbN.Text); j++)
                    {
                        polyY[j] += distrib.Points[j].Y;
                        polyX[j] += distrib.Points[j].X;
                    }
                }
                else if (distributionTypes[i] == DistributionType.Cos)
                {
                    distrib = new Cos(a, dist.f, dist.fi0, dist.n);
                    for (int j = 0; j < Int32.Parse(tbN.Text); j++)
                    {
                        polyY[j] += distrib.Points[j].Y;
                        polyX[j] += distrib.Points[j].X;
                    }

                }
                else if (distributionTypes[i] == DistributionType.Sin)
                {
                    distrib = new Sin(a, dist.f, dist.fi0, dist.n);
                    for (int j = 0; j < Int32.Parse(tbN.Text); j++)
                    {
                        polyY[j] += distrib.Points[j].Y;
                        polyX[j] += distrib.Points[j].X;
                    }

                }
                else if (distributionTypes[i] == DistributionType.Trian)
                {
                    distrib = new Trian(a, dist.f, dist.fi0, dist.n);
                    for (int j = 0; j < Int32.Parse(tbN.Text); j++)
                    {
                        polyY[j] += distrib.Points[j].Y;
                        polyX[j] += distrib.Points[j].X;
                    }
                }
                else if (distributionTypes[i] == DistributionType.Pulse)
                {
                    distrib = new Pulse(a, dist.f, dist.fi0, dist.n);
                    for (int j = 0; j < Int32.Parse(tbN.Text); j++)
                    {
                        polyY[j] += distrib.Points[j].Y;
                        polyX[j] += distrib.Points[j].X;
                    }
                }

                CompAndDraw();
                i++;
            }

        }

        private void DistributionRedrawF(float f)
        {
            Distribution distrib;
            int i = 0;
            foreach (Distribution dist in distributionsList)
            {
                if (distributionTypes[i] == DistributionType.Saw)
                {
                    distrib = new Sawtooth(dist.a, f, dist.fi0, dist.n);
                    for (int j = 0; j < Int32.Parse(tbN.Text); j++)
                    {
                        polyY[j] += distrib.Points[j].Y;
                        polyX[j] += distrib.Points[j].X;
                    }
                }
                else if (distributionTypes[i] == DistributionType.Cos)
                {
                    distrib = new Cos(dist.a, f, dist.fi0, dist.n);
                    for (int j = 0; j < Int32.Parse(tbN.Text); j++)
                    {
                        polyY[j] += distrib.Points[j].Y;
                        polyX[j] += distrib.Points[j].X;
                    }

                }
                else if (distributionTypes[i] == DistributionType.Sin)
                {
                    distrib = new Sin(dist.a, f, dist.fi0, dist.n);
                    for (int j = 0; j < Int32.Parse(tbN.Text); j++)
                    {
                        polyY[j] += distrib.Points[j].Y;
                        polyX[j] += distrib.Points[j].X;
                    }

                }
                else if (distributionTypes[i] == DistributionType.Trian)
                {
                    distrib = new Trian(dist.a, f, dist.fi0, dist.n);
                    for (int j = 0; j < Int32.Parse(tbN.Text); j++)
                    {
                        polyY[j] += distrib.Points[j].Y;
                        polyX[j] += distrib.Points[j].X;
                    }
                }
                else if (distributionTypes[i] == DistributionType.Pulse)
                {
                    distrib = new Pulse(dist.a, f, dist.fi0, dist.n);
                    for (int j = 0; j < Int32.Parse(tbN.Text); j++)
                    {
                        polyY[j] += distrib.Points[j].Y;
                        polyX[j] += distrib.Points[j].X;
                    }
                }

                CompAndDraw();
                i++;
            }

        }
        private void DistributionRedrawFi0(float fi0)
        {
            Distribution distrib;
            int i = 0;
            foreach (Distribution dist in distributionsList)
            {
                if (distributionTypes[i] == DistributionType.Saw)
                {
                    distrib = new Sawtooth(dist.a, dist.f, fi0, dist.n);
                    for (int j = 0; j < Int32.Parse(tbN.Text); j++)
                    {
                        polyY[j] += distrib.Points[j].Y;
                        polyX[j] += distrib.Points[j].X;
                    }
                }
                else if (distributionTypes[i] == DistributionType.Cos)
                {
                    distrib = new Cos(dist.a, dist.f, fi0, dist.n);
                    for (int j = 0; j < Int32.Parse(tbN.Text); j++)
                    {
                        polyY[j] += distrib.Points[j].Y;
                        polyX[j] += distrib.Points[j].X;
                    }

                }
                else if (distributionTypes[i] == DistributionType.Sin)
                {
                    distrib = new Sin(dist.a, dist.f, fi0, dist.n);
                    for (int j = 0; j < Int32.Parse(tbN.Text); j++)
                    {
                        polyY[j] += distrib.Points[j].Y;
                        polyX[j] += distrib.Points[j].X;
                    }

                }
                else if (distributionTypes[i] == DistributionType.Trian)
                {
                    distrib = new Trian(dist.a, dist.f, fi0, dist.n);
                    for (int j = 0; j < Int32.Parse(tbN.Text); j++)
                    {
                        polyY[j] += distrib.Points[j].Y;
                        polyX[j] += distrib.Points[j].X;
                    }
                }
                else if (distributionTypes[i] == DistributionType.Pulse)
                {
                    distrib = new Pulse(dist.a, dist.f, fi0, dist.n);
                    for (int j = 0; j < Int32.Parse(tbN.Text); j++)
                    {
                        polyY[j] += distrib.Points[j].Y;
                        polyX[j] += distrib.Points[j].X;
                    }
                }

                CompAndDraw();
                i++;
            }

        }


        private void CompAndDraw()
        {
            chDist.Series[0].Points.Clear();
            chDist.Series[1].Points.Clear();
            chAmp.Series[0].Points.Clear();
            chPha.Series[0].Points.Clear();

            SinSpectrum = SpectrumMath.SinSpectrum(polyY, Int32.Parse(tbK.Text));
            CosSpectrum = SpectrumMath.CosSpectrum(polyY, Int32.Parse(tbK.Text));
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
            }
        }
    }
}
