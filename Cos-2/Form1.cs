using Cos_2.Lib;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Cos_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public double[] SinSpectrum { get; set; }
        public double[] CosSpectrum { get; set; }
        public double[] AmplitudeSpectrum { get; set; }
        public double[] PhaseSpectrum { get; set; }


        private void btAdd_Click(object sender, EventArgs e)
        {
            chDist.Series[0].Points.Clear();
            chDist.Series[1].Points.Clear();
            chAmp.Series[0].Points.Clear();
            chPha.Series[0].Points.Clear();

            double[] polyY = new double[Int32.Parse(tbN.Text)];
            double[] polyX = new double[Int32.Parse(tbN.Text)];

            double[] restoredY = new double[Int32.Parse(tbN.Text)];
            Distribution distribution = new Cos(1, 1, 0, 128);

            if (rbCos.Checked)
            {
                distribution = new Cos(float.Parse(tbA.Text), float.Parse(tbF.Text), float.Parse(tbFi0.Text), Int32.Parse(tbN.Text));
                for (int i = 0; i < Int32.Parse(tbN.Text); i++)
                {
                    polyY[i] += distribution.Points[i].Y;
                    polyX[i] += distribution.Points[i].X;
                }

            }
            else if (rbSin.Checked)
            {
                distribution = new Sin(float.Parse(tbA.Text), float.Parse(tbF.Text), float.Parse(tbFi0.Text), Int32.Parse(tbN.Text));
                for (int i = 0; i < Int32.Parse(tbN.Text); i++)
                {
                    polyY[i] += distribution.Points[i].Y;
                    polyX[i] += distribution.Points[i].X;
                }

            }
            else if (rbPulse.Checked)
            {
                distribution = new Pulse(float.Parse(tbA.Text), float.Parse(tbF.Text), float.Parse(tbFi0.Text), Int32.Parse(tbN.Text));
                for (int i = 0; i < Int32.Parse(tbN.Text); i++)
                {
                    polyY[i] += distribution.Points[i].Y;
                    polyX[i] += distribution.Points[i].X;
                }
            }
            else if (rbTrian.Checked)
            {
                distribution = new Trian(float.Parse(tbA.Text), float.Parse(tbF.Text), float.Parse(tbFi0.Text), Int32.Parse(tbN.Text));
                for (int i = 0; i < Int32.Parse(tbN.Text); i++)
                {
                    polyY[i] += distribution.Points[i].Y;
                    polyX[i] += distribution.Points[i].X;
                }
            }
            else if (rbSaw.Checked)
            {
                distribution = new Sawtooth(float.Parse(tbA.Text), float.Parse(tbF.Text), float.Parse(tbFi0.Text), Int32.Parse(tbN.Text));
                for (int i = 0; i < Int32.Parse(tbN.Text); i++)
                {
                    polyY[i] += distribution.Points[i].Y;
                    polyX[i] += distribution.Points[i].X;
                }
            }

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

        private void btClear_Click(object sender, EventArgs e)
        {
            chDist.Series[0].Points.Clear();
            chDist.Series[1].Points.Clear();
            chAmp.Series[0].Points.Clear();
            chPha.Series[0].Points.Clear();
        }
    }
}
