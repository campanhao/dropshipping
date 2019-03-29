USE [master]
GO

/****** Object:  Database [POC_DROPSHIPPING]    Script Date: 21/03/2019 21:12:49 ******/
CREATE DATABASE [POC_DROPSHIPPING]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'POC_DROPSHIPPING', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\POC_LOJA.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'POC_DROPSHIPPING_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\POC_LOJA_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO

ALTER DATABASE [POC_DROPSHIPPING] SET COMPATIBILITY_LEVEL = 140
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [POC_DROPSHIPPING].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

ALTER DATABASE [POC_DROPSHIPPING] SET ANSI_NULL_DEFAULT OFF 
GO

ALTER DATABASE [POC_DROPSHIPPING] SET ANSI_NULLS OFF 
GO

ALTER DATABASE [POC_DROPSHIPPING] SET ANSI_PADDING OFF 
GO

ALTER DATABASE [POC_DROPSHIPPING] SET ANSI_WARNINGS OFF 
GO

ALTER DATABASE [POC_DROPSHIPPING] SET ARITHABORT OFF 
GO

ALTER DATABASE [POC_DROPSHIPPING] SET AUTO_CLOSE ON 
GO

ALTER DATABASE [POC_DROPSHIPPING] SET AUTO_SHRINK OFF 
GO

ALTER DATABASE [POC_DROPSHIPPING] SET AUTO_UPDATE_STATISTICS ON 
GO

ALTER DATABASE [POC_DROPSHIPPING] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO

ALTER DATABASE [POC_DROPSHIPPING] SET CURSOR_DEFAULT  GLOBAL 
GO

ALTER DATABASE [POC_DROPSHIPPING] SET CONCAT_NULL_YIELDS_NULL OFF 
GO

ALTER DATABASE [POC_DROPSHIPPING] SET NUMERIC_ROUNDABORT OFF 
GO

ALTER DATABASE [POC_DROPSHIPPING] SET QUOTED_IDENTIFIER OFF 
GO

ALTER DATABASE [POC_DROPSHIPPING] SET RECURSIVE_TRIGGERS OFF 
GO

ALTER DATABASE [POC_DROPSHIPPING] SET  ENABLE_BROKER 
GO

ALTER DATABASE [POC_DROPSHIPPING] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO

ALTER DATABASE [POC_DROPSHIPPING] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO

ALTER DATABASE [POC_DROPSHIPPING] SET TRUSTWORTHY OFF 
GO

ALTER DATABASE [POC_DROPSHIPPING] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO

ALTER DATABASE [POC_DROPSHIPPING] SET PARAMETERIZATION SIMPLE 
GO

ALTER DATABASE [POC_DROPSHIPPING] SET READ_COMMITTED_SNAPSHOT OFF 
GO

ALTER DATABASE [POC_DROPSHIPPING] SET HONOR_BROKER_PRIORITY OFF 
GO

ALTER DATABASE [POC_DROPSHIPPING] SET RECOVERY SIMPLE 
GO

ALTER DATABASE [POC_DROPSHIPPING] SET  MULTI_USER 
GO

ALTER DATABASE [POC_DROPSHIPPING] SET PAGE_VERIFY CHECKSUM  
GO

ALTER DATABASE [POC_DROPSHIPPING] SET DB_CHAINING OFF 
GO

ALTER DATABASE [POC_DROPSHIPPING] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO

ALTER DATABASE [POC_DROPSHIPPING] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO

ALTER DATABASE [POC_DROPSHIPPING] SET DELAYED_DURABILITY = DISABLED 
GO

ALTER DATABASE [POC_DROPSHIPPING] SET QUERY_STORE = OFF
GO

USE [POC_DROPSHIPPING]
GO

ALTER DATABASE SCOPED CONFIGURATION SET IDENTITY_CACHE = ON;
GO

ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO

ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
GO

ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO

ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
GO

ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO

ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
GO

ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO

ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
GO

ALTER DATABASE [POC_DROPSHIPPING] SET  READ_WRITE 
GO


GO

/************************************************************************************/
IF OBJECT_ID(N'[dbo].[Categoria]', N'U') IS NULL
BEGIN
	PRINT 'CREATE TABLE [dbo].[Categoria]'

CREATE TABLE [dbo].[Categoria](
	[CategoriaId] [int] NOT NULL,
	[Nome] [varchar](100) NOT NULL,
	[Descricao] [varchar](400) NOT NULL,
 CONSTRAINT [PK_Categoria] PRIMARY KEY CLUSTERED 
(
	[CategoriaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


INSERT INTO dbo.Categoria values(1,'Smartphones','Smartphones');
INSERT INTO dbo.Categoria values(2,'Televisores','Televisores');

END


GO

/************************************************************************************/
IF OBJECT_ID(N'[dbo].[FormaPagamento]', N'U') IS NULL
BEGIN
	PRINT 'CREATE TABLE [dbo].[FormaPagamento]'

CREATE TABLE [dbo].[FormaPagamento](
	[FormaPagamentoId] [int] NOT NULL,
	[Nome] [varchar](50) NOT NULL,
 CONSTRAINT [PK_FormaPagamento] PRIMARY KEY CLUSTERED 
(
	[FormaPagamentoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


INSERT INTO  dbo.FormaPagamento values(1,'Boleto Bancário');
INSERT INTO  dbo.FormaPagamento values(2,'Cartão de Crédito');
INSERT INTO  dbo.FormaPagamento values(3,'Cartão de Débito');

END

GO

/************************************************************************************/
IF OBJECT_ID(N'[dbo].[Fornecedor]', N'U') IS NULL
BEGIN
	PRINT 'CREATE TABLE [dbo].[Fornecedor]'

CREATE TABLE [dbo].[Fornecedor](
	[FornecedorId] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [varchar](200) NOT NULL,
	[CNPJ] [varchar](14) NOT NULL,
	[Ativo] bit NOT NULL default 1,
	[Usuario] [varchar](50),
	[Senha] [varchar](50),
PRIMARY KEY CLUSTERED 
(
	[FornecedorId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


INSERT INTO dbo.Fornecedor values('Fornecedor 1','96388830000107',1,'fornecedor1','Zm9ybmVjZWRvcjFAMTIz');
INSERT INTO dbo.Fornecedor values('Fornecedor 2','22186462000188',1,'fornecedor2','Zm9ybmVjZWRvcjJAMTIz');
INSERT INTO dbo.Fornecedor values('Fornecedor 3','39433862000143',1,'fornecedor3','Zm9ybmVjZWRvcjNAMTIz');


END

GO

/************************************************************************************/
IF OBJECT_ID(N'[dbo].[Perfil]', N'U') IS NULL
BEGIN
	PRINT 'CREATE TABLE [dbo].[Perfil]'

	CREATE TABLE [dbo].[Perfil](
		[PerfilId]  [int] IDENTITY(1,1) NOT NULL,
		[Nome] [varchar](50) NOT NULL,
	 CONSTRAINT [PK_Perfil] PRIMARY KEY CLUSTERED 
	(
		[PerfilId] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]


INSERT INTO dbo.Perfil values('Cliente');
INSERT INTO dbo.Perfil values('Vendedor');

END


/************************************************************************************/
IF OBJECT_ID(N'[dbo].[Usuario]', N'U') IS NULL
BEGIN
	PRINT 'CREATE TABLE [dbo].[Usuario]'

	CREATE TABLE [dbo].[Usuario](
		[UsuarioId]  [int] IDENTITY(1,1) NOT NULL,
		[PerfilId] [int] NOT NULL,
		[Nome] [varchar](200) NOT NULL,
		[Email] [varchar](100) NOT NULL,
		[Telefone] [varchar](20) NOT NULL,
		[Cpf] [varchar](11) NOT NULL,
		[Senha] [varchar](200) NOT NULL,

	 CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED 
	(
		[UsuarioId] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]

	ALTER TABLE [dbo].[Usuario]  WITH CHECK ADD  CONSTRAINT [FK_Usuario_Perfil] FOREIGN KEY([PerfilId])
REFERENCES [dbo].[Perfil] ([PerfilId])

ALTER TABLE [dbo].[Usuario] CHECK CONSTRAINT [FK_Usuario_Perfil]

INSERT INTO dbo.Usuario values(1,'Rafael','cliente@gmail.com','11999999999','28491323813','MTIzNDU2');


END


GO

/************************************************************************************/
IF OBJECT_ID(N'[dbo].[UsuarioEndereco]', N'U') IS NULL
BEGIN
	PRINT 'CREATE TABLE [dbo].[UsuarioEndereco]'

CREATE TABLE [dbo].[UsuarioEndereco](
	[UsuarioEnderecoId] [int] IDENTITY(1,1) NOT NULL,
	[UsuarioId] [int] NOT NULL,
	[Logradouro] [varchar](100) NOT NULL,
	[Numero] [varchar](10) NOT NULL,
	[Complemento] [varchar](50) NULL,
	[Bairro] [varchar](50) NOT NULL,
	[Cidade] [varchar](50) NOT NULL,
	[Estado] [varchar](2) NOT NULL,
	[CEP] [varchar](8) NOT NULL,
 CONSTRAINT [PK_UsuarioEndereco] PRIMARY KEY CLUSTERED 
(
	[UsuarioEnderecoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


	ALTER TABLE [dbo].[UsuarioEndereco]  WITH CHECK ADD  CONSTRAINT [FK_UsuarioEndereco_Usuario] FOREIGN KEY([UsuarioID])
		REFERENCES [dbo].[Usuario] ([UsuarioID])
	ALTER TABLE [dbo].[UsuarioEndereco]  CHECK CONSTRAINT [FK_UsuarioEndereco_Usuario]


INSERT INTO dbo.UsuarioEndereco values(1,'Rua Teste','9999',NULL,'Moema','São Paulo','SP','04522000');


END

GO

/************************************************************************************/
IF OBJECT_ID(N'[dbo].[Status]', N'U') IS NULL
BEGIN
	PRINT 'CREATE TABLE [dbo].[Status]'

CREATE TABLE [dbo].[Status](
	[StatusId] [int] NOT NULL,
	[Nome] [varchar](50) NOT NULL,
	[Descricao] [varchar](500) NOT NULL,
 CONSTRAINT [PK_Status] PRIMARY KEY CLUSTERED 
(
	[StatusId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


INSERT INTO dbo.Status values(1,'Aguardando confirmação de pedido','Aguardando confirmação de pedido');
INSERT INTO dbo.Status values(2,'Pedido confirmado','Pedido confirmado');
INSERT INTO dbo.Status values(3,'Pedido em separação','Separação e preparação do pedido');
INSERT INTO dbo.Status values(4,'Pedido enviado','Pedido enviado');
INSERT INTO dbo.Status values(5,'Pedido entregue','Pedido entregue ao cliente final');
INSERT INTO dbo.Status values(6,'Pedido cancelado','Pedido cancelado');


END

GO

/************************************************************************************/
IF OBJECT_ID(N'[dbo].[Produto]', N'U') IS NULL
BEGIN
	PRINT 'CREATE TABLE [dbo].[Produto]'

CREATE TABLE [dbo].[Produto](
	[ProdutoId] [int] IDENTITY(1,1) NOT NULL,
	[CodProdFornec] [varchar](30) NOT NULL,
	[Nome] [varchar](50) NOT NULL,
	[Descricao] [varchar](200) NOT NULL,
	[Imagem] [varchar](500) NOT NULL,
	[Preco] [decimal](10, 2) NOT NULL,
	[EmEstoque] [bit] NOT NULL,
	[Ativo] [bit] NOT NULL,
	[FornecedorId] [int] NOT NULL,
	[CategoriaId] [int] NOT NULL,
 CONSTRAINT [PK_Produto] PRIMARY KEY CLUSTERED 
(
	[ProdutoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

ALTER TABLE [dbo].[Produto]  WITH CHECK ADD  CONSTRAINT [FK_Produto_Categoria] FOREIGN KEY([CategoriaId])
REFERENCES [dbo].[Categoria] ([CategoriaId])

ALTER TABLE [dbo].[Produto] CHECK CONSTRAINT [FK_Produto_Categoria]

ALTER TABLE [dbo].[Produto]  WITH CHECK ADD  CONSTRAINT [FK_Produto_Fornecedor] FOREIGN KEY([FornecedorId])
REFERENCES [dbo].[Fornecedor] ([FornecedorId])

ALTER TABLE [dbo].[Produto] CHECK CONSTRAINT [FK_Produto_Fornecedor]

INSERT INTO  dbo.Produto values('P000001F001','Galaxy J5','Smartphone Samsung Galaxy J5 Prime Leitor Digital, Câmera Frontal com Flash a LED, 4G, Dual Chip, 32GB, Dourado, Tela 5',
'94c8df43-1934-49d9-8aa9-93d1aa53ac33',799.00,1,1,1,1);

INSERT INTO  dbo.Produto values('P000002F001','Glaxy J7','Smartphone Samsung Galaxy J7 Prime 2 Preto 32GB Tela 5.5” Dual Chip Android 7.1 Câmera 13MP TV Digital 3GB RAM Processador Octa-Core',
'cd34e0ce-0f2c-4d13-a940-5fad86dc20d5',999.00,1,1,1,1);

INSERT INTO  dbo.Produto values('P000001F002','Galaxy J6','Smartphone Samsung Galaxy J6 Câmera 13MP, TV Digital HD, Dual Chip, Android, 8.0, Processador Octa Core e 2GB de RAM, 32GB, Prata, Tela de 5,6',
'd1879501-783b-46b2-9b46-8b3113202527',799.00,1,1,2,1);

INSERT INTO  dbo.Produto values('P000003F001','Motorola Moto G6','Smartphone Motorola Moto G6 Play XT1922 Dual Chip, Android 8.0, 4G, Câmera 13MP, Processador Octa-Core e 3GB de RAM, 32GB, Ouro, Tela de 5,7',
'33a0104f-0997-4eca-b19d-d91a5d123f33',699.00,1,1,1,1);

INSERT INTO  dbo.Produto values('P000004F001','Galaxy J8','Smartphone Samsung Galaxy J8 Câmera 13MP, TV Digital HD, Dual Chip, Android, 8.0, Processador Octa Core e 2GB de RAM, 32GB, Preto, Tela de 5,6',
'001eacb7-c596-4df3-9e50-f9d13481e901',699.00,1,1,1,1);

INSERT INTO  dbo.Produto values('P000005F001','Iphone 7','iPhone 7 Apple Plus iOS 11, Dupla Câmera Traseira, Resistente à Água, Wi-Fi, 4G LTE e NFC, 32GB, Ouro Rosa, Tela HD de 5,5',
'3aa4a75c-5ab3-48c5-bf8f-ec2be0ee878f',3799.00,1,1,1,1);

INSERT INTO  dbo.Produto values('P000006F001','Motorola One XT1941','Smartphone Motorola One XT1941 Branco 64GB Tela de 5,9", Dual Chip, Android 8.1, Câmera Traseira Dupla, Processador Octa-Core',
'452a14bb-fb1f-43ba-b889-5920f3c0d649',1799.00,1,1,1,1);

INSERT INTO  dbo.Produto values('P000002F002','Iphone 8','iPhone 8 Apple com iOS 11, Câmera de 12 MP, Resistente à Água, Wi-Fi, 4G LTE e NFC, 64GB, Cinza-Espacial, Tela HD de 4,7"',
'9a0378d7-5572-410e-8789-70fd957204b2',2999.00,1,1,1,1);

INSERT INTO  dbo.Produto values('P000007F001','Samsung Galaxy Note 9','Samsung Galaxy Note 9',
'dfbecf34-6715-4410-99be-853334770e15',3999.00,1,1,2,1);

INSERT INTO  dbo.Produto values('P000008F001','TV 32" Samsung','TV LED LED 32" Samsung 32J4000 com Connect Share Movie, Função Futebol',
'b4171977-2068-4985-979e-8590b82cc301',879.00,1,1,1,2);

INSERT INTO  dbo.Produto values('P000009F001','Smart TV 32" Sony','Smart TV LED 32" HD Sony KDL-32W655D com Wi-Fi, Rádio FM, Conversor Digital',
'b4d1d54d-11a0-4cb7-85ec-23d6bd64dbce',1119.00,1,1,1,2);

END


GO

/************************************************************************************/
IF OBJECT_ID(N'[dbo].[Pedido]', N'U') IS NULL
BEGIN
	PRINT 'CREATE TABLE [dbo].[Pedido]'
CREATE TABLE [dbo].[Pedido](
	[PedidoId] [int] IDENTITY(1,1) NOT NULL,
	[UsuarioId] [int] NOT NULL,
	[FormaPagamentoId] [int] NOT NULL,
	[Data] [datetime] NOT NULL,
	[ValorTotal] [decimal](10, 2) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[PedidoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

INSERT INTO  dbo.Pedido values(1,1,CONVERT(DATETIME,'21/03/2019 22:00:00'),1119.00);

END;

GO

/************************************************************************************/
IF OBJECT_ID(N'[dbo].[PedidoItem]', N'U') IS NULL
BEGIN
	PRINT 'CREATE TABLE [dbo].[PedidoItem]'

CREATE TABLE [dbo].[PedidoItem](
	[PedidoItemId] [int] IDENTITY(1,1) NOT NULL,
	[PedidoId] [int] NOT NULL,
	[ProdutoId] [int] NOT NULL,
	[Quantidade] [int] NOT NULL,
	[PrecoUnitario] [decimal](10, 2) NOT NULL,
	[ValorTotal] [decimal](10, 2) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[PedidoItemId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

ALTER TABLE [dbo].[PedidoItem]  WITH CHECK ADD  CONSTRAINT [FK_PedidoItem_Pedido] FOREIGN KEY([PedidoId])
REFERENCES [dbo].[Pedido] ([PedidoId])

ALTER TABLE [dbo].[PedidoItem] CHECK CONSTRAINT [FK_PedidoItem_Pedido]

ALTER TABLE [dbo].[PedidoItem]  WITH CHECK ADD  CONSTRAINT [FK_PedidoItem_Produto] FOREIGN KEY([ProdutoId])
REFERENCES [dbo].[Produto] ([ProdutoId])

ALTER TABLE [dbo].[PedidoItem] CHECK CONSTRAINT [FK_PedidoItem_Produto]

INSERT INTO  dbo.PedidoItem values(1,11,1,1119.00,1119.00);

END;


GO

/************************************************************************************/
IF OBJECT_ID(N'[dbo].[PedidoEntrega]', N'U') IS NULL
BEGIN
	PRINT 'CREATE TABLE [dbo].[PedidoEntrega]'

CREATE TABLE [dbo].[PedidoEntrega](
	[PedidoEntregaId] [int] IDENTITY(1,1) NOT NULL,
	[PedidoId] [int] NOT NULL,
	[Logradouro] [varchar](100) NOT NULL,
	[Numero] [varchar](10) NOT NULL,
	[Complemento] [varchar](50) NULL,
	[Bairro] [varchar](50) NOT NULL,
	[Cidade] [varchar](50) NOT NULL,
	[Estado] [varchar](2) NOT NULL,
	[CEP] [varchar](8) NOT NULL,
 CONSTRAINT [PK_PedidoEntrega] PRIMARY KEY CLUSTERED 
(
	[PedidoEntregaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

ALTER TABLE [dbo].[PedidoEntrega]  WITH CHECK ADD  CONSTRAINT [FK_PedidoEntrega_Pedido] FOREIGN KEY([PedidoId])
REFERENCES [dbo].[Pedido] ([PedidoId])

ALTER TABLE [dbo].[PedidoEntrega] CHECK CONSTRAINT [FK_PedidoEntrega_Pedido]

INSERT INTO  dbo.PedidoEntrega values(1,'Rua Teste',9999,NULL,'Moema','São Paulo','SP','04522000');

END;

GO

/************************************************************************************/
IF OBJECT_ID(N'[dbo].[PedidoItemFornecedor]', N'U') IS NULL
BEGIN
	PRINT 'CREATE TABLE [dbo].[PedidoItemFornecedor]'

CREATE TABLE [dbo].[PedidoItemFornecedor](
	[PedidoItemFornecedorId] [int] IDENTITY(1,1) NOT NULL,
	[CodPedidoItemFornec] [varchar] (30) NULL,
	[PedidoItemId] [int] NOT NULL,
	[FornecedorId] [int] NOT NULL,
	[StatusId] [int] NOT NULL,
	[UltimaAtualizacao] datetime NOT NULL,
	[Observacao] [varchar] (1000) NULL,
PRIMARY KEY CLUSTERED 
(
	[PedidoItemFornecedorId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

ALTER TABLE [dbo].[PedidoItemFornecedor]  WITH CHECK ADD  CONSTRAINT [FK_PedidoItemFornecedor_PedidoItem] FOREIGN KEY([PedidoitemId])
REFERENCES [dbo].[PedidoItem] ([PedidoItemId])

ALTER TABLE [dbo].[PedidoItemFornecedor] CHECK CONSTRAINT [FK_PedidoItemFornecedor_PedidoItem]

ALTER TABLE [dbo].[PedidoItemFornecedor]  WITH CHECK ADD  CONSTRAINT [FK_PedidoItemFornecedor_Fornecedor] FOREIGN KEY([FornecedorId])
REFERENCES [dbo].[Fornecedor] ([FornecedorId])

ALTER TABLE [dbo].[PedidoItemFornecedor] CHECK CONSTRAINT [FK_PedidoItemFornecedor_PedidoItem]

ALTER TABLE [dbo].[PedidoItemFornecedor]  WITH CHECK ADD  CONSTRAINT [FK_PedidoItemFornecedor_Status] FOREIGN KEY([StatusId])
REFERENCES [dbo].[Status] ([StatusId])

ALTER TABLE [dbo].[PedidoItemFornecedor] CHECK CONSTRAINT [FK_PedidoItemFornecedor_Status]


INSERT INTO  dbo.PedidoItemFornecedor values('PED-0000000001-F001',1,1,1,CONVERT(DATETIME,'21/03/2019 22:00:00'),NULL);

END;



