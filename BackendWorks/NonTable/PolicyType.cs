using System.ComponentModel;

namespace BackendWorks.NonTable
{
    public enum PolicyType
    {
        None = 0,
        [Description("Traffic")] Traffic = 01,
        [Description("Dask")] Dask = 02
    }
}
