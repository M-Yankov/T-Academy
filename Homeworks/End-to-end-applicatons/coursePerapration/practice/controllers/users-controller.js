'use strict';

let mongoose = require('mongoose'),
	User = mongoose.model('User');

var generateNewToken = function () {
	return Math.random() + '';
};

let controller = {
	register: function (req, res, next) {
		let user = req.body;

		// user-model doesn't have property for name to lower, but it can be added without problem.
		user.nameToLower = user.username.toLowerCase();

		let dbUser = new User(user);

		dbUser.save(function (err) {
			if (err) {
				next(err);
				return;
			}

			if (!dbUser.username) {
				res.status(201)
					.json('Duplicate');
			}

			res.status(201)
				.json({
					username: dbUser.username
				});
		});
	},
	login: function (req, res, next) {
		let reqUser = req.body;

		User.findOne({
			nameToLower: reqUser.username.toLowerCase()
		}, function (err, user) {
			if (err) {
				next(err);
				return;
			}

			if (!user || user.password !== reqUser.password) {
				next({
					message: "Invalid username or password"
				});
				return;
			}

			if (!user.token) {
				user.token = generateNewToken();
				user.save();
			}

			res.status(200)
				.json({
					username: user.username,
					token: user.token
				});
		});
	}
};

module.exports = controller;