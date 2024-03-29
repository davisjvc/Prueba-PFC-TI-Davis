CREATE DATABASE PruebaPFC
USE [PruebaPFC]
GO
/****** Object:  Table [dbo].[Cliente]    Script Date: 28-Aug-19 6:07:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cliente](
	[ClienteId] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](100) NOT NULL,
	[Direccion] [varchar](200) NULL,
	[Telefono] [varchar](9) NULL,
	[Email] [varchar](50) NULL,
	[FechaNac] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[ClienteId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Orden]    Script Date: 28-Aug-19 6:07:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orden](
	[OrdenId] [int] IDENTITY(1,1) NOT NULL,
	[FechaOrden] [datetime] NOT NULL,
	[TipoPago] [varchar](15) NULL,
	[Total] [decimal](10, 0) NULL,
	[Entregada] [bit] NOT NULL,
	[ClienteId] [int] NULL,
 CONSTRAINT [PK_Ordenes] PRIMARY KEY CLUSTERED 
(
	[OrdenId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Cliente] ON 

INSERT [dbo].[Cliente] ([ClienteId], [Nombre], [Direccion], [Telefono], [Email], [FechaNac]) VALUES (1, N'Davis Vargas', N'San Pedro', N'2546-4126', N'davisjvc@gmail.com', CAST(N'1987-10-27T00:00:00.000' AS DateTime))
INSERT [dbo].[Cliente] ([ClienteId], [Nombre], [Direccion], [Telefono], [Email], [FechaNac]) VALUES (2, N'Juan Perez', N'San José', N'8888-8888', N'juan@hotmail.com', CAST(N'2001-08-19T00:00:00.000' AS DateTime))
INSERT [dbo].[Cliente] ([ClienteId], [Nombre], [Direccion], [Telefono], [Email], [FechaNac]) VALUES (3, N'Maria Castro', N'Limón', N'8825-9874', N'maria@gmail.com', CAST(N'2000-12-26T00:00:00.000' AS DateTime))
INSERT [dbo].[Cliente] ([ClienteId], [Nombre], [Direccion], [Telefono], [Email], [FechaNac]) VALUES (4, N'Berny Mendéz', N'Alajuela', N'8894-3685', N'berny@yahoo.com', CAST(N'1990-02-03T00:00:00.000' AS DateTime))
INSERT [dbo].[Cliente] ([ClienteId], [Nombre], [Direccion], [Telefono], [Email], [FechaNac]) VALUES (5, N'Georgia Tencio', N'Cartago', N'4585-6526', N'gtencio@gmail.com', CAST(N'1970-08-02T00:00:00.000' AS DateTime))
INSERT [dbo].[Cliente] ([ClienteId], [Nombre], [Direccion], [Telefono], [Email], [FechaNac]) VALUES (6, N'Daniela Rodriguez', N'San José', N'2245-8596', N'daniro@outlook.com', CAST(N'1993-03-25T00:00:00.000' AS DateTime))
INSERT [dbo].[Cliente] ([ClienteId], [Nombre], [Direccion], [Telefono], [Email], [FechaNac]) VALUES (7, N'Jimena Vargas', N'', N'8789-2545', N'', CAST(N'1991-04-06T00:00:00.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[Cliente] OFF
SET IDENTITY_INSERT [dbo].[Orden] ON 

INSERT [dbo].[Orden] ([OrdenId], [FechaOrden], [TipoPago], [Total], [Entregada], [ClienteId]) VALUES (18, CAST(N'2019-02-25T00:00:00.000' AS DateTime), N'Efectivo', CAST(100000 AS Decimal(10, 0)), 1, 1)
INSERT [dbo].[Orden] ([OrdenId], [FechaOrden], [TipoPago], [Total], [Entregada], [ClienteId]) VALUES (20, CAST(N'2019-02-25T00:00:00.000' AS DateTime), N'Tarjeta', CAST(46464 AS Decimal(10, 0)), 0, 1)
INSERT [dbo].[Orden] ([OrdenId], [FechaOrden], [TipoPago], [Total], [Entregada], [ClienteId]) VALUES (25, CAST(N'2019-02-25T00:00:00.000' AS DateTime), N'Efectivo', CAST(894523 AS Decimal(10, 0)), 1, 1)
INSERT [dbo].[Orden] ([OrdenId], [FechaOrden], [TipoPago], [Total], [Entregada], [ClienteId]) VALUES (26, CAST(N'2019-02-25T00:00:00.000' AS DateTime), N'Tarjeta', CAST(894523 AS Decimal(10, 0)), 0, 1)
INSERT [dbo].[Orden] ([OrdenId], [FechaOrden], [TipoPago], [Total], [Entregada], [ClienteId]) VALUES (27, CAST(N'2019-02-25T00:00:00.000' AS DateTime), N'Efectivo', CAST(456631 AS Decimal(10, 0)), 1, 1)
INSERT [dbo].[Orden] ([OrdenId], [FechaOrden], [TipoPago], [Total], [Entregada], [ClienteId]) VALUES (28, CAST(N'2019-02-25T00:00:00.000' AS DateTime), N'Tarjeta', CAST(455123 AS Decimal(10, 0)), 0, 2)
INSERT [dbo].[Orden] ([OrdenId], [FechaOrden], [TipoPago], [Total], [Entregada], [ClienteId]) VALUES (31, CAST(N'2019-02-25T00:00:00.000' AS DateTime), N'Efectivo', CAST(55785 AS Decimal(10, 0)), 1, 2)
INSERT [dbo].[Orden] ([OrdenId], [FechaOrden], [TipoPago], [Total], [Entregada], [ClienteId]) VALUES (32, CAST(N'2019-02-25T00:00:00.000' AS DateTime), N'Tarjeta', CAST(95235 AS Decimal(10, 0)), 0, 2)
INSERT [dbo].[Orden] ([OrdenId], [FechaOrden], [TipoPago], [Total], [Entregada], [ClienteId]) VALUES (33, CAST(N'2019-02-25T00:00:00.000' AS DateTime), N'Efectivo', CAST(56223 AS Decimal(10, 0)), 1, 3)
INSERT [dbo].[Orden] ([OrdenId], [FechaOrden], [TipoPago], [Total], [Entregada], [ClienteId]) VALUES (34, CAST(N'2019-02-25T00:00:00.000' AS DateTime), N'Tarjeta', CAST(556645 AS Decimal(10, 0)), 0, 3)
INSERT [dbo].[Orden] ([OrdenId], [FechaOrden], [TipoPago], [Total], [Entregada], [ClienteId]) VALUES (35, CAST(N'2019-02-25T00:00:00.000' AS DateTime), N'Efectivo', CAST(456145 AS Decimal(10, 0)), 1, 3)
INSERT [dbo].[Orden] ([OrdenId], [FechaOrden], [TipoPago], [Total], [Entregada], [ClienteId]) VALUES (36, CAST(N'2019-02-25T00:00:00.000' AS DateTime), N'Tarjeta', CAST(452455 AS Decimal(10, 0)), 0, 4)
INSERT [dbo].[Orden] ([OrdenId], [FechaOrden], [TipoPago], [Total], [Entregada], [ClienteId]) VALUES (37, CAST(N'2019-02-25T00:00:00.000' AS DateTime), N'Efectivo', CAST(56326 AS Decimal(10, 0)), 1, 4)
INSERT [dbo].[Orden] ([OrdenId], [FechaOrden], [TipoPago], [Total], [Entregada], [ClienteId]) VALUES (38, CAST(N'2019-02-25T00:00:00.000' AS DateTime), N'Tarjeta', CAST(65263 AS Decimal(10, 0)), 0, 4)
INSERT [dbo].[Orden] ([OrdenId], [FechaOrden], [TipoPago], [Total], [Entregada], [ClienteId]) VALUES (39, CAST(N'2019-02-25T00:00:00.000' AS DateTime), N'Efectivo', CAST(54564 AS Decimal(10, 0)), 1, 5)
INSERT [dbo].[Orden] ([OrdenId], [FechaOrden], [TipoPago], [Total], [Entregada], [ClienteId]) VALUES (40, CAST(N'2019-02-25T00:00:00.000' AS DateTime), N'Tarjeta', CAST(23526 AS Decimal(10, 0)), 0, 5)
INSERT [dbo].[Orden] ([OrdenId], [FechaOrden], [TipoPago], [Total], [Entregada], [ClienteId]) VALUES (41, CAST(N'2019-02-25T00:00:00.000' AS DateTime), N'Efectivo', CAST(45415 AS Decimal(10, 0)), 1, 6)
INSERT [dbo].[Orden] ([OrdenId], [FechaOrden], [TipoPago], [Total], [Entregada], [ClienteId]) VALUES (42, CAST(N'2019-02-25T00:00:00.000' AS DateTime), N'Tarjeta', CAST(54522 AS Decimal(10, 0)), 0, 7)
SET IDENTITY_INSERT [dbo].[Orden] OFF
ALTER TABLE [dbo].[Orden] ADD  DEFAULT ((1)) FOR [Entregada]
GO
ALTER TABLE [dbo].[Orden]  WITH CHECK ADD  CONSTRAINT [FK_Ordenes_Cliente] FOREIGN KEY([ClienteId])
REFERENCES [dbo].[Cliente] ([ClienteId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Orden] CHECK CONSTRAINT [FK_Ordenes_Cliente]
GO
/****** Object:  StoredProcedure [dbo].[procActualizarCliente]    Script Date: 28-Aug-19 6:07:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[procActualizarCliente]
(
	  @ClienteId int
     ,@Nombre varchar(100)
    , @Direccion varchar(200)
    , @Telefono varchar(9)
	, @Email varchar(50)
	, @FechaNac datetime
)
AS
BEGIN
    BEGIN TRANSACTION [Tran1]

    BEGIN TRY      
       
		UPDATE [dbo].[Cliente]
		   SET [Nombre] = @Nombre
			  ,[Direccion] = @Direccion
			  ,[Telefono] = @Telefono
			  ,[Email] = @Email
			  ,[FechaNac] = @FechaNac
		 WHERE ClienteID = @ClienteId

        COMMIT TRANSACTION [Tran1]

    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0
        BEGIN
            ROLLBACK TRANSACTION [Tran1]
		END
    END CATCH
END;
GO
/****** Object:  StoredProcedure [dbo].[procEliminarOrden]    Script Date: 28-Aug-19 6:07:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[procEliminarOrden]
(
	  @OrdenId int
)
AS
BEGIN
    BEGIN TRANSACTION [Tran1]

    BEGIN TRY      
       
		DELETE FROM [dbo].[Orden]
		WHERE OrdenId = @OrdenId

        COMMIT TRANSACTION [Tran1]

    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0
        BEGIN
            ROLLBACK TRANSACTION [Tran1]
		END
    END CATCH
END;
GO
