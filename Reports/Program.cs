using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reports
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new PeopleContext())
            {
                var usersRepo = new Repository<Users>(db);
                var writerFN = new HtmlWriter(new ByFirstName());
                writerFN.Write(usersRepo);
                var writerLN = new HtmlWriter(new ByLastName());
                writerLN.Write(usersRepo);
                
            }
            
        }
    }
}
