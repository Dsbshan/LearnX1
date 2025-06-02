$(document).ready(function () {
    initialize();
    getUserByEmail();
});

function Login() {
    var self = this;

    self.email = ko.observable('');
    self.password = ko.observable('');

    self.login = function () {
        var data = {
            email: self.email(),
            password: self.password()
        };

        displayLoader();
        connector.Post("/Account/Login", data, function (response) {
            window.location.href = "/Home/Index";
            hideLoader();
        });
    };
}

function getUserByEmail() {
    if (!vm || !vm.email()) return;

    displayLoader();
    connector.Get(`/Account/GetUserByEmail?email=${vm.email()}`, function (data) {
        console.log(data); // Corrected from 'response' to 'data'
        hideLoader();
    });
}

function initialize() {
    vm = new Login();
    ko.applyBindings(vm);
}