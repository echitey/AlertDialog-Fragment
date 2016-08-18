using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace AlertDialogFragment
{
    [Activity(Label = "AlertDialogFragment", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        private Button btnDialog;
        private Button btnDialogFragment;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            btnDialog = FindViewById<Button>(Resource.Id.btnDialog);
            btnDialogFragment = FindViewById<Button>(Resource.Id.btnDialogFragment);

            btnDialog.Click += BtnDialog_Click;
            btnDialogFragment.Click += BtnDialogFragment_Click;
        }

        private void BtnDialogFragment_Click(object sender, EventArgs e)
        {
            FragmentTransaction tr = FragmentManager.BeginTransaction();
            CustomDialogFragment dialog = new CustomDialogFragment();
            dialog.Show(tr, "LoginFragment");
        }

        private void BtnDialog_Click(object sender, EventArgs e)
        {
            AlertDialog.Builder builder = new AlertDialog.Builder(this);
            builder.SetTitle("Alert Dialog");
            builder.SetMessage("This is the Default Dialog Fragment.");
            builder.SetPositiveButton("OK", delegate {
                Toast.MakeText(this, "OK Button Pressed", ToastLength.Short).Show();
            });
            builder.SetNegativeButton("Cancel", delegate {
                builder.Dispose();
            });
            builder.Show();
        }
    }
}

