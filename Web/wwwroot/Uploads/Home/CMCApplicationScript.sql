
CREATE DATABASE [CMC]
USE [CMC]
GO
/****** Object:  Table [dbo].[ApplyingDiscount]    Script Date: 10/31/2022 9:17:29 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ApplyingDiscount](
	[applying_discount_id] [int] IDENTITY(1,1) NOT NULL,
	[template_card_id] [int] NOT NULL,
	[discount_id] [int] NOT NULL,
 CONSTRAINT [PK_ApplyingDiscount] PRIMARY KEY CLUSTERED 
(
	[applying_discount_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Card]    Script Date: 10/31/2022 9:17:29 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Card](
	[card_id] [int] IDENTITY(1,1) NOT NULL,
	[template_id] [int] NOT NULL,
	[card_content] [varchar](255) NOT NULL,
	[created_date] [date] NOT NULL,
	[status] [int] NOT NULL,
 CONSTRAINT [PK_Card] PRIMARY KEY CLUSTERED 
(
	[card_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CardBox]    Script Date: 10/31/2022 9:17:29 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CardBox](
	[card_box_id] [int] IDENTITY(1,1) NOT NULL,
	[user_id] [int] NOT NULL,
	[card_id] [int] NOT NULL,
	[created_date] [int] NOT NULL,
	[status] [int] NOT NULL,
 CONSTRAINT [PK_CardBox] PRIMARY KEY CLUSTERED 
(
	[card_box_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CardType]    Script Date: 10/31/2022 9:17:29 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CardType](
	[type_id] [int] IDENTITY(1,1) NOT NULL,
	[type_name] [nvarchar](50) NOT NULL,
	[status] [int] NOT NULL,
	[Detail] [varchar](255) NULL,
	[createdAt] [datetime] NULL CONSTRAINT [DF_cardType_createdat]  DEFAULT (getdate()),
	[updatedAt] [datetime] NULL CONSTRAINT [DF_cardType_updatedAt]  DEFAULT (getdate()),
 CONSTRAINT [PK_CardType] PRIMARY KEY CLUSTERED 
(
	[type_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Discount]    Script Date: 10/31/2022 9:17:29 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Discount](
	[discount_id] [int] IDENTITY(1,1) NOT NULL,
	[discount_percent] [int] NOT NULL,
	[start_date] [date] NOT NULL,
	[end_date] [date] NOT NULL,
	[status] [bit] NOT NULL,
 CONSTRAINT [PK_Discount] PRIMARY KEY CLUSTERED 
(
	[discount_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Email]    Script Date: 10/31/2022 9:17:29 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Email](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[email_title] [nvarchar](255) NOT NULL,
	[email_content] [nvarchar](255) NOT NULL,
	[user_email] [nvarchar](255) NOT NULL,
	[status] [bit] NOT NULL,
 CONSTRAINT [PK_Email] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Payment]    Script Date: 10/31/2022 9:17:29 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Payment](
	[payment_id] [int] IDENTITY(1,1) NOT NULL,
	[user_id] [int] NOT NULL,
	[transaction_id] [nvarchar](50) NOT NULL,
	[amount] [float] NOT NULL,
	[status] [bit] NOT NULL,
 CONSTRAINT [PK_Payment] PRIMARY KEY CLUSTERED 
(
	[payment_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Receipt]    Script Date: 10/31/2022 9:17:29 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Receipt](
	[receipt_id] [int] IDENTITY(1,1) NOT NULL,
	[user_id] [int] NOT NULL,
	[price] [float] NOT NULL,
	[status] [int] NOT NULL,
	[created_date] [date] NOT NULL,
 CONSTRAINT [PK_Receipt] PRIMARY KEY CLUSTERED 
(
	[receipt_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Role]    Script Date: 10/31/2022 9:17:29 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Role](
	[role_id] [int] IDENTITY(1,1) NOT NULL,
	[role_name] [varchar](50) NOT NULL,
	[status] [int] NOT NULL,
 CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED 
(
	[role_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TemplateCard]    Script Date: 10/31/2022 9:17:29 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TemplateCard](
	[template_id] [int] IDENTITY(1,1) NOT NULL,
	[type_id] [int] NOT NULL,
	[title] [varchar](50) NOT NULL,
	[price] [float] NOT NULL,
	[status] [int] NOT NULL,
	[createdAt] [datetime] NULL CONSTRAINT [DF_TemplateCard_createdat]  DEFAULT (getdate()),
	[updatedAt] [datetime] NULL CONSTRAINT [DF_TemplateCard_updatedAt]  DEFAULT (getdate()),
	[FileName] [nvarchar](500) NULL,
 CONSTRAINT [PK_TemplateCard] PRIMARY KEY CLUSTERED 
(
	[template_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[User]    Script Date: 10/31/2022 9:17:29 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[User](
	[user_id] [int] IDENTITY(1,1) NOT NULL,
	[username] [varchar](50) NOT NULL,
	[password] [varchar](50) NOT NULL,
	[fullname] [varchar](50) NOT NULL,
	[phone_number] [nchar](10) NOT NULL,
	[identity_number] [nchar](12) NOT NULL,
	[email] [varchar](50) NOT NULL,
	[address] [varchar](50) NOT NULL,
	[role_id] [int] NOT NULL,
	[status] [int] NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[user_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[ApplyingDiscount]  WITH CHECK ADD  CONSTRAINT [FK_ApplyingDiscount_Discount] FOREIGN KEY([discount_id])
REFERENCES [dbo].[Discount] ([discount_id])
GO
ALTER TABLE [dbo].[ApplyingDiscount] CHECK CONSTRAINT [FK_ApplyingDiscount_Discount]
GO
ALTER TABLE [dbo].[ApplyingDiscount]  WITH CHECK ADD  CONSTRAINT [FK_ApplyingDiscount_TemplateCard] FOREIGN KEY([template_card_id])
REFERENCES [dbo].[TemplateCard] ([template_id])
GO
ALTER TABLE [dbo].[ApplyingDiscount] CHECK CONSTRAINT [FK_ApplyingDiscount_TemplateCard]
GO
ALTER TABLE [dbo].[Card]  WITH CHECK ADD  CONSTRAINT [FK_Card_TemplateCard] FOREIGN KEY([template_id])
REFERENCES [dbo].[TemplateCard] ([template_id])
GO
ALTER TABLE [dbo].[Card] CHECK CONSTRAINT [FK_Card_TemplateCard]
GO
ALTER TABLE [dbo].[CardBox]  WITH CHECK ADD  CONSTRAINT [FK_CardBox_Card] FOREIGN KEY([card_id])
REFERENCES [dbo].[Card] ([card_id])
GO
ALTER TABLE [dbo].[CardBox] CHECK CONSTRAINT [FK_CardBox_Card]
GO
ALTER TABLE [dbo].[CardBox]  WITH CHECK ADD  CONSTRAINT [FK_CardBox_User] FOREIGN KEY([user_id])
REFERENCES [dbo].[User] ([user_id])
GO
ALTER TABLE [dbo].[CardBox] CHECK CONSTRAINT [FK_CardBox_User]
GO
ALTER TABLE [dbo].[Payment]  WITH CHECK ADD  CONSTRAINT [FK_Payment_User] FOREIGN KEY([user_id])
REFERENCES [dbo].[User] ([user_id])
GO
ALTER TABLE [dbo].[Payment] CHECK CONSTRAINT [FK_Payment_User]
GO
ALTER TABLE [dbo].[Receipt]  WITH CHECK ADD  CONSTRAINT [FK_Receipt_User] FOREIGN KEY([user_id])
REFERENCES [dbo].[User] ([user_id])
GO
ALTER TABLE [dbo].[Receipt] CHECK CONSTRAINT [FK_Receipt_User]
GO
ALTER TABLE [dbo].[TemplateCard]  WITH CHECK ADD  CONSTRAINT [FK_TemplateCard_CardType] FOREIGN KEY([type_id])
REFERENCES [dbo].[CardType] ([type_id])
GO
ALTER TABLE [dbo].[TemplateCard] CHECK CONSTRAINT [FK_TemplateCard_CardType]
GO
ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK_User_Role] FOREIGN KEY([role_id])
REFERENCES [dbo].[Role] ([role_id])
GO
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_User_Role]
GO
USE [master]
GO
ALTER DATABASE [CMC] SET  READ_WRITE 
GO
