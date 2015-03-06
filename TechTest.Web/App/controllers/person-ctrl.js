angular.module('techTest').controller('personCtrl', ['$scope', '$http', '$routeParams','$location','person', function ($scope, $http, $routeParams, $location, person) {

    $scope.person = {};
    $scope.colours = [];

    $scope.init = function () {
        $http.get('api/people/'+$routeParams.id).then(function (result) {
            $scope.person = person.create(result.data);
        });

        $http.get('api/colour/').then(function (result) {
            $scope.colours = result.data;
        });

    };

    $scope.update = function () {
        $http.put('api/people/' + $routeParams.id, $scope.person).then(function () {
            $location.path('/people');
        });
    };

    $scope.cancel = function () {
        $location.path('/people');
    };

    $scope.hideCheckBox = function (id) {
        angular.element('#' + id).toggleClass('ng-hide');
    };

    $scope.init();

}]);