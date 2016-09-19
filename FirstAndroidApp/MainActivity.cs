using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using TaskTracker.Core.Model;
using System.Collections.Generic;
using TaskTracker.Core.BL;

namespace FirstAndroidApp
{
    [Activity(Label = "TaskTracker", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        private ListView _taskView;
        private List<Task> _tasks;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Get our button from the layout resource,
            // and attach an event to it
            Button button = FindViewById<Button>(Resource.Id.homeButtonAddTask);

            button.Click += (s, e) =>
            {
                var intent = new Intent(this, typeof(EditTaskActivity));
                base.StartActivity(intent);
            };

            _taskView = FindViewById<ListView>(Resource.Id.homeListViewTasks);
            if(_taskView != null)
            {
                _taskView.ItemClick += (s, e) =>
                {
                    var intent = new Intent(this, typeof(EditTaskActivity));
                    intent.PutExtra("SelectedTaskName", _tasks[e.Position].Name);
                    base.StartActivity(intent);
                };
            }
        }

        protected override void OnResume()
        {
            base.OnResume();
            _tasks = new TaskManager().GetTasks();
            _taskView.Adapter = new HomeTaskListAdapter(this, _tasks);
        }
    }
}

