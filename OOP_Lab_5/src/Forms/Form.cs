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
        private List<List<MaskedTextBox>> _matrix1;
        private List<List<MaskedTextBox>> _matrix2;
        private List<List<TextBox>> _res;

        public Form()
        {
            InitializeComponent();
            InitializeMatrixes();
        }

        private void InitializeMatrixes()
        {
            _matrix1 = new List<List<MaskedTextBox>>()
            {
                new List<MaskedTextBox>{ matrix100, matrix101, matrix102, matrix103, matrix104, matrix105 },
                new List<MaskedTextBox>{ matrix110, matrix111, matrix112, matrix113, matrix114, matrix115 },
                new List<MaskedTextBox>{ matrix120, matrix121, matrix122, matrix123, matrix124, matrix125 },
                new List<MaskedTextBox>{ matrix130, matrix131, matrix132, matrix133, matrix134, matrix135 },
                new List<MaskedTextBox>{ matrix140, matrix141, matrix142, matrix143, matrix144, matrix145 },
                new List<MaskedTextBox>{ matrix150, matrix151, matrix152, matrix153, matrix154, matrix155 },
            };

            _matrix2 = new List<List<MaskedTextBox>>()
            {
                new List<MaskedTextBox>{ matrix200, matrix201, matrix202, matrix203, matrix204, matrix205 },
                new List<MaskedTextBox>{ matrix210, matrix211, matrix212, matrix213, matrix214, matrix215 },
                new List<MaskedTextBox>{ matrix220, matrix221, matrix222, matrix223, matrix224, matrix225 },
                new List<MaskedTextBox>{ matrix230, matrix231, matrix232, matrix233, matrix234, matrix235 },
                new List<MaskedTextBox>{ matrix240, matrix241, matrix242, matrix243, matrix244, matrix245 },
                new List<MaskedTextBox>{ matrix250, matrix251, matrix252, matrix253, matrix254, matrix255 },
            };

            _res = new List<List<TextBox>>()
            {
                new List<TextBox>{ res00, res01, res02, res03, res04, res05 },
                new List<TextBox>{ res10, res11, res12, res13, res14, res15 },
                new List<TextBox>{ res20, res21, res22, res23, res24, res25 },
                new List<TextBox>{ res30, res31, res32, res33, res34, res35 },
                new List<TextBox>{ res40, res41, res42, res43, res44, res45 },
                new List<TextBox>{ res50, res51, res52, res53, res54, res55 },
            };
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

        private void HideMatrixes()
        {
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    _matrix1[i][j].Hide();
                    _matrix2[i][j].Hide();
                    _res[i][j].Hide();
                }
            }
        }

        private void ShowMatrixes(int k)
        {
            for (int i = 0; i < k; i++)
            {
                for (int j = 0; j < k; j++)
                {
                    _matrix1[i][j].Show();
                    _matrix2[i][j].Show();
                    _res[i][j].Show();
                }
            }
        }

        private void sizeBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            HideMatrixes();
            ShowMatrixes(((ComboBox)sender).SelectedIndex + 2);
        }
    }
}
