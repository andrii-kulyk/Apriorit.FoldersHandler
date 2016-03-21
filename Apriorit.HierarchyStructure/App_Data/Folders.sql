CREATE TABLE Folders ( 
    Id int not null primary key identity,
    Name varchar(200) not null,
    ParentId int null references Folders(Id),
    constraint UX_Path unique (Name, ParentId),
)