/* globals angular*/
(function () {

    'use strict';

    angular.module('carApp')
        .factory('authorization', ['identity', function (identity) {
        return {
            getAuthorizationHeader: function () {
                var token = identity.getCurrentUser();
                if (!!token) {
                	token = token.access_token;
                }
                return {
                    'Authorization': 'Bearer ' + token //identity.getCurrentUser().access_token  //['access_token']
                };
            }
        };
    }]);
}());
