// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
angular.module("myApp", []).run(function ($routeScope) {
    $routeScope.color = "Blue"

}).controller("myCt", function ($scope) {
    $scope.FirstName = "Ali",
        $scope.LastName = "Tahir",
        $scope.Name = "Happy Birthday",
        $scope.color = "Green",
        $scope.changename = function () {
        $scope.Name = "Happy Birthday Ali! :-)"
        };
        
        $scope.Sum = function () {
            return $scope.FirstName + " " + $scope.LastName;

        };

    });
    