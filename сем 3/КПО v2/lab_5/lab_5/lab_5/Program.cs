using System.Security.Cryptography.X509Certificates;
using System.Collections;
using System.Collections.Generic;

namespace lab_5
{
    struct stud
    {
        public string NAME;
        public int NUM;

        public stud()
        {
            NAME = "";
            NUM = 0;
        }
    }
        public class Node<T>
    {
        public Node(T data)
        {
            Data = data;
        }
        public T Data { get; set; }
        public Node<T> Next { get; set; }
    }
    namespace SimpleAlgorithmsApp
    {
        public class Queue<T> : IEnumerable<T>
        {
            Node<T> head; // головной/первый элемент
            Node<T> tail; // последний/хвостовой элемент
            int count;
            // добавление в очередь
            public void Enqueue(T data)
            {
                Node<T> node = new Node<T>(data);
                Node<T> tempNode = tail;
                tail = node;
                if (count == 0)
                    head = tail;
                else
                    tempNode.Next = tail;
                count++;

            }
            // удаление из очереди
            public T Dequeue()
            {
                if (count == 0)
                    throw new InvalidOperationException();
                T output = head.Data;
                head = head.Next;
                count--;
                return output;
            }
            // получаем первый элемент
            public T First
            {
                get
                {
                    if (IsEmpty)
                        throw new InvalidOperationException();
                    return head.Data;
                }
            }
            // получаем последний элемент
            public T Last
            {
                get
                {
                    if (IsEmpty)
                        throw new InvalidOperationException();
                    return tail.Data;
                }
            }
            public int Count { get { return count; } }
            public bool IsEmpty { get { return count == 0; } }
            public void Clear()
            {
                head = null;
                tail = null;
                count = 0;
            }
            public bool Contains(T data)
            {
                Node<T> current = head;
                while (current != null)
                {
                    if (current.Data.Equals(data))
                        return true;
                    current = current.Next;

                }
                return false;
            }
            IEnumerator IEnumerable.GetEnumerator()
            {
                return ((IEnumerable)this).GetEnumerator();
            }
            IEnumerator<T> IEnumerable<T>.GetEnumerator()
            {
                Node<T> current = head;
                while (current != null)
                {
                    yield return current.Data;
                    current = current.Next;
                }
            }
        }
    }

    internal static class Program
    {
       
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }
    }
}