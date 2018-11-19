function timer() {
    let hours = $('#hours');
    let minutes = $('#minutes');
    let seconds = $('#seconds');

    let startButton = $('#start-timer');
    let stopButton = $('#stop-timer');

    let currentSecondCount = 0;
    let timer = null;

    $(startButton).on("click", start);
    $(stopButton).on("click", stop);

    function start(){
        if(timer === null){
            timer = setInterval(incrementTime, 1000)
        }
        function incrementTime(){
            currentSecondCount++;

            hours.text(('0' + Math.floor(currentSecondCount / 60 / 60)).slice(-2));
            minutes.text(('0' + Math.floor(currentSecondCount / 60) % 60).slice(-2));
            seconds.text(('0' + Math.floor(currentSecondCount % 60)).slice(-2));
        }
    }
    function stop(){
        clearInterval(timer);
        timer = null;
    }
}
