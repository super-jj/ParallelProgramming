﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ParallelProgramming.Semaphores
{
    class Program
    {
        static void Main(string[] args)
        {
            var semaphore = new SemaphoreSlim(2,10);
            for (int i = 0; i < 20; i++)
            {
                Task.Factory.StartNew(() =>
                {
                    Console.WriteLine($"Entering task : {Task.CurrentId}");
                    semaphore.Wait();
                    Console.WriteLine($"Processing task{Task.CurrentId}");
                });
            }

            while (semaphore.CurrentCount <= 2)
            {
                Console.WriteLine($"Semaphore Count: {semaphore.CurrentCount}");
                Console.ReadKey();
                semaphore.Release();
            }
        }
    }
}
