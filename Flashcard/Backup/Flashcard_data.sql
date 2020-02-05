DELETE FROM [dbo].[LanguageTypes];

SET IDENTITY_INSERT [dbo].[LanguageTypes] ON

INSERT INTO [dbo].[LanguageTypes] ([Id],[Name],[Tag]) VALUES (1, 'Polish', 'PL');
INSERT INTO [dbo].[LanguageTypes] ([Id],[Name],[Tag]) VALUES (2, 'English', 'EN');

SET IDENTITY_INSERT [dbo].[LanguageTypes] OFF