using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_manager.TaskFactories
{
    abstract class TaskFactory
    {
        public abstract Task CreateTask();
    }

    class SimpleTaskFactory : TaskFactory
    {
        public override Task CreateTask() => new SimpleTask();
    }

    class ReminderFactory : TaskFactory
    {
        public override Task CreateTask() => new Reminder();

    }

    class ReccuringSimpleTaskFactory : TaskFactory
    {
        public override Task CreateTask() => new ReccuringSimpleTask();
    }

    class ProgressTaskFactory : TaskFactory
    {
        public override Task CreateTask() => new ProgressTask();
    }

    class PriorityTaskFactory : TaskFactory
    {
        public override Task CreateTask() => new PriorityTask();
    }

    //class ReccuringReminderFactory : ITaskFactory
    //{
    //    public Task CreateTask() => new ReccuringReminder();
    //}

    //class VoiceReminderFactory : ITaskFactory
    //{
    //    public Task CreateTask() => new VoiceReminder();
    //}
}
