using UnityEngine;

namespace Fractals.UI
{
    /// <summary> Allows the user to select the palette for 2D fractals </summary>
    public class Palette2D : PaletteManager
    {
        [SerializeField] FractalDispatcher2D Dispatcher;

        protected override string Name => "Palette2D";

        protected override void EspecificPaletteChange(int index)
        {
            Dispatcher.PaletteIndex = index;
        }
    }
}