namespace Airport.GameLogic
{
    //Хранилище различных игровых констант
    static class GameConstants
    {
        //Изначально 1 минута игрового времени =
        //1 минута реального времени
        public const int StartSpeed = 1000 * 60;

        //Базовая цена топлива (без учета времени)
        public const decimal BaseFuelPrice = 70;

        //Временной коэффициент для цены топлива
        public const int FuelPriceTimeCoeff = 2;

        //Получаемая с одного человека прибыль
        public const decimal ProfitPerPerson = 1100; 
    }
}