(function() {
    'use strict';

    angular
        .module('earlybirds')
        .controller('editCategoryController', editCategoryController);

    editCategoryController.$inject = ['$window', '$routeParams', 'ticketService', 'categoryService', 'authenticationService'];

    function editCategoryController($window, $routeParams, ticketService, categoryService, authenticationService) {
        var vm = this;
        vm.category = {};
        vm.editCategory = editCategory;

        activate();

        function editCategory(name) {
            var account = authenticationService.getAuthenticatedAccount();
            return categoryService.editCategory(vm.category.id, { 'name': name })
            .then(function() { $window.location.href = '/app/categories'; });
        }

        function activate() { } {
            categoryService.getCategory($routeParams.categoryId)
            .then(function(response) {
                vm.category = response;
            })
        }
    }
}());