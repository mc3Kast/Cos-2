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

namespace Cos_2
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            chart1.Series[0] = Program.f1.chDist.Series[0];
            chart1.Series[1] = Program.f1.chDist.Series[1];
            chart1.Series[2] = Program.f1.chDist.Series[2];

        }
    }
}
