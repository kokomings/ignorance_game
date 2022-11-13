using System;
using System.Collections.Generic;

namespace MonsterFaction
{
    public class Logger
    {
        private static readonly Logger log = new();
        public static Logger Log => log;
        public readonly List<Log> occurredLogs = new();

        private Logger() { }

        public void Information(string text)
        {
            occurredLogs.Add(new Log(text));
            Console.WriteLine(text);
        }
    }

    public class Log
    {
        private readonly string text;
        public string Text => text;

        public Log(string text)
        {
            this.text = text;
        }
    }
}
