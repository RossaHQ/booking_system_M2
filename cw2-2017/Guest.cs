using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//Rossa Heraty Quirke 
//Class which holds the constructors for a guest object and methods to add and delete objects to a dictionary of guest objects
//10/12/2016
namespace cw2_2017
{
    public class Guest
    {
        private int get_age;
        private string get_name;
        private string get_pass_num;
        private int get_book_ref;

        //creates a new dictionary to hold instances of the guest class
        Dictionary<string, Guest> Guest_Dict = new Dictionary<string, Guest>();

        //constructors for the properties in the class
        public string Name
        {
            get { return get_name; }
            set  { get_name = value;}
        }

        public int Age
        {
            get { return get_age; }
            set { get_age = value; }
        }
        
        public string Pass_Num
        {
            get { return get_pass_num; }
            set 
            { 
                if (value.Length > 11)
                {
                   throw new ArgumentException("Please enter a valid passport number, passport numbers are 11 characters long.");
                }
            
                get_pass_num = value;
            }
        }
       
        public int Book_Ref
        {
            get { return get_book_ref; }
            set 
            {
                if (value < 1)
                {
                    throw new ArgumentException("As guests are linked to a booking you must first save your booking dates to create a guest.");
                }
                get_book_ref = value;
            }
        }

    //method to count how many guests there are associated with a booking
        public int CountGuests(Booking new_booking)
        {
            //int to hold the number of guests found 
            int number_of_guests = 0;
           foreach(KeyValuePair<string, Guest> obj in Guest_Dict)
           {
              if(obj.Value.Book_Ref == new_booking.Book_Ref)
              {
                 number_of_guests = Guest_Dict.Count();
              }
           }
           return number_of_guests;
        }

        //method to calculate the cost of the booking, takes the current booking from the booking window and counts how many guests there is
        public int GetBookingCost(Booking new_booking, int guests)
        {
            //calculates the difference between dates
            TimeSpan dates = new_booking.Dep_date - new_booking.Arv_date;
            //converts the days into an int 
            int number_of_days = Convert.ToInt32(dates.TotalDays);
            //int that holds the cost of the booking
            int cost = number_of_days * 50 * guests;
            return cost;
        }

        //method to add new entry to the guest dictionary
        public void AddGuest(Guest new_guest)
        {
            if (Guest_Dict.ContainsKey(new_guest.Pass_Num))
            {
                MessageBox.Show("There is already a guest with this passport number.");
            }
            else
            {
                Guest_Dict.Add(new_guest.Pass_Num, new_guest);
            }
        }

      //method to delete an entry of the guest dictionary if the key equals the string passed in
        public void DelGuest(Guest new_guest, string pass_num_del)
        {
            if (Guest_Dict.ContainsKey(pass_num_del))
            {

                MessageBox.Show("Guest with passport number " + pass_num_del + " has been deleted.");
                Guest_Dict.Remove(pass_num_del);
            }
            else
            {
                MessageBox.Show("This guest does not exist or has already been deleted.");
            }
        }

        //allows the object to be represented as a string in the gui
        public override string ToString()
        {
            return "Booking ref: " + Book_Ref + 
                   "\nName: " + Name + 
                   "\nPassport Number: " + Pass_Num;
        }

   

    }
}
