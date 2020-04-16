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


        
        $scope.getVehiculo = function () {
            $http({
                method: 'GET',
                url:$location.search().id
            }).then(function (response) {
                console.log(response.data);
                
                //$scope.clave = miId;
                console.log($location.search().id + ' Esta es mi id');
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