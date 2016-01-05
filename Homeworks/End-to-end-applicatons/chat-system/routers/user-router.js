'use strict';

var express = require('express'),
	router = express.Router(),
	mongoose = require('mongoose'),
	User = mongoose.model('User'),
	chatDb = require('../chat-db'),
	url =  require('url');

router.post('/register', function (req, res) {
		// gets data from the body
		var user = req.body;

		if (!(user.username) || !(user.password)) {
			res.status(400)
				.json({
					message: 'Username and password are required'
				});
			return;
		}

		chatDb.registerUser(user).then(function (savedUser) {
			res.status(201)
				.json({
					username: savedUser.username
				});
		}, function (error) {
			res.status(400)
				.json(error);
		});
	})
	.post('/sendMessage', function (req, res) {
		var bodyMessage = req.body;
		if (!(bodyMessage.from) || !(bodyMessage.to) || !(bodyMessage.message)) {
			res.status(400).json('Data missing!');
			return;
		}

		chatDb.sendMessage(bodyMessage.from, bodyMessage.to, bodyMessage.message)
			.then(function (successInfo) {
				res.json(successInfo);
			}, function (err) {
				res.status(400)
					.json(err);
			});
	})
	.get('/getMessages', function (req, res) {

		var parsedUrl = url.parse(req.url, true);
		if (!(parsedUrl.query)) {
			res.status(400).json('Query params: ["with", "and"] are required!');
			return;
		}

		var queryParams = parsedUrl.query;

		chatDb.getMessages(queryParams.and, queryParams.with)
			.then(function (messages) {
				res.json(messages);
			}, function (error) {
				res.status(404)
					.json(error);
			});
	});

module.exports = function (app) {
	app.use('/api/users', router);
};