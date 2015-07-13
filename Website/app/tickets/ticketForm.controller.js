(function() {
    'use strict';

    angular
        .module('earlybirds')
        .controller('ticketFormController', ticketFormController);

    ticketFormController.$inject = ['$routeParams', 'ticketService'];

    function ticketFormController($routeParams, ticketService) {
        var vm = this;
        vm.tickets = {};

        activate();

        function activate() {
            ticketService.getTickets()
                .then(function(response) {
                    vm.tickets = response;
                });
        }
    }
}());