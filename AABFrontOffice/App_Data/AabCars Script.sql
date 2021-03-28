USE [AabCars]
GO
/****** Object:  Table [dbo].[BookingAppointment]    Script Date: 2/27/2021 11:49:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BookingAppointment](
	[BookingId] [int] IDENTITY(1,1) NOT NULL,
	[CarId] [int] NULL,
	[customerId] [int] NULL,
	[BookingDate] [date] NULL,
	[CreatedOn] [date] NULL,
	[IsActive] [bit] NULL,
 CONSTRAINT [PK_BookingAppointment] PRIMARY KEY CLUSTERED 
(
	[BookingId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Car]    Script Date: 2/27/2021 11:49:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Car](
	[carId] [int] IDENTITY(1,1) NOT NULL,
	[Model] [varchar](max) NULL,
	[Price] [int] NULL,
	[BodyStyle] [varchar](max) NULL,
	[Color] [nvarchar](max) NULL,
	[IsActive] [bit] NULL,
	[CreatedOn] [date] NULL,
 CONSTRAINT [PK_Car] PRIMARY KEY CLUSTERED 
(
	[carId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserDetails]    Script Date: 2/27/2021 11:49:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserDetails](
	[UserID] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [varchar](max) NULL,
	[Email] [varchar](max) NULL,
	[password] [varchar](max) NULL,
	[Address] [varchar](max) NULL,
	[Contact] [varchar](max) NULL,
	[IsStaff] [bit] NULL,
	[IsActive] [bit] NULL,
	[CreatedOn] [date] NULL,
 CONSTRAINT [PK_UserDetails] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[BookingAppointment] ON 

INSERT [dbo].[BookingAppointment] ([BookingId], [CarId], [customerId], [BookingDate], [CreatedOn], [IsActive]) VALUES (1, 1, 3, CAST(N'2021-02-27' AS Date), CAST(N'2021-02-27' AS Date), 0)
INSERT [dbo].[BookingAppointment] ([BookingId], [CarId], [customerId], [BookingDate], [CreatedOn], [IsActive]) VALUES (2, 1, 3, CAST(N'2021-02-28' AS Date), CAST(N'2021-02-27' AS Date), 1)
SET IDENTITY_INSERT [dbo].[BookingAppointment] OFF
GO
SET IDENTITY_INSERT [dbo].[Car] ON 

INSERT [dbo].[Car] ([carId], [Model], [Price], [BodyStyle], [Color], [IsActive], [CreatedOn]) VALUES (1, N'A-Class Sedan.', 32000, N'A-Clas', N'Black', 1, CAST(N'2021-02-27' AS Date))
INSERT [dbo].[Car] ([carId], [Model], [Price], [BodyStyle], [Color], [IsActive], [CreatedOn]) VALUES (2, N'488 Pista Spider ', 350000, N'ferrari-488-pista-spider', N'White Black', 1, CAST(N'2021-02-27' AS Date))
SET IDENTITY_INSERT [dbo].[Car] OFF
GO
SET IDENTITY_INSERT [dbo].[UserDetails] ON 

INSERT [dbo].[UserDetails] ([UserID], [UserName], [Email], [password], [Address], [Contact], [IsStaff], [IsActive], [CreatedOn]) VALUES (1, N'John Smith', N'johnsmit@gmail.com', N'', N'United States America', N'+54034252552', 0, 0, NULL)
INSERT [dbo].[UserDetails] ([UserID], [UserName], [Email], [password], [Address], [Contact], [IsStaff], [IsActive], [CreatedOn]) VALUES (2, N'John Smith', N'johnsmit@gmail.com', N'', N'United States America', N'+54034252552', 0, 0, NULL)
INSERT [dbo].[UserDetails] ([UserID], [UserName], [Email], [password], [Address], [Contact], [IsStaff], [IsActive], [CreatedOn]) VALUES (3, N'John Smith', N'johnsmit@gmail.com', N'', N'United States America, new york', N'+54034252552', 0, 1, NULL)
INSERT [dbo].[UserDetails] ([UserID], [UserName], [Email], [password], [Address], [Contact], [IsStaff], [IsActive], [CreatedOn]) VALUES (4, N'Ahmed ali akbar', N'ahmed@gmail.com.pk', N'test', N'United States America, California', N'+9242345253', 0, 1, NULL)
INSERT [dbo].[UserDetails] ([UserID], [UserName], [Email], [password], [Address], [Contact], [IsStaff], [IsActive], [CreatedOn]) VALUES (5, N'Admin', N'admin@gmail.com', N'test', N'Karachi sindh Pakistan 1', N'2312-3123123', 1, 1, NULL)
SET IDENTITY_INSERT [dbo].[UserDetails] OFF
GO
ALTER TABLE [dbo].[BookingAppointment]  WITH CHECK ADD  CONSTRAINT [FK__BookingAp__CarId__3D5E1FD2] FOREIGN KEY([CarId])
REFERENCES [dbo].[Car] ([carId])
GO
ALTER TABLE [dbo].[BookingAppointment] CHECK CONSTRAINT [FK__BookingAp__CarId__3D5E1FD2]
GO
ALTER TABLE [dbo].[BookingAppointment]  WITH CHECK ADD  CONSTRAINT [FK__BookingAp__custo__3E52440B] FOREIGN KEY([customerId])
REFERENCES [dbo].[UserDetails] ([UserID])
GO
ALTER TABLE [dbo].[BookingAppointment] CHECK CONSTRAINT [FK__BookingAp__custo__3E52440B]
GO
/****** Object:  StoredProcedure [dbo].[AddOrUpdateCar]    Script Date: 2/27/2021 11:49:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE proc [dbo].[AddOrUpdateCar]
@CarID int,
@Model nvarchar(max),
@Price nvarchar(max),
@Body nvarchar(max),
@Color nvarchar(max)

as
begin

 if(@CarID = 0)
 begin
		insert into Car(Model,Price,BodyStyle,Color, isActive, CreatedOn)
		values(@Model,@Price,@Body,@Color,1,GETDATE());

		select '00' as statusCode
end
end
GO
/****** Object:  StoredProcedure [dbo].[spBookingAppointment]    Script Date: 2/27/2021 11:49:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE proc [dbo].[spBookingAppointment]
@CarID int,
@UserId nvarchar(max),
@BookingDate nvarchar(max)

as
begin
Declare @IsBook int;

select @IsBook = Count(*) from BookingAppointment 
where CarID = @CarID and BookingDate = @BookingDate and IsActive = 1

 if(@IsBook = 0)
 begin
		select @IsBook = Count(*) from BookingAppointment 
		where CarID = @CarID and customerId = @UserId and IsActive = 1
		if(@IsBook = 0)
		BEGIN
				insert into BookingAppointment(CarId, customerId,BookingDate ,isActive, CreatedOn)
								values(@carId,@UserId,@bookingDate,1,GETDATE());
				select '00' as statusCode
		END
		ELSE
		BEGIN
				SELECT '010' AS statusCode
		END
end
else
begin
		select '01' as statusCode
end
end
GO
/****** Object:  StoredProcedure [dbo].[spCancelAppointment]    Script Date: 2/27/2021 11:49:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE proc [dbo].[spCancelAppointment]
@BookingId int

as
begin
		Update BookingAppointment
		set IsActive = 0
		where BookingId = @BookingId

		select '000' statusCode
end
GO
/****** Object:  StoredProcedure [dbo].[SpDeleteCar]    Script Date: 2/27/2021 11:49:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE proc [dbo].[SpDeleteCar]
@CarId int
as
begin
update car 
set isactive = 0
where carId = @CarId

end
GO
/****** Object:  StoredProcedure [dbo].[SpDeleteUser]    Script Date: 2/27/2021 11:49:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE proc [dbo].[SpDeleteUser]
@UserId int
as
begin
update UserDetails
set isactive = 0
where UserID = @userid;

end
GO
/****** Object:  StoredProcedure [dbo].[SpGetBookings]    Script Date: 2/27/2021 11:49:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE proc [dbo].[SpGetBookings]
@UserID int
as
begin
Declare @IsStaff bit;

select @IsStaff = IsStaff from UserDetails where UserID = @UserID

	if(@IsStaff = 1)
	begin
		 select b.BookingId,cast(b.BookingDate as date) BookingDate,c.Model,c.BodyStyle,c.Color,u.UserName,cast(b.CreatedOn as date) as CreatedOn from BookingAppointment b
			left join Car c on b.CarId = c.carId
			left join UserDetails u on b.customerId = u.UserID
			where b.IsActive = 1 order by BookingDate desc;
	end
	else
	begin
		 select b.BookingId,cast(b.BookingDate as date) BookingDate,c.Model,c.BodyStyle,c.Color,u.UserName,cast(b.CreatedOn as date) as CreatedOn from BookingAppointment b
			left join Car c on b.CarId = c.carId
			left join UserDetails u on b.customerId = u.UserID
			where customerId = @UserID and b.IsActive = 1 order by BookingDate desc;
	end
end

GO
/****** Object:  StoredProcedure [dbo].[SpGetCarList]    Script Date: 2/27/2021 11:49:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE proc [dbo].[SpGetCarList]
as
begin
select * from car where isActive = 1
end
GO
/****** Object:  StoredProcedure [dbo].[SpGetStaffList]    Script Date: 2/27/2021 11:49:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE proc [dbo].[SpGetStaffList]
as
begin
 select userid,UserName,Email,password,Address,Contact from UserDetails
 where IsStaff = 1 and IsActive = 1
end
GO
/****** Object:  StoredProcedure [dbo].[SpGetUserData]    Script Date: 2/27/2021 11:49:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE proc [dbo].[SpGetUserData]
@UserID int
as
begin
 select userid,UserName,Email,password,Address,Contact from UserDetails
 where UserID = @UserID and IsActive = 1
end
GO
/****** Object:  StoredProcedure [dbo].[SpLogin]    Script Date: 2/27/2021 11:49:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE proc [dbo].[SpLogin]
@Email varchar(max),
@Password varchar(max)
as
begin
 select userid,UserName,Email,password,Address,Contact,IsStaff from UserDetails
 where email = @Email and Password = @Password and isactive = 1;
end
GO
/****** Object:  StoredProcedure [dbo].[UserRegistrationOrupdate]    Script Date: 2/27/2021 11:49:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE proc [dbo].[UserRegistrationOrupdate]
@UserID int,
@UserName nvarchar(max),
@Email nvarchar(max),
@Contact nvarchar(max),
@password nvarchar(max),
@Address nvarchar(max),
@IsStaff bit

as
begin
 
 

 
 if(@UserID = 0)
 begin
		insert into UserDetails(UserName,Email,Password,Contact,Address,IsStaff,IsActive,CreatedOn)
		values(@UserName,@Email,@password,@Contact,@Address,@IsStaff, 1, getdate())

		select * from UserDetails where UserID = SCOPE_IDENTITY();
   end
   else
	begin


				update UserDetails
				set UserName = @UserName,
					Address = @Address,
					--password = @password,
					Email = @Email,
					Contact = @Contact
					where UserID = @UserID;
					
					select * from UserDetails where UserID = @UserID;
end
end
GO
