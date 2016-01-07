'use strict';

var express = require('express'),
	jade = require('jade'),
	fs = require('fs'),
	app = express(),
	path = require('path'),
	router = express.Router(),
	port = 2016;

require('./routes/tech-route')(app);

app.listen(port, function (err) {
	if (err) {
		console.log(err);
	}

	console.log('http://localhost:' + port);
});