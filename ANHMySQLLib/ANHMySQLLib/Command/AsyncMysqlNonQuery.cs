using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

namespace ANHMySQLLib.Command
{

    public class AsyncMysqlNonQuery : AsyncMysqlCommandCallBack<NonQueryCompletedHandler>
    {

        private int mAffectedRows;

        public AsyncMysqlNonQuery(string command)
            : base(command)
        {
            mAffectedRows = -1;
        }

        public AsyncMysqlNonQuery(string command, NonQueryCompletedHandler callback)
            : base(command)
        {
            mAffectedRows = -1;
            mCallBack = callback;
        }

        public AsyncMysqlNonQuery(MySqlCommand command, NonQueryCompletedHandler callback)
            : base(command)
        {
            mAffectedRows = -1;
            mCallBack = callback;
        }

        public override void Execute()
        {
            try
            {
                mAffectedRows = mMySqlCommand.ExecuteNonQuery();
            }
            catch (MySqlException exception)
            {
                mException = exception;
            }

            base.Execute();
        }

        public override void InvokeHandler()
        {
            mCallBack.Invoke(mAffectedRows);
        }


    }
}
