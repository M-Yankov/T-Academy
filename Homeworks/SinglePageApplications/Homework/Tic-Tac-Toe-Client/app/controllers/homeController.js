/*globals angular*/
(function () {
    'use strict';

    function HomeController($location, auth, identity) {
        var vm = this;
        vm.hello = 'Hello';

        waitForLogin();

        vm.logout = function () {
            vm.globallySetCurrentUser = undefined;
            auth.logout();
            waitForLogin(); // this is for second login
            $location.path('/');
        };

        function waitForLogin() {
            identity.getUser()
                .then(function (user) {
                    vm.globallySetCurrentUser = user;
                });
        }
    }

    angular.module('tttGame.controllers')
        .controller('HomeController', ['$location', 'auth', 'identity', HomeController]);
}());