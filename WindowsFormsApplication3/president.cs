using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication3
{
    [Serializable]
    class president
    {
        private int okrug;
        private string name;
        private DateTime date;
        private string prof;
        [NonSerialized]
        private DateTime date_create;

        public president() { }

        public president(int okrug, string name, DateTime date, string prof)
        {
            this.okrug = okrug;
            this.name = name;
            this.date = date;
            this.prof = prof;
            date_create = DateTime.Now;
        }
        public int Okrug
        {
            get { return okrug; }
            set { okrug = value; }
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public DateTime Date
        {
            get { return date; }
            set { date = value; }
        }
        public string Prof
        {
            get { return prof; }
            set { prof = value; }
        }
        public DateTime Date_create
        {
            get { return date_create; }
            set { date_create = value; }
        }
    }
}
