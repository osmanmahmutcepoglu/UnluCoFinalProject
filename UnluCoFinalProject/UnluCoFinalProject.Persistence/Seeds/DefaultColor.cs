using System.Collections.Generic;
using UnluCoFinalProject.Domain.Entities;
using UnluCoFinalProject.Domain.Enum;

namespace UnluCoFinalProject.Persistence.Seeds
{
    public static class DefaultColor
    {
        public static List<Color> ColorList()
        {
            return new List<Color>()
            {
                new Color
                {
                    Id = 1,
                    ColorName = Colors.MOR.ToString()
                },
                new Color
                {
                    Id = 2,
                    ColorName = Colors.MAVI.ToString()
                },
                new Color
                {
                    Id = 3,
                    ColorName = Colors.KIRMIZI.ToString()
                },
                new Color
                {
                    Id = 4,
                    ColorName = Colors.LACIVERT.ToString()
                },
                new Color
                {
                    Id = 5,
                    ColorName = Colors.PEMBE.ToString()
                },
                new Color
                {
                    Id = 6,
                    ColorName = Colors.SIYAH.ToString()
                },
                new Color
                {
                    Id = 7,
                    ColorName = Colors.SARI.ToString()
                },
            };
        }
    }
}
