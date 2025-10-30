namespace Fractals.UI
{
    /// <summary> Sets the number of frames to render a single frame </summary>
    public class FramesToRenderManager : ClampledIntInputField
    {
        protected override void SubmitChanges(int framesToRender) => Dispatcher.FramesToRender = framesToRender;
    }
}
