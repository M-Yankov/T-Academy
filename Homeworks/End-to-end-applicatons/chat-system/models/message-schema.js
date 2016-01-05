'use strict';

// mongoose - for operation with mongodb.
var mongoose = require('mongoose');

// define a schema for the object. columns, requirements, types etc.
var schema = new mongoose.Schema({
	senderUsername: {
		type: String,
		required: true
	},
	receiverUsername: {
		type: String,
		required: true
	},
	text: {
		type: String,
		required: true
	}
});

// creating a new model with given schema.
mongoose.model('Message', schema);