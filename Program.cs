using Examples;
using Engineless;

if (args.Count() == 0) {
    Console.WriteLine("Please provide the example to run");
    System.Environment.Exit(1);
}

var exampleToRun = args[0];



if (exampleToRun == "Simple") {
    void SimpleSystem(Query<(Wrapper<int>, String)> q) {
        foreach (var hit in q.hits) {
            // Retrieve the parts of the query
            var (intWrapper, str) = hit.Value;
            Console.WriteLine("Entity ID: " + hit.Key);
            Console.WriteLine("intWrapper: " + intWrapper.item + ", str: " + str);
            // Increment each query
            intWrapper.item += 1;
        }
    }
    
    Engine ecs = new();
    
    ecs.AddEntity(new List<Object>() {
        new Wrapper<int>() { item = 0 },
        "Hi Mark!",
    });
    
    ecs.AddSystem(Event.Update, SimpleSystem);
    ecs.Start();
}



else if (exampleToRun == "Advanced") {var e = new Advanced(); e.Example();}
else { Console.WriteLine("Please provide which example to run in command line arguments"); }

