
using Android.Content;
using CustomControlJitter;
using CustomControlJitter.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(TestCustomControl), typeof(TestCustomControlRenderer))]
namespace CustomControlJitter.Droid
{
    public class TestCustomControlRenderer : ViewRenderer<TestCustomControl, TestNativeCustomControl>
    {
        public TestCustomControlRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<TestCustomControl> e)
        {
            base.OnElementChanged(e);
            if (e.NewElement != null)
            {
                this.SetNativeControl(new TestNativeCustomControl(this.Context));
            }
        }
    }
}