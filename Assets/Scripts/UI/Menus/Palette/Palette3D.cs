using UnityEngine;

namespace Fractals.UI
{
    /// <summary> Allows the user to select the palette for 3D fractals </summary>
    public class Palette3D : PaletteManager
    {
        [SerializeField] FractalDispatcher3D Dispatcher;

        [SerializeField] BulbPalette[] Palettes;

        protected override string Name => "Palette3D";

        protected override void EspecificPaletteChange(int index)
        {
            Dispatcher.Palette = Palettes[index];
        }
    }
}