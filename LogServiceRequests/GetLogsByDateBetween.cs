using System;
using System.Collections.Generic;
using System.Text;

namespace LogServiceRequests
{
    public interface GetLogsByDateBetween
    {
        string AdminId { get; }
        DateTime DateAfter { get; }
        DateTime DateBefore { get; }
    }
}
