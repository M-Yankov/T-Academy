function solve() {
	"use strict";
	return function (selector, isCaseSensitive) {

		// after implement to call validation
		var root = document.querySelector(selector),
			divAddControls = document.createElement('div'),
			divSearch = document.createElement('div'),
			divResult = document.createElement('div'),
			itemsList = document.createElement('ul'),
			singleListItem = document.createElement('li'),
			removeButton = document.createElement('button'),
			textInItem = document.createElement('span'),
			label = document.createElement('label'),
			span = document.createElement('span'),
			addInput = document.createElement('input'),
			searchInput = document.createElement('input'),
			addButton = document.createElement('button'),
			fragment = document.createDocumentFragment();

		root.className += ' items-control';
		divAddControls.className += ' add-controls';/*
		divAddControls.style.textAlignAll = 'center';*/

		singleListItem.className += ' list-item';

		label.innerHTML = 'Enter text';
		label.setAttribute('for', 'input');

		addInput.id = 'input';
		addButton.innerHTML = 'Add';
		addButton.className += ' button';

		divAddControls.appendChild(label.cloneNode(true));
		divAddControls.appendChild(addInput.cloneNode(true));
		divAddControls.appendChild(addButton);

		removeButton.innerHTML = 'X';
		removeButton.className += ' button remove';

		addButton.addEventListener('click', function(ev){
			var target = ev.target,
				input = target.previousElementSibling,
				textFromInput = input.value,
				listItems = document.querySelector('.items-list');
			textInItem.innerHTML = textFromInput;

			singleListItem.appendChild(removeButton.cloneNode(true));
			singleListItem.appendChild(textInItem.cloneNode(true));
			listItems.appendChild(singleListItem.cloneNode(true));
			singleListItem.innerHTML = '';
		}, false);


		// search
		divSearch.className += ' search-controls';
		label.innerHTML = 'Search:';

		searchInput.id = 'search';
		divSearch.appendChild(label.cloneNode(true));
		divSearch.appendChild(searchInput); //no clone node here

		searchInput.addEventListener('input', function (ev) {

			var target = ev.target,
				isSearchSensitive = isCaseSensitive,
				allElementsInList = document.querySelectorAll('.list-item'),
				value = target.value,
				i,
				len,
				currentNode;


			for (i = 0, len = allElementsInList.length; i < len; i += 1) {
				currentNode = allElementsInList[i].childNodes[1];

				if (isSearchSensitive) {
					if (currentNode.innerHTML.indexOf(value) >= 0) {
						currentNode.parentNode.style.display = '';
					} else {
						currentNode.parentNode.style.display = 'none';
					}
				} else {
					if (currentNode.innerHTML.toLowerCase().indexOf(value.toLowerCase()) >= 0) {
						currentNode.parentNode.style.display = '';
					} else {
						currentNode.parentNode.style.display = 'none';
					}
				}
			}


		}, false);



		//Results
		divResult.className += ' result-controls';
		itemsList.className += ' items-list';
		divResult.appendChild(itemsList);

		divResult.addEventListener('click', function (ev) {
		    var target = ev.target,
				grandParent;

			if (target.nodeName !== 'BUTTON' && target.innerHTML !== 'X') {
				return;
			}

			grandParent = target.parentNode.parentNode;
			grandParent.removeChild(target.parentNode);

		});

		// todo implement Remove;
		/*  -------------  */
		fragment.appendChild(divAddControls);
		fragment.appendChild(divSearch);
		fragment.appendChild(divResult);

		root.appendChild(fragment);

		function validation(selector) {
			if (typeof (selector) !== 'string' ) {
				throw new Error('Is not a string');
			} else if (!selector.nodeName) {
				throw new Error('Is not a string and not a ');
			}
		}
	};
}

module.exports = solve;