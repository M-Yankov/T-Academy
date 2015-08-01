/*globals $*/
function solve() {
	"use strict";
	return function (selector) {
		validation(selector);

		var $selectElement = $(selector).css('display', 'none'),
			$mainDiv = $('<div />').addClass('dropdown-list'),
			$currentSelection = $('<div />').addClass('current').text('Select a value'),
			$containerDiv = $('<div />').addClass('options-container').css('position', 'absolute').css('display', 'none'),
			$optionsInSelect = $(selector + ' option'),
			$templateDiv,
			i,
			len,
			value,
			innerText;

		// getting options from select tag and attach it as div in divContainer
		for (i = 0, len = $optionsInSelect.length; i < len; i += 1) {
			value = $($optionsInSelect[i]).attr('value');
			innerText = $($optionsInSelect[i]).text();
			$templateDiv = $('<div />').addClass('dropdown-item').attr('data-value', value).attr('data-index', i).text(innerText);
			$containerDiv.append($templateDiv);
		}

		$mainDiv.append($selectElement, $currentSelection, $containerDiv);
		$('body').append($mainDiv);

		$currentSelection.on('click', function(){
			var display = $containerDiv.css('display');
			$(this).text('Select a value');
			if(display === 'none'){
				$containerDiv.css('display', '');
			} else {
				$containerDiv.css('display', 'none');
			}
		});

		$containerDiv.on('click', '.dropdown-item', function(){
			$selectElement.val($(this).attr('data-value'));
			var text = $(this).text();
			$containerDiv.css('display', 'none');
			$currentSelection.text(text);
		});

		function validation(item) {
			if (item && typeof (item) !== 'string') {
				throw new Error('Not expected type provided');
			}
		}
	};
}

// Works great in task-1.html
module.exports = solve;