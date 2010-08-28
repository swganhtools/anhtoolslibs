using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

namespace ANHMySQLLib.Command
{

    public delegate void QueryCompletedHandler(MySqlDataReader reader);
    public delegate void NonQueryCompletedHandler(int affectedRows);


}
