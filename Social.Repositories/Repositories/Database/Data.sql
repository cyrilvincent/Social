USE [Social]
GO
SET IDENTITY_INSERT [dbo].[EntityMetadata] ON 

GO
INSERT [dbo].[EntityMetadata] ([Id], [Pseudo], [ShortName], [LongName], [Mail], [Pwd], [DateTime], [FName], [LName], [MName], [Description], [Text], [Address1], [Address2], [Address3], [ZipCode], [City], [State], [Country], [Phone1], [Phone2], [Internet], [Ip]) VALUES (-1, N'Anonymous', NULL, NULL, NULL, NULL, CAST(0x0000A31B00000000 AS DateTime), NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL,NULL)
GO
INSERT [dbo].[EntityMetadata] ([Id], [Pseudo], [ShortName], [LongName], [Mail], [Pwd], [DateTime], [FName], [LName], [MName], [Description], [Text], [Address1], [Address2], [Address3], [ZipCode], [City], [State], [Country], [Phone1], [Phone2], [Internet], [Ip]) VALUES (2, N'Cyril', NULL, NULL, N'contact@cyrilvincent.com', N'toto', CAST(0x0000A31B00000000 AS DateTime), N'Cyril', N'Vincent', NULL, NULL, NULL, N'3 allée de champagne', NULL, NULL, N'38130', N'Echirolles', NULL, N'France', N'0622538762', NULL, N'www.cyrilvincent.com', N'192.168.1.0')
GO
INSERT [dbo].[EntityMetadata] ([Id], [Pseudo], [ShortName], [LongName], [Mail], [Pwd], [DateTime], [FName], [LName], [MName], [Description], [Text], [Address1], [Address2], [Address3], [ZipCode], [City], [State], [Country], [Phone1], [Phone2], [Internet], [Ip]) VALUES (3, NULL, N'CVC', N'Cyril Vincent Conseil', N'contact@cyrilvincent.com', NULL, CAST(0x0000A31B00000000 AS DateTime), NULL, NULL, NULL, N'Cyril Vincent Conseil', NULL, N'', NULL, NULL, NULL, NULL, NULL, N'France', N'0622538762', NULL, N'www.cyrilvincent.com', N'192.168.1.0')
GO
INSERT [dbo].[EntityMetadata] ([Id], [Pseudo], [ShortName], [LongName], [Mail], [Pwd], [DateTime], [FName], [LName], [MName], [Description], [Text], [Address1], [Address2], [Address3], [ZipCode], [City], [State], [Country], [Phone1], [Phone2], [Internet], [Ip]) VALUES (4, NULL, N'Médecin', NULL, NULL, NULL, CAST(0x0000A31B00000000 AS DateTime), NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'France', NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[EntityMetadata] ([Id], [Pseudo], [ShortName], [LongName], [Mail], [Pwd], [DateTime], [FName], [LName], [MName], [Description], [Text], [Address1], [Address2], [Address3], [ZipCode], [City], [State], [Country], [Phone1], [Phone2], [Internet], [Ip]) VALUES (6, NULL, N'Généraliste', NULL, NULL, NULL, CAST(0x0000A31B00000000 AS DateTime), NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[EntityMetadata] ([Id], [Pseudo], [ShortName], [LongName], [Mail], [Pwd], [DateTime], [FName], [LName], [MName], [Description], [Text], [Address1], [Address2], [Address3], [ZipCode], [City], [State], [Country], [Phone1], [Phone2], [Internet], [Ip]) VALUES (7, N'John Doe', NULL, NULL, NULL, NULL, CAST(0x0000A31B00000000 AS DateTime), N'Jean', N'Doe', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
SET IDENTITY_INSERT [dbo].[EntityMetadata] OFF
GO
INSERT [dbo].[Visibility] ([Id], [Name]) VALUES (1, N'public')
GO
INSERT [dbo].[Visibility] ([Id], [Name]) VALUES (2, N'link')
GO
INSERT [dbo].[Visibility] ([Id], [Name]) VALUES (3, N'protected')
GO
INSERT [dbo].[Visibility] ([Id], [Name]) VALUES (4, N'private')
GO
INSERT [dbo].[Visibility] ([Id], [Name]) VALUES (5, N'special')
GO
INSERT [dbo].[EntityType] ([Id], [Name]) VALUES (1, N'guest')
GO
INSERT [dbo].[EntityType] ([Id], [Name]) VALUES (2, N'user')
GO
INSERT [dbo].[EntityType] ([Id], [Name]) VALUES (3, N'admin')
GO
INSERT [dbo].[EntityType] ([Id], [Name]) VALUES (4, N'root')
GO
INSERT [dbo].[EntityType] ([Id], [Name]) VALUES (5, N'enterprise')
GO
INSERT [dbo].[EntityType] ([Id], [Name]) VALUES (6, N'bannished')
GO
INSERT [dbo].[EntityType] ([Id], [Name]) VALUES (10, N'page')
GO
INSERT [dbo].[EntityType] ([Id], [Name]) VALUES (11, N'ad')
GO
INSERT [dbo].[EntityType] ([Id], [Name]) VALUES (12, N'event')
GO
INSERT [dbo].[EntityType] ([Id], [Name]) VALUES (13, N'centreofinterest')
GO
INSERT [dbo].[EntityType] ([Id], [Name]) VALUES (101, N'procategory')
GO
INSERT [dbo].[EntityType] ([Id], [Name]) VALUES (102, N'profession')
GO
SET IDENTITY_INSERT [dbo].[Entity] ON 

GO
INSERT [dbo].[Entity] ([Id], [MetaDataId], [Name], [Bannished], [TypeId], [VisibilityId]) VALUES (-1, -1, N'Anonymous', 0, 4, 1)
GO
INSERT [dbo].[Entity] ([Id], [MetaDataId], [Name], [Bannished], [TypeId], [VisibilityId]) VALUES (-2, 2, N'Admin', 0, 3, 1)
GO
INSERT [dbo].[Entity] ([Id], [MetaDataId], [Name], [Bannished], [TypeId], [VisibilityId]) VALUES (1, 2, N'Cyril', 0, 4, 1)
GO
INSERT [dbo].[Entity] ([Id], [MetaDataId], [Name], [Bannished], [TypeId], [VisibilityId]) VALUES (2, 3, N'CVC', 0, 5, 1)
GO
INSERT [dbo].[Entity] ([Id], [MetaDataId], [Name], [Bannished], [TypeId], [VisibilityId]) VALUES (3, 4, N'Médecin', 0, 101, 1)
GO
INSERT [dbo].[Entity] ([Id], [MetaDataId], [Name], [Bannished], [TypeId], [VisibilityId]) VALUES (4, 6, N'Généraliste', 0, 102, 1)
GO
INSERT [dbo].[Entity] ([Id], [MetaDataId], [Name], [Bannished], [TypeId], [VisibilityId]) VALUES (5, 7, N'Docteur Jean Doe', 0, 2, 1)
GO
SET IDENTITY_INSERT [dbo].[Entity] OFF
GO
INSERT [dbo].[MessageType] ([Id], [Name]) VALUES (1, N'Message')
GO
INSERT [dbo].[MessageType] ([Id], [Name]) VALUES (2, N'Comment')
GO
INSERT [dbo].[MessageType] ([Id], [Name]) VALUES (3, N'Article')
GO
INSERT [dbo].[MessageType] ([Id], [Name]) VALUES (4, N'LinkMessage')
GO
SET IDENTITY_INSERT [dbo].[Message] ON 

GO
INSERT [dbo].[Message] ([Id], [EntityIdFrom], [EntityIdTo], [TypeId], [DateTime], [VisibilityId], [Tags], [Text], [Title], [MessageId], [LongText]) VALUES (1, 1, 1, 1, CAST(0x0000A31E00000000 AS DateTime), 1, N'First', N'First Message', NULL, NULL, NULL)
GO
SET IDENTITY_INSERT [dbo].[Message] OFF
GO
INSERT [dbo].[Like] ([EntityId], [MessageId], [DateTime]) VALUES (1, 1, CAST(0x0000A31F00000000 AS DateTime))
GO
INSERT [dbo].[LinkType] ([Id], [Name]) VALUES (1, N'friend')
GO
INSERT [dbo].[LinkType] ([Id], [Name]) VALUES (2, N'creator')
GO
INSERT [dbo].[LinkType] ([Id], [Name]) VALUES (3, N'admin')
GO
INSERT [dbo].[LinkType] ([Id], [Name]) VALUES (4, N'contributor')
GO
INSERT [dbo].[LinkType] ([Id], [Name]) VALUES (10, N'demand')
GO
INSERT [dbo].[LinkType] ([Id], [Name]) VALUES (11, N'confirmed')
GO
INSERT [dbo].[LinkType] ([Id], [Name]) VALUES (12, N'refused')
GO
INSERT [dbo].[LinkType] ([Id], [Name]) VALUES (20, N'like')
GO
INSERT [dbo].[LinkType] ([Id], [Name]) VALUES (30, N'banish')
GO
INSERT [dbo].[LinkType] ([Id], [Name]) VALUES (31, N'allowtoread')
GO
INSERT [dbo].[LinkType] ([Id], [Name]) VALUES (32, N'allowtocomment')
GO
INSERT [dbo].[LinkType] ([Id], [Name]) VALUES (33, N'allowtoupdate')
GO
INSERT [dbo].[LinkType] ([Id], [Name]) VALUES (34, N'allowtocreate')
GO
INSERT [dbo].[LinkType] ([Id], [Name]) VALUES (35, N'allowtoadmin')
GO
INSERT [dbo].[LinkType] ([Id], [Name]) VALUES (101, N'profession')
GO
INSERT [dbo].[LinkType] ([Id], [Name]) VALUES (102, N'procategory')
GO
INSERT [dbo].[Link] ([EntityIdFrom], [EntityIdTo], [TypeId], [Status], [DateTime], [MessageId]) VALUES (1, 2, 2, 11, CAST(0x0000A31B00000000 AS DateTime), NULL)
GO
INSERT [dbo].[Link] ([EntityIdFrom], [EntityIdTo], [TypeId], [Status], [DateTime], [MessageId]) VALUES (1, 2, 20, 11, CAST(0x0000A31B00000000 AS DateTime), NULL)
GO
INSERT [dbo].[Link] ([EntityIdFrom], [EntityIdTo], [TypeId], [Status], [DateTime], [MessageId]) VALUES (4, 3, 101, 11, CAST(0x0000A31B00000000 AS DateTime), NULL)
GO
INSERT [dbo].[Link] ([EntityIdFrom], [EntityIdTo], [TypeId], [Status], [DateTime], [MessageId]) VALUES (5, 4, 102, 11, CAST(0x0000A31B00000000 AS DateTime), NULL)
GO
