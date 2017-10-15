using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spider.Invoicing.API.Models
{
    public class Value
    {
        public Value() { }
        public Value(string key, string value)
        {
            Key = key;
            Data = value;
        }
        public string Key { get; set; }
        public string Data { get; set; }
    }
}
