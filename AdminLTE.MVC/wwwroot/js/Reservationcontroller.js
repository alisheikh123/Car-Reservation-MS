var app = angular.module("resApp", []);
app.controller("ReservationCtrl", function ($http, $scope) {
    $http.get('/Reservation/getCountry').then(function (d)
    {
        $scope.countrylist = d.data;
        
        $scope.email = "Ali@gmail.com";

    },  function ()
        {
            alert('Not Exist');
    });

    $scope.state = function () {
        $http.get('/Reservation/getState?country_Id' + $scope.CountryId).then(function (d) {
            $scope.statelist = d.data;

        });
    };

});