(function() {
    'use strict';

    angular
    .module('earlybirds')

    .filter('searchTickets', function() {

        return function(list, query) {

            if (!query) {
                return list;
            }

            var result = [];

            query = query.toLowerCase();

            angular.forEach(list, function(item) {

                if (item.title.toLowerCase().indexOf(query) !== -1) {
                    result.push(item);
                }
                else if (item.content.toLowerCase().indexOf(query) !== -1) {
                    result.push(item);
                }
                else if (item.priority.toLowerCase().indexOf(query) !== -1) {
                    result.push(item);
                }
                else if (item.category.toLowerCase().indexOf(query) !== -1) {
                    result.push(item);
                }
            });

            return result;
        };

    })

    .filter('searchCategories', function() {

        return function(list, query) {

            if (!query) {
                return list;
            }

            var result = [];

            query = query.toLowerCase();

            angular.forEach(list, function(item) {

                if (item.name.toLowerCase().indexOf(query) !== -1) {
                    result.push(item);
                }
            });

            return result;
        };

    })

    .filter('searchUsers', function() {

        return function(list, query) {

            if (!query) {
                return list;
            }

            var result = [];

            query = query.toLowerCase();

            angular.forEach(list, function(item) {

                var fullName = item.firstName + ' ' + item.lastName;

                if (fullName.toLowerCase().indexOf(query) !== -1) {
                    result.push(item);
                }
                else if (fullName.toLowerCase().indexOf(query) !== -1) {
                    result.push(item);
                }
            });

            return result;
        };

    });

}());