'use strict';

var http = require('http');
var request = require('request');
var assert = require('assert');
var fakeData = require('./fake-data');

require('./config');

module.exports.userRoutes = {
	tearDown: function (cb) {
		fakeData.clearData();
		cb();
	},
	expectSuccessRegister: function (test) {

		var doncho = {
			username: 'DonchoMinkov',
			password: '123456q'
		};

		var options = {
			url: 'http://localhost:9222/api/users/register',
			method: 'POST',
			headers: {
				'Content-Type': 'application/json'
			},
			json: true,
			body: doncho
		};

		request.post(options, function (err, res, body) {
			if (err) {
				console.log(err);
				process.exit(0);
			}

			test.equals(body.username, doncho.username);
			test.done();
			//assert.equal(body.username,doncho.username);
		});
	}
};
