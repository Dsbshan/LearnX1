
function AppViewModel() {
    var self = this;

    // Observable properties
    self.isLoaded = ko.observable(false);
    self.tasks = ko.observableArray([]);
    self.newTaskText = ko.observable("");

    // Computed properties
    self.completedTasks = ko.computed(function () {
        return self.tasks().filter(function (task) {
            return task.isDone();
        });
    });

    // Methods
    self.addTask = function () {
        if (self.newTaskText().trim() !== "") {
            self.tasks.push({
                title: self.newTaskText(),
                isDone: ko.observable(false)
            });
            self.newTaskText("");
        }
    };

    self.addTaskOnEnter = function (data, event) {
        if (event.keyCode === 13) { // Enter key
            self.addTask();
        }
        return true;
    };

    self.removeTask = function (task) {
        self.tasks.remove(task);
    };

    // Simulate loading data (in a real app, this might be an AJAX call)
    setTimeout(function () {
        // Initial data
        var initialTasks = [
            { title: "Learn Knockout.js", isDone: ko.observable(true) },
            { title: "Build a sample app", isDone: ko.observable(false) },
            { title: "Explore more features", isDone: ko.observable(false) }
        ];
        self.tasks(initialTasks);
        self.isLoaded(true);
    }, 1000);
}

// Apply bindings when the DOM is ready
document.addEventListener("DOMContentLoaded", function () {
    ko.applyBindings(new AppViewModel());
});