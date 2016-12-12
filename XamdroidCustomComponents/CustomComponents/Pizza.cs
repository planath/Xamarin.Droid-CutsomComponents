using System;

using Android.Content;
using Android.Content.Res;
using Android.Graphics;
using Android.Runtime;
using Android.Util;
using Android.Views;

namespace XamdroidCustomComponents.CustomComponents
{
    public class Pizza : View
    {
        private Paint _paint;
        private Color _color;
        private int _pieces;
        private int _strokeWidth;

        #region Constructors
        protected Pizza(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer)
        {
            Init();
        }

        public Pizza(Context context) : base(context)
        {
            Init(context);
        }

        public Pizza(Context context, IAttributeSet attrs) : base(context, attrs)
        {
            Init(context, attrs);
        }

        public Pizza(Context context, IAttributeSet attrs, int defStyleAttr) : base(context, attrs, defStyleAttr)
        {
            Init(context, attrs);
        }

        public Pizza(Context context, IAttributeSet attrs, int defStyleAttr, int defStyleRes) : base(context, attrs, defStyleAttr, defStyleRes)
        {
            Init(context, attrs);
        }
        #endregion

        private void Init(Context context = null, IAttributeSet attrs = null)
        {
            _pieces = 6;
            _strokeWidth = 4;
            _color = Color.DarkKhaki;
            if (attrs != null && context != null)
            {
                TypedArray array = context.ObtainStyledAttributes(attrs, Resource.Styleable.Pizza);
                _strokeWidth = array.GetDimensionPixelSize(Resource.Styleable.Pizza_stroke_width, _strokeWidth);
                _pieces = array.GetInteger(Resource.Styleable.Pizza_pieces, _pieces);
                _color = array.GetColor(Resource.Styleable.Pizza_color, _color);
            }

            _paint = new Paint(PaintFlags.AntiAlias);
            _paint.SetStyle(Paint.Style.Stroke);
            _paint.StrokeWidth = _strokeWidth;
            _paint.Color = _color;
        }

        protected override void OnDraw(Canvas canvas)
        {
            base.OnDraw(canvas);

            var width = Width - PaddingLeft - PaddingRight;
            var height = Height - PaddingTop - PaddingBottom;
            var centerX = (width / 2) + PaddingLeft;
            var centerY = (height / 2) + PaddingTop;
            var diameter = Math.Min(width, height) - _paint.StrokeWidth;
            var radius = diameter/2;

            canvas.DrawCircle(centerX, centerY, radius, _paint);
            CutPizza(canvas, _pieces, centerX, centerY, radius);
        }

        private void CutPizza(Canvas canvas, int pieces, float cx, float cy, float radius)
        {
            var degreesForRotation = 360 / pieces;
            for (int i = 0; i < degreesForRotation; i++)
            {
                canvas.DrawLine(cx, cy, cx, cy - radius, _paint);
                canvas.Save();
                canvas.Rotate(degreesForRotation, cx, cy);
            }
        }
    }
}