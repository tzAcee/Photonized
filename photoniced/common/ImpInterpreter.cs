using System;
using System.Collections.Generic;
using System.Text;

namespace photoniced.common
{

    public class UserInput : IContext
    {
        public IDictionary<string, object> Result { get; } = new Dictionary<string, object>();

        public IList<string> Error { get; } = new List<string>();
    }

    public class MoveFilesExpression : IExpression
    {
        public void Interpreter(IContext context)
        {

             const int DEFAULT_SPLIT = 3;
             context.Result.Add("Command", 1);
            Console.WriteLine("For which day you want to sort the pictures ? (DD / MM / YYYY)");
            var datetime = Console.ReadLine();
            var dateSplitted = datetime.Split('/');
            if (dateSplitted.Length != DEFAULT_SPLIT)
            {
                context.Error.Add("Invalid date format");
                return;
            }

            context.Result.Add("SortDay", new DateTime(Convert.ToInt32(dateSplitted[2]), Convert.ToInt32(dateSplitted[1]), Convert.ToInt32(dateSplitted[0])));



            Console.WriteLine("What did you do @ this day?");
            string toSort = Console.ReadLine();

            if (string.IsNullOrEmpty(toSort))
            {
                context.Error.Add("Empty name");
                return;
            }

            context.Result.Add("FolderName", toSort);


            Console.WriteLine("Give a little description for this day.");
            string desc = Console.ReadLine();

            context.Result.Add("description", desc);
        }
    }

}

 /*   public class MenuExpression
    {
        MoveFilesExpression MoveFile { get; }

        public void Interpreter(IContext context)
        {

            

        }

}*/
