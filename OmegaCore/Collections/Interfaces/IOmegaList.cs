﻿namespace OmegaCore.Collections.Interfaces
{
    public interface IOmegaList<T> : IOmegaCollection<T>
    {
        T this[int index] { get; }

    }
}