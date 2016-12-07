using System;

using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using Java.Security;

namespace XamdroidCustomComponents.CustomComponents
{
    public class LengthPicker : LinearLayout
    {
        private static readonly string KEY_SUPER_STATE = "superState";
        private static readonly string KEY_NUMBER_OF_INCHES = "numberOfInches";

        private View _plusButton;
        private View _minusButton;
        private TextView _textView;

        #region Constructors
        protected LengthPicker(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer)
        {
            Init();
        }

        public LengthPicker(Context context) : base(context)
        {
            Init();
        }

        public LengthPicker(Context context, IAttributeSet attrs) : base(context, attrs)
        {
            Init();
        }

        public LengthPicker(Context context, IAttributeSet attrs, int defStyleAttr) : base(context, attrs, defStyleAttr)
        {
            Init();
        }

        public LengthPicker(Context context, IAttributeSet attrs, int defStyleAttr, int defStyleRes) : base(context, attrs, defStyleAttr, defStyleRes)
        {
            Init();
        }
        #endregion
        public int NumberInInches { get; private set; }
        // 1. Listener via class
        public IOnChangeListener OnChangeListener { get; set; }
        // 2. Listener via event
        public delegate void OnValueChangeHandler(object myObject, LengthPickerArgs myArgs);
        public event OnValueChangeHandler OnValueChanged;

        protected override IParcelable OnSaveInstanceState()
        {
            var bundle = new Bundle();
            bundle.PutParcelable(KEY_SUPER_STATE, base.OnSaveInstanceState());
            bundle.PutInt(KEY_NUMBER_OF_INCHES, NumberInInches);

            return bundle;
        }

        protected override void OnRestoreInstanceState(IParcelable state)
        {
            if (state is Bundle)
            {
                var bundle = state as Bundle;
                NumberInInches = bundle.GetInt(KEY_NUMBER_OF_INCHES);
                base.OnRestoreInstanceState(bundle.GetParcelable(KEY_NUMBER_OF_INCHES) as IParcelable);
            }
            else
            {
                base.OnRestoreInstanceState(state);
            }

            UpdateControlls();
        }

        private void Init()
        {
            // the inflator sets the content. Like what SetContentView() does in an Activity.
            var inflator = LayoutInflater.From(Context);
            inflator.Inflate(Resource.Layout.LengthPicker, this);

            _plusButton = FindViewById(Resource.Id.lengthPicker_plusButton);
            _minusButton = FindViewById(Resource.Id.lengthPicker_minusButton);
            _textView = FindViewById(Resource.Id.lengthPicker_textView) as TextView;
            Orientation = Orientation.Horizontal;
            
            UpdateControlls();
            _minusButton.Click += minusButton_Click;
            _plusButton.Click += plusButton_Click;
        }
        
        private void minusButton_Click(object sender, EventArgs e)
        {
            if (NumberInInches > 0)
            {
                NumberInInches--;
                InformSubscribedListenersOnChange();
                UpdateControlls();
            }
        }
        private void plusButton_Click(object sender, EventArgs e)
        {
            NumberInInches++;
            InformSubscribedListenersOnChange();
            UpdateControlls();
        }

        private void InformSubscribedListenersOnChange()
        {
            if (OnValueChanged != null)
            {
                var args = new LengthPickerArgs(NumberInInches);
                OnValueChanged(this, args);
            }
        }

        private void UpdateControlls()
        {
            var feet = NumberInInches / 12;
            var inches = NumberInInches % 12;

            var textViewText = $"{feet} Fuss {inches} Zoll";

            if (feet == 0)
            {
                textViewText = $"{inches} Zoll";
            }
            else if (inches == 0)
            {
                textViewText = $"{feet} Fuss";
            }

            _textView.Text = textViewText;
            _minusButton.Enabled = NumberInInches > 0;
        }
        public interface IOnChangeListener
        {
            void OnChange(int length);
        }
    }
}