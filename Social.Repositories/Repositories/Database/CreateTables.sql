/****** Object:  Table [dbo].[Entity]    Script Date: 02/05/2014 22:09:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Entity](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MetaDataId] [int] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Bannished] [bit] NOT NULL,
	[TypeId] [int] NOT NULL,
	[VisibilityId] [int] NOT NULL,
 CONSTRAINT [PK_Entity] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[EntityMetadata]    Script Date: 02/05/2014 22:09:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[EntityMetadata](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Pseudo] [nvarchar](50) NULL,
	[ShortName] [nvarchar](50) NULL,
	[LongName] [nvarchar](255) NULL,
	[Mail] [nvarchar](100) NULL,
	[Pwd] [nvarchar](255) NULL,
	[DateTime] [datetime] NOT NULL,
	[FName] [nvarchar](50) NULL,
	[LName] [nvarchar](100) NULL,
	[MName] [nvarchar](50) NULL,
	[Description] [nvarchar](255) NULL,
	[Text] [nvarchar](max) NULL,
	[Address1] [nvarchar](50) NULL,
	[Address2] [nvarchar](50) NULL,
	[Address3] [nvarchar](50) NULL,
	[ZipCode] [nvarchar](50) NULL,
	[City] [nvarchar](100) NULL,
	[State] [nvarchar](50) NULL,
	[Country] [nvarchar](50) NULL,
	[Phone1] [nvarchar](20) NULL,
	[Phone2] [nvarchar](20) NULL,
	[Internet] [nvarchar](100) NULL,
	[Ip] [char](11) NULL,
 CONSTRAINT [PK_EntityMetadata] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[EntityType]    Script Date: 02/05/2014 22:09:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EntityType](
	[Id] [int] NOT NULL,
	[Name] [nvarchar](20) NULL,
 CONSTRAINT [PK_EntityType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Like]    Script Date: 02/05/2014 22:09:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Like](
	[EntityId] [int] NOT NULL,
	[MessageId] [int] NOT NULL,
	[DateTime] [datetime] NOT NULL,
 CONSTRAINT [PK_Like] PRIMARY KEY CLUSTERED 
(
	[EntityId] ASC,
	[MessageId] DESC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Link]    Script Date: 02/05/2014 22:09:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Link](
	[EntityIdFrom] [int] NOT NULL,
	[EntityIdTo] [int] NOT NULL,
	[TypeId] [int] NOT NULL,
	[Status] [int] NOT NULL,
	[DateTime] [datetime] NOT NULL,
	[MessageId] [int] NULL,
 CONSTRAINT [PK_Link] PRIMARY KEY CLUSTERED 
(
	[EntityIdFrom] ASC,
	[EntityIdTo] ASC,
	[TypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[LinkType]    Script Date: 02/05/2014 22:09:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LinkType](
	[Id] [int] NOT NULL,
	[Name] [nvarchar](20) NOT NULL,
 CONSTRAINT [PK_LinkType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Message]    Script Date: 02/05/2014 22:09:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Message](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[EntityIdFrom] [int] NOT NULL,
	[EntityIdTo] [int] NOT NULL,
	[TypeId] [int] NOT NULL,
	[DateTime] [datetime] NOT NULL,
	[VisibilityId] [int] NOT NULL,
	[Tags] [nvarchar](50) NULL,
	[Text] [nvarchar](4000) NOT NULL,
	[Title] [nvarchar](100) NULL,
	[MessageId] [int] NULL,
	[LongText] [nvarchar](max) NULL,
	[Description] [nvarchar](500) NULL,
	[Url] [nvarchar](255) NULL,
	[ImageUrl] [nvarchar](255) NULL,
	[VideoUrl] [nvarchar](255) NULL,
 CONSTRAINT [PK_Message] PRIMARY KEY CLUSTERED 
(
	[Id] DESC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[MessageType]    Script Date: 02/05/2014 22:09:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MessageType](
	[Id] [int] NOT NULL,
	[Name] [nvarchar](20) NULL,
 CONSTRAINT [PK_MessageType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Visibility]    Script Date: 02/05/2014 22:09:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Visibility](
	[Id] [int] NOT NULL,
	[Name] [nvarchar](10) NOT NULL,
 CONSTRAINT [PK_Visibility] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_Entity_Name]    Script Date: 02/05/2014 22:09:19 ******/
CREATE NONCLUSTERED INDEX [IX_Entity_Name] ON [dbo].[Entity]
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Entity_TypeId]    Script Date: 02/05/2014 22:09:19 ******/
CREATE NONCLUSTERED INDEX [IX_Entity_TypeId] ON [dbo].[Entity]
(
	[TypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Like_DateTime]    Script Date: 02/05/2014 22:09:19 ******/
CREATE NONCLUSTERED INDEX [IX_Like_DateTime] ON [dbo].[Like]
(
	[DateTime] DESC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Link_DateTime]    Script Date: 02/05/2014 22:09:19 ******/
CREATE NONCLUSTERED INDEX [IX_Link_DateTime] ON [dbo].[Link]
(
	[DateTime] DESC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Link_EntityTo]    Script Date: 02/05/2014 22:09:19 ******/
CREATE NONCLUSTERED INDEX [IX_Link_EntityTo] ON [dbo].[Link]
(
	[EntityIdTo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Link_EntityTo_LinkTypeId]    Script Date: 02/05/2014 22:09:19 ******/
CREATE NONCLUSTERED INDEX [IX_Link_EntityTo_LinkTypeId] ON [dbo].[Link]
(
	[EntityIdTo] ASC,
	[TypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Message_EntityIdTo]    Script Date: 02/05/2014 22:09:19 ******/
CREATE NONCLUSTERED INDEX [IX_Message_EntityIdTo] ON [dbo].[Message]
(
	[EntityIdTo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Message_EntityIdTo_TypeId_VisibilityId]    Script Date: 02/05/2014 22:09:19 ******/
CREATE NONCLUSTERED INDEX [IX_Message_EntityIdTo_TypeId_VisibilityId] ON [dbo].[Message]
(
	[EntityIdTo] ASC,
	[TypeId] ASC,
	[VisibilityId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_Message_Tags_Title]    Script Date: 02/05/2014 22:09:19 ******/
CREATE NONCLUSTERED INDEX [IX_Message_Tags_Title] ON [dbo].[Message]
(
	[Tags] ASC,
	[Title] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Entity] ADD  CONSTRAINT [DF_Entity_Bannished]  DEFAULT ((0)) FOR [Bannished]
GO
ALTER TABLE [dbo].[Entity]  WITH CHECK ADD  CONSTRAINT [FK_Entity_EntityMetadata] FOREIGN KEY([MetaDataId])
REFERENCES [dbo].[EntityMetadata] ([Id])
GO
ALTER TABLE [dbo].[Entity] CHECK CONSTRAINT [FK_Entity_EntityMetadata]
GO
ALTER TABLE [dbo].[Entity]  WITH CHECK ADD  CONSTRAINT [FK_Entity_EntityType] FOREIGN KEY([TypeId])
REFERENCES [dbo].[EntityType] ([Id])
GO
ALTER TABLE [dbo].[Entity] CHECK CONSTRAINT [FK_Entity_EntityType]
GO
ALTER TABLE [dbo].[Entity]  WITH CHECK ADD  CONSTRAINT [FK_Entity_Visibily] FOREIGN KEY([VisibilityId])
REFERENCES [dbo].[Visibility] ([Id])
GO
ALTER TABLE [dbo].[Entity] CHECK CONSTRAINT [FK_Entity_Visibily]
GO
ALTER TABLE [dbo].[Like]  WITH CHECK ADD  CONSTRAINT [FK_Like_Entity] FOREIGN KEY([EntityId])
REFERENCES [dbo].[Entity] ([Id])
GO
ALTER TABLE [dbo].[Like] CHECK CONSTRAINT [FK_Like_Entity]
GO
ALTER TABLE [dbo].[Like]  WITH CHECK ADD  CONSTRAINT [FK_Like_Message] FOREIGN KEY([MessageId])
REFERENCES [dbo].[Message] ([Id])
GO
ALTER TABLE [dbo].[Like] CHECK CONSTRAINT [FK_Like_Message]
GO
ALTER TABLE [dbo].[Link]  WITH CHECK ADD  CONSTRAINT [FK_Link_Entity] FOREIGN KEY([EntityIdTo])
REFERENCES [dbo].[Entity] ([Id])
GO
ALTER TABLE [dbo].[Link] CHECK CONSTRAINT [FK_Link_Entity]
GO
ALTER TABLE [dbo].[Link]  WITH CHECK ADD  CONSTRAINT [FK_Link_EntityFrom] FOREIGN KEY([EntityIdFrom])
REFERENCES [dbo].[Entity] ([Id])
GO
ALTER TABLE [dbo].[Link] CHECK CONSTRAINT [FK_Link_EntityFrom]
GO
ALTER TABLE [dbo].[Link]  WITH CHECK ADD  CONSTRAINT [FK_Link_LinkType] FOREIGN KEY([TypeId])
REFERENCES [dbo].[LinkType] ([Id])
GO
ALTER TABLE [dbo].[Link] CHECK CONSTRAINT [FK_Link_LinkType]
GO
ALTER TABLE [dbo].[Link]  WITH CHECK ADD  CONSTRAINT [FK_Link_LinkTypeStatus] FOREIGN KEY([Status])
REFERENCES [dbo].[LinkType] ([Id])
GO
ALTER TABLE [dbo].[Link] CHECK CONSTRAINT [FK_Link_LinkTypeStatus]
GO
ALTER TABLE [dbo].[Link]  WITH CHECK ADD  CONSTRAINT [FK_Link_Message] FOREIGN KEY([MessageId])
REFERENCES [dbo].[Message] ([Id])
GO
ALTER TABLE [dbo].[Link] CHECK CONSTRAINT [FK_Link_Message]
GO
ALTER TABLE [dbo].[Message]  WITH CHECK ADD  CONSTRAINT [FK_Message_Entity] FOREIGN KEY([EntityIdFrom])
REFERENCES [dbo].[Entity] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Message] CHECK CONSTRAINT [FK_Message_Entity]
GO
ALTER TABLE [dbo].[Message]  WITH CHECK ADD  CONSTRAINT [FK_Message_EntityTo] FOREIGN KEY([EntityIdTo])
REFERENCES [dbo].[Entity] ([Id])
GO
ALTER TABLE [dbo].[Message] CHECK CONSTRAINT [FK_Message_EntityTo]
GO
ALTER TABLE [dbo].[Message]  WITH CHECK ADD  CONSTRAINT [FK_Message_Message] FOREIGN KEY([MessageId])
REFERENCES [dbo].[Message] ([Id])
GO
ALTER TABLE [dbo].[Message] CHECK CONSTRAINT [FK_Message_Message]
GO
ALTER TABLE [dbo].[Message]  WITH CHECK ADD  CONSTRAINT [FK_Message_MessageType] FOREIGN KEY([TypeId])
REFERENCES [dbo].[MessageType] ([Id])
GO
ALTER TABLE [dbo].[Message] CHECK CONSTRAINT [FK_Message_MessageType]
GO
ALTER TABLE [dbo].[Message]  WITH CHECK ADD  CONSTRAINT [FK_Message_Visibily] FOREIGN KEY([VisibilityId])
REFERENCES [dbo].[Visibility] ([Id])
GO
ALTER TABLE [dbo].[Message] CHECK CONSTRAINT [FK_Message_Visibily]
GO