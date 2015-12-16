/* globals angular*/
(function () {
    'use strict';

    function config($routeProvider, $locationProvider, $httpProvider) {


        var CONTROLLER_AS = 'vm';

        $locationProvider.html5Mode(true);

        $routeProvider
            .when('/', {
                templateUrl: './templates/home.html'
            })
            .when('/login',{
                templateUrl: './templates/login.html',
                controller: 'LoginController',
                controllerAs: CONTROLLER_AS
            })
            .when('/register', {
                templateUrl: './templates/register.html',
                controller: 'RegisterController',
                controllerAs: CONTROLLER_AS
            })
            .when('/cars', {

            })
            .when('/cars/add', {

            })
            .otherwise({redirectTo : '/'});
    }

    angular.module('carApp.controllers', []);

    angular.module('carApp', ['ngRoute','ngMessages', 'ngCookies', 'carApp.controllers'])
        .directive('compareTo', function() {
            return {
                require: "ngModel",
                scope: {
                    otherModelValue: "=compareTo"
                },
                link: function(scope, element, attributes, ngModel) {

                    ngModel.$validators.compareTo = function(modelValue) {
                        return (modelValue === scope.otherModelValue);
                    };

                    scope.$watch("otherModelValue", function() {
                        ngModel.$validate();
                    });
                }
            };
        })
        .constant('baseServiceUrl', 'http://localhost:9595/')
        .config(['$routeProvider', '$locationProvider', '$httpProvider', config]);
}());