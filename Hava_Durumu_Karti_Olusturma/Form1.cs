using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Hava_Durumu_Karti_Olusturma
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			label2.Text = DateTime.Now.ToShortDateString();

			string api = "0c45010d1c81302c946d0622a3898024";
			string connection = "https://api.openweathermap.org/data/2.5/weather?q=izmir&mode=xml&lang=tr&units=metric&appid=" + api;
			XDocument hava = XDocument.Load(connection);
			var sicaklik = hava.Descendants("temperature").ElementAt(0).Attribute("value").Value;
			var ruzgar = hava.Descendants("speed").ElementAt(0).Attribute("value").Value;
			var nem = hava.Descendants("humidity").ElementAt(0).Attribute("value").Value;
			var durum = hava.Descendants("weather").ElementAt(0).Attribute("value").Value;
			label4.Text = sicaklik.ToString();
			LblSicaklik.Text = sicaklik.ToString();
			LblRuzgar.Text = ruzgar + " m/s";
			LblNem.Text = nem + " %";
			LblWeather.Text = durum.ToUpper();
			//durum = "bulutlu";

			if (durum == "açık")
			{
				pictureBox1.ImageLocation = @"C:\Users\LENOVO\OneDrive\Masaüstü\RESİMLER\Status-weather-clear-icon.png";
			}
			if (durum == "bulutlu")
			{
				pictureBox1.ImageLocation = @"C:\Users\LENOVO\OneDrive\Masaüstü\RESİMLER\cloudy-icon.png";
			}
		}
	}
}
