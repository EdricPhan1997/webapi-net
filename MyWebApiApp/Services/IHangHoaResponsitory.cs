using MyWebApiApp.Models;
using System.Collections.Generic;

namespace MyWebApiApp.Services
{
    public interface IHangHoaResponsitory
    {
        List<HangHoaModel> GetAll(string search, double? from, double? to, string sortBy, int page = 1);

    }
}
