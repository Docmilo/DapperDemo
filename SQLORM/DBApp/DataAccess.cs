using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace DBApp
{
    public class DataAccess
    {
        public List<Person> GetPeople(string lastName)
        {
            //Allow us to compile the application without code
            //throw new NotImplementedException();

            //Using statments in code allow you to call code / functions that have a connection
            //And as soon as the using is done, destroy the connection
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("SampleDB")))
            {
                //https://dapper-tutorial.net/query
                //Query method is an extension method that can be called from any object of type IDbConnection. It can execute a query and map the result.

                //Ask the connection for person data back - normally returns an IEnumerable so convert to list
                //return connection.Query<Person>($"select * from People where LastName = '{ lastName}'").ToList();

                //Not great practice as it is subject to SQL injection, instead we should use a stored procedure
                //var output = connection.Query<Person>($"select * from People where LastName = '{ lastName }'").ToList();
                //Create a new dynamic class instance that has a propery called LastName which is initialised with the lastName parameter from the function

                var output = connection.Query<Person>("dbo.spPeople_GetByLastName @LastName", new { LastName = lastName }).ToList();


                return output;
            }
        }

        public void InsertPerson(string firstName, string lastName, string email, string phone)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("SampleDB")))
            {
                //https://dapper-tutorial.net/execute
                //Execute is an extension method that can be called from any object of type IDbConnection. 
                //It can execute a command one or multiple times and return the number of affected rows. This method is usually used to execute:

                //Assemble the data create a person
                //Person newPerson = new Person { FirstName = firstName, LastName = lastName, EmailAddress = email, PhoneNumber = phone };
                List<Person> people = new List<Person>();
                //people.Add(newPerson);
                people.Add(new Person { FirstName = firstName, LastName = lastName, EmailAddress = email, PhoneNumber = phone });

                connection.Execute("dbo.spPeople_Insert @FirstName, @LastName, @EmailAddress, @PhoneNumber", people);

            }
        }
    }
}


/*
 
 Stored procedures

/*
To create a stored procedure
CREATE procedure dbo.spPeople_GetByLastName
    @LastName nvarchar(50)
as 
begin 
	/*We don't want a count of rows affected*/
/*SET NOCOUNT ON;

select* from dbo.People 
		where LastName = @LastName;
end

///Insert strored procedure

Create PROCEDURE dbo.spPeople_Insert
	@FirstName nvarchar(50),
	@LastName nvarchar(50),
	@EmailAddress nvarchar(100),
	@PhoneNumber varchar(20)
AS
BEGIN
	SET NOCOUNT ON;

    insert into dbo.People (FirstName, LastName, EmailAddress, PhoneNumber)
	values (@FirstName, @LastName, @EmailAddress, @PhoneNumber);

END


*/

*/