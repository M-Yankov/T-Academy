/*globals exports*/
exports.fetch = function(load, fetch) {
    "use strict";
    return new Promise(function(resolve, reject) {
        var cssFile = load.address;

        var link = document.createElement('link');
        link.rel = 'stylesheet';
        link.href = cssFile;
        link.onload = resolve;

        document.head.appendChild(link);
    });
};