using System;
using System.Collections.Generic;

namespace Airport.GameModel
{
    [Serializable]
    //Характеристики самолёта
    struct PlaneCharacteristics
    {

        //Скорость (в км./ч.)
        public double Speed;

        //Максимальная дальность перелетов (в км.)
        public double Range;

        //Максимальное число пассажиров
        public uint MaxSeatings;

        //Максимальная грузовместимость (в тоннах)
        public double Payload;
    }

    //Хранилище с характеристиками различных моделей самолётов
    static class PlaneCharacteristicsStorage
    {
        public static readonly Dictionary<Plane.Models, PlaneCharacteristics> Characteristics = new Dictionary<Plane.Models, PlaneCharacteristics>
        {
            { Plane.Models.TY_134, new PlaneCharacteristics { Speed = 871, Range = 13450, MaxSeatings = 406, Payload = 49.4 } },
            { Plane.Models.SuperJet123, new PlaneCharacteristics { Speed = 988, Range = 14100, MaxSeatings = 581, Payload = 78 } },
            { Plane.Models.KukuruznikMX150, new PlaneCharacteristics { Speed = 940, Range = 6652, MaxSeatings = 410, Payload = 91.962 } },
        };
    }
}
