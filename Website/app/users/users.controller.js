(function() {
    'use strict';

    angular
        .module('earlybirds')
        .controller('usersController', usersController);

    usersController.$inject = ['userService'];

    function usersController(userService) {
        var vm = this;
        vm.users = {};

        activate();

        function activate() {
            userService.getUsers()
                .then(function(response) {
                    vm.users = response;
                });
        }
    }
}());