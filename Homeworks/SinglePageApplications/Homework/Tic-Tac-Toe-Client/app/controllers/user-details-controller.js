/* global angular*/

(function () {
    'use strict';

    function UserDetailsController(auth, notifier) {
        var vm = this;

        getFullDetails();

        function getFullDetails() {
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