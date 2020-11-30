using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBApp
{
    public class Person
    {
        //Create properties that match the 
        /*int id;
        string firstName_;
        string lastName_;
        string emailAddress_;
        string phoneNumber_;*/

        //Class with and without backing fields : https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/properties 

        /*
         f a property has both a get and a set accessor, both must be auto-implemented. 
        You define an auto-implemented property by using the get and set keywords without providing any implementation.
         */

        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }

        public string FullInfo {
            get {
                //return the details of the person
                return $"{ FirstName } { LastName } ({EmailAddress})";
            }
        }



    }
}
