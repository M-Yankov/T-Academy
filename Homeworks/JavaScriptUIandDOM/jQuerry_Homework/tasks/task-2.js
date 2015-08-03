/* globals $, describe, it, require, before, global */

/*
 Create a function that takes a selector and:
 * Finds all elements with class `button` or `content` within the provided element
 * Change the content of all `.button` elements with "hide"
 * When a `.button` is clicked:
 * Find the topmost `.content` element, that is before another `.button` and:
 * If the `.content` is visible:
 * Hide the `.content`
 * Change the content of the `.button` to "show"
 * If the `.content` is hidden:
 * Show the `.content`
 * Change the content of the `.button` to "hide"
 * If there isn't a `.content` element **after the clicked `.button`** and **before other `.button`**, do nothing
 * Throws if:
 * The provided ID is not a **jQuery object** or a `string`

 */

var jQuery = require('jquery');

function solve() {
	"use strict";
	return function (selector) {
		validation(selector);

		$('.button').html('hide');
		$(selector).on('click', '.button', function () {
			var $currentButton = $(this),
				contentElement = $currentButton.next() || undefined,
				displayProp;

			if (!contentElement) {
				return;
			}

			while (!contentElement.hasClass('content')) {
				contentElement = contentElement.next();

			}

			displayProp = contentElement.css('display');

			if (displayProp === '' || displayProp === 'block' || displayProp === 'inline-block' || displayProp === 'inline') {
				contentElement.css('display', 'none');
				$currentButton.html('show');
			} else {
				contentElement.css('display', '');
				$currentButton.html('hide');
			}
		});

		function validation(object) {
			if(!object){
				throw new Error('No params Provided!');
			}

			if (typeof (object) !== 'string') {
				throw new ReferenceError('Selector is not a jQuery or a string type!');
			}

			if($(object).length === 0){
			    throw new ReferenceError('Nothing selected!');
			}
		}
	};
}

module.exports = solve;