using System;
using System.Collections.Generic;
using System.Text;

namespace LogServiceRequests
{
    public interface GetLogsByDateAfter
    {
        string AdminId { get; }
        DateTime Date { get; }
    }
}
