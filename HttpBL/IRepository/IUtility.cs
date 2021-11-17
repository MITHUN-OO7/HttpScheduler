using System;
using System.Collections.Generic;
using System.Text;

namespace HttpBL.IRepository
{
    public interface IUtility
    {
        TimeSpan GetIntervalatParticularTime();
        int GetSecond();

    }
}
