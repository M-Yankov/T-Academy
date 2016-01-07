'use strict';
var router = require('express').Router(),
	fs = require('fs'),
	jade = require('jade'),
	path = require('path'),
	model = require('../data/model'),
	phones = require('../data/phones'),
	tablets = require('../data/tablets'),
	wearables = require('../data/wearables'), // like a pyramid :D
	template;

fs.readFile('./view/template.jade', 'utf8', function (err, content) {
	if (err) {
		throw err;
	}

	model.technologies = false;

	template = jade.compile(content, {
		filename: path.join('./view/', 'template.jade'),
		pretty: true
	});
});

router
	.get('/', function (req, res) {
		model.technologies = false;
		var readyHtml = template(model);

		res.append('Content-type', 'text/html');
		res.send(readyHtml);
	})
	.get('/phones', function (req, res) {
		model.technologies = phones;
		model.colorStyle = 'warning';

		var readyHtml = template(model);
		res.append('Content-type', 'text/html');
		res.send(readyHtml);

	})
	.get('/tablets', function (req, res) {
		model.technologies = tablets;
		model.colorStyle = 'primary';

		var readyHtml = template(model);
		res.append('Content-type', 'text/html');
		res.send(readyHtml);
	})
	.get('/wearables', function (req, res) {
		model.technologies = wearables;
		model.colorStyle = 'success';

		var readyHtml = template(model);
		res.append('Content-type', 'text/html');
		res.send(readyHtml);
	});

module.exports = function (app) {
	app.use('/', router);
};