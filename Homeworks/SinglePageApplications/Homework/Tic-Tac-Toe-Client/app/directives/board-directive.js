/* globals angular*/
(function () {
    'use strict';

    angular.module('tttGame.directives')
        .directive('tttBoard', function () {
            return {
                restrict: 'A',
                templateUrl: 'templates/board.html',
                scope: {
                    gameInfo: '=info'
                },
                link: function (scope, element, attrs, ctrl, transclude) {
                    scope.setTile = function (row, col) {
                        if (scope.$parent.vm.tile) {
                            scope.$parent.vm.tile.row = row;
                            scope.$parent.vm.tile.col = col;
                        }
                    };
                }
            };
        });
}());