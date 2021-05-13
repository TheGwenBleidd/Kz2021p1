﻿using System;
using System.Collections.Generic;
using System.Linq;
using WebApplication1.EfStuff.Model.Airport;
using WebApplication1.EfStuff.Repositoryies.Airport.Intrefaces;

namespace WebApplication1.EfStuff.Repositoryies.Airport
{
	public class PassengersRepository : BaseRepository<Passenger>, IPassengersRepository
    {
        public PassengersRepository(KzDbContext kzDbContext) : base(kzDbContext)
        {
        }

        public List<Passenger> GetAllPassengersAvailableForAdmission()
        {
			return _dbSet.
				Where(passenger => passenger.Flight.FlightType == FlightType.IncomingFlight && IsValidAddmissionTime(passenger.Flight.Date))
				.ToList();
        }

		public List<Passenger> GetAllPassengersAvailableForDeparture()
        {
			return _dbSet

        }

		private bool IsValidDepartureTime(DateTime flightDate)
		{
			DateTime now = DateTime.Now;
			if (flightDate.Day == now.Day && flightDate.AddMinutes(-30) <= now && now >= flightDate)
				return true;
			return false;
		}

		private bool IsValidAddmissionTime(DateTime flightDate)
		{
			DateTime now = DateTime.Now;
			DateTime add30 = flightDate.AddMinutes(30);
			if (flightDate.Day == now.Day && now >= flightDate && now <= add30)
				return true;
			return false;
		}
	}
}
