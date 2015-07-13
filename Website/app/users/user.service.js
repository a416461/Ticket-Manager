(function() {
    'use strict';

    angular
        .module('earlybirds')
        .factory('userService', userService);

    userService.$inject = ['$http'];

    function userService($http) {
        var service = {
            getUsers: getUsers,
            getUser: getUser,
            updateUserInfo: updateUserInfo,
            createUser: createUser,
            deleteUser: deleteUser
        };
        return service;

        function getUsers() {
            return $http.get('http://localhost:2001/users')
            .then(function(response) { return response.data; });
        }

        function getUser(userId) {
            return $http.get('http://localhost:2001/users/' + userId)
            .then(function(response) { return response.data; });
        }

        function updateUserInfo(userId, user) {
            return $http.put('http://localhost:2001/users/' + userId, user)
            .then(function(response) { return response.data; });
        }

        function createUser(user) {
            return $http.post('http://localhost:2001/users', user)
            .then(function(response) { return response.data; });
        }

        function deleteUser(userId) {
            return $http.delete('http://localhost:2001/users/' + userId)
            .then(function(response) { return response.data; });
        }
    }
}());