using System;
using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Collections
{
    class App
    {
        static void Main(string[] args)
        {
			//test object
            Ellipse testEllipse = new Ellipse(4.4, 1.6, 5.3);

			//ADD ELEMENT  -- ArrayList vs LinkedList        
			Stopwatch stopWatch = new Stopwatch();
			Random rand = new Random();
			ArrayList array = new ArrayList();
			stopWatch.Start();
            for (int i = 0; i < 500000; i++)
            {
                array.Add(new Ellipse((rand.Next(20) + rand.Next(20) * 0.1), (rand.Next(20) + rand.Next(20) * 0.1), (rand.Next(20) + rand.Next(20) * 0.1)));
            }
            array.Add(testEllipse);
            for (int i = 0; i < 500000; i++)
            {
                array.Add(new Ellipse((rand.Next(20) + rand.Next(20) * 0.1), (rand.Next(20) + rand.Next(20) * 0.1), (rand.Next(20) + rand.Next(20) * 0.1)));
            }            
            stopWatch.Stop();
            Console.WriteLine("Add Elements: TestTime for ArrayList - " + stopWatch.Elapsed);
            stopWatch.Reset();


			LinkedList<Ellipse> linkedList = new LinkedList<Ellipse>();
			stopWatch.Start();                      
            for (int i = 0; i < 500000; i++)
            {
                linkedList.AddLast(new Ellipse((rand.Next(20) + rand.Next(20) * 0.1), (rand.Next(20) + rand.Next(20) * 0.1), (rand.Next(20) + rand.Next(20) * 0.1)));
            }            
            linkedList.AddLast(testEllipse);
            for (int i = 0; i < 500000; i++)
            {
                linkedList.AddLast(new Ellipse((rand.Next(20) + rand.Next(20) * 0.1), (rand.Next(20) + rand.Next(20) * 0.1), (rand.Next(20) + rand.Next(20) * 0.1)));
            }
            stopWatch.Stop();
            Console.WriteLine("Add Elements: TestTime for LinkedList - " + stopWatch.Elapsed);
            stopWatch.Reset();

			Ellipse result = new Ellipse();
			//SEARCH ELEMENT --  ArrayList vs LinkedList               
			stopWatch.Start();
            array.Sort(new CustomEllipseComparer());
            int index = array.BinarySearch((object)testEllipse,new CustomEllipseComparer());
            result = (Ellipse)array[index];            
            stopWatch.Stop();
            Console.WriteLine("\nSearch Elements: TestTime for ArrayList - " + stopWatch.Elapsed);
            stopWatch.Reset();
                                  
            stopWatch.Start();
            result = (Ellipse)linkedList.Find(testEllipse).Value;            
            stopWatch.Stop();
            Console.WriteLine("Search Elements: TestTime for LinkedList - " + stopWatch.Elapsed);
            stopWatch.Reset();

            //REMOVE ELEMENT --  ArrayList vs LinkedList         
            stopWatch.Start();
            array.Remove(testEllipse);
            stopWatch.Stop();
            Console.WriteLine("\nRemove Elements: TestTime for ArrayList - " + stopWatch.Elapsed);
            stopWatch.Reset();

            stopWatch.Start();
            linkedList.Remove(testEllipse);
            stopWatch.Stop();
            Console.WriteLine("Remove Elements: TestTime for LinkedList - " + stopWatch.Elapsed);
            stopWatch.Reset();

			//ADD ELEMENT  -- Stack vs Queue       
			Stack<Ellipse> stack = new Stack<Ellipse>();
			stopWatch.Start();
            for (int i = 0; i < 5000; i++)
            {
                stack.Push(new Ellipse((rand.Next(20) + rand.Next(20) * 0.1), (rand.Next(20) + rand.Next(20) * 0.1), (rand.Next(20) + rand.Next(20) * 0.1)));
            }
            stack.Push(testEllipse);
            for (int i = 0; i < 5000; i++)
            {
                stack.Push(new Ellipse((rand.Next(20) + rand.Next(20) * 0.1), (rand.Next(20) + rand.Next(20) * 0.1), (rand.Next(20) + rand.Next(20) * 0.1)));
            }
            stopWatch.Stop();
            Console.WriteLine("\nAdd Elements: TestTime for Stack - " + stopWatch.Elapsed);
            stopWatch.Reset();

			Queue<Ellipse> queue = new Queue<Ellipse>();
			stopWatch.Start();
            for (int i = 0; i < 5000; i++)
            {
                queue.Enqueue(new Ellipse((rand.Next(20) + rand.Next(20) * 0.1), (rand.Next(20) + rand.Next(20) * 0.1), (rand.Next(20) + rand.Next(20) * 0.1)));
            }
            queue.Enqueue(testEllipse);
            for (int i = 0; i < 5000; i++)
            {
                queue.Enqueue(new Ellipse((rand.Next(20) + rand.Next(20) * 0.1), (rand.Next(20) + rand.Next(20) * 0.1), (rand.Next(20) + rand.Next(20) * 0.1)));
            }
            stopWatch.Stop();
            Console.WriteLine("Add Elements: TestTime for Queue - " + stopWatch.Elapsed);
            stopWatch.Reset();


            //SEARCH ELEMENT --  Stack vs Queue         
            CustomEllipseComparer circleComparer = new CustomEllipseComparer(); 

            stopWatch.Start();
            for (int i = 0; i < 10000; i++)
            {
                if (circleComparer.Compare(testEllipse, stack.ElementAt(i)) == 0)
                    result = stack.ElementAt(i);
            }            
            stopWatch.Stop();
            Console.WriteLine("\nSearch Elements: TestTime for Stack - " + stopWatch.Elapsed);
            stopWatch.Reset();

            stopWatch.Start();
            for (int i = 0; i < 10000; i++)
            {
                if (circleComparer.Compare(testEllipse, queue.ElementAt(i)) == 0)
                    result = queue.ElementAt(i);
            }
            stopWatch.Stop();
            Console.WriteLine("Search Elements: TestTime for Queue - " + stopWatch.Elapsed);
            stopWatch.Reset();


            //REMOVE ELEMENT --  Stack vs Queue         
            stopWatch.Start();
            stack.Pop();
            stopWatch.Stop();
            Console.WriteLine("\nRemove Elements: TestTime for Stack - " + stopWatch.Elapsed);
            stopWatch.Reset();

            stopWatch.Start();
            queue.Dequeue();
            stopWatch.Stop();
            Console.WriteLine("Remove Elements: TestTime for Queue - " + stopWatch.Elapsed);
            stopWatch.Reset();

			//ADD ELEMENT  -- HashTable vs Dictionary     
			Dictionary<int, Ellipse> dictionary = new Dictionary<int, Ellipse>();
			Hashtable hashTable = new Hashtable();
			stopWatch.Start();
            for (int i = 0; i < 1000000; i++)
            {
                hashTable.Add(i, new Ellipse((rand.Next(20) + rand.Next(20) * 0.1), (rand.Next(20) + rand.Next(20) * 0.1), (rand.Next(20) + rand.Next(20) * 0.1)));
            }
            stopWatch.Stop();
            Console.WriteLine("\nAdd Elements: TestTime for HashTable - " + stopWatch.Elapsed);
            stopWatch.Reset();


            stopWatch.Start();
            for (int i = 0; i < 1000000; i++)
            {
                dictionary.Add(i, new Ellipse((rand.Next(20) + rand.Next(20) * 0.1), (rand.Next(20) + rand.Next(20) * 0.1), (rand.Next(20) + rand.Next(20) * 0.1)));
            }
            stopWatch.Stop();
            Console.WriteLine("Add Elements: TestTime for Dictionary - " + stopWatch.Elapsed);
            stopWatch.Reset();

            //SEARCH ELEMENT --  HashTable vs Dictionary         
            stopWatch.Start();
            result = (Ellipse)hashTable[500000];
            stopWatch.Stop();
            Console.WriteLine("\nSearch Elements: TestTime for Hashtable - " + stopWatch.Elapsed);
            stopWatch.Reset();

            stopWatch.Start();
            result = (Ellipse)dictionary[500000];
            stopWatch.Stop();
            Console.WriteLine("Search Elements: TestTime for Dictionary - " + stopWatch.Elapsed);
            stopWatch.Reset();

         
            //REMOVE ELEMENT  -- HashTable vs Dictionary            
            stopWatch.Start();
            hashTable.Remove(500000);
            stopWatch.Stop();
            Console.WriteLine("\nRemove Elements: TestTime for HashTable - " + stopWatch.Elapsed);
            stopWatch.Reset();

            stopWatch.Start();
            dictionary.Remove(500000);
            stopWatch.Stop();
            Console.WriteLine("Remove Elements: TestTime for Dictionary - " + stopWatch.Elapsed);
            stopWatch.Reset();


			Console.WriteLine("\nAll operations have ended. Press enter to exit");
			Console.ReadLine();
        }
    }
}
