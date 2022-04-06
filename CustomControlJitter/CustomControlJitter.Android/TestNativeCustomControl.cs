
using Android.Content;
using Android.Graphics;
using Android.Views;
using Android.Widget;
using System;

namespace CustomControlJitter.Droid
{
    public class TestNativeCustomControl : FrameLayout
    {
        internal static float Density;
        private ZoomLayout zoomLayout;
        public TestNativeCustomControl(Context context) : base(context)
        {
            Density = context.Resources.DisplayMetrics.Density;
            ShapeView shapeView = new ShapeView(this.Context);
            zoomLayout = new ZoomLayout(this.Context);
            zoomLayout.ShapeView = shapeView;
            AddView(zoomLayout);
            AddView(shapeView);
        }
    }

    public class ShapeView : FrameLayout
    {
        private Paint paint;
        internal float Scale { get; set; }

        public ShapeView(Context context) : base(context)
        {
            this.Scale = (float)Math.Pow(2, 17) / 2;
            this.ScaleX = 0.9f;
            this.ScaleY = 0.9f;
            this.PivotX = 0;
            this.PivotY = 0;
            this.SetWillNotDraw(false);
            this.paint = new Paint();
        }

        public override void Draw(Canvas canvas)
        {
            base.Draw(canvas);
            canvas.Translate(-86522968, -55230612);
            Path path = new Path();
            path.MoveTo(1320.245f * this.Scale, 842.7646f * this.Scale);
            path.LineTo(1320.245f * this.Scale, 842.7676f * this.Scale);
            path.LineTo(1320.242f * this.Scale, 842.7676f * this.Scale);
            path.LineTo(1320.242f * this.Scale, 842.7627f * this.Scale);
            paint.Color = Color.Red;
            paint.SetStyle(Paint.Style.Fill);
            canvas.DrawPath(path, paint);
        }
    }

    public class ZoomLayout : FrameLayout
    {
        internal ShapeView ShapeView { get; set; }
        private PointExt last = new PointExt();
        private PointExt start = new PointExt();
        public ZoomLayout(Context context) : base(context)
        {
        }

        public override bool OnTouchEvent(MotionEvent e)
        {
            PointExt curr = new PointExt(e.GetX(), e.GetY());
            switch (e.Action)
            {
                case MotionEventActions.Down:
                case MotionEventActions.Pointer2Down:
                case MotionEventActions.Pointer1Down:
                    last = curr;
                    start = last;
                    break;
                case MotionEventActions.Move:
                    if (e.PointerCount == 1)
                    {
                        this.ShapeView.TranslationX -= (last.X - curr.X) * ShapeView.ScaleX;
                        this.ShapeView.TranslationY -= (last.Y - curr.Y) * ShapeView.ScaleY;
                    }

                    last = curr;
                    break;
            }

            return true;
        }
    }

    internal class PointExt
    {
        #region ctor

        public PointExt()
        {
        }

        public PointExt(float x, float y)
        {
            X = x;
            Y = y;
        }

        #endregion

        #region properties

        public float X { get; set; }

        public float Y { get; set; }

        #endregion
    }
}