using System;
using System.Collections.Generic;
using System.Text;
using LogServiceModels;

namespace LogServiceRequests
{
    public interface GetLogsByLevelRequest
    {
        string AdminId { get; }
        ELevel Level { get; }
    }
}
