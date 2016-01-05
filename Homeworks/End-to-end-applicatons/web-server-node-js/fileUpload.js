var formidable = require('formidable'),
	http = require('http'),
	util = require('util'),
	fs = require('fs');

fs.mkdir('files', function (err) {
	'use strict';
	if (err && err.code !== 'EEXIST') {
		throw err;
	}
});

http.createServer(function (req, res) {
	'use strict';
	if (req.url === '/upload' && req.method.toLowerCase() === 'post') {
		// parse a file upload
		var form = new formidable.IncomingForm();
		form.encoding = 'utf-8';
		form.uploadDir = "./files/";
		var hasError = false;

		form.on('file', function (name, file) {
			if (!file.size) {
				res.writeHead(400);
				res.write('<div>Noting to send!</div>');
				res.write('<a href="/">Upload</a>');
				res.end();
				hasError = true;
				return;
			}

			file.path = form.uploadDir + file.name;
		});

		form.parse(req, function (err, fields, files) {
			if (hasError) {
				return;
			}

			if (err) {
				res.write(err);
				res.end();
				return;
			}

			if (!req) {
				res.write('<div>Noting to send!</div>');
				res.write('<a href="/">Upload</a>');
				res.end();
				return;
			}

			res.writeHead(201, {'content-type': 'text/html'});
			res.write('<div>UploadComplete:</div> <br />');
			res.write('<a href="/files">Files</a>');
			//res.end(util.inspect({fields: fields, files: files}));
			res.end();
		});

		return;
	}

	if (req.url.toString().includes('/file/') && req.url.length > 7) {
		var fileName = req.url.substr(6);
		fs.readFile('./files/' + fileName, 'utf8', function (err, fileContent) {
			if (err) {
				res.writeHead(404);
				res.write('Cannot read file: <b>' + fileName + '</b>');
				res.end();
				return;
			}

			res.write('<div style="width: 500px">' + fileContent + '</div>');
			res.end();
		});

		return;
	}

	if (req.url === '/files') {
		fs.readdir('./files', function (err, files) {
			if (err) {
				res.writeHead(401);
				res.write('cannot read directory');
				res.end();
				return;
			}

			res.writeHead(200, {'content-type': 'text/html'});
			res.write('<ul>');
			for (var i = 0; i < files.length; i += 1) {
				res.write('<li><a href="/file/' + files[i] + '">' + files[i] + '</a></li>');
			}

			res.write('</ul>');

			res.end();
		});

		return;
	}

	// show a file upload form
	res.writeHead(200, {'content-type': 'text/html'});
	res.end(
		'<form action="/upload" enctype="multipart/form-data" method="post">' +
		'<input type="text" name="title"><br>' +
		'<input type="file" name="upload"><br>' +
		'<input type="submit" value="Upload">' +
		'</form><br>' +
		'<a href="/files" >Files</a>');
}).listen(8080);