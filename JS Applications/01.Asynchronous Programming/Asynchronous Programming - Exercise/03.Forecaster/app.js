function attachEvents() {
    //console.log("TODO...");
    const baseUrl = 'http://localhost:3030/jsonstore/forecaster/locations';
    document.getElementById('submit').addEventListener('click', getWeather);

    const forecast = document.getElementById('forecast');
    const current = document.getElementById('current');
    const upcoming = document.getElementById('upcoming');

    let forecasts = document.createElement("div");
    forecasts.classList.add('forecast-info');

    const weatherSymbols = {
        'Sunny': '&#x2600;',
        'Partly sunny': '&#x26C5;',
        'Overcast': '&#x2601;',
        'Rain': '&#x2614;',
        'Degrees': '&#176;'
    };

    async function getWeather() {
        try {
            const location = document.getElementById('location');

            const response = await fetch(baseUrl);
            const data = await response.json();

            let city = data.find(obj => obj.name === location.value)
            let locationCode = city.code;

            let url = 'http://localhost:3030/jsonstore/forecaster'

            let todayForecast = await fetch(`${url}/today/${locationCode}`);
            let todaysData = await todayForecast.json();

            let upcoming = await fetch(`${url}/upcoming/${locationCode}`);
            let upcomingData = await upcoming.json();

            getTodaysWeather(todaysData);
            getUpcomingWeather(upcomingData);

        } catch (error) {
            current.innerHTML = '';
            upcoming.innerHTML = '';
            forecast.style.display = 'block';
            document.querySelector(".label").textContent = "Error";
        }
    }

    function getTodaysWeather(data) {
        forecast.style.display = 'block';
        const { condition, high, low } = data.forecast;

        let forecasts = document.createElement("div");
        forecasts.classList.add('forecasts');
        let conditionSymbol = document.createElement('span')
        conditionSymbol.classList.add('condition', 'symbol');
        conditionSymbol.innerHTML = weatherSymbols[condition];

        let currentConditions = document.createElement('span');
        currentConditions.classList.add('condition');

        let cityName = document.createElement('span');
        cityName.classList.add('forecast-data');
        cityName.textContent = data.name

        let degrees = document.createElement('span');
        degrees.classList.add('forecast-data');
        degrees.innerHTML = `${low}${weatherSymbols["Degrees"]}/${high}${weatherSymbols["Degrees"]}`

        let weather = document.createElement('span');
        weather.classList.add('forecast-data');
        weather.textContent = condition;

        currentConditions.appendChild(cityName);
        currentConditions.appendChild(degrees);
        currentConditions.appendChild(weather);

        forecasts.appendChild(conditionSymbol);
        forecasts.appendChild(currentConditions);

        current.appendChild(forecasts);
    }

    function getUpcomingWeather(data) {  
        for (const day of data.forecast) {
            const { condition, high, low } = data.forecast;

            // let forecasts = document.createElement("div");
            // forecasts.classList.add('forecast-info');

            let upcomingForecast = document.createElement("span");
            upcomingForecast.classList.add('upcoming');

            let symbol = document.createElement("span");
            symbol.classList.add('symbol');
            symbol.innerHTML = weatherSymbols[day.condition];

            let degrees = document.createElement('span');
            degrees.classList.add('forecast-data');
            degrees.innerHTML = `${day.low}${weatherSymbols["Degrees"]}/${day.high}${weatherSymbols["Degrees"]}`

            let weatherCondition = document.createElement('span');
            weatherCondition.classList.add('forecast-data');
            weatherCondition.textContent = day.condition;

            upcomingForecast.appendChild(symbol);
            upcomingForecast.appendChild(degrees);
            upcomingForecast.appendChild(weatherCondition);

            forecasts.appendChild(upcomingForecast); 
        }
        
        upcoming.appendChild(forecasts);
    }
}
attachEvents();
