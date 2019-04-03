using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace WindowsFormsApp1
{
    [Serializable, DataContract]
    class StudentLastCourse : Student
    {
        [DataMember]
        public string Distribution { get; set; }

        [DataMember]
        public Diploma Diploma { get; set; }

        public StudentLastCourse(string FIO, string Age, string Adress, string MaleOrFemale, string Course, string Speciality, string Group, string TypeOfLearning, string FreeOrPaid,
            string Distribution, Diploma Diploma)
            : base(FIO, Age, Adress, MaleOrFemale, Course, Speciality, Group, TypeOfLearning, FreeOrPaid)
        {
            this.Distribution = Distribution;
            this.Diploma = Diploma;
        }
    }
}
