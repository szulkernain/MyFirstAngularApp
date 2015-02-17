(function() {
    var firstApp = angular.module('firstApp', []);

    firstApp.config(['$httpProvider', function ($httpProvider) {
        delete $httpProvider.defaults.headers.common["X-Requested-With"];
    }]);

    firstApp.controller('EmailsController', function($scope, $http) {
        $http.get('/Home/GetEmails').success(function (data, status, headers, config) {
            $scope.emails = data;
        });
    });

    firstApp.controller("NewEmailController", function ($scope, $http) {

        $scope.email = {};
        $scope.confirmation = '';

        $scope.SendEmail = function() {
            $http.post('/Home/SendEmail', $scope.email)
                .success(function(data, status, header, config) {
                    $scope.confirmation = 'Email was sent successfully';
                })
                .error(function(data, status, header, config) {
                    $scope.confirmation = 'Email sending failed';
                });
        };
    });
})();