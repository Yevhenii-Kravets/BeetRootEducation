document.addEventListener('DOMContentLoaded', function () {
    var startTime = document.getElementById('datetimeStart');
    var endTime = document.getElementById('datetimeEnd');

    var currentDate = new Date();
    currentDate.setHours(currentDate.getHours() + 3);
    var formattedDate = currentDate.toISOString().substr(0, 16);
    startTime.value = formattedDate;

    currentDate.setHours(currentDate.getHours() + 24);
    var formattedDate = currentDate.toISOString().substr(0, 16);
    endTime.value = formattedDate;
});