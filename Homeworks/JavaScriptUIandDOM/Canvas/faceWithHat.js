var face = (function () {
    var canvas = document.getElementById('face');
    var canvasContext = canvas.getContext('2d');
    var darkBLue = 'rgb(34, 84, 95)',
        lightBlue = 'rgb(133, 202, 215)',
        heavyBlue = 'rgb(57, 102, 147)',
        black = '#000';
    canvasContext.lineWidth = 5;
    canvasContext.strokeStyle = darkBLue;
    canvasContext.fillStyle = lightBlue;
    canvasContext.save();

    canvasContext.scale(1, 0.90);

    canvasContext.arc(120, 280, 110, 0, 2 * Math.PI);
    canvasContext.fill();
    canvasContext.stroke();

    // eyes
    canvasContext.scale(1, 0.65);
    canvasContext.beginPath();
    canvasContext.arc(60, 378, 20, 0, 2 * Math.PI);
    canvasContext.stroke();
    canvasContext.beginPath();
    canvasContext.arc(150, 378, 20, 0, 2 * Math.PI);
    canvasContext.stroke();

    canvasContext.restore();

    canvasContext.beginPath();
    canvasContext.fillStyle = darkBLue;
    canvasContext.scale(0.5, 1);
    canvasContext.arc(103, 221, 10, 0, 2 * Math.PI);
    canvasContext.fill();

    canvasContext.beginPath();
    canvasContext.arc(283, 221, 10, 0, 2 * Math.PI);
    canvasContext.fill();

    // nose
    canvasContext.restore();
    canvasContext.beginPath();
    canvasContext.moveTo(200, 215);
    canvasContext.lineTo(140, 272);
    canvasContext.lineTo(200, 272);
    canvasContext.stroke();

    // mouth
    canvasContext.setTransform(1, 0, 0, 1, 0, 0);
    canvasContext.lineWidth = 6;
    canvasContext.beginPath();
    canvasContext.translate(100, 290);
    canvasContext.rotate(15 * Math.PI / 180);
    canvasContext.scale(1, 0.3);
    canvasContext.arc(0, 55, 40, 0, 2 * Math.PI);
    canvasContext.stroke();

    // hat
    canvasContext.setTransform(1, 0, 0, 1, 0, 0);
    canvasContext.fillStyle = heavyBlue;
    canvasContext.strokeStyle = black;
    canvasContext.beginPath();
    canvasContext.scale(1.5, 0.3);
    canvasContext.arc(85, 555, 80, 0, 2 * Math.PI);
    canvasContext.fill();
    canvasContext.stroke();

    canvasContext.scale(1, 1.3);
    canvasContext.beginPath();
    canvasContext.arc(82, 50, 40, 0, 2 * Math.PI);
    canvasContext.fill();
    canvasContext.stroke();

    canvasContext.lineWidth = 4;
    canvasContext.lineTo(122, 400);
    canvasContext.stroke();

    canvasContext.arc(82, 400, 40,0, Math.PI);
    canvasContext.lineTo(42, 50);
    canvasContext.fill();
    canvasContext.stroke();

}());