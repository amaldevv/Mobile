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

namespace FirstAndroidApp
{
    public class HomeTaskListAdapter : BaseAdapter<Task>
    {
        List<Task> _tasks;
        Activity _context;

        public HomeTaskListAdapter(Activity context, List<Task> tasks)
        {
            this._tasks = tasks;
            this._context = context;
        }

       public override Task this[int position]
        {
            get { return _tasks[position]; }
        }

        public override int Count
        {
            get
            {
                return _tasks.Count;
            }
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var item = _tasks[position];
            View view = convertView ?? _context.LayoutInflater.Inflate(Resource.Layout.HomeTaskViewList, null);
            view.FindViewById<TextView>(Resource.Id.TaskName).Text = item.Name;
            //view.FindViewById<TextView>(Resource.Id.TaskDescription).Text = item.Description;
            view.FindViewById<TextView>(Resource.Id.TaskEstimatedCompletionDate).Text = item.EstimatedCompletionDate.ToString("d");

          
            return view;
        }
    }
}