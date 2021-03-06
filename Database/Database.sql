USE [DS]
GO
/****** Object:  Table [dbo].[User]    Script Date: 11/10/2015 11:34:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[User](
	[Id] [uniqueidentifier] NOT NULL,
	[FirstName] [varchar](128) NOT NULL,
	[LastName] [varchar](128) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Place]    Script Date: 11/10/2015 11:34:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Place](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [varchar](128) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Meeting]    Script Date: 11/10/2015 11:34:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Meeting](
	[Id] [uniqueidentifier] NOT NULL,
	[PlaceId] [uniqueidentifier] NOT NULL,
	[OwnerId] [uniqueidentifier] NOT NULL,
	[Title] [varchar](256) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[MeetingParticipants]    Script Date: 11/10/2015 11:34:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MeetingParticipants](
	[MeetingId] [uniqueidentifier] NOT NULL,
	[UserId] [uniqueidentifier] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[MeetingId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Check [CK_Place_Name]    Script Date: 11/10/2015 11:34:46 ******/
ALTER TABLE [dbo].[Place]  WITH CHECK ADD  CONSTRAINT [CK_Place_Name] CHECK  (((1)=(1)))
GO
ALTER TABLE [dbo].[Place] CHECK CONSTRAINT [CK_Place_Name]
GO
/****** Object:  ForeignKey [FK_Meeting_ToPlace]    Script Date: 11/10/2015 11:34:46 ******/
ALTER TABLE [dbo].[Meeting]  WITH CHECK ADD  CONSTRAINT [FK_Meeting_ToPlace] FOREIGN KEY([PlaceId])
REFERENCES [dbo].[Place] ([Id])
GO
ALTER TABLE [dbo].[Meeting] CHECK CONSTRAINT [FK_Meeting_ToPlace]
GO
/****** Object:  ForeignKey [FK_Meeting_ToUser]    Script Date: 11/10/2015 11:34:46 ******/
ALTER TABLE [dbo].[Meeting]  WITH CHECK ADD  CONSTRAINT [FK_Meeting_ToUser] FOREIGN KEY([OwnerId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[Meeting] CHECK CONSTRAINT [FK_Meeting_ToUser]
GO
/****** Object:  ForeignKey [FK_MeetingParticipants_ToMeetings]    Script Date: 11/10/2015 11:34:46 ******/
ALTER TABLE [dbo].[MeetingParticipants]  WITH CHECK ADD  CONSTRAINT [FK_MeetingParticipants_ToMeetings] FOREIGN KEY([MeetingId])
REFERENCES [dbo].[Meeting] ([Id])
GO
ALTER TABLE [dbo].[MeetingParticipants] CHECK CONSTRAINT [FK_MeetingParticipants_ToMeetings]
GO
/****** Object:  ForeignKey [FK_MeetingParticipants_ToUsers]    Script Date: 11/10/2015 11:34:46 ******/
ALTER TABLE [dbo].[MeetingParticipants]  WITH CHECK ADD  CONSTRAINT [FK_MeetingParticipants_ToUsers] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[MeetingParticipants] CHECK CONSTRAINT [FK_MeetingParticipants_ToUsers]
GO
