# VTU-Design-Patterns
# Относно приложението
Приложението предлага възможност на регистрация на клиенти. След успешна регистрация, всеки клиент може да взима или връща книга. Приложението има и функционалност която да уведомя своите клиенти, че датата за връщане на дадена книга наближава. 

## Използвани шаблони
* Creational patterns
	* Abstract Factory
* Structural patterns
	* Facade
* Behavioral patterns
	* Command
	* Observer

## Команди
* RegisterClient {userType} {fName} {lName} {age}
* GetBook {userFName} {userLName} {bookName}
* ReturnBook {userFName} {userLName} {bookName}
* Report {userFName} {userLName}
* ShutDown

## Input/Output
	Input

	RegisterClient Child Pesho Peshev 17
	RegisterClient Adult Gosho Goshev 32
	Getbook Pesho Peshev Harry Potter and the Philosopher's Stone
	Getbook Pesho Peshev Pet cemetery
	Getbook Gosho Goshev Harry Potter and the Philosopher's Stone
	Getbook Gosho Goshev Pet cemetery
	Getbook Pesho Peshev Harry Potter and the Chamber of Secrets
	ReturnBook Pesho Peshev Harry Potter and the Philosopher's Stone
	Report Pesho Peshev
	Report Gosho Goshev 
	Shutdown
  
	Output

	Successfully registered Pesho Peshev!
	Successfully registered Gosho Goshev!
	Pesho Peshev took Harry Potter and the Philosopher's Stone.
	You can't take this book because its genre is forbidden to you!
	Harry Potter and the Philosopher's Stone is taken. Will be available at the latest:
	Gosho Goshev took Pet cemetery.
	Pesho Peshev took Harry Potter and the Chamber of Secrets.
	The Harry Potter and the Philosopher's Stone book is back.
	Books:
	Title: Harry Potter and the Chamber of Secrets
	Author: Joan
	Genre: Novel
	Date of take:
	Return date:
	--------------------
	Books:
	Title: Pet cemetery
	Author: Stephen
	Genre: Horror
	Date of take:
	Return date:
	--------------------
