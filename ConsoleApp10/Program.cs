using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp10
{
    public abstract class Command
    {
        public string CommandName { get; set; }
        public IDictionary<string, object> Params { get; set; }
        public abstract void ParseParamsString(string data);
        public abstract object Execute(string Params);
        
    }

    public class GetUser : Command
    {

        private string[] ParamList = new string[]
        {
            "_fn",
            "_e",
            "_s",
            "_l"
        };
      
        public GetUser()
        {
            this.CommandName = "GetUser";
            this.Params = new Dictionary<string, object>();
        }
        public override object Execute(string Params)
        {
            ParseParamsString(Params);
            foreach(KeyValuePair<string,object> item in this.Params)
            {
                Console.WriteLine($"{item.Key}:{item.Value}");
            }
            return null;
        }

        public override void ParseParamsString(string data)
        {
            string[] parsed = data.Split(' ');
            string current = String.Empty;
            foreach(string param in parsed)
            {
                if (ParamList.Contains(param))
                {
                    
                    current = param;
                    this.Params.Add(param, null);
                }
                else
                {
                    if (current != String.Empty)
                    {
                        Params[current] += param.Trim();
                    }
                    
                }

            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Write command:");
            string cmd = Console.ReadLine();
            Command command = new GetUser();

            command.Execute(cmd);
            Console.ReadKey();
        }
    }
}
