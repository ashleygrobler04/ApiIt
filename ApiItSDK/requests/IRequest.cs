using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Threading.Tasks;

namespace lib.requests
{
    public interface IRequest
    {
        Task<T> GetData<T>(string url);
        Task PostData<T>(T data, string url);
        Task PutData<T>(T data, string url);
        Task DeleteData(string url);
        Task PatchData<T>(T data, string url);
    }
}
