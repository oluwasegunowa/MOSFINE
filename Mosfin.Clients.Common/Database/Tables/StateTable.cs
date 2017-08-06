using System;
namespace Mosfin.Clients.Common.Database.Tables
{
    public class StateTable: DbTableBase
    {
        public int StateId { get; set; }
        public String Name { get; set; }
       
    }
}
