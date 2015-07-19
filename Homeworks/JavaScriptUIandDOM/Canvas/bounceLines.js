var canvas = document.getElementById('canvas');
var context = canvas.getContext('2d');
var x = 0,
    y = 120,
    leftBoundary = 0,
    topBoundary = 0,
    rightBoundary = canvas.width,
    bottomBoundary = canvas.height,
    direction = 'DR',
    countCrashedInBoundary = 0,
    color = '',
    fixedY,
    fixedX;

/*DR - DownRight
* UR - UpRight
* DL - DownLeft
* UL - UpLeft   */

context.strokeStyle = '#000';
context.lineWidth = 5;

function colorToString(){
    var red, green, blue;
    red = (Math.random() * 255) | 0;
    green = (Math.random() * 255) | 0;
    blue = (Math.random() * 255) | 0;
    return 'rgb(' + red + ', ' + green + ', ' + blue + ')';
}


function move(){
    switch (direction) {
        case 'DR':
            x += 10;
            y += 10;
            fixedX = x + 5;
            fixedY = y + 5;
            break;
        case 'UR':
            x += 10;
            y -= 10;
            fixedX = x + 5;
            fixedY = y - 5;
            break;
        case 'DL':
            x -= 10;
            y += 10;
            fixedX = x - 5;
            fixedY = y + 5;
            break;
        case 'UL':
            x -= 10;
            y -= 10;
            fixedX = x - 5;
            fixedY = y - 5;
            break;
        default: throw new Error('Invalid command');
    }

    context.beginPath();
    context.moveTo(x, y);
    context.lineTo(fixedX, fixedY);
    context.stroke();



    if(x <= leftBoundary){
        countCrashedInBoundary +=1;
        if (direction === 'DL') {
            direction = 'DR';
        } else {
            direction = 'UR';
        }
    }

    if(rightBoundary <= x){
        countCrashedInBoundary += 1;
        if (direction === 'DR') {
            direction = 'DL';
        } else {
            direction = 'UL';
        }
    }

    if(y <= topBoundary){
        countCrashedInBoundary += 1;
        if(direction === 'UR'){
            direction = 'DR';
        } else {
            direction = 'DL'
        }
    }

    if(bottomBoundary <= y){
        countCrashedInBoundary += 1;
        if(direction === 'DR'){
            direction = 'UR';
        } else {
            direction = 'UL';
        }
    }

    if(countCrashedInBoundary >= 26){
        context.strokeStyle = colorToString();
        countCrashedInBoundary = 0;
    }

    window.requestAnimationFrame(move);
}

window.requestAnimationFrame(move);