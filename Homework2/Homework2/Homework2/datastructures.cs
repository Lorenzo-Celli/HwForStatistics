using System;
using System.Collections.Generic;
using System.Collections.Specialized;

class Program
{
    static void Main()
    {
        // Array
        int[] array = { 1, 2, 3, 4, 5 };

        // Loop
        foreach (int item in array)
        {
            Console.WriteLine(item);
        }

        // Add an element (not possible to add dynamically to an array)

        // Remove an element (not dynamically supported in arrays)

        // Get an element
        int elementFromArray = array[2];

        // Check the existence of an element
        bool existsInArray = Array.Exists(array, item => item == 3);

        // List
        List<int> list = new List<int> { 1, 2, 3, 4, 5 };

        // Loop
        foreach (int item in list)
        {
            Console.WriteLine(item);
        }

        // Add an element
        list.Add(6);

        // Remove an element
        list.Remove(3);

        // Get an element
        int elementFromList = list[2];

        // Check the existence of an element
        bool existsInList = list.Contains(5);

        // Dictionary
        Dictionary<string, int> dictionary = new Dictionary<string, int>();

        // Loop
        foreach (var kvp in dictionary)
        {
            Console.WriteLine($"{kvp.Key}: {kvp.Value}");
        }

        // Add an element
        dictionary["One"] = 1;

        // Remove an element
        dictionary.Remove("Three");

        // Get an element
        bool hasKey = dictionary.TryGetValue("One", out int value);
        int valueFromDictionary = value;

        // Check the existence of an element
        bool keyExists = dictionary.ContainsKey("Two");

        // SortedList (similar to Dictionary)
        SortedList<int, string> sortedList = new SortedList<int, string>();

        // HashSet
        HashSet<int> hashSet = new HashSet<int> { 1, 2, 3, 4, 5 };

        // Loop
        foreach (int item in hashSet)
        {
            Console.WriteLine(item);
        }

        // Add an element
        hashSet.Add(6);

        // Remove an element
        hashSet.Remove(3);

        // Get an element (not directly supported in HashSet)

        // Check the existence of an element
        bool existsInHashSet = hashSet.Contains(5);

        // SortedSet (similar to HashSet)
        SortedSet<int> sortedSet = new SortedSet<int> { 5, 4, 3, 2, 1 };

        // Loop
        foreach (int item in sortedSet)
        {
            Console.WriteLine(item);
        }

        // Add an element
        sortedSet.Add(6);

        // Remove an element
        sortedSet.Remove(3);

        // Get an element (not directly supported in SortedSet)

        // Check the existence of an element
        bool existsInSortedSet = sortedSet.Contains(4);

        // Queue
        Queue<int> queue = new Queue<int>();

        // Loop (not directly supported in Queue)

        // Add an element
        queue.Enqueue(1);

        // Remove an element
        int dequeuedItem = queue.Dequeue();

        // Get an element (not directly supported in Queue)

        // Check the existence of an element (not directly supported in Queue)

        // Stack
        Stack<int> stack = new Stack<int>();

        // Loop (not directly supported in Stack)

        // Add an element
        stack.Push(1);

        // Remove an element
        int poppedItem = stack.Pop();

        // Get an element (not directly supported in Stack)

        // Check the existence of an element (not directly supported in Stack)

        // LinkedList
        LinkedList<int> linkedList = new LinkedList<int>();

        // Loop
        foreach (int item in linkedList)
        {
            Console.WriteLine(item);
        }

        // Add an element
        linkedList.AddLast(1);

        // Remove an element
        linkedList.Remove(2);

        // Get an element
        int elementFromLinkedList = linkedList.First.Value;

        // Check the existence of an element
        bool existsInLinkedList = linkedList.Contains(1);
    }
}
