/* globals angular*/
(function () {
    'use strict';

    function GameController($location, $routeParams, $interval, notifier, gameManager, $scope) {
        var vm = this;

        var promiseToDestroy;
        vm.tile = {};

        if ($routeParams.id) {
            GameDetails();
            promiseToDestroy = $interval(GameDetails, 3000);
        }

        $scope.$on('$destroy', function () {
            // Make sure that the interval is destroyed too
            $interval.cancel(promiseToDestroy);
            console.log('DEEEEESTORUYYYYYYYY');
        });

        vm.createGame = function () {
            gameManager.createGame()
                .then(function (response) {
                    notifier.success('Game created', 'Success!');
                    console.log(response);
                    $location.path('/game/' + response.data);
                }, function (errResponse) {
                    notifier.error('Cannot create game', 'Error');
                    console.log(errResponse);
                });
        };

        vm.joinGame = function () {
            gameManager.joinGame()
                .then(function (successEnter) {
                    notifier.success('You just joined in the game!', 'Success!');
                    $location.path('/game/' + successEnter.data);

                }, function (error) {
                    notifier.error('Currently there are no games', 'Game not found!');
                });
        };

        vm.play = function (tile, playTileForm) {
            if (!playTileForm.$dirty) {
                notifier.warning('First chose a tile!', 'Warning');
                return;
            }

            if (vm.gameInfo.State >= 3) {
                notifier.warning('Game already finished!', 'Warning');
                return;
            }

            if (vm.gameInfo.State === 0) {
                notifier.warning('You must wait for opponent!', 'Warning');
                return;
            }

            tile.gameId = vm.gameInfo.Id;
            gameManager.play(tile)
                .then(function (response) {
                    /// Success play
                    GameDetails();

                    // start waiting again
                    promiseToDestroy = $interval(GameDetails, 3000);
                }, function (errorResponse) {
                    var errors = {};
                    notifier.error(errorResponse.data.Message, 'Error');

                    if (errorResponse.data && errorResponse.data.ModelState && errorResponse.data.ModelState[""]) {
                        errors = errorResponse.data.ModelState[""];

                        for (var ind in errors) {
                            if (errors.hasOwnProperty(ind)) {
                                notifier.error(errors[ind], errorResponse.statusText);
                            }
                        }
                    }
                });
        };

        function GameDetails() {
            var idOfTheGame = $routeParams.id;

            function stopIntervalIfBoardChanged(newGameInfo) {
                if (!vm.gameInfo) {
                    return;
                }

                // If game is finished stop!
                if (newGameInfo.State >= 3) {
                    $interval.cancel(promiseToDestroy);
                    return;
                }

                // if opponent comes stop!
                if (vm.gameInfo.SecondPlayerName !== newGameInfo.SecondPlayerName) {
                    notifier.warning('Opponent just join', 'Info');
                    $interval.cancel(promiseToDestroy);
                    return;
                }

                // if player is first to play stop
                if (newGameInfo.State === 1 && newGameInfo.FirstPlayerName === $scope.$parent.hm.globallySetCurrentUser.Email) {
                    $interval.cancel(promiseToDestroy);
                    return;
                }

                // if player is second to play stop
                if (newGameInfo.State === 2 && newGameInfo.SecondPlayerName === $scope.$parent.hm.globallySetCurrentUser.Email) {
                    $interval.cancel(promiseToDestroy);
                    return;
                }
            }

            if (!idOfTheGame) {
                return;
            }

            gameManager.gameDetails(idOfTheGame)
                .then(function (response) {

                    stopIntervalIfBoardChanged(response.data);

                    vm.gameInfo = response.data;

                    if (vm.gameInfo.State >= 3) {
                        $interval.cancel(promiseToDestroy);
                    }

                }, function (error) {
                    $interval.cancel(GameDetails);
                    notifier.error('Reasons: id or you are not participate in the game', 'Game not found!');
                    $location.path('/games/all');
                });
        }
    }

    angular.module('tttGame.controllers')
        .controller('GameController', ['$location', '$routeParams', '$interval', 'notifier', 'gameManager', '$scope', GameController]);

}());