Feature: Account

Account contains all the authorized user accounts that can access the bookstore api methods to store books.
The feature contains POST,GET and DELETE methods to 
create new users,
authorize them,
check if existing users are authorised and 
delete an existing user.

@NewUserCreation
Scenario: Create a new user with username and password
	When I create a new user with name "pepapa" and password "pingPong@12"
	Then A new user should be created with unique userID 

Scenario: I get a user with userID
  Given I have the userID "161139f5-bfb3-419b-bb47-12dd96e6ec3c"
  When I get the user with userID
  Then It should throw Unauthorized exception with code "1200" and message "User not authorized!"

Scenario: I authorise a created user
  When I create a new user with name "Jimbo" and password "Ganesha@02"
  And I authorise the user with name "Jimbo" and password "Ganesha@02"
  Then The user should be authorised successfully
