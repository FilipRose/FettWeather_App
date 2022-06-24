using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.Net;

namespace FettWeather_App
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        string APIKey = "your APIKey from openweathermap.com";
        
      
        private void searchBtn_Click(object sender, EventArgs e)
        {
            getWeather();
            geForecast();
        }
        double lon;
        double lat;
       
        void getWeather()
        {
            using(WebClient webClient = new WebClient())
            {
                string url = string.Format("https://api.openweathermap.org/data/2.5/weather?q=" + cityTxtBox.Text + "&appid=" + APIKey );
                var json = webClient.DownloadString(url);
                WeatherInfo.root Info = JsonConvert.DeserializeObject<WeatherInfo.root>(json);

                picIcon.ImageLocation = "https://openweathermap.org/img/w/" + Info.weather[0].icon + ".png";
                labCondition.Text = Info.weather[0].main;
                labDetails.Text = Info.weather[0].description;
                labSunset.Text = convertDateTime(Info.sys.sunset).ToShortTimeString();
                labSunrise.Text = convertDateTime(Info.sys.sunrise).ToShortTimeString();
                labTemp.Text = Convert.ToInt32(Info.main.temp - 273).ToString();
                labHumidity.Text = Info.main.humidity.ToString();
                labMinTemp.Text = Convert.ToInt32(Info.main.temp_max - 273).ToString();
                labFeelsLike.Text = Convert.ToInt32(Info.main.feels_like - 273).ToString();
                labWindSpeed.Text = Info.wind.speed.ToString();
                labPressure.Text = Info.main.pressure.ToString();   

                lon = Info.coord.lon;
                lat = Info.coord.lat;

            }
        }

        DateTime convertDateTime(long millisec)
        {
            DateTime day = new DateTime(1970, 1, 1, 0, 0, 0, System.DateTimeKind.Utc).ToLocalTime();
            day = day.AddSeconds(millisec).ToLocalTime();
            return day;
        }
        void geForecast()
        {
            using (WebClient webClient = new WebClient())
            {
                string url = string.Format("https://api.openweathermap.org/data/2.5/onecall?lat=" + lat +"&lon=" + lon + "&exclude=current,minutely,hourly,alerts&appid=" + APIKey );
                var json = webClient.DownloadString(url);
                ForecastInfo.Forecast Forecast = JsonConvert.DeserializeObject<ForecastInfo.Forecast>(json);

                ForecastUC Fuc;
                for(int i=0; i < 8; i++)
                {
                    Fuc = new ForecastUC();
                    Fuc.picWeatherIcon.ImageLocation = "https://openweathermap.org/img/w/" + Forecast.daily[i].weather[0].icon + ".png";
                    Fuc.labMainWeather.Text = Forecast.daily[i].weather[0].main;
                    Fuc.labWeatherDescription.Text = Forecast.daily[i].weather[0].description;
                    Fuc.labDT.Text = convertDateTime(Forecast.daily[i].dt).DayOfWeek.ToString();

                    flp.Controls.Add(Fuc);
                }
            }
        }
      
    }
}
