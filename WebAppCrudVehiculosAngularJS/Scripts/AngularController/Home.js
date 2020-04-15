angular.module('app')
    .controller('HomeController', function ($scope, $http) {

        $scope.btnText = "Save";
        $scope.saveData = function () {
            $http({
                method: 'POST',
                url: '/Home/AgregarVehiculo',
                data: $scope.Vehiculo
            }).then(function (response) {
                $scope.btnText = "Save";
                data: $scope.Vehiculo = null;
                alert(response);
            }, function (error) {
                alert(error);
            })

        }
    });