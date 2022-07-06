USE [AVALOPE_NOVO]
GO
/****** Object:  Table [dbo].[AVAL_CASO]    Script Date: 28/11/2017 08:48:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AVAL_CASO](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ALIMENTADOR] [nvarchar](80) NOT NULL,
	[DESCRICAO] [nvarchar](200) NULL,
	[OCORRENCIA] [nvarchar](80) NULL,
	[SUBESTACAO] [nvarchar](80) NOT NULL,
	[CENTROOPERACAO] [int] NOT NULL,
	[DATA] [datetime] NOT NULL
) ON [PRIMARY]
GO
