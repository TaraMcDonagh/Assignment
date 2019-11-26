using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment
{
    //Create a class called Activity with properties as shown in Table 1 (next page). 
    public enum ActivityType
    {
        Air,
        Water,
        Land
    }
    public class Activity : IComparable<Activity>
    {
        //These are my properties
        private string _description;
        public string Name { get; set; }

        public DateTime ActivityDate { get; set; }

        public decimal Cost { get; set; }
        public ActivityType Type { get; set; }

        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }
        //these are my constructers
        public Activity()
        {

        }
        public Activity(string name, string description, DateTime date, ActivityType type, decimal cost)
        {
            Name = name;
            Description = description;
            ActivityDate = date;
            Type = type;
            Cost = cost;
        }
        //Methods
        public override str
        //Implement IComparable to sort by date, utilised by both listboxes. 
        public int CompareTo(Activity other)
        {
            if (this.ActivityDate == other.ActivityDate)
            {
                return this.Name.CompareTo(other.Name);
            }
            return other.ActivityDate.CompareTo(this.ActivityDate);
        }
    }
}
