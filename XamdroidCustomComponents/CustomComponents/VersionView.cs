using System;

using Android.Content;
using Android.Runtime;
using Android.Util;
using Android.Widget;

namespace XamdroidCustomComponents.CustomComponents
{
    public class VersionView : TextView
    {
        protected VersionView(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer)
        {
            SetVersion();
        }

        public VersionView(Context context) : base(context)
        {
            SetVersion();
        }

        public VersionView(Context context, IAttributeSet attrs) : base(context, attrs)
        {
            SetVersion();
        }

        public VersionView(Context context, IAttributeSet attrs, int defStyleAttr) : base(context, attrs, defStyleAttr)
        {
            SetVersion();
        }

        public VersionView(Context context, IAttributeSet attrs, int defStyleAttr, int defStyleRes) : base(context, attrs, defStyleAttr, defStyleRes)
        {
            SetVersion();
        }

        private void SetVersion()
        {
            var packageName = Context.PackageManager.GetPackageInfo(Context.PackageName, 0);
            Text = packageName.VersionName;
        }
    }
}