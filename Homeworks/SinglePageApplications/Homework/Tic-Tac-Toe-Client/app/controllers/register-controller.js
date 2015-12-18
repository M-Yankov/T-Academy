/* globals angular */
(function () {
    'use strict';

    function RegisterController($location, auth, notifier) {
        var vm = this;

        vm.return = function () {
            $location.path('/');
        };

        vm.makeRegistration = function (user, form) {
            vm.hasError = false;
            if (form.$valid) {
                auth.userRegistration(user)
                    .then(function (response) {
                        notifier.success('Now you must login!', 'Success registration!');
                        $location.path('/login');
                    }, function (errorResponse) {

                        var errors = errorResponse.data.ModelState[""];
                        for (var ind in errors) {
                            if (errors.hasOwnProperty(ind)) {
                                notifier.error(errors[ind], errorResponse.statusText);
                            }
                        }
                        console.log('something is not good. check below:');
                        console.log(errorResponse);
                        vm.hasError = true;
                    });
            } else {
                notifier.error('Invalid form!', 'See messages.');
                vm.hasError = true;
            }
        };
    }

    angular.module('tttGame.controllers')
        .controller('RegisterController', ['$location', 'auth', 'notifier', RegisterController]);
}());