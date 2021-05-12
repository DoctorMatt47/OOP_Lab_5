using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOP_Lab_5
{
    public partial class Form : System.Windows.Forms.Form
    {
        private bool _mouseDown;
        private Point _lastLocation;

        public Form()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Form_MouseDown(object sender, MouseEventArgs e)
        {
            _mouseDown = true;
            _lastLocation = e.Location;
        }

        private void Form_MouseMove(object sender, MouseEventArgs e)
        {
            if (!_mouseDown) return;
            Location = new Point(
                (Location.X - _lastLocation.X) + e.X, (Location.Y - _lastLocation.Y) + e.Y);
            Update();
        }

        private void Form_MouseUp(object sender, MouseEventArgs e)
        {
            _mouseDown = false;
        }

        private void sizeList_SelectedIndexChanged(object sender, EventArgs e)
        {
            var index = sizeList.SelectedIndex;

        }
    }
}
