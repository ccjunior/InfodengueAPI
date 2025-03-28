USE [infodengue]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 23/03/2025 12:28:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Relatorios]    Script Date: 23/03/2025 12:28:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Relatorios](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DataSolicitacao] [datetime2](7) NOT NULL,
	[Arbovirose] [nvarchar](50) NOT NULL,
	[SolicitanteId] [int] NOT NULL,
	[SemanaInicio] [datetime] NOT NULL,
	[SemanaFim] [datetime] NOT NULL,
	[CodigoIBGE] [nvarchar](7) NOT NULL,
	[Municipio] [nvarchar](100) NOT NULL,
	[DadosConsulta] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Relatorios] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Solicitantes]    Script Date: 23/03/2025 12:28:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Solicitantes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [nvarchar](100) NOT NULL,
	[CPF] [nvarchar](11) NOT NULL,
 CONSTRAINT [PK_Solicitantes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20250321232514_Initial', N'9.0.3')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20250323010953_atualizar_tipo', N'9.0.3')
GO
SET IDENTITY_INSERT [dbo].[Relatorios] ON 

INSERT [dbo].[Relatorios] ([Id], [DataSolicitacao], [Arbovirose], [SolicitanteId], [SemanaInicio], [SemanaFim], [CodigoIBGE], [Municipio], [DadosConsulta]) VALUES (1, CAST(N'2025-03-22T22:14:39.9818700' AS DateTime2), N'dengue', 1, CAST(N'2025-03-23T00:00:00.000' AS DateTime), CAST(N'2025-03-23T00:00:00.000' AS DateTime), N'1200401', N'Rio Branco', N'[]')
INSERT [dbo].[Relatorios] ([Id], [DataSolicitacao], [Arbovirose], [SolicitanteId], [SemanaInicio], [SemanaFim], [CodigoIBGE], [Municipio], [DadosConsulta]) VALUES (2, CAST(N'2025-03-22T22:30:58.3807324' AS DateTime2), N'dengue', 1, CAST(N'2025-03-23T00:00:00.000' AS DateTime), CAST(N'2025-04-23T00:00:00.000' AS DateTime), N'1200401', N'Rio Branco', N'[]')
INSERT [dbo].[Relatorios] ([Id], [DataSolicitacao], [Arbovirose], [SolicitanteId], [SemanaInicio], [SemanaFim], [CodigoIBGE], [Municipio], [DadosConsulta]) VALUES (3, CAST(N'2025-03-22T22:44:06.4144387' AS DateTime2), N'dengue', 1, CAST(N'2025-02-17T00:00:00.000' AS DateTime), CAST(N'2025-03-17T00:00:00.000' AS DateTime), N'2917508', N'Jacobina', N'[{"data_iniSE":1739664000000,"SE":202508,"casos_est":11.0,"casos_est_min":10,"casos_est_max":13,"casos":10,"p_rt1":0.8220812678,"p_inc100k":12.4580955505,"Localidade_id":0,"nivel":1,"id":291750820250820165,"versao_modelo":"2025-03-18","tweet":null,"Rt":1.5342041254,"pop":88296.0,"tempmin":null,"umidmax":null,"receptivo":0,"transmissao":0,"nivel_inc":1,"umidmed":null,"umidmin":null,"tempmed":null,"tempmax":null,"casprov":9,"casprov_est":null,"casprov_est_min":null,"casprov_est_max":null,"casconf":null,"notif_accum_year":10}]')
INSERT [dbo].[Relatorios] ([Id], [DataSolicitacao], [Arbovirose], [SolicitanteId], [SemanaInicio], [SemanaFim], [CodigoIBGE], [Municipio], [DadosConsulta]) VALUES (4, CAST(N'2025-03-22T22:46:04.2846290' AS DateTime2), N'dengue', 1, CAST(N'2025-01-17T00:00:00.000' AS DateTime), CAST(N'2025-02-17T00:00:00.000' AS DateTime), N'2917508', N'Jacobina', N'[{"data_iniSE":1736640000000,"SE":202503,"casos_est":1.0,"casos_est_min":1,"casos_est_max":1,"casos":1,"p_rt1":0.2540645599,"p_inc100k":1.1325541735,"Localidade_id":0,"nivel":1,"id":291750820250320165,"versao_modelo":"2025-03-18","tweet":null,"Rt":0.5058852434,"pop":88296.0,"tempmin":20.784,"umidmax":96.3586571429,"receptivo":0,"transmissao":0,"nivel_inc":0,"umidmed":83.9050428571,"umidmin":68.0033571429,"tempmed":23.2740714286,"tempmax":26.4077714286,"casprov":1,"casprov_est":null,"casprov_est_min":null,"casprov_est_max":null,"casconf":null,"notif_accum_year":1}]')
INSERT [dbo].[Relatorios] ([Id], [DataSolicitacao], [Arbovirose], [SolicitanteId], [SemanaInicio], [SemanaFim], [CodigoIBGE], [Municipio], [DadosConsulta]) VALUES (5, CAST(N'2025-03-22T22:48:07.9927867' AS DateTime2), N'dengue', 1, CAST(N'2025-01-17T00:00:00.000' AS DateTime), CAST(N'2025-02-17T00:00:00.000' AS DateTime), N'2917508', N'Jacobina', N'[{"data_iniSE":1736640000000,"SE":202503,"casos_est":1.0,"casos_est_min":1,"casos_est_max":1,"casos":1,"p_rt1":0.2540645599,"p_inc100k":1.1325541735,"Localidade_id":0,"nivel":1,"id":291750820250320165,"versao_modelo":"2025-03-18","tweet":null,"Rt":0.5058852434,"pop":88296.0,"tempmin":20.784,"umidmax":96.3586571429,"receptivo":0,"transmissao":0,"nivel_inc":0,"umidmed":83.9050428571,"umidmin":68.0033571429,"tempmed":23.2740714286,"tempmax":26.4077714286,"casprov":1,"casprov_est":null,"casprov_est_min":null,"casprov_est_max":null,"casconf":null,"notif_accum_year":1}]')
INSERT [dbo].[Relatorios] ([Id], [DataSolicitacao], [Arbovirose], [SolicitanteId], [SemanaInicio], [SemanaFim], [CodigoIBGE], [Municipio], [DadosConsulta]) VALUES (6, CAST(N'2025-03-22T23:06:35.6198496' AS DateTime2), N'dengue', 1, CAST(N'2025-01-17T00:00:00.000' AS DateTime), CAST(N'2025-02-17T00:00:00.000' AS DateTime), N'2917508', N'Jacobina', N'[{"data_iniSE":1736640000000,"SE":202503,"casos_est":1.0,"casos_est_min":1,"casos_est_max":1,"casos":1,"p_rt1":0.2540645599,"p_inc100k":1.1325541735,"Localidade_id":0,"nivel":1,"id":291750820250320165,"versao_modelo":"2025-03-18","tweet":null,"Rt":0.5058852434,"pop":88296.0,"tempmin":20.784,"umidmax":96.3586571429,"receptivo":0,"transmissao":0,"nivel_inc":0,"umidmed":83.9050428571,"umidmin":68.0033571429,"tempmed":23.2740714286,"tempmax":26.4077714286,"casprov":1,"casprov_est":null,"casprov_est_min":null,"casprov_est_max":null,"casconf":null,"notif_accum_year":1}]')
INSERT [dbo].[Relatorios] ([Id], [DataSolicitacao], [Arbovirose], [SolicitanteId], [SemanaInicio], [SemanaFim], [CodigoIBGE], [Municipio], [DadosConsulta]) VALUES (7, CAST(N'2025-03-22T23:09:01.1781131' AS DateTime2), N'dengue', 1, CAST(N'2025-01-17T00:00:00.000' AS DateTime), CAST(N'2025-02-17T00:00:00.000' AS DateTime), N'2917508', N'Jacobina', N'[{"data_iniSE":1736640000000,"SE":202503,"casos_est":1.0,"casos_est_min":1,"casos_est_max":1,"casos":1,"p_rt1":0.2540645599,"p_inc100k":1.1325541735,"Localidade_id":0,"nivel":1,"id":291750820250320165,"versao_modelo":"2025-03-18","tweet":null,"Rt":0.5058852434,"pop":88296.0,"tempmin":20.784,"umidmax":96.3586571429,"receptivo":0,"transmissao":0,"nivel_inc":0,"umidmed":83.9050428571,"umidmin":68.0033571429,"tempmed":23.2740714286,"tempmax":26.4077714286,"casprov":1,"casprov_est":null,"casprov_est_min":null,"casprov_est_max":null,"casconf":null,"notif_accum_year":1}]')
INSERT [dbo].[Relatorios] ([Id], [DataSolicitacao], [Arbovirose], [SolicitanteId], [SemanaInicio], [SemanaFim], [CodigoIBGE], [Municipio], [DadosConsulta]) VALUES (8, CAST(N'2025-03-22T23:09:34.4662093' AS DateTime2), N'dengue', 1, CAST(N'2025-01-17T00:00:00.000' AS DateTime), CAST(N'2025-02-17T00:00:00.000' AS DateTime), N'2917508', N'Jacobina', N'[{"data_iniSE":1736640000000,"SE":202503,"casos_est":1.0,"casos_est_min":1,"casos_est_max":1,"casos":1,"p_rt1":0.2540645599,"p_inc100k":1.1325541735,"Localidade_id":0,"nivel":1,"id":291750820250320165,"versao_modelo":"2025-03-18","tweet":null,"Rt":0.5058852434,"pop":88296.0,"tempmin":20.784,"umidmax":96.3586571429,"receptivo":0,"transmissao":0,"nivel_inc":0,"umidmed":83.9050428571,"umidmin":68.0033571429,"tempmed":23.2740714286,"tempmax":26.4077714286,"casprov":1,"casprov_est":null,"casprov_est_min":null,"casprov_est_max":null,"casconf":null,"notif_accum_year":1}]')
INSERT [dbo].[Relatorios] ([Id], [DataSolicitacao], [Arbovirose], [SolicitanteId], [SemanaInicio], [SemanaFim], [CodigoIBGE], [Municipio], [DadosConsulta]) VALUES (9, CAST(N'2025-03-22T23:35:22.6619623' AS DateTime2), N'dengue', 1, CAST(N'2025-01-17T00:00:00.000' AS DateTime), CAST(N'2025-03-17T00:00:00.000' AS DateTime), N'3304557', N'Rio de Janeiro', N'[{"data_iniSE":1736640000000,"SE":202503,"casos_est":513.0,"casos_est_min":511,"casos_est_max":519,"casos":511,"p_rt1":0.9999986291,"p_inc100k":7.7424039841,"Localidade_id":0,"nivel":3,"id":330455720250320165,"versao_modelo":"2025-03-18","tweet":null,"Rt":1.3728631735,"pop":6625849.0,"tempmin":22.2045285714,"umidmax":90.2165571429,"receptivo":1,"transmissao":1,"nivel_inc":1,"umidmed":77.8640142857,"umidmin":62.4082428571,"tempmed":24.7140857143,"tempmax":27.8754,"casprov":243,"casprov_est":null,"casprov_est_min":null,"casprov_est_max":null,"casconf":null,"notif_accum_year":511}]')
INSERT [dbo].[Relatorios] ([Id], [DataSolicitacao], [Arbovirose], [SolicitanteId], [SemanaInicio], [SemanaFim], [CodigoIBGE], [Municipio], [DadosConsulta]) VALUES (10, CAST(N'2025-03-22T23:36:08.5179921' AS DateTime2), N'dengue', 1, CAST(N'2025-01-17T00:00:00.000' AS DateTime), CAST(N'2025-03-17T00:00:00.000' AS DateTime), N'3550308', N'São Paulo', N'[{"data_iniSE":1736640000000,"SE":202503,"casos_est":4302.0,"casos_est_min":4268,"casos_est_max":4367,"casos":4254,"p_rt1":1.0,"p_inc100k":35.2617759705,"Localidade_id":0,"nivel":4,"id":355030820250320165,"versao_modelo":"2025-03-18","tweet":null,"Rt":1.4972755909,"pop":12200180.0,"tempmin":17.9711714286,"umidmax":96.0442714286,"receptivo":0,"transmissao":1,"nivel_inc":2,"umidmed":84.5219,"umidmin":68.3923428571,"tempmed":20.7257,"tempmax":24.3982285714,"casprov":698,"casprov_est":null,"casprov_est_min":null,"casprov_est_max":null,"casconf":null,"notif_accum_year":4254}]')
INSERT [dbo].[Relatorios] ([Id], [DataSolicitacao], [Arbovirose], [SolicitanteId], [SemanaInicio], [SemanaFim], [CodigoIBGE], [Municipio], [DadosConsulta]) VALUES (11, CAST(N'2025-03-22T23:56:51.2935126' AS DateTime2), N'dengue', 1, CAST(N'2025-01-17T00:00:00.000' AS DateTime), CAST(N'2025-03-17T00:00:00.000' AS DateTime), N'3304557', N'Rio de Janeiro', N'[{"data_iniSE":1736640000000,"SE":202503,"casos_est":513.0,"casos_est_min":511,"casos_est_max":519,"casos":511,"p_rt1":0.9999986291,"p_inc100k":7.7424039841,"Localidade_id":0,"nivel":3,"id":330455720250320165,"versao_modelo":"2025-03-18","tweet":null,"Rt":1.3728631735,"pop":6625849.0,"tempmin":22.2045285714,"umidmax":90.2165571429,"receptivo":1,"transmissao":1,"nivel_inc":1,"umidmed":77.8640142857,"umidmin":62.4082428571,"tempmed":24.7140857143,"tempmax":27.8754,"casprov":243,"casprov_est":null,"casprov_est_min":null,"casprov_est_max":null,"casconf":null,"notif_accum_year":511}]')
INSERT [dbo].[Relatorios] ([Id], [DataSolicitacao], [Arbovirose], [SolicitanteId], [SemanaInicio], [SemanaFim], [CodigoIBGE], [Municipio], [DadosConsulta]) VALUES (12, CAST(N'2025-03-23T00:23:35.4214537' AS DateTime2), N'chikungunya', 1, CAST(N'2025-01-17T00:00:00.000' AS DateTime), CAST(N'2025-02-17T00:00:00.000' AS DateTime), N'3304557', N'Rio de Janeiro', N'[{"data_iniSE":1736640000000,"SE":202503,"casos_est":10.0,"casos_est_min":10,"casos_est_max":12,"casos":10,"p_rt1":0.1430193782,"p_inc100k":0.1509240568,"Localidade_id":0,"nivel":2,"id":330455720250320165,"versao_modelo":"2025-03-18","tweet":null,"Rt":0.655636549,"pop":6625849.0,"tempmin":22.2045285714,"umidmax":90.2165571429,"receptivo":1,"transmissao":0,"nivel_inc":0,"umidmed":77.8640142857,"umidmin":62.4082428571,"tempmed":24.7140857143,"tempmax":27.8754,"casprov":6,"casprov_est":null,"casprov_est_min":null,"casprov_est_max":null,"casconf":null,"notif_accum_year":10}]')
INSERT [dbo].[Relatorios] ([Id], [DataSolicitacao], [Arbovirose], [SolicitanteId], [SemanaInicio], [SemanaFim], [CodigoIBGE], [Municipio], [DadosConsulta]) VALUES (13, CAST(N'2025-03-23T00:47:16.7982994' AS DateTime2), N'chikungunya', 1, CAST(N'2025-01-17T00:00:00.000' AS DateTime), CAST(N'2025-02-17T00:00:00.000' AS DateTime), N'3550308', N'São Paulo', N'[{"data_iniSE":1736640000000,"SE":202503,"casos_est":18.0,"casos_est_min":17,"casos_est_max":21,"casos":17,"p_rt1":0.425195843,"p_inc100k":0.147538811,"Localidade_id":0,"nivel":1,"id":355030820250320165,"versao_modelo":"2025-03-18","tweet":null,"Rt":0.9406116009,"pop":12200180.0,"tempmin":17.9711714286,"umidmax":96.0442714286,"receptivo":0,"transmissao":0,"nivel_inc":0,"umidmed":84.5219,"umidmin":68.3923428571,"tempmed":20.7257,"tempmax":24.3982285714,"casprov":14,"casprov_est":null,"casprov_est_min":null,"casprov_est_max":null,"casconf":null,"notif_accum_year":17}]')
INSERT [dbo].[Relatorios] ([Id], [DataSolicitacao], [Arbovirose], [SolicitanteId], [SemanaInicio], [SemanaFim], [CodigoIBGE], [Municipio], [DadosConsulta]) VALUES (14, CAST(N'2025-03-23T10:41:11.6887082' AS DateTime2), N'dengue', 1, CAST(N'2025-01-17T00:00:00.000' AS DateTime), CAST(N'2025-02-17T00:00:00.000' AS DateTime), N'2927408', N'Salvador', N'[{"data_iniSE":1736640000000,"SE":202503,"casos_est":79.0,"casos_est_min":78,"casos_est_max":82,"casos":78,"p_rt1":0.6953559518,"p_inc100k":3.0256757736,"Localidade_id":0,"nivel":2,"id":292740820250320165,"versao_modelo":"2025-03-18","tweet":null,"Rt":1.0863169432,"pop":2610987.0,"tempmin":24.8488142857,"umidmax":89.6458428571,"receptivo":1,"transmissao":0,"nivel_inc":0,"umidmed":83.296,"umidmin":74.7984285714,"tempmed":26.2237,"tempmax":28.0121571429,"casprov":51,"casprov_est":null,"casprov_est_min":null,"casprov_est_max":null,"casconf":null,"notif_accum_year":78}]')
SET IDENTITY_INSERT [dbo].[Relatorios] OFF
GO
SET IDENTITY_INSERT [dbo].[Solicitantes] ON 

INSERT [dbo].[Solicitantes] ([Id], [Nome], [CPF]) VALUES (1, N'carlos', N'86988025081')
SET IDENTITY_INSERT [dbo].[Solicitantes] OFF
GO
ALTER TABLE [dbo].[Relatorios]  WITH CHECK ADD  CONSTRAINT [FK_Relatorios_Solicitantes_SolicitanteId] FOREIGN KEY([SolicitanteId])
REFERENCES [dbo].[Solicitantes] ([Id])
GO
ALTER TABLE [dbo].[Relatorios] CHECK CONSTRAINT [FK_Relatorios_Solicitantes_SolicitanteId]
GO
