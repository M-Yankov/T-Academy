/* globals angular*/
(function () {
    'use strict';
    function backgroundImageFilter() {
        return function (input) {
            switch (input) {
                case 'X':
                    return 'red-X-symbol-background';
                case 'O':
                    return 'green-circle-background';
                default:
                    return ' ';
            }
        };
    }

    angular.module('tttGame.filters')
        .filter('backgroundImageFilter', backgroundImageFilter);
}());