/* globals angular*/
(function () {

    'use strict';

    angular.module('carApp')
        .factory('auth', ['$http', '$q', 'identity', 'authorization', 'baseServiceUrl', function ($http, $q, identity, authorization, baseServiceUrl) {
            // var usersApi = baseServiceUrl + '/api/users';

            return {
                signup: function (user) {
                    var deferred = $q.defer();

                    $http.post(baseServiceUrl + 'api/Account/register', 'username=' + user.username + '&password=' + user.password + '&confirmPassword=' + user.confirmPassword + '&email=' + user.email, {headers: {'Content-Type': 'application/x-www-form-urlencoded'}})
                        .then(function () {
                            deferred.resolve();
                        }, function (response) {
                            deferred.reject(response);
                        });

                    return deferred.promise;
                },
                login: function (user) {
                    var deferred = $q.defer();
                    user.grant_type = 'password'; // user['grant_type']; TODO: change '&grant_type=password' to '&grant_type=' + user.grant_type
                    $http.post(baseServiceUrl + 'Token', 'username=' + user.username + '&password=' + user.password + '&grant_type=password', {headers: {'Content-Type': 'application/x-www-form-urlencoded'}})
                        .then(function (response) {
                            if (response.data.access_token) { // response["access_token"]

                                identity.setCurrentUser(response.data);
                                deferred.resolve(true);
                            }
                            else {
                                // TODO reject
                                deferred.resolve(false);
                            }
                        }, function (res) {
                            deferred.reject(res);
                        });

                    return deferred.promise;
                },
                logout: function () {
                    var deferred = $q.defer();

                    if (identity.isAuthenticated()) {

                        identity.setCurrentUser(undefined);
                        deferred.resolve('Success');
                    } else {
                        deferred.reject('error');
                    }

                    /*var headers = authorization.getAuthorizationHeader();
                     $http.post(' ' + '/logout', {}, { headers: headers })
                     .success(function() {
                     identity.setCurrentUser(undefined);
                     deferred.resolve();
                     });*/

                    return deferred.promise;
                },
                getUserInfo: function () {
                    var deferred = $q.defer();
                    var authorizationHeader = authorization.getAuthorizationHeader();
                    //authorizationHeader['Content-Type'] = 'application/json';
                    var urlGet = baseServiceUrl + 'api/account/info';
                    var config = {};
                    config.headers = {};
                    config.headers.Authorization = authorizationHeader.Authorization;
                    config.headers['Content-type'] = 'application/json';

                    $http.defaults.headers.common.Authorization = authorizationHeader.Authorization;
                    // TODO : DON't work
                    $http.get(urlGet, {headers: {'Content-Type': 'application/x-www-form-urlencoded', 'Authorization': 'Bearer bicLYYW5b035LQcc2bKN938OcBgtw2sOtlAVdVk_NLHyuuovYxlAcBjoGXHJytcxRHtP6AK152H32D5covHsJNF4As2qJKjeykM_e1EW3IjSISbEpRJXFPeHy5flv--XepXoj1UDX6LXsY9JHcQPjoCp6cDKS9ehkpZXovq-3U75loNZ-ixOJMTf2qUh1bcLGXuqesWwhu5fuSW9pbMK_D6j_I_JDGQTUVIN9T7vX_C55xU5fM4-uLgnG5Rx3DWtHiYz9tzdEj14VzgITjCTYa3wDD2teMCkp7cuEPyb1Df5tNQhvGN6Udt_kMrCXLrOcECnEL66zHrw0zUhkrriKPhYnfaXu72pZQDeRZPCnOd5fb_wZA23We7YA3FlOr2qE4v5XEwYYplphZxuVsI3GFOZotLXvvoDMEStL-HPs4ivUNHNE9kuSZVui-xruf4T0WZkAroTg8POWZkY9yEDh3ylqcZIIouWy7amBcmd57s'}})
                        .then(function (res) {
                            deferred.resolve(res);
                        }, function (res) {
                            deferred.reject(res);
                        });

                    return deferred.promise;
                },
                getCars: function () {
                  var deferred = $q.defer();
                    $http.get(baseServiceUrl + 'api/cars')
                        .then(function(res){
                            deferred.resolve(res);
                        }, function (err) {
                            deferred.reject(err);
                        });

                    return deferred.promise;
                },
                isAuthenticated: function () {
                    if (identity.isAuthenticated()) {
                        return true;
                    }
                    else {
                        return $q.reject('not authorized');
                    }
                }
            };
        }]);
}());