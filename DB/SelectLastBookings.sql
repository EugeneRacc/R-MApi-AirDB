USE AirportDB;

SELECT * FROM Booking AS b
ORDER BY b.TransactionDate DESC
LIMIT 5
