using System;
using System.Collections.Generic;

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

            var revenue = new Dictionary<DateTime, decimal>();
            foreach (var date in dates)
            {
                revenue.Add(date, _reservation.CalculateRevenue(date));
            }

            return revenue;
        }

    }
}
