(function () {
    'use strict';
    angular.module('booksLibrary', ['common.core', 'common.ui'])
        .config(config);

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
})();