using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

namespace ANHMySQLLib.Command
{

    public abstract class AsyncMysqlCommandCallBack<T> : AsyncMysqlCommand
    {
        protected T mCallBack;

        public AsyncMysqlCommandCallBack(string command) : base(command) { }
        public AsyncMysqlCommandCallBack(MySqlCommand command) : base(command) { }

        public void SetHandler(T handler)
        {
            mCallBack = handler;
        }

    }
}
