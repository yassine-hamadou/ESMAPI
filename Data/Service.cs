using System;
using System.Collections.Generic;

namespace ServiceManagerApi.Data
{
    public partial class Service
    {
        public Service()
        {
            FleetSchedules = new HashSet<FleetSchedule>();
            Sections = new HashSet<Section>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Model { get; set; }

        public virtual Model? ModelNavigation { get; set; }
        public virtual ICollection<FleetSchedule> FleetSchedules { get; set; }
        public virtual ICollection<Section> Sections { get; set; }
    }
}
