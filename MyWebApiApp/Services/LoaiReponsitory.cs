using MyWebApiApp.Data;
using MyWebApiApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace MyWebApiApp.Services
{
    public class LoaiReponsitory : ILoaiReponsitory
    {
        private readonly MyDBContext _context;

        // inject
        public LoaiReponsitory(MyDBContext context)
        {
            _context = context;
        }
        public LoaiVM Add(LoaiModel loai)
        {
            var _loai = new Loai
            {
                TenLoai = loai.TenLoai,
            };

            _context.Add(_loai);
            _context.SaveChanges();

            return new LoaiVM
            {
                MaLoai = _loai.MaLoai,
                TenLoai = loai.TenLoai,

            };
        }

        public void Delete(int id)
        {
            var loai = _context.Loais.FirstOrDefault(lo => lo.MaLoai == id);

            if (loai != null)
            {
                _context.Remove(loai);
                _context.SaveChanges();
            }
        }

        public List<LoaiVM> GetAll()
        {
            var loais = _context.Loais.Select(lo => new LoaiVM
            {
                MaLoai = lo.MaLoai,
                TenLoai = lo.TenLoai,
            });
            return loais.ToList();
        }

        public LoaiVM GetById(int id)
        {
            var loai = _context.Loais.FirstOrDefault(lo => lo.MaLoai == id);
            if (loai != null)
            {
                return new LoaiVM
                {
                    MaLoai = loai.MaLoai,
                    TenLoai = loai.TenLoai,
                };
            }
            return null;
        }

        public void Update(LoaiVM loai)
        {
            var _loai = _context.Loais.FirstOrDefault(lo => lo.MaLoai == loai.MaLoai);
            loai.TenLoai = _loai.TenLoai;
            _context.SaveChanges();


        }
    }
}
