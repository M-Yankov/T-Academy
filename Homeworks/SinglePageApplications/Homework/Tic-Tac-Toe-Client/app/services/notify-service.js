/*globals angular */
(function () {
    'use strict';

    function NotificationService(toastr) {
        toastr.options = {
            "closeButton": true,
            "debug": false,
            "newestOnTop": true,
            "progressBar": true,
            "positionClass": "toast-top-right",
            "preventDuplicates": false,
            "onclick": null,
            "showDuration": "1000",
            "hideDuration": "1000",
            "timeOut": "3000",
            "extendedTimeOut": "1000",
            "showEasing": "swing",
            "hideEasing": "linear",
            "showMethod": "fadeIn",
            "hideMethod": "fadeOut"
        };

        return {
            success: function (body, title) {
                toastr.success(body, title);
            },
            warning: function (body, title) {
                toastr.warning(body, title);
            },
            error: function (body, title) {
                toastr.error(body, title);
            }
        };
    }

    angular.module('tttGame.services')
        .factory('notifier',['toastr', NotificationService]);
}());