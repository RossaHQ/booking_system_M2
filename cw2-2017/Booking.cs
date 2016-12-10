using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//Rossa Heraty Quirke 
//Class which holds the constructors for a booking object and methods to add and delete objects to a dictionary of booking objects
//10/12/2016

namespace cw2_2017
{
    public class Booking 
    {

        private DateTime get_arv_date;
        private DateTime get_dep_date;
        private int get_booking_ref;

        //create a new diciontary to hold instance of the booking class
        Dictionary<int, Booking> Book_Dict = new Dictionary<int, Booking>();

        public DateTime Arv_date
        {
            get { return get_arv_date; }
            set { get_arv_date = value; }
        }
        public DateTime Dep_date
        {
            get { return get_dep_date; }
            set { get_dep_date = value; }
                  
        }
        public int Book_Ref
        {
            get { return get_booking_ref; }
            set { get_booking_ref = value; }
        }
    
        //booking delete, amend and find methods

        //takes an int and checks if a key in the booking dictionary 
        //matches this this method returns that matching entry

        //adds a booking object to the booking dictionary and sets the key to the booking reference
        public void AddBooking(Booking new_booking)
        {
           Book_Dict.Add(new_booking.Book_Ref, new_booking);
        }

        //takes an int and checks if it matches a key in the booking dictionary, 
        //if it matches it will delete that object and key from the dictionary
        public void DelBooking(int booking_ref)
        {
            if (Book_Dict.ContainsKey(booking_ref))
            {
                MessageBox.Show("The booking with the booking reference " + booking_ref + " has been deleted");
                Book_Dict.Remove(booking_ref);

            }
            else
            {
                MessageBox.Show("This booking does not exist or has already been deleted.");
            }
        }

        //allows class object to be displayed as a string
        public override string ToString()
        {
            return "Booking ref: " + Book_Ref +
                "\nDep. date: " + Dep_date.Date +
                "\nArv. date: " + Arv_date.Date;
        }
    }
}
