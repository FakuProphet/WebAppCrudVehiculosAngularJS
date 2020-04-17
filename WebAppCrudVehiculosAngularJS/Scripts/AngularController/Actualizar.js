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
                url: '/Home/ActualizarVehiculo',
                data: $scope.Vehiculo
            }).then(function (response) {
                $scope.btn = "Save";
                data: $scope.Vehiculo = null;
                alert(response.data);
                $location.path("/Home/Listado");
            }).error(function () {
                alert('Error');
            })

        };


        
        const ob =getUrlParameters()
        
        $scope.getVehiculo = function () {
            $http({
                method: 'GET',
                url: '/Home/GetVehiculoById?id=' + Object.values(ob)
                
            }).then(function (response) {
                console.log(response.data);
                console.log(Object.values(ob) + ' Esta es mi id por metodo');
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