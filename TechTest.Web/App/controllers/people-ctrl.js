angular.module('techTest').controller('peopleCtrl', ['$scope', '$http', 'person', function ($scope, $http, person) {

    $scope.people = [];

    $scope.init = function(){
        $http.get('api/people').then(function (result) {
            $scope.people = result.data.map(person.create);
        });
    };

    $scope.init();

}]);