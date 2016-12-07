using System;

using Android.Content;
using Android.Runtime;
using Android.Util;
using Android.Views;

namespace XamdroidCustomComponents.CustomComponents
{
    public class PhotoSpiral : ViewGroup
    {
        #region Constructors
        public PhotoSpiral(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer)
        {
            Init();
        }

        public PhotoSpiral(Context context) : base(context)
        {
            Init();
        }

        public PhotoSpiral(Context context, IAttributeSet attrs) : base(context, attrs)
        {
            Init();
        }

        public PhotoSpiral(Context context, IAttributeSet attrs, int defStyleAttr) : base(context, attrs, defStyleAttr)
        {
            Init();
        }

        public PhotoSpiral(Context context, IAttributeSet attrs, int defStyleAttr, int defStyleRes) : base(context, attrs, defStyleAttr, defStyleRes)
        {
            Init();
        }
        #endregion

        private void Init()
        {
            // the inflator sets the content. Like what SetContentView() does in an Activity.
            var inflator = LayoutInflater.From(Context);
            inflator.Inflate(Resource.Layout.SpiralGallery, this);
        }

        protected override void OnMeasure(int widthMeasureSpec, int heightMeasureSpec)
        {
            // assuming all 4 containing photos are same size
            MeasureChildren(widthMeasureSpec, heightMeasureSpec);
            var firstChild = GetChildAt(0);
            var size = firstChild.MeasuredWidth + firstChild.MeasuredHeight;
            var width = ViewGroup.ResolveSize(size, widthMeasureSpec);
            var height = ViewGroup.ResolveSize(size, heightMeasureSpec);

            SetMeasuredDimension(width, height);
        }

        protected override void OnLayout(bool changed, int l, int t, int r, int b)
        {
            var childLongSide = MeasuredWidth / 3 * 2;
            var childShortSide = MeasuredWidth / 3;

            for (int i = 0; i < ChildCount; ++i)
            {
                var child = GetChildAt(i);
                var x = 0;
                var y = 0;

                switch (i)
                {
                    case 0:
                        child.Layout(x, y, x + childLongSide, y + childShortSide);
                        break;
                    case 1:
                        x = childLongSide;
                        child.Layout(x, y, x + childShortSide, y + childLongSide);
                        break;
                    case 2:
                        y = childShortSide;
                        child.Layout(x, y, x + childShortSide, y + childLongSide);
                        break;
                    case 3:
                        x = childShortSide;
                        y = childLongSide;
                        child.Layout(x, y, x + childLongSide, y + childShortSide);
                        break;
                }
            }
        }
    }
}