using Ookii.CommandLine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealPlannerCmd
{
    internal class CommandLineArguments
    {
        [CommandLineArgument(Position = 1, IsRequired = true)]
        public CommandLineOperation Operation { get; set; }

        [CommandLineArgument(Position = 2, IsRequired = false)]
        public string RecipeName { get; set; }

        [CommandLineArgument(Position = 3, IsRequired = false)]
        public string NewRecipeName { get; set; }
    }

    internal enum CommandLineOperation
    {
        Add,
        Rename,
        Delete,
        List
    }
}
