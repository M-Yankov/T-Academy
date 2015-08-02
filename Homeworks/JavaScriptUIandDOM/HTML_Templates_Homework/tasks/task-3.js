/*globals $, handlebars*/
function solve() {
	"use strict";
	return function () {
		$.fn.listview = function (data) {
			var $that = $(this),
				dataTemplateAttribute = $that.attr('data-template'),
				htmlCodeTemplate = $('#' + dataTemplateAttribute).html(),
				template = handlebars.compile(htmlCodeTemplate),
				fragment = document.createDocumentFragment(),
				len,
				i;

			for (i = 0, len = data.length; i <len; i += 1) {
				$(fragment).append(template(data[i]));
			}

			$that.append(fragment);

			// activate chaining
			return this;
		};
	};
}

module.exports = solve;