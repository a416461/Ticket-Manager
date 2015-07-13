(function() {
    'use strict';

    angular
        .module('earlybirds')
        .controller('ticketsController', ticketsController);

    ticketsController.$inject = ['ticketService', 'categoryService'];

    function ticketsController(ticketService, categoryService) {
        var vm = this;
        vm.tickets = [];
        vm.availableSortingOptions = [];
        vm.primarySortingOption = 'Sorting Options';
        vm.secondarySortingOption = 'Value Options';

        activate();

        function activate() {
            ticketService.getTickets()
                .then(function(response) {
                    vm.tickets = response;
                });

            categoryService.getCategories()
                .then(function(response) {
                    vm.availableSortingOptions = [{ name: 'Sorting Options', values: ['Value Options'] }, { name: 'Category', values: response.map(function(i) { return i.name }) }, { name: 'Priority', values: ['High', 'Medium', 'Low', 'Low to High', 'High to Low'] }, { name: 'Status', values: ['Open', 'Closed', 'Open to Closed', 'Closed to Open'] }];
                });
        }
    }
}());