USE [master]
GO
/****** Object:  Database [pp_zone]    Script Date: 2017/12/10 11:21:24 ******/
CREATE DATABASE [pp_zone]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'qq_room', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\qq_room.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'qq_room_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\qq_room_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [pp_zone] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [pp_zone].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [pp_zone] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [pp_zone] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [pp_zone] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [pp_zone] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [pp_zone] SET ARITHABORT OFF 
GO
ALTER DATABASE [pp_zone] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [pp_zone] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [pp_zone] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [pp_zone] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [pp_zone] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [pp_zone] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [pp_zone] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [pp_zone] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [pp_zone] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [pp_zone] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [pp_zone] SET  DISABLE_BROKER 
GO
ALTER DATABASE [pp_zone] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [pp_zone] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [pp_zone] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [pp_zone] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [pp_zone] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [pp_zone] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [pp_zone] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [pp_zone] SET RECOVERY FULL 
GO
ALTER DATABASE [pp_zone] SET  MULTI_USER 
GO
ALTER DATABASE [pp_zone] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [pp_zone] SET DB_CHAINING OFF 
GO
ALTER DATABASE [pp_zone] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [pp_zone] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
EXEC sys.sp_db_vardecimal_storage_format N'pp_zone', N'ON'
GO
USE [pp_zone]
GO
/****** Object:  Table [dbo].[album]    Script Date: 2017/12/10 11:21:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[album](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[ImagePath] [nvarchar](max) NOT NULL,
	[ImageName] [nvarchar](30) NOT NULL,
	[Time] [datetime] NOT NULL,
	[Albumid] [int] NOT NULL,
	[IsCoverOrNot] [bit] NULL,
 CONSTRAINT [PK_albumfile] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[albumlist]    Script Date: 2017/12/10 11:21:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[albumlist](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[AccountName] [nvarchar](50) NOT NULL,
	[AlbumName] [nvarchar](20) NOT NULL,
	[CoverPath] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_albumlist] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[applyfriends]    Script Date: 2017/12/10 11:21:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[applyfriends](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[AccountName] [nvarchar](50) NOT NULL,
	[ApplyFriend] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_applyfriends] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[comments]    Script Date: 2017/12/10 11:21:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[comments](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Comment] [varchar](max) NOT NULL,
	[CommentUser] [varchar](50) NOT NULL,
	[Pageid] [int] NOT NULL,
	[Time] [datetime] NOT NULL,
 CONSTRAINT [PK_comments_1] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[diary]    Script Date: 2017/12/10 11:21:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[diary](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[AccountName] [nvarchar](50) NOT NULL,
	[DiaryTitle] [nvarchar](20) NOT NULL,
	[Diary] [varchar](max) NOT NULL,
	[Time] [datetime] NOT NULL,
 CONSTRAINT [PK_diary] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[diarycomment]    Script Date: 2017/12/10 11:21:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[diarycomment](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Diaryid] [int] NOT NULL,
	[Comment] [nvarchar](max) NOT NULL,
	[CommentUser] [nvarchar](50) NOT NULL,
	[Time] [datetime] NOT NULL,
 CONSTRAINT [PK_diarycomment] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[friends]    Script Date: 2017/12/10 11:21:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[friends](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[AccountName] [nvarchar](50) NOT NULL,
	[Friend] [nvarchar](50) NOT NULL,
	[Remark] [nvarchar](50) NULL,
 CONSTRAINT [PK_friends] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[message]    Script Date: 2017/12/10 11:21:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[message](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[AccountName] [nvarchar](50) NOT NULL,
	[Message] [varchar](max) NOT NULL,
	[MessageUser] [nvarchar](50) NOT NULL,
	[Time] [datetime] NOT NULL,
 CONSTRAINT [PK_message] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[messagecomment]    Script Date: 2017/12/10 11:21:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[messagecomment](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[MessageComment] [nvarchar](max) NOT NULL,
	[MessageCommentUser] [nvarchar](50) NOT NULL,
	[Messageid] [int] NOT NULL,
	[Time] [datetime] NULL,
 CONSTRAINT [PK_messagecomment] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[passages]    Script Date: 2017/12/10 11:21:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[passages](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[AccountName] [nvarchar](50) NOT NULL,
	[Passage] [nvarchar](max) NOT NULL,
	[Title] [nvarchar](50) NOT NULL,
	[Time] [datetime] NOT NULL,
 CONSTRAINT [PK_passage] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[users]    Script Date: 2017/12/10 11:21:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[users](
	[AccountName] [nvarchar](50) NOT NULL,
	[AccountPwd] [nvarchar](50) NOT NULL,
	[UserNickName] [nvarchar](30) NOT NULL,
	[Question] [nvarchar](100) NOT NULL,
	[Answer] [nvarchar](100) NOT NULL,
	[Age] [nvarchar](3) NULL,
	[Sex] [nvarchar](1) NULL,
	[BornYear] [nvarchar](4) NULL,
	[BornMonth] [nvarchar](2) NULL,
	[BornDay] [nvarchar](2) NULL,
	[Profession] [nvarchar](50) NULL,
	[ProfileImage] [nvarchar](max) NULL,
 CONSTRAINT [PK_users_1] PRIMARY KEY CLUSTERED 
(
	[AccountName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[album] ON 

INSERT [dbo].[album] ([id], [ImagePath], [ImageName], [Time], [Albumid], [IsCoverOrNot]) VALUES (1, N'\album\201712040718228091234.jpg', N'可是这和我帅有什么关系呢', CAST(0x0000A82900B8A970 AS DateTime), 1, NULL)
INSERT [dbo].[album] ([id], [ImagePath], [ImageName], [Time], [Albumid], [IsCoverOrNot]) VALUES (5, N'\album\20171204100726248abc.jpg', N'喂喂喂', CAST(0x0000A82700A83DEC AS DateTime), 2, NULL)
INSERT [dbo].[album] ([id], [ImagePath], [ImageName], [Time], [Albumid], [IsCoverOrNot]) VALUES (10, N'\album\20171207163710223abc.jpg', N'', CAST(0x0000A8420111E148 AS DateTime), 2, NULL)
INSERT [dbo].[album] ([id], [ImagePath], [ImageName], [Time], [Albumid], [IsCoverOrNot]) VALUES (11, N'\album\20171209211650643abc.png', N'向大佬低头', CAST(0x0000A844015EB158 AS DateTime), 2, NULL)
INSERT [dbo].[album] ([id], [ImagePath], [ImageName], [Time], [Albumid], [IsCoverOrNot]) VALUES (12, N'\album\20171209211704440abc.png', N'向大佬低头', CAST(0x0000A844015EC1C0 AS DateTime), 6, NULL)
INSERT [dbo].[album] ([id], [ImagePath], [ImageName], [Time], [Albumid], [IsCoverOrNot]) VALUES (13, N'\album\20171209211741964abc.png', N'不知道是什么的图片', CAST(0x0000A844015EED1C AS DateTime), 6, NULL)
INSERT [dbo].[album] ([id], [ImagePath], [ImageName], [Time], [Albumid], [IsCoverOrNot]) VALUES (14, N'\album\201712101022463211234.jpg', N'函数图像', CAST(0x0000A84500AB0C48 AS DateTime), 1, NULL)
INSERT [dbo].[album] ([id], [ImagePath], [ImageName], [Time], [Albumid], [IsCoverOrNot]) VALUES (15, N'\album\201712101053116461234.jpg', N'', CAST(0x0000A84500B366F4 AS DateTime), 1, NULL)
SET IDENTITY_INSERT [dbo].[album] OFF
SET IDENTITY_INSERT [dbo].[albumlist] ON 

INSERT [dbo].[albumlist] ([id], [AccountName], [AlbumName], [CoverPath]) VALUES (1, N'1234', N'first', N'/album/Cover.jpg')
INSERT [dbo].[albumlist] ([id], [AccountName], [AlbumName], [CoverPath]) VALUES (2, N'abc', N'second', N'\album\20171204100726248abc.jpg')
INSERT [dbo].[albumlist] ([id], [AccountName], [AlbumName], [CoverPath]) VALUES (6, N'abc', N'测试相册', N'album/Cover.jpg')
SET IDENTITY_INSERT [dbo].[albumlist] OFF
SET IDENTITY_INSERT [dbo].[applyfriends] ON 

INSERT [dbo].[applyfriends] ([id], [AccountName], [ApplyFriend]) VALUES (3, N'123', N'123')
INSERT [dbo].[applyfriends] ([id], [AccountName], [ApplyFriend]) VALUES (4, N'123', N'1234')
SET IDENTITY_INSERT [dbo].[applyfriends] OFF
SET IDENTITY_INSERT [dbo].[comments] ON 

INSERT [dbo].[comments] ([id], [Comment], [CommentUser], [Pageid], [Time]) VALUES (1, N'2333', N'1234', 1, CAST(0x0000A83100A84170 AS DateTime))
INSERT [dbo].[comments] ([id], [Comment], [CommentUser], [Pageid], [Time]) VALUES (4, N'<p>233333<br/></p>', N'1234', 1, CAST(0x0000A83100A91460 AS DateTime))
INSERT [dbo].[comments] ([id], [Comment], [CommentUser], [Pageid], [Time]) VALUES (5, N'<p>66666<br/></p>', N'1234', 1, CAST(0x0000A83100A95AB0 AS DateTime))
INSERT [dbo].[comments] ([id], [Comment], [CommentUser], [Pageid], [Time]) VALUES (6, N'<p>66666666<br/></p>', N'1234', 5, CAST(0x0000A83100A84170 AS DateTime))
INSERT [dbo].[comments] ([id], [Comment], [CommentUser], [Pageid], [Time]) VALUES (8, N'<p>6666<br/></p>', N'1234', 1, CAST(0x0000A83100A857B4 AS DateTime))
INSERT [dbo].[comments] ([id], [Comment], [CommentUser], [Pageid], [Time]) VALUES (9, N'<p>666<br/></p>', N'1234', 1, CAST(0x0000A83400A84170 AS DateTime))
INSERT [dbo].[comments] ([id], [Comment], [CommentUser], [Pageid], [Time]) VALUES (10, N'<p>666<br/></p>', N'1234', 1, CAST(0x0000A83100A850AC AS DateTime))
INSERT [dbo].[comments] ([id], [Comment], [CommentUser], [Pageid], [Time]) VALUES (11, N'<p>在此处书写美好，记得要加上标题哦</p>', N'', 1, CAST(0x0000A83D00A84170 AS DateTime))
INSERT [dbo].[comments] ([id], [Comment], [CommentUser], [Pageid], [Time]) VALUES (12, N'<p>在此处书写美好，记得要加上标题哦</p>', N'1234', 1, CAST(0x0000A83D017E7D30 AS DateTime))
INSERT [dbo].[comments] ([id], [Comment], [CommentUser], [Pageid], [Time]) VALUES (15, N'<p>6666<br/></p>', N'1234', 7, CAST(0x0000A83D014D0CF0 AS DateTime))
INSERT [dbo].[comments] ([id], [Comment], [CommentUser], [Pageid], [Time]) VALUES (16, N'<p>你怕不是傻哦</p>', N'1234', 5, CAST(0x0000A83D013E7E60 AS DateTime))
INSERT [dbo].[comments] ([id], [Comment], [CommentUser], [Pageid], [Time]) VALUES (20, N'<p>不懂了吧黑暗之神<br/></p>', N'abc', 8, CAST(0x0000A841009D209C AS DateTime))
INSERT [dbo].[comments] ([id], [Comment], [CommentUser], [Pageid], [Time]) VALUES (23, N'<p>我是郭凯璐<br/></p>', N'1234', 1, CAST(0x0000A84100B380BC AS DateTime))
INSERT [dbo].[comments] ([id], [Comment], [CommentUser], [Pageid], [Time]) VALUES (24, N'<p>傻支书</p><p><br/></p>', N'1234', 7, CAST(0x0000A842010FFE78 AS DateTime))
INSERT [dbo].[comments] ([id], [Comment], [CommentUser], [Pageid], [Time]) VALUES (25, N'<p>傻支书而我也土切割撒豆成兵是的是混分巨兽都发个北京户口</p>', N'abc', 1, CAST(0x0000A84201117320 AS DateTime))
SET IDENTITY_INSERT [dbo].[comments] OFF
SET IDENTITY_INSERT [dbo].[diary] ON 

INSERT [dbo].[diary] ([id], [AccountName], [DiaryTitle], [Diary], [Time]) VALUES (1, N'1234', N'first diary         ', N'hahahahha Hello world', CAST(0x0000A82C00B81370 AS DateTime))
INSERT [dbo].[diary] ([id], [AccountName], [DiaryTitle], [Diary], [Time]) VALUES (4, N'1234', N'试试                  ', N'<p>试试水<br/></p>', CAST(0x0000A82A00B8A13C AS DateTime))
INSERT [dbo].[diary] ([id], [AccountName], [DiaryTitle], [Diary], [Time]) VALUES (5, N'1234', N'心态大崩                ', N'<p>心态崩裂了，好难受<br/></p>', CAST(0x0000A82E00B8A13C AS DateTime))
INSERT [dbo].[diary] ([id], [AccountName], [DiaryTitle], [Diary], [Time]) VALUES (6, N'abc', N'古娜拉黑暗之神', N'<p style="text-align: center;">黑魔变身！！<br/></p>', CAST(0x0000A82A00BBA6AC AS DateTime))
INSERT [dbo].[diary] ([id], [AccountName], [DiaryTitle], [Diary], [Time]) VALUES (7, N'1234', N'突然好不想写代码', N'<p>2017.12.5 突然好不想写代码，好像休息啊，烦烦烦<br/></p>', CAST(0x0000A83A00BBA6AC AS DateTime))
SET IDENTITY_INSERT [dbo].[diary] OFF
SET IDENTITY_INSERT [dbo].[diarycomment] ON 

INSERT [dbo].[diarycomment] ([id], [Diaryid], [Comment], [CommentUser], [Time]) VALUES (2, 7, N'<p>别这样，打起精神来，加油！加油！加油！<br/></p>', N'1234', CAST(0x0000A841016570B0 AS DateTime))
INSERT [dbo].[diarycomment] ([id], [Diaryid], [Comment], [CommentUser], [Time]) VALUES (3, 7, N'<p>呼啦啦啦啦啦</p>', N'1234', CAST(0x0000A84200F9D698 AS DateTime))
INSERT [dbo].[diarycomment] ([id], [Diaryid], [Comment], [CommentUser], [Time]) VALUES (4, 6, N'<p>你在傻什么</p>', N'1234', CAST(0x0000A84200FC28BC AS DateTime))
INSERT [dbo].[diarycomment] ([id], [Diaryid], [Comment], [CommentUser], [Time]) VALUES (1002, 1, N'<p>emmm，继续修bug</p>', N'1234', CAST(0x0000A84400A38108 AS DateTime))
INSERT [dbo].[diarycomment] ([id], [Diaryid], [Comment], [CommentUser], [Time]) VALUES (1003, 6, N'<p><img src="/ueditor/dialogs/emotion/images/tsj/t_0015.gif"/>这是啥</p>', N'1234', CAST(0x0000A84500ACC740 AS DateTime))
SET IDENTITY_INSERT [dbo].[diarycomment] OFF
SET IDENTITY_INSERT [dbo].[friends] ON 

INSERT [dbo].[friends] ([id], [AccountName], [Friend], [Remark]) VALUES (18, N'1234', N'abc', N'古娜拉黑暗之神')
INSERT [dbo].[friends] ([id], [AccountName], [Friend], [Remark]) VALUES (19, N'abc', N'1234', N'发放的合法的')
SET IDENTITY_INSERT [dbo].[friends] OFF
SET IDENTITY_INSERT [dbo].[message] ON 

INSERT [dbo].[message] ([id], [AccountName], [Message], [MessageUser], [Time]) VALUES (2, N'1234', N'hhh', N'1234', CAST(0x0000A8310061AB20 AS DateTime))
INSERT [dbo].[message] ([id], [AccountName], [Message], [MessageUser], [Time]) VALUES (3, N'1234', N'嘿嘿', N'1234', CAST(0x0000A83401745F58 AS DateTime))
INSERT [dbo].[message] ([id], [AccountName], [Message], [MessageUser], [Time]) VALUES (4, N'1234', N'<p>不错啊小伙子<br/></p>', N'1234', CAST(0x0000A83601745F58 AS DateTime))
INSERT [dbo].[message] ([id], [AccountName], [Message], [MessageUser], [Time]) VALUES (6, N'1234', N'<p><img src="/ueditor/dialogs/emotion/images/tsj/t_0002.gif"/>我来看你了</p>', N'abc', CAST(0x0000A84500AB9438 AS DateTime))
INSERT [dbo].[message] ([id], [AccountName], [Message], [MessageUser], [Time]) VALUES (7, N'abc', N'<p><img src="/ueditor/dialogs/emotion/images/jx2/j_0003.gif"/>闪亮登场</p>', N'1234', CAST(0x0000A84500AC04B8 AS DateTime))
SET IDENTITY_INSERT [dbo].[message] OFF
SET IDENTITY_INSERT [dbo].[messagecomment] ON 

INSERT [dbo].[messagecomment] ([id], [MessageComment], [MessageCommentUser], [Messageid], [Time]) VALUES (3, N'<p>哈哈哈哈</p>', N'1234', 2, CAST(0x0000A83D01745F58 AS DateTime))
INSERT [dbo].[messagecomment] ([id], [MessageComment], [MessageCommentUser], [Messageid], [Time]) VALUES (4, N'<p>我是张鸿儒</p>', N'1234', 3, CAST(0x0000A83F01745F58 AS DateTime))
INSERT [dbo].[messagecomment] ([id], [MessageComment], [MessageCommentUser], [Messageid], [Time]) VALUES (5, N'<p><img src="/ueditor/dialogs/emotion/images/jx2/j_0002.gif"/>厉害不</p>', N'abc', 7, CAST(0x0000A84500AC1070 AS DateTime))
INSERT [dbo].[messagecomment] ([id], [MessageComment], [MessageCommentUser], [Messageid], [Time]) VALUES (6, N'<p><img src="/ueditor/dialogs/emotion/images/tsj/t_0039.gif"/>放我出去</p>', N'1234', 7, CAST(0x0000A84500AC9158 AS DateTime))
SET IDENTITY_INSERT [dbo].[messagecomment] OFF
SET IDENTITY_INSERT [dbo].[passages] ON 

INSERT [dbo].[passages] ([id], [AccountName], [Passage], [Title], [Time]) VALUES (1, N'1234', N'hello world', N'first page', CAST(0x0000A82700A7DCA8 AS DateTime))
INSERT [dbo].[passages] ([id], [AccountName], [Passage], [Title], [Time]) VALUES (5, N'1234', N'<p>今天被陈志垠打了一顿，感觉很难受，想搞死他</p>', N'2017.12.4', CAST(0x0000A82700A7DDD4 AS DateTime))
INSERT [dbo].[passages] ([id], [AccountName], [Passage], [Title], [Time]) VALUES (7, N'1234', N'<p>今天和坚铭大佬一起写代码<br/></p>', N'2017.24.4', CAST(0x0000A82700A7DF00 AS DateTime))
INSERT [dbo].[passages] ([id], [AccountName], [Passage], [Title], [Time]) VALUES (8, N'abc', N'<p>什么鬼系统</p>', N'第一篇文章', CAST(0x0000A82700A7DF00 AS DateTime))
INSERT [dbo].[passages] ([id], [AccountName], [Passage], [Title], [Time]) VALUES (9, N'abc', N'<p><img src="/ueditor/dialogs/emotion/images/jx2/j_0067.gif"/></p>', N'123', CAST(0x0000A84400F4C2FC AS DateTime))
INSERT [dbo].[passages] ([id], [AccountName], [Passage], [Title], [Time]) VALUES (10, N'abc', N'<p><span style="font-family: 楷体,楷体_GB2312,SimKai; font-size: 24px;">test</span><span style="font-family: impact,chicago;"></span></p>', N'test', CAST(0x0000A84400F5BB6C AS DateTime))
INSERT [dbo].[passages] ([id], [AccountName], [Passage], [Title], [Time]) VALUES (11, N'abc', N'<ul class=" list-paddingleft-2" style="list-style-type: square;"><li><p>在此处书写美好，记得要加上标题哦<img src="/ueditor/dialogs/emotion/images/jx2/j_0003.gif"/></p></li></ul>', N'兔斯基！！', CAST(0x0000A84400F763A4 AS DateTime))
INSERT [dbo].[passages] ([id], [AccountName], [Passage], [Title], [Time]) VALUES (12, N'abc', N'<p><span style="color: rgb(247, 150, 70); background-color: rgb(255, 255, 255);">asdfsadf<span style="color: rgb(247, 150, 70); text-decoration: line-through; background-color: rgb(255, 255, 255);">asdfasf</span></span></p>', N'字体颜色测试', CAST(0x0000A84400F87708 AS DateTime))
SET IDENTITY_INSERT [dbo].[passages] OFF
INSERT [dbo].[users] ([AccountName], [AccountPwd], [UserNickName], [Question], [Answer], [Age], [Sex], [BornYear], [BornMonth], [BornDay], [Profession], [ProfileImage]) VALUES (N'123', N'A9-06-44-9D-57-69-FA-73-61-D7-EC-C6-AA-3F-6D-28', N'hello', N'hahaha', N'123', N'', N'', NULL, N'', N'', N'', NULL)
INSERT [dbo].[users] ([AccountName], [AccountPwd], [UserNickName], [Question], [Answer], [Age], [Sex], [BornYear], [BornMonth], [BornDay], [Profession], [ProfileImage]) VALUES (N'1234', N'BF-B4-62-F4-30-D5-4D-C2-CC-4D-9A-E3-65-6B-00-C7', N'元老', N'123', N'111', N'24', N'女', N'1993', N'12', N'30', N'职业傻逼', N'\album\20171210102944612Profile1234.jpg')
INSERT [dbo].[users] ([AccountName], [AccountPwd], [UserNickName], [Question], [Answer], [Age], [Sex], [BornYear], [BornMonth], [BornDay], [Profession], [ProfileImage]) VALUES (N'abc', N'A9-06-44-9D-57-69-FA-73-61-D7-EC-C6-AA-3F-6D-28', N'张作霖', N'小时候最喜欢的人的名字', N'wawu', N'17', N'男', N'2000', N'5', N'10', N'古娜拉黑暗之神', N'\album\20171209110415456Profileabc.png')
ALTER TABLE [dbo].[comments]  WITH CHECK ADD  CONSTRAINT [Passage's_Comment] FOREIGN KEY([Pageid])
REFERENCES [dbo].[passages] ([id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[comments] CHECK CONSTRAINT [Passage's_Comment]
GO
ALTER TABLE [dbo].[diary]  WITH CHECK ADD  CONSTRAINT [User's_Diary] FOREIGN KEY([AccountName])
REFERENCES [dbo].[users] ([AccountName])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[diary] CHECK CONSTRAINT [User's_Diary]
GO
ALTER TABLE [dbo].[friends]  WITH CHECK ADD  CONSTRAINT [User's_Frend] FOREIGN KEY([AccountName])
REFERENCES [dbo].[users] ([AccountName])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[friends] CHECK CONSTRAINT [User's_Frend]
GO
ALTER TABLE [dbo].[message]  WITH CHECK ADD  CONSTRAINT [FK_message_users] FOREIGN KEY([AccountName])
REFERENCES [dbo].[users] ([AccountName])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[message] CHECK CONSTRAINT [FK_message_users]
GO
ALTER TABLE [dbo].[messagecomment]  WITH CHECK ADD  CONSTRAINT [MessageCommentUser_AccountName] FOREIGN KEY([MessageCommentUser])
REFERENCES [dbo].[users] ([AccountName])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[messagecomment] CHECK CONSTRAINT [MessageCommentUser_AccountName]
GO
ALTER TABLE [dbo].[passages]  WITH CHECK ADD  CONSTRAINT [User's_Passage] FOREIGN KEY([AccountName])
REFERENCES [dbo].[users] ([AccountName])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[passages] CHECK CONSTRAINT [User's_Passage]
GO
USE [master]
GO
ALTER DATABASE [pp_zone] SET  READ_WRITE 
GO
