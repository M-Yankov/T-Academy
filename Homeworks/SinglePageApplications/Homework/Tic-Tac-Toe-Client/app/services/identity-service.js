/*globals angular*/
(function () {
    'use strict';

    var identityService = function identityService($q) {
        var currentUser = {};
        var deferred = $q.defer();

        return {
            getUser: function () {
                if (this.isAuthenticated()) {
                    return $q.resolve(currentUser);
                }

                return deferred.promise;
            },
            isAuthenticated: function () {
                var res = Object.getOwnPropertyNames(currentUser).length !== 0;
                return res;
            },
            setUser: function (user) {

                currentUser = user;
                deferred.resolve(user);
            },
            removeUser: function () {
                currentUser = {};
                deferred = $q.defer();
            }
        };
    };

    angular.module('tttGame.services')
        .factory('identity', ['$q', identityService]);
}());