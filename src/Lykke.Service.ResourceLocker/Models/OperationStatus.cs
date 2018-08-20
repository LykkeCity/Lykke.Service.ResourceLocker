using System;
using System.Collections.Generic;
using System.Text;

namespace Lykke.Service.ResourceLocker.Models
{
    public class OperationStatus
    {
        public bool Error { get; internal set; }
        public string Message { get; internal set; }
    }
}
