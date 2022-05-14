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
* GetItem {userFName} {userLName} {itemName}
* ReturnItem {userFName} {userLName} {itemName}
* Report {userFName} {userLName}
* ShutDown

## Input/Output
	Input

	RegisterClient Child Pesho Peshev 17
	RegisterClient Adult Gosho Goshev 32
	GetItem Pesho Peshev Harry Potter and the Philosopher's Stone
	GetItem Pesho Peshev Savage Spider-Man
	GetItem Pesho Peshev Pet cemetery
	GetItem Gosho Goshev Harry Potter and the Philosopher's Stone
	GetItem Gosho Goshev Pet cemetery
	GetItem Pesho Peshev Harry Potter and the Chamber of Secrets
	ReturnItem Pesho Peshev Harry Potter and the Philosopher's Stone
	Report Pesho Peshev 
	Report Gosho Goshev
	Shutdown
  
	Output

	Successfully registered Pesho Peshev!
	Successfully registered Gosho Goshev!
	Pesho Peshev took Harry Potter and the Philosopher's Stone.
	Pesho Peshev took Savage Spider-Man.
	Genre: Horror is forbidden for children!
	Harry Potter and the Philosopher's Stone is taken. Will be available at the latest:
	Gosho Goshev took Pet cemetery.
	Pesho Peshev took Harry Potter and the Chamber of Secrets.
	The Harry Potter and the Philosopher's Stone book is back.
	Items to return:
	Item type: Book
	Title: Harry Potter and the Chamber of Secrets
	Author: Joan
	Genre: Novel
	Date of take:
	Return date:
	--------------------
	Item type: Comics
	Title: Savage Spider-Man
	Author: Joe
	Genre: Superhero
	Date of take: 
	Return date: 
	--------------------
	Items to return:
	Item type: Book
	Title: Pet cemetery
	Author: Stephen
	Genre: Horror
	Date of take:
	Return date:
	--------------------
	Shutdown application
