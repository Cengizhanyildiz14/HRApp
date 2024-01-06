using Cengo.AdvertisementApp.Common.Response;

namespace Cengo.AdvertisementApp.Common.Interfaces
{
    public interface IResponse
    {
        string Message { get; set; }
        ResponseType ResponseType { get; set; }
    }
}
