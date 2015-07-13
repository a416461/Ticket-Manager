(function() {
    'use strict';

    angular
        .module('earlybirds')
        .factory('authenticationService', authenticationService);

    authenticationService.$inject = ['$http', 'userService'];

    function authenticationService($http, userService) {

        var service = {
            login: login,
            logout: logout,
            getAuthenticatedAccount: getAuthenticatedAccount,
        };
        return service;

        function login(email, password) {
            return $http.get('http://localhost:2001/login?email=' + email + '&password=' + password)
            .then(onSuccess, onFail);

            function onSuccess(response) {
                sessionStorage.setItem('account', angular.toJson(response.data));
                return response.data;
            }

            function onFail(response) {
                logout();
                return null;
            }
        }

        function getAuthenticatedAccount() {
            return angular.fromJson(sessionStorage.getItem('account'));
        }

        function logout() {
            sessionStorage.setItem('account', null);
            window.location.href = "/";
        }
    }
}());