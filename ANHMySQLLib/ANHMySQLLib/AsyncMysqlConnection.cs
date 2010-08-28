using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using MySql.Data.MySqlClient;

namespace ANHMySQLLib
{
    class AsyncMysqlConnection
    {
        private MySqlConnection mConnection;
        private SharedWorkQueue<AsyncMysqlCommand> mCommandQueue;
        private Thread mProcessor;
        private bool mRunning;

        public AsyncMysqlConnection(MySqlConnection connection, SharedWorkQueue<AsyncMysqlCommand> commandQueue)
        {
            mConnection = connection;
            mCommandQueue = commandQueue;
            mProcessor = new Thread(new ThreadStart(this.Process));
            mRunning = true;

            mProcessor.Start();
        }

        public void Shutdown()
        {
            mRunning = false;

            //Console.WriteLine("waiting for connection to shutdown..");

            while (mProcessor.IsAlive)
            {
                mCommandQueue.Notify();
            }
        }


        private void Process()
        {

            while (mRunning)
            {

                //Console.WriteLine("{0} waiting for work", Thread.CurrentThread.ManagedThreadId);

                mCommandQueue.WaitForWork();
                mCommandQueue.GetContext();

                //Console.WriteLine("{0} got work", Thread.CurrentThread.ManagedThreadId);

                if (mCommandQueue.Count != 0)
                {

                    //Console.WriteLine("thread {0} processing query ", Thread.CurrentThread.ManagedThreadId);

                    AsyncMysqlCommand command = mCommandQueue.Dequeue();

                    mCommandQueue.NotifyEmpty();

                    mCommandQueue.ReleaseContext();

                    command.Command.Connection = mConnection;

                    try
                    {
                        command.Execute();
                    }
                    catch (MySqlException exception)
                    {

                    }

                    command.InvokeHandler();

                    //Console.WriteLine("{0} processing complete", Thread.CurrentThread.ManagedThreadId);

                }
                else
                {
                    //Console.WriteLine("{0} nothing to do ", Thread.CurrentThread.ManagedThreadId);
                    mCommandQueue.ReleaseContext();
                }
            }

            //Console.WriteLine("closing mysql connection..");

            mConnection.Close();

            Console.WriteLine("mysql connection closed");

        }
    }
}
