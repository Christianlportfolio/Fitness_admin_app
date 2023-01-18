using FitnessApp.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessApp.ViewModel
{
    public class CustomerViewModel : INotifyPropertyChanged
    {
        public CustomerRepository customerRepository;
        public List<Customer> Customers { get; set; }

        public List<Customer> CustomersToAddPaymentInformation { get; set; }


        public int[] Age { get; set; }

        private Customer selectedCostumer;
       
        public Customer SelectedCostumer
        {
            get { return selectedCostumer; }

            set
            {
                if(selectedCostumer != value)
                {
                    selectedCostumer = value;
                    OnPropertyChanged("SelectedCostumer");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if (propertyChanged != null)
            {
                propertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }


        public CustomerViewModel()
        {
            customerRepository = new CustomerRepository();
            Customers = customerRepository.GetAllCustomers();

            Age = new int[] { 1930, 1931, 1932, 1933, 1934, 1935, 1936, 1937, 1938, 1939, 1940, 1941, 1942, 1943, 1944, 1945, 1946, 1947, 1948, 1949, 1950, 1951, 1952, 1953, 1954, 1955, 1956, 1957, 1958, 1959, 1960, 1961, 1962, 1963, 1964, 1965, 1966, 1967, 1968, 1969, 1970, 1971, 1972, 1973, 1974, 1975, 1976, 1977, 1978, 1979, 1980, 1981, 1982, 1983, 1984, 1985, 1986, 1987, 1988, 1989, 1990, 1991, 1992, 1993, 1994, 1995, 1996, 1993, 1994, 1995, 1996, 1997, 1998, 1999, 2000, 2001, 2002, 2003, 2004, 2005, 2006 };

            CustomersToAddPaymentInformation = new List<Customer>();
            foreach (Customer customer in Customers)
            {
                if(customer.RegisterNumber == 0)
                {
                    CustomersToAddPaymentInformation.Add(customer);
                }
            }
        }


  

    }
}
