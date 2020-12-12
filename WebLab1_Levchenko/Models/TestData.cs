using System;
using System.Collections.Generic;
using System.Text;
using WebLab1_Levchenko.DAL.Data;
using WebLab1_Levchenko.DAL.Entities;

namespace WebLab1_Levchenko.Models
{
    public static class TestData
    {
        public static List<Cats> GetCatsList()
        {
            return new List<Cats>
            {
                 new Cats{ CatsID=1, CatsGroupID=1},
                 new Cats{ CatsID=2, CatsGroupID=1},
                 new Cats{ CatsID=3, CatsGroupID=2},
                 new Cats{ CatsID=4, CatsGroupID=2},
                 new Cats{ CatsID=5, CatsGroupID=6},
                 new Cats{ CatsID=6, CatsGroupID=5}
            };
        }
        public static IEnumerable<object[]> Params()
        {
            // 1-я страница, кол. объектов 3, id первого объекта 1
            yield return new object[] { 1, 3, 1 };
            // 2-я страница, кол. объектов 3, id первого объекта 4
            yield return new object[] { 2, 3, 4 };
        }
        public static void FillContext(ApplicationDbContext context)
        {
            context.CatsGroups.Add(new CatsGroup(){ GroupName = "fake group" });
            context.AddRange(new List<Cats>()
                {
                   new Cats{ CatsID=1, CatsGroupID=1},
                 new Cats{ CatsID=2, CatsGroupID=1},
                 new Cats{ CatsID=3, CatsGroupID=2},
                 new Cats{ CatsID=4, CatsGroupID=2},
                 new Cats{ CatsID=5, CatsGroupID=6},
                 new Cats{ CatsID=6, CatsGroupID=5}
                });
            context.SaveChanges();
        }

    }
}

