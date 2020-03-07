using System;
using System.Collections.Generic;

namespace ISP
{
    public interface IReservation
    {
        List<DateTime> FindAvailableDates();
        List<int> GetListOfAvailableTables(DateTime forDate);
        bool IsTableAvailable(DateTime value, int tableId);

        void AddDishForReservation(ReservationCode code, string dishName);
        void AddBeverageForReservation(ReservationCode code, string beverageName);

        void SelectTableForReservation(ReservationCode code, int tableId);
        void CancelReservation(ReservationCode code);
        ReservationCode MakeReservation(DateTime value);
        string FindTable(ReservationCode code);

        bool IsValidReservation(ReservationCode code);

        decimal CalculateRevenue(DateTime forDay);

    }
}
