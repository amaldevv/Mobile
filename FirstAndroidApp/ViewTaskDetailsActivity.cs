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
    [Activity(Label = "View Task Details")]
    public class ViewTaskDetailsActivity : Activity
    {
        private Task _task;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

           

            SetContentView(Resource.Layout.ViewTaskScreen);

           

            var taskName = Intent.GetStringExtra("SelectedTripName");
            _task = new TaskManager().GetTask(taskName);
            // In case the Trip was just created, intialize expenses

            UpdateUI();

           
        }


        private void UpdateUI()
        {
            FindViewById<TextView>(Resource.Id.viewTaskDetailTextViewTaskName).Text = _task.Name;
            FindViewById<TextView>(Resource.Id.viewTaskDetailTextViewDesc).Text = _task.Description;

            FindViewById<TextView>(Resource.Id.viewTaskDetailTextViewTaskEstCompDate).Text = _task.EstimatedCompletionDate.ToString("d");

            

        }
    }
}