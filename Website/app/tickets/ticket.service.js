(function() {
    'use strict';

    angular
        .module('earlybirds')
        .factory('ticketService', ticketService);

    ticketService.$inject = ['$http'];

    function ticketService($http) {
        var service = {
            getTickets: getTickets,
            getTicket: getTicket,
            getTicketUpdates: getTicketUpdates,
            updateTicket: updateTicket,
            editTicket: editTicket,
            createTicket: createTicket,
            closeTicket: closeTicket
        };
        return service;

        function getTickets() {
            return $http.get('http://localhost:2001/tickets')
            .then(function(response) { return response.data; });
        }

        function getTicket(ticketId) {
            return $http.get('http://localhost:2001/tickets/' + ticketId)
            .then(function(response) { return response.data; });
        }

        function getTicketUpdates(ticketId) {
            return $http.get('http://localhost:2001/tickets/' + ticketId + '/updates')
            .then(function(response) { return response.data; });
        }

        function updateTicket(ticketId, update) {
            return $http.post('http://localhost:2001/tickets/' + ticketId + '/updates', update)
            .then(function(response) { return response.data; });
        }

        function editTicket(ticketId, ticket) {
            return $http.put('http://localhost:2001/tickets/' + ticketId, ticket)
            .then(function(response) { return response.data; });
        }

        function createTicket(ticket) {
            return $http.post('http://localhost:2001/tickets', ticket)
            .then(function(response) { return response.data; });
        }

        function closeTicket(ticketId, userId) {
            return $http.delete('http://localhost:2001/tickets/' + ticketId)
            .then(function(response) { return response.data; });
        }
    }
}());