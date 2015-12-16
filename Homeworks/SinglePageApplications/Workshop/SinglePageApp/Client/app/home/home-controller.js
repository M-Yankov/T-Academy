/* globals angular */
(function () {
    'use strict';
    function HomeController($location, identity, auth) {
        var vm = this;
        console.log('--------------------');
        vm.loggedUser = identity.getCurrentUser();

        // TODO: HOW TO SEND $http.get() with authorization
        auth.getUserInfo().then(function (res) {
            console.log(res);
        }, function (err) {
            alert(err);
        });

        vm.logout = function () {
            return auth.logout()
                .then(function (res) {
                    alert('success Logout!');
                    $location.path('/s');
                }, function (res) {
                    alert('failed to logout!');
                });
        };

        var inauthentic = identity.isAuthenticated();
        vm.isAuth = inauthentic;
        vm.introduction = 'Welcome to cars system';
        vm.information = 'Add watch cars, Cars system information.';
    }

    angular.module('carApp')
        .controller('HomeController', ['$location','identity', 'auth', HomeController]);
}());