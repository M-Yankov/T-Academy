/*globals angular*/
(function () {
    'use strict';

    function calculateGamesWonPercentage() {
        return function (gamesWon, totalGames) {
            if (!totalGames) {
                return 0;
            }

            var all = gamesWon * 100;
            return Math.round10(all / totalGames);
        };
    }

    angular.module('tttGame.filters')
        .filter('gamesWonPercentageFilter', calculateGamesWonPercentage);
}());