using UnityEngine;

namespace Fractals
{
    public partial class FractalDispatcher3D
    {
        [SerializeField] BulbPalette _palette;

        public BulbPalette Palette
        {
            private get => _palette;
            set
            {
                _palette = value;
                AreChangesOnParameters = true;

                foreach (var (key, v) in Palette)
                {
                    ComputeShader.SetVector(key, v);
                }
            }
        }

        [SerializeField] BulbParameters Parameters;

        [SerializeField] Camera Cam;

        (Vector3, Vector3)? _camTransform = null;

        (Vector3, Vector3) CamTransform => (Cam.transform.position, Cam.transform.forward);

        [SerializeField] Light MainLight;

        const float _SCALE_SPEED = 1.05f;

        float _scale = 1.0f;

        public float Scale
        {
            get => _scale;
            set
            {
                _scale = value;
                AreChangesOnParameters = true;
                ComputeShader.SetFloat("Scale", _scale);
            }
        }

        float _time;

        public float Time
        {
            get => _time;
            set
            {
                _time = value;
                ComputeShader.SetFloat("Time", _time);
                AreChangesOnParameters = true;
            }
        }

        bool _background;

        public bool Background
        {
            set
            {
                _background = value;
                ComputeShader.SetBool("Background", _background);
                AreChangesOnParameters = true;
            }
        }

        protected override void InitParameters()
        {
            ComputeShader.SetVector("LightDir", MainLight.transform.forward);

            Palette = Palette;

            foreach (var (key, value) in Parameters)
            {
                ComputeShader.SetFloat(key, value);
            }

            Scale = 1.0f;
        }

        protected override void Update()
        {
            if (_camTransform is null || _camTransform != CamTransform)
            {
                _camTransform = CamTransform;
                ComputeShader.SetVector("CamPos", _camTransform.Value.Item1);
                ComputeShader.SetVector("Forward", _camTransform.Value.Item2);
                AreChangesOnParameters = true;
            }

            var scroll = Input.mouseScrollDelta.y;

            if (scroll != 0)
            {
                Scale *= Mathf.Pow(_SCALE_SPEED, scroll);
                Scale = Mathf.Max(Scale, 1.0f);
            }

            base.Update();
        }
    }
}