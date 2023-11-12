﻿namespace QLSV.Models
{
    public class DiemHocSinh
    {
        public int IdHocSinh { get; set; }
        public int IdKhoaHoc { get; set; }
        public int? SoDiem { get;set; }
        public string? NhanXet { get; set; }
        public int? SoLan { get; set; }
        public virtual HocSinh HocSinh { get; set; }
        public virtual KhoaHoc KhoaHoc { get; set; }
    }
}
