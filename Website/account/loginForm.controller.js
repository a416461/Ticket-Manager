(function() {
    'use strict';

    angular
        .module('earlybirds')
        .controller('loginFormController', loginFormController);

    loginFormController.$inject = ['$window', 'authenticationService'];

    function loginFormController($window, authenticationService) {
        var vm = this;
        vm.email;
        vm.password;
        vm.submit = submit;

        function submit() {
            authenticationService.login(vm.email, vm.password).then(onSuccess, onFail);

            function onSuccess(account) {
                if (account == null) {
                    console.error('User was not authenticated.');
                }
                else {
                    $window.location.href = '/app/dashbaord';
                    console.log(account.type);
                }
            }

            function onFail() {
                console.error('Server error.');
            }
        }
    }
}());