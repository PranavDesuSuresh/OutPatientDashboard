SET IDENTITY_INSERT [dbo].[Speciality] ON 
GO
INSERT [dbo].[Speciality] ([Id], [Name]) VALUES (1, N'Paediatrics')
GO
INSERT [dbo].[Speciality] ([Id], [Name]) VALUES (2, N'Oncology')
GO
INSERT [dbo].[Speciality] ([Id], [Name]) VALUES (3, N'Orthopaedics')
GO
INSERT [dbo].[Speciality] ([Id], [Name]) VALUES (4, N'Urology')
GO
INSERT [dbo].[Speciality] ([Id], [Name]) VALUES (5, N'Cardiology')
GO
INSERT [dbo].[Speciality] ([Id], [Name]) VALUES (6, N'Dentistry')
GO
INSERT [dbo].[Speciality] ([Id], [Name]) VALUES (7, N'ENT')
GO
INSERT [dbo].[Speciality] ([Id], [Name]) VALUES (8, N'General Surgery')
GO
INSERT [dbo].[Speciality] ([Id], [Name]) VALUES (9, N'Radiology')
GO
SET IDENTITY_INSERT [dbo].[Speciality] OFF
GO
SET IDENTITY_INSERT [dbo].[Physician] ON 
GO
INSERT [dbo].[Physician] ([Id], [FirstName], [LastName], [NPI], [SpecialityId]) VALUES (1, N'James', N'Smith', 672714531, 1)
GO
INSERT [dbo].[Physician] ([Id], [FirstName], [LastName], [NPI], [SpecialityId]) VALUES (2, N'Christopher', N'Anderson', 661363026, 1)
GO
INSERT [dbo].[Physician] ([Id], [FirstName], [LastName], [NPI], [SpecialityId]) VALUES (3, N'Ronald', N'Clark', 923991710, 2)
GO
INSERT [dbo].[Physician] ([Id], [FirstName], [LastName], [NPI], [SpecialityId]) VALUES (4, N'Mary', N'Wright', 520127820, 3)
GO
INSERT [dbo].[Physician] ([Id], [FirstName], [LastName], [NPI], [SpecialityId]) VALUES (5, N'Lisa', N'Mitchell', 738947770, 4)
GO
INSERT [dbo].[Physician] ([Id], [FirstName], [LastName], [NPI], [SpecialityId]) VALUES (6, N'Michelle', N'Johnson', 617316606, 4)
GO
INSERT [dbo].[Physician] ([Id], [FirstName], [LastName], [NPI], [SpecialityId]) VALUES (7, N'John', N'Thomas', 890036235, 5)
GO
INSERT [dbo].[Physician] ([Id], [FirstName], [LastName], [NPI], [SpecialityId]) VALUES (8, N'Daniel', N'Rodriguez', 586038938, 6)
GO
INSERT [dbo].[Physician] ([Id], [FirstName], [LastName], [NPI], [SpecialityId]) VALUES (9, N'Anthony', N'Lopez', 679996930, 7)
GO
INSERT [dbo].[Physician] ([Id], [FirstName], [LastName], [NPI], [SpecialityId]) VALUES (10, N'Patricia', N'Perez', 523221450, 7)
GO
INSERT [dbo].[Physician] ([Id], [FirstName], [LastName], [NPI], [SpecialityId]) VALUES (11, N'Nancy', N'Williams', 646649676, 8)
GO
INSERT [dbo].[Physician] ([Id], [FirstName], [LastName], [NPI], [SpecialityId]) VALUES (12, N'Laura', N'Jackson', 952815901, 9)
GO
INSERT [dbo].[Physician] ([Id], [FirstName], [LastName], [NPI], [SpecialityId]) VALUES (13, N'Robert', N'Lewis', 933436816, 9)
GO
SET IDENTITY_INSERT [dbo].[Physician] OFF
GO
SET IDENTITY_INSERT [dbo].[StatusType] ON 
GO
INSERT [dbo].[StatusType] ([Id], [Name]) VALUES (1, N'InCare')
GO
INSERT [dbo].[StatusType] ([Id], [Name]) VALUES (2, N'Discharged')
GO
SET IDENTITY_INSERT [dbo].[StatusType] OFF
GO
