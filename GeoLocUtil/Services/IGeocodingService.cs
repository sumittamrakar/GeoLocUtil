using GeoLocUtil.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GeoLocUtil.Services
{
    public interface IGeocodingService
    {
        Task<string> GetCoordinates(LocationInputType location);
    }
}
