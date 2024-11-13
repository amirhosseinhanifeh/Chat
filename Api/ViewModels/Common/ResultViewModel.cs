using Mozer.ViewModels.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mozer.ViewModels.Common
{
    public class ResultViewModel<TModel>
    {
        public NotificationType NotificationType { get; set; }
        public string Message { get; set; }
        public TModel Object { get; set; }
    }
}
