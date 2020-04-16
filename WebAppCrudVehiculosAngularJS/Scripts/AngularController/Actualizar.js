angular.module('miApp', [])
    .controller('HomeUpdateAngularController', function ($scope, $http) {

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
            }).error(function () {
                alert('Error');
            })

        };
      
        $scope.getVehiculo = function (id) {
            $http({
                method: 'GET',
                url: "/Home/GetVehiculoById?id=" + id
            }).then(function (response) {
                console.log(response.data);
                $scope.vehiculo = response.data;
            }, function (error) {

            });

        };



    });