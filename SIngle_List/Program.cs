﻿using System;

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
            
        }
    }
}