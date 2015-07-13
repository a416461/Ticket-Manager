(function() {
    'use strict';

    angular
        .module('earlybirds')
        .directive('ticketListItem', ticketListItem);

    function ticketListItem() {
        return {
            restrict: 'E',
            replace: 'true',
            templateUrl: '/app/tickets/directives/ticket-list-item.directive.html',
            scope: {
                ticket: '='
            }
        }
    }
}());