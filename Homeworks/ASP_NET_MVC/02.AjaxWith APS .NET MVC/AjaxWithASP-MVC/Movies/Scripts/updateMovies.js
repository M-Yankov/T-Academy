function OnAjaxRequestComplete(requset, status) {
    $.get('/Movies/All', function (data) {

        var $movies = $(data).filter("#all-movies");
        if (!$movies.length) {
            return;
        }

        $("#all-movies").html($movies.html())
    })
}