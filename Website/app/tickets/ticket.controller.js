(function() {
    'use strict';
    
    angular
        .module('earlybirds')
        .controller('ticketController', ticketController);

    ticketController.$inject = ['$routeParams', '$window', '$route', 'ticketService', 'authenticationService'];

    function ticketController($routeParams, $window, $route, ticketService, authenticationService) {
        var vm = this;
        vm.filters = [];
        vm.ticket = {};
        vm.updates = {};
        vm.updateTicket = updateTicket;
        vm.closeTicket = closeTicket;

        activate();

        function updateTicket(content) {
            var account = authenticationService.getAuthenticatedAccount();
            return ticketService.updateTicket($routeParams.ticketId, { 'content': content, 'creatorId': account.id })
            .then(function() { $route.reload(); });
        }

        function closeTicket() {
            ticketService.closeTicket($routeParams.ticketId)
            .then(function() { $window.location.href = '/app/tickets'; });
        }

        function activate() {
            ticketService.getTicket($routeParams.ticketId)
                .then(function(response) {
                    vm.ticket = response;
                });
            ticketService.getTicketUpdates($routeParams.ticketId)
                .then(function(response) {
                    vm.updates = response;
                });
        }
    }
}());