using photoniced.common;
using photoniced.essentials;
using photoniced.essentials.ConsoleUnitWrapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace photoniced.device.services
{
    public class UserInputService
    {
        static public DeviceUserEntry get_user_entry(IConsole internConsole)
        {
            var user = new UserInput();
            var move = new MoveFilesExpression();
            move.Interpreter(user, internConsole);

            if (user.Error.Count > 0)
            {
                foreach (var error in user.Error)
                    Console.WriteLine(error);
                Console.ReadLine();
                return new DeviceUserEntry();
            }
            return new DeviceUserEntry
            {
                SortWord = user.Result["FolderName"] as string,
                Description = user.Result["description"] as string,
                SortTime = (DateTime)user.Result["SortDay"]
            };
        }


    }
}
