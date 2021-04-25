
using System;

namespace IMSCK.DAO
{
    public class ServiceResponse<T>
    {
        public T Data { get; set; }

        public bool Success { get; set; } = true;
        
        public string Message { get; set; } = null;

        public static implicit operator ServiceResponse<T>(ServiceResponse<object> v)
        {
            throw new NotImplementedException();
        }
    }
}
