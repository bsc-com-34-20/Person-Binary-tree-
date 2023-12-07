namespace Assignmentsc_
{
    public class BinaryTree
    {
        private Node<Person>? root;

        // Insert a Person object into the binary tree
      
        public void Insert(Person person)  {
            root = InsertRecursive(root, person);
        }

        // Inserting a node recursively
        private Node<Person>? InsertRecursive(Node<Person>? node, Person person)
        {
            if (node == null){
                return new Node<Person>(person);
            }

            // Check if the unique ID already exists
            if(person.UniqueID == node.Data.UniqueID ){
                Console.WriteLine("\tPerson with the same unique ID already exists. Insertion aborted.");
                Console.WriteLine($"\t{node.Data.FirstName} \n\t{node.Data.LastName} \n\t{node.Data.Age} \n\t{node.Data.UniqueID}\n");
                 return node; 
            }

            //checking if the new node has 6 characters and consist of numbers and characters
             if (person.UniqueID.Length != 6 || !person.UniqueID.All(char.IsLetterOrDigit)){
                   Console.WriteLine("\tInvalid Unique ID.. Insertion aborted.");
                   Console.WriteLine($"\t{person.FirstName} \n\t{person.LastName} \n\t{person.Age} \n\t{person.UniqueID}");
                   return node; 
                }
        if (person.Age < node.Data.Age){
                node.LeftNode = InsertRecursive(node.LeftNode, person);
            }
            else if (person.Age > node.Data.Age)
            {
                node.RightNode = InsertRecursive(node.RightNode, person);
            }
          

            return node;
        }

        // Read from the specified text file and insert nodes into the binary tree
        public void ReadFromFileAndInsert(string fileName){
            try
            {
                string[] lines = File.ReadAllLines(fileName);
                int index = 0;

                while (index < lines.Length)
                {
                    // Read details from the text file
                    string firstName = lines[index++];
                    string lastName = lines[index++];
                    int age = int.Parse(lines[index++]);
                    string uniqueID = lines[index++];

                    // Create a Person object
                    Person person = new Person(firstName, lastName, age, uniqueID);

                    // Insert the Person object into the binary tree
                    Insert(person);

                    // Skip the empty line between entries
                    index++;
                }

                //Console.WriteLine("\tNodes inserted successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\tError reading from file: {ex.Message}");
            }
        }

        // Perform in-order traversal and display the details of each node
        public void InOrderTraversal()
        {
            Console.Write("\tInorder Traversal: ");
            InOrderTraversalRecursive(root);
            Console.WriteLine();
        }

        private void InOrderTraversalRecursive(Node<Person>? node)
        {
            if (node != null)
            {
                InOrderTraversalRecursive(node.LeftNode);
                Console.WriteLine($"\n\t{node.Data.FirstName} \n\t{node.Data.LastName} \n\t{node.Data.Age} \n\t{node.Data.UniqueID}");
                InOrderTraversalRecursive(node.RightNode);
            }
        }

        // Perform post-order traversal and display the details of each node
        public void PostOrderTraversal()
        {
            Console.Write("\tPostorder Traversal: ");
            PostOrderTraversalRecursive(root);
            Console.WriteLine();
        }

        private void PostOrderTraversalRecursive(Node<Person>? node)
        {
            if (node != null)
            {
                PostOrderTraversalRecursive(node.LeftNode);
                PostOrderTraversalRecursive(node.RightNode);
                Console.WriteLine($"\n\t{node.Data.FirstName} \n\t{node.Data.LastName} \n\t{node.Data.Age} \n\t{node.Data.UniqueID}");
            }
        }

        // Search for a node with the specified unique ID in the binary tree
        public bool Search(string uniqueID, out Person foundPerson)
        {
            foundPerson = new Person("", "", 0, "");

            return SearchRecursive(root, uniqueID, ref foundPerson);
        }

        // Searching a node in the binary tree recursively
        private bool SearchRecursive(Node<Person>? node, string uniqueID, ref Person foundPerson)
        {
            if (node == null)
            {
                Console.WriteLine("\tNode not found.");
                return false;
            }

            if (uniqueID == node.Data.UniqueID)
            {
                foundPerson = node.Data;
                Console.WriteLine($"\tNode found: \n\t{foundPerson.FirstName} \n\t{foundPerson.LastName} \n\t{foundPerson.Age} \n\t{foundPerson.UniqueID}");
                return true;
            }

            if (String.Compare(uniqueID, node.Data.UniqueID) < 0)
            {
                return SearchRecursive(node.LeftNode, uniqueID, ref foundPerson);
            }
            else
            {
                return SearchRecursive(node.RightNode, uniqueID, ref foundPerson);
            }
             //ID validation method 
        
        }
           static bool IsValidID(string id){
            return id.Length == 6;
        }
    }

}

