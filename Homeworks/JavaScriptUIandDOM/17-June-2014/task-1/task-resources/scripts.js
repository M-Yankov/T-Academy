function createImagesPreviewer(selector, items) {
	"use strict";
	var root = document.querySelector(selector),
		leftPanel = document.createElement('div'),
		rightPanel = document.createElement('div'),
		h3 = document.createElement('h3'),
		img = document.createElement('img'),
		label = document.createElement('label'),
		input = document.createElement('input'),
		fragment = document.createDocumentFragment(),
		imageList = document.createElement('div'),
		imageContainer = document.createElement('div'),
		strong = document.createElement('strong'),
		imgInCollection = document.createElement('img'),
		i,
		len;

	leftPanel.style.float = 'left';
	leftPanel.className += ' image-preview';
	rightPanel.style.float = 'left';

	h3.innerHTML = items[0].title;
	h3.style.textAlign = 'center';
	img.setAttribute('src', items[0].url);
	img.setAttribute('width', '300');
	img.style.borderRadius = '15px';

	leftPanel.appendChild(h3);
	leftPanel.appendChild(img);

	// right panel
	imageList.style.height = '300px';

	imageContainer.className += ' image-container';
	imageContainer.style.textAlign = 'center';

	imageList.className += ' image-List';
	imageList.style.overflowY = 'scroll';

	imgInCollection.setAttribute('width', '100');
	imgInCollection.style.borderRadius = '10px';
	imgInCollection.className += 'image-small';

	strong.style.display = 'block';
	strong.className += ' title';

	for (i = 0, len = items.length; i < len; i += 1) {
		imgInCollection.setAttribute('src', items[i].url);
		strong.innerHTML = items[i].title;
		imageContainer.appendChild(strong.cloneNode(true));
		imageContainer.appendChild(imgInCollection.cloneNode(true));
		imageList.appendChild(imageContainer.cloneNode(true));
		imageContainer.innerHTML = '';
	}

	label.setAttribute('for', 'filter');
	label.innerHTML = 'Filter';
	label.style.display = 'block';
	label.style.textAlign = 'Center';
	input.id = 'filter';

	fragment.appendChild(label);
	fragment.appendChild(input);
	fragment.appendChild(imageList);
	rightPanel.appendChild(fragment);

	imageList.addEventListener('click', function (ev) {
		var target = ev.target;
		if (target.className.indexOf('image-small') >= 0 || target.className.indexOf('title') >= 0) {
			target = target.parentNode;
		}
		// target is always a "div.image-container" element
		leftPanel.childNodes[0].innerHTML = target.childNodes[0].innerHTML;
		leftPanel.childNodes[1].setAttribute('src', target.childNodes[1].getAttribute('src'));

	}, false);

	imageList.addEventListener('mouseover', function (ev) {
		var target = ev.target;
		if (target.className.indexOf('image-List') >= 0) {
			return;
		}
		if (target.className.indexOf('image-small') >= 0 || target.className.indexOf('title') >= 0) {
			target = target.parentNode;
		}

		target.style.backgroundColor = '#ccc';
	}, false);

	imageList.addEventListener('mouseout', function (ev) {
		var target = ev.target;
		if (target.className.indexOf('image-List') >= 0) {
			return;
		}
		if (target.className.indexOf('image-small') >= 0 || target.className.indexOf('title') >= 0) {
			target = target.parentNode;
		}

		target.style.backgroundColor = '';
	}, false);

	input.addEventListener('input', function (ev) {

		var list = document.getElementsByClassName('image-container'),
			valueOfInput = ev.target.value.toLowerCase(),
			len,
			j;
		for (j = 0, len = list.length; j < len; j += 1) {
			if (list[j].childNodes[0].innerHTML.toLowerCase().indexOf(valueOfInput) >= 0) {
				list[j].style.display = 'block';
			} else {
				list[j].style.display = 'none';
			}
		}
	});

	root.appendChild(leftPanel);
	root.appendChild(rightPanel);

}