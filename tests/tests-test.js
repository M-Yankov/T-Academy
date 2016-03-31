'use strict';

var data = require('./index');

module.exports.exmaple = {
	property: function (test) {

		data(function (results) {
			for (var i = 0; i < results.length; i += 1) {
				test.ok(results[i].pass, 'check status of response link:' + results[i].link);
			}

			test.done();
		});
	}
};
