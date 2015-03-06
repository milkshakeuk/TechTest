angular.module('techTest').config(['$routeProvider', function ($routeProvider) {
    $routeProvider.
        when('/people', {
            templateUrl: 'App/partials/people.html',
            controller: 'peopleCtrl'
        }).
        when('/people/:id', {
            templateUrl: 'App/partials/person.html',
            controller: 'personCtrl'
        }).
        otherwise({ redirectTo: '/people' });
}]);