using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
//Rossa Heraty Quirke 
//window representing an invoice for a booking, it shows the total cost of that booking
//10/12/2016
namespace cw2_2017
{
    /// <summary>
    /// Interaction logic for invoice_window.xaml
    /// </summary>
    public partial class invoice_window : Window
    {
        public invoice_window(string inv_details)
        {
            InitializeComponent();
            //sets the label to the string holding the invoice details
            lbl_cost.Content = inv_details;
        }
    }
}
