(function() {
    'use strict';

    angular
        .module('earlybirds')
        .controller('categoryController', categoryController);

    categoryController.$inject = ['$routeParams', '$route', '$window', 'categoryService'];

    function categoryController($routeParams, $route, $window, categoryService) {
        var vm = this;
        vm.category = {};
        vm.deleteCategory = deleteCategory;
        vm.updateCategory = updateCategory;

        activate();

        function updateCategory(name) {
            categoryService.updateCategory($routeParams.categoryId, {'name': name})
            .then(function() { $route.reload(); });
        }

        function deleteCategory() {
            categoryService.deleteCategory($routeParams.categoryId)
            .then(function() { $window.location.href = '/app/categories'; });
        }

        function activate() {
            categoryService.getCategory($routeParams.categoryId)
                .then(function(response) {
                    vm.category = response;
                });
        }
    }
}());