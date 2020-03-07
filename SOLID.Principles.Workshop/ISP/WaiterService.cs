using System.Collections.Generic;

namespace ISP
{
    public sealed class WaiterService
    {
        private readonly IReservation _reservation;

        internal WaiterService(IReservation reservation)
        {
            _reservation = reservation;
        }

        public string FindTableLocation(ReservationCode code)
        {
            return _reservation.FindTable(code);
        }

        public void TakeAnOrder(ReservationCode code, List<string> dishes, List<string> beverages)
        {
            foreach (var dish in dishes)
            {
                _reservation.AddDishForReservation(code, dish);
            }

            foreach (var beverage in beverages)
            {
                _reservation.AddBeverageForReservation(code, beverage);
            }
        }

    }
}
