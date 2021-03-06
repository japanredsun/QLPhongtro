USE [master]
GO
/****** Object:  Database [QLPhongTro]    Script Date: 05/28/2017 18:49:59 ******/
CREATE DATABASE [QLPhongTro] ON  PRIMARY 
( NAME = N'QLPhongTro', FILENAME = N'E:\GIT\QLPhongTro.mdf' , SIZE = 51200KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'QLPhongTro_log', FILENAME = N'E:\GIT\QLPhongTro_1.ldf' , SIZE = 5120KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [QLPhongTro] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [QLPhongTro].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [QLPhongTro] SET ANSI_NULL_DEFAULT OFF
GO
ALTER DATABASE [QLPhongTro] SET ANSI_NULLS OFF
GO
ALTER DATABASE [QLPhongTro] SET ANSI_PADDING OFF
GO
ALTER DATABASE [QLPhongTro] SET ANSI_WARNINGS OFF
GO
ALTER DATABASE [QLPhongTro] SET ARITHABORT OFF
GO
ALTER DATABASE [QLPhongTro] SET AUTO_CLOSE OFF
GO
ALTER DATABASE [QLPhongTro] SET AUTO_CREATE_STATISTICS ON
GO
ALTER DATABASE [QLPhongTro] SET AUTO_SHRINK OFF
GO
ALTER DATABASE [QLPhongTro] SET AUTO_UPDATE_STATISTICS ON
GO
ALTER DATABASE [QLPhongTro] SET CURSOR_CLOSE_ON_COMMIT OFF
GO
ALTER DATABASE [QLPhongTro] SET CURSOR_DEFAULT  GLOBAL
GO
ALTER DATABASE [QLPhongTro] SET CONCAT_NULL_YIELDS_NULL OFF
GO
ALTER DATABASE [QLPhongTro] SET NUMERIC_ROUNDABORT OFF
GO
ALTER DATABASE [QLPhongTro] SET QUOTED_IDENTIFIER OFF
GO
ALTER DATABASE [QLPhongTro] SET RECURSIVE_TRIGGERS OFF
GO
ALTER DATABASE [QLPhongTro] SET  DISABLE_BROKER
GO
ALTER DATABASE [QLPhongTro] SET AUTO_UPDATE_STATISTICS_ASYNC OFF
GO
ALTER DATABASE [QLPhongTro] SET DATE_CORRELATION_OPTIMIZATION OFF
GO
ALTER DATABASE [QLPhongTro] SET TRUSTWORTHY OFF
GO
ALTER DATABASE [QLPhongTro] SET ALLOW_SNAPSHOT_ISOLATION OFF
GO
ALTER DATABASE [QLPhongTro] SET PARAMETERIZATION SIMPLE
GO
ALTER DATABASE [QLPhongTro] SET READ_COMMITTED_SNAPSHOT OFF
GO
ALTER DATABASE [QLPhongTro] SET HONOR_BROKER_PRIORITY OFF
GO
ALTER DATABASE [QLPhongTro] SET  READ_WRITE
GO
ALTER DATABASE [QLPhongTro] SET RECOVERY SIMPLE
GO
ALTER DATABASE [QLPhongTro] SET  MULTI_USER
GO
ALTER DATABASE [QLPhongTro] SET PAGE_VERIFY CHECKSUM
GO
ALTER DATABASE [QLPhongTro] SET DB_CHAINING OFF
GO
EXEC sys.sp_db_vardecimal_storage_format N'QLPhongTro', N'ON'
GO
USE [QLPhongTro]
GO
/****** Object:  Table [dbo].[LoaiPhong]    Script Date: 05/28/2017 18:50:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LoaiPhong](
	[MaLoaiPhong] [nchar](10) NOT NULL,
	[TenLoaiPhong] [nvarchar](50) NULL,
	[DienTichPhong] [float] NULL,
	[DonGia] [float] NULL,
	[GhiChu] [nvarchar](50) NULL,
 CONSTRAINT [PK_LoaiPhong] PRIMARY KEY CLUSTERED 
(
	[MaLoaiPhong] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[LoaiPhong] ([MaLoaiPhong], [TenLoaiPhong], [DienTichPhong], [DonGia], [GhiChu]) VALUES (N'1         ', N'Nhỏ', 10, 1000000, NULL)
INSERT [dbo].[LoaiPhong] ([MaLoaiPhong], [TenLoaiPhong], [DienTichPhong], [DonGia], [GhiChu]) VALUES (N'2         ', N'Vừa', 20, 1500000, NULL)
INSERT [dbo].[LoaiPhong] ([MaLoaiPhong], [TenLoaiPhong], [DienTichPhong], [DonGia], [GhiChu]) VALUES (N'3         ', N'Lớn', 30, 2000000, NULL)
/****** Object:  Table [dbo].[KhuVuc]    Script Date: 05/28/2017 18:50:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KhuVuc](
	[MaKhuVuc] [nchar](10) NOT NULL,
	[TenKhuVuc] [nvarchar](50) NULL,
 CONSTRAINT [PK_KhuVuc] PRIMARY KEY CLUSTERED 
(
	[MaKhuVuc] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[KhuVuc] ([MaKhuVuc], [TenKhuVuc]) VALUES (N'KV01      ', N'Q.Bình Tân')
INSERT [dbo].[KhuVuc] ([MaKhuVuc], [TenKhuVuc]) VALUES (N'KV02      ', N'Q.12')
/****** Object:  Table [dbo].[GhiNho]    Script Date: 05/28/2017 18:50:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GhiNho](
	[ID] [nchar](10) NULL,
	[Pass] [nchar](10) NULL
) ON [PRIMARY]
GO
INSERT [dbo].[GhiNho] ([ID], [Pass]) VALUES (N'KDC       ', N'1996      ')
/****** Object:  Table [dbo].[DichVu]    Script Date: 05/28/2017 18:50:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DichVu](
	[Id] [int] NOT NULL,
	[TenDichVu] [nvarchar](50) NULL,
	[Gia] [bigint] NULL,
 CONSTRAINT [PK_DichVu] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[DichVu] ([Id], [TenDichVu], [Gia]) VALUES (1, N'Điện', 2500)
INSERT [dbo].[DichVu] ([Id], [TenDichVu], [Gia]) VALUES (2, N'Nước', 15000)
INSERT [dbo].[DichVu] ([Id], [TenDichVu], [Gia]) VALUES (3, N'Wifi', 200000)
INSERT [dbo].[DichVu] ([Id], [TenDichVu], [Gia]) VALUES (4, N'Nước_2', 20000)
/****** Object:  Table [dbo].[DangNhap]    Script Date: 05/28/2017 18:50:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DangNhap](
	[ID] [nvarchar](50) NULL,
	[PassWord] [nchar](10) NULL
) ON [PRIMARY]
GO
INSERT [dbo].[DangNhap] ([ID], [PassWord]) VALUES (N'KDC', N'1996      ')
INSERT [dbo].[DangNhap] ([ID], [PassWord]) VALUES (N'JR', N'123123    ')
INSERT [dbo].[DangNhap] ([ID], [PassWord]) VALUES (N'TL', N'123123    ')
INSERT [dbo].[DangNhap] ([ID], [PassWord]) VALUES (N'QL', N'123123    ')
/****** Object:  Table [dbo].[ThongTinKhach]    Script Date: 05/28/2017 18:50:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ThongTinKhach](
	[MaKhachTro] [nchar](10) NOT NULL,
	[Ho] [nvarchar](50) NULL,
	[Ten] [nvarchar](50) NULL,
	[GioiTinh] [nvarchar](50) NULL,
	[AnhNhanDien] [image] NULL,
	[NgaySinh] [date] NULL,
	[CMND] [nchar](10) NULL,
	[QueQuan] [nvarchar](50) NULL,
	[NgheNghiep] [nvarchar](50) NULL,
	[MaPhong] [nchar](10) NULL,
	[GhiChu] [nvarchar](50) NULL,
 CONSTRAINT [PK_ThongTinKhach] PRIMARY KEY CLUSTERED 
(
	[MaKhachTro] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[ThongTinKhach] ([MaKhachTro], [Ho], [Ten], [GioiTinh], [AnhNhanDien], [NgaySinh], [CMND], [QueQuan], [NgheNghiep], [MaPhong], [GhiChu]) VALUES (N'KT001     ', N'Hà Tuấn', N'An', N'Nam', NULL, CAST(0xE51C0B00 AS Date), N'123456789 ', N'Hà Nội', N'Công Nhân', N'QBTA01    ', N'1')
INSERT [dbo].[ThongTinKhach] ([MaKhachTro], [Ho], [Ten], [GioiTinh], [AnhNhanDien], [NgaySinh], [CMND], [QueQuan], [NgheNghiep], [MaPhong], [GhiChu]) VALUES (N'KT002     ', N'Trần Quốc', N'Bảo', N'Nam', NULL, CAST(0xE61C0B00 AS Date), N'123456788 ', N'Hải Phòng', N'Công Nhân', N'QBTA02    ', N'1')
INSERT [dbo].[ThongTinKhach] ([MaKhachTro], [Ho], [Ten], [GioiTinh], [AnhNhanDien], [NgaySinh], [CMND], [QueQuan], [NgheNghiep], [MaPhong], [GhiChu]) VALUES (N'KT003     ', N'Trần Quốc', N'Bảo', N'Nam', NULL, CAST(0x521E0B00 AS Date), N'123456788 ', N'Hải Phòng', N'Công Nhân', N'QBTA03    ', N'1')
INSERT [dbo].[ThongTinKhach] ([MaKhachTro], [Ho], [Ten], [GioiTinh], [AnhNhanDien], [NgaySinh], [CMND], [QueQuan], [NgheNghiep], [MaPhong], [GhiChu]) VALUES (N'KT004     ', N'Đinh Văn', N'Hưng', N'Nam', NULL, CAST(0x9F070B00 AS Date), N'123456786 ', N'Huế', N'Giáo Viên', N'QBTB05    ', N'1')
INSERT [dbo].[ThongTinKhach] ([MaKhachTro], [Ho], [Ten], [GioiTinh], [AnhNhanDien], [NgaySinh], [CMND], [QueQuan], [NgheNghiep], [MaPhong], [GhiChu]) VALUES (N'KT005     ', N'Bùi Quang', N'Minh', N'Nam', NULL, CAST(0xF0150B00 AS Date), N'123456785 ', N'Đà Nẵng', N'Giáo Viên', N'QBTB05    ', N'1')
INSERT [dbo].[ThongTinKhach] ([MaKhachTro], [Ho], [Ten], [GioiTinh], [AnhNhanDien], [NgaySinh], [CMND], [QueQuan], [NgheNghiep], [MaPhong], [GhiChu]) VALUES (N'KT006     ', N'Nguyễn Phương', N'Ngọc', N'Nữ', NULL, CAST(0x12180B00 AS Date), N'123456784 ', N'TP.HCM', N'Giáo Viên', N'Q12A01    ', N'1')
INSERT [dbo].[ThongTinKhach] ([MaKhachTro], [Ho], [Ten], [GioiTinh], [AnhNhanDien], [NgaySinh], [CMND], [QueQuan], [NgheNghiep], [MaPhong], [GhiChu]) VALUES (N'KT007     ', N'Lê Ngọc', N'Tuyết', N'Nữ', NULL, CAST(0x5F1B0B00 AS Date), N'123456783 ', N'TP.HCM', N'Nhân Viên Bán Hàng', N'Q12A03    ', N'1')
INSERT [dbo].[ThongTinKhach] ([MaKhachTro], [Ho], [Ten], [GioiTinh], [AnhNhanDien], [NgaySinh], [CMND], [QueQuan], [NgheNghiep], [MaPhong], [GhiChu]) VALUES (N'KT008     ', N'Nguyễn Minh', N'Nhật', N'Nam', NULL, CAST(0x7D200B00 AS Date), N'123456782 ', N'TP.HCM', N'Sinh Viên', N'Q12A03    ', N'1')
INSERT [dbo].[ThongTinKhach] ([MaKhachTro], [Ho], [Ten], [GioiTinh], [AnhNhanDien], [NgaySinh], [CMND], [QueQuan], [NgheNghiep], [MaPhong], [GhiChu]) VALUES (N'KT009     ', N'Trần Ngọc', N'Thủy', N'Nữ', NULL, CAST(0xE61F0B00 AS Date), N'123456781 ', N'Hà Tĩnh', N'Sinh Viên', N'Q12A02    ', N'1')
INSERT [dbo].[ThongTinKhach] ([MaKhachTro], [Ho], [Ten], [GioiTinh], [AnhNhanDien], [NgaySinh], [CMND], [QueQuan], [NgheNghiep], [MaPhong], [GhiChu]) VALUES (N'KT010     ', N'Nguyễn Huỳnh', N'Trang', N'Nữ', NULL, CAST(0x87220B00 AS Date), N'123456780 ', N'Vĩnh Long', N'Sinh Viên', N'Q12A02    ', N'1')
INSERT [dbo].[ThongTinKhach] ([MaKhachTro], [Ho], [Ten], [GioiTinh], [AnhNhanDien], [NgaySinh], [CMND], [QueQuan], [NgheNghiep], [MaPhong], [GhiChu]) VALUES (N'KT011     ', N'Trần Đức', N'Huy', N'Nam', NULL, CAST(0x051D0B00 AS Date), N'123456787 ', N'Hà Nội', N'Công Nhân', N'QBTA01    ', N'1')
/****** Object:  Table [dbo].[ThongTinDangKyPhong]    Script Date: 05/28/2017 18:50:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ThongTinDangKyPhong](
	[Id] [int] NOT NULL,
	[Ho] [nvarchar](50) NULL,
	[Ten] [nvarchar](50) NULL,
	[GioiTinh] [nvarchar](50) NULL,
	[NgaySinh] [date] NULL,
	[CMND] [nvarchar](50) NULL,
	[QueQuan] [nvarchar](max) NULL,
	[NgheNghiep] [nvarchar](50) NULL,
	[MaKhuVuc] [nchar](10) NULL,
	[MaLoaiPhong] [nchar](10) NULL,
 CONSTRAINT [PK_DangKyPhong] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[SaveP]    Script Date: 05/28/2017 18:50:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[SaveP](@ID nchar (10), @Pass nchar (10))
as
		DELETE FROM GhiNho
		INSERT INTO GhiNho (ID, Pass) Values (@ID, @Pass)
GO
/****** Object:  Table [dbo].[Phong]    Script Date: 05/28/2017 18:50:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Phong](
	[MaPhong] [nchar](10) NOT NULL,
	[MaLoaiPhong] [nchar](10) NOT NULL,
	[MaKhuVuc] [nchar](10) NOT NULL,
	[TenPhong] [nvarchar](50) NOT NULL,
	[Day] [nchar](10) NOT NULL,
	[TrangThai] [nvarchar](10) NOT NULL,
	[GhiChu] [nvarchar](50) NULL,
 CONSTRAINT [PK_Phong] PRIMARY KEY CLUSTERED 
(
	[MaPhong] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Phong] ([MaPhong], [MaLoaiPhong], [MaKhuVuc], [TenPhong], [Day], [TrangThai], [GhiChu]) VALUES (N'Q12A01    ', N'1         ', N'KV02      ', N'Phòng 001', N'A         ', N'Đã thuê', NULL)
INSERT [dbo].[Phong] ([MaPhong], [MaLoaiPhong], [MaKhuVuc], [TenPhong], [Day], [TrangThai], [GhiChu]) VALUES (N'Q12A02    ', N'1         ', N'KV02      ', N'Phòng 002', N'A         ', N'Đã thuê', NULL)
INSERT [dbo].[Phong] ([MaPhong], [MaLoaiPhong], [MaKhuVuc], [TenPhong], [Day], [TrangThai], [GhiChu]) VALUES (N'Q12A03    ', N'2         ', N'KV02      ', N'Phòng 003', N'A         ', N'Đã thuê', NULL)
INSERT [dbo].[Phong] ([MaPhong], [MaLoaiPhong], [MaKhuVuc], [TenPhong], [Day], [TrangThai], [GhiChu]) VALUES (N'Q12B04    ', N'2         ', N'KV02      ', N'Phòng 004', N'B         ', N'Trống', NULL)
INSERT [dbo].[Phong] ([MaPhong], [MaLoaiPhong], [MaKhuVuc], [TenPhong], [Day], [TrangThai], [GhiChu]) VALUES (N'Q12B05    ', N'3         ', N'KV02      ', N'Phòng 005', N'B         ', N'Trống', NULL)
INSERT [dbo].[Phong] ([MaPhong], [MaLoaiPhong], [MaKhuVuc], [TenPhong], [Day], [TrangThai], [GhiChu]) VALUES (N'QBTA01    ', N'1         ', N'KV01      ', N'Phòng 001', N'A         ', N'Đã thuê', NULL)
INSERT [dbo].[Phong] ([MaPhong], [MaLoaiPhong], [MaKhuVuc], [TenPhong], [Day], [TrangThai], [GhiChu]) VALUES (N'QBTA02    ', N'1         ', N'KV01      ', N'Phòng 002', N'A         ', N'Đã thuê', NULL)
INSERT [dbo].[Phong] ([MaPhong], [MaLoaiPhong], [MaKhuVuc], [TenPhong], [Day], [TrangThai], [GhiChu]) VALUES (N'QBTA03    ', N'2         ', N'KV01      ', N'Phòng 003', N'A         ', N'Đã thuê', NULL)
INSERT [dbo].[Phong] ([MaPhong], [MaLoaiPhong], [MaKhuVuc], [TenPhong], [Day], [TrangThai], [GhiChu]) VALUES (N'QBTB04    ', N'2         ', N'KV01      ', N'Phòng 004', N'B         ', N'Trống', NULL)
INSERT [dbo].[Phong] ([MaPhong], [MaLoaiPhong], [MaKhuVuc], [TenPhong], [Day], [TrangThai], [GhiChu]) VALUES (N'QBTB05    ', N'3         ', N'KV01      ', N'Phòng 005', N'B         ', N'Đã thuê', NULL)
/****** Object:  StoredProcedure [dbo].[ChangePass]    Script Date: 05/28/2017 18:50:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[ChangePass] (@ID nvarchar(50), @Pass nchar (10))
as
begin
	Update DangNhap
	Set PassWord = @Pass
	Where ID = @ID
end
GO
/****** Object:  StoredProcedure [dbo].[Xoa]    Script Date: 05/28/2017 18:50:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[Xoa]
as
	DELETE from GhiNho
GO
/****** Object:  Table [dbo].[TraPhong]    Script Date: 05/28/2017 18:50:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TraPhong](
	[Id] [int] NOT NULL,
	[MaPhong] [nchar](10) NULL,
	[MaKhachTro] [nchar](10) NULL,
	[NgayThue] [date] NULL,
	[NgayTraPhong] [date] NULL,
 CONSTRAINT [PK_TraPhong] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ThongTinThuePhong]    Script Date: 05/28/2017 18:50:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ThongTinThuePhong](
	[MaHD] [nchar](10) NOT NULL,
	[MaKhachTro] [nchar](10) NOT NULL,
	[MaPhong] [nchar](10) NOT NULL,
	[NgayThue] [date] NOT NULL,
	[TienDatCoc] [bigint] NULL,
	[GhiChu] [nvarchar](50) NULL,
 CONSTRAINT [PK_ThongTinThuePhong_1] PRIMARY KEY CLUSTERED 
(
	[MaHD] ASC,
	[MaKhachTro] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[ThongTinThuePhong] ([MaHD], [MaKhachTro], [MaPhong], [NgayThue], [TienDatCoc], [GhiChu]) VALUES (N'0         ', N'KT002     ', N'QBTA02    ', CAST(0xDB3C0B00 AS Date), 1000000, NULL)
INSERT [dbo].[ThongTinThuePhong] ([MaHD], [MaKhachTro], [MaPhong], [NgayThue], [TienDatCoc], [GhiChu]) VALUES (N'1         ', N'KT001     ', N'QBTA01    ', CAST(0xDB3C0B00 AS Date), 1000000, NULL)
INSERT [dbo].[ThongTinThuePhong] ([MaHD], [MaKhachTro], [MaPhong], [NgayThue], [TienDatCoc], [GhiChu]) VALUES (N'11        ', N'KT011     ', N'QBTA01    ', CAST(0xDB3C0B00 AS Date), 1000000, NULL)
INSERT [dbo].[ThongTinThuePhong] ([MaHD], [MaKhachTro], [MaPhong], [NgayThue], [TienDatCoc], [GhiChu]) VALUES (N'2         ', N'KT004     ', N'QBTB05    ', CAST(0xDB3C0B00 AS Date), 1000000, NULL)
INSERT [dbo].[ThongTinThuePhong] ([MaHD], [MaKhachTro], [MaPhong], [NgayThue], [TienDatCoc], [GhiChu]) VALUES (N'3         ', N'KT003     ', N'QBTA03    ', CAST(0xDB3C0B00 AS Date), 1000000, NULL)
INSERT [dbo].[ThongTinThuePhong] ([MaHD], [MaKhachTro], [MaPhong], [NgayThue], [TienDatCoc], [GhiChu]) VALUES (N'4         ', N'KT006     ', N'Q12A01    ', CAST(0xDB3C0B00 AS Date), 1000000, NULL)
INSERT [dbo].[ThongTinThuePhong] ([MaHD], [MaKhachTro], [MaPhong], [NgayThue], [TienDatCoc], [GhiChu]) VALUES (N'5         ', N'KT005     ', N'QBTB05    ', CAST(0xDB3C0B00 AS Date), 1000000, NULL)
INSERT [dbo].[ThongTinThuePhong] ([MaHD], [MaKhachTro], [MaPhong], [NgayThue], [TienDatCoc], [GhiChu]) VALUES (N'6         ', N'KT008     ', N'Q12A03    ', CAST(0xDB3C0B00 AS Date), 1000000, NULL)
INSERT [dbo].[ThongTinThuePhong] ([MaHD], [MaKhachTro], [MaPhong], [NgayThue], [TienDatCoc], [GhiChu]) VALUES (N'7         ', N'KT007     ', N'Q12A03    ', CAST(0xDB3C0B00 AS Date), 1000000, NULL)
INSERT [dbo].[ThongTinThuePhong] ([MaHD], [MaKhachTro], [MaPhong], [NgayThue], [TienDatCoc], [GhiChu]) VALUES (N'8         ', N'KT010     ', N'Q12A02    ', CAST(0xDB3C0B00 AS Date), 1000000, NULL)
INSERT [dbo].[ThongTinThuePhong] ([MaHD], [MaKhachTro], [MaPhong], [NgayThue], [TienDatCoc], [GhiChu]) VALUES (N'9         ', N'KT009     ', N'Q12A02    ', CAST(0xDB3C0B00 AS Date), 1000000, NULL)
/****** Object:  Table [dbo].[PhieuThu]    Script Date: 05/28/2017 18:50:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PhieuThu](
	[MaPT] [nchar](10) NOT NULL,
	[MaPhong] [nchar](10) NULL,
	[NgayLap] [date] NOT NULL,
	[NgayThu] [date] NULL,
	[TienNha] [bigint] NULL,
	[SkDien] [int] NULL,
	[TienDien] [bigint] NULL,
	[SkNuoc] [int] NULL,
	[TienNuoc] [bigint] NULL,
	[TongTien] [bigint] NULL,
	[TrangThai] [nvarchar](50) NULL,
 CONSTRAINT [PK_PhieuThu] PRIMARY KEY CLUSTERED 
(
	[MaPT] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[PhieuThu] ([MaPT], [MaPhong], [NgayLap], [NgayThu], [TienNha], [SkDien], [TienDien], [SkNuoc], [TienNuoc], [TongTien], [TrangThai]) VALUES (N'1         ', N'QBTA01    ', CAST(0xDC3C0B00 AS Date), CAST(0xDC3C0B00 AS Date), 1000000, 5, 12500, 2, 30000, 1042500, N'Đã thu')
INSERT [dbo].[PhieuThu] ([MaPT], [MaPhong], [NgayLap], [NgayThu], [TienNha], [SkDien], [TienDien], [SkNuoc], [TienNuoc], [TongTien], [TrangThai]) VALUES (N'2         ', N'QBTA02    ', CAST(0xDC3C0B00 AS Date), CAST(0xDC3C0B00 AS Date), 1000000, 5, 12500, 5, 75000, 1087500, N'Đã thu')
INSERT [dbo].[PhieuThu] ([MaPT], [MaPhong], [NgayLap], [NgayThu], [TienNha], [SkDien], [TienDien], [SkNuoc], [TienNuoc], [TongTien], [TrangThai]) VALUES (N'3         ', N'QBTB05    ', CAST(0xDC3C0B00 AS Date), CAST(0xDC3C0B00 AS Date), 2000000, 5, 12500, 0, 40000, 2052500, N'Đã thu')
INSERT [dbo].[PhieuThu] ([MaPT], [MaPhong], [NgayLap], [NgayThu], [TienNha], [SkDien], [TienDien], [SkNuoc], [TienNuoc], [TongTien], [TrangThai]) VALUES (N'4         ', N'QBTA03    ', CAST(0xDC3C0B00 AS Date), CAST(0xDC3C0B00 AS Date), 1500000, 5, 12500, 5, 75000, 1587500, N'Đã thu')
INSERT [dbo].[PhieuThu] ([MaPT], [MaPhong], [NgayLap], [NgayThu], [TienNha], [SkDien], [TienDien], [SkNuoc], [TienNuoc], [TongTien], [TrangThai]) VALUES (N'5         ', N'Q12A01    ', CAST(0xDC3C0B00 AS Date), CAST(0xDC3C0B00 AS Date), 1000000, 5, 12500, 5, 75000, 1087500, N'Đã thu')
/****** Object:  StoredProcedure [dbo].[Converdatetime]    Script Date: 05/28/2017 18:50:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create proc [dbo].[Converdatetime]
as

SELECT CONVERT(varchar(10),k.NgayThue,103) as [Ngày sinh]
From ThongTinThuePhong k
GO
/****** Object:  ForeignKey [FK_DangKyPhong_KhuVuc]    Script Date: 05/28/2017 18:50:00 ******/
ALTER TABLE [dbo].[ThongTinDangKyPhong]  WITH CHECK ADD  CONSTRAINT [FK_DangKyPhong_KhuVuc] FOREIGN KEY([MaKhuVuc])
REFERENCES [dbo].[KhuVuc] ([MaKhuVuc])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ThongTinDangKyPhong] CHECK CONSTRAINT [FK_DangKyPhong_KhuVuc]
GO
/****** Object:  ForeignKey [FK_DangKyPhong_LoaiPhong]    Script Date: 05/28/2017 18:50:00 ******/
ALTER TABLE [dbo].[ThongTinDangKyPhong]  WITH CHECK ADD  CONSTRAINT [FK_DangKyPhong_LoaiPhong] FOREIGN KEY([MaLoaiPhong])
REFERENCES [dbo].[LoaiPhong] ([MaLoaiPhong])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ThongTinDangKyPhong] CHECK CONSTRAINT [FK_DangKyPhong_LoaiPhong]
GO
/****** Object:  ForeignKey [FK_Phong_KhuVuc]    Script Date: 05/28/2017 18:50:01 ******/
ALTER TABLE [dbo].[Phong]  WITH CHECK ADD  CONSTRAINT [FK_Phong_KhuVuc] FOREIGN KEY([MaKhuVuc])
REFERENCES [dbo].[KhuVuc] ([MaKhuVuc])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Phong] CHECK CONSTRAINT [FK_Phong_KhuVuc]
GO
/****** Object:  ForeignKey [FK_Phong_LoaiPhong]    Script Date: 05/28/2017 18:50:01 ******/
ALTER TABLE [dbo].[Phong]  WITH CHECK ADD  CONSTRAINT [FK_Phong_LoaiPhong] FOREIGN KEY([MaLoaiPhong])
REFERENCES [dbo].[LoaiPhong] ([MaLoaiPhong])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Phong] CHECK CONSTRAINT [FK_Phong_LoaiPhong]
GO
/****** Object:  ForeignKey [FK_TraPhong_Phong]    Script Date: 05/28/2017 18:50:01 ******/
ALTER TABLE [dbo].[TraPhong]  WITH CHECK ADD  CONSTRAINT [FK_TraPhong_Phong] FOREIGN KEY([MaPhong])
REFERENCES [dbo].[Phong] ([MaPhong])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[TraPhong] CHECK CONSTRAINT [FK_TraPhong_Phong]
GO
/****** Object:  ForeignKey [FK_TraPhong_ThongTinKhach]    Script Date: 05/28/2017 18:50:01 ******/
ALTER TABLE [dbo].[TraPhong]  WITH CHECK ADD  CONSTRAINT [FK_TraPhong_ThongTinKhach] FOREIGN KEY([MaKhachTro])
REFERENCES [dbo].[ThongTinKhach] ([MaKhachTro])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[TraPhong] CHECK CONSTRAINT [FK_TraPhong_ThongTinKhach]
GO
/****** Object:  ForeignKey [FK_ThongTinThuePhong_Phong]    Script Date: 05/28/2017 18:50:01 ******/
ALTER TABLE [dbo].[ThongTinThuePhong]  WITH CHECK ADD  CONSTRAINT [FK_ThongTinThuePhong_Phong] FOREIGN KEY([MaPhong])
REFERENCES [dbo].[Phong] ([MaPhong])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ThongTinThuePhong] CHECK CONSTRAINT [FK_ThongTinThuePhong_Phong]
GO
/****** Object:  ForeignKey [FK_ThongTinThuePhong_ThongTinKhach]    Script Date: 05/28/2017 18:50:01 ******/
ALTER TABLE [dbo].[ThongTinThuePhong]  WITH CHECK ADD  CONSTRAINT [FK_ThongTinThuePhong_ThongTinKhach] FOREIGN KEY([MaKhachTro])
REFERENCES [dbo].[ThongTinKhach] ([MaKhachTro])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ThongTinThuePhong] CHECK CONSTRAINT [FK_ThongTinThuePhong_ThongTinKhach]
GO
/****** Object:  ForeignKey [FK_PhieuThu_Phong]    Script Date: 05/28/2017 18:50:01 ******/
ALTER TABLE [dbo].[PhieuThu]  WITH CHECK ADD  CONSTRAINT [FK_PhieuThu_Phong] FOREIGN KEY([MaPhong])
REFERENCES [dbo].[Phong] ([MaPhong])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[PhieuThu] CHECK CONSTRAINT [FK_PhieuThu_Phong]
GO
