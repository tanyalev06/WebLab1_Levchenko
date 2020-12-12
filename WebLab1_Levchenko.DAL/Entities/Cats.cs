using System;
using System.Collections.Generic;
using System.Text;

namespace WebLab1_Levchenko.DAL.Entities
{
    public class Cats
    {
        public int CatsID { get; set; }
        public string CatsName { get; set; }
        public string CatsColor { get; set; }
        public string Image { get; set; }
        public int CatsWeight { get; set; }

        public int CatsGroupID { get; set; }
        public CatsGroup Group { get; set; }

    }

    public class CatsGroup
    {
        public int CatsGroupID { get; set; }
        public string GroupName { get; set; }
        public List<Cats> Catss { get; set; }
    }
}
