$(function () {
    debugger;

    ko_test_bindSingle();

    ko_test_bindArray();

    ko_test_uncleTomSelect();
});

function ko_test_bindSingle() {

    var myViewModel_old = {
        personName: 'Bob',
        personAge: 123
    };

    var myViewModel = {
        personName: ko.observable('Bob'),
        personAge: ko.observable(123)
    };
    ko.applyBindings(myViewModel, document.getElementById('myspan'));
}

function ko_test_bindArray() {
    debugger;
    // demo 1
    var myObservableArray = ko.observableArray();

    myObservableArray.push('Some value');

    var anotherObservableArray = ko.observableArray([
        { name: "Bungle", type: "Bear" },
        { name: "George", type: "Hippo" },
        { name: "Zippy", type: "Unknown" }
    ]);

    alert('The length of the array is ' + myObservableArray().length);
    alert('The first element is ' + myObservableArray()[0]);
    // demo 1 end

    // demo 2 begin
    var SimpleListModel = function (items) {
        this.items = ko.observableArray(items);
        this.itemToAdd = ko.observable("");
        this.addItem = function () {
            if (this.itemToAdd() != "") {
                this.items.push(this.itemToAdd()); // Adds the item. Writing to the "items" observableArray causes any associated UI to update. 
                this.itemToAdd(""); // Clears the text box, because it's bound to the "itemToAdd" observable 
            }
        }.bind(this); // Ensure that "this" is always this view model 
    };

    ko.applyBindings(new SimpleListModel(["Alpha", "Beta", "Gamma"]), document.getElementById('myform'));
    // demo 2 end

}

function ko_test_uncleTomSelect() {
    debugger;

    var availableMeals = [
        { mealName: 'Standard', description: 'Dry crusts of bread', extraCost: 0 },
        { mealName: 'Premium', description: 'Fresh bread with cheese', extraCost: 9.95 },
        { mealName: 'Deluxe', description: 'Caviar and vintage Dr Pepper', extraCost: 18.50 }
    ];

    var viewModel = {
        availableMeals: availableMeals,
        chosenMeal: ko.observable(availableMeals[0]),
    };

    ko.applyBindings(viewModel, document.getElementById('uncleTomDiv'));
}

function formatPrice(price) {
    return price == 0 ? "Free" : "$" + price.toFixed(2);
}
