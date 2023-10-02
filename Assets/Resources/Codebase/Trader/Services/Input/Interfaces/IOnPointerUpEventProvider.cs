using System;

namespace Services
{
    public interface IOnPointerUpEventProvider
    {
        event Action OnPointerUp;
    }
}