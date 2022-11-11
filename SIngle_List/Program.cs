using System;
using System.Security.Cryptography.X509Certificates;

namespace Single_List
{
    // Each node consist of the information part and link to the next node

    class Node
    {
        public int rollNumber;
        public string name;
        public Node next;
    }

    class List
    {
        Node START;
        
        public List()
        {
            START = null;
        }

        public void addNote() //add a node in the list
        {
            int nim;
            string nm;
            Console.WriteLine("Enter the roll number of the student : ");
            nim = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter the name of the student : ");
            nm = Console.ReadLine();
            Node newnode = new Node();
            newnode.rollNumber = nim;
            newnode.name = nm;
            //if the node to be inserted is the fisrt node
            if (START == null || nim <= START.rollNumber)
            {
                if((START != null) && (nim == START.rollNumber))
                {
                    Console.WriteLine("Duplicate roll number of allowed");
                }
            }
            newnode.next = START;
            START = newnode;
            return;

            //Locate the position of the new node in the list

            Node previous, current;
            previous = START;
            current = START;

            while ((current != null) && (nim >= current.rollNumber))
            {
                if (nim == current.rollNumber)
                {
                    Console.WriteLine("Duplicate rill numbers not allowed");
                    return;

                }
                previous = current;
                current = current.next;
            }

            //Once the above for loop is executed, previous and current are positional is such a way that the position for the new node
            newnode.next = current;
            previous.next = newnode;
        }
        public void traverse()
        {
            if (ListEmpty())
                Console.WriteLine("List is empty");
            else
            {
                Console.WriteLine("The records in the list area");
                Node currentNode;
                for (currentNode = START; currentNode != null; currentNode = currentNode.next)
                    Console.Write(currentNode.rollNumber + " " + currentNode.name + " ");
                Console.WriteLine();
               
            }

           
        }
        public bool delNote(int nim)
        {
            Node previous, current;
            previous = current = null;
            //Check if the specified node is the list or not
            if (Search(nim, ref previous, ref current) == false)
                return false;
            previous.next = current.next;
            if (current == START)
                START = current.next;
            return true;
        }

        public bool Search(int nim, ref Node previous, ref Node current)
        {
            previous = START;
            current = START;
            while ((current != null) && (nim != current.rollNumber))
            {
                previous = current;
                current = current.next;
            }
            if (current == null)
                return (false);
            else 
                return(true);
        }

        public bool ListEmpty()
        {
            if (START == null)
                return true;
            else
                return false;
        }
    }
    class Program
    {
        // Check wheter the specified node is present in the list or not

        static void Main(string[] args)
        {
            List obj = new List();
            while (true)
            {
                try
                {
                    Console.WriteLine("MENU");
                    Console.WriteLine("1. Add a record to the list");
                    Console.WriteLine("2. Delete a record from  the list");
                    Console.WriteLine("3. View all the records in the list");
                    Console.WriteLine("4. Search for a record in the last");
                    Console.WriteLine("5. EXIT");
                    Console.Write("Enter your choice (1-5) : ");
                    char ch = Convert.ToChar(Console.ReadLine());
                    switch (ch)
                    {
                        case '1':
                            {
                                obj.addNote();
                            }
                            break;
                        case '2':
                            {
                                if (obj.ListEmpty())
                                {
                                    Console.WriteLine("List is empty");
                                }
                                Console.Write("Enter the roll number of" + " the student whose record is to be deleted : ");
                                int nim = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine();
                                if (obj.delNote(nim) == false)
                                    Console.WriteLine("Record not found");
                                else
                                    Console.WriteLine("Record with roll number" + nim + "Deleted");

                            }
                            break;
                        case '3':
                            {
                                obj.traverse();
                            }
                            break;
                        case '4':
                            {
                                if (obj.ListEmpty() == true)
                                {
                                    Console.WriteLine("List is empty");
                                    break;
                                }
                                Node previous, current;
                                previous = current = null;
                                Console.Write("Enter the roll number of the" + "student whpse record is to be searched: ");
                                int num = Convert.ToInt32(Console.ReadLine());
                                if (obj.Search(num, ref previous, ref current) == false)
                                    Console.WriteLine("Record not found.");
                                else
                                {
                                    Console.WriteLine("Record found");
                                    Console.WriteLine("Roll number: " + current.rollNumber);
                                    Console.WriteLine("Name :" + current.name);
                                }
                            }
                            break;
                        case '5':
                            return;
                        default:
                            {
                                Console.WriteLine("Invalid Option");
                                break;
                            }

                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Check for the value entered");
                }
            }   
        }
    }
    
}