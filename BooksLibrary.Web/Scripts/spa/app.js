﻿(function () {
    'use strict';
    angular.module('booksLibrary', ['common.core', 'common.ui'])
        .config(config)
        .run(run);

    config.$inject = ['$routeProvider'];

    function config($routeProvider) {
        $routeProvider
            .when("/", {
                templateUrl: "scripts/spa/home/index.html", controller: "indexCtrl"
            })
            .when("/login", {
                templateUrl: "scripts/spa/account/login.html", controller: "loginCtrl"
            })
            .when("/register", {
                templateUrl: "scripts/spa/account/register.html", controller: "registerCtrl"
            })
            .when("/books", {
                templateUrl: "scripts/spa/books/index.html", controller: "booksCtrl"
            })
            .when("/books/add", {
                templateUrl: "scripts/spa/books/add.html", controller: "bookAddCtrl"
            })
            .when("/books/:id", {
                templateUrl: "scripts/spa/books/details.html", controller: "bookDetailsCtrl"
            })
            .when("/books/edit/:id", {
                templateUrl: "scripts/spa/books/edit.html", controller: "bookEditCtrl"
            })
            .otherwise({ redirectTo: "/" });
    }

    run.$inject = ['$rootScope', '$location', '$cookieStore', '$http'];

    function run($rootScope, $location, $cookieStore, $http) {
        $rootScope.repository = $cookieStore.get('repository') || {};
        if ($rootScope.repository.loggedUser) {
            $http.defaults.headers.common['Authorization'] = $rootScope.repository.loggedUser.authdata;
        }

        $(document).ready(function () {
            $(".fancybox").fancybox({
                openEffect: 'none',
                closeEffect: 'none'
            });
            $('.fancybox-media').fancybox({
                openEffect: 'none',
                closeEffect: 'none',
                helpers: { media: {} }
            });
            $('[data-toggle=offcanvas]').click(
                function () {
                    $('.row-offcanvas').toggleClass('active');
                });
        });
    }
    isAuthenticated.$inject = ['membershipService', '$rootScope', '$location'];

    function isAuthenticated(membershipService, $rootScope, $location) {
        if (!membershipService.isUserLoggedIn()) {
            $rootScope.previousState = $location.path();
            $location.path('/login');
        }
    }

})();