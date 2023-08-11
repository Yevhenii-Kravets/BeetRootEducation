
function createCalendar() {
    const calendarContainer = document.getElementById('calendar');

    const currentDate = new Date();

    const dateElement = document.createElement('p');
    dateElement.textContent = currentDate.toDateString();

    calendarContainer.appendChild(dateElement);
}
window.onload = createCalendar;

