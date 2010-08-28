using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using ANHMySQLLib.Command;
using System.Threading;

namespace ANHMySQLLib
{

    public abstract class AsyncMysqlCommand
    {

        protected MySqlCommand mMySqlCommand;
        protected MySqlException mException;
        protected AutoResetEvent mCompleted;

        public MySqlCommand Command
        {
            get
            {
                return mMySqlCommand;
            }
        }

        public MySqlException Error
        {
            get
            {
                return mException;
            }
        }

        public AsyncMysqlCommand()
        {
            mCompleted = new AutoResetEvent(false);
        }

        public AsyncMysqlCommand(MySqlCommand command)
            : this()
        {
            mMySqlCommand = command;
        }

        public AsyncMysqlCommand(string command)
            : this()
        {
            mMySqlCommand = new MySqlCommand(command);
        }


        public void WaitForCompletion()
        {
            mCompleted.WaitOne();
        }

        public virtual void InvokeHandler()
        {
            throw new Exception("this method has to be overloaded");
        }

        public virtual void Execute()
        {
            mCompleted.Set();
        }

    }

}