using GeographyLibrary.AzimuthModel;

namespace GeographyLibrary;

public class Calculation
{

    #region Создание метода заглушки

    // public static void GetDistance(Coordinate coordinate1, Coordinate coordinate2)
    // {
    //     throw new NotImplementedException();
    // }
    //
    // public static void GetAzimuth(Coordinate coordinate1, Coordinate coordinate2)
    // {
    //     throw new NotImplementedException();
    // }

    #endregion

    #region "Зелёная" фаза 1

    // public static double GetDistance(Coordinate coordinate1, Coordinate coordinate2)
    // {
    //     if (coordinate1.Latitude is < -90 or > 90)
    //     {
    //         throw new ArgumentException("Latitude should be between -90 and 90.", nameof(coordinate1.Latitude));
    //     }
    //
    //     if (coordinate1.Longitude is < -180 or > 180)
    //     {
    //         throw new ArgumentException("Longitude should be between -180 and 180.", nameof(coordinate1.Longitude));
    //     }
    //
    //     if (coordinate2.Latitude is < -90 or > 90)
    //     {
    //         throw new ArgumentException("Latitude should be between -90 and 90.", nameof(coordinate2.Latitude));
    //     }
    //
    //     if (coordinate2.Longitude is < -180 or > 180)
    //     {
    //         throw new ArgumentException("Longitude should be between -180 and 180.", nameof(coordinate2.Longitude));
    //     }
    //
    //     throw new NotImplementedException();
    // }
    //
    // public static double GetAzimuth(Coordinate coordinate1, Coordinate coordinate2)
    // {
    //     if (coordinate1.Latitude is < -90 or > 90)
    //     {
    //         throw new ArgumentException("Latitude should be between -90 and 90.", nameof(coordinate1.Latitude));
    //     }
    //
    //     if (coordinate1.Longitude is < -180 or > 180)
    //     {
    //         throw new ArgumentException("Longitude should be between -180 and 180.", nameof(coordinate1.Longitude));
    //     }
    //
    //     if (coordinate2.Latitude is < -90 or > 90)
    //     {
    //         throw new ArgumentException("Latitude should be between -90 and 90.", nameof(coordinate2.Latitude));
    //     }
    //
    //     if (coordinate2.Longitude is < -180 or > 180)
    //     {
    //         throw new ArgumentException("Longitude should be between -180 and 180.", nameof(coordinate2.Longitude));
    //     }
    //
    //     throw new NotImplementedException();
    // }

    #endregion

    #region Зелёная фаза 2

    // public static double GetDistance(Coordinate coordinate1, Coordinate coordinate2)
    // {
    //     if (coordinate1.Latitude is < -90 or > 90)
    //     {
    //         throw new ArgumentException("Latitude should be between -90 and 90.", nameof(coordinate1.Latitude));
    //     }
    //
    //     if (coordinate1.Longitude is < -180 or > 180)
    //     {
    //         throw new ArgumentException("Longitude should be between -180 and 180.", nameof(coordinate1.Longitude));
    //     }
    //
    //     if (coordinate2.Latitude is < -90 or > 90)
    //     {
    //         throw new ArgumentException("Latitude should be between -90 and 90.", nameof(coordinate2.Latitude));
    //     }
    //
    //     if (coordinate2.Longitude is < -180 or > 180)
    //     {
    //         throw new ArgumentException("Longitude should be between -180 and 180.", nameof(coordinate2.Longitude));
    //     }
    //
    //     throw new NotImplementedException();
    // }
    //
    // public static double GetAzimuth(Coordinate coordinate1, Coordinate coordinate2)
    // {
    //     if (coordinate1.Latitude is < -90 or > 90)
    //     {
    //         throw new ArgumentException("Latitude should be between -90 and 90.", nameof(coordinate1.Latitude));
    //     }
    //
    //     if (coordinate1.Longitude is < -180 or > 180)
    //     {
    //         throw new ArgumentException("Longitude should be between -180 and 180.", nameof(coordinate1.Longitude));
    //     }
    //
    //     if (coordinate2.Latitude is < -90 or > 90)
    //     {
    //         throw new ArgumentException("Latitude should be between -90 and 90.", nameof(coordinate2.Latitude));
    //     }
    //
    //     if (coordinate2.Longitude is < -180 or > 180)
    //     {
    //         throw new ArgumentException("Longitude should be between -180 and 180.", nameof(coordinate2.Longitude));
    //     }
    //
    //     var delta = (coordinate2.Longitude - coordinate1.Longitude);
    //     var l1 = (coordinate1.Latitude);
    //     var l2 = (coordinate2.Latitude);
    //     var angle = Math.Atan2(Math.Sin(delta * Math.PI / 180) * Math.Cos(l2 * Math.PI / 180), Math.Cos(l1 * Math.PI / 180) * Math.Sin(l2 * Math.PI / 180) - Math.Sin(l1 * Math.PI / 180) * Math.Cos(l2 * Math.PI / 180) * Math.Cos(delta * Math.PI / 180)) * 180 / Math.PI;
    //
    //     return angle < 0 ? Math.Round(360 + angle, 4) : Math.Round(angle, 4);
    // }

    #endregion

    #region Рефакторинг 2

    // public static double GetAzimuth(Coordinate coordinate1, Coordinate coordinate2)
    // {
    //     if (coordinate1.Latitude is < -90 or > 90)
    //     {
    //         throw new ArgumentException("Latitude should be between -90 and 90.", nameof(coordinate1.Latitude));
    //     }
    //
    //     if (coordinate1.Longitude is < -180 or > 180)
    //     {
    //         throw new ArgumentException("Longitude should be between -180 and 180.", nameof(coordinate1.Longitude));
    //     }
    //
    //     if (coordinate2.Latitude is < -90 or > 90)
    //     {
    //         throw new ArgumentException("Latitude should be between -90 and 90.", nameof(coordinate2.Latitude));
    //     }
    //
    //     if (coordinate2.Longitude is < -180 or > 180)
    //     {
    //         throw new ArgumentException("Longitude should be between -180 and 180.", nameof(coordinate2.Longitude));
    //     }
    //
    //     var delta = ConvertToRadian(coordinate2.Longitude - coordinate1.Longitude);
    //     var l1 = ConvertToRadian(coordinate1.Latitude);
    //     var l2 = ConvertToRadian(coordinate2.Latitude);
    //     var angle = ConvertToAngle(Math.Atan2(Math.Sin(delta) * Math.Cos(l2),
    //         Math.Cos(l1) * Math.Sin(l2) - Math.Sin(l1) * Math.Cos(l2) * Math.Cos(delta)));
    //
    //     return angle < 0 ? Math.Round(360 + angle, 4) : Math.Round(angle, 4);
    // }
    //
    // private static double ConvertToRadian(double angle)
    // {
    //     return angle * Math.PI / 180;
    // }
    //
    // private static double ConvertToAngle(double radian)
    // {
    //     return radian * 180 / Math.PI;
    // }

    #endregion

    #region Зелёная фаза 3

    public static Azimuth GetAzimuth(Coordinate coordinate1, Coordinate coordinate2)
    {
        if (coordinate1.Latitude is < -90 or > 90)
        {
            throw new ArgumentException("Latitude should be between -90 and 90.", nameof(coordinate1.Latitude));
        }

        if (coordinate1.Longitude is < -180 or > 180)
        {
            throw new ArgumentException("Longitude should be between -180 and 180.", nameof(coordinate1.Longitude));
        }

        if (coordinate2.Latitude is < -90 or > 90)
        {
            throw new ArgumentException("Latitude should be between -90 and 90.", nameof(coordinate2.Latitude));
        }

        if (coordinate2.Longitude is < -180 or > 180)
        {
            throw new ArgumentException("Longitude should be between -180 and 180.", nameof(coordinate2.Longitude));
        }

        if (coordinate1.Latitude == coordinate2.Latitude && coordinate1.Longitude == coordinate2.Longitude)
        {
            return new Azimuth {AzimuthResult = AzimuthResult.None};
        }

        if (Math.Abs(coordinate1.Latitude) == 90 && coordinate1.Latitude + coordinate2.Latitude == 0)
        {
            return new Azimuth {AzimuthResult = AzimuthResult.Any};
        }

        if (coordinate1.Latitude + coordinate2.Latitude == 0 &&
            Math.Abs(Math.Abs(coordinate1.Longitude) + Math.Abs(coordinate2.Longitude) - 180) < double.Epsilon)
        {
            return new Azimuth {AzimuthResult = AzimuthResult.Any};
        }

        var delta = ConvertToRadian(coordinate2.Longitude - coordinate1.Longitude);
        var l1 = ConvertToRadian(coordinate1.Latitude);
        var l2 = ConvertToRadian(coordinate2.Latitude);
        var angle = ConvertToAngle(Math.Atan2(Math.Sin(delta) * Math.Cos(l2),
            Math.Cos(l1) * Math.Sin(l2) - Math.Sin(l1) * Math.Cos(l2) * Math.Cos(delta)));


        return new Azimuth
        {
            AzimuthResult = AzimuthResult.Value,
            Value = angle < 0
                ? Math.Round(360 + angle, 4)
                : Math.Round(angle, 4)
        };
    }

    private static double ConvertToRadian(double angle)
    {
        return angle * Math.PI / 180;
    }

    private static double ConvertToAngle(double radian)
    {
        return radian * 180 / Math.PI;
    }

    #endregion

    #region Зелёная фаза 4

    public const double R = 6371.008;
    public static double GetDistance(Coordinate coordinate1, Coordinate coordinate2)
    {
        if (coordinate1.Latitude is < -90 or > 90)
        {
            throw new ArgumentException("Latitude should be between -90 and 90.", nameof(coordinate1.Latitude));
        }

        if (coordinate1.Longitude is < -180 or > 180)
        {
            throw new ArgumentException("Longitude should be between -180 and 180.", nameof(coordinate1.Longitude));
        }

        if (coordinate2.Latitude is < -90 or > 90)
        {
            throw new ArgumentException("Latitude should be between -90 and 90.", nameof(coordinate2.Latitude));
        }

        if (coordinate2.Longitude is < -180 or > 180)
        {
            throw new ArgumentException("Longitude should be between -180 and 180.", nameof(coordinate2.Longitude));
        }

        var a = Math.Pow(Math.Sin(ConvertToRadian((coordinate2.Latitude - coordinate1.Latitude) / 2)), 2) +
                Math.Cos(ConvertToRadian(coordinate1.Latitude)) * Math.Cos(ConvertToRadian(coordinate2.Latitude)) *
                Math.Pow(Math.Sin(ConvertToRadian((coordinate2.Longitude - coordinate1.Longitude) / 2)), 2);

        var c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));

        return Math.Round(R * c, 3);
    }

    #endregion
}