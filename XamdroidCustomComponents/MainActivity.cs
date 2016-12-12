using Android.App;
using Android.OS;
using Android.Widget;
using XamdroidCustomComponents.CustomComponents;

namespace XamdroidCustomComponents
{
    [Activity(Label = "XamdroidCustomComponents", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        private TextView _areaValue;
        private LengthPicker _widthPicker;
        private LengthPicker _lengthPicker;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            _widthPicker = FindViewById(Resource.Id.widthPicker) as LengthPicker;
            _lengthPicker = FindViewById(Resource.Id.lengthPicker) as LengthPicker;
            _areaValue = FindViewById(Resource.Id.areaValue) as TextView;
            
            // 2. Listener via event
            _widthPicker.OnValueChanged += new LengthPicker.OnValueChangeHandler(picker_OnValueChanged);
            _lengthPicker.OnValueChanged += new LengthPicker.OnValueChangeHandler(picker_OnValueChanged);
        }

        protected override void OnResume()
        {
            base.OnResume();
            UpdateSquareInchForArea();
        }

        private void picker_OnValueChanged(object myObject, LengthPickerArgs myArgs)
        {
            UpdateSquareInchForArea();
        }

        private void UpdateSquareInchForArea()
        {
            var field = _widthPicker.NumberInInches * _lengthPicker.NumberInInches;
            _areaValue.Text = $"{field} Zoll^2";
        }
    }
}

