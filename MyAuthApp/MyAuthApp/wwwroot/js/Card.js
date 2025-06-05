$(document).ready(function () {
    initialize();
    GetmoduleLists();
});

function CardViewModel() {
    var self = this;

    self.moduleListTypes = ko.observableArray([]);
    self.moduleListTypeId = ko.observable();
    
}



function GetmoduleLists() {
    displayLoader();
    connector.Get(`/Dashboard/GetModulesLists`, function (data) {
        hideLoader();
        vm.moduleListTypes(data);
    });
}
function initialize() {
    vm = new CardViewModel();
    ko.applyBindings(vm);
}
