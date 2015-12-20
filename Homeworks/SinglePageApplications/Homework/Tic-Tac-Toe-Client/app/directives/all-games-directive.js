/* globals angular*/
(function () {
    'use strict';

    angular.module('tttGame.directives')
        .directive('tttAllGames', function () {
            return {
                restrict: 'A',
                templateUrl: 'templates/all-games-template.html'
            };
        });
}());