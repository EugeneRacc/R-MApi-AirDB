USE AirportDB;

INSERT INTO `Country` (`Name`)
VALUES
  ("facilisis"),
  ("lorem"),
  ("diam"),
  ("Integer"),
  ("ornare.");
  
  INSERT INTO `City` (`Name`,`CountryId`)
VALUES
  ("facilisis",1),
  ("lorem",3),
  ("diam",2),
  ("Integer",3),
  ("ornare.",2);

  INSERT INTO `Airport` (`Name`,`CityId`)
VALUES
  ("Maecenas malesuada",2),
  ("posuere cubilia Curae",4),
  ("nulla. In tincidunt",4),
  ("malesuada fringilla",2),
  ("morbi",4);
  
  INSERT INTO `Airplane` (`Capacity`,`Description`)
VALUES
  (429,"tincidunt, nunc ac mattis ornare, lectus ante dictum mi, ac mattis velit justo nec ante. Maecenas mi felis, adipiscing fringilla, porttitor vulputate, posuere vulputate, lacus. Cras interdum. Nunc sollicitudin commodo ipsum. Suspendisse non leo. Vivamus nibh dolor, nonummy ac,"),
  (374,"risus. Donec egestas. Aliquam nec enim. Nunc ut erat. Sed nunc est, mollis non, cursus non, egestas a, dui. Cras pellentesque. Sed dictum. Proin eget odio. Aliquam vulputate ullamcorper magna. Sed eu eros. Nam consequat dolor vitae dolor. Donec fringilla. Donec feugiat metus sit amet ante. Vivamus non lorem vitae odio sagittis semper. Nam tempor diam dictum sapien. Aenean massa. Integer vitae nibh. Donec est mauris, rhoncus id, mollis nec, cursus a, enim. Suspendisse aliquet, sem ut cursus luctus, ipsum leo elementum sem, vitae aliquam eros turpis non enim. Mauris quis turpis vitae purus gravida sagittis. Duis gravida. Praesent eu nulla at sem molestie sodales. Mauris blandit enim consequat purus. Maecenas libero est, congue a, aliquet vel, vulputate eu, odio. Phasellus at augue id ante dictum cursus. Nunc mauris elit, dictum eu, eleifend nec, malesuada ut, sem. Nulla interdum. Curabitur dictum. Phasellus in felis. Nulla tempor augue ac ipsum. Phasellus vitae mauris"),
  (738,"pharetra. Nam ac nulla. In tincidunt congue turpis. In condimentum. Donec at arcu. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae Donec tincidunt. Donec vitae erat vel pede blandit congue. In scelerisque scelerisque dui. Suspendisse ac metus vitae velit egestas lacinia. Sed congue, elit sed consequat auctor, nunc nulla"),
  (460,"orci. Ut sagittis lobortis mauris. Suspendisse aliquet molestie tellus. Aenean egestas hendrerit neque. In ornare sagittis felis. Donec tempor, est ac mattis semper, dui lectus rutrum urna, nec luctus felis purus ac tellus. Suspendisse sed dolor. Fusce mi lorem, vehicula et, rutrum eu, ultrices sit amet, risus. Donec nibh enim, gravida sit amet, dapibus id, blandit at, nisi. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Proin vel nisl. Quisque fringilla euismod enim. Etiam gravida molestie arcu. Sed eu nibh vulputate mauris sagittis placerat. Cras dictum ultricies ligula. Nullam enim. Sed nulla ante, iaculis nec, eleifend non, dapibus rutrum, justo."),
  (874,"Aenean egestas hendrerit neque. In ornare");
  
  INSERT INTO `Department` (`Name`)
VALUES
  ("Cras lorem lorem, luctus ut,"),
  ("congue. In scelerisque"),
  ("Phasellus dolor elit,"),
  ("Aenean sed"),
  ("sed");

INSERT INTO `Employee` (`FirstName`,`LastName`,`BirthDate`,`AdditionalInformation`,`DepartmentId`)
VALUES
  ("montes,","ipsum","27.10.22","pede ac urna. Ut tincidunt vehicula risus. Nulla eget metus eu erat semper rutrum. Fusce dolor",4),
  ("adipiscing","Duis risus","27.10.22","a nunc. In at pede. Cras vulputate velit eu sem. Pellentesque ut ipsum ac mi eleifend egestas.",4),
  ("tortor","aliquam","27.10.22","eu metus. In lorem. Donec elementum, lorem ut",2),
  ("tincidunt","magna.","27.10.22","at pretium aliquet, metus urna convallis erat, eget tincidunt dui augue eu tellus. Phasellus elit",3),
  ("convallis","Mauris","27.10.22","volutpat ornare, facilisis eget, ipsum. Donec sollicitudin",5);
  
  INSERT INTO `Flight` (`Departure`,`Arrival`,`DepartureAirportId`,`ArrivalAirportId`,`AirplaneId`)
VALUES
  ("25.09.2023","04.02.23",3,2,3),
  ("27.10.22","10.02.23",5,1,4),
  ("10.02.23","10.02.23",2,2,3),
  ("04.02.23","04.02.23",4,3,3),
  ("27.10.22","27.10.22",2,3,4);
  
  INSERT INTO `FlightStaff` (`FlightId`,`EmployeeId`)
VALUES
  (3,2),
  (2,4),
  (4,3),
  (2,5),
  (2,1);
  
  INSERT INTO `Passenger` (`FirstName`,`LastName`,`PassportNumber`)
VALUES
  ("Thane","Ora","DD611879-1CA0-E893-8E2E-9461EECCD9C1"),
  ("Samuel","Ifeoma","D2692D69-0695-DEBC-A95D-1E9F2D624D0A"),
  ("Baker","Emerson","B2EA573D-FF5B-14D2-52D9-371E9ECA7A24"),
  ("Lance","Brenden","AB838695-1EB9-6C82-8C83-77E73F64AA9C"),
  ("Wayne","Wesley","57ECF35E-5AB7-905F-849D-FFC5A7DDC588");
  
  INSERT INTO `Booking` (`TransactionDate`,`PassengerId`,`Seat`,`Cost`,`FlightId`)
VALUES
  ("17.10.21 21:00",3,493,"416.94",4),
  ("19.10.21",4,848,"166.00",1),
  ("21.10.21",2,260,"566.65",2),
  ("19.11.21",3,218,"810.58",2),
  ("16.09.20",3,422,"166.92",3);
  
  INSERT INTO `Booking` (`TransactionDate`,`PassengerId`,`Seat`,`Cost`,`FlightId`)
VALUES
  ("17.10.21 21:00",1,493,"416.94",4),
  ("19.10.21",4,848,"166.00",1),
  ("21.10.21",2,260,"566.65",2),
  ("19.11.21",5,218,"810.58",2),
  ("16.09.20",5,422,"166.92",3);
