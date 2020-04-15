    angular.module('miApp',[])
    .controller('HomeAngularController', function ($scope, $http) {

        $scope.btn = "Save";
        $scope.saveData = function () {
            $scope.btn = "Wait...";
            $http({
                method: 'POST',
                url: '/Home/AgregarVehiculo',
                data: $scope.Vehiculo
            }).then(function (response) {
                $scope.btn = "Save";
                data: $scope.Vehiculo = null;
                alert(response.data);
            }).error (function() {
                alert('Error');
            })

        }


        $scope.vehiculos = [];
        $http({
            method: 'GET',
            url: '/Home/Listado'

        }).then(function (response) {
            console.log(response.data);
            $scope.vehiculos = response.data;
        }, function (error) {

        });




    });