import $ from 'jquery'; // works because config.js map.jquery
import db from 'app/db'; // = ./db

export function init($element) {
    "use strict";
    let $list = $('<ul />');
    let $input;

    $element = $($element);

    console.log(db.all());

    db.all()
        .forEach((item) => {
            createItem(item)
                .appendTo($list);
        });

    $('<label />')
        .text('Text: ')
        .attr('for', 'input-value')
        .appendTo($element);

    $input = $('<input />')
        .attr('id', 'input-value')
        .appendTo($element);

    $('<a />')
        .addClass('button')
        .attr('href', '#')
        .text('add')
        .appendTo($element)
        .on('click', function () {
            let text = $input.val();
            $input.val('');
            var matcher = new RegExp('[A-z]|[0-9]|[!@#$%^&*(&)]');
            if (!matcher.test(text)) {
            	return;
            }

            let obj = {
                text
            };
            db.add(obj);
            createItem(obj)
                .appendTo($list);
        });

    $list.addClass('items-list')
        .appendTo($element)
        .on('click', '.button', function () {
            let $this = $(this);
            let $parent = $this.parent();
            let id = $parent.attr('data-id') | 0;
            db.removeByID(id);
            $parent.remove();
        });

    function createItem(obj) {
        return $('<li/>')
            .addClass('list-item')
            .attr('data-id', obj.id)
            .append($('<strong />')
                .html(obj.text))
            .append($('<a/>')
                .addClass('button')
                .attr('href', '#')
                .text('X'));
    }
}

/*$('<h1 />')
 .text('Loaded!')
 .appendTo('body');*/
