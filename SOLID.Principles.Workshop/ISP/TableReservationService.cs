using System;
using System.Collections.Generic;
using System.Linq;

namespace ISP
{
    public sealed class TableReservationService
    {
        private readonly IReservation _reservation;

        internal TableReservationService(IReservation reservation)
        {
            _reservation = reservation;
        }

        public IReadOnlyDictionary<DateTime, IReadOnlyList<int>> FindAvailableDates()
        {
            var dates = _reservation.FindAvailableDates();
            return dates.Select(x =>
            {
                var tables = _reservation.GetListOfAvailableTables(x);
                return new KeyValuePair<DateTime, IReadOnlyList<int>>(x, tables);
            }).ToDictionary(pair => pair.Key, pair => pair.Value);
        }

        public string ReserveTable(DateTime date, int tableId)
        {
            if (!_reservation.IsTableAvailable(date, tableId))
            {
                return "Selected table is not available for given date.";
            }

            var code = _reservation.MakeReservation(date);
            _reservation.SelectTableForReservation(code, tableId);

            return "Your reservation code is: " + code.Value;
        }

    }
}
