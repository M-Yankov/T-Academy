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