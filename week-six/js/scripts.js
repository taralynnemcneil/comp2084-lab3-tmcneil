// date picker

$(function () {
    $('#datetimepicker1').datetimepicker();
});

// use jquery to attach a confirmation for deleting objects with class confirm

$('.confirm').on('click', function () {
    return confirm('Are you sure you want to delete this?');
});