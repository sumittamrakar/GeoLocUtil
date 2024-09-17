using GeoLocUtility.Models;
using System.Threading.Tasks;

namespace GeoLocUtility.Services;

public interface IGeocodingService
{
    Task<GeocodingResponse> GetCoordinates(LocationInputType location);
}
