
document.addEventListener('DOMContentLoaded', function () {
    const calendarEl = document.getElementById('calendar');
    const calendar = new FullCalendar.Calendar(calendarEl, {
        selectable: true,
        customButtons: {
            MonthButton: { text: 'Month', click: function () { calendar.changeView('dayGridMonth');}},
            WeekButton: { text: 'Week', click: function () { calendar.changeView('timeGridWeek'); }},
            DayButton: { text: 'Day', click: function () { calendar.changeView('timeGridDay'); }}
        },
        headerToolbar: {
            left: 'prev,today,next',
            center: 'title',
            right: 'MonthButton,WeekButton,DayButton'
        },
        height: '100%',
    });
    calendar.render();

    var addButton = document.getElementById('addEvent');
    addButton.addEventListener('click', function () {

        var title = document.getElementById('inputTitle');
        var startTime = document.getElementById('datetimeStart');
        var endTime = document.getElementById('datetimeEnd');
        var backColor = document.getElementById('colorBackground');
        var textColor = document.getElementById('colorText');

        calendar.addEvent({
            title: title.value,
            textColor: textColor.value,
            backgroundColor: backColor.value,
            classNames: ['event-textsize','breadcrumb'],
            start: startTime.value,
            end: endTime.value
        });
    });

    window.calendar = calendar;
});




