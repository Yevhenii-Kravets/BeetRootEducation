$(function() {
    $('#datepicker').datepicker({
        changeYear: true,
        onSelect: function (date) {
            const selectedDate = new Date(date);
            const calendar = window.calendar;

            if (calendar.view.type === 'timeGridDay') {
                calendar.gotoDate(selectedDate);
            } else if (calendar.view.type === 'timeGridWeek') {
                calendar.gotoDate(selectedDate);
                calendar.changeView('timeGridWeek');
            } else if (calendar.view.type === 'dayGridMonth') {
                calendar.gotoDate(selectedDate);
                calendar.changeView('dayGridMonth');
            }
        }
    });
});

