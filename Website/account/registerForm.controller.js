(function() {
    'use strict';

    angular
        .module('app')
        .controller('registerFormController', registerFormController);

    registerFormController.$inject = ['$scope', 'authenticationService', '$location'];

    function registerFormController($scope, authenticationService, $location) {
        $scope.email;
        $scope.password;
        $scope.submit = submit;

        function submit() {
            authenticationService.login($scope.email, $scope.password).then(onSuccess, onFail);

            function onSuccess(user) {
                if (user == null) {
                    console.error('User was not authenticated.');
                }
                else {
                    $location.path('/app/dashboard');
                }
            }

            function onFail() {
                console.error('Server error.');
            }
        }
    }
}());