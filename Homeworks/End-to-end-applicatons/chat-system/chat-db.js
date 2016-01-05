'use strict';

var mongoose = require('mongoose'),
	User = mongoose.model('User'),
	Message = mongoose.model('Message'),
	BBPromise = require('bluebird');

// BBPromise = Blue Bird promise - there are already a Object Promise in ES6. Just to not overwrite it.
module.exports = {
	registerUser: function (newUser) {
		return new BBPromise(function (resolve, reject) {
			User.find({username: newUser.username}).exec(function (err, user) {
				if (err) {
					return reject(err);
				}

				if (user.length) {
					console.log(user);
					return reject({
						message: 'Username already exist'
					});
				}

				var dbUser = new User(newUser);
				dbUser.save(function (err) {
					if (err) {
						return reject(err);
					}

					resolve(dbUser);
				});
			});
		});
	},
	sendMessage: function (from, to, message) {
		return new BBPromise(function (resolve, reject) {
			User.find({$or: [{username: from}, {username: to}]}).exec(function (err, results) {
				if (err) {
					return reject(err);
				}

				// should find two users
				if (results.length !== 2) {
					return reject({
						message: 'One of the users not found!'
					});
				}

				var dbMessage = new Message({
					senderUsername: from,
					receiverUsername: to,
					text: message
				});

				dbMessage.save(function (err, message) {
					if (err) {
						return reject(err);
					}

					resolve({
						message: 'message "' + message.text + '" was sent to user ' + message.receiverUsername + '!'
					});
				});
			});
		});
	},
	getMessages: function (withUser, andUser) {
		return new BBPromise(function (resolve, reject) {
			Message.find({
					$and: [
						{$or: [{senderUsername: withUser}, {senderUsername: andUser}]},
						{$or: [{receiverUsername: withUser}, {receiverUsername: andUser}]}
					]
				})
				.select('-__v')
				.exec(function (err, results) {
					if (err) {
						return reject(err);
					}

					resolve(results);
				});

			// .select('-__v') means excluding field: "__v"
		});
	}
};