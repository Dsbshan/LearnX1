function Task(data) {
    this.Id = data.Id;
    this.Name = data.Name;
}

function TaskViewModel() {
    var self = this;

    self.tasks = ko.observableArray([]);
    self.newTask = ko.observable("");

    self.addTask = function () {
        if (self.newTask().trim() !== "") {
            var task = new Task({ Id: self.tasks().length + 1, Name: self.newTask() });
            self.tasks.push(task);
            self.newTask("");
        }
    };

    self.removeTask = function (task) {
        self.tasks.remove(task);
    };

    // Load tasks from server
    self.loadTasks = function () {
        $.getJSON('/Task/GetTasks', function (data) {
            var mappedTasks = $.map(data, function (item) { return new Task(item); });
            self.tasks(mappedTasks);
        });
    };

    self.loadTasks();
}

ko.applyBindings(new TaskViewModel());
