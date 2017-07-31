using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapraFunctionLibrary
{
    public delegate void GetDataEventHandler(WithTagEventArgs e);

    public delegate void SetDataEventHandler(WithTagEventArgs e);

    public delegate void ChangeDataEventHandler<T>(ChangeEventArgs<T> e);

    public class WithTagEventArgs : System.EventArgs
    {
        private string tag;

        public string Tag
        {
            get
            {
                return tag;
            }
        }

        public WithTagEventArgs(string tag)
            => this.tag = tag;
    }

    public class ChangeEventArgs<T> : System.EventArgs
    {
        private T before;
        private T after;
        private string tag;

        public T Before
        {
            get
            {
                return before;
            }
        }
        public T After
        {
            get
            {
                return after;
            }
        }
        public string Tag
        {
            get
            {
                return tag;
            }
        }

        public ChangeEventArgs(string tag, T before, T after)
        {
            this.tag = tag;
            this.before = before;
            this.after = after;
        }
    }

    public class CprData<T>
    {
        private T item;
        private string tag;

        public event GetDataEventHandler GetDataEvent;
        public event SetDataEventHandler SetDataEvent;
        public event ChangeDataEventHandler<T> ChangeDataEvent;

        public CprData(T item, string tag)
        {
            this.item = item;
            this.tag = tag;
        }

        protected virtual void OnGetData(WithTagEventArgs e)
        {
            if (GetDataEvent != null)
                GetDataEvent(e);
        }
        protected virtual void OnSetData(WithTagEventArgs e)
        {
            if (SetDataEvent != null)
                SetDataEvent(e);
        }
        protected virtual void OnChangeData(ChangeEventArgs<T> e)
        {
            if (SetDataEvent != null)
                ChangeDataEvent(e);
        }

        public T Item
        {
            get
            {
                OnGetData(new WithTagEventArgs(tag));
                return item;
            }
            set
            {
                T item_clone = item;
                OnSetData(new WithTagEventArgs(tag));
                item = value;
                if (!item.Equals(item_clone))
                    OnChangeData(new ChangeEventArgs<T>(tag, item_clone, item));
            }
        }
        public string Tag
        {
            get
            {
                return tag;
            }
        }
    }
}
