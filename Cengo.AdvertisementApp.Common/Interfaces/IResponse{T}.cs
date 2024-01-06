using System.Collections.Generic;

namespace Cengo.AdvertisementApp.Common.Interfaces
{
    public interface IResponse<T> : IResponse
    {
        List<CustomValidationError> ValidationErrors { get; set; }
        T Data { get; set; }
    }
}
