using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RegistryDemo.Models
{
    public class RegisteredObject
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Version { get; set; }
        public string Platform { get; set; }
        public string Min_platform { get; set; }
        public string Source { get; set; }
        public string Jurisdiction { get; set; }
        public string User_authn { get; set; }
        public long DateRegistered { get; set; }
        public string Url { get; set; }
        public string Trust_registry { get; set; }
    }
}
