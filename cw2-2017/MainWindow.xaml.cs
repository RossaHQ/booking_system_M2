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
using System.Windows.Navigation;
using System.Windows.Shapes;
//Rossa Heraty Quirke 
//Window which takes user input to create a customer object, it can call methods to add and delete entries from the customer dictionary
//it displays the created customer object and allows user to open the booking window   
//10/12/2016

namespace cw2_2017
{
    public partial class MainWindow : Window
    {
        //new instance of the customer object
        Customer new_customer = new Customer();

        //create a variable to hold customer reference
        private int cust_ref_inc = 1;

        public MainWindow()
        {
            InitializeComponent();
        }

        //button to call the add method to add the created customer to a customer dictionary
        private void btn_save_Click(object sender, RoutedEventArgs e)
        {
            if (txt_name.Text == String.Empty | txt_address.Text == String.Empty)
            { 
                MessageBox.Show("Please enter your full details.");
            }else{
                //get values from user input
                new_customer.Name = txt_name.Text;
                new_customer.Address = txt_address.Text;

                //increment the booking reference for a new booking
                new_customer.Cust_Ref = cust_ref_inc++;

                lst_box_cust.Items.Clear();
                //add the values to the dictionary and set the key as cust ref
                new_customer.AddCust(new_customer);
                lst_box_cust.Items.Add(new_customer);
                //clear ui
                txt_name.Text = String.Empty;
                txt_address.Text = String.Empty;
            }
            //clear ui
            txt_name.Text = String.Empty;
            txt_address.Text = String.Empty;

        }

        //button to call the delete method for customer and pass in a int to use as a key
        private void btn_delete_cust_Click(object sender, RoutedEventArgs e)
        {
            //int to hold the value which will be compared to the key to find the relevant entry
                int cust_ref_delete;

                int.TryParse(txt_cust_key.Text, out cust_ref_delete);
             //calls delete customer method
                new_customer.DelCust(new_customer, cust_ref_delete);
            //clear ui
                lst_box_cust.Items.Clear();

                txt_cust_key.Text = String.Empty;


        }
       
      //button to open the booking window, does not open if there is no item in the listbox - so it ensures there is an existing customer before a booking is created
        private void btn_booking_Click(object sender, RoutedEventArgs e)
        {
            if ( lst_box_cust.Items.Count == 0)
            {
                MessageBox.Show("You must create a customer before a booking");
            }
            else
            {
                //open booking window
                Window booking_window = new Booking_Window();
                booking_window.Show();
            }
        }
        private void btn_quit_Click(object sender, RoutedEventArgs e)
        {
            //close the main window ending the progrma
            this.Close();
        }
        
        private void lst_box_cust_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

    }
}
