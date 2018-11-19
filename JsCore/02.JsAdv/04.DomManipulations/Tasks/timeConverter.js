function attachEventsListeners() {
    document.getElementById("daysBtn").addEventListener("click", () => {
        let days = +document.getElementById("days").value;

        document.getElementById("hours").value = days * 24;
        document.getElementById("minutes").value = days * 1440;
        document.getElementById("seconds").value = days * 86400;
    });

    document.getElementById("hoursBtn").addEventListener("click", () => {
        let hours = +document.getElementById("hours").value;

        document.getElementById("days").value = hours / 24;
        document.getElementById("minutes").value = hours * 60;
        document.getElementById("seconds").value = hours * 3600;
    });

    document.getElementById("minutesBtn").addEventListener("click", () => {
        let minutes = +document.getElementById("minutes").value;

        document.getElementById("days").value = minutes / 1440;
        document.getElementById("hours").value = minutes / 60;
        document.getElementById("seconds").value = minutes * 60;
    });

    document.getElementById("secondsBtn").addEventListener("click", () => {
        let seconds = +document.getElementById("seconds").value;

        document.getElementById("days").value = seconds / 86400;
        document.getElementById("hours").value = seconds / 3600;
        document.getElementById("minutes").value = seconds / 60;
    });

}