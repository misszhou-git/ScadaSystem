using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TulingScadaSystem.Models
{
    public class LogEntry:EntityBase
    {
        private DateTime _timestamp;

        public DateTime Timestamp
        {
            get => _timestamp;
            set => SetProperty(ref _timestamp, value);
        }

        private string _level;

        public string Level
        {
            get => _level;
            set => SetProperty(ref _level, value);
        }

        private string _logger;

        public string Logger
        {
            get => _logger;
            set => SetProperty(ref _logger, value);
        }
        private string _message;

        public string Message
        {
            get => _message;
            set => SetProperty(ref _message, value);
        }

        /// <summary>
        ///  2025-01-10 16:08:54.2585|ERROR|TulingScadaSystem.Helpers.GlobalConfig|数据读取失败 
        /// </summary>
        /// <param name="line"></param>
        /// <returns></returns>
        public static LogEntry Parse(string line)
        {
            try
            {
                var parts = line.Split('|');

                if (parts.Length >= 4)
                {
                    return new LogEntry()
                    {
                        Timestamp = DateTime.Parse(parts[0]),
                        Level = parts[1],
                        Logger = parts[2],
                        Message = parts[3]
                    };
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e); 
            }

            return null;
        }
    }
}
