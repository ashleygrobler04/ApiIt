using System;

namespace lib
{
    public class Result<T>
    {
        public bool IsSuccess { get; }
        public T Data { get; }

        public Result(bool isSuccess, T data)
        {
            this.IsSuccess = isSuccess;
            this.Data = data;
        }

        /// <summary>
        /// Use when you want an operation to be successfull.
        /// </summary>
        /// <param name="data"> The data you would like the result to contain</param>
        /// <returns>A Result object with the isSuccess set to true to indicate that the operation is completed. This object also contains the data, you can retreive it with Result.Data</returns>
        public static Result<T> Succeed(T data)
        {
            return new Result<T>(true, data);
        }

        /// <summary>
        /// Use to indicate that an operation has failed for some reason.
        /// </summary>
        /// <param name="data"> The data you would like to return once the operation failed.</param>
        /// <returns>A result object that has the isSuccess property set to false, indicating that the operation has failed. Contains the data for when the operation failed.</returns>
        public static Result<T> Fail(T data)
        {
            return new Result<T>(false, data);
        }
    }
}
