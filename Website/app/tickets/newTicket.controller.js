(function() {
    'use strict';

    angular
        .module('earlybirds')
        .controller('newTicketController', newTicketController);

    newTicketController.$inject = ['$window', 'ticketService', 'categoryService', 'authenticationService'];

    function newTicketController($window, ticketService, categoryService, authenticationService) {
        var vm = this;
        vm.categories = {};
        vm.createNewTicket = createNewTicket;

        activate();

        function createNewTicket(title, priority, categoryId, content) {
            var account = authenticationService.getAuthenticatedAccount();
            return ticketService.createTicket({ 'title': title, 'priority': priority, 'categoryId': categoryId, 'content': content, 'creatorId': account.id })
            .then(function() { $window.location.href = '/app/tickets'; });
        }

        function activate() {
            categoryService.getCategories()
                .then(function(response) {
                    vm.categories = response;
                });
        }
    }
}());