'use strict';

let mongoose = require('mongoose'),
	ImageModel = mongoose.model('Image'),
	fs = require('fs');

module.exports = {
	all: function (req, res) {
		ImageModel.find({})
			.exec(function (err, images) {
				if (err) {
					return res.render('error',{error:err.message});
				}



				res.render('images', {images: images});
			});
	},

	add: function (req, res) {
		if (!req.body || !req.body.title || req.body.title.length < 5) {
			return res.render('upload-form', {error: 'File was not saved'});
		}

		let path = './public/pic/' + req.file.originalname;

		var dbImage = new ImageModel({
			path: path,
			user: req.user,
			comments: [],
			title: req.body.title
		});

		dbImage.save(function (err, img) {
			if (err) {
				return res.render('upload-form', {error: err + ''});
			}

			fs.writeFileSync(path, req.file.buffer);
			res.redirect('/images/' + img._id);
		});
	},
	addForm: function (req, res) {
		res.render('upload-form', {});
	},
	addComment: function (req, res) {
		if (!req.body.comment || req.body.comment.length < 5) {
			return res.render('error', {error: 'Need comment with length 5'});
		}

		let comment = {
			text: req.body.comment,
			username: req.user.username,
			date: new Date()
		};

		let imageID = req.params.id;

		ImageModel.findById(imageID)
			.exec(function (err, image) {
				if (err || !image) {
					return res.render('error', {error: 'Not Found'});
				}

				image.comments.push(comment);
				image.save(function (err, updated) {
					if (err) {
						return res.render('error', {error: err.message});
					}

					res.redirect('/images/' + updated._id);
				});
			});
	},
	detail: function (req, res) {
		let id = req.params.id;
		ImageModel.findById(id)
			.exec(function (err, image) {
				if (err || !image) {
					return res.render("error", {error: 'not found'});
				}
				/*{
					title: image.title,
						imgUrl: '../' + image.path.substr(9),
					comments: image.comments,
					user: image.user
				}*/

				res.render('detail', {image:image});
			});
	}
};