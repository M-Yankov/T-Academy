function createCalendar(selector, events) {
	"use strict";
	var table = document.createElement('table'),
		tableRow = document.createElement('tr'),
		tableCell = document.createElement('td'),
		divHead = document.createElement('div'),
		divContent = document.createElement('div'),
		style = document.createElement('style'),
		daysInJune = 30,
		month = 'June 2014',
		day = '',
		i,
		j,
		len;

	style.type = 'text/css';
	style.innerHTML = '.divHead {' +
		'text-align: center; ' +
		'background-color: #ccc;' +
		'font: 12px Arial' +
		'} ' +
		'.divContent {' +
		'height: 100px; ' +
		'}' +
		'td {' +
		'width: 150px;' +
		'border: 1px solid black' +
		'}';
	document.getElementsByTagName('head')[0].appendChild(style);

	for (i = 0; i <= daysInJune; i += 1) {
		day = dayOfWeek(i % 7);
		tableCell.id = 'day-' + (i + 1);
		divHead.innerHTML = day + ' ' + (i + 1) + ' ' + month;

		divHead.className = 'divHead';
		divContent.className = 'divContent';

		tableCell.appendChild(divHead.cloneNode(true));
		tableCell.appendChild(divContent.cloneNode(true));
		tableRow.appendChild(tableCell.cloneNode(true));

		if (i % 7 === 6) {
			table.appendChild(tableRow.cloneNode(true));
			tableRow.innerHTML = '';
		} else if (i === daysInJune) {
			table.appendChild(tableRow.cloneNode(true));
			tableRow.innerHTML = '';
		}

		tableCell.innerHTML = '';
	}

	table.setAttribute('cellspacing', '0');
	document.getElementById(selector).appendChild(table);

	for (j = 0, len = events.length; j < len; j += 1) {
		if (events[j].date > 30) {
			throw new Error('Not actual date');
		}
		document.getElementById('day-' + events[j].date).lastElementChild.innerHTML =
			events[j].hour + ' ' + events[j].title;
	}

	document.getElementsByTagName('table')[0].addEventListener('mouseover', function (ev) {
		var target = ev.target,
			cells = document.getElementsByTagName('td'),
			k,
			len;
		for (k = 0, len = cells.length; k < len; k += 1) {
			cells[k].firstElementChild.style.backgroundColor = '#ccc';
		}

		if (target.nodeName === 'DIV' && target.className.indexOf('divContent') !== -1) {
			target.previousElementSibling.style.backgroundColor = 'yellow';
		}
	});

	document.getElementsByTagName('table')[0].addEventListener('click', function (ev) {
		var target = ev.target,
			cells = document.getElementsByTagName('td'),
			k,
			len;

		for (k = 0, len = cells.length; k < len; k += 1) {
			cells[k].lastElementChild.style.backgroundColor = 'white';
		}

		if (target.nodeName === 'DIV' && target.className.indexOf('divContent') !== -1) {
			target.style.backgroundColor = 'green';
		}
	});

	function dayOfWeek(number) {
		var day = '';

		switch (number) {
			case 0:
				day = 'Sun';
				break;
			case 1:
				day = 'Mon';
				break;
			case 2:
				day = 'Tue';
				break;
			case 3:
				day = 'Wed';
				break;
			case 4:
				day = 'Thu';
				break;
			case 5:
				day = 'Fri';
				break;
			case 6:
				day = 'Sat';
				break;
			default:
				throw new Error(number + ' is not > 1 and < 7.');
		}

		return day;
	}
}