/*globals angular, toastr*/

(function () {
    'use strict';

    function configuration($routeProvider, $locationProvider) {

        $locationProvider.html5Mode(true);

        var CONTROLLER_AS = 'vm';

        var routeResolvers = {
            authenticationRequired: {
                authenticate: ['$q', 'auth', function ($q, auth) {
                    if (auth.isAuthenticated()) {
                        return true;
                    }

                    return $q.reject('not authorized');
                }]
            }
        };

        $routeProvider
            .when('/', {
                templateUrl: 'templates/home-template.html'
            })
            .when('/login', {
                templateUrl: 'templates/login-template.html',
                controller: 'LoginController',
                controllerAs: CONTROLLER_AS
            })
            .when('/register', {
                templateUrl: 'templates/register-template.html',
                controller: 'RegisterController',
                controllerAs: CONTROLLER_AS
            })
            .when('/game/add', {
                templateUrl: 'templates/game-create-template.html',
                controller: 'GameController',
                controllerAs: CONTROLLER_AS,
                resolve: routeResolvers.authenticationRequired
            })
            .when('/game/join', {
                templateUrl: 'templates/game-join-template.html',
                controller: 'GameController',
                controllerAs: CONTROLLER_AS,
                resolve: routeResolvers.authenticationRequired
            })
            .when('/games/all', {
                templateUrl: 'templates/games-default-template.html',
                controller: 'AllGamesController',
                controllerAs: CONTROLLER_AS
            })
            .when('/games/profile/usergames', {
                templateUrl: 'templates/games-default-template.html',
                controller: 'UsersGamesController',
                controllerAs: CONTROLLER_AS,
                resolve: routeResolvers.authenticationRequired
            })
            .when('/games/profile', {
                templateUrl: 'templates/user-profile-template.html',
                controller: 'UserDetailsController',
                controllerAs: CONTROLLER_AS,
                resolve: routeResolvers.authenticationRequired
            })
            .when('/game/:id', {
                templateUrl: 'templates/game-details-template.html',
                controller: 'GameController',
                controllerAs: CONTROLLER_AS,
                resolve: routeResolvers.authenticationRequired
            })
            .otherwise({redirectTo: '/'});
    }

    function run($http, $cookies, $rootScope, $location, auth, notifier) {
        $rootScope.$on('$routeChangeError', function (ev, current, previous, rejection) {
            if (rejection === 'not authorized') {
                notifier.warning('First login!', 'NOT AUTHORIZED!');
                $location.path('/login');
            }
        });

        if (auth.isAuthenticated()) {
            $http.defaults.headers.common.Authorization = 'Bearer ' + $cookies.get('authentication');
            auth.getIdentity();
        }
    }

    angular.module('tttGame', ['ui.bootstrap', 'ngRoute', 'ngResource', 'ngCookies', 'ngMessages', 'tttGame.directives', 'tttGame.controllers', 'tttGame.services', 'tttGame.filters'])
        .config(['$routeProvider', '$locationProvider', configuration])
        .run(['$http', '$cookies', '$rootScope', '$location', 'auth', 'notifier', run])
        .value('toastr', toastr)
        .constant('domain', 'http://localhost:3331/');

    angular.module('tttGame.directives', []);

    angular.module('tttGame.controllers', []);

    angular.module('tttGame.services', []);

    angular.module('tttGame.filters', []);
}());