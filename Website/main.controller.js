(function() {
    'use strict';

    angular
        .module('earlybirds')
        .controller('mainController', mainController);

    mainController.$inject = ['authenticationService'];

    function mainController(authenticationService) {
        var main = this;
        main.User = {};
        main.logout = authenticationService.logout;

        activate();

        function activate() {
            main.User = authenticationService.getAuthenticatedAccount();
        };
    }
}());