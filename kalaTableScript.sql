USE [Kala]
GO
/****** Object:  Table [dbo].[Kalas]    Script Date: 11/6/2019 3:07:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Kalas](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](255) NULL,
	[Model] [nvarchar](255) NULL,
	[Color] [nvarchar](20) NULL,
	[AvailableNumber] [smallint] NOT NULL,
	[Price] [int] NOT NULL,
 CONSTRAINT [PK_dbo.Kalas] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Kalas] ON 

INSERT [dbo].[Kalas] ([Id], [Name], [Model], [Color], [AvailableNumber], [Price]) VALUES (1, N'دستگاه قهوه ساز', N'Tefal', N'مشکی', 20, 1252000)
INSERT [dbo].[Kalas] ([Id], [Name], [Model], [Color], [AvailableNumber], [Price]) VALUES (2, N'گوشی موبایل سامسونگ', N'Galaxy XS', N'طلایی', 12, 1500000)
INSERT [dbo].[Kalas] ([Id], [Name], [Model], [Color], [AvailableNumber], [Price]) VALUES (3, N'دوچرخه', N'Davis', N'سبز', 5, 2400000)
INSERT [dbo].[Kalas] ([Id], [Name], [Model], [Color], [AvailableNumber], [Price]) VALUES (4, N'ساعت', N'Casio', N'طوسی', 8, 3000000)
INSERT [dbo].[Kalas] ([Id], [Name], [Model], [Color], [AvailableNumber], [Price]) VALUES (5, N'باتری', N'Duracell', N'قهوه ای', 100, 45000)
INSERT [dbo].[Kalas] ([Id], [Name], [Model], [Color], [AvailableNumber], [Price]) VALUES (6, N'مانیتور', N'LG 22 Flat', N'مشکی', 50, 7000000)
INSERT [dbo].[Kalas] ([Id], [Name], [Model], [Color], [AvailableNumber], [Price]) VALUES (7, N'خودکار', N'کیان', N'آبی', 1000, 2000)
SET IDENTITY_INSERT [dbo].[Kalas] OFF
