USE [AVALOPE_NOVO]
GO
/****** Object:  Table [dbo].[AVAL_CRITERIO]    Script Date: 28/11/2017 08:48:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AVAL_CRITERIO](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[CODIGO] [int] NOT NULL,
	[NOME] [nvarchar](80) NOT NULL,
	[PESO] [float] NOT NULL,
	[DESVIO] [float] NOT NULL,
	[DISTRIBUICAO] [bit] NOT NULL,
	[ATIVO] [bit] NOT NULL,
	[SUBCRITERIO] [bit] NOT NULL,
	[AVALIACAO] [int] NOT NULL
) ON [PRIMARY]
GO
