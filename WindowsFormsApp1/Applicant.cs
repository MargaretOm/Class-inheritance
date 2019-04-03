using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace WindowsFormsApp1
{
    [Serializable, DataContract]
    class Applicant : Human
    {
        [DataMember]
        public string WantSpeciality { get; set; }
        [DataMember]
        public string Points { get; set; }

        public Applicant(string FIO, string Age, string Adress, string MaleOrFemale,
            string WantSpeciality, string Points)
            : base(FIO, Age, Adress, MaleOrFemale)
        {
            this.WantSpeciality = WantSpeciality;
            this.Points = Points;
        }
    }
}
