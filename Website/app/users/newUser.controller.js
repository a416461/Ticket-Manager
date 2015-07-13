(function() {
    'use strict';

    angular
        .module('earlybirds')
        .controller('newUserController', newUserController);

    newUserController.$inject = ['$window', 'userService', 'authenticationService'];

    function newUserController($window, userService, authenticationService) {
        var vm = this;
        vm.createNewUser = createNewUser;

        activate();

        function createNewUser(firstName, lastName, email, password) {
            var account = authenticationService.getAuthenticatedAccount();
            return userService.createUser({ 'firstName': firstName, 'lastName': lastName, 'email': email, 'password': password, 'businessId': account.businessId })
            .then(function() { $window.location.href = '/app/users'; });
        }

        function activate() {
        }
    }
}());