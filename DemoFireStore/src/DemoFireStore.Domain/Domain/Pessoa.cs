using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoFireStore.Domain.Domain
{
    public class Pessoa:Base
    {
        [FirestoreProperty("Nome")]
        public string Nome { get; set; }
        [FirestoreProperty("Idade")]
        public int Idade { get; set; }
    }
}
