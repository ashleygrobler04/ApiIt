using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Threading.Tasks;

using Newtonsoft.Json.Linq;
namespace lib.requests
{
    public interface IRequest
    {
        Task<Result<JObject>> GetData(string url);
        Task<Result<T>> PostData<T>(T data, string url);
        Task<Result<T>> PutData<T>(T data, string url);
        Task<Result<T>> DeleteData<T>(string url);
        Task <Result<T>>PatchData<T>(T data, string url);
    }
}
