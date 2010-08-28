using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

namespace ANHMySQLLib.Command
{
    public class AsyncMysqlQuery : AsyncMysqlCommandCallBack<QueryCompletedHandler>
    {

        private MySqlDataReader mReader;

        public AsyncMysqlQuery(string command) : base(command) { }
        public AsyncMysqlQuery(MySqlCommand command) : base(command) { }
        public AsyncMysqlQuery(string command, QueryCompletedHandler callback)
            : base(command)
        {
            mCallBack = callback;
        }
        public AsyncMysqlQuery(MySqlCommand command, QueryCompletedHandler callback)
            : base(command)
        {
            mCallBack = callback;
        }

        public override void Execute()
        {
            try
            {
                mReader = mMySqlCommand.ExecuteReader();
            }
            catch (MySqlException exception)
            {
                mException = exception;
            }

            base.Execute();
        }

        public override void InvokeHandler()
        {
            mCallBack.Invoke(mReader);

            if (mReader != null)
                mReader.Close();
        }

    }
}
