(function (app) {
    'use strict';

    app.controller('indexCtrl', indexCtrl);

    indexCtrl.$inject = ['$scope', '$location', 'apiService', 'notificationService'];

    function indexCtrl($scope, $location, apiService, notificationService) {
        $scope.pageClass = 'page-home';
        $scope.loadingBooks = true;
        $scope.loadingGenres = true;
        $scope.isReadOnly = true;
        $scope.latestBooks = [];

        apiService.get('/api/books/latest', null,
            booksLoadCompleted,
            booksLoadFailed);

        apiService.get("/api/genres/", null,
            genresLoadCompleted,
            genresLoadFailed);

        function booksLoadCompleted(result) {
            $scope.latestBooks = result.data;
            $scope.loadingBooks = false;
        }
        function genresLoadFailed(response) {
             notificationService.displayError(response.data);
        }
        function booksLoadFailed(response) {
             notificationService.displayError(response.data);
        }
        function genresLoadCompleted(result) {
            var genres = result.data;
            Morris.Bar({
                element: "genres-bar",
                data: genres,
                xkey: "Name",
                ykeys: ["NumberOfBooks"],
                labels: ["Number Of Books"],
                barRatio: 0.4,
                xLabelAngle: 55,
                hideHover: "auto",
                resize: 'true'
            });

            $scope.loadingGenres = false;
        }
    }
})(angular.module('booksLibrary'));