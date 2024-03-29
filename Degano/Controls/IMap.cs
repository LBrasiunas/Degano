﻿namespace Degano.Controls
{
    public interface IMap : IView
    {
        bool IsShowingUser { get; }
        bool IsScrollEnabled { get; }
        bool IsZoomEnabled { get; }
        bool IsTrafficEnabled { get; }
        float MinZoomLevel { get; }
        float MaxZoomLevel { get; }
        (Location, Location) MapBounds { get; }

        // Adds Marker to map,
        // currently takes GasStation as argument to be tagged to marker
        void AddMarker(object? args);
        void AnimateCamera(object? args);
        void MoveCamera(object? args);
        void ZoomCamera(object? args);
        void SelectGasStation(object? args);
        void RemoveGasStation(object? args);

        void Clear();
    }
}
