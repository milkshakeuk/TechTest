angular.module('techTest').factory('person', function () {

    var person = function (personId, firstName, lastName, isAuthorised, isValid, isEnabled, colours) {
        this.personId = personId;
        this.firstName = firstName;
        this.lastName = lastName;
        this.isAuthorised = isAuthorised;
        this.isValid = isValid;
        this.isEnabled = isEnabled;
        this.colours = colours;
    };

    person.prototype.getFullName = function () {
        return this.firstName + ' ' + this.lastName;
    };

    person.prototype.nameIsPalindrome = function () {
        var name = (this.firstName + this.lastName).toLowerCase(),
            eman = name.split("").reverse().join("");

        return name === eman;
    };

    person.prototype.addColour = function (colour){
        var hasColour = this.hasColour(colour);

        if(hasColour.result){
            this.colours.splice(hasColour.index, 1);
        }else{
            this.colours.push(colour);
        }

    };

    person.prototype.hasColour = function (colour) {
        var result = {result: false, index: -1};
        angular.forEach(this.colours, function(v, k){
            if(colour.colourId === v.colourId){
                result.result = true;
                result.index = k;
            }
        });

        return result;

    };

    person.create = function (data) {
        return new person(
            data.personId,
            data.firstName,
            data.lastName,
            data.isAuthorised,
            data.isValid,
            data.isEnabled,
            data.colours
            );
    };

    return person;

});