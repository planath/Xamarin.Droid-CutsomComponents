using System;

using Android.Content;
using Android.Runtime;
using Android.Util;
using Android.Views;

namespace XamdroidCustomComponents.CustomComponents
{
    public class SquareView : View
    {
        protected SquareView(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer)
        {
        }

        public SquareView(Context context) : base(context)
        {
        }

        public SquareView(Context context, IAttributeSet attrs) : base(context, attrs)
        {
        }

        public SquareView(Context context, IAttributeSet attrs, int defStyleAttr) : base(context, attrs, defStyleAttr)
        {
        }

        public SquareView(Context context, IAttributeSet attrs, int defStyleAttr, int defStyleRes) : base(context, attrs, defStyleAttr, defStyleRes)
        {
        }

        protected override void OnMeasure(int widthMeasureSpec, int heightMeasureSpec)
        {
            base.OnMeasure(widthMeasureSpec, heightMeasureSpec);

            var smallerSize = Math.Min(MeasuredHeight, MeasuredWidth);

            // it is 0 in scroll view, as maximum height is inf
            if (smallerSize == 0)
            {
                smallerSize = Math.Max(MeasuredHeight, MeasuredWidth);
            }
            SetMeasuredDimension(smallerSize, smallerSize);
        }
    }
}