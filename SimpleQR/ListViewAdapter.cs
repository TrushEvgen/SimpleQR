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

namespace SimpleQR
{
    class ListViewAdapter : BaseAdapter<string>
    {
        List<string> TextList;
        Activity context;

        public ListViewAdapter(Activity context, List<string> textList)
        {
            this.context = context;
            this.TextList = textList;
        }


        public override Java.Lang.Object GetItem(int position)
        {
            return position;
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var view = convertView ?? context.LayoutInflater.Inflate(Resource.Layout.ShowScannedQR, parent, false);

            view.FindViewById<TextView>(Resource.Id.ShowScannedQRText).Text = TextList[position];
            return view;
        }

        //Fill in cound here, currently 0
        public override int Count
        {
            get
            {
                int count = 0;
                if (TextList != null)
                    count = TextList.Count;
                return count;
            }
        }

        public override string this[int position] => TextList[position];
    }

    class ListViewAdapterViewHolder : Java.Lang.Object
    {
        //Your adapter views to re-use
        //public TextView Title { get; set; }
    }
}