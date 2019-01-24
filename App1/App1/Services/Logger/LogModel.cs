using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App1.Services.Logger
{
    class LogModel
    {
        public DateTime Date { get; set; }
        public TypeOfLog TypeOfLog { get; set; }
        public string Comment { get; set; }

        public LogModel(TypeOfLog typeOfLog, string comment)
        {
            Date = DateTime.Now;
            TypeOfLog = typeOfLog;
            Comment = comment;
        }

        public override string ToString()
        {
            return String.Format("{0} {1} {2}", Date, TypeOfLog.GetStringValue(), Comment);
        }
    }

    public enum TypeOfLog
    {
        EXCEPTION,
        INFO
    }

    public static class TypeOfLogUseCase
    {
        public static string GetStringValue(this TypeOfLog typeOfLog)
        {
            switch(typeOfLog)
            {
                case TypeOfLog.EXCEPTION: return ">::EXCEPTION::<";
                case TypeOfLog.INFO: return ">::INFO::<";
                default: return ">::<";
            }
        }
    }
}
