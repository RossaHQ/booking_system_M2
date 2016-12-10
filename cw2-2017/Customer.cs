using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//Rossa Heraty Quirke 
//Class which holds the constructors for a customer object and methods to add and delete objects to a dictionary of customer objects
//10/12/2016

namespace cw2_2017
{
    public class Customer
    {
        
        private string get_name;
        private string get_address;
        private int get_cust_ref;
        //create a new diciontary to hold instance of the customer class
        Dictionary<int, Customer> Cust_Dict = new Dictionary<int, Customer>();
        //constructors to get the values of the class object
        public string Name
        {
            get { return get_name; }
            set { get_name = value; }
        }

        public string Address
        {
            get { return get_address; }
            set { get_address = value; }
        }
        public int Cust_Ref
        {
            get { return get_cust_ref; }
            set { get_cust_ref = value; }
               
      
        }
        //method to add a customer to the customer dictionary
        public void AddCust(Customer new_customer)
        {
            Cust_Dict.Add(new_customer.Cust_Ref, new_customer);
        }
        //method to delete a customer, takes in a int to compare against keys
        public void DelCust(Customer new_customer, int customer_ref)
        {
            if (Cust_Dict.ContainsKey(customer_ref))
            {
                MessageBox.Show("The customer with the reference number " + customer_ref + " has been deleted.");
                Cust_Dict.Remove(customer_ref);
            }
            else
            {
                MessageBox.Show("This customer does not exist or has already been deleted.");
            }
        }
        //overloaded method to allow the class object to be displayed as a string
        public override string ToString()
        {
            return "Customer Reference: " + Cust_Ref + 
                "\nName: " + Name + 
                "\nAddress: " + Address;
        }
    }
}
