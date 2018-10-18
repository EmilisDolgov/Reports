using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reports
{
    public class HtmlWriter
    {
        private Strategy _strategy;
        public HtmlWriter(Strategy strategy)
        {
            _strategy = strategy;
        }
        public void Write(Repository<Users> repository)
        {
            _strategy.WriteToHtml(repository);
        }

    }
    public abstract class Strategy
    {
        public abstract void WriteToHtml(Repository<Users> repository);
    }
    public class ByFirstName : Strategy
    {
        public override void WriteToHtml(Repository<Users> repository)
        {
            var users = repository.GetAll().ToList();
            users.Sort((a, b) => a.FirstName.CompareTo(b.FirstName));
            using (FileStream fs = new FileStream("orderedByFirstName.html", FileMode.Create))
            {
                using (StreamWriter w = new StreamWriter(fs, Encoding.UTF8))
                {
                    foreach (var u in users)
                    {
                        w.WriteLine("<HTML>");
                        w.WriteLine("<BODY>");
                        w.WriteLine($"<P>{u.FirstName} {u.LastName} {u.PhoneNumber}</P>");
                        w.WriteLine("</BODY>");
                        w.WriteLine("</HTML>");
                    }
                }
            }
        }
    }
    public class ByLastName : Strategy
    {
        public override void WriteToHtml(Repository<Users> repository)
        {
            var users = repository.GetAll().ToList();
            users.Sort((a, b) => a.LastName.CompareTo(b.LastName));
            using (FileStream fs = new FileStream("orderedByLastName.html", FileMode.Create))
            {
                using (StreamWriter w = new StreamWriter(fs, Encoding.UTF8))
                {
                    foreach (var u in users)
                    {
                        w.WriteLine("<HTML>");
                        w.WriteLine("<BODY>");
                        w.WriteLine($"<P>{u.FirstName} {u.LastName} {u.PhoneNumber}</P>");
                        w.WriteLine("</BODY>");
                        w.WriteLine("</HTML>");
                    }
                }
            }
        }
    }
}
