(function(){
    var canvas = document.getElementById('house');
    var context = canvas.getContext('2d');
    var violet = 'rgb(151, 91, 91)',
        black = '#000',
        fix = 40,
        doorHeight = 120,
        doorBeginX = 50,
        doorWidth = 125,
        chimneyWidth = 50;

    context.lineWidth = 5;
    context.strokeStyle = black;
    context.fillStyle = violet;
    context.save();

    // fundamentals
    context.fillRect(0, canvas.height /2 - fix, canvas.width, canvas.height /2 + fix);
    context.strokeRect(0, canvas.height /2 - fix, canvas.width, canvas.height /2 + fix);

    // top
    context.beginPath();
    context.moveTo(canvas.width / 2, 0);
    context.lineTo(0, canvas.height /2 - fix);
    context.lineTo(canvas.width, canvas.height /2 - fix);
    context.closePath();
    context.fill();
    context.stroke();

    // door
    context.beginPath();
    context.moveTo(doorBeginX, canvas.height);
    context.lineTo(doorBeginX, canvas.height - doorHeight);
    context.quadraticCurveTo(115, 415, doorBeginX + doorWidth,canvas.height - doorHeight);
    context.lineTo(doorBeginX + doorWidth, canvas.height);
    context.moveTo((doorBeginX + doorWidth) - (doorWidth / 2), canvas.height);
    context.lineTo((doorBeginX + doorWidth) - (doorWidth / 2), canvas.height - doorHeight - 30);
    context.stroke();

    // door > handle doors
    context.beginPath();
    context.arc(95, 550, 6.5, 0, Math.PI * 2);
    context.stroke();

    context.beginPath();
    context.arc(130, 550, 6.5, 0, Math.PI * 2);
    context.stroke();

    // windows
    drawWindow(35, 290);
    drawWindow(255, 290);
    drawWindow(255, 435);

    // chimney
    context.beginPath();
    context.moveTo(365, 190);
    context.lineTo(365, 60);
    context.stroke();
    context.scale(1, 0.3);
    context.arc((10 + 365) - chimneyWidth /2, 200, 15, 0, 2 * Math.PI);
    context.arc((10 + 365) - chimneyWidth /2, 200, 15, 0, Math.PI);
    context.setTransform(1, 0, 0, 1, 0, 0);
    context.lineTo(365 - chimneyWidth + 20, 190);
    context.fillStyle = violet;
    context.fill();
    context.stroke();

    function drawWindow(x, y) {
        var width = 80,
            height = 50,
            offset = 5;
        context.beginPath();
        context.fillStyle = black;
        context.fillRect(x, y, width, height);
        context.fillRect(x + width + offset, y, width, height);
        context.fillRect(x, y + height + offset, width, height);
        context.fillRect(x + width + offset, y + height + offset, width, height);
        context.restore();
    }

}());