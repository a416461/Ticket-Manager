(function() {
    'use strict';

    angular
        .module('earlybirds')
        .controller('userController', userController);

    userController.$inject = ['$routeParams', '$window', '$route', 'userService', 'authenticationService'];

    function userController($routeParams, $window, $route, userService, authenticationService) {
        var vm = this;
        vm.user = {};
        vm.updateUser = updateUser;
        vm.deleteUser = deleteUser;

        activate();

        function updateUser(firstName, lastName, email, password) {
            return userService.updateUser($routeParams.userId, { 'firstName': firstName, 'lastName': lastName, 'email': email, 'password': password })
            .then(function() { $route.reload(); });
        }

        function deleteUser() {
            userService.deleteUser($routeParams.userId)
            .then(function() { $window.location.href = '/app/users'; });
        }

        function activate() {
            userService.getUser($routeParams.userId)
                .then(function(response) {
                    vm.user = response;
                });
        }
    }
}());