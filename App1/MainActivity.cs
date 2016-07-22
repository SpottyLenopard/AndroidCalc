using System;
using System.Linq;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Java.Interop;

namespace App1
{
    [Activity(Label = "CalcApp", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity, View.IOnClickListener
    {
        private EditText _editText;

        private double _right;
        private double _left;
        private string _operation;
        private bool _toClean;

        public const string LeftOp = "Left";
        public const string RightOp = "Right";
        public const string Operation = "Uperation";
        public const string ToClean = "ToClean";
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);


            _editText = FindViewById<EditText>(Resource.Id.editText1);

            Button button1 = FindViewById<Button>(Resource.Id.button1);
            button1.SetOnClickListener(this);
            Button button2 = FindViewById<Button>(Resource.Id.button2);
            button2.SetOnClickListener(this);
            Button button3 = FindViewById<Button>(Resource.Id.button3);
            button3.SetOnClickListener(this);
            Button button4 = FindViewById<Button>(Resource.Id.button4);
            button4.SetOnClickListener(this);
            Button button5 = FindViewById<Button>(Resource.Id.button5);
            button5.SetOnClickListener(this);
            Button button6 = FindViewById<Button>(Resource.Id.button6);
            button6.SetOnClickListener(this);
            Button button7 = FindViewById<Button>(Resource.Id.button7);
            button7.SetOnClickListener(this);
            Button button8 = FindViewById<Button>(Resource.Id.button8);
            button8.SetOnClickListener(this);
            Button button9 = FindViewById<Button>(Resource.Id.button9);
            button9.SetOnClickListener(this);
            Button button10 = FindViewById<Button>(Resource.Id.button10);
            button10.SetOnClickListener(this);
            Button button11 = FindViewById<Button>(Resource.Id.button11);
            button11.SetOnClickListener(this);
            Button button12 = FindViewById<Button>(Resource.Id.button12);
            button12.SetOnClickListener(this);
            Button button13 = FindViewById<Button>(Resource.Id.button13);
            button13.SetOnClickListener(this);
            Button button14 = FindViewById<Button>(Resource.Id.button14);
            button14.SetOnClickListener(this);
            Button button15 = FindViewById<Button>(Resource.Id.button15);
            button15.SetOnClickListener(this);
            Button button16 = FindViewById<Button>(Resource.Id.button16);
            button16.SetOnClickListener(this);


            if (bundle != null)
            {
                if (bundle.ContainsKey(LeftOp))
                    _left = Double.Parse(bundle.GetString(LeftOp));
                if (bundle.ContainsKey(RightOp))
                    _right = Double.Parse(bundle.GetString(RightOp));
                if (bundle.ContainsKey(Operation))
                    _operation = bundle.GetString(Operation);
                if (bundle.ContainsKey(ToClean))
                    _toClean = bundle.GetBoolean(ToClean);
            }

        }

        protected override void OnSaveInstanceState(Bundle state)
        {
            state.PutString(LeftOp, _left.ToString());
            state.PutString(Operation, _operation);
            if (_operation !=string.Empty && _editText.Text != string.Empty)
                state.PutString(RightOp, _editText.Text);
            state.PutBoolean(ToClean,_toClean);
            base.OnSaveInstanceState(state);
        }

        public void OnClick(View v)
        {
            if (v is Button)
            {
                string s = ((Button) v).Text;
                if (s.All(char.IsDigit) || s == ".")
                {
                    if (_toClean)
                    {
                        _editText.Text = string.Empty;
                        _toClean = false;
                    }
                    
                    _editText.Text += s;
                }
                switch (s)
                {
                    case "+":
                    case "-":
                    case "*":
                        if (Double.TryParse(_editText.Text, out _left))
                            _editText.Text = string.Empty;
                        _right = 0;
                        _operation = s;
                        break;
                    case "=":
                        if (Double.TryParse(_editText.Text, out _right))
                            if (_operation == "+")
                                _editText.Text = (_left + _right).ToString();
                            else
                                if (_operation == "-")
                                    _editText.Text = (_left - _right).ToString();
                                else
                                _editText.Text = (_left * _right).ToString();
                        _operation = string.Empty;
                        _right = _left = 0;
                        _toClean = true;
                        break;
                    case "CE":
                        _editText.Text = string.Empty;
                        break;
                }
            }
        }
    }
}



