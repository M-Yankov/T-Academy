/* globals describe, before, it, assert */
'use strict';

var https = require('https'),
	jquery = require('jquery'),
	util = require('util'),
	env = require('jsdom').env,
	domain = 'https://github.com/',
	linkForTesting = 'https://github.com/M-Yankov/T-Academy/blob/master/README.md',
	results = [],
	selector = '#readme a[href*="M-Yankov"]',
	count;

function getData(callBack) {
	https.get(linkForTesting, (res) => {
		var bodyChunks = [];

		res.on('data', function (chunk) {
			bodyChunks.push(chunk);
		}).on('end', function () {
			var body = Buffer.concat(bodyChunks);
			body += '';
			env(body, function (errors, window) {
				if (!!errors) {
					throw errors;
				}

				var $ = jquery(window);
				count = $(selector).length;
				$(selector).each(function (index, element) {
					var link = domain + $(element).attr('href');

					checkResults(link);
				});
			});
		});
	}).on('error', (e) => {
		console.log(`Got error: ${e.message}`);
	});

	function checkResults(link) {
		https.get(link, (res) => {
			res.on('data', function (data) {
			}).on('end', function () {
				results.push({
					pass: true,
					link: link
				});

				count -= 1;
				if (count < 1) {
					callBack(results);
				}
			});
		}).on('error', (e) => {
			results.push({
				pass: false,
				link: link
			});

			count -= 1;
			if (count < 1) {
				callBack(results);
			}
		});
	}
}

module.exports = getData;