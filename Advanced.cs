using Engineless;

// Test ECS
namespace Examples {
    class Advanced {
        void StartupSystem(IECS ecs) {
            Console.WriteLine("Starting it up with the startup system");
            ecs.AddEntity(new List<Object>() {
                new DuckAspects() { greatQuack = "QUACK QUACK QUACK 🦜"},
                new Counter(),
            });
        }
    
        void SuperSystem(Query<(DuckAspects, Counter)> q) {
            foreach (var hit in q.hits) {
                var (duckAspects, counter) = hit.Value;
                Console.WriteLine("Quack: " + duckAspects.greatQuack);
                Console.WriteLine("Count: " + counter.counter);
                Console.WriteLine("EntityId: " + hit.Key);
                counter.counter += 1;
            }
        }
    
        public void Example() {
            Engine ecs = new();
            ecs.AddEntity(new List<Object>() {
                new DuckAspects() { greatQuack = "kvitter kvitter 🐔" },
            });
            ecs.AddSystem(Event.Startup, StartupSystem);
            ecs.AddSystem(Event.Update, SuperSystem);
            ecs.Start();
        }
    }
    
    class DuckAspects {
        public DuckAspects() {}
        public String greatQuack = "";
    }

    class Counter {
        public Counter() {}
        public int counter = 0;
    }
}
