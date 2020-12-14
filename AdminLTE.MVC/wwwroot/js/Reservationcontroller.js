var app = angular.module("resApp", []);
app.controller("ReservationCtrl", function ($http, $scope) {
    $.http.get('/Reservation/getCity').then(function (rec) {
        $scope.citylist = rec.data;

    });  

    $scope.getstate = function () {
        $http.get('/Reservation/getState?stateid' + $scope.CityId).then(function (d) {
            $scope.statelist = d.data;
        });
    };
$http.get('/Reservation/getCountry').then(function (d)
    {
        $scope.countrylist = d.data;
        
        $scope.email = "Ali@gmail.com";

    },  function ()
        {
            alert('Not Exist');
    });


});