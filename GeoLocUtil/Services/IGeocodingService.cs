using GeoLocUtil.Models;
using System.Threading.Tasks;

namespace GeoLocUtil.Services;

public interface IGeocodingService
{
    Task<BaseResponse> GetCoordinates(LocationInputType location);
}
