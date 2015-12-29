'use strict';

// mongoose - library that works with mongodb (like Entity Framework for MS SQL database with C#).
// Logs - is model from mongodb (schema), it'a collection with logs (table in MS SQL).
let mongoose = require('mongoose'),
	Log = mongoose.model('Log');

let controller = {
	/**
	 *
	 * @param req - request
	 * @param res - response
	 */
	all: function (req, res) {
		// object for filter.
		let filter = {};

		//  by default query parameters can be gathered from request object
		if (req.query.userId) {
			filter.user = req.query.userId;
		}

		// I bet there is a better way to do this, instead of if...else
		if (req.query.type) {
			filter.type = req.query.type;
		}

		// finds a model with the given filter.
		Log.find(filter, function (err, logs) {
			if (err) {
				throw err;
			}

			res.json({
				result: logs
			});
		});
	},
	add: function (req, res, next) {
		let log = req.body;

		// one of the libraries allows to get authenticated user from the request.
		let user = req.user;

		log.date = new Date();
		log.user = user._id;
		log.type = log.type || 'unauthorized';

		let dbLog = new Log(log);

		dbLog.save(function (err) {
			if (err) {
				let error = {
					status: 400,
					message: err.message
				};

				next(error);
				return;
			}

			res.status(201)
				.json({result: dbLog});
		});
	}
};

// important
module.exports = controller;