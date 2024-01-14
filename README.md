# Towergate

## Time spent
* 2 Hours for the master commit
* In-progress modal branch

## Choice of Frontend Technology
I've used ASP.NET MVC Razor, this allows me to create a dynamic web page using C# alongside HTML. 

## Design Decisions Taken
* Model-view-controller (MVC): This project follows the MVC pattern, which is a standard way for structuring ASP.net applications.
* Data Validation: Data annotations were used for validating the 'Customer' Model.
* Data storage: A static list was chosen to temporarily store customer data in memory.
* Modal Dialogs: Bootstrap modals are being used to add/edit customer details, providing a user-friendly experience without having to do page reloads. (still in progress)

## Any issues found
A few problems:
* Switching the views: Customer/Create.cshtml and Customer/Edit.cshtml to a bootstrap modal, I thought would be straight forward, however a lot of different issues arose.
* Form submission and validation: I initially used IFormCollection when I started this project and later on after adding validation to the model binding. I found it was bypassing the validation completely. This was resolved by using model binding directly.

## Next steps to Further Improve the work
* Implement a EF Database
* Improve User Experience by using modals (in progress)
* Adding unit tests to ensure the reliability and correctness of the application logic.
* Responsive Designs - I've only tested the application works on my monitor so far.
* Implement a more comprehensive error handling
