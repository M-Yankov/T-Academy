/* globals angular*/

(function () {
    'use strict';

    var authService = function authService($http, $q, $cookies, identity, domain) {
        var TOKEN_KEY = 'authentication';

        var register = function (user) {
            var deferred = $q.defer();

            var data = "Username=" + (user.username || '') +
                '&Password=' + (user.password || '') +
                '&ConfirmPassword=' + (user.confirmPassword || '') +
                '&Email=' + (user.email || '');

            $http.post(domain + 'api/account/register', data, {headers: {'Content-Type': 'application/x-www-form-urlencoded'}})
                .then(function (response) {
                    deferred.resolve(response);
                }, function (err) {
                    deferred.reject(err);
                });

            return deferred.promise;
        };

        var login = function login(user) {
            var deferred = $q.defer();

            var data = "grant_type=password&username=" + (user.username || '') + '&password=' + (user.password || '');

            $http.post(domain + 'Token', data, {headers: {'Content-Type': 'application/x-www-form-urlencoded'}})
                .then(function (response) {
                    var tokenValue = response.data.access_token;

                    var theBigDay = new Date();
                    theBigDay.setHours(theBigDay.getHours() + 72);

                    $cookies.put(TOKEN_KEY, tokenValue, {expires: theBigDay});

                    $http.defaults.headers.common.Authorization = 'Bearer ' + tokenValue;

                    getIdentity().then(function () {
                        deferred.resolve(response);
                    }, function (errorResponse) {
                        deferred.reject(errorResponse);
                    });
                }, function (err) {
                    deferred.reject(err);
                });

            return deferred.promise;
        };

        var getIdentity = function () {
            var deferred = $q.defer();

            $http.get(domain + 'api/Account/userinfo')
                .then(function (identityResponse) {
                    identity.setUser(identityResponse.data);
                    deferred.resolve(identityResponse.data);
                }, function (errorResponse) {
                    deferred.reject(errorResponse);
                });

            return deferred.promise;
        };

        var fullInformation = function () {
            var deferred = $q.defer();

            $http.get(domain + 'api/games/info')
                .then(function (identityResponse) {
                    deferred.resolve(identityResponse.data);
                }, function (errorResponse) {
                    deferred.reject(errorResponse);
                });

            return deferred.promise;
        };

        return {
            userRegistration: register,
            login: login,
            getIdentity: getIdentity,
            userFullInformation: fullInformation,
            isAuthenticated: function () {
                return !!$cookies.get(TOKEN_KEY);
            },
            logout: function () {
                $cookies.remove(TOKEN_KEY);
                $http.defaults.headers.common.Authorization = null;
                identity.removeUser();
            }
        };
    };

    angular.module('tttGame.services')
        .factory('auth', ['$http', '$q', '$cookies', 'identity', 'domain', authService]);
}());