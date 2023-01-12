USE AirportDB;

SELECT b.BookingId AS BookingId, 
p.PassengerId AS PassengerId,
p.FirstName,
p.LastName,
b.Seat,
b.Cost
FROM Booking AS b
JOIN Passenger AS p ON p.PassengerId = b.PassengerId
