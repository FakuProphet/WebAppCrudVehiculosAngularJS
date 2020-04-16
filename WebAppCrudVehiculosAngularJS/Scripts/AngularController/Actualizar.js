var app = angular.module('miApp', []);

    
    app.controller('HomeUpdateAngularController', function ($scope, $http, $location) {


        app.config(['$locationProvider', function ($locationProvider) {
            $locationProvider.html5Mode(true);
        }]);

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
                var yourId = $location.search().id;
                console.log(id + ' Esta es mi id');
                $scope.vehiculo = response.data;
            }, function (error) {

            });

        };

        function getUrlParameters() {
            var pairs = window.location.search.substring(1).split(/[&?]/);
            var res = {}, i, pair;
            for (i = 0; i < pairs.length; i++) {
                pair = pairs[i].split('=');
                if (pair[1])
                    res[decodeURIComponent(pair[0])] = decodeURIComponent(pair[1]);
            }
            return res;
        }

        console.log(getUrlParameters() + ' Esta es mi url');

      
    });