using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ZEncodeingV2
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

        #region Byte[] TO Hex
        public void ToHex(byte[] b)
        {
            StringBuilder sb = new StringBuilder();

            string tmpStr = "";
            for (int i = 0; i < b.Length; i++)
            {
                tmpStr = Convert.ToString(b[i], 16);
                sb.Append(tmpStr.Length == 1 ? "0" + tmpStr : tmpStr);
                
                if (this.IsFormat.IsChecked.GetValueOrDefault())
                {
                    sb.Append(" ");

                    //以四字节为一组
                    if ((i + 1) % 16 == 0)
                    {
                        sb.Append("\n");
                        continue;
                    }
                    if ((i + 1) % 8 == 0)
                    {
                        sb.Append("  ");
                        continue;
                    }
                    if ((i + 1) % 4 == 0)
                    {
                        sb.Append(" ");
                        continue;
                    }
                }
            }

            TxtBox2.Text = sb.ToString().TrimEnd();
        }
        #endregion

        #region ToHex Encode TO HEX
        public string FromTextBox1(bool isString = false)
        {
            if (isString)
            {
                return this.TxtBox1.Text;
            }
            return this.TxtBox1.Text.Replace("\r","").Trim('\n');
        }
        private void GtChartBtn_Click(object sender, RoutedEventArgs e)
        {
            byte[] result = null;
            var list = new List<byte>();
            string[] arr = FromTextBox1().Split('\n');

            for (int i = arr.Length-1; i >= 0; i--)
            {
                char num = '0';
                try
                {
                    num = Convert.ToChar(arr[i]);
                }
                catch (Exception ex)
                {
                    this.TxtBox2.Text = "输入错误";
                    return;
                }
                result = BitConverter.GetBytes(num);
                for (int j = 0; j < result.Length; j++)
                {
                    list.Add(result[j]);
                }
            }
            ToHex(list.ToArray());
        }

        private void GtShortBtn_Click(object sender, RoutedEventArgs e)
        {
            byte[] result = null;
            var list = new List<byte>();
            string[] arr = FromTextBox1().Split('\n');

            for (int i = arr.Length - 1; i >= 0; i--)
            {
                short num = 0;
                try
                {
                    num = Convert.ToInt16(arr[i]);
                }
                catch (Exception ex)
                {
                    this.TxtBox2.Text = "输入错误";
                    return;
                }
                result = BitConverter.GetBytes(num);
                for (int j = 0; j < result.Length; j++)
                {
                    list.Add(result[j]);
                }
            }
            ToHex(list.ToArray());
        }

        private void GtLongBtn_Click(object sender, RoutedEventArgs e)
        {
            byte[] result = null;
            var list = new List<byte>();
            string[] arr = FromTextBox1().Split('\n');

            for (int i = arr.Length - 1; i >= 0; i--)
            {
                long num = 0;
                try
                {
                    num = Convert.ToInt64(arr[i]);
                }
                catch (Exception ex)
                {
                    this.TxtBox2.Text = "输入错误";
                    return;
                }
                result = BitConverter.GetBytes(num);
                for (int j = 0; j < result.Length; j++)
                {
                    list.Add(result[j]);
                }
            }
            ToHex(list.ToArray());
        }

        private void GtFloatBtn_Click(object sender, RoutedEventArgs e)
        {
            byte[] result = null;
            var list = new List<byte>();
            string[] arr = FromTextBox1().Split('\n');

            for (int i = arr.Length - 1; i >= 0; i--)
            {
                float num = 0;
                try
                {
                    num = Convert.ToSingle(arr[i]);
                }
                catch (Exception ex)
                {
                    this.TxtBox2.Text = "输入错误";
                    return;
                }
                result = BitConverter.GetBytes(num);
                for (int j = 0; j < result.Length; j++)
                {
                    list.Add(result[j]);
                }
            }
            ToHex(list.ToArray());

        }

        private void GtIntBtn_Click(object sender, RoutedEventArgs e)
        {
            byte[] result = null;
            var list = new List<byte>();
            string[] arr = FromTextBox1().Split('\n');

            for (int i = arr.Length - 1; i >= 0; i--)
            {
                int num = 0;
                try
                {
                    num = Convert.ToInt32(arr[i]);
                }
                catch (Exception ex)
                {
                    this.TxtBox2.Text = "输入错误";
                    return;
                }
                result = BitConverter.GetBytes(num);
                for (int j = 0; j < result.Length; j++)
                {
                    list.Add(result[j]);
                }
            }
            ToHex(list.ToArray());
        }

        private void GtDoubleBtn_Click(object sender, RoutedEventArgs e)
        {
            byte[] result = null;
            var list = new List<byte>();
            string[] arr = FromTextBox1().Split('\n');

            for (int i = arr.Length - 1; i >= 0; i--)
            {
                double num = 0;
                try
                {
                    num = Convert.ToDouble(arr[i]);
                }
                catch (Exception ex)
                {
                    this.TxtBox2.Text = "输入错误";
                    return;
                }
                result = BitConverter.GetBytes(num);
                for (int j = 0; j < result.Length; j++)
                {
                    list.Add(result[j]);
                }
            }
            ToHex(list.ToArray());
        }

        private void GtStringBtn_Click(object sender, RoutedEventArgs e)
        {
            byte[] byteArray = System.Text.Encoding.Default.GetBytes(FromTextBox1(true));

            ToHex(byteArray);
        }
        #endregion

        #region FromHex Decode From Hex
        public string FromHex(bool isInverted = true)
        {
            string myHex = this.TxtBox2.Text.Replace(" ", "").Replace("\n", "").Replace("　","");
            if (isInverted)
            {
                StringBuilder sb = new StringBuilder();
                for (int i = myHex.Length - 1; i > 0; i -= 2)
                {
                    sb.Append(myHex.Substring(i - 1, 2));
                }

                return sb.ToString();
            }
            return myHex;
        }
        public void SetTxtBox1(string str)
        {
            this.TxtBox1.Text = str.TrimEnd('\n');
        }
        private void LtChartBtn_Click(object sender, RoutedEventArgs e)
        {
            string myHex = FromHex();

            string str = "";
            try
            {
                for (int i = 0; i < myHex.Length; i += 4)
                    str += (char)Int16.Parse(myHex.Substring(i, 4),
                                             NumberStyles.AllowHexSpecifier) + "\n";
            }
            catch (Exception ed)
            {
                this.TxtBox1.Text = "输入错误";
                return;
            }

            SetTxtBox1(str);
        }

        private void LtIntBtn_Click(object sender, RoutedEventArgs e)
        {
            string myHex = FromHex();

            string str = "";
            try
            {
                for (int i = 0; i < myHex.Length; i += 8)
                    str += Int32.Parse(myHex.Substring(i, 8),
                                             NumberStyles.AllowHexSpecifier).ToString() + "\n";
            }
            catch (Exception ed)
            {
                this.TxtBox1.Text = "输入错误";
                return;
            }

            SetTxtBox1(str);
        }

        private void LtFloatBtn_Click(object sender, RoutedEventArgs e)
        {
            string hexString = FromHex();

            string str = "";
            try
            {
                for (int i = 0; i < hexString.Length; i += 8)
                {
                    uint num = uint.Parse(hexString.Substring(i, 8), NumberStyles.AllowHexSpecifier);
                    byte[] floatVals = BitConverter.GetBytes(num);
                    float f = BitConverter.ToSingle(floatVals, 0);

                    str += f + "\n";
                }
            }
            catch (Exception ex)
            {
                this.TxtBox1.Text = "输入错误";
                return;
            }

            SetTxtBox1(str);
        }

        private void LtShortBtn_Click(object sender, RoutedEventArgs e)
        {
            string myHex = FromHex();

            string str = "";
            try
            {
                for (int i = 0; i < myHex.Length; i += 4)
                    str += Int16.Parse(myHex.Substring(i, 4),
                                             NumberStyles.AllowHexSpecifier).ToString() + "\n";
            }
            catch (Exception ed)
            {
                this.TxtBox1.Text = "输入错误";
                return;
            }

            SetTxtBox1(str);
        }

        private void LtLongBtn_Click(object sender, RoutedEventArgs e)
        {
            string myHex = FromHex();

            string str = "";
            try
            {
                for (int i = 0; i < myHex.Length; i += 16)
                    str += Int64.Parse(myHex.Substring(i, 16),
                                             NumberStyles.AllowHexSpecifier).ToString() + "\n";
            }
            catch (Exception ed)
            {
                this.TxtBox1.Text = "输入错误";
                return;
            }

            SetTxtBox1(str);
        }

        private void LtDoubleBtn_Click(object sender, RoutedEventArgs e)
        {
            string hexString = FromHex();

            string str = "";
            try
            {
                for (int i = 0; i < hexString.Length; i += 16)
                {
                    ulong num = ulong.Parse(hexString.Substring(i, 16), NumberStyles.AllowHexSpecifier);
                    byte[] floatVals = BitConverter.GetBytes(num);
                    double f = BitConverter.ToDouble(floatVals, 0);

                    str += f + "\n";
                }
            }
            catch (Exception ex)
            {
                this.TxtBox1.Text = "输入错误";
                return;
            }

            SetTxtBox1(str);
        }

        private void LtStringBtn_Click(object sender, RoutedEventArgs e)
        {
            string hexString = FromHex(false);

            byte[] raw = new byte[hexString.Length / 2];
            try
            {
                for (int i = 0; i < raw.Length; i++)
                {
                    raw[i] = Convert.ToByte(hexString.Substring(i * 2, 2), 16);
                }
            }
            catch (Exception ex)
            {
                this.TxtBox1.Text = "输入错误";
                return;
            }

            SetTxtBox1(Encoding.Default.GetString(raw));
        }
        #endregion

        #region Format Hex
        private void IsFormat_Click(object sender, RoutedEventArgs e)
        {
            if (this.IsFormat.IsChecked.GetValueOrDefault())
            {
                StringBuilder sb = new StringBuilder();
                string str = TxtBox2.Text;
                for (int i = 0; i < str.Length; i++)
                {
                    sb.Append(str[i]);

                    if ((i + 1) % 32 == 0)
                    {
                        sb.Append("\n");
                        continue;
                    }
                    if ((i + 1) % 16 == 0)
                    {
                        sb.Append("   ");
                        continue;
                    }
                    if ((i + 1) % 8 == 0)
                    {
                        sb.Append("  ");
                        continue;
                    }
                    if ((i + 1) % 2 == 0)
                    {
                        sb.Append(" ");
                        continue;
                    }
                }
                TxtBox2.Text = sb.ToString();
            }
            else
            {
                TxtBox2.Text = TxtBox2.Text.Replace("\n", "").Replace(" ", "").Replace("　","");
            }
        }
        #endregion


    }
}
