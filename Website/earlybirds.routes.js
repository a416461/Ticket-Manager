(function() {
    'use strict';

    angular
        .module('earlybirds')
        .config(config)
        .run(check);

    config.$inject = ['$routeProvider', '$locationProvider'];

    function config($routeProvider, $locationProvider) {
        $routeProvider
        .when('/', {
            templateUrl: 'homepage.html'
        })
        .when('/login', {
            templateUrl: 'login.html',
            controller: 'loginFormController',
            controllerAs: 'vm'
        })
        .when('/register', {
            templateUrl: 'register.html'
        })
        .when('/app/dashboard', {
            templateUrl: '/app/dashboard/dashboard.html'
        })
        .when('/app/tickets', {
            templateUrl: '/app/tickets/tickets.html',
            controller: 'ticketsController',
            controllerAs: 'vm'
        })
        .when('/app/tickets/new', {
            templateUrl: '/app/tickets/newTicket.html',
            controller: 'newTicketController',
            controllerAs: 'vm'
        })
        .when('/app/tickets/:ticketId', {
            templateUrl: '/app/tickets/ticket.html',
            controller: 'ticketController',
            controllerAs: 'vm'
        })
        .when('/app/tickets/:ticketId/edit', {
            templateUrl: '/app/tickets/editTicket.html',
            controller: 'editTicketController',
            controllerAs: 'vm'
        })
        .when('/app/tickets/:ticketId/update', {
            templateUrl: '/app/tickets/updateTicket.html',
            controller: 'ticketController',
            controllerAs: 'vm'
        })
        .when('/app/categories', {
            templateUrl: '/app/categories/categories.html',
            controller: 'categoriesController',
            controllerAs: 'vm'
        })
        .when('/app/categories/new', {
            templateUrl: '/app/categories/newCategory.html',
            controller: 'newCategoryController',
            controllerAs: 'vm'
        })
        .when('/app/categories/:categoryId', {
            templateUrl: '/app/categories/category.html',
            controller: 'categoryController',
            controllerAs: 'vm'
        })
        .when('/app/categories/:categoryId/edit', {
            templateUrl: '/app/categories/editCategory.html',
            controller: 'editCategoryController',
            controllerAs: 'vm'
        })
        .when('/app/conversations', {
            templateUrl: '/app/conversations/conversations.html'
        })
        .when('/app/account', {
            templateUrl: '/app/account/account.html'
        })
        .when('/app/conversations', {
            templateUrl: '/app/conversations/conversations.html'
        })
        .when('/app/users', {
            templateUrl: '/app/users/users.html',
            controller: 'usersController',
            controllerAs: 'vm'
        })
        .when('/app/users/new', {
            templateUrl: '/app/users/newUser.html',
            controller: 'newUserController',
            controllerAs: 'vm'
        })
        .when('/app/users/:userId', {
            templateUrl: '/app/users/user.html',
            controller: 'userController',
            controllerAs: 'vm'
        })
        .otherwise({
            redirectTo: '/app/dashboard'
        });

        $locationProvider.html5Mode(true);
    }

    check.$inject = ['$rootScope', '$location', 'authenticationService'];

    function check($rootScope, $location, authenticationService) {
        $rootScope.$on('$routeChangeStart', function() {
            var account = authenticationService.getAuthenticatedAccount();

            if (account === null && (window.location.href.indexOf('app') > -1)) {
                window.location.href = "/";
                console.log('Route Unauthenticated');
            } else {
                console.log('Route Authenticated');
            }
        });
    }
}());
