using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyWebApiApp.Models;  // => HangHoa
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyWebApiApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    // viet them xoa sua lay
    public class HangHoaController : ControllerBase
    {
        // tranh truong hop mat du lieu moi lan goi action deu new moi cai controllers
        // Alt + Enter se tu dong chen thu vien
        public static List<HangHoa> hanghoas = new List<HangHoa>(); // hanghoas = new list cac danh sach hang hoa


        [HttpGet]
        // IActionResult tra ve mot cai interface danh chon cac Action
        // Action la cac cai methods
        // GetAll() khi chay ung dung se tu dong nhay vo GetAll
        // ten Action se khong suat hien tren controller cua minh 
        public IActionResult GetAll()
        {
            // tra ve danh sach cac hang hoa
            // bo so tra ve OK tuc la thanh cong
            return Ok(hanghoas);
        }

        [HttpPost]
        // them moi mot cai hang hoa
        // Create khi them truyen vo mot cai HangHoaVM models ben folder Models
        public IActionResult Create(HangHoaVM hangHoaVM)
        {
            // tao moi mot cai hang hoa
            var hanghoa = new HangHoa
            {
                MaHangHoa = Guid.NewGuid(), // ma hang hoa duoc render tu dong
                TenHangHoa = hangHoaVM.TenHangHoa, // lay tu bo models dc map
                DonGia = hangHoaVM.DonGia // lay tu bo models dc map
            };

            // hanghoas la danh sach cac hang hoa dc tao o dong 17
            hanghoas.Add(hanghoa);
            return Ok(new
            {
                Success = true,
                Data = hanghoa
            });
        }
        [HttpGet("{id}")]
        public IActionResult GetById(string id)
        {
            try
            {
                // LINQ [Object] Query => truy van tren mang Object
                // truy van ID co hoac khong nen dung => SingleOrDefault()
                var hangHoa = hanghoas.SingleOrDefault(hh => hh.MaHangHoa == Guid.Parse(id));
                if (hangHoa == null)
                {
                    return NotFound(); // Tim khong thay
                }
                return Ok(hangHoa);
            }
            catch
            {
                return BadRequest();
            }

        }
        [HttpPut("{id}")]
        // truyen vao id
        // Truyen vao cai Models dinh update la dua nao
        public IActionResult Edit(string id, HangHoa hangHoaEdit)
        {
            try
            {
                var hangHoa = hanghoas.SingleOrDefault(hh => hh.MaHangHoa == Guid.Parse(id));
                if (hangHoa == null)
                {
                    return NotFound(); // Tim khong thay
                }
                if (id != hangHoa.MaHangHoa.ToString())
                {
                    return BadRequest();
                }

                // Update
                hangHoa.TenHangHoa = hangHoaEdit.TenHangHoa;
                hangHoa.DonGia = hangHoaEdit.DonGia;

                return Ok();

            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            try
            {
                var hangHoa = hanghoas.SingleOrDefault(hh => hh.MaHangHoa == Guid.Parse(id));
                if (hangHoa == null)
                {
                    return NotFound(); // Tim khong thay
                }

                // Delete
                hanghoas.Remove(hangHoa);
                return Ok();

            }
            catch
            {
                return BadRequest();
            }
        }

    }
}
