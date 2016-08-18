using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace AlertDialogFragment
{
    class CustomDialogFragment : DialogFragment
    {
        public override void OnActivityCreated(Bundle savedInstanceState)
        {
            Dialog.Window.RequestFeature(WindowFeatures.NoTitle);
            base.OnActivityCreated(savedInstanceState);
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            View view = inflater.Inflate(Resource.Layout.CustomFragment, container, false);

            Button btnCancel = view.FindViewById<Button>(Resource.Id.btnCancel);
            btnCancel.Click += delegate
            {
                Dismiss();
                Toast.MakeText(Activity, "Dialog Fragment Dismissed", ToastLength.Short).Show();
            };

            return view;
        }
        public override void OnResume()
        {
            
            Dialog.Window.SetLayout(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.WrapContent);
            base.OnResume();
        }
    }
}