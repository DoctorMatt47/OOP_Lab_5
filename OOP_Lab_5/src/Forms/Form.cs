using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OOP_Lab_5;
using OOP_Lab_5.Facade;
using OOP_Lab_5.Core;
using OOP_Lab_5.Core.Algorithms;
using OOP_Lab_5.Core.Prototype;
using OOP_Lab_5.Decorators;

namespace OOP_Lab_5
{
    public partial class Form : System.Windows.Forms.Form
    {
        private bool _mouseDown;
        private Point _lastLocation;
        private List<List<MaskedTextBox>> _leftBoxes;
        private List<List<MaskedTextBox>> _rightBoxes;
        private List<List<TextBox>> _resultBoxes;
        private IMatrixFacade _left;
        private IMatrixFacade _right;
        private Matrix _result;
        private IPrototype _buffer;
        private int _size = 6;

        public Form()
        {
            InitializeComponent();
            InitializeMatrixes();
            _left = new TimeDecorator(new MatrixFacade(new Matrix(_size)));
            _right = new TimeDecorator(new MatrixFacade(new Matrix(_size)));
            _result = new Matrix(_size);
        }

        private void InitializeMatrixes()
        {
            _leftBoxes = new List<List<MaskedTextBox>>()
            {
                new List<MaskedTextBox>{ matrix100, matrix101, matrix102, matrix103, matrix104, matrix105 },
                new List<MaskedTextBox>{ matrix110, matrix111, matrix112, matrix113, matrix114, matrix115 },
                new List<MaskedTextBox>{ matrix120, matrix121, matrix122, matrix123, matrix124, matrix125 },
                new List<MaskedTextBox>{ matrix130, matrix131, matrix132, matrix133, matrix134, matrix135 },
                new List<MaskedTextBox>{ matrix140, matrix141, matrix142, matrix143, matrix144, matrix145 },
                new List<MaskedTextBox>{ matrix150, matrix151, matrix152, matrix153, matrix154, matrix155 },
            };

            _rightBoxes = new List<List<MaskedTextBox>>()
            {
                new List<MaskedTextBox>{ matrix200, matrix201, matrix202, matrix203, matrix204, matrix205 },
                new List<MaskedTextBox>{ matrix210, matrix211, matrix212, matrix213, matrix214, matrix215 },
                new List<MaskedTextBox>{ matrix220, matrix221, matrix222, matrix223, matrix224, matrix225 },
                new List<MaskedTextBox>{ matrix230, matrix231, matrix232, matrix233, matrix234, matrix235 },
                new List<MaskedTextBox>{ matrix240, matrix241, matrix242, matrix243, matrix244, matrix245 },
                new List<MaskedTextBox>{ matrix250, matrix251, matrix252, matrix253, matrix254, matrix255 },
            };

            _resultBoxes = new List<List<TextBox>>()
            {
                new List<TextBox>{ res00, res01, res02, res03, res04, res05 },
                new List<TextBox>{ res10, res11, res12, res13, res14, res15 },
                new List<TextBox>{ res20, res21, res22, res23, res24, res25 },
                new List<TextBox>{ res30, res31, res32, res33, res34, res35 },
                new List<TextBox>{ res40, res41, res42, res43, res44, res45 },
                new List<TextBox>{ res50, res51, res52, res53, res54, res55 },
            };
        }

        private void HideMatrixes()
        {
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    _leftBoxes[i][j].Text = "0";
                    _rightBoxes[i][j].Text = "0";
                    _resultBoxes[i][j].Text = "0";
                    _leftBoxes[i][j].Hide();
                    _rightBoxes[i][j].Hide();
                    _resultBoxes[i][j].Hide();
                }
            }
            detLabel.Text = "";
            rankLabel.Text = "";
            timeLabel.Text = "";
        }

        private void ShowMatrixes(int k)
        {
            _size = k;
            for (int i = 0; i < k; i++)
            {
                for (int j = 0; j < k; j++)
                {
                    _leftBoxes[i][j].Show();
                    _rightBoxes[i][j].Show();
                    _resultBoxes[i][j].Show();
                }
            }
            _left = new TimeDecorator(new MatrixFacade(new Matrix(_size)));
            _right = new TimeDecorator(new MatrixFacade(new Matrix(_size)));
            _result = new Matrix(_size);
        }

        private void RefreshBoxes(Matrix matrix, List<List<MaskedTextBox>> boxes)
        {
            for (int i = 0; i < _size; i++)
            {
                for (int j = 0; j < _size; j++)
                {
                    boxes[i][j].Text = matrix[i, j].ToString();
                }
            }
        }

        private void RefreshResultBoxes()
        {
            for (int i = 0; i < _size; i++)
            {
                for (int j = 0; j < _size; j++)
                {
                    _resultBoxes[i][j].Text = _result[i, j].ToString();
                }
            }
        }

        private void TakeBoxes(Matrix matrix, List<List<MaskedTextBox>> boxes)
        {
            for (int i = 0; i < _size; i++)
            {
                for (int j = 0; j < _size; j++)
                {
                    matrix[i, j] = Convert.ToInt64(boxes[i][j].Text != "" ? boxes[i][j].Text : null);
                }
            }
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

        private void sizeBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            HideMatrixes();
            ShowMatrixes(((ComboBox)sender).SelectedIndex + 2);
        }

        private void transposeButton_Click(object sender, EventArgs e)
        {
            TakeBoxes(_left.Matrix, _leftBoxes);
            _left.Transpose();
            RefreshBoxes(_left.Matrix, _leftBoxes);
            if (_left is TimeDecorator timeDecorator)
            {
                timeLabel.Text = timeDecorator.Time + " ms";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _left.Undo();
            RefreshBoxes(_left.Matrix, _leftBoxes);
            if (_left is TimeDecorator timeDecorator)
            {
                timeLabel.Text = timeDecorator.Time + " ms";
            }
        }

        private void inverseButton2_Click(object sender, EventArgs e)
        {
            TakeBoxes(_right.Matrix, _rightBoxes);
            _right.Transpose();
            RefreshBoxes(_right.Matrix, _rightBoxes);
            if (_right is TimeDecorator timeDecorator)
            {
                timeLabel.Text = timeDecorator.Time + " ms";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            _right.Undo();
            RefreshBoxes(_right.Matrix, _rightBoxes);
            if (_right is TimeDecorator timeDecorator)
            {
                timeLabel.Text = timeDecorator.Time + " ms";
            }
        }

        private void detButton_Click(object sender, EventArgs e)
        {
            TakeBoxes(_left.Matrix, _leftBoxes);
            IFindDeterminant algorithm = detBox1.SelectedIndex switch
            {
                0 => new NativeFindDeterminant(),
                1 => new LibraryFindDeterminant(),
                _ => null
            };
            detLabel.Text = _left.Determinant(algorithm).ToString();
            if (_left is TimeDecorator timeDecorator)
            {
                timeLabel.Text = timeDecorator.Time + " ms";
            }
        }

        private void detButton2_Click(object sender, EventArgs e)
        {
            TakeBoxes(_right.Matrix, _rightBoxes);
            IFindDeterminant algorithm = detBox2.SelectedIndex switch
            {
                0 => new NativeFindDeterminant(),
                1 => new LibraryFindDeterminant(),
                _ => null
            };
            detLabel.Text = _right.Determinant(algorithm).ToString();
            if (_right is TimeDecorator timeDecorator)
            {
                timeLabel.Text = timeDecorator.Time + " ms";
            };
        }

        private void squareButton_Click(object sender, EventArgs e)
        {
            TakeBoxes(_left.Matrix, _leftBoxes);
            IMultiply algorithm = squareBox1.SelectedIndex switch
            {
                0 => new NativeMultiply(),
                1 => new LibraryMultiply(),
                _ => null
            };
            _left.Square(algorithm);
            RefreshBoxes(_left.Matrix, _leftBoxes);
            if (_left is TimeDecorator timeDecorator)
            {
                timeLabel.Text = timeDecorator.Time + " ms";
            }
        }

        private void squareButton2_Click(object sender, EventArgs e)
        {
            TakeBoxes(_right.Matrix, _rightBoxes);
            IMultiply algorithm = squareBox2.SelectedIndex switch
            {
                0 => new NativeMultiply(),
                1 => new LibraryMultiply(),
                _ => null
            };
            _right.Square(algorithm);
            RefreshBoxes(_right.Matrix, _rightBoxes);
            if (_right is TimeDecorator timeDecorator)
            {
                timeLabel.Text = timeDecorator.Time + " ms";
            }
        }

        private void triangularButton1_Click(object sender, EventArgs e)
        {
            TakeBoxes(_left.Matrix, _leftBoxes);
            ITriangular algorithm = triangularBox1.SelectedIndex switch
            {
                0 => new NativeTriangular(),
                1 => new LibraryTriangular(),
                _ => null
            };
            _left.Triangular(algorithm);
            RefreshBoxes(_left.Matrix, _leftBoxes);
            if (_left is TimeDecorator timeDecorator)
            {
                timeLabel.Text = timeDecorator.Time + " ms";
            }
        }

        private void triangularButton2_Click(object sender, EventArgs e)
        {
            TakeBoxes(_right.Matrix, _rightBoxes);
            ITriangular algorithm = triangularBox2.SelectedIndex switch
            {
                0 => new NativeTriangular(),
                1 => new LibraryTriangular(),
                _ => null
            };
            _right.Triangular(algorithm);
            RefreshBoxes(_right.Matrix, _rightBoxes);
            if (_right is TimeDecorator timeDecorator)
            {
                timeLabel.Text = timeDecorator.Time + " ms";
            }
        }

        private void rankButton1_Click(object sender, EventArgs e)
        {
            TakeBoxes(_left.Matrix, _leftBoxes);
            IFindRank algorithm = rankBox1.SelectedIndex switch
            {
                0 => new NativeFindRank(),
                1 => new LibraryFindRank(),
                _ => null
            };
            rankLabel.Text = _left.Rank(algorithm).ToString();
            if (_left is TimeDecorator timeDecorator)
            {
                timeLabel.Text = timeDecorator.Time + " ms";
            }
        }

        private void rankButton2_Click(object sender, EventArgs e)
        {
            TakeBoxes(_right.Matrix, _rightBoxes);
            IFindRank algorithm = rankBox2.SelectedIndex switch
            {
                0 => new NativeFindRank(),
                1 => new LibraryFindRank(),
                _ => null
            };
            rankLabel.Text = _right.Rank(algorithm).ToString();
            if (_right is TimeDecorator timeDecorator)
            {
                timeLabel.Text = timeDecorator.Time + " ms";
            }
        }

        private void MultiplyOnButton1_Click(object sender, EventArgs e)
        {
            TakeBoxes(_left.Matrix, _leftBoxes);
            if (Int64.TryParse(multiplyOnBox1.Text, out long scalar))
            {
                _left.MultiplyOnScalar(scalar);
            }
            RefreshBoxes(_left.Matrix, _leftBoxes);
            if (_left is TimeDecorator timeDecorator)
            {
                timeLabel.Text = timeDecorator.Time + " ms";
            }
        }

        private void MultiplyOnButton2_Click(object sender, EventArgs e)
        {
            TakeBoxes(_right.Matrix, _rightBoxes);
            if (Int64.TryParse(multiplyOnBox2.Text, out long scalar))
            {
                _right.MultiplyOnScalar(scalar);
            }
            RefreshBoxes(_right.Matrix, _rightBoxes);
            if (_right is TimeDecorator timeDecorator)
            {
                timeLabel.Text = timeDecorator.Time + " ms";
            }
        }

        private void multiplyButton_Click(object sender, EventArgs e)
        {
            TakeBoxes(_left.Matrix, _leftBoxes);
            TakeBoxes(_right.Matrix, _rightBoxes);
            IMultiply algorithm = mulBox1.SelectedIndex switch
            {
                0 => new NativeMultiply(),
                1 => new LibraryMultiply(),
                _ => null
            };
            _result = _left.Multiply(_right.Matrix, algorithm);
            RefreshResultBoxes();
            if (_left is TimeDecorator timeDecorator)
            {
                timeLabel.Text = timeDecorator.Time + " ms";
            }
        }

        private void differenceButton_Click(object sender, EventArgs e)
        {
            TakeBoxes(_left.Matrix, _leftBoxes);
            TakeBoxes(_right.Matrix, _rightBoxes);
            _result = _left.Diff(_right.Matrix);
            RefreshResultBoxes();
            if (_left is TimeDecorator timeDecorator)
            {
                timeLabel.Text = timeDecorator.Time + " ms";
            }
        }

        private void additionButton_Click(object sender, EventArgs e)
        {
            TakeBoxes(_left.Matrix, _leftBoxes);
            TakeBoxes(_right.Matrix, _rightBoxes);
            _result = _left.Add(_right.Matrix);
            RefreshResultBoxes();
            if (_left is TimeDecorator timeDecorator)
            {
                timeLabel.Text = timeDecorator.Time + " ms";
            }
        }

        private void copyButton1_Click(object sender, EventArgs e)
        {
            TakeBoxes(_left.Matrix, _leftBoxes);
            _buffer = _left.Copy();
            if (_left is TimeDecorator timeDecorator)
            {
                timeLabel.Text = timeDecorator.Time + " ms";
            }
        }

        private void copyButton2_Click(object sender, EventArgs e)
        {
            TakeBoxes(_right.Matrix, _rightBoxes);
            _buffer = _right.Copy();
        }

        private void copyButton3_Click(object sender, EventArgs e)
        {
            _buffer = _result.Clone();
        }

        private void pasteButton1_Click(object sender, EventArgs e)
        {
            if (_buffer is null)
                return;
            _left.Paste(_buffer);
            RefreshBoxes(_left.Matrix, _leftBoxes);
        }

        private void pasteButton2_Click(object sender, EventArgs e)
        {
            if (_buffer is null)
                return;
            _right.Paste(_buffer);
            RefreshBoxes(_right.Matrix, _rightBoxes);
        }

        private void saveToDbButton1_Click(object sender, EventArgs e)
        {
            TakeBoxes(_left.Matrix, _leftBoxes);
            _left.SaveToDb(saveBox1.Text);
            if (_left is TimeDecorator timeDecorator)
            {
                timeLabel.Text = timeDecorator.Time + " ms";
            }
        }

        private void saveToDbButton2_Click(object sender, EventArgs e)
        {
            TakeBoxes(_right.Matrix, _rightBoxes);
            _right.SaveToDb(saveBox2.Text);
            if (_right is TimeDecorator timeDecorator)
            {
                timeLabel.Text = timeDecorator.Time + " ms";
            }
        }

        private void saveButton3_Click(object sender, EventArgs e)
        {
            var facade = new MatrixFacade(_result);
            facade.SaveToDb(saveBox3.Text);
        }

        private void loadFromDbButton1_Click(object sender, EventArgs e)
        {
            try
            {
                _left.LoadFromDb(loadBox1.Text);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            RefreshBoxes(_left.Matrix, _leftBoxes);
            if (_left is TimeDecorator timeDecorator)
            {
                timeLabel.Text = timeDecorator.Time + " ms";
            }
        }

        private void loadFromDbButton2_Click(object sender, EventArgs e)
        {
            try
            {
                _right.LoadFromDb(loadBox2.Text);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            RefreshBoxes(_right.Matrix, _rightBoxes);
            if (_right is TimeDecorator timeDecorator)
            {
                timeLabel.Text = timeDecorator.Time + " ms";
            }
        }
    }
}
