'use strict';

let express = require('express'),
	router = new express.Router(),
	passport = require('passport'),
	imagesCtrl = require('../controllers/images-controller'),
	multer = require('multer');
var upload = multer();

router.get('/', imagesCtrl.all);
router.get('/add', passport.authenticate('cookie', {
	session: false
}), imagesCtrl.addForm);
router.get('/:id', imagesCtrl.detail);
router.post('/add', passport.authenticate('cookie', {
	session: false
}), upload.single('image'), imagesCtrl.add);
router.post('/:id/comment',passport.authenticate('cookie', {
	session: false
}), imagesCtrl.addComment);

module.exports = function (app) {
	app.use('/images', router);
};