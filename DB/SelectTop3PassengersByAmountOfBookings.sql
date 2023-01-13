USE AirportDB;

SELECT b.PassengerId,
COUNT(b.PassengerId) AS NumberOfBookings, 
p.FirstName, 
p.LastName
FROM Booking AS b
JOIN Passenger AS p ON p.PassengerId = b.PassengerId
GROUP BY b.PassengerId
ORDER BY NumberOfBookings DESC
LIMIT 3


