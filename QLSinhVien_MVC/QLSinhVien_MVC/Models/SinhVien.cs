using System;
using System.Collections.Generic;

namespace QLSinhVien_MVC.Models;

public partial class SinhVien
{
    public int MaSv { get; set; }

    public string? HoTen { get; set; }

    public DateOnly? NgaySinh { get; set; }

    public int? MaLop { get; set; }

    public virtual Lop? MaLopNavigation { get; set; }
}
