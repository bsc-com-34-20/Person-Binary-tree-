namespace Assignmentsc_
{
     class Program
    {
        static void Main()
        {
            BinaryTree binaryTree = new BinaryTree();

            // Read from the text file and insert nodes into the binary tree
            binaryTree.ReadFromFileAndInsert("COM314.txt");

            while (true)
            {
                Console.WriteLine("\n\t\tBINARY TREE OPERATIONS");
                Console.WriteLine("\t1. Inorder Traversal");
                Console.WriteLine("\t2. Postorder Traversal");
                Console.WriteLine("\t3. Search Person by Unique ID");
                Console.WriteLine("\t4. Exit\n");
                Console.Write("\tEnter your choice: ");

                int choice;
                if (int.TryParse(Console.ReadLine(), out choice))
                {
                    switch (choice)
                    {
                        case 1:
                            binaryTree.InOrderTraversal();
                            break;

                        case 2:
                            binaryTree.PostOrderTraversal();
                            break;

                        case 3:
                            Console.Write("\tEnter the Unique ID to search: ");
                            string searchID = Console.ReadLine();

                            Person foundPerson;
                            binaryTree.Search(searchID, out foundPerson);
                            break;

                        case 4:
                            Console.WriteLine("\n\tThank you Bye!!.");
                            Environment.Exit(0);
                            break;

                        default:
                            Console.WriteLine("\tInvalid choice. Please enter a valid option.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("\tInvalid input. Please enter a valid integer.");
                }
            }
        }
    }

}
