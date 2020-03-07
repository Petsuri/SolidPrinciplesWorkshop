using System;
using System.Collections.Generic;
using System.Linq;

namespace ISP
{
    public sealed class ManagementService
    {
        private readonly IReservation _reservation;

        internal ManagementService(IReservation reservation)
        {
            _reservation = reservation;
        }

        public void CancelReservation(ReservationCode code)
        {
            if (!_reservation.IsValidReservation(code))
            {
                throw new ArgumentException( $"Reservation is not found with '{code}'");
            }

            _reservation.CancelReservation(code);
        }

        public IReadOnlyDictionary<DateTime, decimal> GenerateReportFor(DateTime start, DateTime end)
        {
            if (end < start)
            {
                throw new ArgumentException("End time can't be before start time");
            }

            var dates = new List<DateTime>();
            for (var dt = start; dt <= end; dt = dt.AddDays(1))
            {
                dates.Add(dt);
            }

            return dates.ToDictionary(date => date, date => _reservation.CalculateRevenue(date));
        }

    }
}
