Create database KhachSan
go

use KhachSan
go

Create table CongTy
(
	MaCongTy varchar(15) primary key,
	TenCongTy Nvarchar(100),
	DienThoai varchar(15),
	Fax Nvarchar(10),
	Email Nvarchar(100),
	DiaChi Nvarchar(300)
)
go

Create table DonVi
(
	MaDonVi varchar(15) primary key,
	TenDonVi Nvarchar(100),
	DienThoai varchar(15),
	Fax Nvarchar(10),
	Email Nvarchar(100),
	DiaChi Nvarchar(300),
	MaCongTy varchar(15) not null references CongTy(MaCongTy)
)
go

Create table LoaiPhong
(
	MaLoaiPhong int identity(1,1) primary key,
	TenLoaiPhong Nvarchar(100),
	DonGia float,
	SoNguoi int,
	SoGiuong int
)
go

Create table ThietBi
(
	MaThietBi int identity(1,1) primary key,
	TenThietBi Nvarchar(100),
	DonGia float
)
go

Create table SanPham
(
	MaSanPham int identity(1,1) primary key,
	TenSanPham Nvarchar(100),
	DonGia float
)
go

Create table Tang
(
	MaTang int identity(1,1) primary key,
	TenTang Nvarchar(100),
)
go

Create table KhachHang
(
	MaKhachHang int identity(1,1) primary key,
	TenKhachHang Nvarchar(100),
	CCCD varchar(20),
	DienThoai varchar(15),
	Email Nvarchar(100),
	DiaChi Nvarchar(300),
)
go

Create table Phong
(
	MaPhong int identity(1,1) primary key,
	TenPhong Nvarchar(100),
	TrangThai bit,
	MaTang int not null references Tang(MaTang),
	MaLoaiPhong int not null references LoaiPhong(MaLoaiPhong)
)
go

Create table Phong_ThietBi
(
	MaPhong int references Phong(MaPhong),
	MaThietBi int references ThietBi(MaThietBi),
	SoLuong int,
	primary key(MaPhong,MaThietBi)
)
go

Create table NhanVien
(
	MaNhanVien int identity(1,1) primary key,
	TenNhanVien Nvarchar(100),
	TenDangNhap varchar(100),
	MatKhau varchar(100),
	MaCongTy varchar(15) references CongTy(MaCongTy),
	MaDonVi varchar(15) references DonVi(MaDonVi),
	Nhom bit,
	KhoaTaiKhoan bit
)
go

Create table DatPhong
(
	MaDatPhong int identity(1,1) primary key,
	MaKhachHang int references KhachHang(MaKhachHang),
	MaPhong int references Phong(MaPhong),
	NgayDat datetime,
	NgayTra datetime,
	SoNgayO int,
	MaNhanVien int references NhanVien(MaNhanVien),
	MaSanPham int,
	MaCongTy varchar(15),
	MaDonVi varchar(15),
)
go

Create table TinhNang
(
	MaTinhNang varchar(15),
	SapXep int,
	Decription Nvarchar(200),
	IsGroup bit,
	Parent Nvarchar(100),
	Menu bit,
	Tips Nvarchar(300),
	primary key(MaTinhNang, SapXep)
)
go