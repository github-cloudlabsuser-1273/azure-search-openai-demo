# Fetch weather data from OpenWeatherMap API
# Usage: python weather_script.py <city_name>
import requests
import sys

API_KEY = "YOUR_API_KEY_HERE"  # Replace with your OpenWeatherMap API key
def get_weather(city):
    url = f"https://api.openweathermap.org/data/2.5/weather?q={city}&appid={API_KEY}&units=metric"
    response = requests.get(url)
    if response.status_code == 200:
        data = response.json()
        temp = data['main']['temp']
        humidity = data['main']['humidity']
        weather = data['weather'][0]['description']
        print(f"Weather in {city}:")
        print(f"Temperature: {temp}°C")
        print(f"Humidity: {humidity}%")
        print(f"Condition: {weather}")
    else:
        print(f"Failed to get weather data for {city}. Error: {response.status_code}")

if __name__ == "__main__":
    if len(sys.argv) < 2:
        print("Usage: python weather_script.py <city_name>")
    else:
        get_weather(sys.argv[1])
