using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace WindowsFormsApp1
{
    [Serializable, DataContract]
    class Student : Human
    {
        [DataMember]
        public string Course { get; set; }
        [DataMember]
        public string Speciality { get; set; }
        [DataMember]
        public string Group { get; set; }
        [DataMember]
        public string TypeOfLearning { get; set; }
        [DataMember]
        public string FreeOrPaid { get; set; }

        public Student(string FIO, string Age, string Adress, string MaleOrFemale, 
            string Course, string Speciality, string Group, string TypeOfLearning, string FreeOrPaid) 
            : base(FIO, Age, Adress, MaleOrFemale)
        {
            this.Course = Course;
            this.Speciality = Speciality;
            this.Group = Group;
            this.TypeOfLearning = TypeOfLearning;
            this.FreeOrPaid = FreeOrPaid;
        }
    }
}
