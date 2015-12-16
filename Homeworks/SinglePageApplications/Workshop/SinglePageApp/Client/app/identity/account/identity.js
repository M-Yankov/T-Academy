/*globals angular*/
(function () {
    'use strict';

    // TODO: Change $cookieStore to $cookies. href: https://code.angularjs.org/1.4.8/docs/api/ngCookies/service/$cookies

    angular.module('carApp')
        .factory('identity', ['$cookieStore', function ($cookieStore) {
        var cookieStorageUserKey = 'currentApplicationUser';

        var currentUser;
        return {
            getCurrentUser: function () {
                var savedUser = $cookieStore.get(cookieStorageUserKey);
                if (savedUser) {
                    return savedUser;
                }

                return currentUser;
            },
            setCurrentUser: function (user) {
                if (user) {
                    $cookieStore.put(cookieStorageUserKey, user);
                }
                else {
                    $cookieStore.remove(cookieStorageUserKey);
                }

                currentUser = user;
            },
            isAuthenticated: function () {
                return !!this.getCurrentUser();
            }
        };
    }]);
}());
