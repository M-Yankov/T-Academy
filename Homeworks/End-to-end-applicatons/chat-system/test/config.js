'use strict';

var express = require('express'),
	bodyParser = require('body-parser'),
	app = express(),
	port = 9222;

app.use(bodyParser.json());

var fakeData = require('./fake-data');

require('../routers/user-router')(app, fakeData);
// listening on port: 9222
app.listen(port);