/* global angular*/

(function () {
    'use strict';

    function UserDetailsController(auth, notifier) {
        var vm = this;

        getFullDetails();

        function getFullDetails() {
            /* TODO: from server to return games won, games lose, games participate (% win can be on the client)*/
            auth.userFullInformation()
                .then(function (response) {
                    vm.fullInformation = response;
                }, function (errResponse) {
                    notifier.error('Cannot access data','Error');
                });
        }
    }

    angular.module('tttGame.controllers')
        .controller('UserDetailsController', ['auth','notifier', UserDetailsController]);
}());