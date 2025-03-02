using UnityEngine;
using UnityEngine.UIElements;

namespace Fractals.UI
{
    /// <summary> Toggles background for 3D fractals </summary>
    public class BackgroundManager : MonoBehaviour
    {
        [SerializeField] FractalDispatcher3D Dispatcher;

        [SerializeField] SwitchToggle Switch;

        [SerializeField] Material Transparency;

        void Start()
        {
            Switch.OnPointerClick(null);
            OnScale();
            Scaler.Instance.OnResolutionChanged += OnScale;
        }

        public void ShowBackground(bool show) => Dispatcher.Background = show;

        void OnScale() => Transparency.SetTextureScale("_MainTex", new(50f * Screen.width / Screen.height, 50));
    }
}