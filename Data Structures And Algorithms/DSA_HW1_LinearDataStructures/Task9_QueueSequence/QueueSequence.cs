using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task9_QueueSequence
{
    public static class QueueSequence
    {
        public static void GenerateQueueSequence<T>(T seed, int membersLimit)
        {
            Queue<T> template = new Queue<T>();
            List<T> result = new List<T>();

            template.Enqueue(seed);
            for (int i = 0; i < membersLimit; i++)
			{
                dynamic current = template.Dequeue();
                Console.Write(current + " ");

                template.Enqueue(current + 1);
                template.Enqueue(2 * current + 1);
                template.Enqueue(current + 2);
			}
        }

        public static void Main()
        {
            GenerateQueueSequence<int>(2, 50);

            //Console.WriteLine();
            //GenerateQueueSequence<double>(2.5, 40);
        }
    }
}
