$(document).ready(function () {
    initialize();
});

function Note() {  // Constructor functions should start with capital letter by convention
    var self = this;

    self.id = ko.observable('');
    self.title = ko.observable('');
    self.content = ko.observable('');

    self.saveNote = function () {  // Moved the save functionality into a method
        var data = {
            id: self.id(),
            title: self.title(),
            content: self.content()
        };

        displayLoader();
        connector.Post("/NoteBook/CreateNote", data, function (res) {
            hideLoader();
            // You might want to do something with the response here
        });
    };
}

function initialize() {
    var vm = new Note();  // Use the capitalized constructor name
    ko.applyBindings(vm);
}