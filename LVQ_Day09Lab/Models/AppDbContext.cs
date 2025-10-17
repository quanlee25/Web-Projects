using LVQ_Day09Lab.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Lvq_Day09Lab.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Lvq_QuanTri> QuanTris { get; set; }
        public DbSet<Lvq_KhachHang> KhachHangs { get; set; }
        public DbSet<Lvq_HoaDon> HoaDons { get; set; }
        public DbSet<Lvq_ChiTietHoaDon> ChiTietHoaDons { get; set; }
        public DbSet<Lvq_SanPham> SanPhams { get; set; }
        public DbSet<Lvq_LoaiSanPham> LoaiSanPhams { get; set; }
    }
}
