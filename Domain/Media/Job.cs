using Domain.Users;
using System;

namespace Domain.Media
{
    //need to create a simple logical model
    public interface IJob
    {

    }

    public class Job : IJob
    {
        public User Initiator { get; protected set; }
        public DateTime Start { get; protected set; }
        public DateTime? Finish { get; protected set; }
        //public Progress Progress { get; protected set; }
    }

    public class JobId : Id
    {
        public JobId(uint id) : base(id) { }
    }
}
