(function() {
    'use strict';

    angular
        .module('earlybirds')
        .directive('categoryListItem', categoryListItem);

    function categoryListItem() {
        return {
            restrict: 'E',
            replace: 'true',
            templateUrl: '/app/categories/directives/category-list-item.directive.html',
            scope: {
                category: '='
            }
        }
    }
}());