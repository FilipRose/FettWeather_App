# Weather Forecast Application

This C# code represents a simple weather forecast application. The application uses the OpenWeatherMap API to retrieve weather information for a specified city and display it to the user. It consists of a Windows Forms application with a single form named Form1.

## Form1 Class

- The `Form1` class inherits from `Form` and serves as the main form of the application.
- It contains an API key (APIKey) that is used to authenticate requests to the OpenWeatherMap API.
- There are two event handlers defined: `searchBtn_Click` and two helper methods: `getWeather` and `geForecast`.

## searchBtn_Click Event Handler

- This event handler is triggered when the user clicks the "Search" button on the form.
- It calls two methods: `getWeather` and `geForecast`.

## getWeather Method

- This method is responsible for fetching current weather data for a specified city using the OpenWeatherMap API.
- It uses a `WebClient` to make a GET request to the API endpoint.
- The response data, received in JSON format, is deserialized into a custom class `WeatherInfo.root` using `JsonConvert.DeserializeObject`.
- The relevant weather information is extracted from the response and displayed on the form's controls, such as temperature, humidity, wind speed, and sunset/sunrise times.

## convertDateTime Method

- This method converts a Unix timestamp (milliseconds since 1970) to a `DateTime` object in the local time zone.
- It is used to convert the sunrise and sunset timestamps received from the API into human-readable time.

## getForecast Method

- This method fetches weather forecast data for a specific location (latitude and longitude) using the OpenWeatherMap API.
- Similar to `getWeather`, it makes a GET request using `WebClient`, deserializes the JSON response into a custom class `ForecastInfo.Forecast`, and extracts the relevant forecast data.
- It then creates instances of a custom user control `ForecastUC` to display the forecast information for the next 8 days.
- Each `ForecastUC` contains details like weather icon, weather description, and the day of the week.

## Additional Notes

- The code follows good practices by utilizing the `using` statement for the `WebClient`, which ensures proper disposal of resources after usage.
- The application fetches weather information in metric units (temperature in degrees Celsius and wind speed in meters per second) by default as the API returns data in this format.

