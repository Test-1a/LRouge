using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LRouge
{
    static class Extensions
    {
        public static IDrawable CreatureAtExten(this IEnumerable<Creature> creatures, Cell cell)
        {
            //var res = creatures
            //    .Where(c => c.Cell.Items.Count > 3)
            //    .Select(i => new
            //    {
            //        nrOfItems = i.Cell.Items.Count,
            //        i.Cell.Symbol
            //    });

            return creatures.FirstOrDefault(c => c.Cell == cell);
        }

        public static int GetMapSizeFor(this IConfiguration configuration, string name)
        {
            var section = configuration.GetSection($"LRouge:MapSettings");
            return int.TryParse(section[name], out int result) ? result : 0;
        }
    }
}
