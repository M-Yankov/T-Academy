/*globals angular*/
(function () {
    'use strict';

    function RegisterController($location, auth) {
        var vm = this;

        vm.registerUser = function (user, regForm) {
            vm.hasError = false;
            if (regForm.$valid) {

                console.log(user);
                console.log(regForm);

                auth.signup(user)
                    .then(function () {
                        // TODO: toastr.success();
                        alert('registered!');
                        $location.path('/');
                    }, function (err) {
                        vm.hasError = true;
                        // TODO: toastr.fail();
                        alert('reallyBad');
                    });
            } else {
                // TODO: toastr.fail();
                console.error('wrong' + regForm);
            }
        };

        vm.return = function () {
            $location.path('/');
        };
    }

    angular.module('carApp.controllers')
        .controller('RegisterController', ['$location', 'auth', RegisterController]);
}());