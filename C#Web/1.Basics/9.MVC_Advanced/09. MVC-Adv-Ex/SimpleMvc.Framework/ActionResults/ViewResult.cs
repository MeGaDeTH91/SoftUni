namespace SimpleMvc.Framework.ActionResults
{
    using SimpleMvc.Framework.Interfaces;

    public class ViewResult : IViewable
    {
        public ViewResult(IRenderable view)
        {
            this.View = view;
        }
        public IRenderable View { get; set; }

        public string Invoke()
        {
            return this.View.Render();
        }
    }
}
