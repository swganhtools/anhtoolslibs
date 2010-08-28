using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ANHMySQLLib
{
    class SharedWorkQueue<T>
    {
        private object mContext;
        private Queue<T> mQueue;
        private AutoResetEvent mEnqueueEvent;
        private AutoResetEvent mEmpty;

        public int Count
        {
            get
            {
                return mQueue.Count;
            }
        }

        public SharedWorkQueue()
        {
            mContext = new object();
            mQueue = new Queue<T>();
            mEnqueueEvent = new AutoResetEvent(false);
            mEmpty = new AutoResetEvent(false);
        }

        public void GetContext()
        {
            Monitor.Enter(mContext);
        }

        public void ReleaseContext()
        {
            Monitor.Exit(mContext);
        }

        public void Enqueue(T command)
        {
            this.GetContext();

            mQueue.Enqueue(command);

            this.ReleaseContext();

            this.NotifyEmpty();
        }

        public void WaitForWork()
        {
            mEnqueueEvent.WaitOne();
        }

        public void WaitForEmpty()
        {
            mEmpty.WaitOne();
        }

        public void NotifyEmpty()
        {
            if (mQueue.Count != 0)
            {
                mEnqueueEvent.Set();
            }
            else
            {
                mEmpty.Set();
            }
        }

        public void Notify()
        {
            mEnqueueEvent.Set();
        }


        public T Dequeue()
        {
            return mQueue.Dequeue();
        }

        public void Clear()
        {
            this.GetContext();
            mQueue.Clear();
            this.ReleaseContext();
        }
    }
}
