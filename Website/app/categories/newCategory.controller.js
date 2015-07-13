(function() {
    'use strict';

    angular
        .module('earlybirds')
        .controller('newCategoryController', newCategoryController);

    newCategoryController.$inject = ['$window', 'categoryService', 'authenticationService'];

    function newCategoryController($window, categoryService, authenticationService) {
        var vm = this;
        vm.businessId;
        vm.createNewCategory = createNewCategory;

        function createNewCategory(name) {
            var account = authenticationService.getAuthenticatedAccount();
                categoryService.createCategory({ 'name': name, 'businessId': account.businessId })
                .then(function() { $window.location.href = '/app/categories'; });
        }
    }
}());