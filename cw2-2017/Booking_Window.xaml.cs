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


namespace cw2_2017
{
    //Rossa Heraty Quirke 
    //Window that takes inputs from the user to generate a booking object and a guest object, it calls methods to add and delete this from their dictionaries
    //10/12/2016
    public partial class Booking_Window : Window
    {
        //create new instance of the booking class
        Booking new_booking = new Booking();
        //create new booking instance of the guest class
        Guest new_guest = new Guest();
        public Booking_Window()
        {
            InitializeComponent();
        }
        //int that will be assinged to new bookings as booking reference
        private int booking_ref_inc = 1;

        //button to add a new booking
        private void btn_save_book_Click(object sender, RoutedEventArgs e)
        {
            //get dates from values entered in the date picker, if there is one, catch exceptions
            if (d_box_arr.SelectedDate.HasValue)
            {
                new_booking.Arv_date = d_box_arr.SelectedDate.Value;
                if (d_box_dep.SelectedDate.HasValue)
                {
                    new_booking.Dep_date = d_box_dep.SelectedDate.Value;

                    //increment the booking reference for a new booking
                    new_booking.Book_Ref = booking_ref_inc++;

                    //add the object to the dictionary
                    new_booking.AddBooking(new_booking);

                    //clear the user input
                    d_box_arr.Text = String.Empty;
                    d_box_dep.Text = String.Empty;

                    //add the object to the list box 
                    lstbox_booking.Items.Add(new_booking);
                }
            }
        }

        //button which clears the selected item from the listbox and calls the delete method
        private void btn_delete_booking_Click(object sender, RoutedEventArgs e)
        {
            if (lstbox_booking.SelectedItem != null)
            {
                //user inputted int that will be compared to keys in the dictionary
                int booking_ref = 0;
                int.TryParse(txt_booking_ref.Text, out booking_ref);
                //call method to delete the relevant booking reference
                new_booking.DelBooking(booking_ref);
                lstbox_booking.Items.Remove(lstbox_booking.SelectedItem);
                txt_booking_ref.Text = String.Empty;
            }
            else
            {
                txt_booking_ref.Text = String.Empty;
                MessageBox.Show("Please select the relevant item from the box and enter its reference before deleting.");
            }
        }
         private void btn_guest_save_Click(object sender, RoutedEventArgs e)
         {

            //int to hold the guest's age before it is added to the object
             int guest_age;
             //convert age to an int and save it
             int.TryParse(txt_age.Text, out guest_age);

             //get values for the creation of a guest object
              new_guest.Age = guest_age; 
              new_guest.Name = txt_name.Text;
            
             try{
             new_guest.Pass_Num = txt_pass_num.Text;
              }catch (Exception excep)
             {
                MessageBox.Show(excep.Message);
             }
             try { 
             new_guest.Book_Ref = new_booking.Book_Ref;
             }
             catch (Exception excep)
             {
                 MessageBox.Show(excep.Message);
             }
    
             //call method to add object to the dictionary
             new_guest.AddGuest(new_guest);

             //call method to add the new guest object to the guest dictionary
             lstbox_guests.Items.Add(new_guest);

             //clear user input
             txt_name.Text = String.Empty;
             txt_age.Text = String.Empty;
             txt_pass_num.Text = String.Empty;
         }

        //button to delete a guest and clear relevant item from the listbox
         private void btn_delete_guest_Click(object sender, RoutedEventArgs e)
         {
             //string to be compared to the dictionary of guests
             string pass_num_del = txt_pass_num_key.Text;
             //if the string matches the key it calls the delete method and removes that entry from the dictionary
             if (txt_pass_num_key.Text != String.Empty)
             {
                 new_guest.DelGuest(new_guest, pass_num_del);
                 txt_pass_num_key.Text = String.Empty;
             }
             else
             {
                 MessageBox.Show("Please enter a valid passport number.");
             }
         }
        private void btn_invoice_Click(object sender, RoutedEventArgs e)
        {
            //int to hold the number of guests found by the count guest method which it calls
            int guests = new_guest.CountGuests(new_booking);
            //int to hold the cost of the booking found by the metthod called
            int cost = new_guest.GetBookingCost(new_booking,guests);
            string inv_details = "The booking with booking reference " + new_booking.Book_Ref + " will cost £" + cost + ".";
            //open the invoice window, passes the invoice details to that window
            Window inv_win = new invoice_window(inv_details);
            inv_win.Show();
        }
        private void btn_quit_Click(object sender, RoutedEventArgs e)
        {
            //closes current window
            Close();
        }
        private void txt_pass_num_TextChanged(object sender, TextChangedEventArgs e)
        {
        }
        private void lstbox_guests_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }

        private void btn_extra_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
