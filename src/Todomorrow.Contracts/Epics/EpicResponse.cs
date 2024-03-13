using System;

namespace Todomorrow.Contracts.Epics
{
    public class EpicResponse
    {
        public Guid ProjectId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
