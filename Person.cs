namespace Assignmentsc_
{
      // Person class with attributes: FirstName, LastName, Age, and UniqueID
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string UniqueID { get; set; }

        // Constructor for Person class
        public Person(string firstName, string lastName, int age, string uniqueID)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            UniqueID = uniqueID;
        }
        
    }
    
}