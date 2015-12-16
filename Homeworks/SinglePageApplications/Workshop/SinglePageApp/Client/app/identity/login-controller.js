/*globals angular*/
(function () {
    'use strict';

    function LoginController($location, auth) {

        var vm = this;

        vm.logUser = function (user, regForm) {
            if (regForm.$valid) {
                auth.login(user)
                    .then(function () {
                        // TODO: toastr.succes
                        alert('Success login');
                        $location.path('/');
                    }, function () {

                        // TODO: toastr.
                        alert('Error');
                    });
            } else {
                // tODO:
                // taoastr. Invalid data
            }
        };
    }

    angular.module('carApp')
        .controller('LoginController', ['$location', 'auth', LoginController]);

}());