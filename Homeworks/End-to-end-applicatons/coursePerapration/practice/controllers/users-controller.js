'use strict';

// mongoose - library that works with mongodb (like Entity Framework for MS SQL database with C#).
// User - is model from mongodb (schema), it'a collection with users (table in MS SQL).
let mongoose = require('mongoose'),
	User = mongoose.model('User');

// simple function for generate tokens.
let generateNewToken = function () {
	return Math.random() + '';
};

let controller = {
	/**
	 *
 	 * @param req - request
	 * @param res - response
	 * @param next Middleware function for handle errors
	 */
	register: function (req, res, next) {
		// gets data from the body
		let user = req.body;

		// user-model doesn't have property for name to lower, but it can be added without problem.
		user.nameToLower = user.username.toLowerCase();

		// makes a new instance for db from Users schema.
		let dbUser = new User(user);

		dbUser.save(function (err) {
			if (err) {
				next(err);
				return;
			}

			res.status(201)
				.json({
					username: dbUser.username
				});
		});
	},
	login: function (req, res, next) {
		let reqUser = req.body;

		// find a user with given filter and callback function
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

			// When user is registered it does'n have a token.
			// When logs in it receives a token and it is saved to the db.
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

// it's important.
module.exports = controller;