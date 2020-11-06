
using System;

public sealed class Singleton  
    {  
        private Singleton()  
        {  
        }  
        private static Singleton instance = null;  
        public static Singleton Instance  
        {  
            get  
            {  
                if (instance == null)  
                {  
                    instance = new Singleton();  
                }  
                return instance;  
            }  
        }  
        public DateTime StartTime { get; set; }  
        public DateTime EndTime { get; set; }  
        public string Difference()  
        {  
            TimeSpan span = EndTime.Subtract ( StartTime );
            return "Total time spent: " +span.TotalSeconds + "s.";
        }   
    }  