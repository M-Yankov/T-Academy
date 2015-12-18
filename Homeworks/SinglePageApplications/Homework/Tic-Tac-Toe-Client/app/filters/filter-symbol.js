/*globals angular*/

(function () {
    'use strict';

    function filterSymbol() {
        return function(input) {
            switch (input) {
                case '-':
                    return ' ';
                default:
                    return input;
            }
        };
    }
    
    angular.module('tttGame.filters')
        .filter('renderSymbol',filterSymbol);
}());