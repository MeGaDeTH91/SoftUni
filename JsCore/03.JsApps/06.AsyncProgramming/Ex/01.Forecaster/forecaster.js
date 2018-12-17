function attachEvents(){
    let initialUrl = "https://judgetests.firebaseio.com/locations.json";
    $('#submit').on("click", getWeather);

    function getWeather(){
        $.get(initialUrl)
            .then(prepareInformation)
            .catch(displayError);
    }

    function prepareInformation(locations){
        let seekLocation = $('#location');
        let seekLocationVal = seekLocation.val();
        let locationCheck = locations.filter(x => x['name'] === seekLocationVal);

        if(locationCheck.length === 0){
            displayError();
        } else{
            let dayCode = `${locationCheck[0]['code']}`;
            let dayForecastUrl = "https://judgetests.firebaseio.com/forecast/today/" + dayCode + ".json";

            let threeDayCode = `${locationCheck[0]['code']}`;
            let threeDayForecastUrl = "https://judgetests.firebaseio.com/forecast/upcoming/" + threeDayCode + ".json";

            Promise.all([
                $.get(dayForecastUrl),
                $.get(threeDayForecastUrl)
            ]).then(handleDisplay)
                .catch(displayError);
        }

        function handleDisplay(args) {
            let dayWeatherResponse = args[0];
            let threeDayWeatherResponse = args[1];

            let currentDiv = $('#current');
            let forecastDiv = $('#forecast');
            let locationName = dayWeatherResponse['name'];
            let lowTemp = dayWeatherResponse['forecast']['low'];
            let highTemp = dayWeatherResponse['forecast']['high'];
            let condition = dayWeatherResponse['forecast']['condition'];

            let symbol = getProperWeatherSymbol(condition);

            currentDiv.append($('<span>').addClass('condition symbol').html(symbol));
            let conditionSpan = $('<span>').addClass('condition');

            conditionSpan.append($('<span>').addClass('forecast-data').html(locationName));
            conditionSpan.append($('<span>').addClass('forecast-data').html(`${lowTemp}&#176/${highTemp}&#176`));
            conditionSpan.append($('<span>').addClass('forecast-data').html(condition));
            currentDiv.append(conditionSpan);
            forecastDiv.css('display', 'block');

            let upcomingDiv = $('#upcoming');

            for (let i = 0; i < threeDayWeatherResponse['forecast'].length; i++) {
                let dayWeatherResponse = threeDayWeatherResponse['forecast'][i];

                let lowTemp = dayWeatherResponse['low'];
                let highTemp = dayWeatherResponse['high'];
                let condition = dayWeatherResponse['condition'];

                let symbol = getProperWeatherSymbol(condition);

                let upcomingSpan = $('<span>').addClass('upcoming');

                upcomingSpan.append($('<span>').addClass('symbol').html(symbol));
                upcomingSpan.append($('<span>').addClass('forecast-data').html(`${lowTemp}&#176/${highTemp}&#176`));
                upcomingSpan.append($('<span>').addClass('forecast-data').html(condition));
                upcomingDiv.append(upcomingSpan);

            }
        }
    }

    function displayError(){
        $('#forecast').html("Error").css('display', 'block');
    }
    function getProperWeatherSymbol(condition){
        switch (condition) {
            case "Sunny" : return "&#x2600";
            case "Partly sunny" : return "&#x26C5";
            case "Overcast" : return "&#x2601";
            case "Rain" : return "&#x2614";
        }
    }
}