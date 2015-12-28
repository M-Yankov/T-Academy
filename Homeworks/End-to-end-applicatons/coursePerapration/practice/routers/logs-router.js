/**/
'use strict';

var express = require('express'),
	mongoose = require('mongoose'),
	router = express.Router(),
	passport = require('passport'),
	Log = mongoose.model('Log');

let controller = require('./../controllers/logs-controller');

router
	.get('/', controller.all)
	.post('/', passport.authenticate('bearer', {
		session: false
	}),
	controller.add);

module.exports = function (app) {
	app.use('/api/logs', router);
};