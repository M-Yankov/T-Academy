(function () {
    var svgNS = 'http://www.w3.org/2000/svg',
        theSvgElement = document.getElementById('svg-draw'),
        fragment = createFragmentElement(), //document.createDocumentFragment(),
        margin = 5,
        lightBlue = 'rgb(45, 139, 239)',
        violet = 'rgb(120, 10, 120)',
        row = {
            first: '100',
            second: '165',
            third: '230',
            fourth: '295'
        },
        column = {
            first: '60',
            second: '125',
            third: '190',
            fourth: '255'
        },
        columnSecondGroup = {
            first: '400'
        };

    theSvgElement.style.backgroundColor = '#002565';
    theSvgElement.style.borderRadius = '15px';

    var squareWithTitle = createRectangle(column.first, row.first, lightBlue, '1', 'Store', './Images/google_play_new.png'),
        secondSquare = createRectangle(column.second, row.first, '#00aa00', '1', 'Photos', './Images/gallery.png'),
        mailSquare = createRectangle(column.first, row.second, '#7f2ffa', '1', 'Mail', './Images/Mail.png'),
        calendarSquare = createRectangle(column.second, row.second, '#f902a2', '1', 'Calendar', './Images/Calendar.png'),
        bluetoohtSqure = createRectangle(column.first, row.third, '#ff8905', '2', 'Bluetooth', './Images/Bluetooth.png'),
        internetExplorer = createRectangle(column.first, row.fourth, '#12559f', '2', 'Internet', './Images/IE.png'),
        recycleBin = createRectangle(column.third, row.first, '#555512', '2', 'Recycle', './Images/rec.png'),
        usbMenu = createRectangle(column.third, row.second, '#dddd00', '2', 'USB drive', './Images/usb.png'),
        options = createRectangle(column.third, row.third, lightBlue, '1', 'Options', './Images/Configure.png'),
        devices = createRectangle(column.fourth, row.third, violet, '1', 'Devices', './Images/Devices.png'),
        games = createRectangle(column.third, row.fourth, '#00aa00', '1', 'Games', './Images/Games.png'),
        music = createRectangle(column.fourth, row.fourth, violet, '1', 'Music', './Images/Music.png'),
        microphone = createRectangle(columnSecondGroup.first, row.first, '#990c6a', '2', 'Microphone', './Images/Microphone.png'),
        skype = createRectangle(columnSecondGroup.first, row.second, lightBlue, '2', 'Skype', './Images/Skype.png'),
        wifi = createRectangle(columnSecondGroup.first, row.third, '#344a99', '2', 'Connections', './Images/Signal.png'),
        player = createRectangle(columnSecondGroup.first, row.fourth, lightBlue, '2' , 'Player', './Images/player.png'),
        startText = createText('60', '50', 'Start', 'fill: white; stroke: none; font: 40px Segoe UI; font-weight: 100;'),
        firstName = createText('450', '40', 'Jason', 'fill: white; stroke: none; font: 20px Segoe UI; font-weight: 100;'),
        lastName = createText('460', '55' , 'Statham', 'fill: white; stroke: none; font: 10px Segoe UI; font-weight: 100;');

    var userImage = document.createElementNS(svgNS, 'image');
    userImage.setAttributeNS('http://www.w3.org/1999/xlink', 'href', './Images/jason.jpg');
    userImage.setAttribute('x', '500');
    userImage.setAttribute('y', '20');
    userImage.setAttribute('width', '40');
    userImage.setAttribute('height', '40');

    var firstQurve = document.createElementNS(svgNS, 'path'),
        secondQurve = document.createElementNS(svgNS, 'path');
    firstQurve.setAttribute('d', 'M0 80 Q110 60 182 120 T240 40 T50 0');
    firstQurve.setAttribute('style', 'fill: none; stroke: ' + lightBlue +'; opacity: 0.7;');
    secondQurve.setAttribute('d', 'M300 405 C250 280 370 280 350 200 S380 100 400 200 S500 350 860 103');
    secondQurve.setAttribute('style', 'fill: none; stroke: ' + lightBlue +'; opacity: 1;');


    fragment.appendManyNodes(squareWithTitle,
        firstQurve,
        secondQurve,
        startText,
        secondSquare,
        mailSquare,
        calendarSquare,
        bluetoohtSqure,
        internetExplorer,
        recycleBin,
        usbMenu,
        options,
        devices,
        games,
        music,
        microphone,
        skype,
        wifi,
        player,
        userImage,
        firstName,
        lastName
        );

    theSvgElement.appendChild(fragment);

    /**
     * @param {string} positionX
     * @param {string} positionY
     * @param {string} fillColor
     * @param {string} [size]
     * @param {string} [title]
     * @param {string} [imagePath]
     * @returns {Object} Array[0] = rect; [1] = text to it; [2] = icon image;
     */
    function createRectangle(positionX, positionY, fillColor, size, title, imagePath) {
        var height = '60',
            width,
            textTitle,
            imageTag,
            imageX,
            imageY,
            result = [];

        if (!size || size === '1') {
            width = '60';
        } else if (size === '2') {
            width = (120 + margin).toString();
        }


        var element = document.createElementNS(svgNS, 'rect');
        element.setAttributeNS(null, 'x', positionX);
        element.setAttribute('y', positionY);
        element.setAttribute('width', width);
        element.setAttribute('height', height);
        element.setAttribute('fill', fillColor);

        result.push(element);

        if (title) {
            textTitle = createText((+positionX + 5).toString(),
                (((positionY - 0) + (+height - 5))).toString(),
                title,
                'fill: white; stroke: none; font: 10px Segoe UI;');
            //element.appendChild(textTitle);
            result.push(textTitle);
        }

        if (imagePath) {
            imageX = (((positionX - 0) + (+width / 2)) - 16).toString();
            imageY = (((positionY - 0) + (+height / 2)) - 20).toString();
            imageTag = document.createElementNS(svgNS, 'image');
            imageTag.setAttributeNS('http://www.w3.org/1999/xlink', 'href', imagePath);
            imageTag.setAttribute('x', imageX);
            imageTag.setAttribute('y', imageY);
            imageTag.setAttribute('height', '32');
            imageTag.setAttribute('width', '32');
            imageTag.setAttribute('filter', 'url(#colorMeMatrix)');
            result.push(imageTag);
        }

        return result;
    }

    /**
     * @param {string} positionX
     * @param {string} positionY
     * @param {string} text
     * @param {string} fontCSSProperties
     * @returns {object}
     */
    function createText(positionX, positionY, text, fontCSSProperties) {
        var element = document.createElementNS(svgNS, 'text');
        element.setAttribute('x', positionX);
        element.setAttribute('y', positionY);
        element.setAttribute('style', fontCSSProperties);
        element.innerHTML = text;

        return element;
    }

    function createFragmentElement() {
        var element = document.createDocumentFragment();

        Object.defineProperties(element, {
            appendManyNodes: {
                value: function (args) {
                    var len = arguments.length,
                        i,
                        j,
                        subLen;
                    for (i = 0; i < len; i += 1) {
                        //console.log(this);
                        if (Array.isArray(arguments[i])) {
                            subLen = arguments[i].length;
                            for (j = 0; j < subLen; j += 1) {
                                this.appendChild(arguments[i][j]);
                            }

                            continue;
                        }
                        this.appendChild(arguments[i]);
                    }
                }
            }
        });

        return element;
    }
}());