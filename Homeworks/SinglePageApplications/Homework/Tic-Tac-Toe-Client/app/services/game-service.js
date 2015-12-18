/*globals angular*/
(function () {
    'use strict';

    function GameService($http, $q, domain) {

        function createGame() {
            var deferred = $q.defer();

            $http.post(domain + 'api/games/create')
                .then(function (successResponse) {
                    deferred.resolve(successResponse);
                }, function (errorResponse) {
                    deferred.reject(errorResponse);
                });

            return deferred.promise;
        }

        function joinGame() {
            var deferred = $q.defer();

            $http.post(domain + 'api/games/join')
                .then(function (successResponse) {
                    deferred.resolve(successResponse);
                }, function (errorResponse) {
                    deferred.reject(errorResponse);
                });

            return deferred.promise;
        }

        function details(id) {
            var deferred = $q.defer();

            $http.get(domain + 'api/games/status?gameId=' + id)
                .then(function (successResponse) {
                    deferred.resolve(successResponse);
                }, function (errorResponse) {
                    deferred.reject(errorResponse);
                });

            return deferred.promise;
        }

        function play(tileRequest) {

            var deferred = $q.defer();

            $http.post(domain + 'api/games/play', tileRequest)
                .then(function (successResponse) {
                    deferred.resolve(successResponse);
                }, function (errorResponse) {

                    deferred.reject(errorResponse);
                });

            return deferred.promise;
        }

        function allGames() {
            var deferred = $q.defer();

            $http.get(domain + 'api/games/all')
                .then(function (successResponse) {
                    deferred.resolve(successResponse);
                }, function (errorResponse) {
                    deferred.reject(errorResponse);
                });

            return deferred.promise;
        }

        function getPrivateGames() {
            var deferred = $q.defer();

            $http.get(domain + 'api/games/PrivateGames')
                .then(function (successResponse) {
                    deferred.resolve(successResponse);
                }, function (errorResponse) {
                    deferred.reject(errorResponse);
                });

            return deferred.promise;
        }

        return {
            createGame: createGame,
            joinGame: joinGame,
            gameDetails: details,
            play : play,
            allGames: allGames,
            getPrivateGames: getPrivateGames
        };
    }

    angular.module('tttGame.services')
        .factory('gameManager', ['$http', '$q', 'domain', GameService]);
}());