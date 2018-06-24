USE [VideoLocadoraDB]
GO

/****** Object: Table [dbo].[Clientes] Script Date: 21/06/2018 22:12:08 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Clientes] (
    [ClienteId]   INT            IDENTITY (1, 1) NOT NULL,
    [Nome]        NVARCHAR (30)  NOT NULL,
    [CPF]         NVARCHAR (MAX) NULL,
    [Endereco]    NVARCHAR (MAX) NULL,
    [Numero]      NVARCHAR (MAX) NULL,
    [Complemento] NVARCHAR (MAX) NULL,
    [Telefone]    NVARCHAR (MAX) NULL,
    [Celular]     NVARCHAR (MAX) NULL
	
);


