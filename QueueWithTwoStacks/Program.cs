using System;
using System.Collections.Generic;

namespace QueueWithTwoStacks
{
    class Solution
    {

        class MyQueue1
        {
            private readonly Stack<int> stack1 = new Stack<int>();
            private readonly Stack<int> stack2 = new Stack<int>();
            private Commands LastCommand = Commands.none;
            private int? PeekValue = null;

            private enum Commands
            {
                none,
                enqueue,
                dequeue,
                peek
            }

            internal void Enqueue(int value)
            {

                if (LastCommand != Commands.enqueue)
                {
                    FlipStacks();
                }

                if (stack2.Count == 0)
                {
                    stack1.Push(value);
                }
                else
                {
                    stack2.Push(value);
                }

                LastCommand = Commands.enqueue;

                if (PeekValue == null)
                {
                    PeekValue = value;
                }
            }
            internal int Dequeue()
            {
                if (LastCommand == Commands.enqueue)
                {
                    FlipStacks();
                }

                LastCommand = Commands.dequeue;

                int pop;
                if (stack1.Count > 0)
                {
                    pop = stack1.Pop();
                    if (stack1.Count > 0)
                        PeekValue = stack1.Peek();
                    else
                        PeekValue = null;
                }
                else
                {
                    pop = stack2.Pop();
                    if (stack2.Count > 0)
                        PeekValue = stack2.Peek();
                    else
                        PeekValue = null;
                }

                return pop;
            }
            internal int Peek()
            {
                return PeekValue ?? 0;
            }
            private void FlipStacks()
            {
                if (stack1.Count == 0)
                {
                    while (stack2.Count > 0)
                    {
                        stack1.Push(stack2.Pop());
                    }
                }
                else
                {
                    while (stack1.Count > 0)
                    {
                        stack2.Push(stack1.Pop());
                    }
                }
            }

        }
        class MyQueue2
        {
            private readonly Stack<int> stack1 = new Stack<int>();
            private readonly Stack<int> stack2 = new Stack<int>();
            private Commands LastCommand = Commands.none;

            private enum Commands
            {
                none,
                enqueue,
                dequeue,
                peek
            }

            internal void Enqueue(int value)
            {

                if ( LastCommand != Commands.enqueue)
                {
                    FlipStacks();
                }

                if (stack2.Count == 0)
                {
                    stack1.Push(value);
                }
                else
                {
                    stack2.Push(value);
                }

                LastCommand = Commands.enqueue;
            }
            internal int Dequeue()
            {
                if (LastCommand == Commands.enqueue)
                {
                    FlipStacks();
                }

                LastCommand = Commands.dequeue;

                if (stack1.Count > 0)
                {
                    return stack1.Pop();
                }
                else
                {
                    return stack2.Pop();
                }
            }
            internal int Peek()
            {
                if (LastCommand == Commands.enqueue)
                {
                    FlipStacks();
                }

                LastCommand = Commands.peek;

                if (stack1.Count > 0)
                {
                    return stack1.Peek();
                }
                else
                {
                    return stack2.Peek();
                }

            }
            private void FlipStacks()
            {
                if (stack1.Count == 0)
                {
                    while (stack2.Count > 0)
                    {
                        stack1.Push(stack2.Pop());
                    }
                }
                else
                {
                    while (stack1.Count > 0)
                    {
                        stack2.Push(stack1.Pop());
                    }
                }
            }

        }

        class MyQueue3
        {
            private Queue<int> queue = new Queue<int>();
            
            public void Enqueue ( int value)
            {
                queue.Enqueue(value);
            }
            public int Dequeue ()
            {
                return queue.Dequeue();
            }
            public int Peek()
            {
                return queue.Peek();
            }
        }

        class MyQueue<T>
        {
            Stack<T> stack1 = new Stack<T>();
            Stack<T> stack2 = new Stack<T>();
            public void Enqueue(T value)
            {
                if (stack2.Count == 0 && stack1.Count == 0)
                    stack1.Push(value);
                else
                    stack2.Push(value);
            }

            public T Dequeue() {
                if (stack1.Count == 0)
                    MoveStack();
                return stack1.Pop();
            }

            public T Peek()  {

                if (stack1.Count == 0)
                   MoveStack();
                return stack1.Peek();
            }

            void MoveStack()
            {
                while (stack2.Count==0)
                {
                    stack1.Push(stack2.Pop());
                }
            }
        }

        static void Main(string[] args)
        {
            // Queue
            MyQueue<int> queue = new MyQueue<int>();
            //MyQueue1 queue = new MyQueue1();

            // Commands;
            string[] command;

            // Read first stdIn line - number of queries
            string inLine = Console.ReadLine();

            // Try to parse line - q = number of queries
            if (Int32.TryParse(inLine, out int q))
            {
                // Loop q times
                for (int i = 0; i < q; i++)
                {
                    // Read input line
                    inLine = Console.ReadLine();

                    // Parse line by space separator
                    command = inLine.Split(' ');

                    // Check command
                    switch (command[0])
                    {
                        case "1":
                            // Try parse number
                            if (command[1].Length > 0)
                            {
                                if (Int32.TryParse(command[1], out int x))
                                {
                                    // Enqueue
                                    queue.Enqueue(x);
                                }
                                else
                                {
                                    throw new ArgumentException("Line with command 1 must have another integer");
                                }
                            }
                            else
                            {
                                throw new ArgumentException("Line with command 1 must have another integer");
                            }
                            break;

                        case "2":
                            // Dequeue;
                            queue.Dequeue();
                            break;

                        case "3":
                            // Print Peek;
                            Console.WriteLine(queue.Peek());
                            break;
                    }
                }
            }
            else
            {
                Console.WriteLine("FirstLine must contain an integer with number of queries");
            }
        }
    }
}
