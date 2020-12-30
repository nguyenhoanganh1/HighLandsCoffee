using System;

namespace WindowsFormsApp2.Views
{
    internal class QL_BanHangEntities : IDisposable
    {
        internal readonly object CategoryProducts;

        public object Products { get; internal set; }
        public object Suppliers { get; internal set; }
    }
}