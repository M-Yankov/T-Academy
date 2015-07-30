/* globals $ */

/* 

 Create a function that takes an id or DOM element and an array of contents

 * if an id is provided, select the element
 * Add divs to the element
 * Each div's content must be one of the items from the contents array
 * The function must remove all previous content from the DOM element provided
 * Throws if:
 * The provided first parameter is neither string or existing DOM element
 * The provided id does not select anything (there is no element that has such an id)
 * Any of the function params is missing
 * Any of the function params is not as described
 * Any of the contents is neight `string` or `number`
 * In that case, the content of the element **must not be** changed
 */
var solve = function () {
    return function (element, contents) {
        validation(element, contents);
        var len = contents.length,
            typeOfElement = typeof (element),
            htmlCode = '',
            i,
            DomElement;
        if(typeOfElement === 'string'){
            DomElement = document.getElementById(element);
        } else {
            DomElement = element;
        }

        for (i = 0; i < len; i += 1) {
            htmlCode += '<div>' + contents[i] + '</div>';
        }

        DomElement.innerHTML = htmlCode;

        function validation(el, content) {
            if (!(el && content)) {
                throw new Error('No param provided!');
            }

            if ((typeof (el) !== 'object' && typeof (el) !== 'string') || !Array.isArray(contents)) {
                throw new TypeError('Parameters is not a type that expected!');
            }

            if (typeof (el) !== 'string' && el.nodeName === undefined) {
                throw new TypeError('First params is nod an Id or DOM element!');
            }

            if (typeof (el) === 'string' && document.getElementById(el) === null) {
                throw new ReferenceError('provided Id isn\'t selecting a DOM element!');
            }

            if (!content.every(function(item){
                    var type = typeof (item);
                    return type === 'string' || type === 'number';
                })) {
                throw new TypeError('Not all items in contents are from the expected types!')
            }
        }
    };
};
module.exports = solve;