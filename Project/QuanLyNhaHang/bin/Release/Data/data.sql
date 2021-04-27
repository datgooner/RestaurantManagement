CREATE DATABASE QuanLyNhaHang
GO


USE QuanLyNhaHang
GO



-- Food
-- Table
-- FoodCategory
-- Account
-- Bill
-- BillInfo

CREATE TABLE TableFood
(
	id INT IDENTITY PRIMARY KEY,
	name NVARCHAR(100) NOT NULL DEFAULT N'Bàn chưa có tên',
	status NVARCHAR(100) NOT NULL DEFAULT N'Trống'	-- Trống || Có người
)
GO

CREATE TABLE Account
(
	UserName NVARCHAR(100) PRIMARY KEY,	
	DisplayName NVARCHAR(100) NOT NULL DEFAULT N'Quanly',
	PassWord NVARCHAR(1000) NOT NULL DEFAULT 0,
	Type INT NOT NULL  DEFAULT 0 -- 1: admin && 0: staff
)
GO

CREATE TABLE FoodCategory
(
	id INT IDENTITY PRIMARY KEY,
	name NVARCHAR(100) NOT NULL DEFAULT N'Chưa đặt tên'
)
GO

CREATE TABLE Food
(
	id INT IDENTITY PRIMARY KEY,
	name NVARCHAR(100) NOT NULL DEFAULT N'Chưa đặt tên',
	idCategory INT NOT NULL,
	price FLOAT NOT NULL DEFAULT 0
	
	FOREIGN KEY (idCategory) REFERENCES dbo.FoodCategory(id)
)
GO

CREATE TABLE Bill
(
	id INT IDENTITY PRIMARY KEY,
	DateCheckIn DATE NOT NULL DEFAULT GETDATE(),
	DateCheckOut DATE,
	idTable INT NOT NULL,
	status INT NOT NULL DEFAULT 0 -- 1: đã thanh toán && 0: chưa thanh toán

	
	FOREIGN KEY (idTable) REFERENCES dbo.TableFood(id)
)
GO

CREATE TABLE BillInfo
(
	id INT IDENTITY PRIMARY KEY,
	idBill INT NOT NULL,
	idFood INT NOT NULL,
	count INT NOT NULL DEFAULT 0
	
	FOREIGN KEY (idBill) REFERENCES dbo.Bill(id),
	FOREIGN KEY (idFood) REFERENCES dbo.Food(id)
)
GO

CREATE TABLE ReportFood
(
	name NVARCHAR(100) NOT NULL,
	allcount INT NOT NULL DEFAULT 0
)
GO

ALTER TABLE dbo.Bill 
ADD discount INT
GO
UPDATE dbo.Bill SET discount = 0
GO

ALTER TABLE dbo.Bill 
ADD totalPrice FLOAT

GO

INSERT INTO dbo.Account
        ( UserName ,
          DisplayName ,
          PassWord ,
          Type
        )
VALUES  ( N'tdat' , -- UserName - nvarchar(100)
          N'Nguyen Tien Dat' , -- DisplayName - nvarchar(100)
          N'1' , -- PassWord - nvarchar(1000)
          1  -- Type - int
        )
INSERT INTO dbo.Account
        ( UserName ,
          DisplayName ,
          PassWord ,
          Type
        )
VALUES  ( N'qcuong' , -- UserName - nvarchar(100)
          N'Trinh Quoc Cuong' , -- DisplayName - nvarchar(100)
          N'1' , -- PassWord - nvarchar(1000)
          0  -- Type - int
        )
GO

CREATE PROC SP_GetAccountByUserName
@userName NVARCHAR(100)
AS
BEGIN
	SELECT * FROM dbo.Account WHERE UserName = @userName
END
GO

CREATE PROC SP_login
@userName NVARCHAR(100) , @passWord NVARCHAR(100)
AS
BEGIN
	SELECT * FROM dbo.Account WHERE UserName = @userName AND PassWord = @passWord
END
GO

--thêm bàn
DECLARE @i INT = 1
WHILE @i <= 10
BEGIN
	INSERT dbo.TableFood ( name) VALUES  ( N'Bàn ' + CAST(@i AS NVARCHAR(100)))
	SET @i = @i + 1
END
GO

 
CREATE PROC SP_GetTableList
AS SELECT * FROM dbo.TableFood
GO


-- thêm Category
INSERT dbo.FoodCategory ( name ) VALUES  ( N'Hải sản')
INSERT dbo.FoodCategory ( name ) VALUES  ( N'Nông sản')
INSERT dbo.FoodCategory ( name ) VALUES  ( N'Tráng miệng')
INSERT dbo.FoodCategory ( name ) VALUES  ( N'Đồ uống')
-- thêm món ăn
-- hải sản
INSERT dbo.Food
        ( name, idCategory, price )
VALUES  ( N'Mực nướng', 1, 100000)
INSERT dbo.Food
        ( name, idCategory, price )
VALUES  ( N'Mực xào', 1, 70000)
INSERT dbo.Food
        ( name, idCategory, price )
VALUES  ( N'Cá hấp', 1, 50000)
--nông sản
INSERT dbo.Food
        ( name, idCategory, price )
VALUES  ( N'Gà luộc', 2, 100000)
INSERT dbo.Food
        ( name, idCategory, price )
VALUES  ( N'Lợn quay', 2, 150000)
INSERT dbo.Food
        ( name, idCategory, price )
VALUES  ( N'Rau theo mùa', 2, 20000)
--tráng miệng
INSERT dbo.Food
        ( name, idCategory, price )
VALUES  ( N'Salad', 3, 30000)
INSERT dbo.Food
        ( name, idCategory, price )
VALUES  ( N'Hoa Quả', 3, 20000)
--đồ uống
INSERT dbo.Food
        ( name, idCategory, price )
VALUES  ( N'Coca', 4, 10000)
INSERT dbo.Food
        ( name, idCategory, price )
VALUES  ( N'Bia Hà Nội', 4, 15000)
INSERT dbo.Food
        ( name, idCategory, price )
VALUES  ( N'Rượu', 4, 30000)

GO



CREATE PROC SP_InsertBill
@idTable INT
AS
BEGIN
	INSERT dbo.Bill 
	        ( DateCheckIn ,
	          DateCheckOut ,
	          idTable ,
	          status ,
			  discount
	        )
	VALUES  ( GETDATE() , -- DateCheckIn - date
	          NULL , -- DateCheckOut - date
	          @idTable , -- idTable - int
	          0,  -- status - int
			  0
	        )
END

GO

CREATE PROC SP_InsertBillInfo
@idBill INT, @idFood INT, @count INT
AS
BEGIN

	DECLARE @isExitsBillInfo INT
	DECLARE @foodCount INT = 1
	
	SELECT @isExitsBillInfo = id, @foodCount = b.count 
	FROM dbo.BillInfo AS b 
	WHERE idBill = @idBill AND idFood = @idFood

	IF (@isExitsBillInfo > 0)
	BEGIN
		DECLARE @newCount INT = @foodCount + @count
		IF (@newCount > 0)
			UPDATE dbo.BillInfo	SET count = @foodCount + @count WHERE idFood = @idFood
		ELSE
			DELETE dbo.BillInfo WHERE idBill = @idBill AND idFood = @idFood
	END
	ELSE
	BEGIN
		INSERT	dbo.BillInfo
        ( idBill, idFood, count )
		VALUES  ( @idBill, -- idBill - int
          @idFood, -- idFood - int
          @count  -- count - int
          )
	END
END
GO


CREATE TRIGGER TG_UpdateBillInfo
ON dbo.BillInfo FOR INSERT, UPDATE
AS
BEGIN
	DECLARE @idBill INT
	
	SELECT @idBill = idBill FROM Inserted
	
	DECLARE @idTable INT
	
	SELECT @idTable = idTable FROM dbo.Bill WHERE id = @idBill AND status = 0
	
	UPDATE dbo.TableFood SET status = N'Có người' WHERE id = @idTable
END

GO

CREATE TRIGGER TG_UpdateBill
ON dbo.Bill FOR UPDATE
AS
BEGIN
	DECLARE @idBill INT
	
	SELECT @idBill = id FROM Inserted	
	
	DECLARE @idTable INT
	
	SELECT @idTable = idTable FROM dbo.Bill WHERE id = @idBill
	
	DECLARE @count int = 0
	
	SELECT @count = COUNT(*) FROM dbo.Bill WHERE idTable = @idTable AND status = 0
	
	IF (@count = 0)
	BEGIN
		UPDATE dbo.TableFood SET status = N'Trống' WHERE id = @idTable
		UPDATE dbo.Bill SET DateCheckOut = GETDATE() WHERE id = @idBill
	END
    
END
GO




CREATE PROC SP_GetListBillByDate
@checkIN DATE, @checkOut DATE
AS
BEGIN
	SELECT t.name AS [Tên bàn], b.totalPrice AS [Tổng tiền], b.DateCheckIn AS [Ngày vào], b.DateCheckOut AS [Ngày ra], b.discount AS [Giảm giá]
	FROM dbo.Bill AS b, dbo.TableFood AS t
	WHERE b.DateCheckIn >= @checkIN AND b.DateCheckOut <= @checkOut AND b.status = 1 AND t.id = b.idTable
END
GO


CREATE PROC SP_UpdateAccount
@userName NVARCHAR(100), @displayName NVARCHAR(100), @password NVARCHAR(100), @newPassword NVARCHAR(100)
AS
BEGIN
	DECLARE @isRightPass INT = 0
	
	SELECT @isRightPass = COUNT(*) FROM dbo.Account WHERE USERName = @userName AND PassWord = @password
	
	IF (@isRightPass = 1)
	BEGIN
		IF (@newPassword = NULL OR @newPassword = '')
		BEGIN
			UPDATE dbo.Account SET DisplayName = @displayName WHERE UserName = @userName
		END		
		ELSE
			UPDATE dbo.Account SET DisplayName = @displayName, PassWord = @newPassword WHERE UserName = @userName
	end
END
GO

CREATE TRIGGER TG_DeleteBillInfo
ON dbo.BillInfo FOR DELETE
AS 
BEGIN
	DECLARE @idBillInfo INT
	DECLARE @idBill INT
	SELECT @idBillInfo = id, @idBill = Deleted.idBill FROM Deleted
	
	DECLARE @idTable INT
	SELECT @idTable = idTable FROM dbo.Bill WHERE id = @idBill
	
	DECLARE @count INT = 0
	
	SELECT @count = COUNT(*) FROM dbo.BillInfo AS bi, dbo.Bill AS b WHERE b.id = bi.idBill AND b.id = @idBill AND b.status = 0
	
	IF (@count = 0)
		UPDATE dbo.TableFood SET status = N'Trống' WHERE id = @idTable
END
GO


CREATE FUNCTION [dbo].[fuConvertToUnsign1] ( @strInput NVARCHAR(4000) ) RETURNS NVARCHAR(4000) AS BEGIN IF @strInput IS NULL RETURN @strInput IF @strInput = '' RETURN @strInput DECLARE @RT NVARCHAR(4000) DECLARE @SIGN_CHARS NCHAR(136) DECLARE @UNSIGN_CHARS NCHAR (136) SET @SIGN_CHARS = N'ăâđêôơưàảãạáằẳẵặắầẩẫậấèẻẽẹéềểễệế ìỉĩịíòỏõọóồổỗộốờởỡợớùủũụúừửữựứỳỷỹỵý ĂÂĐÊÔƠƯÀẢÃẠÁẰẲẴẶẮẦẨẪẬẤÈẺẼẸÉỀỂỄỆẾÌỈĨỊÍ ÒỎÕỌÓỒỔỖỘỐỜỞỠỢỚÙỦŨỤÚỪỬỮỰỨỲỶỸỴÝ' +NCHAR(272)+ NCHAR(208) SET @UNSIGN_CHARS = N'aadeoouaaaaaaaaaaaaaaaeeeeeeeeee iiiiiooooooooooooooouuuuuuuuuuyyyyy AADEOOUAAAAAAAAAAAAAAAEEEEEEEEEEIIIII OOOOOOOOOOOOOOOUUUUUUUUUUYYYYYDD' DECLARE @COUNTER int DECLARE @COUNTER1 int SET @COUNTER = 1 WHILE (@COUNTER <=LEN(@strInput)) BEGIN SET @COUNTER1 = 1 WHILE (@COUNTER1 <=LEN(@SIGN_CHARS)+1) BEGIN IF UNICODE(SUBSTRING(@SIGN_CHARS, @COUNTER1,1)) = UNICODE(SUBSTRING(@strInput,@COUNTER ,1) ) BEGIN IF @COUNTER=1 SET @strInput = SUBSTRING(@UNSIGN_CHARS, @COUNTER1,1) + SUBSTRING(@strInput, @COUNTER+1,LEN(@strInput)-1) ELSE SET @strInput = SUBSTRING(@strInput, 1, @COUNTER-1) +SUBSTRING(@UNSIGN_CHARS, @COUNTER1,1) + SUBSTRING(@strInput, @COUNTER+1,LEN(@strInput)- @COUNTER) BREAK END SET @COUNTER1 = @COUNTER1 +1 END SET @COUNTER = @COUNTER +1 END SET @strInput = replace(@strInput,' ','-') RETURN @strInput END
GO

CREATE PROC SP_DeleteBillInfoAndBillByTableID
@TableId int
AS
BEGIN
DECLARE @billId INT
---xoa bill info
DECLARE @billInfoId INT
DECLARE @MyCursor CURSOR
SET @MyCursor = CURSOR FAST_FORWARD
FOR
SELECT bi.id FROM dbo.Bill AS b, dbo.BillInfo AS bi  WHERE b.idTable = @TableId AND bi.idBill = b.id
OPEN @MyCursor 
FETCH NEXT FROM @MyCursor INTO @billInfoId
WHILE @@FETCH_STATUS = 0
BEGIN
	DELETE dbo.BillInfo WHERE id = @billInfoId
	FETCH NEXT FROM @MyCursor INTO @billInfoId
END
CLOSE @MyCursor
DEALLOCATE @MyCursor
---xoa bill
DELETE dbo.Bill WHERE idTable = @TableId

END
GO

CREATE PROC SP_MakeFoodReport
@datef DATE, @datet DATE
AS
BEGIN
DELETE dbo.ReportFood
DECLARE @Foodid INT
DECLARE @MyCursor CURSOR

SET @MyCursor = CURSOR FAST_FORWARD
FOR SELECT id FROM dbo.Food

OPEN @MyCursor 

FETCH NEXT FROM @MyCursor
INTO @Foodid

WHILE @@FETCH_STATUS = 0
BEGIN
	DECLARE @MyCursor1 CURSOR
	DECLARE @count INT
	DECLARE @sum INT = 0
	DECLARE @foodname NVARCHAR(100)

	SET @MyCursor1 = CURSOR FAST_FORWARD FOR 
		SELECT bi.count FROM dbo.BillInfo AS bi, dbo.Bill AS b WHERE bi.idFood = @Foodid AND b.id = bi.idBill AND b.DateCheckIn >= @datef AND b.DateCheckOut <= @datet

	OPEN @MyCursor1
	FETCH NEXT FROM @MyCursor1 INTO @count
	WHILE @@FETCH_STATUS = 0
		BEGIN 
			SET @sum =  @sum + @count
			FETCH NEXT FROM @MyCursor1 INTO @count
		END
		CLOSE @MyCursor1
		DEALLOCATE @MyCursor1
	SELECT @foodname = name FROM dbo.Food WHERE id = @Foodid
	INSERT INTO dbo.ReportFood
	        ( name, allcount )
	VALUES  ( @foodname, -- name - nvarchar(100)
	          @sum  -- allcount - int
	          )
	FETCH NEXT FROM @MyCursor
	INTO @Foodid
END

CLOSE @MyCursor
DEALLOCATE @MyCursor

END 
GO

CREATE PROC SP_FoodReport
AS SELECT * FROM dbo.ReportFood
GO

CREATE PROC SP_BillCheckOutReportByIdBIll
@Billid INT
AS
BEGIN
SELECT f.name, bi.count, f.price, f.price*bi.count AS totalPrice FROM dbo.BillInfo AS bi, dbo.Bill AS b, dbo.Food AS f WHERE bi.idBill = b.id AND bi.idFood = f.id AND b.id = @Billid
END
GO

CREATE TABLE BillForCal
(
	allcount FLOAT NOT NULL DEFAULT 0
)
GO

CREATE PROC SP_CalTotalPriceByBillId
@Billid int
AS
BEGIN
DECLARE @sum FLOAT = 0
DECLARE @count FLOAT
DELETE dbo.BillForCal
DECLARE @MyCursor1 CURSOR
SET @MyCursor1 = CURSOR FAST_FORWARD FOR 
SELECT  f.price*bi.count AS totalPrice FROM dbo.BillInfo AS bi, dbo.Bill AS b, dbo.Food AS f WHERE bi.idBill = b.id AND bi.idFood = f.id AND b.id = @Billid
OPEN @MyCursor1
FETCH NEXT FROM @MyCursor1 INTO @count
	WHILE @@FETCH_STATUS = 0
		BEGIN 
			SET @sum =  @sum + @count
			FETCH NEXT FROM @MyCursor1 INTO @count
		END
	CLOSE @MyCursor1
	DEALLOCATE @MyCursor1
	INSERT dbo.BillForCal
	        ( allcount )
	VALUES  ( @sum  -- allcount - float
	          )

END
GO


