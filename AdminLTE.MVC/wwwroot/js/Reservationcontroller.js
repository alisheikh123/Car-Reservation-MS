var app = angular.module("resApp", []);
app.controller("ReservationCtrl", function ($http, $scope) {
    $http.get('/Reservation/getCountry').then(function (data)
    {
        $scope.countrylist = data.data;

    }, function ()
        {
            alert('Not Exist');
        });

});