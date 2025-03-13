using System.Data;
using Oracle.ManagedDataAccess.Client;

namespace WindowsFormsApplication2
{
    class clsDB
    {
        public OracleDataAdapter mDataAdapter = new OracleDataAdapter();
        public DataSet mDataSet = new DataSet();
        public OracleConnection mConn;

        public clsDB()
        {
            mConn = new OracleConnection("User Id=(the id);Password=(the password);Data Source=(the data source)");

        // Para conectar ao Oracle DB, precisa de prover o Oracle Data Provider for .NET (ODP.NET)    

        // Make sure to install the Oracle.ManagedDataAccess - Certifique de instalar o Oracle.ManagedDataAccess
        // Install-Package Oracle.ManagedDataAccess -Version 19.3.3
        // Depois de instalar, adicione a referência ao projeto
        // mConn = new OracleConnection("User Id=your_user_id;Password=your_password;Data Source=your_data_source");
        }

        public void SQLDB(string strSQL, Dictionary<string, object> parameters = null)
        {
            try
            {
                mConn.Open();
                OracleCommand command = new OracleCommand(strSQL, mConn);
                if (parameters != null)
                {
                    foreach (var param in parameters)
                    {
                        command.Parameters.Add(new OracleParameter(param.Key, param.Value));
                    }
                }

                mDataAdapter = new OracleDataAdapter(command);
                mDataSet = new DataSet();
                mDataAdapter.Fill(mDataSet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                mConn.Close();
            }
        }

        public void ClearRes()
        {
            mDataAdapter.Dispose();
            mDataAdapter = null;
            mDataSet.Dispose();
            if (mConn.State != ConnectionState.Closed)
            {
                mConn.Close();
            }
        }
    }
}