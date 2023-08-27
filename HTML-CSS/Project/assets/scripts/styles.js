$(document).ready(function () {
    $('.fc-button').each(function () {
        $(this).removeClass();
        $(this).addClass('btn btn-outline-secondary');
    });
});

$(document).ready(function () {
    $('.fc-event.fc-event-draggable.fc-event-start.fc-event-end.fc-event-past.fc-daygrid-event.fc-daygrid-block-event.fc-h-event').each(function () {
        $(this).addClass('hd-border');
    });
});