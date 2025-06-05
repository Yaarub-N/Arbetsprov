using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetNextNumber.Services
{
    public interface IRequestService
    {

        Task<string> SendRequestAsync(string xml, string action);
    }
}
