using System;
namespace Mosfin.Clients.Utils.Utils
{
    public sealed class MosfinPreserveAttribute : System.Attribute
    {
		public bool AllMembers;
		public bool Conditional;
    }
}
