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
using TaskTracker.Core.Model;
using TaskTracker.Core.BL;

namespace FirstAndroidApp
{
    [Activity(Label = "Edit Task Details")]
    public class EditTaskActivity : Activity
    {
        private Task _task;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.EditTaskScreen);

            var taskName = Intent.GetStringExtra("SelectedTaskName");

            _task = String.IsNullOrEmpty(taskName) ? new Task() : new TaskManager().GetTask(taskName);

            UpdateUI();

            FindViewById<Button>(Resource.Id.editTaskButtonSave).Click += (s, e) =>
            {
                UpdateTrip();
                new TaskManager().SaveTask(_task);

                var intent = new Intent(this, typeof(MainActivity));
                //intent.PutExtra("SelectedTaskName", _task.Name);

                base.StartActivity(intent);
            };

            FindViewById<Button>(Resource.Id.editTaskButtonDelete).Click += (s, e) =>
            {

                new TaskManager().DeleteTask(_task);
                var intent = new Intent(this, typeof(MainActivity));
                base.StartActivity(intent);
            };
        }

        private void UpdateUI()
        {
            FindViewById<TextView>(Resource.Id.editTaskEditTextTaskName).Text = _task.Name;
            FindViewById<DatePicker>(Resource.Id.editTaskDatePickerEstComp).UpdateDate(_task.EstimatedCompletionDate.Year,
                _task.EstimatedCompletionDate.Month, _task.EstimatedCompletionDate.Day);
            
            
            FindViewById<EditText>(Resource.Id.editTaskEditTextDesc).Text = _task.Description;
        }

        private void UpdateTrip()
        {
            _task.Name = FindViewById<TextView>(Resource.Id.editTaskEditTextTaskName).Text;

            var estCompDate = FindViewById<DatePicker>(Resource.Id.editTaskDatePickerEstComp);
            _task.EstimatedCompletionDate = new DateTime(estCompDate.Year, estCompDate.Month, estCompDate.DayOfMonth);
            
            _task.Description = FindViewById<EditText>(Resource.Id.editTaskEditTextDesc).Text;

        }
    }
}