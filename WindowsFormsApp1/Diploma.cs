using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace WindowsFormsApp1
{
    [Serializable, DataContract]
    class Diploma
    {
        [DataMember]
        public string Theme { get; set; }
        [DataMember]
        public string DateOfDelivery { get; set; }
        [DataMember]
        public string NameProfessor { get; set; }

        public Diploma(string Theme, string DateOfDelivery, string NameProfessor)
        {
            this.Theme = Theme;
            this.DateOfDelivery = DateOfDelivery;
            this.NameProfessor = NameProfessor;
        }
    }
}
