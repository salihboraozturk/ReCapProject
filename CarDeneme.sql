USE [CarDeneme]
GO
/****** Object:  Table [dbo].[Brands]    Script Date: 10/04/2021 22:13:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Brands](
	[BrandId] [int] IDENTITY(1,1) NOT NULL,
	[BrandName] [nvarchar](20) NULL,
PRIMARY KEY CLUSTERED 
(
	[BrandId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cards]    Script Date: 10/04/2021 22:13:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cards](
	[CardId] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NULL,
	[CardOwner] [nvarchar](50) NULL,
	[CardNumber] [nvarchar](50) NULL,
	[ExpirationMonth] [int] NULL,
	[ExpirationYear] [int] NULL,
	[Cvv] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[CardId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CarImages]    Script Date: 10/04/2021 22:13:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CarImages](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CarId] [int] NULL,
	[ImagePath] [nvarchar](250) NULL,
	[Date] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cars]    Script Date: 10/04/2021 22:13:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cars](
	[CarId] [int] IDENTITY(1,1) NOT NULL,
	[BrandId] [int] NULL,
	[ColorId] [int] NULL,
	[ModelYear] [int] NULL,
	[DailyPrice] [int] NULL,
	[CarName] [nvarchar](50) NULL,
	[Description] [nvarchar](50) NULL,
	[MinFindex] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[CarId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Colors]    Script Date: 10/04/2021 22:13:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Colors](
	[ColorId] [int] IDENTITY(1,1) NOT NULL,
	[ColorName] [nvarchar](20) NULL,
PRIMARY KEY CLUSTERED 
(
	[ColorId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Customers]    Script Date: 10/04/2021 22:13:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customers](
	[CustomerId] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NULL,
	[CompanyName] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[CustomerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OperationClaims]    Script Date: 10/04/2021 22:13:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OperationClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](250) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Payments]    Script Date: 10/04/2021 22:13:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Payments](
	[PaymentId] [int] IDENTITY(1,1) NOT NULL,
	[CardOwner] [nvarchar](50) NOT NULL,
	[CardNumber] [nvarchar](16) NOT NULL,
	[ExpirationMonth] [int] NULL,
	[Cvv] [int] NULL,
	[ExpirationYear] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[PaymentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Rentals]    Script Date: 10/04/2021 22:13:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rentals](
	[RentalId] [int] IDENTITY(1,1) NOT NULL,
	[CarId] [int] NULL,
	[CustomerId] [int] NULL,
	[RentDate] [datetime] NULL,
	[ReturnDate] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[RentalId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserOperationClaims]    Script Date: 10/04/2021 22:13:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserOperationClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[OperationClaimId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 10/04/2021 22:13:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[PasswordSalt] [varbinary](500) NOT NULL,
	[PasswordHash] [varbinary](500) NOT NULL,
	[Status] [bit] NOT NULL,
	[Findex] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Brands] ON 
GO
INSERT [dbo].[Brands] ([BrandId], [BrandName]) VALUES (1, N'Audi')
GO
INSERT [dbo].[Brands] ([BrandId], [BrandName]) VALUES (2, N'Renault')
GO
INSERT [dbo].[Brands] ([BrandId], [BrandName]) VALUES (3, N'Opel')
GO
INSERT [dbo].[Brands] ([BrandId], [BrandName]) VALUES (4, N'Volkswagen')
GO
INSERT [dbo].[Brands] ([BrandId], [BrandName]) VALUES (5, N'Mercedes')
GO
INSERT [dbo].[Brands] ([BrandId], [BrandName]) VALUES (6, N'BMW')
GO
INSERT [dbo].[Brands] ([BrandId], [BrandName]) VALUES (1002, N'Toyota')
GO
SET IDENTITY_INSERT [dbo].[Brands] OFF
GO
SET IDENTITY_INSERT [dbo].[Cards] ON 
GO
INSERT [dbo].[Cards] ([CardId], [UserId], [CardOwner], [CardNumber], [ExpirationMonth], [ExpirationYear], [Cvv]) VALUES (1006, 4, N'Ahmet Mehmet', N'1234123412341234', 10, 26, 131)
GO
SET IDENTITY_INSERT [dbo].[Cards] OFF
GO
SET IDENTITY_INSERT [dbo].[CarImages] ON 
GO
INSERT [dbo].[CarImages] ([Id], [CarId], [ImagePath], [Date]) VALUES (5002, 3, N'\Images\c4576e44399b4b409cc78a2edc89c669-3-24-2021.jpg', CAST(N'2021-03-24T15:17:31.757' AS DateTime))
GO
INSERT [dbo].[CarImages] ([Id], [CarId], [ImagePath], [Date]) VALUES (5003, 1002, N'\Images\16eaa5a9efb94312b851e41c849b704e-3-24-2021.jpg', CAST(N'2021-03-24T15:17:56.237' AS DateTime))
GO
INSERT [dbo].[CarImages] ([Id], [CarId], [ImagePath], [Date]) VALUES (5004, 1003, N'\Images\11839ae3c2714350be4936efe62d6331-3-24-2021.jpg', CAST(N'2021-03-24T15:18:08.867' AS DateTime))
GO
INSERT [dbo].[CarImages] ([Id], [CarId], [ImagePath], [Date]) VALUES (5005, 1004, N'\Images\f5783c3eb454459d999c42f50713ee12-3-24-2021.jpg', CAST(N'2021-03-24T15:18:20.123' AS DateTime))
GO
INSERT [dbo].[CarImages] ([Id], [CarId], [ImagePath], [Date]) VALUES (5006, 1006, N'\Images\7f15502cc4d34d6682227a943f2c7668-3-24-2021.jpg', CAST(N'2021-03-24T15:18:42.953' AS DateTime))
GO
INSERT [dbo].[CarImages] ([Id], [CarId], [ImagePath], [Date]) VALUES (5007, 1007, N'\Images\3361183afd4a41c690006d4b42ee3cad-3-24-2021.jpg', CAST(N'2021-03-24T15:18:55.357' AS DateTime))
GO
INSERT [dbo].[CarImages] ([Id], [CarId], [ImagePath], [Date]) VALUES (5008, 2007, N'\Images\2e3987c100ba4de8ad7d77e80387c878-3-24-2021.jpg', CAST(N'2021-03-24T15:19:13.243' AS DateTime))
GO
INSERT [dbo].[CarImages] ([Id], [CarId], [ImagePath], [Date]) VALUES (5009, 3007, N'\Images\fd545a115e5049669349c83a2ff41b37-3-24-2021.jpg', CAST(N'2021-03-24T15:19:30.710' AS DateTime))
GO
INSERT [dbo].[CarImages] ([Id], [CarId], [ImagePath], [Date]) VALUES (5010, 3009, N'\Images\fad206f1c4f5444c9b57c83731bb2e0d-3-24-2021.jpg', CAST(N'2021-03-24T15:20:01.623' AS DateTime))
GO
INSERT [dbo].[CarImages] ([Id], [CarId], [ImagePath], [Date]) VALUES (5011, 3010, N'\Images\37a39f3d6be5461798abfb272ad6cead-3-24-2021.jpg', CAST(N'2021-03-24T15:20:12.563' AS DateTime))
GO
INSERT [dbo].[CarImages] ([Id], [CarId], [ImagePath], [Date]) VALUES (7002, 1003, N'\Images\cdeb34a3b3db4281933e17487adaf319-3-30-2021.jpg', CAST(N'2021-03-30T21:43:30.710' AS DateTime))
GO
INSERT [dbo].[CarImages] ([Id], [CarId], [ImagePath], [Date]) VALUES (7003, 1003, N'\Images\1a85afe0bd7b450b89ac69259736cef2-3-30-2021.jpg', CAST(N'2021-03-30T21:44:16.110' AS DateTime))
GO
INSERT [dbo].[CarImages] ([Id], [CarId], [ImagePath], [Date]) VALUES (8002, 7007, N'\Images\dd0542cfdf4142a5afadd3f436c77945-4-9-2021.jpg', CAST(N'2021-04-09T17:06:35.000' AS DateTime))
GO
INSERT [dbo].[CarImages] ([Id], [CarId], [ImagePath], [Date]) VALUES (8003, 7008, N'\Images\852161a35d4643edb6a98856ce1f4e28-4-9-2021.jpg', CAST(N'2021-04-09T17:08:04.187' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[CarImages] OFF
GO
SET IDENTITY_INSERT [dbo].[Cars] ON 
GO
INSERT [dbo].[Cars] ([CarId], [BrandId], [ColorId], [ModelYear], [DailyPrice], [CarName], [Description], [MinFindex]) VALUES (3, 1, 1003, 2018, 1000, N'A8', N'Benzin-Otomatik', 1900)
GO
INSERT [dbo].[Cars] ([CarId], [BrandId], [ColorId], [ModelYear], [DailyPrice], [CarName], [Description], [MinFindex]) VALUES (1002, 1, 3, 2006, 500, N'A3', N'Dizel-Otomatik', 1500)
GO
INSERT [dbo].[Cars] ([CarId], [BrandId], [ColorId], [ModelYear], [DailyPrice], [CarName], [Description], [MinFindex]) VALUES (1003, 2, 1003, 2018, 750, N'Megane', N'Dizel-Manuel', 0)
GO
INSERT [dbo].[Cars] ([CarId], [BrandId], [ColorId], [ModelYear], [DailyPrice], [CarName], [Description], [MinFindex]) VALUES (1004, 2, 2, 2012, 587, N'Clio', N'Dizel-Manuel', 0)
GO
INSERT [dbo].[Cars] ([CarId], [BrandId], [ColorId], [ModelYear], [DailyPrice], [CarName], [Description], [MinFindex]) VALUES (1006, 3, 3, 2013, 500, N'Corsa', N'Benzin-Manuel', 0)
GO
INSERT [dbo].[Cars] ([CarId], [BrandId], [ColorId], [ModelYear], [DailyPrice], [CarName], [Description], [MinFindex]) VALUES (1007, 4, 2, 2020, 850, N'Passat', N'Dizel-Otomatik', 1200)
GO
INSERT [dbo].[Cars] ([CarId], [BrandId], [ColorId], [ModelYear], [DailyPrice], [CarName], [Description], [MinFindex]) VALUES (2007, 4, 1003, 2012, 650, N'Jetta', N'Benzin-Otomatik', 750)
GO
INSERT [dbo].[Cars] ([CarId], [BrandId], [ColorId], [ModelYear], [DailyPrice], [CarName], [Description], [MinFindex]) VALUES (3007, 5, 2, 2011, 750, N'C180', N'Dizel-Manuel', 1600)
GO
INSERT [dbo].[Cars] ([CarId], [BrandId], [ColorId], [ModelYear], [DailyPrice], [CarName], [Description], [MinFindex]) VALUES (3009, 6, 1, 2005, 500, N'M3', N'Benzin-Manuel', 1000)
GO
INSERT [dbo].[Cars] ([CarId], [BrandId], [ColorId], [ModelYear], [DailyPrice], [CarName], [Description], [MinFindex]) VALUES (3010, 6, 4, 2016, 1450, N'M4', N'Benzin-Manuel', 1600)
GO
INSERT [dbo].[Cars] ([CarId], [BrandId], [ColorId], [ModelYear], [DailyPrice], [CarName], [Description], [MinFindex]) VALUES (7007, 5, 3, 2010, 650, N'E250', N'Benzin-Otomatik', 1250)
GO
INSERT [dbo].[Cars] ([CarId], [BrandId], [ColorId], [ModelYear], [DailyPrice], [CarName], [Description], [MinFindex]) VALUES (7008, 3, 1003, 2009, 350, N'Vectra', N'Dizel-Manuel', 50)
GO
SET IDENTITY_INSERT [dbo].[Cars] OFF
GO
SET IDENTITY_INSERT [dbo].[Colors] ON 
GO
INSERT [dbo].[Colors] ([ColorId], [ColorName]) VALUES (1, N'Siyah')
GO
INSERT [dbo].[Colors] ([ColorId], [ColorName]) VALUES (2, N'Beyaz')
GO
INSERT [dbo].[Colors] ([ColorId], [ColorName]) VALUES (3, N'Kırmızı')
GO
INSERT [dbo].[Colors] ([ColorId], [ColorName]) VALUES (4, N'Mavi')
GO
INSERT [dbo].[Colors] ([ColorId], [ColorName]) VALUES (5, N'Sarı')
GO
INSERT [dbo].[Colors] ([ColorId], [ColorName]) VALUES (6, N'Yeşil')
GO
INSERT [dbo].[Colors] ([ColorId], [ColorName]) VALUES (7, N'Pembe')
GO
INSERT [dbo].[Colors] ([ColorId], [ColorName]) VALUES (8, N'Mor')
GO
INSERT [dbo].[Colors] ([ColorId], [ColorName]) VALUES (1002, N'Turuncu')
GO
INSERT [dbo].[Colors] ([ColorId], [ColorName]) VALUES (1003, N'Gri')
GO
INSERT [dbo].[Colors] ([ColorId], [ColorName]) VALUES (1004, N'Altın Sarısı')
GO
SET IDENTITY_INSERT [dbo].[Colors] OFF
GO
SET IDENTITY_INSERT [dbo].[Customers] ON 
GO
INSERT [dbo].[Customers] ([CustomerId], [UserId], [CompanyName]) VALUES (1, 1, N'DevSoft')
GO
INSERT [dbo].[Customers] ([CustomerId], [UserId], [CompanyName]) VALUES (2, 2005, N'Kodlama.io')
GO
SET IDENTITY_INSERT [dbo].[Customers] OFF
GO
SET IDENTITY_INSERT [dbo].[OperationClaims] ON 
GO
INSERT [dbo].[OperationClaims] ([Id], [Name]) VALUES (1, N'car.getall')
GO
INSERT [dbo].[OperationClaims] ([Id], [Name]) VALUES (2, N'admin')
GO
SET IDENTITY_INSERT [dbo].[OperationClaims] OFF
GO
SET IDENTITY_INSERT [dbo].[Payments] ON 
GO
INSERT [dbo].[Payments] ([PaymentId], [CardOwner], [CardNumber], [ExpirationMonth], [Cvv], [ExpirationYear]) VALUES (1, N'Ahmet Mehmet', N'1234123412341234', 10, 131, 26)
GO
SET IDENTITY_INSERT [dbo].[Payments] OFF
GO
SET IDENTITY_INSERT [dbo].[Rentals] ON 
GO
INSERT [dbo].[Rentals] ([RentalId], [CarId], [CustomerId], [RentDate], [ReturnDate]) VALUES (1, 3, 1, CAST(N'2021-02-01T00:00:00.000' AS DateTime), CAST(N'2021-05-31T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[Rentals] ([RentalId], [CarId], [CustomerId], [RentDate], [ReturnDate]) VALUES (2, 1002, 1, CAST(N'2019-01-01T00:00:00.000' AS DateTime), CAST(N'2021-01-31T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[Rentals] ([RentalId], [CarId], [CustomerId], [RentDate], [ReturnDate]) VALUES (1002, 1002, 2, CAST(N'2021-03-30T00:00:00.000' AS DateTime), CAST(N'2021-04-03T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[Rentals] ([RentalId], [CarId], [CustomerId], [RentDate], [ReturnDate]) VALUES (2002, 1003, 1, CAST(N'2021-04-02T00:00:00.000' AS DateTime), CAST(N'2021-04-03T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[Rentals] ([RentalId], [CarId], [CustomerId], [RentDate], [ReturnDate]) VALUES (2003, 1004, 1, CAST(N'2021-04-13T00:00:00.000' AS DateTime), CAST(N'2021-04-18T00:00:00.000' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[Rentals] OFF
GO
SET IDENTITY_INSERT [dbo].[UserOperationClaims] ON 
GO
INSERT [dbo].[UserOperationClaims] ([Id], [UserId], [OperationClaimId]) VALUES (1, 6, 1)
GO
INSERT [dbo].[UserOperationClaims] ([Id], [UserId], [OperationClaimId]) VALUES (2, 2005, 2)
GO
INSERT [dbo].[UserOperationClaims] ([Id], [UserId], [OperationClaimId]) VALUES (1002, 4, 1)
GO
INSERT [dbo].[UserOperationClaims] ([Id], [UserId], [OperationClaimId]) VALUES (1003, 4, 2)
GO
SET IDENTITY_INSERT [dbo].[UserOperationClaims] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 
GO
INSERT [dbo].[Users] ([UserId], [FirstName], [LastName], [Email], [PasswordSalt], [PasswordHash], [Status], [Findex]) VALUES (1, N'Salih', N'Öztürk', N'salihbora@mail.com', 0xE2EC651A994135D73E9FAFEC6C49F8B8ABC854B9F89C3C6CABC1F5ECEB4D88BE80E227CDF574A11A44F5FF67D133AAD7AB070E6A988E0ECD7FA03FFBA7CEDBEF06188292F1BA9C779A0B552FF211089EDED08B019EE4555379E2BEE45C71BB33D94E049AAD777E33D02C332D210D0A857A0CDA9BF12739A76190A804B33514C7, 0xDAB94E53C7BBF3B515EF5194E956C74BDD494B6C9B639A426D33ED0342931704DE860C313CEC578CEAB6F383662C3443D3086834EFDD72FBC62922CA1AF1887700000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000, 1, 0)
GO
INSERT [dbo].[Users] ([UserId], [FirstName], [LastName], [Email], [PasswordSalt], [PasswordHash], [Status], [Findex]) VALUES (2, N'İrem', N'Çınar', N'irem@irem.com', 0xDC821054F734A1CBD2A7303B1678C97BB8AB2FC461EE10EA8E80B0E8EEA3AEBEB29D4818CF6E8070F7FF55E7899CEC94D70EDC87D888680AB6E713B5AD9F046B11972FBC24EDC99F4FD72C0D5614AE998509EF7B46289F2E191609A7BE770DBC460AC44BBC5C3BC22A1BE5802BA1CE753BCF3843AA77B3398101D5C214B79F69, 0xD356A94169D919F12578CE3BC438924A6BAB08864040562DCC92BB735EBD6BCFF8AB9B4092C40BB3216FA96D57E6C896F965EDE7D5931DEE4985A8CB96903C7B00000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000, 1, 0)
GO
INSERT [dbo].[Users] ([UserId], [FirstName], [LastName], [Email], [PasswordSalt], [PasswordHash], [Status], [Findex]) VALUES (3, N'Tuğba', N'Öztürk', N'tugba@tugba.com', 0xED7BC6A73922E04177915892997A0B9C368ACB10083EAE2A141C5ADD39FE8412ECDC31871F0ACA41CCA4E6205C083ADC87E68E3358B79E633D25372C96EEC123B5783A2DCAA4953EB7BBCC22BB1641A7E9F729C1A7A1E131131C9A6724895840EAA0444DCE0F2F7CF7FC1585610D34189481582B4B0CFD63225AB3F008391661, 0x12B8B743F045928BE8ED8E67714D8007C90F5689CB1ED5BDF0289952B34F7959396A29BB1FC680E8E1B13FD211F99E3A033F4856B067E165A182D00A0D94C23F00000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000, 1, 0)
GO
INSERT [dbo].[Users] ([UserId], [FirstName], [LastName], [Email], [PasswordSalt], [PasswordHash], [Status], [Findex]) VALUES (4, N'Ahmet Ali', N'Mehmet', N'ahmet@ahmet.com', 0x8D2AE3E3C0752F3B77F27E7810E5A8FF8FEE76BD79EF405F6EF9780E727F50D88186A9D363415203B777446580A14E0FAB5723EA59100CBB0A6173F2E9140E85194530119C311FA3EC12138EC1EA8666A551A0CEB64568D56171A6BBAB844D2CC7E30529C040F4950170FAD12ACEFEBA2F22CA45DAF0DA77F970F855612F2112, 0xF54947D54A7766066425102F5C1FDC592C1C0DC0223164B5215A9B59C28D3BC37B6DA823C552E07D231C58C11DF3F892ACE792001D1D3AFCAF7B3BE9D60DAB85, 1, 350)
GO
INSERT [dbo].[Users] ([UserId], [FirstName], [LastName], [Email], [PasswordSalt], [PasswordHash], [Status], [Findex]) VALUES (5, N'Ali Veli', N'1234123412341234', N'ali@veli.com', 0x9B7D3C9EBFAC7F2A8708B4E880998C01A3AFA0808661F2126FF95C0384764DBFE963F3BB5D6961D40F373A3A5CB522FF871CDA0A9DEA9F74B31F71E6A0EB06143F9EB41768304572F11D49528849F86C34BD571B96615E5700C3F7157103C50A3B4E83C22AAEBDEB914AE4D74C6BFAE060ABCB6BB05D098C0B8DF51CE1D2A82D, 0xCFB1B00D1DAA0C11274E83E32E4F6A8A54B3ACDA94A193604FA86A5629950B43AA843CB11C1DA813F5B65BC7276CE9D716FE44BA21A32213DB8D8DD81777E91D, 1, 0)
GO
INSERT [dbo].[Users] ([UserId], [FirstName], [LastName], [Email], [PasswordSalt], [PasswordHash], [Status], [Findex]) VALUES (1002, N'Can', N'Özdemir', N'can@can.com', 0x1D60125548537E6A565682B56F0DA97F2E9FE757F331F7C6177625C09CB8974368653CA0B2A1F993A1E99B24E79BACCC1752FBACADA2861C6C885F082F6286FE0AFCEFE8C14DA569709823B0AB519CE7EEE260FCFEB8BEDF27876880F878BEA74A48D30C07CBE14DC50A90C65A3A49D568C77C80FAD49991BCD891A04A31FB4F, 0x3FB61B3D28E2A16482613FBF1EA5F00E3DAFC0D9DD443AC3A03DF1DFEB08B5B0AC4B44BF9C94FCC1DDB091FC55307640DF22DABEC48C801FCB3CF7578790F85B, 1, 0)
GO
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
ALTER TABLE [dbo].[Users] ADD  DEFAULT ((0)) FOR [Findex]
GO
ALTER TABLE [dbo].[CarImages]  WITH CHECK ADD  CONSTRAINT [FK_Table_ToTable] FOREIGN KEY([CarId])
REFERENCES [dbo].[Cars] ([CarId])
GO
ALTER TABLE [dbo].[CarImages] CHECK CONSTRAINT [FK_Table_ToTable]
GO
ALTER TABLE [dbo].[Cars]  WITH CHECK ADD FOREIGN KEY([BrandId])
REFERENCES [dbo].[Brands] ([BrandId])
GO
ALTER TABLE [dbo].[Cars]  WITH CHECK ADD FOREIGN KEY([ColorId])
REFERENCES [dbo].[Colors] ([ColorId])
GO
ALTER TABLE [dbo].[Rentals]  WITH CHECK ADD FOREIGN KEY([CarId])
REFERENCES [dbo].[Cars] ([CarId])
GO
ALTER TABLE [dbo].[Rentals]  WITH CHECK ADD FOREIGN KEY([CustomerId])
REFERENCES [dbo].[Customers] ([CustomerId])
GO
