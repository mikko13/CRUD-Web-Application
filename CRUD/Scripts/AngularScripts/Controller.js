app.controller("CRUDController", function ($scope, CRUDService) {
    $scope.people = [];

    $scope.loadPeople = function () {
        CRUDService.getAll().then(function (response) {
            $scope.people = response.data;
        });
    };

    $scope.createPerson = function () {
        CRUDService.create($scope.newPerson).then(function () {
            $scope.loadPeople();
            $scope.newPerson = {};
        });
    };

    $scope.updatePerson = function () {
        CRUDService.update($scope.selectedPerson).then(function () {
            $scope.loadPeople();
        });
    };

    $scope.deletePerson = function (id) {
        CRUDService.delete(id).then(function () {
            $scope.loadPeople();
        });
    };

    $scope.loadPeople();
});


