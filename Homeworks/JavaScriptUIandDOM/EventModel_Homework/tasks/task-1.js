/* globals $ */

/*
 Create a function that takes an id or DOM element and:
 */


function solve() {
    "use strict";
    return function (selector) {
        existValidation(selector);
        var type = typeof (selector),
            DOMelement;

        switch (type) {
            case 'object':
                objectValidation(selector);
                DOMelement = selector;
                break;
            case 'string':
                stringValidation(selector);
                DOMelement = document.getElementById(selector);
                break;
            default:
                throw new Error('Not a selector or DOM element!');
        }

        var children = DOMelement.childNodes,
            len = children.length,
            i;
        for (i = 0; i < len; i += 1) {
            if (children[i].getAttribute('class') === 'button') {
                children[i].innerHTML = 'hide';
            }
        }

        DOMelement.addEventListener('click', function (ev) {
            var contentElement,
                currentButton,
                displayAttribute;

            currentButton = ev.target;
            contentElement = ev.target.nextElementSibling;
            while (contentElement.className !== 'content') {
                if (contentElement.className === 'button') {
                    return;
                }

                contentElement = contentElement.nextElementSibling;
            }

            displayAttribute = contentElement.getAttribute('style');

            if (displayAttribute === null || displayAttribute.indexOf('none') === -1) {
                contentElement.setAttribute('style', 'display: none');
                currentButton.innerHTML = 'show';
            } else {
                contentElement.style.display = '';
                currentButton.innerHTML = 'hide';
            }

        }, false);


        function objectValidation(item) {
            if (typeof (item) === 'object' && item.nodeName === undefined) {
                throw new Error('object is not a DOM Element!');
            }
        }

        function existValidation(item) {
            if (!item) {
                throw new Error('No params provided.');
            }
        }

        function stringValidation(item) {
            if (document.getElementById(item) === null) {
                throw new Error('Id is not selecting a element!');
            }
        }
    };
}

module.exports = solve;
