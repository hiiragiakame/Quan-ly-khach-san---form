USE [KhachSan]
GO
/****** Object:  Table [dbo].[DatPhong_SanPham]    Script Date: 1/2/2023 2:13:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DatPhong_SanPham](
	[MaChiTietSanPham] [int] IDENTITY(1,1) NOT NULL,
	[MaDatPhong] [int] NULL,
	[MaChiTietDatPhong] [int] NULL,
	[MaPhong] [int] NULL,
	[MaSanPham] [int] NULL,
	[Ngay] [datetime] NULL,
	[SoLuong] [int] NULL,
	[DonGia] [float] NULL,
	[ThanhTien] [float] NULL,
 CONSTRAINT [PK_DatPhong_SanPham] PRIMARY KEY CLUSTERED 
(
	[MaChiTietSanPham] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SanPham]    Script Date: 1/2/2023 2:13:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SanPham](
	[MaSanPham] [int] IDENTITY(1,1) NOT NULL,
	[TenSanPham] [nvarchar](100) NULL,
	[DonGia] [float] NULL,
	[Disabled] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[MaSanPham] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[KhachHang]    Script Date: 1/2/2023 2:13:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KhachHang](
	[MaKhachHang] [int] IDENTITY(1,1) NOT NULL,
	[TenKhachHang] [nvarchar](100) NULL,
	[CCCD] [varchar](20) NULL,
	[DienThoai] [varchar](15) NULL,
	[Email] [nvarchar](100) NULL,
	[DiaChi] [nvarchar](300) NULL,
	[Nam] [bit] NULL,
	[Disabled] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[MaKhachHang] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Phong]    Script Date: 1/2/2023 2:13:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Phong](
	[MaPhong] [int] IDENTITY(1,1) NOT NULL,
	[TenPhong] [nvarchar](100) NULL,
	[TrangThai] [bit] NULL,
	[MaTang] [int] NOT NULL,
	[MaLoaiPhong] [int] NOT NULL,
	[Disabled] [bit] NULL,
 CONSTRAINT [PK__Phong__20BD5E5B0D260CEE] PRIMARY KEY CLUSTERED 
(
	[MaPhong] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DatPhong]    Script Date: 1/2/2023 2:13:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DatPhong](
	[MaDatPhong] [int] IDENTITY(1,1) NOT NULL,
	[MaKhachHang] [int] NULL,
	[NgayDatPhong] [datetime] NULL,
	[NgayTraPhong] [datetime] NULL,
	[SoTien] [float] NULL,
	[SoNguoiO] [int] NULL,
	[MaNhanVien] [int] NULL,
	[MaCongTy] [varchar](15) NULL,
	[MaDonVi] [varchar](15) NULL,
	[TrangThai] [bit] NULL,
	[Disabled] [bit] NULL,
	[TheoDoan] [bit] NULL,
	[GhiChu] [nvarchar](500) NULL,
	[NgayTao] [datetime] NULL,
	[NgayCapNhat] [datetime] NULL,
	[MaNhanVienCapNhat] [int] NULL,
 CONSTRAINT [PK__DatPhong__6344ADEAF104112C] PRIMARY KEY CLUSTERED 
(
	[MaDatPhong] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ChiTietDatPhong]    Script Date: 1/2/2023 2:13:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChiTietDatPhong](
	[MaChiTietDatPhong] [int] IDENTITY(1,1) NOT NULL,
	[MaDatPhong] [int] NULL,
	[MaPhong] [int] NULL,
	[SoNgayO] [int] NULL,
	[DonGia] [int] NULL,
	[ThanhTien] [float] NULL,
	[Ngay] [datetime] NULL,
 CONSTRAINT [PK_ChiTietDatPhong] PRIMARY KEY CLUSTERED 
(
	[MaChiTietDatPhong] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[View_1]    Script Date: 1/2/2023 2:13:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[View_1]
AS
SELECT        dbo.DatPhong.MaDatPhong, dbo.DatPhong.MaKhachHang, dbo.KhachHang.TenKhachHang, dbo.KhachHang.DienThoai, dbo.KhachHang.DiaChi, dbo.DatPhong.NgayDatPhong, dbo.DatPhong.NgayTraPhong, 
                         dbo.DatPhong.SoTien, dbo.DatPhong.SoNguoiO, dbo.DatPhong.MaCongTy, dbo.DatPhong.MaDonVi, dbo.DatPhong.TrangThai, dbo.DatPhong.GhiChu, dbo.ChiTietDatPhong.MaPhong, dbo.Phong.TenPhong, 
                         dbo.ChiTietDatPhong.SoNgayO, dbo.ChiTietDatPhong.DonGia, dbo.ChiTietDatPhong.ThanhTien, dbo.DatPhong_SanPham.MaChiTietSanPham, dbo.SanPham.TenSanPham, dbo.DatPhong_SanPham.SoLuong, 
                         dbo.DatPhong_SanPham.DonGia AS 'sp_DonGia', dbo.DatPhong_SanPham.ThanhTien AS 'sp_ThanhTien'
FROM            dbo.DatPhong INNER JOIN
                         dbo.DatPhong_SanPham ON dbo.DatPhong.MaDatPhong = dbo.DatPhong_SanPham.MaDatPhong INNER JOIN
                         dbo.ChiTietDatPhong ON dbo.DatPhong.MaDatPhong = dbo.ChiTietDatPhong.MaDatPhong AND dbo.DatPhong_SanPham.MaChiTietDatPhong = dbo.ChiTietDatPhong.MaChiTietDatPhong INNER JOIN
                         dbo.KhachHang ON dbo.DatPhong.MaKhachHang = dbo.KhachHang.MaKhachHang INNER JOIN
                         dbo.Phong ON dbo.DatPhong_SanPham.MaPhong = dbo.Phong.MaPhong INNER JOIN
                         dbo.SanPham ON dbo.DatPhong_SanPham.MaSanPham = dbo.SanPham.MaSanPham
GO
/****** Object:  Table [dbo].[NhomQuyen]    Script Date: 1/2/2023 2:13:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NhomQuyen](
	[Nhom] [int] NOT NULL,
	[MaNhanVien] [int] NOT NULL,
 CONSTRAINT [PK_NhomQuyen] PRIMARY KEY CLUSTERED 
(
	[Nhom] ASC,
	[MaNhanVien] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NhanVien]    Script Date: 1/2/2023 2:13:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NhanVien](
	[MaNhanVien] [int] IDENTITY(1,1) NOT NULL,
	[TenNhanVien] [nvarchar](100) NULL,
	[TenDangNhap] [varchar](100) NULL,
	[MatKhau] [varchar](100) NULL,
	[MaCongTy] [varchar](15) NULL,
	[MaDonVi] [varchar](15) NULL,
	[Nhom] [bit] NULL,
	[KhoaTaiKhoan] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[MaNhanVien] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[NhanVienKhongTrongNhom]    Script Date: 1/2/2023 2:13:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[NhanVienKhongTrongNhom]
AS
SELECT        MaNhanVien, TenNhanVien, TenDangNhap, MatKhau, MaCongTy, MaDonVi, Nhom, KhoaTaiKhoan
FROM            dbo.NhanVien
WHERE        (MaNhanVien NOT IN
                             (SELECT        Nhom
                               FROM            dbo.NhomQuyen)) AND (MaNhanVien NOT IN
                             (SELECT        MaNhanVien
                               FROM            dbo.NhomQuyen AS NhomQuyen_1))
GO
/****** Object:  View [dbo].[NhanVienTrongNhom]    Script Date: 1/2/2023 2:13:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[NhanVienTrongNhom]
AS
SELECT        dbo.NhanVien.MaNhanVien, dbo.NhanVien.TenNhanVien, dbo.NhanVien.TenDangNhap, dbo.NhanVien.MatKhau, dbo.NhanVien.MaCongTy, dbo.NhanVien.MaDonVi, dbo.NhanVien.Nhom, dbo.NhanVien.KhoaTaiKhoan, 
                         dbo.NhomQuyen.Nhom AS 'MaNhom'
FROM            dbo.NhanVien RIGHT OUTER JOIN
                         dbo.NhomQuyen ON dbo.NhanVien.MaNhanVien = dbo.NhomQuyen.MaNhanVien
GO
/****** Object:  Table [dbo].[TinhNang]    Script Date: 1/2/2023 2:13:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TinhNang](
	[MaTinhNang] [varchar](50) NOT NULL,
	[SapXep] [int] NOT NULL,
	[Decription] [nvarchar](200) NULL,
	[IsGroup] [bit] NULL,
	[Parent] [nvarchar](100) NULL,
	[Menu] [bit] NULL,
	[Tips] [nvarchar](300) NULL,
 CONSTRAINT [PK__TinhNang__2346BD22C47D226F] PRIMARY KEY CLUSTERED 
(
	[MaTinhNang] ASC,
	[SapXep] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Quyen]    Script Date: 1/2/2023 2:13:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Quyen](
	[MaTinhNang] [varchar](50) NOT NULL,
	[MaNhanVien] [int] NOT NULL,
	[Quyen] [int] NULL,
 CONSTRAINT [PK_Quyen] PRIMARY KEY CLUSTERED 
(
	[MaTinhNang] ASC,
	[MaNhanVien] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[QuyenTinhNang]    Script Date: 1/2/2023 2:13:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[QuyenTinhNang]
as
Select A.MaTinhNang, A.Decription, A.IsGroup, A.Parent, A.SapXep, B.MaNhanVien,
case B.Quyen when 1 then 'Xem' when 2 then N'Toàn quyền' end as Quyen
from TinhNang A, Quyen B
where A.MaTinhNang = B.MaTinhNang
GO
/****** Object:  Table [dbo].[CongTy]    Script Date: 1/2/2023 2:13:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CongTy](
	[MaCongTy] [varchar](15) NOT NULL,
	[TenCongTy] [nvarchar](100) NULL,
	[DienThoai] [varchar](15) NULL,
	[Fax] [nvarchar](10) NULL,
	[Email] [nvarchar](100) NULL,
	[DiaChi] [nvarchar](300) NULL,
	[Disabled] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[MaCongTy] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CongTy_DonVi]    Script Date: 1/2/2023 2:13:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CongTy_DonVi](
	[MaCongTy] [varchar](15) NOT NULL,
	[MaDonVi] [varchar](15) NOT NULL,
	[TenCongTy] [nvarchar](100) NULL,
	[TenDonVi] [nvarchar](100) NULL,
 CONSTRAINT [PK_CongTy_DonVi] PRIMARY KEY CLUSTERED 
(
	[MaCongTy] ASC,
	[MaDonVi] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DonVi]    Script Date: 1/2/2023 2:13:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DonVi](
	[MaDonVi] [varchar](15) NOT NULL,
	[TenDonVi] [nvarchar](100) NULL,
	[DienThoai] [varchar](15) NULL,
	[Fax] [nvarchar](10) NULL,
	[Email] [nvarchar](100) NULL,
	[DiaChi] [nvarchar](300) NULL,
	[MaCongTy] [varchar](15) NOT NULL,
	[Disabled] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[MaDonVi] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LoaiPhong]    Script Date: 1/2/2023 2:13:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LoaiPhong](
	[MaLoaiPhong] [int] IDENTITY(1,1) NOT NULL,
	[TenLoaiPhong] [nvarchar](100) NULL,
	[DonGia] [float] NULL,
	[SoNguoi] [int] NULL,
	[SoGiuong] [int] NULL,
	[Disabled] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[MaLoaiPhong] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Phong_ThietBi]    Script Date: 1/2/2023 2:13:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Phong_ThietBi](
	[MaPhong] [int] NOT NULL,
	[MaThietBi] [int] NOT NULL,
	[SoLuong] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[MaPhong] ASC,
	[MaThietBi] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tang]    Script Date: 1/2/2023 2:13:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tang](
	[MaTang] [int] IDENTITY(1,1) NOT NULL,
	[TenTang] [nvarchar](100) NULL,
	[Disabled] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[MaTang] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ThietBi]    Script Date: 1/2/2023 2:13:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ThietBi](
	[MaThietBi] [int] IDENTITY(1,1) NOT NULL,
	[TenThietBi] [nvarchar](100) NULL,
	[DonGia] [float] NULL,
	[Disabled] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[MaThietBi] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[ChiTietDatPhong] ON 

INSERT [dbo].[ChiTietDatPhong] ([MaChiTietDatPhong], [MaDatPhong], [MaPhong], [SoNgayO], [DonGia], [ThanhTien], [Ngay]) VALUES (29, 14, 3, 0, 3000000, 0, CAST(N'2022-12-30T23:34:33.657' AS DateTime))
INSERT [dbo].[ChiTietDatPhong] ([MaChiTietDatPhong], [MaDatPhong], [MaPhong], [SoNgayO], [DonGia], [ThanhTien], [Ngay]) VALUES (30, 15, 2, 1, 3500000, 3500000, CAST(N'2022-12-31T09:49:15.443' AS DateTime))
INSERT [dbo].[ChiTietDatPhong] ([MaChiTietDatPhong], [MaDatPhong], [MaPhong], [SoNgayO], [DonGia], [ThanhTien], [Ngay]) VALUES (35, 16, 2, -30, 3500000, -105000000, CAST(N'2023-01-01T10:16:38.530' AS DateTime))
INSERT [dbo].[ChiTietDatPhong] ([MaChiTietDatPhong], [MaDatPhong], [MaPhong], [SoNgayO], [DonGia], [ThanhTien], [Ngay]) VALUES (36, 17, 5, -30, 3000000, -90000000, CAST(N'2023-01-01T10:16:43.513' AS DateTime))
INSERT [dbo].[ChiTietDatPhong] ([MaChiTietDatPhong], [MaDatPhong], [MaPhong], [SoNgayO], [DonGia], [ThanhTien], [Ngay]) VALUES (37, 18, 7, 3, 3500000, 10500000, CAST(N'2023-01-01T10:51:30.633' AS DateTime))
INSERT [dbo].[ChiTietDatPhong] ([MaChiTietDatPhong], [MaDatPhong], [MaPhong], [SoNgayO], [DonGia], [ThanhTien], [Ngay]) VALUES (38, 18, 6, 3, 3000000, 9000000, CAST(N'2023-01-01T10:51:30.650' AS DateTime))
INSERT [dbo].[ChiTietDatPhong] ([MaChiTietDatPhong], [MaDatPhong], [MaPhong], [SoNgayO], [DonGia], [ThanhTien], [Ngay]) VALUES (39, 18, 17, 3, 2500000, 7500000, CAST(N'2023-01-01T10:51:30.650' AS DateTime))
INSERT [dbo].[ChiTietDatPhong] ([MaChiTietDatPhong], [MaDatPhong], [MaPhong], [SoNgayO], [DonGia], [ThanhTien], [Ngay]) VALUES (42, 19, 5, 0, 3000000, 0, CAST(N'2023-01-01T10:53:50.463' AS DateTime))
INSERT [dbo].[ChiTietDatPhong] ([MaChiTietDatPhong], [MaDatPhong], [MaPhong], [SoNgayO], [DonGia], [ThanhTien], [Ngay]) VALUES (43, 20, 7, 2, 3500000, 7000000, CAST(N'2023-01-01T10:55:54.113' AS DateTime))
INSERT [dbo].[ChiTietDatPhong] ([MaChiTietDatPhong], [MaDatPhong], [MaPhong], [SoNgayO], [DonGia], [ThanhTien], [Ngay]) VALUES (44, 20, 6, 2, 3000000, 6000000, CAST(N'2023-01-01T10:55:54.140' AS DateTime))
INSERT [dbo].[ChiTietDatPhong] ([MaChiTietDatPhong], [MaDatPhong], [MaPhong], [SoNgayO], [DonGia], [ThanhTien], [Ngay]) VALUES (45, 21, 7, 2, 3500000, 7000000, CAST(N'2023-01-02T01:20:36.327' AS DateTime))
INSERT [dbo].[ChiTietDatPhong] ([MaChiTietDatPhong], [MaDatPhong], [MaPhong], [SoNgayO], [DonGia], [ThanhTien], [Ngay]) VALUES (46, 21, 9, 2, 2500000, 5000000, CAST(N'2023-01-02T01:20:36.337' AS DateTime))
INSERT [dbo].[ChiTietDatPhong] ([MaChiTietDatPhong], [MaDatPhong], [MaPhong], [SoNgayO], [DonGia], [ThanhTien], [Ngay]) VALUES (47, 21, 6, 2, 3000000, 6000000, CAST(N'2023-01-02T01:20:36.337' AS DateTime))
INSERT [dbo].[ChiTietDatPhong] ([MaChiTietDatPhong], [MaDatPhong], [MaPhong], [SoNgayO], [DonGia], [ThanhTien], [Ngay]) VALUES (50, 22, 3, 0, 3000000, 0, CAST(N'2023-01-02T01:22:26.737' AS DateTime))
SET IDENTITY_INSERT [dbo].[ChiTietDatPhong] OFF
GO
INSERT [dbo].[CongTy] ([MaCongTy], [TenCongTy], [DienThoai], [Fax], [Email], [DiaChi], [Disabled]) VALUES (N'CNMN', N'Chi nhánh miền Nam', N'0315621889', N'123', N'cnmn@gmail.com', N'cnmn@gmail.com', 1)
INSERT [dbo].[CongTy] ([MaCongTy], [TenCongTy], [DienThoai], [Fax], [Email], [DiaChi], [Disabled]) VALUES (N'CTyMe', N'Công ty mẹ', N'012344567890', N'789', N'congtyme@gmail.com', N'congtyme@gmail.com', 0)
INSERT [dbo].[CongTy] ([MaCongTy], [TenCongTy], [DienThoai], [Fax], [Email], [DiaChi], [Disabled]) VALUES (N'HPMN', N'Công Ty TNHH Hòa Phát Miền Nam', N'18006155', N'123', N'hoaphatmiennam@gmail.com', N'hoaphatmiennam@gmail.com', 0)
GO
INSERT [dbo].[CongTy_DonVi] ([MaCongTy], [MaDonVi], [TenCongTy], [TenDonVi]) VALUES (N'CNMN', N'aaa', N'Chi nhánh miền Nam', N'dasd')
INSERT [dbo].[CongTy_DonVi] ([MaCongTy], [MaDonVi], [TenCongTy], [TenDonVi]) VALUES (N'CTyMe', N'abc', N'Công ty mẹ', N'Chi nhánh 3')
GO
SET IDENTITY_INSERT [dbo].[DatPhong] ON 

INSERT [dbo].[DatPhong] ([MaDatPhong], [MaKhachHang], [NgayDatPhong], [NgayTraPhong], [SoTien], [SoNguoiO], [MaNhanVien], [MaCongTy], [MaDonVi], [TrangThai], [Disabled], [TheoDoan], [GhiChu], [NgayTao], [NgayCapNhat], [MaNhanVienCapNhat]) VALUES (14, 4, CAST(N'2022-12-30T21:34:06.557' AS DateTime), CAST(N'2022-12-30T23:34:31.287' AS DateTime), 6064000, 3, 2, N'CNMN', N'aaa', 1, 0, 0, N'abc', CAST(N'2022-12-30T21:34:27.367' AS DateTime), CAST(N'2022-12-30T23:34:33.647' AS DateTime), 2)
INSERT [dbo].[DatPhong] ([MaDatPhong], [MaKhachHang], [NgayDatPhong], [NgayTraPhong], [SoTien], [SoNguoiO], [MaNhanVien], [MaCongTy], [MaDonVi], [TrangThai], [Disabled], [TheoDoan], [GhiChu], [NgayTao], [NgayCapNhat], [MaNhanVienCapNhat]) VALUES (15, 1, CAST(N'2022-12-30T22:35:25.910' AS DateTime), CAST(N'2022-12-31T09:49:12.743' AS DateTime), 32000, 2, 2, N'CNMN', N'aaa', 1, 0, 0, N'aaa', CAST(N'2022-12-30T22:35:41.387' AS DateTime), CAST(N'2022-12-31T09:49:15.427' AS DateTime), 2)
INSERT [dbo].[DatPhong] ([MaDatPhong], [MaKhachHang], [NgayDatPhong], [NgayTraPhong], [SoTien], [SoNguoiO], [MaNhanVien], [MaCongTy], [MaDonVi], [TrangThai], [Disabled], [TheoDoan], [GhiChu], [NgayTao], [NgayCapNhat], [MaNhanVienCapNhat]) VALUES (16, 1, CAST(N'2022-12-31T22:24:49.297' AS DateTime), CAST(N'2023-01-01T10:16:36.860' AS DateTime), 64000, 1, 2, N'CNMN', N'aaa', 1, 0, 1, N'', CAST(N'2022-12-31T22:25:01.663' AS DateTime), CAST(N'2023-01-01T10:16:38.510' AS DateTime), 2)
INSERT [dbo].[DatPhong] ([MaDatPhong], [MaKhachHang], [NgayDatPhong], [NgayTraPhong], [SoTien], [SoNguoiO], [MaNhanVien], [MaCongTy], [MaDonVi], [TrangThai], [Disabled], [TheoDoan], [GhiChu], [NgayTao], [NgayCapNhat], [MaNhanVienCapNhat]) VALUES (17, 1, CAST(N'2022-12-31T23:12:02.913' AS DateTime), CAST(N'2023-01-01T10:16:42.273' AS DateTime), 0, 1, 2, N'CNMN', N'aaa', 1, 0, 1, N'', CAST(N'2022-12-31T23:12:06.860' AS DateTime), CAST(N'2023-01-01T10:16:43.507' AS DateTime), 2)
INSERT [dbo].[DatPhong] ([MaDatPhong], [MaKhachHang], [NgayDatPhong], [NgayTraPhong], [SoTien], [SoNguoiO], [MaNhanVien], [MaCongTy], [MaDonVi], [TrangThai], [Disabled], [TheoDoan], [GhiChu], [NgayTao], [NgayCapNhat], [MaNhanVienCapNhat]) VALUES (18, 1, CAST(N'2023-01-01T10:51:08.000' AS DateTime), CAST(N'2023-01-03T10:51:08.000' AS DateTime), 18254000, 1, 2, N'CNMN', N'aaa', 1, 0, 1, N'', CAST(N'2023-01-01T10:51:30.580' AS DateTime), NULL, NULL)
INSERT [dbo].[DatPhong] ([MaDatPhong], [MaKhachHang], [NgayDatPhong], [NgayTraPhong], [SoTien], [SoNguoiO], [MaNhanVien], [MaCongTy], [MaDonVi], [TrangThai], [Disabled], [TheoDoan], [GhiChu], [NgayTao], [NgayCapNhat], [MaNhanVienCapNhat]) VALUES (19, 4, CAST(N'2023-01-01T10:53:05.187' AS DateTime), CAST(N'2023-01-01T10:53:42.503' AS DateTime), 192000, 2, 2, N'CNMN', N'aaa', 1, 0, 0, N'aaa', CAST(N'2023-01-01T10:53:27.487' AS DateTime), CAST(N'2023-01-01T10:53:50.433' AS DateTime), 2)
INSERT [dbo].[DatPhong] ([MaDatPhong], [MaKhachHang], [NgayDatPhong], [NgayTraPhong], [SoTien], [SoNguoiO], [MaNhanVien], [MaCongTy], [MaDonVi], [TrangThai], [Disabled], [TheoDoan], [GhiChu], [NgayTao], [NgayCapNhat], [MaNhanVienCapNhat]) VALUES (20, 1, CAST(N'2023-01-01T10:55:47.207' AS DateTime), CAST(N'2023-01-02T10:55:47.207' AS DateTime), 6684000, 1, 2, N'CNMN', N'aaa', 1, 0, 1, N'', CAST(N'2023-01-01T10:55:54.073' AS DateTime), NULL, NULL)
INSERT [dbo].[DatPhong] ([MaDatPhong], [MaKhachHang], [NgayDatPhong], [NgayTraPhong], [SoTien], [SoNguoiO], [MaNhanVien], [MaCongTy], [MaDonVi], [TrangThai], [Disabled], [TheoDoan], [GhiChu], [NgayTao], [NgayCapNhat], [MaNhanVienCapNhat]) VALUES (21, 1, CAST(N'2023-01-02T01:19:58.843' AS DateTime), CAST(N'2023-01-03T01:19:58.843' AS DateTime), 9384000, 9, 3, N'CTyMe', N'aaa', 1, 0, 1, N'đoàn thanh niên', CAST(N'2023-01-02T01:20:36.320' AS DateTime), NULL, NULL)
INSERT [dbo].[DatPhong] ([MaDatPhong], [MaKhachHang], [NgayDatPhong], [NgayTraPhong], [SoTien], [SoNguoiO], [MaNhanVien], [MaCongTy], [MaDonVi], [TrangThai], [Disabled], [TheoDoan], [GhiChu], [NgayTao], [NgayCapNhat], [MaNhanVienCapNhat]) VALUES (22, 6, CAST(N'2023-01-02T01:21:33.287' AS DateTime), CAST(N'2023-01-02T01:22:25.497' AS DateTime), 624000, 2, 3, N'CTyMe', N'aaa', 1, 0, 0, N'tuần trăng mật', CAST(N'2023-01-02T01:21:59.127' AS DateTime), CAST(N'2023-01-02T01:22:26.730' AS DateTime), 3)
SET IDENTITY_INSERT [dbo].[DatPhong] OFF
GO
SET IDENTITY_INSERT [dbo].[DatPhong_SanPham] ON 

INSERT [dbo].[DatPhong_SanPham] ([MaChiTietSanPham], [MaDatPhong], [MaChiTietDatPhong], [MaPhong], [MaSanPham], [Ngay], [SoLuong], [DonGia], [ThanhTien]) VALUES (65, 14, 29, 3, 4, CAST(N'2022-12-30T23:34:33.667' AS DateTime), 2, 20000, 40000)
INSERT [dbo].[DatPhong_SanPham] ([MaChiTietSanPham], [MaDatPhong], [MaChiTietDatPhong], [MaPhong], [MaSanPham], [Ngay], [SoLuong], [DonGia], [ThanhTien]) VALUES (66, 14, 29, 3, 5, CAST(N'2022-12-30T23:34:33.670' AS DateTime), 2, 12000, 24000)
INSERT [dbo].[DatPhong_SanPham] ([MaChiTietSanPham], [MaDatPhong], [MaChiTietDatPhong], [MaPhong], [MaSanPham], [Ngay], [SoLuong], [DonGia], [ThanhTien]) VALUES (67, 15, 30, 2, 5, CAST(N'2022-12-31T09:49:15.450' AS DateTime), 1, 12000, 12000)
INSERT [dbo].[DatPhong_SanPham] ([MaChiTietSanPham], [MaDatPhong], [MaChiTietDatPhong], [MaPhong], [MaSanPham], [Ngay], [SoLuong], [DonGia], [ThanhTien]) VALUES (68, 15, 30, 2, 4, CAST(N'2022-12-31T09:49:15.450' AS DateTime), 1, 20000, 20000)
INSERT [dbo].[DatPhong_SanPham] ([MaChiTietSanPham], [MaDatPhong], [MaChiTietDatPhong], [MaPhong], [MaSanPham], [Ngay], [SoLuong], [DonGia], [ThanhTien]) VALUES (73, 16, 35, 2, 2, CAST(N'2023-01-01T10:16:38.537' AS DateTime), 1, 10000, 10000)
INSERT [dbo].[DatPhong_SanPham] ([MaChiTietSanPham], [MaDatPhong], [MaChiTietDatPhong], [MaPhong], [MaSanPham], [Ngay], [SoLuong], [DonGia], [ThanhTien]) VALUES (74, 16, 35, 2, 4, CAST(N'2023-01-01T10:16:38.537' AS DateTime), 1, 20000, 20000)
INSERT [dbo].[DatPhong_SanPham] ([MaChiTietSanPham], [MaDatPhong], [MaChiTietDatPhong], [MaPhong], [MaSanPham], [Ngay], [SoLuong], [DonGia], [ThanhTien]) VALUES (75, 18, 37, 7, 4, CAST(N'2023-01-01T10:51:30.650' AS DateTime), 1, 20000, 20000)
INSERT [dbo].[DatPhong_SanPham] ([MaChiTietSanPham], [MaDatPhong], [MaChiTietDatPhong], [MaPhong], [MaSanPham], [Ngay], [SoLuong], [DonGia], [ThanhTien]) VALUES (76, 18, 37, 7, 3, CAST(N'2023-01-01T10:51:30.650' AS DateTime), 1, 150000, 150000)
INSERT [dbo].[DatPhong_SanPham] ([MaChiTietSanPham], [MaDatPhong], [MaChiTietDatPhong], [MaPhong], [MaSanPham], [Ngay], [SoLuong], [DonGia], [ThanhTien]) VALUES (77, 18, 38, 6, 5, CAST(N'2023-01-01T10:51:30.650' AS DateTime), 2, 12000, 24000)
INSERT [dbo].[DatPhong_SanPham] ([MaChiTietSanPham], [MaDatPhong], [MaChiTietDatPhong], [MaPhong], [MaSanPham], [Ngay], [SoLuong], [DonGia], [ThanhTien]) VALUES (78, 18, 38, 6, 4, CAST(N'2023-01-01T10:51:30.650' AS DateTime), 1, 20000, 20000)
INSERT [dbo].[DatPhong_SanPham] ([MaChiTietSanPham], [MaDatPhong], [MaChiTietDatPhong], [MaPhong], [MaSanPham], [Ngay], [SoLuong], [DonGia], [ThanhTien]) VALUES (79, 18, 39, 17, 2, CAST(N'2023-01-01T10:51:30.650' AS DateTime), 2, 10000, 20000)
INSERT [dbo].[DatPhong_SanPham] ([MaChiTietSanPham], [MaDatPhong], [MaChiTietDatPhong], [MaPhong], [MaSanPham], [Ngay], [SoLuong], [DonGia], [ThanhTien]) VALUES (80, 18, 39, 17, 4, CAST(N'2023-01-01T10:51:30.650' AS DateTime), 1, 20000, 20000)
INSERT [dbo].[DatPhong_SanPham] ([MaChiTietSanPham], [MaDatPhong], [MaChiTietDatPhong], [MaPhong], [MaSanPham], [Ngay], [SoLuong], [DonGia], [ThanhTien]) VALUES (88, 19, 42, 5, 2, CAST(N'2023-01-01T10:53:50.463' AS DateTime), 1, 10000, 10000)
INSERT [dbo].[DatPhong_SanPham] ([MaChiTietSanPham], [MaDatPhong], [MaChiTietDatPhong], [MaPhong], [MaSanPham], [Ngay], [SoLuong], [DonGia], [ThanhTien]) VALUES (89, 19, 42, 5, 4, CAST(N'2023-01-01T10:53:50.463' AS DateTime), 1, 20000, 20000)
INSERT [dbo].[DatPhong_SanPham] ([MaChiTietSanPham], [MaDatPhong], [MaChiTietDatPhong], [MaPhong], [MaSanPham], [Ngay], [SoLuong], [DonGia], [ThanhTien]) VALUES (90, 19, 42, 5, 5, CAST(N'2023-01-01T10:53:50.463' AS DateTime), 1, 12000, 12000)
INSERT [dbo].[DatPhong_SanPham] ([MaChiTietSanPham], [MaDatPhong], [MaChiTietDatPhong], [MaPhong], [MaSanPham], [Ngay], [SoLuong], [DonGia], [ThanhTien]) VALUES (91, 19, 42, 5, 3, CAST(N'2023-01-01T10:53:50.463' AS DateTime), 1, 150000, 150000)
INSERT [dbo].[DatPhong_SanPham] ([MaChiTietSanPham], [MaDatPhong], [MaChiTietDatPhong], [MaPhong], [MaSanPham], [Ngay], [SoLuong], [DonGia], [ThanhTien]) VALUES (92, 20, 43, 7, 5, CAST(N'2023-01-01T10:55:54.140' AS DateTime), 2, 12000, 24000)
INSERT [dbo].[DatPhong_SanPham] ([MaChiTietSanPham], [MaDatPhong], [MaChiTietDatPhong], [MaPhong], [MaSanPham], [Ngay], [SoLuong], [DonGia], [ThanhTien]) VALUES (93, 20, 44, 6, 2, CAST(N'2023-01-01T10:55:54.143' AS DateTime), 1, 10000, 10000)
INSERT [dbo].[DatPhong_SanPham] ([MaChiTietSanPham], [MaDatPhong], [MaChiTietDatPhong], [MaPhong], [MaSanPham], [Ngay], [SoLuong], [DonGia], [ThanhTien]) VALUES (94, 20, 44, 6, 3, CAST(N'2023-01-01T10:55:54.143' AS DateTime), 1, 150000, 150000)
INSERT [dbo].[DatPhong_SanPham] ([MaChiTietSanPham], [MaDatPhong], [MaChiTietDatPhong], [MaPhong], [MaSanPham], [Ngay], [SoLuong], [DonGia], [ThanhTien]) VALUES (95, 21, 45, 7, 4, CAST(N'2023-01-02T01:20:36.333' AS DateTime), 1, 20000, 20000)
INSERT [dbo].[DatPhong_SanPham] ([MaChiTietSanPham], [MaDatPhong], [MaChiTietDatPhong], [MaPhong], [MaSanPham], [Ngay], [SoLuong], [DonGia], [ThanhTien]) VALUES (96, 21, 45, 7, 3, CAST(N'2023-01-02T01:20:36.337' AS DateTime), 1, 150000, 150000)
INSERT [dbo].[DatPhong_SanPham] ([MaChiTietSanPham], [MaDatPhong], [MaChiTietDatPhong], [MaPhong], [MaSanPham], [Ngay], [SoLuong], [DonGia], [ThanhTien]) VALUES (97, 21, 46, 9, 3, CAST(N'2023-01-02T01:20:36.337' AS DateTime), 1, 150000, 150000)
INSERT [dbo].[DatPhong_SanPham] ([MaChiTietSanPham], [MaDatPhong], [MaChiTietDatPhong], [MaPhong], [MaSanPham], [Ngay], [SoLuong], [DonGia], [ThanhTien]) VALUES (98, 21, 46, 9, 5, CAST(N'2023-01-02T01:20:36.337' AS DateTime), 1, 12000, 12000)
INSERT [dbo].[DatPhong_SanPham] ([MaChiTietSanPham], [MaDatPhong], [MaChiTietDatPhong], [MaPhong], [MaSanPham], [Ngay], [SoLuong], [DonGia], [ThanhTien]) VALUES (99, 21, 46, 9, 4, CAST(N'2023-01-02T01:20:36.337' AS DateTime), 1, 20000, 20000)
INSERT [dbo].[DatPhong_SanPham] ([MaChiTietSanPham], [MaDatPhong], [MaChiTietDatPhong], [MaPhong], [MaSanPham], [Ngay], [SoLuong], [DonGia], [ThanhTien]) VALUES (100, 21, 47, 6, 6, CAST(N'2023-01-02T01:20:36.340' AS DateTime), 2, 10000, 20000)
INSERT [dbo].[DatPhong_SanPham] ([MaChiTietSanPham], [MaDatPhong], [MaChiTietDatPhong], [MaPhong], [MaSanPham], [Ngay], [SoLuong], [DonGia], [ThanhTien]) VALUES (101, 21, 47, 6, 5, CAST(N'2023-01-02T01:20:36.340' AS DateTime), 1, 12000, 12000)
INSERT [dbo].[DatPhong_SanPham] ([MaChiTietSanPham], [MaDatPhong], [MaChiTietDatPhong], [MaPhong], [MaSanPham], [Ngay], [SoLuong], [DonGia], [ThanhTien]) VALUES (106, 22, 50, 3, 3, CAST(N'2023-01-02T01:22:26.740' AS DateTime), 4, 150000, 600000)
INSERT [dbo].[DatPhong_SanPham] ([MaChiTietSanPham], [MaDatPhong], [MaChiTietDatPhong], [MaPhong], [MaSanPham], [Ngay], [SoLuong], [DonGia], [ThanhTien]) VALUES (107, 22, 50, 3, 5, CAST(N'2023-01-02T01:22:26.740' AS DateTime), 2, 12000, 24000)
SET IDENTITY_INSERT [dbo].[DatPhong_SanPham] OFF
GO
INSERT [dbo].[DonVi] ([MaDonVi], [TenDonVi], [DienThoai], [Fax], [Email], [DiaChi], [MaCongTy], [Disabled]) VALUES (N'aaa', N'dasd', N'', N'', N'', N'', N'CTyMe', 0)
INSERT [dbo].[DonVi] ([MaDonVi], [TenDonVi], [DienThoai], [Fax], [Email], [DiaChi], [MaCongTy], [Disabled]) VALUES (N'abc', N'Chi nhánh 3', N'', N'13', N'', N'', N'CNMN', 0)
INSERT [dbo].[DonVi] ([MaDonVi], [TenDonVi], [DienThoai], [Fax], [Email], [DiaChi], [MaCongTy], [Disabled]) VALUES (N'CTKSVD', N'Khách sạn viễn đông', N'5123478961', N'111', N'viendong@gmail.com', N'viendong@gmail.com', N'CTyMe', 0)
INSERT [dbo].[DonVi] ([MaDonVi], [TenDonVi], [DienThoai], [Fax], [Email], [DiaChi], [MaCongTy], [Disabled]) VALUES (N'daucungduoc', N'Khách sạn đâu cũng được', N'15776796', N'1234567', N'daucungduoc@gmail.com', N'daucungduoc@gmail.com', N'HPMN', 0)
GO
SET IDENTITY_INSERT [dbo].[KhachHang] ON 

INSERT [dbo].[KhachHang] ([MaKhachHang], [TenKhachHang], [CCCD], [DienThoai], [Email], [DiaChi], [Nam], [Disabled]) VALUES (1, N'Nguyễn Văn A', N'13421', N'5346', N'ấ@gmail.com', N'ấ@gmail.com', 1, 0)
INSERT [dbo].[KhachHang] ([MaKhachHang], [TenKhachHang], [CCCD], [DienThoai], [Email], [DiaChi], [Nam], [Disabled]) VALUES (2, N'Phan Văn B', N'', N'', N'dasd', N'dasd', 1, 0)
INSERT [dbo].[KhachHang] ([MaKhachHang], [TenKhachHang], [CCCD], [DienThoai], [Email], [DiaChi], [Nam], [Disabled]) VALUES (3, N'Nguyễn Quốc C', N'412', N'412412', N'24@gmail.com', N'24@gmail.com', 1, 0)
INSERT [dbo].[KhachHang] ([MaKhachHang], [TenKhachHang], [CCCD], [DienThoai], [Email], [DiaChi], [Nam], [Disabled]) VALUES (4, N'Phan Tấn Tài', N'45124', N'3123', N'2Gmai..com', N'2Gmai..com', 0, 0)
INSERT [dbo].[KhachHang] ([MaKhachHang], [TenKhachHang], [CCCD], [DienThoai], [Email], [DiaChi], [Nam], [Disabled]) VALUES (5, N'Nguyễn Gia Thuận', N'6345234', N'562354', N'2edas@gmail.com', N'2edas@gmail.com', 1, 0)
INSERT [dbo].[KhachHang] ([MaKhachHang], [TenKhachHang], [CCCD], [DienThoai], [Email], [DiaChi], [Nam], [Disabled]) VALUES (6, N'Phan Văn Thuận', N'05236156', N'026518791', N'phanvanthuan@gmail.com', N'phanvanthuan@gmail.com', 1, 0)
SET IDENTITY_INSERT [dbo].[KhachHang] OFF
GO
SET IDENTITY_INSERT [dbo].[LoaiPhong] ON 

INSERT [dbo].[LoaiPhong] ([MaLoaiPhong], [TenLoaiPhong], [DonGia], [SoNguoi], [SoGiuong], [Disabled]) VALUES (1, N'VIP1', 3500000, 2, 1, 0)
INSERT [dbo].[LoaiPhong] ([MaLoaiPhong], [TenLoaiPhong], [DonGia], [SoNguoi], [SoGiuong], [Disabled]) VALUES (2, N'VIP2', 3000000, 2, 1, 0)
INSERT [dbo].[LoaiPhong] ([MaLoaiPhong], [TenLoaiPhong], [DonGia], [SoNguoi], [SoGiuong], [Disabled]) VALUES (3, N'Loại 1', 2500000, 4, 2, 0)
INSERT [dbo].[LoaiPhong] ([MaLoaiPhong], [TenLoaiPhong], [DonGia], [SoNguoi], [SoGiuong], [Disabled]) VALUES (4, N'Loại 2', 2200000, 4, 2, 0)
INSERT [dbo].[LoaiPhong] ([MaLoaiPhong], [TenLoaiPhong], [DonGia], [SoNguoi], [SoGiuong], [Disabled]) VALUES (5, N'Loại 3', 2500000, 4, 2, 1)
INSERT [dbo].[LoaiPhong] ([MaLoaiPhong], [TenLoaiPhong], [DonGia], [SoNguoi], [SoGiuong], [Disabled]) VALUES (6, N'VIP 3', 3000000, 2, 2, 1)
SET IDENTITY_INSERT [dbo].[LoaiPhong] OFF
GO
SET IDENTITY_INSERT [dbo].[NhanVien] ON 

INSERT [dbo].[NhanVien] ([MaNhanVien], [TenNhanVien], [TenDangNhap], [MatKhau], [MaCongTy], [MaDonVi], [Nhom], [KhoaTaiKhoan]) VALUES (2, N'Nguyễn Văn A', N'as', N'123', N'CTyMe', N'aaa', 0, 1)
INSERT [dbo].[NhanVien] ([MaNhanVien], [TenNhanVien], [TenDangNhap], [MatKhau], [MaCongTy], [MaDonVi], [Nhom], [KhoaTaiKhoan]) VALUES (3, N'Đinh Thị Bé', N'dinhthibe', N'123456', N'CTyMe', N'aaa', 0, 0)
INSERT [dbo].[NhanVien] ([MaNhanVien], [TenNhanVien], [TenDangNhap], [MatKhau], [MaCongTy], [MaDonVi], [Nhom], [KhoaTaiKhoan]) VALUES (7, N'admin', N'admin', NULL, N'CTyMe', N'aaa', 1, 0)
INSERT [dbo].[NhanVien] ([MaNhanVien], [TenNhanVien], [TenDangNhap], [MatKhau], [MaCongTy], [MaDonVi], [Nhom], [KhoaTaiKhoan]) VALUES (9, N'admin', N'ADMIN', NULL, N'CTyMe', N'CTKSVD', 1, 0)
INSERT [dbo].[NhanVien] ([MaNhanVien], [TenNhanVien], [TenDangNhap], [MatKhau], [MaCongTy], [MaDonVi], [Nhom], [KhoaTaiKhoan]) VALUES (10, N'Nhân viên A', N'nhanviena', N'123', N'CTyMe', N'CTKSVD', 0, 0)
INSERT [dbo].[NhanVien] ([MaNhanVien], [TenNhanVien], [TenDangNhap], [MatKhau], [MaCongTy], [MaDonVi], [Nhom], [KhoaTaiKhoan]) VALUES (11, N'test', N'TEST', NULL, N'CTyMe', N'aaa', 1, 0)
INSERT [dbo].[NhanVien] ([MaNhanVien], [TenNhanVien], [TenDangNhap], [MatKhau], [MaCongTy], [MaDonVi], [Nhom], [KhoaTaiKhoan]) VALUES (12, N'test2', N'TEST2', NULL, N'CTyMe', N'aaa', 1, 0)
INSERT [dbo].[NhanVien] ([MaNhanVien], [TenNhanVien], [TenDangNhap], [MatKhau], [MaCongTy], [MaDonVi], [Nhom], [KhoaTaiKhoan]) VALUES (13, N'test3', N'test3', N'123', N'CTyMe', N'aaa', 0, 0)
INSERT [dbo].[NhanVien] ([MaNhanVien], [TenNhanVien], [TenDangNhap], [MatKhau], [MaCongTy], [MaDonVi], [Nhom], [KhoaTaiKhoan]) VALUES (14, N'admin', N'ADMIN', NULL, N'HPMN', N'daucungduoc', 1, 0)
INSERT [dbo].[NhanVien] ([MaNhanVien], [TenNhanVien], [TenDangNhap], [MatKhau], [MaCongTy], [MaDonVi], [Nhom], [KhoaTaiKhoan]) VALUES (15, N'Nguyễn Hữu Tín', N'nguyenhuutin', N'123', N'CTyMe', N'aaa', 0, 0)
INSERT [dbo].[NhanVien] ([MaNhanVien], [TenNhanVien], [TenDangNhap], [MatKhau], [MaCongTy], [MaDonVi], [Nhom], [KhoaTaiKhoan]) VALUES (17, N'Administrator', N'sa', N'123456', N'CTyMe', N'aaa', 0, 0)
SET IDENTITY_INSERT [dbo].[NhanVien] OFF
GO
INSERT [dbo].[NhomQuyen] ([Nhom], [MaNhanVien]) VALUES (7, 15)
INSERT [dbo].[NhomQuyen] ([Nhom], [MaNhanVien]) VALUES (7, 17)
GO
SET IDENTITY_INSERT [dbo].[Phong] ON 

INSERT [dbo].[Phong] ([MaPhong], [TenPhong], [TrangThai], [MaTang], [MaLoaiPhong], [Disabled]) VALUES (2, N'Phòng 101', 0, 1, 1, 0)
INSERT [dbo].[Phong] ([MaPhong], [TenPhong], [TrangThai], [MaTang], [MaLoaiPhong], [Disabled]) VALUES (3, N'Phòng 102', 0, 1, 2, 0)
INSERT [dbo].[Phong] ([MaPhong], [TenPhong], [TrangThai], [MaTang], [MaLoaiPhong], [Disabled]) VALUES (5, N'Phòng 202', 0, 2, 2, 0)
INSERT [dbo].[Phong] ([MaPhong], [TenPhong], [TrangThai], [MaTang], [MaLoaiPhong], [Disabled]) VALUES (6, N'Phòng 301', 0, 3, 2, 0)
INSERT [dbo].[Phong] ([MaPhong], [TenPhong], [TrangThai], [MaTang], [MaLoaiPhong], [Disabled]) VALUES (7, N'Phòng 103', 0, 1, 1, 0)
INSERT [dbo].[Phong] ([MaPhong], [TenPhong], [TrangThai], [MaTang], [MaLoaiPhong], [Disabled]) VALUES (8, N'Phòng 104', 0, 1, 3, 0)
INSERT [dbo].[Phong] ([MaPhong], [TenPhong], [TrangThai], [MaTang], [MaLoaiPhong], [Disabled]) VALUES (9, N'Phòng 201', 0, 2, 3, 0)
INSERT [dbo].[Phong] ([MaPhong], [TenPhong], [TrangThai], [MaTang], [MaLoaiPhong], [Disabled]) VALUES (10, N'Phòng 203', 0, 2, 4, 0)
INSERT [dbo].[Phong] ([MaPhong], [TenPhong], [TrangThai], [MaTang], [MaLoaiPhong], [Disabled]) VALUES (11, N'Phòng 204', 0, 2, 5, 0)
INSERT [dbo].[Phong] ([MaPhong], [TenPhong], [TrangThai], [MaTang], [MaLoaiPhong], [Disabled]) VALUES (12, N'Phòng 302', 0, 3, 1, 0)
INSERT [dbo].[Phong] ([MaPhong], [TenPhong], [TrangThai], [MaTang], [MaLoaiPhong], [Disabled]) VALUES (13, N'Phòng 303', 0, 3, 2, 0)
INSERT [dbo].[Phong] ([MaPhong], [TenPhong], [TrangThai], [MaTang], [MaLoaiPhong], [Disabled]) VALUES (14, N'Phòng 304', 0, 3, 3, 0)
INSERT [dbo].[Phong] ([MaPhong], [TenPhong], [TrangThai], [MaTang], [MaLoaiPhong], [Disabled]) VALUES (15, N'Phòng 401', 0, 4, 1, 0)
INSERT [dbo].[Phong] ([MaPhong], [TenPhong], [TrangThai], [MaTang], [MaLoaiPhong], [Disabled]) VALUES (16, N'Phòng 402', 0, 4, 2, 0)
INSERT [dbo].[Phong] ([MaPhong], [TenPhong], [TrangThai], [MaTang], [MaLoaiPhong], [Disabled]) VALUES (17, N'Phòng 403', 0, 4, 3, 0)
INSERT [dbo].[Phong] ([MaPhong], [TenPhong], [TrangThai], [MaTang], [MaLoaiPhong], [Disabled]) VALUES (18, N'Phòng 404', 0, 4, 5, 0)
INSERT [dbo].[Phong] ([MaPhong], [TenPhong], [TrangThai], [MaTang], [MaLoaiPhong], [Disabled]) VALUES (19, N'Phòng 105', 0, 1, 1, 1)
SET IDENTITY_INSERT [dbo].[Phong] OFF
GO
INSERT [dbo].[Phong_ThietBi] ([MaPhong], [MaThietBi], [SoLuong]) VALUES (2, 1, 1)
GO
INSERT [dbo].[Quyen] ([MaTinhNang], [MaNhanVien], [Quyen]) VALUES (N'CongTy', 3, 1)
INSERT [dbo].[Quyen] ([MaTinhNang], [MaNhanVien], [Quyen]) VALUES (N'CongTy', 4, 0)
INSERT [dbo].[Quyen] ([MaTinhNang], [MaNhanVien], [Quyen]) VALUES (N'CongTy', 7, 2)
INSERT [dbo].[Quyen] ([MaTinhNang], [MaNhanVien], [Quyen]) VALUES (N'CongTy', 9, 0)
INSERT [dbo].[Quyen] ([MaTinhNang], [MaNhanVien], [Quyen]) VALUES (N'CongTy', 10, 0)
INSERT [dbo].[Quyen] ([MaTinhNang], [MaNhanVien], [Quyen]) VALUES (N'CongTy', 11, 0)
INSERT [dbo].[Quyen] ([MaTinhNang], [MaNhanVien], [Quyen]) VALUES (N'CongTy', 12, 0)
INSERT [dbo].[Quyen] ([MaTinhNang], [MaNhanVien], [Quyen]) VALUES (N'CongTy', 13, 0)
INSERT [dbo].[Quyen] ([MaTinhNang], [MaNhanVien], [Quyen]) VALUES (N'CongTy', 14, 0)
INSERT [dbo].[Quyen] ([MaTinhNang], [MaNhanVien], [Quyen]) VALUES (N'CongTy', 15, 0)
INSERT [dbo].[Quyen] ([MaTinhNang], [MaNhanVien], [Quyen]) VALUES (N'CongTy', 16, 0)
INSERT [dbo].[Quyen] ([MaTinhNang], [MaNhanVien], [Quyen]) VALUES (N'CongTy', 17, 0)
INSERT [dbo].[Quyen] ([MaTinhNang], [MaNhanVien], [Quyen]) VALUES (N'DanhMuc', 3, 0)
INSERT [dbo].[Quyen] ([MaTinhNang], [MaNhanVien], [Quyen]) VALUES (N'DanhMuc', 4, 0)
INSERT [dbo].[Quyen] ([MaTinhNang], [MaNhanVien], [Quyen]) VALUES (N'DanhMuc', 7, 2)
INSERT [dbo].[Quyen] ([MaTinhNang], [MaNhanVien], [Quyen]) VALUES (N'DanhMuc', 9, 0)
INSERT [dbo].[Quyen] ([MaTinhNang], [MaNhanVien], [Quyen]) VALUES (N'DanhMuc', 10, 0)
INSERT [dbo].[Quyen] ([MaTinhNang], [MaNhanVien], [Quyen]) VALUES (N'DanhMuc', 11, 0)
INSERT [dbo].[Quyen] ([MaTinhNang], [MaNhanVien], [Quyen]) VALUES (N'DanhMuc', 12, 0)
INSERT [dbo].[Quyen] ([MaTinhNang], [MaNhanVien], [Quyen]) VALUES (N'DanhMuc', 13, 0)
INSERT [dbo].[Quyen] ([MaTinhNang], [MaNhanVien], [Quyen]) VALUES (N'DanhMuc', 14, 0)
INSERT [dbo].[Quyen] ([MaTinhNang], [MaNhanVien], [Quyen]) VALUES (N'DanhMuc', 15, 0)
INSERT [dbo].[Quyen] ([MaTinhNang], [MaNhanVien], [Quyen]) VALUES (N'DanhMuc', 16, 0)
INSERT [dbo].[Quyen] ([MaTinhNang], [MaNhanVien], [Quyen]) VALUES (N'DanhMuc', 17, 0)
INSERT [dbo].[Quyen] ([MaTinhNang], [MaNhanVien], [Quyen]) VALUES (N'DatPhongTD', 3, 1)
INSERT [dbo].[Quyen] ([MaTinhNang], [MaNhanVien], [Quyen]) VALUES (N'DatPhongTD', 4, 0)
INSERT [dbo].[Quyen] ([MaTinhNang], [MaNhanVien], [Quyen]) VALUES (N'DatPhongTD', 7, 2)
INSERT [dbo].[Quyen] ([MaTinhNang], [MaNhanVien], [Quyen]) VALUES (N'DatPhongTD', 9, 0)
INSERT [dbo].[Quyen] ([MaTinhNang], [MaNhanVien], [Quyen]) VALUES (N'DatPhongTD', 10, 0)
INSERT [dbo].[Quyen] ([MaTinhNang], [MaNhanVien], [Quyen]) VALUES (N'DatPhongTD', 11, 0)
INSERT [dbo].[Quyen] ([MaTinhNang], [MaNhanVien], [Quyen]) VALUES (N'DatPhongTD', 12, 0)
INSERT [dbo].[Quyen] ([MaTinhNang], [MaNhanVien], [Quyen]) VALUES (N'DatPhongTD', 13, 0)
INSERT [dbo].[Quyen] ([MaTinhNang], [MaNhanVien], [Quyen]) VALUES (N'DatPhongTD', 14, 0)
INSERT [dbo].[Quyen] ([MaTinhNang], [MaNhanVien], [Quyen]) VALUES (N'DatPhongTD', 15, 0)
INSERT [dbo].[Quyen] ([MaTinhNang], [MaNhanVien], [Quyen]) VALUES (N'DatPhongTD', 16, 0)
INSERT [dbo].[Quyen] ([MaTinhNang], [MaNhanVien], [Quyen]) VALUES (N'DatPhongTD', 17, 0)
INSERT [dbo].[Quyen] ([MaTinhNang], [MaNhanVien], [Quyen]) VALUES (N'DoiMK', 3, 0)
INSERT [dbo].[Quyen] ([MaTinhNang], [MaNhanVien], [Quyen]) VALUES (N'DoiMK', 4, 0)
INSERT [dbo].[Quyen] ([MaTinhNang], [MaNhanVien], [Quyen]) VALUES (N'DoiMK', 7, 2)
INSERT [dbo].[Quyen] ([MaTinhNang], [MaNhanVien], [Quyen]) VALUES (N'DoiMK', 9, 0)
INSERT [dbo].[Quyen] ([MaTinhNang], [MaNhanVien], [Quyen]) VALUES (N'DoiMK', 10, 0)
INSERT [dbo].[Quyen] ([MaTinhNang], [MaNhanVien], [Quyen]) VALUES (N'DoiMK', 11, 0)
INSERT [dbo].[Quyen] ([MaTinhNang], [MaNhanVien], [Quyen]) VALUES (N'DoiMK', 12, 0)
INSERT [dbo].[Quyen] ([MaTinhNang], [MaNhanVien], [Quyen]) VALUES (N'DoiMK', 13, 0)
INSERT [dbo].[Quyen] ([MaTinhNang], [MaNhanVien], [Quyen]) VALUES (N'DoiMK', 14, 0)
INSERT [dbo].[Quyen] ([MaTinhNang], [MaNhanVien], [Quyen]) VALUES (N'DoiMK', 15, 0)
INSERT [dbo].[Quyen] ([MaTinhNang], [MaNhanVien], [Quyen]) VALUES (N'DoiMK', 16, 0)
INSERT [dbo].[Quyen] ([MaTinhNang], [MaNhanVien], [Quyen]) VALUES (N'DoiMK', 17, 0)
INSERT [dbo].[Quyen] ([MaTinhNang], [MaNhanVien], [Quyen]) VALUES (N'DonVi', 3, 1)
INSERT [dbo].[Quyen] ([MaTinhNang], [MaNhanVien], [Quyen]) VALUES (N'DonVi', 4, 0)
INSERT [dbo].[Quyen] ([MaTinhNang], [MaNhanVien], [Quyen]) VALUES (N'DonVi', 7, 2)
INSERT [dbo].[Quyen] ([MaTinhNang], [MaNhanVien], [Quyen]) VALUES (N'DonVi', 9, 0)
INSERT [dbo].[Quyen] ([MaTinhNang], [MaNhanVien], [Quyen]) VALUES (N'DonVi', 10, 0)
INSERT [dbo].[Quyen] ([MaTinhNang], [MaNhanVien], [Quyen]) VALUES (N'DonVi', 11, 0)
INSERT [dbo].[Quyen] ([MaTinhNang], [MaNhanVien], [Quyen]) VALUES (N'DonVi', 12, 0)
INSERT [dbo].[Quyen] ([MaTinhNang], [MaNhanVien], [Quyen]) VALUES (N'DonVi', 13, 0)
INSERT [dbo].[Quyen] ([MaTinhNang], [MaNhanVien], [Quyen]) VALUES (N'DonVi', 14, 0)
INSERT [dbo].[Quyen] ([MaTinhNang], [MaNhanVien], [Quyen]) VALUES (N'DonVi', 15, 0)
INSERT [dbo].[Quyen] ([MaTinhNang], [MaNhanVien], [Quyen]) VALUES (N'DonVi', 16, 0)
INSERT [dbo].[Quyen] ([MaTinhNang], [MaNhanVien], [Quyen]) VALUES (N'DonVi', 17, 0)
INSERT [dbo].[Quyen] ([MaTinhNang], [MaNhanVien], [Quyen]) VALUES (N'HeThong', 3, 0)
INSERT [dbo].[Quyen] ([MaTinhNang], [MaNhanVien], [Quyen]) VALUES (N'HeThong', 4, 0)
INSERT [dbo].[Quyen] ([MaTinhNang], [MaNhanVien], [Quyen]) VALUES (N'HeThong', 7, 2)
INSERT [dbo].[Quyen] ([MaTinhNang], [MaNhanVien], [Quyen]) VALUES (N'HeThong', 9, 0)
INSERT [dbo].[Quyen] ([MaTinhNang], [MaNhanVien], [Quyen]) VALUES (N'HeThong', 10, 0)
INSERT [dbo].[Quyen] ([MaTinhNang], [MaNhanVien], [Quyen]) VALUES (N'HeThong', 11, 0)
INSERT [dbo].[Quyen] ([MaTinhNang], [MaNhanVien], [Quyen]) VALUES (N'HeThong', 12, 0)
INSERT [dbo].[Quyen] ([MaTinhNang], [MaNhanVien], [Quyen]) VALUES (N'HeThong', 13, 0)
INSERT [dbo].[Quyen] ([MaTinhNang], [MaNhanVien], [Quyen]) VALUES (N'HeThong', 14, 0)
INSERT [dbo].[Quyen] ([MaTinhNang], [MaNhanVien], [Quyen]) VALUES (N'HeThong', 15, 0)
INSERT [dbo].[Quyen] ([MaTinhNang], [MaNhanVien], [Quyen]) VALUES (N'HeThong', 16, 0)
INSERT [dbo].[Quyen] ([MaTinhNang], [MaNhanVien], [Quyen]) VALUES (N'HeThong', 17, 0)
INSERT [dbo].[Quyen] ([MaTinhNang], [MaNhanVien], [Quyen]) VALUES (N'KhachHang', 3, 1)
INSERT [dbo].[Quyen] ([MaTinhNang], [MaNhanVien], [Quyen]) VALUES (N'KhachHang', 4, 0)
INSERT [dbo].[Quyen] ([MaTinhNang], [MaNhanVien], [Quyen]) VALUES (N'KhachHang', 7, 2)
INSERT [dbo].[Quyen] ([MaTinhNang], [MaNhanVien], [Quyen]) VALUES (N'KhachHang', 9, 0)
INSERT [dbo].[Quyen] ([MaTinhNang], [MaNhanVien], [Quyen]) VALUES (N'KhachHang', 10, 0)
INSERT [dbo].[Quyen] ([MaTinhNang], [MaNhanVien], [Quyen]) VALUES (N'KhachHang', 11, 0)
INSERT [dbo].[Quyen] ([MaTinhNang], [MaNhanVien], [Quyen]) VALUES (N'KhachHang', 12, 0)
INSERT [dbo].[Quyen] ([MaTinhNang], [MaNhanVien], [Quyen]) VALUES (N'KhachHang', 13, 0)
INSERT [dbo].[Quyen] ([MaTinhNang], [MaNhanVien], [Quyen]) VALUES (N'KhachHang', 14, 0)
INSERT [dbo].[Quyen] ([MaTinhNang], [MaNhanVien], [Quyen]) VALUES (N'KhachHang', 15, 0)
INSERT [dbo].[Quyen] ([MaTinhNang], [MaNhanVien], [Quyen]) VALUES (N'KhachHang', 16, 0)
INSERT [dbo].[Quyen] ([MaTinhNang], [MaNhanVien], [Quyen]) VALUES (N'KhachHang', 17, 0)
INSERT [dbo].[Quyen] ([MaTinhNang], [MaNhanVien], [Quyen]) VALUES (N'LoaiPhong', 3, 1)
INSERT [dbo].[Quyen] ([MaTinhNang], [MaNhanVien], [Quyen]) VALUES (N'LoaiPhong', 4, 0)
INSERT [dbo].[Quyen] ([MaTinhNang], [MaNhanVien], [Quyen]) VALUES (N'LoaiPhong', 7, 2)
INSERT [dbo].[Quyen] ([MaTinhNang], [MaNhanVien], [Quyen]) VALUES (N'LoaiPhong', 9, 0)
INSERT [dbo].[Quyen] ([MaTinhNang], [MaNhanVien], [Quyen]) VALUES (N'LoaiPhong', 10, 0)
INSERT [dbo].[Quyen] ([MaTinhNang], [MaNhanVien], [Quyen]) VALUES (N'LoaiPhong', 11, 0)
INSERT [dbo].[Quyen] ([MaTinhNang], [MaNhanVien], [Quyen]) VALUES (N'LoaiPhong', 12, 0)
INSERT [dbo].[Quyen] ([MaTinhNang], [MaNhanVien], [Quyen]) VALUES (N'LoaiPhong', 13, 0)
INSERT [dbo].[Quyen] ([MaTinhNang], [MaNhanVien], [Quyen]) VALUES (N'LoaiPhong', 14, 0)
INSERT [dbo].[Quyen] ([MaTinhNang], [MaNhanVien], [Quyen]) VALUES (N'LoaiPhong', 15, 0)
INSERT [dbo].[Quyen] ([MaTinhNang], [MaNhanVien], [Quyen]) VALUES (N'LoaiPhong', 16, 0)
INSERT [dbo].[Quyen] ([MaTinhNang], [MaNhanVien], [Quyen]) VALUES (N'LoaiPhong', 17, 0)
INSERT [dbo].[Quyen] ([MaTinhNang], [MaNhanVien], [Quyen]) VALUES (N'Phong', 3, 1)
INSERT [dbo].[Quyen] ([MaTinhNang], [MaNhanVien], [Quyen]) VALUES (N'Phong', 4, 0)
INSERT [dbo].[Quyen] ([MaTinhNang], [MaNhanVien], [Quyen]) VALUES (N'Phong', 7, 2)
INSERT [dbo].[Quyen] ([MaTinhNang], [MaNhanVien], [Quyen]) VALUES (N'Phong', 9, 0)
GO
INSERT [dbo].[Quyen] ([MaTinhNang], [MaNhanVien], [Quyen]) VALUES (N'Phong', 10, 0)
INSERT [dbo].[Quyen] ([MaTinhNang], [MaNhanVien], [Quyen]) VALUES (N'Phong', 11, 0)
INSERT [dbo].[Quyen] ([MaTinhNang], [MaNhanVien], [Quyen]) VALUES (N'Phong', 12, 0)
INSERT [dbo].[Quyen] ([MaTinhNang], [MaNhanVien], [Quyen]) VALUES (N'Phong', 13, 0)
INSERT [dbo].[Quyen] ([MaTinhNang], [MaNhanVien], [Quyen]) VALUES (N'Phong', 14, 0)
INSERT [dbo].[Quyen] ([MaTinhNang], [MaNhanVien], [Quyen]) VALUES (N'Phong', 15, 0)
INSERT [dbo].[Quyen] ([MaTinhNang], [MaNhanVien], [Quyen]) VALUES (N'Phong', 16, 0)
INSERT [dbo].[Quyen] ([MaTinhNang], [MaNhanVien], [Quyen]) VALUES (N'Phong', 17, 0)
INSERT [dbo].[Quyen] ([MaTinhNang], [MaNhanVien], [Quyen]) VALUES (N'Phong_ThietBi', 3, 1)
INSERT [dbo].[Quyen] ([MaTinhNang], [MaNhanVien], [Quyen]) VALUES (N'Phong_ThietBi', 4, 0)
INSERT [dbo].[Quyen] ([MaTinhNang], [MaNhanVien], [Quyen]) VALUES (N'Phong_ThietBi', 7, 2)
INSERT [dbo].[Quyen] ([MaTinhNang], [MaNhanVien], [Quyen]) VALUES (N'Phong_ThietBi', 9, 0)
INSERT [dbo].[Quyen] ([MaTinhNang], [MaNhanVien], [Quyen]) VALUES (N'Phong_ThietBi', 10, 0)
INSERT [dbo].[Quyen] ([MaTinhNang], [MaNhanVien], [Quyen]) VALUES (N'Phong_ThietBi', 11, 0)
INSERT [dbo].[Quyen] ([MaTinhNang], [MaNhanVien], [Quyen]) VALUES (N'Phong_ThietBi', 12, 0)
INSERT [dbo].[Quyen] ([MaTinhNang], [MaNhanVien], [Quyen]) VALUES (N'Phong_ThietBi', 13, 0)
INSERT [dbo].[Quyen] ([MaTinhNang], [MaNhanVien], [Quyen]) VALUES (N'Phong_ThietBi', 14, 0)
INSERT [dbo].[Quyen] ([MaTinhNang], [MaNhanVien], [Quyen]) VALUES (N'Phong_ThietBi', 15, 0)
INSERT [dbo].[Quyen] ([MaTinhNang], [MaNhanVien], [Quyen]) VALUES (N'Phong_ThietBi', 16, 0)
INSERT [dbo].[Quyen] ([MaTinhNang], [MaNhanVien], [Quyen]) VALUES (N'Phong_ThietBi', 17, 0)
INSERT [dbo].[Quyen] ([MaTinhNang], [MaNhanVien], [Quyen]) VALUES (N'QuanLyNguoiDung', 3, 0)
INSERT [dbo].[Quyen] ([MaTinhNang], [MaNhanVien], [Quyen]) VALUES (N'QuanLyNguoiDung', 4, 0)
INSERT [dbo].[Quyen] ([MaTinhNang], [MaNhanVien], [Quyen]) VALUES (N'QuanLyNguoiDung', 7, 2)
INSERT [dbo].[Quyen] ([MaTinhNang], [MaNhanVien], [Quyen]) VALUES (N'QuanLyNguoiDung', 9, 0)
INSERT [dbo].[Quyen] ([MaTinhNang], [MaNhanVien], [Quyen]) VALUES (N'QuanLyNguoiDung', 10, 0)
INSERT [dbo].[Quyen] ([MaTinhNang], [MaNhanVien], [Quyen]) VALUES (N'QuanLyNguoiDung', 11, 0)
INSERT [dbo].[Quyen] ([MaTinhNang], [MaNhanVien], [Quyen]) VALUES (N'QuanLyNguoiDung', 12, 0)
INSERT [dbo].[Quyen] ([MaTinhNang], [MaNhanVien], [Quyen]) VALUES (N'QuanLyNguoiDung', 13, 0)
INSERT [dbo].[Quyen] ([MaTinhNang], [MaNhanVien], [Quyen]) VALUES (N'QuanLyNguoiDung', 14, 0)
INSERT [dbo].[Quyen] ([MaTinhNang], [MaNhanVien], [Quyen]) VALUES (N'QuanLyNguoiDung', 15, 0)
INSERT [dbo].[Quyen] ([MaTinhNang], [MaNhanVien], [Quyen]) VALUES (N'QuanLyNguoiDung', 16, 0)
INSERT [dbo].[Quyen] ([MaTinhNang], [MaNhanVien], [Quyen]) VALUES (N'QuanLyNguoiDung', 17, 0)
INSERT [dbo].[Quyen] ([MaTinhNang], [MaNhanVien], [Quyen]) VALUES (N'SanPham', 3, 1)
INSERT [dbo].[Quyen] ([MaTinhNang], [MaNhanVien], [Quyen]) VALUES (N'SanPham', 4, 0)
INSERT [dbo].[Quyen] ([MaTinhNang], [MaNhanVien], [Quyen]) VALUES (N'SanPham', 7, 2)
INSERT [dbo].[Quyen] ([MaTinhNang], [MaNhanVien], [Quyen]) VALUES (N'SanPham', 9, 0)
INSERT [dbo].[Quyen] ([MaTinhNang], [MaNhanVien], [Quyen]) VALUES (N'SanPham', 10, 0)
INSERT [dbo].[Quyen] ([MaTinhNang], [MaNhanVien], [Quyen]) VALUES (N'SanPham', 11, 0)
INSERT [dbo].[Quyen] ([MaTinhNang], [MaNhanVien], [Quyen]) VALUES (N'SanPham', 12, 0)
INSERT [dbo].[Quyen] ([MaTinhNang], [MaNhanVien], [Quyen]) VALUES (N'SanPham', 13, 0)
INSERT [dbo].[Quyen] ([MaTinhNang], [MaNhanVien], [Quyen]) VALUES (N'SanPham', 14, 0)
INSERT [dbo].[Quyen] ([MaTinhNang], [MaNhanVien], [Quyen]) VALUES (N'SanPham', 15, 0)
INSERT [dbo].[Quyen] ([MaTinhNang], [MaNhanVien], [Quyen]) VALUES (N'SanPham', 16, 0)
INSERT [dbo].[Quyen] ([MaTinhNang], [MaNhanVien], [Quyen]) VALUES (N'SanPham', 17, 0)
INSERT [dbo].[Quyen] ([MaTinhNang], [MaNhanVien], [Quyen]) VALUES (N'Tang', 3, 1)
INSERT [dbo].[Quyen] ([MaTinhNang], [MaNhanVien], [Quyen]) VALUES (N'Tang', 4, 0)
INSERT [dbo].[Quyen] ([MaTinhNang], [MaNhanVien], [Quyen]) VALUES (N'Tang', 7, 2)
INSERT [dbo].[Quyen] ([MaTinhNang], [MaNhanVien], [Quyen]) VALUES (N'Tang', 9, 0)
INSERT [dbo].[Quyen] ([MaTinhNang], [MaNhanVien], [Quyen]) VALUES (N'Tang', 10, 0)
INSERT [dbo].[Quyen] ([MaTinhNang], [MaNhanVien], [Quyen]) VALUES (N'Tang', 11, 0)
INSERT [dbo].[Quyen] ([MaTinhNang], [MaNhanVien], [Quyen]) VALUES (N'Tang', 12, 0)
INSERT [dbo].[Quyen] ([MaTinhNang], [MaNhanVien], [Quyen]) VALUES (N'Tang', 13, 0)
INSERT [dbo].[Quyen] ([MaTinhNang], [MaNhanVien], [Quyen]) VALUES (N'Tang', 14, 0)
INSERT [dbo].[Quyen] ([MaTinhNang], [MaNhanVien], [Quyen]) VALUES (N'Tang', 15, 0)
INSERT [dbo].[Quyen] ([MaTinhNang], [MaNhanVien], [Quyen]) VALUES (N'Tang', 16, 0)
INSERT [dbo].[Quyen] ([MaTinhNang], [MaNhanVien], [Quyen]) VALUES (N'Tang', 17, 0)
INSERT [dbo].[Quyen] ([MaTinhNang], [MaNhanVien], [Quyen]) VALUES (N'ThietBi', 3, 1)
INSERT [dbo].[Quyen] ([MaTinhNang], [MaNhanVien], [Quyen]) VALUES (N'ThietBi', 4, 0)
INSERT [dbo].[Quyen] ([MaTinhNang], [MaNhanVien], [Quyen]) VALUES (N'ThietBi', 7, 2)
INSERT [dbo].[Quyen] ([MaTinhNang], [MaNhanVien], [Quyen]) VALUES (N'ThietBi', 9, 0)
INSERT [dbo].[Quyen] ([MaTinhNang], [MaNhanVien], [Quyen]) VALUES (N'ThietBi', 10, 0)
INSERT [dbo].[Quyen] ([MaTinhNang], [MaNhanVien], [Quyen]) VALUES (N'ThietBi', 11, 0)
INSERT [dbo].[Quyen] ([MaTinhNang], [MaNhanVien], [Quyen]) VALUES (N'ThietBi', 12, 0)
INSERT [dbo].[Quyen] ([MaTinhNang], [MaNhanVien], [Quyen]) VALUES (N'ThietBi', 13, 0)
INSERT [dbo].[Quyen] ([MaTinhNang], [MaNhanVien], [Quyen]) VALUES (N'ThietBi', 14, 0)
INSERT [dbo].[Quyen] ([MaTinhNang], [MaNhanVien], [Quyen]) VALUES (N'ThietBi', 15, 0)
INSERT [dbo].[Quyen] ([MaTinhNang], [MaNhanVien], [Quyen]) VALUES (N'ThietBi', 16, 0)
INSERT [dbo].[Quyen] ([MaTinhNang], [MaNhanVien], [Quyen]) VALUES (N'ThietBi', 17, 0)
GO
SET IDENTITY_INSERT [dbo].[SanPham] ON 

INSERT [dbo].[SanPham] ([MaSanPham], [TenSanPham], [DonGia], [Disabled]) VALUES (1, N'Sting', 15000, 0)
INSERT [dbo].[SanPham] ([MaSanPham], [TenSanPham], [DonGia], [Disabled]) VALUES (2, N'Cocacola', 10000, 0)
INSERT [dbo].[SanPham] ([MaSanPham], [TenSanPham], [DonGia], [Disabled]) VALUES (3, N'Cam ép', 150000, 0)
INSERT [dbo].[SanPham] ([MaSanPham], [TenSanPham], [DonGia], [Disabled]) VALUES (4, N'Redbull', 20000, 0)
INSERT [dbo].[SanPham] ([MaSanPham], [TenSanPham], [DonGia], [Disabled]) VALUES (5, N'Nước suối', 12000, 0)
INSERT [dbo].[SanPham] ([MaSanPham], [TenSanPham], [DonGia], [Disabled]) VALUES (6, N'Pepsi', 10000, 0)
SET IDENTITY_INSERT [dbo].[SanPham] OFF
GO
SET IDENTITY_INSERT [dbo].[Tang] ON 

INSERT [dbo].[Tang] ([MaTang], [TenTang], [Disabled]) VALUES (1, N'Tầng 1', 0)
INSERT [dbo].[Tang] ([MaTang], [TenTang], [Disabled]) VALUES (2, N'Tầng 2', 0)
INSERT [dbo].[Tang] ([MaTang], [TenTang], [Disabled]) VALUES (3, N'Tầng 3', 0)
INSERT [dbo].[Tang] ([MaTang], [TenTang], [Disabled]) VALUES (4, N'Tầng 4', 0)
INSERT [dbo].[Tang] ([MaTang], [TenTang], [Disabled]) VALUES (5, N'Tầng 5', 1)
SET IDENTITY_INSERT [dbo].[Tang] OFF
GO
SET IDENTITY_INSERT [dbo].[ThietBi] ON 

INSERT [dbo].[ThietBi] ([MaThietBi], [TenThietBi], [DonGia], [Disabled]) VALUES (1, N'Máy lạnh', 900000, 0)
INSERT [dbo].[ThietBi] ([MaThietBi], [TenThietBi], [DonGia], [Disabled]) VALUES (2, N'Mền', 150000, 0)
INSERT [dbo].[ThietBi] ([MaThietBi], [TenThietBi], [DonGia], [Disabled]) VALUES (3, N'Gối', 50000, 0)
SET IDENTITY_INSERT [dbo].[ThietBi] OFF
GO
INSERT [dbo].[TinhNang] ([MaTinhNang], [SapXep], [Decription], [IsGroup], [Parent], [Menu], [Tips]) VALUES (N'CongTy', 101, N'Danh Mục Công Ty', 0, N'DanhMuc', 1, N'Quản lý danh mục Công Ty')
INSERT [dbo].[TinhNang] ([MaTinhNang], [SapXep], [Decription], [IsGroup], [Parent], [Menu], [Tips]) VALUES (N'DanhMuc', 100, N'DANH MỤC', 1, NULL, 1, N'Danh mục dùng chung')
INSERT [dbo].[TinhNang] ([MaTinhNang], [SapXep], [Decription], [IsGroup], [Parent], [Menu], [Tips]) VALUES (N'DatPhongTD', 110, N'Đặt Phòng Theo Đoàn', 0, N'DanhMuc', 1, NULL)
INSERT [dbo].[TinhNang] ([MaTinhNang], [SapXep], [Decription], [IsGroup], [Parent], [Menu], [Tips]) VALUES (N'DoiMK', 201, N'Thay Đổi Mật Khẩu', 0, N'HeThong', 1, N'Thay đổi mật khẩu người dùng hiện tại')
INSERT [dbo].[TinhNang] ([MaTinhNang], [SapXep], [Decription], [IsGroup], [Parent], [Menu], [Tips]) VALUES (N'DonVi', 102, N'Danh mục đơn vị', 0, N'DanhMuc', 1, N'Quản lý danh mục đơn vị')
INSERT [dbo].[TinhNang] ([MaTinhNang], [SapXep], [Decription], [IsGroup], [Parent], [Menu], [Tips]) VALUES (N'HeThong', 200, N'HỆ THỐNG', 1, NULL, 1, N'Tính năng hệ thống')
INSERT [dbo].[TinhNang] ([MaTinhNang], [SapXep], [Decription], [IsGroup], [Parent], [Menu], [Tips]) VALUES (N'KhachHang', 103, N'Quản Lý Khách Hàng', 0, N'DanhMuc', 1, NULL)
INSERT [dbo].[TinhNang] ([MaTinhNang], [SapXep], [Decription], [IsGroup], [Parent], [Menu], [Tips]) VALUES (N'LoaiPhong', 105, N'Quản Lý Loại Phòng', 0, N'DanhMuc', 1, NULL)
INSERT [dbo].[TinhNang] ([MaTinhNang], [SapXep], [Decription], [IsGroup], [Parent], [Menu], [Tips]) VALUES (N'Phong', 106, N'Quản Lý Phòng', 0, N'DanhMuc', 1, NULL)
INSERT [dbo].[TinhNang] ([MaTinhNang], [SapXep], [Decription], [IsGroup], [Parent], [Menu], [Tips]) VALUES (N'Phong_ThietBi', 109, N'Quản Lý Thiết Bị Phòng', 0, N'DanhMuc', 1, NULL)
INSERT [dbo].[TinhNang] ([MaTinhNang], [SapXep], [Decription], [IsGroup], [Parent], [Menu], [Tips]) VALUES (N'QuanLyNguoiDung', 202, N'Quản Lý Người Dùng', 0, N'HeThong', 1, NULL)
INSERT [dbo].[TinhNang] ([MaTinhNang], [SapXep], [Decription], [IsGroup], [Parent], [Menu], [Tips]) VALUES (N'SanPham', 107, N'Quản Lý Sản Phẩm', 0, N'DanhMuc', 1, NULL)
INSERT [dbo].[TinhNang] ([MaTinhNang], [SapXep], [Decription], [IsGroup], [Parent], [Menu], [Tips]) VALUES (N'Tang', 104, N'Quản Lý Tầng', 0, N'DanhMuc', 1, NULL)
INSERT [dbo].[TinhNang] ([MaTinhNang], [SapXep], [Decription], [IsGroup], [Parent], [Menu], [Tips]) VALUES (N'ThietBi', 108, N'Quản Lý Thiết Bị', 0, N'DanhMuc', 1, NULL)
GO
ALTER TABLE [dbo].[DatPhong]  WITH CHECK ADD  CONSTRAINT [FK__DatPhong__MaKhac__3F466844] FOREIGN KEY([MaKhachHang])
REFERENCES [dbo].[KhachHang] ([MaKhachHang])
GO
ALTER TABLE [dbo].[DatPhong] CHECK CONSTRAINT [FK__DatPhong__MaKhac__3F466844]
GO
ALTER TABLE [dbo].[DatPhong]  WITH CHECK ADD  CONSTRAINT [FK__DatPhong__MaNhan__412EB0B6] FOREIGN KEY([MaNhanVien])
REFERENCES [dbo].[NhanVien] ([MaNhanVien])
GO
ALTER TABLE [dbo].[DatPhong] CHECK CONSTRAINT [FK__DatPhong__MaNhan__412EB0B6]
GO
ALTER TABLE [dbo].[DonVi]  WITH CHECK ADD FOREIGN KEY([MaCongTy])
REFERENCES [dbo].[CongTy] ([MaCongTy])
GO
ALTER TABLE [dbo].[NhanVien]  WITH CHECK ADD FOREIGN KEY([MaCongTy])
REFERENCES [dbo].[CongTy] ([MaCongTy])
GO
ALTER TABLE [dbo].[NhanVien]  WITH CHECK ADD FOREIGN KEY([MaDonVi])
REFERENCES [dbo].[DonVi] ([MaDonVi])
GO
ALTER TABLE [dbo].[Phong]  WITH CHECK ADD  CONSTRAINT [FK__Phong__MaLoaiPho__33D4B598] FOREIGN KEY([MaLoaiPhong])
REFERENCES [dbo].[LoaiPhong] ([MaLoaiPhong])
GO
ALTER TABLE [dbo].[Phong] CHECK CONSTRAINT [FK__Phong__MaLoaiPho__33D4B598]
GO
ALTER TABLE [dbo].[Phong]  WITH CHECK ADD  CONSTRAINT [FK__Phong__MaTang__32E0915F] FOREIGN KEY([MaTang])
REFERENCES [dbo].[Tang] ([MaTang])
GO
ALTER TABLE [dbo].[Phong] CHECK CONSTRAINT [FK__Phong__MaTang__32E0915F]
GO
ALTER TABLE [dbo].[Phong_ThietBi]  WITH CHECK ADD  CONSTRAINT [FK__Phong_Thi__MaPho__36B12243] FOREIGN KEY([MaPhong])
REFERENCES [dbo].[Phong] ([MaPhong])
GO
ALTER TABLE [dbo].[Phong_ThietBi] CHECK CONSTRAINT [FK__Phong_Thi__MaPho__36B12243]
GO
ALTER TABLE [dbo].[Phong_ThietBi]  WITH CHECK ADD FOREIGN KEY([MaThietBi])
REFERENCES [dbo].[ThietBi] ([MaThietBi])
GO
/****** Object:  StoredProcedure [dbo].[PHIEU_DATPHONG]    Script Date: 1/2/2023 2:13:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[PHIEU_DATPHONG] @MADATPHONG INT
AS
BEGIN
	SELECT C.MaDatPhong, C.MaKhachHang, D.TenKhachHang, D.DienThoai, D.DiaChi, C.NgayDatPhong, C.NgayTraPhong, 
		C.SoTien, C.SoNguoiO, C.MaCongTy, C.MaDonVi, C.TrangThai, C.GhiChu, E.MaPhong, F.TenPhong, 
		E.SoNgayO, E.DonGia AS 'dp_DonGia', E.ThanhTien AS 'dp_ThanhTien', B.MaChiTietSanPham, A.TenSanPham, B.SoLuong AS 'sp_SoLuong', 
		B.DonGia AS 'sp_DonGia', B.ThanhTien AS 'sp_ThanhTien'
	FROM SanPham A INNER JOIN
		DatPhong_SanPham B ON A.MaSanPham = B.MaSanPham RIGHT OUTER JOIN
		DatPhong C INNER JOIN
		KhachHang D ON C.MaKhachHang = D.MaKhachHang RIGHT OUTER JOIN
		ChiTietDatPhong E INNER JOIN
		Phong F ON E.MaPhong = F.MaPhong ON C.MaDatPhong = E.MaDatPhong ON 
		B.MaChiTietDatPhong = E.MaChiTietDatPhong
	WHERE C.MaDatPhong = @MADATPHONG
END
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "NhanVien"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 136
               Right = 208
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 9
         Width = 284
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'NhanVienKhongTrongNhom'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'NhanVienKhongTrongNhom'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "NhanVien"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 136
               Right = 208
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "NhomQuyen"
            Begin Extent = 
               Top = 9
               Left = 321
               Bottom = 105
               Right = 491
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 11
         Width = 284
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'NhanVienTrongNhom'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'NhanVienTrongNhom'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "DatPhong"
            Begin Extent = 
               Top = 12
               Left = 252
               Bottom = 142
               Right = 457
            End
            DisplayFlags = 280
            TopColumn = 9
         End
         Begin Table = "DatPhong_SanPham"
            Begin Extent = 
               Top = 153
               Left = 776
               Bottom = 283
               Right = 972
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "ChiTietDatPhong"
            Begin Extent = 
               Top = 0
               Left = 519
               Bottom = 167
               Right = 715
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "KhachHang"
            Begin Extent = 
               Top = 10
               Left = 30
               Bottom = 140
               Right = 200
            End
            DisplayFlags = 280
            TopColumn = 3
         End
         Begin Table = "Phong"
            Begin Extent = 
               Top = 0
               Left = 990
               Bottom = 145
               Right = 1160
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "SanPham"
            Begin Extent = 
               Top = 183
               Left = 1160
               Bottom = 313
               Right = 1330
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'View_1'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane2', @value=N'1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'View_1'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=2 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'View_1'
GO
