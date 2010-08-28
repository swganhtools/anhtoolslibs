using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Data;
using System.Threading;

namespace ANHMySQLLib
{



    public class MysqlEngine
    {

        private Stack<AsyncMysqlConnection> mConnections;
        private SharedWorkQueue<AsyncMysqlCommand> mCommandQueue;

        private bool mShuttingDown;

        private string mConnectionString;


        public MysqlEngine(string connectionString)
        {
            mConnections = new Stack<AsyncMysqlConnection>();
            mCommandQueue = new SharedWorkQueue<AsyncMysqlCommand>();
            mShuttingDown = false;

            mConnectionString = connectionString;
        }

        public void Shutdown(bool clearQueue)
        {

            mShuttingDown = true;

            if (clearQueue)
            {
                mCommandQueue.Clear();
            }

            Console.WriteLine("waiting for {0} to finish..", mCommandQueue.Count);
            mCommandQueue.WaitForEmpty();

            foreach (AsyncMysqlConnection connection in mConnections)
            {
                connection.Shutdown();
            }
        }

        public void AddConnections(int count)
        {
            for (int i = 0; i < count; i++)
            {
                this.AddConnection();
            }
        }

        private void AddConnection()
        {
            MySqlConnection connection = new MySqlConnection();
            connection.ConnectionString = mConnectionString;
            connection.Open();

            Console.WriteLine("opened connection #{0}", this.mConnections.Count);

            mConnections.Push(new AsyncMysqlConnection(connection, mCommandQueue));
        }




        public void ExecuteAsync(AsyncMysqlCommand command)
        {
            if (mShuttingDown)
                throw new Exception("MysqlQueryManager is shutting down. No more queries accepted");

            mCommandQueue.Enqueue(command);
        }


        public void ExecuteSync(AsyncMysqlCommand command)
        {
            this.ExecuteAsync(command);
            command.WaitForCompletion();
        }

    }
}
