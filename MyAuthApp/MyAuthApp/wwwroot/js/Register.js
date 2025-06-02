$(document).ready(function () {
    initialize();
});


function RegisterViewModel() {
    var self = this;

    

    self.firstName = ko.observable('');
    self.lastName = ko.observable('');
    self.email = ko.observable('');
    self.userName = ko.observable('');
    self.password = ko.observable('');

    self.register = function () {

        var data = {
            firstName: self.firstName(),
            lastName: self.lastName(),
            email: self.email(),
            userName: self.userName(),
            password: self.password()
        };

        connector.Post("/Account/Register", data, function (response) {
            window.location.href = "/Account/Login";
        });
    };
}

function initialize() {
    vm = new RegisterViewModel();
    ko.applyBindings(vm);

}