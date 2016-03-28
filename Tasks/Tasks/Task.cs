using System;

namespace Tasks.Tasks
{
    public class Task
    {
        public static Task Create(string name, string description)
        {
            return new Task(Guid.NewGuid(), name, description);
        }

        public Task()
        {
            
        }

        private Task(Guid id, string name, string description)
        {
            Id = id;
            Name = name;
            Description = description;
        }

        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
    }
}
