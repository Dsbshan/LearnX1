function Person(firstName, lastName, age) {
    this.firstName = firstName;
    this.lastName = lastName;
    this.age = age;
}

function ViewModel() {
    var self = this;

    // Observable array to hold our data
    self.people = ko.observableArray([
        new Person("John", "Doe", 30),
        new Person("Jane", "Smith", 25)
    ]);

    // Function to add new person
    self.addPerson = function () {
        self.people.push(new Person("New", "Person", Math.floor(Math.random() * 50) + 18));
    };
}

ko.applyBindings(new ViewModel());