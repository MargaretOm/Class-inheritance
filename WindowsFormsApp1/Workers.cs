using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace WindowsFormsApp1
{
    [Serializable, DataContract]
    class Workers : Human
    {
        [DataMember]
        public string Post { get; set; }
        [DataMember]
        public string Salary { get; set; }
        [DataMember]
        public string LenghtOfService { get; set; }

        public Workers(string FIO, string Age, string Adress, string MaleOrFemale,
            string Post, string Salary, string LenghtOfService)
            : base(FIO, Age, Adress, MaleOrFemale)
        {
            this.Post = Post;
            this.Salary = Salary;
            this.LenghtOfService = LenghtOfService;
        }
    }
}
