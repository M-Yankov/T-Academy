(function () {
	'use strict';
	let http = require('http'),
		url = require('url'),
		fs = require('fs'),
		querystring = require('querystring'),
		port = 1222;

	var server = http.createServer();

	server.on('request', function (request, response) {
		var urlObj = url.parse(request.url);

		request.on('data', function(data) {
			console.log(data);
		});

		response.writeHead(200, {
			'Content-type': 'text/html'
		});

		if (urlObj.path === '/upload') {
			fs.readFile('./index.html', 'utf8', function (err, data) {
				if (err) {
					throw  err;
				}
				response.write(data);
				response.end();
			});
		} else if (urlObj.path === '/api/upload') {
			var body = '';

			request.on('data', function(data){
				body += data;
			});

			request.on('end', function() {
				var note = querystring.parse(body);
				console.log("Body data: " + note);
				var newPath = "./files/file.txt";
				fs.writeFile( newPath, body, function (err) {
					if (err) {
						throw err;
					}
				});
			});
		} else {
			response.write(urlObj.path || 'Welcome Node js');
			response.write('<br/> <a href="/upload">Go to upload page</a>');
			response.end();
		}
	});

	server.listen(port);

	console.log(`Server is running on port: ${port}`);
}());
