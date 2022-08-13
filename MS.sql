-------------Database creation-------------

create database MusicService;
Go

use MusicService;

------------Table Creation-----------------
create table users
(
ID nvarchar(50) primary key,
Password nvarchar(50) not null,
 Name nvarchar(50)not null unique ,
phone_number int,
Age int,
Gender char(1),
Priv smallint,
)

create table Artists
(
Name nvarchar(50) not null,
ID nvarchar(50) not null,
foreign key(ID) references users(ID)
ON Delete Cascade,
Primary key(ID),
)

create table Albums
(
Title nvarchar(MAX) not null,
ID nvarchar(50) not null,
Art nvarchar(MAX) ,
ArtistID nvarchar(50) not null, 
foreign key(ArtistID) references Artists
ON Delete Cascade On Update Cascade,
primary key (ID)
)

create table Concerts
(
Ticket_Price real not null,
concert_date datetime not null,
ProducerID nvarchar (50) not null,
ArtistID nvarchar(50) ,
foreign key (ArtistID) references Artists
ON Delete set null On Update Cascade,
foreign key (ProducerID) references Users
ON Delete No Action On Update Cascade,
Primary key(concert_date, ProducerID),
)

create table Genres
(
Name nvarchar(50) not null,
Primary key (Name),
)

create table Merchandise
(
Title nvarchar(50) not null,
Price real not null,
Available bit not null,
Release_date date,
Product_ID nvarchar(50) not null,
Artist_ID nvarchar(50) not null,
primary key(Product_ID),
foreign key (Artist_ID) references Artists
)

create table Musician
(
Name nvarchar(50) not null,
Gender char(1),
Age int,
ArtistID nvarchar(50) ,
foreign key(ArtistID)references Artists
ON Delete Cascade On Update Cascade,
primary key (ArtistID,Name)
)

create table Playlists
(

Title nvarchar(50)not null,
UserID nvarchar(50) not null,
Art nvarchar(max),
foreign key(UserID) references users
ON Delete Cascade On Update Cascade,
primary key(Title,UserID)
)
create table Tracks
(
Title nvarchar(50)not null,
Track_Length nvarchar(50)not null,
Lyrics nvarchar(50),
Album_ID nvarchar(50)not null,
foreign key(Album_ID) references Albums
ON Delete Cascade On Update Cascade,
Art nvarchar(MAX),
Audio nvarchar(MAX) not null,
primary key(Title,Album_ID)
)

/*create table Artist_Concerts
(
ArtistID nvarchar(50)not null,
ConcertDate datetime not null,
foreign key(ArtistID) references Artists,
primary key(ArtistID,ConcertDate)
)
*/
create table Artist_Genre
(
ArtistID nvarchar(50)not null,
GenreName nvarchar(50)not null,
foreign key(GenreName) references Genres,
foreign key(ArtistID) references Artists,
primary key(ArtistID,GenreName)
)
create table Playlist_Track
(
UserID nvarchar(50)not null,
PlaylistTitle nvarchar(50)not null,
AlbumID nvarchar(50)not null,
TrackTitle nvarchar(50)not null,
foreign key(PlaylistTitle,UserID) references Playlists,
foreign key(TrackTitle,AlbumID) references Tracks,
primary key(PlaylistTitle,UserID,TrackTitle,AlbumID)
)


----------- inserting Employee Foreign key to Department --------------


---------------Inserting values into tables----------------
insert into users 
values
('1','1234','user','0110385029',19,'F',0),
('2','555','Khaled','01277160127',20,'M',1),
('3','12345','keeny','01102040029',19,'M',2),
('21','top','Twenty One Pilots',null,null,null,1),
('505','am','Arctic Monkeys',null,null,null,1),
('69','strokes','The Strokes',null,null,null,1),
('50','tep','The Eden Project',null,null,null,1),
('51','Fz','Fairouz',null,null,null,1),
('70','Av','Avicii',null,null,null,1)

insert into Artists
values
('Arctic Monkeys','505'),
('Twenty One Pilots','21'),
('The Strokes','69'),
('The Eden Project','50'),
('Fairouz','51'),
('Avicii','70')

insert into Albums
values
('Vessel','1',null,'21'),
('Favourite Worst Nightmare','2',null,'505'),
('The New Abnormal','3',null,'69'),
('Kairo','4',null,'50'),
('kifak inta','5',null,'51'),
('Levels','6',null,'70')

insert into Genres
values
('Rock'),
('Alternative'),
 ('Pop'), ('Metal'),
 ('Progressive'),('Punk'),
 ('Blues'),('Electro'),('Classical'),
 ('Country Music'),('Hip Hop')

insert into Musician
values
('Tyler Joseph','M',23,'21'),
('Josh Dunn','M',24,'21'),
('Alex Turner','M',34,'505'),
('Julian Casablancas','M',43,'69'),
('Eden','M',25,'50'),
('Tim Berg','M',27,'70')

insert into Tracks(Title,Track_Length,Album_ID,Audio)
values 
('Migraine','3:30','1','E:\College\Second Year\Spring 2020\CIE 206 - Database Managment\Project\Migraine.m4a'),
('Fluorescent Adolescent','3:30','2','E:\College\Second Year\Spring 2020\CIE 206 - Database Managment\Project\Fluorescent Adolescent.m4a'),
('Not the same anymore','3:30','3','E:\College\Second Year\Spring 2020\CIE 206 - Database Managment\Project\Not The Same Anymore.mp3')

insert into Playlists
values
('Liked Songs','1','E:\College\Second Year\Spring 2020\CIE 206 - Database Managment\Project\likedSongs.png')
insert into Concerts 
values(100,'2020-06-18 22:30:00','3','21'),
(200,'2020-11-14 20:00:00','3','505'),
(250,'2021-01-01 19:45:00','3','69')

insert into Artist_Genre
values
('505','Rock'),
('21','Alternative '),
('69','Rock'),
('50','Electro'),
('70','Electro')

/*
insert into Artist_Concerts
values
('21','2020-06-18 22:30:00'),
('505','2020-11-14 20:00:00'),
('69','2021-01-01 19:45:00')
*/
insert into Playlist_Track
values('1','Liked Songs','1','Migraine'),
('1','Liked Songs','2','Fluorescent Adolescent')
insert into users 
values
('pf','pf123','Pink Floyd',null,null,null,1),
('GR','gr123','Guns and Roses',null,null,null,1),
('CP','cp123','Cold Play',null,null,null,1),
('RH','rh123','Radio Head',null,null,null,1),
('LDR','ldr123','Lana Del Rey',null,null,null,1),
('TB','tb123','The Beatles',null,null,null,1)
Insert into artists
values 
('Pink Floyd','pf'),
('Guns and Roses','gr'),
('Cold Play','cp'),
('Radio Head','rh'),
('Lana Del Rey','ldr'),
('The Beatles','tb')
insert into artist_genre
values
('pf','Rock'),
('GR','Metal'),
('CP','Alternative'),
('RH','Rock'),
('LDR','Pop'),
('TB','Classical')
Insert into Musician
values
('David Gilmour','M','50','pf'),
('Water Rogers','M','55','pf'),
('Axel Rose','M','60','GR'),
('Slash','M','65','GR'),
('Chris Martin','M','40','CP'),
('Thom Yorke','M','51','RH'),
('John Lenon','M','70','tb'),
('Lana','F','29','ldr')
insert into albums
values
('Ok Computer','okc',null,'rh'),
('Chinese Democracy','Chd',null,'GR'),
('The Wall','thewall',null,'pf'),
('A Rush of Blood to the Head','arobtth',null,'cp'),
('Hey Jude','hj',null,'tb'),
('Born to Die','btd',null,'ldr')
insert into Tracks(Title,Track_Length,Album_ID,Audio)
values 
('Hey You','4:00','thewall','E:\College\Second Year\Spring 2020\CIE 206 - Database Managment\Project\Hey You!.mp3'),
('Just','3:50','Okc','E:\College\Second Year\Spring 2020\CIE 206 - Database Managment\Project\Just.mp3'),
('No Surprises','4:10','okc','E:\College\Second Year\Spring 2020\CIE 206 - Database Managment\Project\No Surprises.mp3'),
('Street Of Dreams','4:20','chd','E:\College\Second Year\Spring 2020\CIE 206 - Database Managment\Project\Street Of Dreams.mp3'),
('This I Love','4:30','chd','E:\College\Second Year\Spring 2020\CIE 206 - Database Managment\Project\This I Love.mp3'),
('Video Games','4:35','btd','E:\College\Second Year\Spring 2020\CIE 206 - Database Managment\Project\Video Games.mp3'),
('Warning Sign','4:10','arobtth','E:\College\Second Year\Spring 2020\CIE 206 - Database Managment\Project\Warning Sign.mp3'),
('Kifak inta','3:31','5','E:\College\Second Year\Spring 2020\CIE 206 - Database Managment\Project\Kifak inta.mp3'),
('Avicii - Levels','3:18','6','E:\College\Second Year\Spring 2020\CIE 206 - Database Managment\Project\Avicii - Levels.mp3'),
('Avicii - The Days','4:40','6','E:\College\Second Year\Spring 2020\CIE 206 - Database Managment\Project\Avicii - The Days.mp3'),
('Avicii_The_Nights','2:56','6','E:\College\Second Year\Spring 2020\CIE 206 - Database Managment\Project\Avicii_The_Nights.mp3'),
('Avicii-Wake_Me_Up','4:07','6','E:\College\Second Year\Spring 2020\CIE 206 - Database Managment\Project\Avicii-Wake_Me_Up.orig'),
('Blank Space The eden project','3:35','4','E:\College\Second Year\Spring 2020\CIE 206 - Database Managment\Project\Blank Space The eden project.mp3'),
('ChasingGhosts The Eden Project','4:51','4','E:\College\Second Year\Spring 2020\CIE 206 - Database Managment\Project\ChasingGhosts The Eden Project.mp3'),
('Death Of A Dream The Eden Project','3:29','4','E:\College\Second Year\Spring 2020\CIE 206 - Database Managment\Project\Death Of A Dream The Eden Project.mp3'),
('Drowning The Eden Project','4:17','4','E:\College\Second Year\Spring 2020\CIE 206 - Database Managment\Project\Drowning The Eden Project.mp3'),
('Entrance The Eden Project','2:31','4','E:\College\Second Year\Spring 2020\CIE 206 - Database Managment\Project\Entrance The Eden Project.mp3'),
('Fumes The Eden project','3:31','4','E:\College\Second Year\Spring 2020\CIE 206 - Database Managment\Project\Fumes The Eden project.mp3'),
('Jupiter The Eden Project','4:02','4','E:\College\Second Year\Spring 2020\CIE 206 - Database Managment\Project\Jupiter The Eden Project.mp3'),
('Kairo The Eden Project','4:44','4','E:\College\Second Year\Spring 2020\CIE 206 - Database Managment\Project\Kairo The Eden Project.mp3')