USE [master]
GO
/****** Object:  Database [WebMVC]    Script Date: 12/13/2020 11:45:30 AM ******/
CREATE DATABASE [WebMVC]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'WebMVC', FILENAME = N'F:\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\WebMVC.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'WebMVC_log', FILENAME = N'F:\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\WebMVC_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [WebMVC] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [WebMVC].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [WebMVC] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [WebMVC] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [WebMVC] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [WebMVC] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [WebMVC] SET ARITHABORT OFF 
GO
ALTER DATABASE [WebMVC] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [WebMVC] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [WebMVC] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [WebMVC] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [WebMVC] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [WebMVC] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [WebMVC] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [WebMVC] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [WebMVC] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [WebMVC] SET  DISABLE_BROKER 
GO
ALTER DATABASE [WebMVC] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [WebMVC] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [WebMVC] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [WebMVC] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [WebMVC] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [WebMVC] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [WebMVC] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [WebMVC] SET RECOVERY FULL 
GO
ALTER DATABASE [WebMVC] SET  MULTI_USER 
GO
ALTER DATABASE [WebMVC] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [WebMVC] SET DB_CHAINING OFF 
GO
ALTER DATABASE [WebMVC] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [WebMVC] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [WebMVC] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [WebMVC] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'WebMVC', N'ON'
GO
ALTER DATABASE [WebMVC] SET QUERY_STORE = OFF
GO
USE [WebMVC]
GO
/****** Object:  Table [dbo].[BaoCao]    Script Date: 12/13/2020 11:45:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BaoCao](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Tuan] [int] NULL,
	[Nhom_ID] [int] NULL,
	[TieuDe] [nvarchar](50) NULL,
	[NoiDung] [ntext] NULL,
	[ThoiGianBaoCao] [datetime] NULL,
	[FileUpload] [varchar](500) NULL,
	[FilePath] [varchar](500) NULL,
 CONSTRAINT [PK_BaoCao] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ChucVu]    Script Date: 12/13/2020 11:45:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChucVu](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[TenChucVu] [varchar](50) NOT NULL,
 CONSTRAINT [PK_ChucVu] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DeTai]    Script Date: 12/13/2020 11:45:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DeTai](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[TenDeTai] [nvarchar](50) NULL,
	[YeuCauDeTai] [nvarchar](500) NULL,
	[ThoiGianBatDau] [datetime] NULL,
	[ThoiGianKetThuc] [datetime] NULL,
	[SoTuanThucHien] [int] NULL,
 CONSTRAINT [PK_DeTai] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NguoiDung]    Script Date: 12/13/2020 11:45:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NguoiDung](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[TenDangNhap] [varchar](20) NOT NULL,
	[MatKhau] [varchar](50) NOT NULL,
	[HoTen] [nvarchar](50) NOT NULL,
	[Email] [varchar](320) NOT NULL,
	[Nhom_ID] [int] NULL,
	[DeTai_ID] [int] NULL,
	[ChucVu_ID] [int] NULL,
 CONSTRAINT [PK_NguoiDung] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Nhom]    Script Date: 12/13/2020 11:45:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Nhom](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[TenNhom] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Nhom] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PhanHoi]    Script Date: 12/13/2020 11:45:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PhanHoi](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[BaoCao_ID] [int] NULL,
	[NoiDung] [ntext] NULL,
	[TieuDe] [nvarchar](50) NULL,
 CONSTRAINT [PK_PhanHoi] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[BaoCao] ON 

INSERT [dbo].[BaoCao] ([ID], [Tuan], [Nhom_ID], [TieuDe], [NoiDung], [ThoiGianBaoCao], [FileUpload], [FilePath]) VALUES (1, 1, 1, N'Báo cáo lần 1', N'Đã hoàn thiện được trang đăng nhập', CAST(N'2020-12-13T11:31:11.763' AS DateTime), N'2020_12_13-C6 - LAB - Access control.docx', N'UploadFiles/2020_12_13-C6 - LAB - Access control.docx')
SET IDENTITY_INSERT [dbo].[BaoCao] OFF
GO
SET IDENTITY_INSERT [dbo].[ChucVu] ON 

INSERT [dbo].[ChucVu] ([ID], [TenChucVu]) VALUES (1, N'Giáo viên')
INSERT [dbo].[ChucVu] ([ID], [TenChucVu]) VALUES (2, N'Sinh viên')
SET IDENTITY_INSERT [dbo].[ChucVu] OFF
GO
SET IDENTITY_INSERT [dbo].[DeTai] ON 

INSERT [dbo].[DeTai] ([ID], [TenDeTai], [YeuCauDeTai], [ThoiGianBatDau], [ThoiGianKetThuc], [SoTuanThucHien]) VALUES (1, N'Xây dựng web học tập', N'Có các chức năng như đăng nhập, đăng xuất, giao đề tài, báo cáo,...', CAST(N'2020-12-12T00:00:00.000' AS DateTime), CAST(N'2021-01-30T00:00:00.000' AS DateTime), 7)
SET IDENTITY_INSERT [dbo].[DeTai] OFF
GO
SET IDENTITY_INSERT [dbo].[NguoiDung] ON 

INSERT [dbo].[NguoiDung] ([ID], [TenDangNhap], [MatKhau], [HoTen], [Email], [Nhom_ID], [DeTai_ID], [ChucVu_ID]) VALUES (1, N'101', N'123456', N'Huỳnh Xuân Phụng', N'Phunghx@hcmute.edu.vn', NULL, NULL, 1)
INSERT [dbo].[NguoiDung] ([ID], [TenDangNhap], [MatKhau], [HoTen], [Email], [Nhom_ID], [DeTai_ID], [ChucVu_ID]) VALUES (2, N'18110121', N'password', N'Cao Chiêu', N'18110121@student.hcmute.edu.vn', 1, 1, 2)
INSERT [dbo].[NguoiDung] ([ID], [TenDangNhap], [MatKhau], [HoTen], [Email], [Nhom_ID], [DeTai_ID], [ChucVu_ID]) VALUES (4, N'18110211', N'0967625714', N'Lê La', N'18110211@student.hcmute.edu.vn', 1, NULL, 2)
INSERT [dbo].[NguoiDung] ([ID], [TenDangNhap], [MatKhau], [HoTen], [Email], [Nhom_ID], [DeTai_ID], [ChucVu_ID]) VALUES (5, N'18110111', N'11111111', N'Nguyễn Lộc', N'18110111@student.hcmute.edu.vn', 2, NULL, 2)
INSERT [dbo].[NguoiDung] ([ID], [TenDangNhap], [MatKhau], [HoTen], [Email], [Nhom_ID], [DeTai_ID], [ChucVu_ID]) VALUES (6, N'19110123', N'winwin', N'Phan Lang', N'19110123@student.hcmute.edu.vn', 2, NULL, 2)
INSERT [dbo].[NguoiDung] ([ID], [TenDangNhap], [MatKhau], [HoTen], [Email], [Nhom_ID], [DeTai_ID], [ChucVu_ID]) VALUES (8, N'17110135', N'luclac123', N'Bùi Kiên', N'17110135@student.hcmute.edu.vn', 3, NULL, 2)
INSERT [dbo].[NguoiDung] ([ID], [TenDangNhap], [MatKhau], [HoTen], [Email], [Nhom_ID], [DeTai_ID], [ChucVu_ID]) VALUES (9, N'18110321', N'2135202641', N'Trần Hồng', N'18110321@student.hcmute.edu.vn', 3, NULL, 2)
INSERT [dbo].[NguoiDung] ([ID], [TenDangNhap], [MatKhau], [HoTen], [Email], [Nhom_ID], [DeTai_ID], [ChucVu_ID]) VALUES (10, N'18110042', N'nanababa', N'Nhiếp Ly', N'18110042@student.hcmute.edu.vn', 4, NULL, 2)
INSERT [dbo].[NguoiDung] ([ID], [TenDangNhap], [MatKhau], [HoTen], [Email], [Nhom_ID], [DeTai_ID], [ChucVu_ID]) VALUES (11, N'18110303', N'yeahyeah123', N'Thu Đồng', N'18110303@student.hcmute.edu.vn', 4, NULL, 2)
SET IDENTITY_INSERT [dbo].[NguoiDung] OFF
GO
SET IDENTITY_INSERT [dbo].[Nhom] ON 

INSERT [dbo].[Nhom] ([ID], [TenNhom]) VALUES (1, N'Nhóm 1')
INSERT [dbo].[Nhom] ([ID], [TenNhom]) VALUES (2, N'Nhóm 2')
INSERT [dbo].[Nhom] ([ID], [TenNhom]) VALUES (3, N'Nhóm 3')
INSERT [dbo].[Nhom] ([ID], [TenNhom]) VALUES (4, N'Nhóm 4')
SET IDENTITY_INSERT [dbo].[Nhom] OFF
GO
/****** Object:  Index [unique_BaoCao]    Script Date: 12/13/2020 11:45:31 AM ******/
ALTER TABLE [dbo].[BaoCao] ADD  CONSTRAINT [unique_BaoCao] UNIQUE NONCLUSTERED 
(
	[Tuan] ASC,
	[Nhom_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [unique_TenDeTai]    Script Date: 12/13/2020 11:45:31 AM ******/
ALTER TABLE [dbo].[DeTai] ADD  CONSTRAINT [unique_TenDeTai] UNIQUE NONCLUSTERED 
(
	[TenDeTai] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[BaoCao]  WITH CHECK ADD  CONSTRAINT [FK_BaoCao_Nhom] FOREIGN KEY([Nhom_ID])
REFERENCES [dbo].[Nhom] ([ID])
GO
ALTER TABLE [dbo].[BaoCao] CHECK CONSTRAINT [FK_BaoCao_Nhom]
GO
ALTER TABLE [dbo].[NguoiDung]  WITH CHECK ADD  CONSTRAINT [FK_NguoiDung_ChucVu] FOREIGN KEY([ChucVu_ID])
REFERENCES [dbo].[ChucVu] ([ID])
GO
ALTER TABLE [dbo].[NguoiDung] CHECK CONSTRAINT [FK_NguoiDung_ChucVu]
GO
ALTER TABLE [dbo].[NguoiDung]  WITH CHECK ADD  CONSTRAINT [FK_NguoiDung_DeTai] FOREIGN KEY([DeTai_ID])
REFERENCES [dbo].[DeTai] ([ID])
GO
ALTER TABLE [dbo].[NguoiDung] CHECK CONSTRAINT [FK_NguoiDung_DeTai]
GO
ALTER TABLE [dbo].[NguoiDung]  WITH CHECK ADD  CONSTRAINT [FK_NguoiDung_Nhom] FOREIGN KEY([Nhom_ID])
REFERENCES [dbo].[Nhom] ([ID])
GO
ALTER TABLE [dbo].[NguoiDung] CHECK CONSTRAINT [FK_NguoiDung_Nhom]
GO
ALTER TABLE [dbo].[PhanHoi]  WITH CHECK ADD  CONSTRAINT [FK_PhanHoi_BaoCao] FOREIGN KEY([BaoCao_ID])
REFERENCES [dbo].[BaoCao] ([ID])
GO
ALTER TABLE [dbo].[PhanHoi] CHECK CONSTRAINT [FK_PhanHoi_BaoCao]
GO
USE [master]
GO
ALTER DATABASE [WebMVC] SET  READ_WRITE 
GO
