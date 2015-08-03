/*globals $*/
$.fn.tabs = function () {
	"use strict";
	$('#tabs-container').attr('style', 'display: inline-block; ' +
		'position: relative; overflow: auto; height: 300px;' +
		'border: 1px solid #000; border-radius: 5px; background-color: #ccc');
	$('#tabs-container .tab-item').attr('style', 'display: inline-block');
	$('#tabs-container .tab-item:first-of-type .tab-item-title').attr('style', 'border-left: none');
	$('#tabs-container .tab-item-title').attr('style', 'display: inline-block; padding: 5px 15px;' +
		'margin-bottom: 2px; border-left: 1px solid #000; border-bottom: 1px solid #000;' +
		'background-color: #fff');
	$('#tabs-container .tab-item-title:hover').attr('style', 'cursor: pointer; background-color: #999;');
	$('#tabs-container .tab-item-content').attr('style', 'position: absolute; left: 0; padding: 5px; background-color: #ccc; display: none');
	// $('#tabs-container .tab-item:first-of-type').addClass('current');

	$('#tabs-container .tab-item-title').on('mouseenter', function () {
		//$('.tab-item-title').css('cursor', 'default').css('background-color','#fff');
		$(this).css('cursor', 'pointer').css('background-color', '#999');
	});

	$('#tabs-container .tab-item-title').on('mouseleave', function () {
		$('.tab-item-title').each(function(index, item){
			if($(item).attr('myAttr') !== 'true'){

				$(item).css('cursor', 'default').css('background-color', '#fff');
			} else {
				$(item).css('cursor', 'default').css('background-color', '#ccc');
			}
		});
	});

	$('.tab-item .tab-item-title').on('click', function () {
		$('.tab-item-title')
			.css('border-bottom','1px solid #000')
			.css('background-color', '#fff')
			.css('font-style', 'normal')
			.attr('myAttr','false');

		$(this).css('border-bottom', 'none')
			.css('background-color', '#ccc')
			.css('font-style', 'italic')
			.attr('myAttr','true');

		$('.tab-item-content').css('display', 'none');
		$(this).next().css('display', '');

	});
};