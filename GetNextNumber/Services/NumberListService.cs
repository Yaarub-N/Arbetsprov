using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetNextNumber.Services;


    public class NumberListService : INumberListService
    {
        public IEnumerable<string> GenerateNumberList(int startNumber, int count = 100)
        {
            var result = new List<string>();

            for (int i = 0; i <= count; i++)
            {
                int current = startNumber + i;

                if (current % 15 == 0)
                    result.Add($"{current} TreMultipelFemMultipel");
                else if (current % 3 == 0)
                    result.Add($"{current} TreMultipel");
                else if (current % 5 == 0)
                    result.Add($"{current} FemMultipel");
                else
                    result.Add(current.ToString());
            }

            return result;
        }
    }
