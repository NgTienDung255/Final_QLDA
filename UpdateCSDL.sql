alter table Baotri
drop constraint PK_BT_May

alter table Hoadonban
drop constraint PK_HDB_May

alter table May
drop constraint PK__May__3A5BBB4172FE1C18

ALTER TABLE May
ALTER COLUMN MaMay NVARCHAR(10) NOT NULL;

ALTER TABLE May
ALTER COLUMN MaPhong NVARCHAR(10) NOT NULL;

-- Thêm khóa chính mới bao gồm cả MaMay và MaPhong
ALTER TABLE May
ADD PRIMARY KEY (MaMay, MaPhong);

alter table HoaDonBan
add constraint PK_HDB_May
foreign key (MaMay, MaPhong) references May (MaMay, MaPhong)

ALTER TABLE BaoTri
ADD MaPhong NVARCHAR(10); 

alter table BaoTri
add constraint PK_BT_May
foreign key (MaMay, MaPhong) references May (MaMay, MaPhong)

UPDATE BaoTri
SET MaNBT = 'NBT02', MaPhong = 'P01'
WHERE MaBT = 'MBT001';

UPDATE BaoTri
SET MaNBT = 'NBT01', MaPhong = 'P03'
WHERE MaBT = 'MBT002';

UPDATE BaoTri
SET MaNBT = 'NBT04', MaPhong = 'P01'
WHERE MaBT = 'MBT003';

drop trigger trg_InsertMay
