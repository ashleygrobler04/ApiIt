using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Threading.Tasks;

namespace lib.requests
{
    public interface IRequest
    {
        Task<Result<T>> GetData<T>(string url);
        Task<Result<T>> PostData<T>(T data, string url);
        Task<Result<T>> PutData<T>(T data, string url);
        Task<Result<T>> DeleteData<T>(string url);
        Task <Result<T>>PatchData<T>(T data, string url);
    }
}
