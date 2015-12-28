'use strict';

let mongoose = require('mongoose'),
	Log = mongoose.model('Log');

let controller = {
	all: function (req, res) {
		var filter = {};

		if (req.query.userId) {
			filter.user = req.query.userId;
		}

		if (req.query.type) {
			filter.type = req.query.type;
		}

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

module.exports = controller;