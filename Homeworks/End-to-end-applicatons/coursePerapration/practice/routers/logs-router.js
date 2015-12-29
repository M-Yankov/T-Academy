'use strict';

// express - it's like ASP.NET for C#
// passport - is authentication library helps with easy resolve auth headers.
let express = require('express'),
	router = express.Router(),
	passport = require('passport'),
	logController = require('./../controllers/logs-controller');

// makes a routing, on post requires an authentication. (You can register on /api/users/register)
router
	.get('/', logController.all)
	.post('/', passport.authenticate('bearer', {
		session: false
	}),
	logController.add);

// exports a function which accepts a instance of express() and sets to use on '/api/logs' route above configuration.
module.exports = function (app) {
	app.use('/api/logs', router);
};