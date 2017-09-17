namespace CodingQuestions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ExclusiveTimePerFunction : ISolution
    {
        public class FuncInfo
        {
            public string Name { get; set; }

            public string Status { get; set; }

            public int Time { get; set; }
        }

        private List<FuncInfo> funcs = null;

        public ExclusiveTimePerFunction(List<string> input)
        {
            this.funcs = input.Select(x =>
            {
                string[] parts = x.Split(',');
                return new FuncInfo { Name = parts[0], Status = parts[1], Time = int.Parse(parts[2]) };
            }).ToList();
        }
        public void Run()
        {
            Dictionary<string, int> execTimes = new Dictionary<string, int>();
            List<string> funcOrder = new List<string>();
            Stack<FuncInfo> funcStack = new Stack<FuncInfo>();

            foreach (var func in this.funcs)
            {
                // check the status
                if (func.Status == "START")
                {
                    if (!funcOrder.Contains(func.Name))
                    {
                        funcOrder.Add(func.Name);
                    }

                    // Get the last element on the stack
                    if (funcStack.Count != 0)
                    {
                        var prevFunc = funcStack.Peek();
                        int execTime = func.Time - prevFunc.Time;

                        // Add to exec time
                        execTimes[prevFunc.Name] = execTime;
                    }

                    execTimes.Add(func.Name, 0);
                    funcStack.Push(func);
                }
                else
                {
                    var prevFunc = funcStack.Pop();
                    int execTime = func.Time - prevFunc.Time;

                    // Add to total time
                    int totalTime = execTimes[prevFunc.Name];
                    execTimes[prevFunc.Name] = totalTime + execTime;

                    // update last elements time to current time
                    if (funcStack.Count > 0)
                    {
                        funcStack.Peek().Time = func.Time;
                    }
                }
            }

            foreach (var f in funcOrder)
            {
                Console.WriteLine("Func {0}.Total Time {1}", f, execTimes[f]);
            }
        }
    }
}