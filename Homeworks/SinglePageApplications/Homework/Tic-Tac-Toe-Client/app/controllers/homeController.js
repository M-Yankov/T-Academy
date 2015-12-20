/*globals angular*/
(function () {
    'use strict';

    function HomeController($location, auth, identity) {
        var hm = this;
        hm.hello = 'Hello';
        hm.screen1 = '../img/screen1.png';
        hm.screen2 = '../img/screen2.png';
        hm.screen3 = '../img/screen3.png';
        hm.logo = '../img/back.png';

        waitForLogin();

        hm.logout = function () {
            hm.globallySetCurrentUser = undefined;
            auth.logout();
            waitForLogin(); // this is for second login
            $location.path('/');
        };

        function waitForLogin() {
            identity.getUser()
                .then(function (user) {
                    hm.globallySetCurrentUser = user;
                });
        }
    }

    angular.module('tttGame.controllers')
        .controller('HomeController', ['$location', 'auth', 'identity', HomeController]);
}());