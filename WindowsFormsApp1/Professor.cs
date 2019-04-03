using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace WindowsFormsApp1
{
    [Serializable, DataContract]
    class Professor : Workers
    {
        [DataMember]
        public string Subject { get; set; }
        [DataMember]
        public string Education { get; set; }

        public Professor(string FIO, string Age, string Adress, string MaleOrFemale, string Post, string Salary, string LenghtOfService,
            string Subject, string Education)
            : base(FIO, Age, Adress, MaleOrFemale, Post, Salary, LenghtOfService)
        {
            this.Subject = Subject;
            this.Education = Education;
        }
    }
}
