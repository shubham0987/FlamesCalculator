using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;

namespace Flames_Calculator
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            if (name.Text.Length == 0)
                MessageBox.Show("Name not entered");
            else if (pname.Text.Length == 0)
            {
                MessageBox.Show("Partners Name not entered");
            }
            else
            {
                string n1 = name.Text.Trim();
                n1 = name.Text.ToUpper();
                string n2 = pname.Text.Trim();
                n2 = pname.Text.ToUpper();
                if (n1 == n2)
                    MessageBox.Show("Both the names are same");
                else if (name.Text.Length > 0 && pname.Text.Length > 0 && n1 != n2)
                {
                    char[] nn1 = new char[n1.Length];
                    char[] nn2 = new char[n2.Length];
                    nn1 = n1.ToCharArray();
                    nn2 = n2.ToCharArray();
                    int counter = 0;
                    for (int i = 0; i < nn1.Length; i++)
                    {
                        if (nn1[i] != null)
                            for (int j = 0; j < nn2.Length; j++)
                                if (nn2[j] != null)
                                    if (nn1[i] == nn2[j])
                                    {
                                        counter = counter + 2;
                                        break;
                                    }
                    }
                    int count = (nn1.Length + nn2.Length) - counter;
                    char[] flame = { 'F', 'L', 'A', 'M', 'E', 'S' };
                    int l = flame.Length;
                    string s;
                    while (flame.Length != 1)
                    {
                        int c = count % flame.Length;
                        flame[c] = '/';
                        s = new string(flame);
                        s.Remove(c, 1);
                        string[] ss = s.Split('/');
                        s = ss[0] + ss[1];
                        flame = s.ToCharArray();
                    }
                    string ans = new string(flame);
                    if (ans == "F")
                        ans = " are Friends";
                    else if (ans == "L")
                        ans = " in Love";
                    else if (ans == "A")
                        ans = " are Affectionate";
                    else if (ans == "M")
                        ans = " will get Married";
                    else if (ans == "E")
                        ans = " are Enemy";
                    else if (ans == "S")
                        ans = " are Siblings";
                    MessageBox.Show(name.Text.ToUpper() + " and " + pname.Text.ToUpper() + ans, "Calcuated Relation", MessageBoxButton.OK);
                    name.Text = "";
                    pname.Text = "";
                }
            }
        }

        private void PhoneApplicationPage_OrientationChanged(object sender, OrientationChangedEventArgs e)
        {
            PageOrientation pp = this.Orientation;
            if (pp == PageOrientation.Landscape || pp == PageOrientation.LandscapeLeft || pp == PageOrientation.LandscapeRight)
            {
                button1.Margin = new Thickness(450, 25, 0, 0);
                textBlock3.Margin = new Thickness(100, 300, 0, 0);
                stackPanel1.Margin = new Thickness(470, 100, 0, 0);
            }
            else
            {
                button1.Margin = new Thickness(195, 216, 0, 0);
                textBlock3.Margin = new Thickness(25, 579, 0, 0);
                stackPanel1.Margin = new Thickness(123, 341, 0, 0);
            }
        }

    }
}