using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace WindowsFormsApp1
{
    [Serializable, DataContract]
    class Human
    {
        [DataMember]
        public string FIO { get; set; }
        [DataMember]
        public string Age { get; set; }
        [DataMember]
        public string Adress { get; set; }
        [DataMember]
        public string MaleOrFemale { get; set; }

        public Human(string FIO, string Age, string Adress, string MaleOrFemale)
        {
            this.FIO = FIO;
            this.Age = Age;
            this.Adress = Adress;
            this.MaleOrFemale = MaleOrFemale;
        }
    }
}
