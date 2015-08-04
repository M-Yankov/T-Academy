/* globals $ */

$.fn.gallery = function (cols) {
	"use strict";
	var columns = cols || 4,
		gallery = $('#gallery'),
		selected = $('.selected'),
		imageContainers = $('.image-container'),
		counter = 1,
		isInSelected,
		len,
		i;

	for (i = 0, len = imageContainers.length; i < len; i += 1) {
		if (counter === columns) {
			$('<div class="clearfix"></div>').insertAfter(imageContainers[i]);
			counter = 1;
		} else {
			counter += 1;
		}
	}

	imageContainers.on('click', 'img', function () {
		var dataInfoCurrent = $(this).attr('data-info'),
			srcCurrent = $(this).attr('src'),
			srcPrev,
			srcNext,
			dataInfoPrev,
			dataInfoNext;

		dataInfoCurrent -= 0;

		if (isInSelected) {
			return;
		}

		if (dataInfoCurrent - 1 < 1) {
			srcPrev = getElementSrc('12'); // string?
			dataInfoPrev = 12;
		} else {
			srcPrev = getElementSrc((dataInfoCurrent - 1) + '');
			dataInfoPrev = dataInfoCurrent - 1;
		}

		if (dataInfoCurrent + 1 > 12) {
			srcNext = getElementSrc('1');
			dataInfoNext = 1;
		} else {
			srcNext = getElementSrc((dataInfoCurrent + 1) + '');
			dataInfoNext = dataInfoCurrent + 1;
		}

		if (!(srcCurrent && srcNext && srcPrev)) {
			throw new Error('Some src attribute is null');
		}

		selected.find('#current-image').attr('src', srcCurrent).attr('data-info', dataInfoCurrent);
		selected.find('#previous-image').attr('src', srcPrev).attr('data-info', dataInfoPrev);
		selected.find('#next-image').attr('src', srcNext).attr('data-info', dataInfoNext);
		selected.show();

		$('.gallery-list').addClass('blurred').addClass('disabled-background');

		isInSelected = true;
	});

	selected.find('#current-image').on('click', function () {
		$('.gallery-list').removeClass('blurred').removeClass('disabled-background');
		selected.hide();
		isInSelected = false;
	});

	selected.find('#previous-image').on('click', function () {
		var currentDataInfo = selected.find('#current-image').attr('data-info'),
			prevDataInfo = selected.find('#previous-image').attr('data-info'),
			prevPrevDataInfo,
			prevSrc,
			currentSrc,
			nextSrc;
		// -> prev -> current ->> next


		if ((prevDataInfo-0) - 1 < 1) {
			prevPrevDataInfo = '12';
		} else {
			prevPrevDataInfo = (+prevDataInfo - 1) + '';
		}

		prevSrc = getElementSrc(prevPrevDataInfo);
		currentSrc = getElementSrc(prevDataInfo);
		nextSrc = getElementSrc(currentDataInfo);

		selected.find('#current-image').attr('src', currentSrc).attr('data-info', prevDataInfo);
		selected.find('#previous-image').attr('src', prevSrc).attr('data-info', prevPrevDataInfo);
		selected.find('#next-image').attr('src', nextSrc).attr('data-info', currentDataInfo);
	});

	selected.find('#next-image').on('click', function () {
		var currentDataInfo = selected.find('#current-image').attr('data-info'),
			nextDataInfo = selected.find('#next-image').attr('data-info'),
			nextNextDataInfo,
			prevSrc,
			currentSrc,
			nextSrc;

		if ((nextDataInfo-0) + 1 > 12) {
			nextNextDataInfo = '1';
		} else {
			nextNextDataInfo = ((nextDataInfo-0) + 1) + '';
		}

		prevSrc = getElementSrc(currentDataInfo);
		currentSrc = getElementSrc(nextDataInfo);
		nextSrc = getElementSrc(nextNextDataInfo);

		selected.find('#current-image').attr('src', currentSrc).attr('data-info', nextDataInfo);
		selected.find('#previous-image').attr('src', prevSrc).attr('data-info', currentDataInfo);
		selected.find('#next-image').attr('src', nextSrc).attr('data-info', nextNextDataInfo);
	});

	selected.hide();//css('display', 'none');
	gallery.addClass('gallery');

	/**
	 *
	 * @param {string} dataInfo
	 * @returns {object}
	 */
	function getElementSrc(dataInfo) {
		var len,
			j;

		for (j = 0, len = imageContainers.length; j < len; j += 1) {
			if ($(imageContainers[j]).find('img').attr('data-info') === dataInfo) {
				return $(imageContainers[j]).find('img').attr('src');
			}
		}

		return null;
	}
};