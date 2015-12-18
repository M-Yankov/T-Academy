/* globals angular*/
(function () {
    'use strict';

    function AllGamesController(gameManager, notifier) {

        var vm = this;


        getAllGames();

        function getAllGames() {
            gameManager.allGames()
                .then(function (response) {
                    vm.allGames = response.data;
                }, function (errorResponse) {
                    var errors = {};
                    notifier.error(errorResponse.data.Message, 'Error');

                    if (errorResponse.data && errorResponse.data.ModelState[""]) {
                        errors = errorResponse.data.ModelState[""];

                        for (var ind in errors) {
                            if (errors.hasOwnProperty(ind)) {
                                notifier.error(errors[ind], errorResponse.statusText);
                            }
                        }
                    }
                });
        }
    }

    angular.module('tttGame.controllers')
        .controller('AllGamesController', ['gameManager', 'notifier', AllGamesController]);
}());