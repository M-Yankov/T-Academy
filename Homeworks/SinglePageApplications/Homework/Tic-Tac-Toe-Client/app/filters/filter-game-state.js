/*globals angular*/

(function () {
    "use strict";

    function filterForGameState() {
        return function (input) {
            switch (input) {
                case 0:
                    return "Waiting for opponent!";
                case 1:
                    return "First player turn.";
                case 2:
                    return "Second player turn.";
                case 3:
                    return "Game was won by first player";
                case 4:
                    return "Game was won by second player";
                case 5:
                    return "Draw. Deal with it.";
                default:
            }
        };
    }

    angular.module('tttGame.filters')
        .filter('gameStateFilter', filterForGameState);
}());