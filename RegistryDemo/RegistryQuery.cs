using System;

namespace RegistryDemo
{
    public class RegistryQuery
    {
        public DateTime Date { get; set; }

        public int Name { get; set; }

        public int Version => 32 + (int)(Name / 0.5556);

        public string Summary { get; set; }
    }
}
