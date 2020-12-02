var app = angular.module("resApp", []);
app.controller("ReservationCtrl", function ($http, $scope) {
    $http.get('/Reservation/getCountry').then(function (d)
    {
        $scope.countrylist = d.data;

    }, function ()
        {
            alert('Not Exist');
        });

});