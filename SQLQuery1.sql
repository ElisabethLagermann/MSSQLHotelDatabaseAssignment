--Opgave 1: Find alle hoteller

SELECT * FROM Hotel

--Opgave 2: Finde alle navne på kunderne (og kun navnene)

SELECT [Name] FROM Customer

--Opgavee 3:  Finde alle hoteller i Odense

SELECT [Address] FROM Hotel
Where [Address] like '%Odense%'

--Opgave 4: Find det billigste værelse

SELECT * FROM Room
Where Price = (Select MIN(price) From Room)

-- Opgave 4, hvor kun prisen vises som MinimumPrice

SELECT Price AS MinimimPrice
FROM Room
Where Price = (Select MIN(price) From Room)



-- Opgave 5: Find værelse med højst antal sengepladser

Select * From Room
Where [Capacity] = (select MAX(capacity) from Room)


-- Opgave 5 hvor kun Capacity vises som Number Of Beds

Select [Capacity] AS NoOfBeds
From Room
Where [Capacity] = (select MAX(capacity) from Room)


-- Opgave 6 Finde alle værelser sorteret efter pris (lav-høj)

Select [Number], [HotelId], [Price] as Price, [HotelId]
From Room
Order by Price ASC

-- Opgave 7 Finde alle værelser sorteret efter pris (høj-lav)

Select [Number], [HotelId], [Price] as Price
From Room
Order by Price DESC


-- Opgave 8 Find alle hoteller med tilhørende værelser

Select Hotel.Name, Room.Number
From Hotel
INNER JOIN ROOM ON Hotel.Id = Room.HotelId
Order by Hotel.Name

-- Opgave 9 Find alle hoteller med værelser, der er booket

Select Hotel.Name, Room.Number, Booking.BookingId
From Hotel
INNER JOIN ROOM ON Hotel.Id = Room.HotelId
INNER JOIN Booking ON Room.HotelId = Booking.HotelId
   AND Room.Number = Booking.RoomNumber
Order by Room.HotelId


-- Opgave 10 Finde alle hoteller rangordnet efter gennemsnitspriser på værelser

SELECT Hotel.Name, AVG(Room.Price) as [Average Price]
FROM Hotel
INNER JOIN Room ON Hotel.Id = Room.HotelID
Group by Hotel.Name
Order by [Average Price]

-- 11 Finde hotelnavnet, værelsesnummer og kundenavn på alle bookinger

Select Hotel.Name, Room.Number, Customer.[Name]
From Hotel
Join Room on Hotel.Id = Room.HotelId
Join Booking on Room.Number = Booking.RoomNumber
and Room.HotelId = Booking.HotelId
join Customer on Booking.CustomerId = Customer.Id
Order by Room.Number asc

