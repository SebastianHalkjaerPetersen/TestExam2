using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestExam2
{
    public class Measurement
    {

		private int _id;

		public int Id
		{
			get { return _id; }
			set { _id = value; }
		}

		private int _pressure;

		public int Pressure
		{
			get { return _pressure; }
			set { _pressure = value; }
		}

		private int _humidity;

		public int Humidity
		{
			get { return _humidity; }
			set { _humidity = value; }
		}


		private int _temperature;

		public int Temperature
		{
			get { return _temperature; }
			set { _temperature = value; }
		}

		private DateTime _timestamp;

		public DateTime Timestamp
		{
			get { return _timestamp; }
			set { _timestamp = value; }
		}

        public Measurement()
        {
            
        }

        public Measurement(int pressure, int humidity, int temperature)
        {
            _pressure = pressure;
            _humidity = humidity;
            _temperature = temperature;
        }

	}
}
