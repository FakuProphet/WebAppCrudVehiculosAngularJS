    angular.module('miApp',[])
    .controller('HomeAngularController', function ($scope, $http,$location) {

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
                window.location.href = "/Home/Listado";
            }).error(function () {
                alert('Error');
            })

        };


       





        $scope.vehiculos = [];
        $http({
            method: 'GET',
            url: '/Home/GetListado'

        }).then(function (response) {
            console.log(response.data);
            $scope.vehiculos = response.data;
        }, function (error) {

        });


        $scope.getVehiculo = function (dominio) {
            $http({
                method: 'GET',
                url: "/Home/GetVehiculo?dominio=" + dominio
            }).then(function (response) {
                console.log(response.data);
                $scope.vehiculo = response.data[0];
            }, function (error) {

            });

        };
        
        

    });