using System.Linq;
using System.Threading.Tasks;
using UnityEngine;

namespace Fractals.UI
{
    /// <summary> Allows to focus one panel by hiding the rest and removing the blur </summary>
    public class Focus : MonoBehaviour
    {
        MenuAnimator _animator;

        public static bool Animating { get; private set; } = false;

        PanelAnimation _parent;

        bool _focused = false;

        public static bool AnyFocused { get; private set; } = false;

        async void ToggleFocus()
        {
            if (Animating)
            {
                return;
            }

            _focused = !_focused;
            AnyFocused = _focused;

            Animating = true;

            if (_animator == null)
            {
                _animator = FindFirstObjectByType<MenuAnimator>();
            }

            if (_parent == null)
            {
                _parent = GetComponentInParent<PanelAnimation>();
            }

            _animator.ToggleEffects();

            var tasks =  PanelAnimation.Panels
                .Select(x => x.ToggleScale(x == _parent));

            await Task.WhenAll(tasks);

            Animating = false;
        }

        public void Update()
        {
            if (_focused && Input.GetKeyDown(KeyCode.Escape))
            {
                ToggleFocus();
            }
        }
    }
}