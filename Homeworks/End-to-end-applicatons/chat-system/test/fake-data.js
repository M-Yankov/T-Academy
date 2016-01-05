'use strict';

var BBPromise = require('bluebird');

var data = {
	registerUser: function (user) {
		return  new BBPromise(function (resolve, reject) {
			for (var i = 0; i < data.users.length; i += 1) {
				if (data.users[i].username === user.username) {
					return reject({
						message: 'Username already exist'
					});
				}
			}

			data.users.push(user);
			resolve(user);
		});

	},
	sendMessage: function (from, to, message) {
		return new BBPromise(function (resolve, reject) {
			var firstUser = false;
			var secondUser = false;
			for (var i = 0; i < data.users.length; i += 1) {
				if (firstUser && secondUser) {
					break;
				}

				if (data.users[i].username === from) {
					firstUser = from;
				}

				if (data.users[i].username === to) {
					secondUser = to;
				}
			}

			if (!firstUser && !secondUser) {
				return reject({
					message: 'One of the users not found!'
				});
			}

			var message = {
				senderUsername: from,
				receiverUsername: to,
				text: message
			};

			data.messages.push(message);
			resolve({
				message: 'message "' + message.text + '" was sent to user ' + message.receiverUsername + '!'
			});

		});
	},
	getMessages: function (withUser, andUser) {
		return new BBPromise(function (resolve, reject) {
			var result = [];
			for (var i = 0; i < data.messages.length; i += 1) {
				if ((data.messages[i].senderUsername === withUser || data.messages[i].senderUsername === andUser) &&
					data.messages[i].receiverUsername === withUser || data.messages[i].receiverUsername === andUser) {
					result.push(data.messages[i]);
				}
			}

			resolve(result);
		});
	},
	users: [],
	messages: [],
	clearData: function () {
		data.users = [];
		data.messages = [];
	},
	feedData: function () {
		data.users = [{
			username: 'NikolayKostov',
			password: '19va@sC8l_2'
		}, {
			username: 'pesho',
			password: 'ps&DpV!112'
		}, {
			username: 'DonchoMinkov',
			password: 'opa1a8A56q!112'
		}];

		data.messages = [{
			senderUsername: 'NikolayKostov',
			receiverUsername: 'pesho',
			text: 'Hello Pesho, your task is to write hello world app in node js.'
		}, {
			senderUsername: 'pesho',
			receiverUsername: 'NikolayKostov',
			text: 'Hello Niki. Task is completed!'
		}, {
			senderUsername: 'NikolayKostov',
			receiverUsername: 'pesho',
			text: 'Nice job Pesho!'
		}];
	}
};

module.exports = data;