using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Patterns_Design
{
    public class ThreadTest
    {
        public void RunTask()
        {
            Console.WriteLine();
            Console.WriteLine("Output RunTask");

            Task<Int32[]> parent = new Task<Int32[]>(() =>
            {
                var cts = new CancellationTokenSource();
                var results = new Int32[3];
                new Task(() => results[0] = ThreadTest.Sum(cts.Token, 10000), TaskCreationOptions.AttachedToParent).Start();
                new Task(() => results[1] = ThreadTest.Sum(cts.Token, 20000), TaskCreationOptions.AttachedToParent).Start();
                new Task(() => results[2] = ThreadTest.Sum(cts.Token, 30000), TaskCreationOptions.AttachedToParent).Start();
                return results;
            });

            var cwt = parent.ContinueWith(parentTast => Array.ForEach(parentTast.Result, Console.WriteLine));
            parent.Start();
        }

        public void TestFactory()
        {
            Task parent = new Task(() =>
            {
                var cts = new CancellationTokenSource();
                var taskFactory = new TaskFactory<Int32>(cts.Token, TaskCreationOptions.AttachedToParent,
                    TaskContinuationOptions.ExecuteSynchronously, TaskScheduler.Default);
                var childTasks = new[]
                {
                    taskFactory.StartNew(() => ThreadTest.Sum(cts.Token, 1150)),
                    taskFactory.StartNew(() => ThreadTest.Sum(cts.Token, 3000)),
                    taskFactory.StartNew(() => ThreadTest.Sum(cts.Token, 5000))
                };

                for (int task = 0; task < childTasks.Length; task++)
                {
                    childTasks[task].ContinueWith(t=>cts.Cancel(),TaskContinuationOptions.OnlyOnFaulted);
                }

                taskFactory.ContinueWhenAll(childTasks,
                    completedTasks => completedTasks.Where(t =>
                        !t.IsFaulted && !t.IsCanceled).Max(t => t.Result), CancellationToken.None)
                    .ContinueWith(t => Console.WriteLine("The maximum is : {0} -", t.Result),
                        TaskContinuationOptions.ExecuteSynchronously);
            });

            parent.ContinueWith(p =>
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("The following exception occurred:" + Environment.NewLine);
                foreach (var e in p.Exception.Flatten().InnerExceptions)
                {
                    sb.AppendLine(" " + e.GetType().ToString());
                }
                Console.WriteLine(sb.ToString());
            }, TaskContinuationOptions.OnlyOnFaulted);

            parent.Start();
        }

        public static Int32 Sum(CancellationToken ct, Int32 input)
        {
            Int32 sum = 0;
            for (; input > 0; input--)
            {
                ct.ThrowIfCancellationRequested();
                checked
                {
                    sum += input;
                }
            }
            return sum;
        }
    }
}
