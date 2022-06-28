using System;
using System.Collections.Generic;
using System.Text;

namespace LogServiceRequests
{
    public interface GetLogsByDateBefore
    {
        string AdminId { get; }
        DateTime Date { get; }
    }
}
