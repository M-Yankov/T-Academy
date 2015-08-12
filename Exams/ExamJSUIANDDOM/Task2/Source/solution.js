/*globals $*/
function solve() {
	"use strict";
	$.fn.datepicker = function () {
		var MONTH_NAMES = [
			{name: "January", days: 31},
			{name: "February", days: 28},
			{name: "March", days: 31},
			{name: "April", days: 30},
			{name: "May", days: 31},
			{name: "June", days: 30},
			{name: "July", days: 31},
			{name: "August", days: 31},
			{name: "September", days: 30},
			{name: "October", days: 31},
			{name: "November", days: 30},
			{name: "December", days: 31}];
		var WEEK_DAY_NAMES = ['Su', 'Mo', 'Tu', 'We', 'Th', 'Fr', 'Sa'];
		var CELLS_IN_CALENDAR = 42;

		Date.prototype.getMonthName = function () {
			return MONTH_NAMES[this.getMonth()].name;
		};

		Date.prototype.getDayName = function () {
			return WEEK_DAY_NAMES[this.getDay()];
		};

		// you are welcome :)
		var date = new Date();
		console.log(date.getDayName());
		console.log(date.getMonthName());
		console.log(date.getDay());

		var $wrapper = $('<div class="datepicker-wrapper"></div>'),
			$input = $('#date'),
			$parent = $input.parent();
		$input.addClass('datepicker');
		$input.appendTo($wrapper);
		$parent.append($wrapper);
		// Ready

		var $datepickerContent = $('<div class="datepicker-content"></div>'),
			$controls = $('<div class="controls"></div>'),
			$buttonLeft = $('<button class="btn"></button>'),
			$buttonRight = $('<button class="btn"></button>'),
			$currentMonth = $('<div class="current-month"></div>'),
			$currentDate = $('<div class="current-date-link"></div>'),
			$tableCalendar = $('<table class="calendar"></table>'),
			$tableRow = $('<tr></tr>'),
			i,
			start,
			currentMonth = date.getMonth(),
			currentYear = date.getFullYear() - 0,
			isCalendarShowed;

		start = date.getDay();

		$tableCalendar.attr('style',
			'border-collapse: collapse; ' +
			'margin: 10px; ' +
			'margin-top: 10px; ' +
			'position: initial ;' +
			'top: 0; ');

		function generateArrayWithCorrectDays(change) {

			$tableCalendar.html('');

			for (var j = 0; j < 7; j += 1) {
				$tableRow.append($('<th />').html(WEEK_DAY_NAMES[j]));
			}

			$tableCalendar.append($tableRow.clone());
			$tableRow.html('');

			currentMonth += change;

			if (currentMonth > 11) {
				currentMonth = 0;
			}

			if (currentMonth < 0) {
				currentMonth = 11;
			}

			var daysPrevMonth = MONTH_NAMES[currentMonth - 1 < 0 ? 11 : currentMonth - 1].days;
			var firstDatemonth = new Date(currentYear, currentMonth, 1),
				startOn = firstDatemonth.getDay(); // 0 = sunday;

			var array = [];

			for (var l = 0; l < startOn; l += 1) {
				array.push('<td class="another-month">' + (daysPrevMonth - (startOn - (l + 1))) + '</td>');
			}

			for (var m = 0; m < MONTH_NAMES[currentMonth].days; m += 1) {
				array.push('<td  class="current-month">' + (m + 1) + '</td>');
			}

			for (var p = 0; array.length < CELLS_IN_CALENDAR; p += 1) {
				array.push('<td class="another-month">' + (p + 1) + '</td>');
			}

			var counter;
			for (i = 0, counter = 1; i <= CELLS_IN_CALENDAR; i += 1, counter += 1) {
				if (counter % 8 === 0) {
					counter = 1;
					$tableCalendar.append($tableRow.clone());
					$tableRow.html('');
				}

				$tableRow.append($(array[i]));
			}
		}

		generateArrayWithCorrectDays(0);

		$buttonLeft.html('<');
		$buttonLeft.addClass('left');
		$currentMonth.html(date.getMonthName() + ' ' + date.getFullYear());
		$buttonRight.html('>');
		$buttonRight.addClass('right');

		$currentDate.html(date.getDate() + ' ' + date.getMonthName() + ' ' + date.getFullYear());
		/*$currentDate.addClass('controls');*/
		$currentDate.css('padding', '7px');
		$currentDate.css('text-align', 'center');

		/*$datepickerContent.css('height', '285px');*/
		$controls.append($buttonLeft, $currentMonth, $buttonRight);
		$datepickerContent.append($controls.clone(), $tableCalendar);
		$controls.html('').append($currentDate);
		$datepickerContent.append($controls);
		$wrapper.append($datepickerContent);

		$('.right').on('click', function () {
			/*currentMonth += 1;*/

			generateArrayWithCorrectDays(1);

			var innerHTMLCurrentmonth = $('.controls .current-month').html(),
				month = MONTH_NAMES[currentMonth].name;
			if (innerHTMLCurrentmonth.indexOf("December") >= 0) {
				currentYear += 1;
				month = MONTH_NAMES[0].name;
			}

			$('.controls .current-month').html(month + ' ' + currentYear);
			// $('.current-month').html(MONTH_NAMES[currentMonth].name + ' ' + date.getFullYear());
		});

		$('.left').on('click', function () {

			generateArrayWithCorrectDays(-1);

			var innerHTMLCurrentmonth = $('.controls .current-month').html(),
				month = MONTH_NAMES[currentMonth].name;
			if (innerHTMLCurrentmonth.indexOf("January") >= 0) {
				currentYear -= 1;
				month = MONTH_NAMES[MONTH_NAMES.length - 1].name;
			}

			$('.controls .current-month').html(month + ' ' + currentYear);
		});

		$('.current-date-link').on('click', function () {
			isCalendarShowed = false;
			$('#date').html('');
			$('#date').attr('value', date.getDate() + '/' + (date.getMonth() + 1) + '/' + date.getFullYear());
			$('.datepicker-content').hide();
		});

		$('.calendar').on('click', '.current-month', function () {


			isCalendarShowed = false;
			var value = $(this).html();
			$('#date').html('');
			$('#date').attr('value', value + '/' + (currentMonth + 1) + '/' + currentYear);
			$('.datepicker-content').hide();
		});

		$('.datepicker').focus(function () {
			isCalendarShowed = true;
			$('.datepicker-content').show();
		});


		return this;
	};
}