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
    }
    
}