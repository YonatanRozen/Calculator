using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using Android.Content;
using System;

namespace Calculator
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        private EditText etNum1, etNum2;
        private Spinner spAction;
        private TextView tvResult;
        private Button btnCalculate;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            etNum1 = FindViewById<EditText>(Resource.Id.etNum1);
            etNum2 = FindViewById<EditText>(Resource.Id.etNum2);
            spAction = FindViewById<Spinner>(Resource.Id.spAction);
            btnCalculate = FindViewById<Button>(Resource.Id.btnCalculate);
            btnCalculate.Click += Calc_onClick;
            tvResult = FindViewById<TextView>(Resource.Id.tvResult);
            

        }

        private void Calc_onClick (object sender, EventArgs e)
        {
            double num1, num2;
            double res;

            if (double.TryParse(etNum1.Text, out num1) && double.TryParse(etNum2.Text, out num2))
            {
                spAction = FindViewById<Spinner>(Resource.Id.spAction);
                string act = spAction.SelectedItem.ToString();

                if (act == "+")
                {
                    res = num1 + num2;
                    tvResult.Text = res.ToString();
                }

                else if (act == "-")
                {
                    res = num1 - num2;
                    tvResult.Text = res.ToString();
                }

                else if (act == "X")
                {
                    res = num1 * num2;
                    tvResult.Text = res.ToString();
                }

                else if (act == ":")
                {

                    if (num2 == 0)
                        Toast.MakeText(this, "Illegal!", ToastLength.Short).Show();
                    else
                    {
                        res = num1 / num2;
                        tvResult.Text = res.ToString();
                    }
                }
            }

            else
                Toast.MakeText(this, "Illegal!", ToastLength.Short).Show();

        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}