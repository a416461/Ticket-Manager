(function() {
    'use strict';

    angular
        .module('earlybirds')
        .factory('categoryService', categoryService);

    categoryService.$inject = ['$http'];

    function categoryService($http) {
        var service = {
            getCategories: getCategories,
            getCategory: getCategory,
            createCategory: createCategory,
            editCategory: editCategory,
            deleteCategory: deleteCategory
        };
        return service;

        function getCategories() {
            return $http.get('http://localhost:2001/categories')
            .then(function(response) { return response.data; });
        }

        function getCategory(categoryId) {
            return $http.get('http://localhost:2001/categories/' + categoryId)
            .then(function(response) { return response.data; });
        }

        function createCategory(category) {
            return $http.post('http://localhost:2001/categories', category)
            .then(function(response) { return response.data; });
        }

        function editCategory(categoryId, category) {
            return $http.put('http://localhost:2001/categories/' + categoryId, category)
            .then(function(response) { return response.data; });
        }

        function deleteCategory(categoryId) {
            return $http.delete('http://localhost:2001/categories/' + categoryId)
            .then(function(response) { return response.data; });
        }
    }
}());