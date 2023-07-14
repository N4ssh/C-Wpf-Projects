using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Linear_Algebra_Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9\\-]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void Find_Determinant1_Click(object sender, RoutedEventArgs e)
        {
            int det = 0;

            int[,] arr1 = new int[3, 3];

            if (Determinant1_11.Text != "" && Determinant1_12.Text != "" && Determinant1_13.Text != "" && Determinant1_21.Text != "" && Determinant1_22.Text != "" && Determinant1_23.Text != "" && Determinant1_31.Text != "" && Determinant1_31.Text != "" && Determinant1_33.Text != "")
            {
                arr1[0, 0] = int.Parse(Determinant1_11.Text);
                arr1[0, 1] = int.Parse(Determinant1_12.Text);
                arr1[0, 2] = int.Parse(Determinant1_13.Text);
                arr1[1, 0] = int.Parse(Determinant1_21.Text);
                arr1[1, 1] = int.Parse(Determinant1_22.Text);
                arr1[1, 2] = int.Parse(Determinant1_23.Text);
                arr1[2, 0] = int.Parse(Determinant1_31.Text);
                arr1[2, 1] = int.Parse(Determinant1_32.Text);
                arr1[2, 2] = int.Parse(Determinant1_33.Text);

                for (int i = 0; i < 3; i++)
                {
                    det = det + (arr1[0, i] * (arr1[1, (i + 1) % 3] * arr1[2, (i + 2) % 3] - arr1[1, (i + 2) % 3] * arr1[2, (i + 1) % 3]));
                }

                Determinant1_Answer.Text = det.ToString();
            }
            else
            {
                MessageBox.Show("Please fill all the boxes!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
        }

        private void Find_Determinant2_Click(object sender, RoutedEventArgs e)
        {
            int det;

            if (Determinant2_11.Text != "" && Determinant2_12.Text != "" && Determinant2_21.Text != "" && Determinant2_22.Text != "")
            {
                det = int.Parse(Determinant2_11.Text) * int.Parse(Determinant2_22.Text) - int.Parse(Determinant2_12.Text) * int.Parse(Determinant2_21.Text);
                Determinant2_Answer.Text = det.ToString();
            }
            else
            {
                MessageBox.Show("Please fill all the boxes!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
        }

        private void Find_Inverse1_Click(object sender, RoutedEventArgs e)
        {
            int det = 0;

            int[,] arr1 = new int[3, 3];
            int[,] arr2 = new int[3, 3];

            if (Matrix1_11.Text != "" && Matrix1_12.Text != "" && Matrix1_13.Text != "" && Matrix1_21.Text != "" && Matrix1_22.Text != "" && Matrix1_23.Text != "" && Matrix1_31.Text != "" && Matrix1_31.Text != "" && Matrix1_33.Text != "")
            {
                arr1[0, 0] = int.Parse(Matrix1_11.Text);
                arr1[0, 1] = int.Parse(Matrix1_12.Text);
                arr1[0, 2] = int.Parse(Matrix1_13.Text);
                arr1[1, 0] = int.Parse(Matrix1_21.Text);
                arr1[1, 1] = int.Parse(Matrix1_22.Text);
                arr1[1, 2] = int.Parse(Matrix1_23.Text);
                arr1[2, 0] = int.Parse(Matrix1_31.Text);
                arr1[2, 1] = int.Parse(Matrix1_32.Text);
                arr1[2, 2] = int.Parse(Matrix1_33.Text);

                for (int i = 0; i < 3; i++)
                {
                    det = det + (arr1[0, i] * (arr1[1, (i + 1) % 3] * arr1[2, (i + 2) % 3] - arr1[1, (i + 2) % 3] * arr1[2, (i + 1) % 3]));
                }

                if (det == 0)
                {
                    MessageBox.Show("The determinant is 0 therefore A is not invertible!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                else
                {
                    arr2[0, 0] = arr1[1, 1] * arr1[2, 2] - arr1[1, 2] * arr1[2, 1];
                    arr2[0, 1] = arr1[0, 2] * arr1[2, 1] - arr1[0, 1] * arr1[2, 2];
                    arr2[0, 2] = arr1[0, 1] * arr1[1, 2] - arr1[0, 2] * arr1[1, 1];
                    arr2[1, 0] = arr1[1, 2] * arr1[2, 0] - arr1[1, 0] * arr1[2, 2];
                    arr2[1, 1] = arr1[0, 0] * arr1[2, 2] - arr1[0, 2] * arr1[2, 0];
                    arr2[1, 2] = arr1[0, 2] * arr1[1, 0] - arr1[0, 0] * arr1[1, 2];
                    arr2[2, 0] = arr1[1, 0] * arr1[2, 1] - arr1[1, 1] * arr1[2, 0];
                    arr2[2, 1] = arr1[0, 1] * arr1[2, 0] - arr1[0, 0] * arr1[2, 1];
                    arr2[2, 2] = arr1[0, 0] * arr1[1, 1] - arr1[0, 1] * arr1[1, 0];
                }

                Inverse1_11.Text = ReduceFraction(arr2[0, 0], det);
                Inverse1_12.Text = ReduceFraction(arr2[0, 1], det);
                Inverse1_13.Text = ReduceFraction(arr2[0, 2], det);
                Inverse1_21.Text = ReduceFraction(arr2[1, 0], det);
                Inverse1_22.Text = ReduceFraction(arr2[1, 1], det);
                Inverse1_23.Text = ReduceFraction(arr2[1, 2], det);
                Inverse1_31.Text = ReduceFraction(arr2[2, 0], det);
                Inverse1_32.Text = ReduceFraction(arr2[2, 1], det);
                Inverse1_33.Text = ReduceFraction(arr2[2, 2], det);
            }
            else
            {
                MessageBox.Show("Please fill all the boxes!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
        }


        private string ReduceFraction(int x, int y)
        {
            int d;
            d = GCD(x, y);

            x = x / d;
            y = y / d;

            if (x % y == 0)
            {
                return (x / y).ToString();
            }
            else
            {
                return x.ToString() + "/" + y.ToString();
            }
        }

        private int GCD(int a, int b)
        {
            if (b == 0)
                return a;
            return GCD(b, a % b);
        }

        private void Find_Inverse2_Click(object sender, RoutedEventArgs e)
        {
            int det = 0;

            int[,] arr1 = new int[2, 2];
            int[,] arr2 = new int[2, 2];

            if (Matrix2_11.Text != "" && Matrix2_12.Text != "" && Matrix2_21.Text != "" && Matrix2_22.Text != "")
            {
                det = int.Parse(Matrix2_11.Text) * int.Parse(Matrix2_22.Text) - int.Parse(Matrix2_12.Text) * int.Parse(Matrix2_21.Text);

                if (det == 0)
                {
                    MessageBox.Show("The determinant is 0 therefore B is not invertible!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                else
                {
                    arr1[0, 0] = int.Parse(Matrix2_11.Text);
                    arr1[0, 1] = int.Parse(Matrix2_12.Text);
                    arr1[1, 0] = int.Parse(Matrix2_21.Text);
                    arr1[1, 1] = int.Parse(Matrix2_22.Text);

                    arr2[0, 0] = arr1[1, 1];
                    arr2[0, 1] = 0 - arr1[0, 1];
                    arr2[1, 0] = 0 - arr1[1, 0];
                    arr2[1, 1] = arr1[0, 0];

                    Inverse2_11.Text = ReduceFraction(arr2[0, 0], det);
                    Inverse2_12.Text = ReduceFraction(arr2[0, 1], det);
                    Inverse2_21.Text = ReduceFraction(arr2[1, 0], det);
                    Inverse2_22.Text = ReduceFraction(arr2[1, 1], det);
                }
            }
            else
            {
                MessageBox.Show("Please fill all the boxes!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
        }

        private void Transformation1_Click(object sender, RoutedEventArgs e)
        {
            if (Transformation1_11.Text != "" && Transformation1_12.Text != "" && Transformation1_13.Text != "" && Transformation1_21.Text != "" && Transformation1_22.Text != "" && Transformation1_23.Text != "" && Transformation1_31.Text != "" && Transformation1_32.Text != "" && Transformation1_33.Text != "" && Vector1_1.Text != "" && Vector1_2.Text != "" && Vector1_3.Text != "")
            {
                int[,] arr1 = new int[3, 3];

                arr1[0, 0] = int.Parse(Transformation1_11.Text);
                arr1[0, 1] = int.Parse(Transformation1_12.Text);
                arr1[0, 2] = int.Parse(Transformation1_13.Text);
                arr1[1, 0] = int.Parse(Transformation1_21.Text);
                arr1[1, 1] = int.Parse(Transformation1_22.Text);
                arr1[1, 2] = int.Parse(Transformation1_23.Text);
                arr1[2, 0] = int.Parse(Transformation1_31.Text);
                arr1[2, 1] = int.Parse(Transformation1_32.Text);
                arr1[2, 2] = int.Parse(Transformation1_33.Text);

                Vector2_1.Text = (arr1[0, 0] * int.Parse(Vector1_1.Text) + arr1[0, 1] * int.Parse(Vector1_2.Text) + arr1[0, 2] * int.Parse(Vector1_3.Text)).ToString();
                Vector2_2.Text = (arr1[1, 0] * int.Parse(Vector1_1.Text) + arr1[1, 1] * int.Parse(Vector1_2.Text) + arr1[1, 2] * int.Parse(Vector1_3.Text)).ToString();
                Vector2_3.Text = (arr1[2, 0] * int.Parse(Vector1_1.Text) + arr1[2, 1] * int.Parse(Vector1_2.Text) + arr1[2, 2] * int.Parse(Vector1_3.Text)).ToString();
            }
            else
            {
                MessageBox.Show("Please fill all the boxes!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
        }

        private void Transformation2_Click(object sender, RoutedEventArgs e)
        {
            if (Transformation2_11.Text != "" && Transformation2_12.Text != "" && Transformation2_21.Text != "" && Transformation2_22.Text != "" && Vector3_1.Text != "" && Vector3_2.Text != "")
            {
                int[,] arr1 = new int[2, 2];

                arr1[0, 0] = int.Parse(Transformation2_11.Text);
                arr1[0, 1] = int.Parse(Transformation2_12.Text);
                arr1[1, 0] = int.Parse(Transformation2_21.Text);
                arr1[1, 1] = int.Parse(Transformation2_22.Text);

                Vector4_1.Text = (arr1[0, 0] * int.Parse(Vector3_1.Text) + arr1[0, 1] * int.Parse(Vector3_2.Text)).ToString();
                Vector4_2.Text = (arr1[1, 0] * int.Parse(Vector3_1.Text) + arr1[1, 1] * int.Parse(Vector3_2.Text)).ToString();
            }
            else
            {
                MessageBox.Show("Please fill all the boxes!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

        }

        private void CrossProduct_Click(object sender, RoutedEventArgs e)
        {
            if (Cross1_1.Text != "" && Cross1_2.Text != "" && Cross1_3.Text != "" && Cross2_1.Text != "" && Cross2_2.Text != "" && Cross2_3.Text != "")
            {
                NormalVector_1.Text = (int.Parse(Cross1_2.Text) * int.Parse(Cross2_3.Text) - int.Parse(Cross1_3.Text) * int.Parse(Cross2_2.Text)).ToString();
                NormalVector_2.Text = (int.Parse(Cross1_3.Text) * int.Parse(Cross2_1.Text) - int.Parse(Cross1_1.Text) * int.Parse(Cross2_3.Text)).ToString();
                NormalVector_3.Text = (int.Parse(Cross1_1.Text) * int.Parse(Cross2_2.Text) - int.Parse(Cross1_2.Text) * int.Parse(Cross2_1.Text)).ToString();
            }
            else
            {
                MessageBox.Show("Please fill all the boxes!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
        }

        private void Magnitude1_Click(object sender, RoutedEventArgs e)
        {
            if (Magnitude1_1.Text != "" && Magnitude1_2.Text != "" && Magnitude1_3.Text != "")
            {
                Magnitude1_lenght.Text = "√" + (int.Parse(Magnitude1_1.Text) * int.Parse(Magnitude1_1.Text) + int.Parse(Magnitude1_2.Text) * int.Parse(Magnitude1_2.Text) + int.Parse(Magnitude1_3.Text) * int.Parse(Magnitude1_3.Text)).ToString();
            }
            else
            {
                MessageBox.Show("Please fill all the boxes!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
        }

        private void Magnitude2_Click(object sender, RoutedEventArgs e)
        {
            if (Magnitude2_1.Text != "" && Magnitude2_2.Text != "")
            {
                Magnitude2_lenght.Text = "√" + (int.Parse(Magnitude2_1.Text) * int.Parse(Magnitude2_1.Text) + int.Parse(Magnitude2_2.Text) * int.Parse(Magnitude2_2.Text)).ToString();
            }
            else
            {
                MessageBox.Show("Please fill all the boxes!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
        }

        private void Eigenvalues1_Click(object sender, RoutedEventArgs e)
        {
            int det = 0;
            int trace = 0;
            double eig1, eig2;
            int[,] arr1 = new int[2, 2];

            if (Eigenvalue_Matrix_11.Text != "" && Eigenvalue_Matrix_12.Text != "" && Eigenvalue_Matrix_21.Text != "" && Eigenvalue_Matrix_22.Text != "")
            {
                arr1[0, 0] = int.Parse(Eigenvalue_Matrix_11.Text);
                arr1[0, 1] = int.Parse(Eigenvalue_Matrix_12.Text);
                arr1[1, 0] = int.Parse(Eigenvalue_Matrix_21.Text);
                arr1[1, 1] = int.Parse(Eigenvalue_Matrix_22.Text);

                trace = arr1[0, 0] + arr1[1, 1];
                det = int.Parse(Eigenvalue_Matrix_11.Text) * int.Parse(Eigenvalue_Matrix_22.Text) - int.Parse(Eigenvalue_Matrix_12.Text) * int.Parse(Eigenvalue_Matrix_21.Text);

                eig1 = (trace + Math.Sqrt(trace * trace - 4 * det)) / 2;
                Eigenvalue1.Text = eig1.ToString();
                eig2 = (trace - Math.Sqrt(trace * trace - 4 * det)) / 2;
                Eigenvalue2.Text = eig2.ToString();
            }
            else
            {
                MessageBox.Show("Please fill all the boxes!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
        }

        private void Find_Trace1_Click(object sender, RoutedEventArgs e)
        {
            if (Trace1_11.Text != "" && Trace1_12.Text != "" && Trace1_13.Text != "" && Trace1_21.Text != "" && Trace1_22.Text != "" && Trace1_23.Text != "" && Trace1_31.Text != "" && Trace1_32.Text != "" && Trace1_33.Text != "")
            {
                int trace = int.Parse(Trace1_11.Text) + int.Parse(Trace1_22.Text) + int.Parse(Trace1_33.Text);
                Trace1_Answer.Text = trace.ToString();
            }
            else
            {
                MessageBox.Show("Please fill all the boxes!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
        }

        private void Find_Trace2_Click(object sender, RoutedEventArgs e)
        {
            if (Trace2_11.Text != "" && Trace2_12.Text != "" && Trace2_21.Text != "" && Trace2_22.Text != "")
            {
                int trace = int.Parse(Trace2_11.Text) + int.Parse(Trace2_22.Text);
                Trace2_Answer.Text = trace.ToString();
            }
            else
            {
                MessageBox.Show("Please fill all the boxes!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
        }

        private void Find_Transpose1_Click(object sender, RoutedEventArgs e)
        {

            int[,] arr1 = new int[3, 3];

            if (Matrix3_11.Text != "" && Matrix3_12.Text != "" && Matrix3_13.Text != "" && Matrix3_21.Text != "" && Matrix3_22.Text != "" && Matrix3_23.Text != "" && Matrix3_31.Text != "" && Matrix3_31.Text != "" && Matrix3_33.Text != "")
            {
                arr1[0, 0] = int.Parse(Matrix3_11.Text);
                arr1[0, 1] = int.Parse(Matrix3_12.Text);
                arr1[0, 2] = int.Parse(Matrix3_13.Text);
                arr1[1, 0] = int.Parse(Matrix3_21.Text);
                arr1[1, 1] = int.Parse(Matrix3_22.Text);
                arr1[1, 2] = int.Parse(Matrix3_23.Text);
                arr1[2, 0] = int.Parse(Matrix3_31.Text);
                arr1[2, 1] = int.Parse(Matrix3_32.Text);
                arr1[2, 2] = int.Parse(Matrix3_33.Text);

                Transpose1_11.Text = arr1[0, 0].ToString();
                Transpose1_12.Text = arr1[1, 0].ToString();
                Transpose1_13.Text = arr1[2, 0].ToString();
                Transpose1_21.Text = arr1[0, 1].ToString();
                Transpose1_22.Text = arr1[1, 1].ToString();
                Transpose1_23.Text = arr1[2, 1].ToString();
                Transpose1_31.Text = arr1[0, 2].ToString();
                Transpose1_32.Text = arr1[1, 2].ToString();
                Transpose1_33.Text = arr1[2, 2].ToString();

            }
            else
            {
                MessageBox.Show("Please fill all the boxes!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
        }

        private void Find_Transpose2_Click(object sender, RoutedEventArgs e)
        {

            int[,] arr1 = new int[2, 2];

            if (Matrix4_11.Text != "" && Matrix4_12.Text != "" && Matrix4_21.Text != "" && Matrix4_22.Text != "")
            {
                arr1[0, 0] = int.Parse(Matrix4_11.Text);
                arr1[0, 1] = int.Parse(Matrix4_12.Text);
                arr1[1, 0] = int.Parse(Matrix4_21.Text);
                arr1[1, 1] = int.Parse(Matrix4_22.Text);

                Transpose2_11.Text = arr1[0, 0].ToString();
                Transpose2_12.Text = arr1[1, 0].ToString();
                Transpose2_21.Text = arr1[0, 1].ToString();
                Transpose2_22.Text = arr1[1, 1].ToString();

            }
            else
            {
                MessageBox.Show("Please fill all the boxes!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
        }
    }
}
