using Previsul.Components.Logging.Domain.Interfaces;
using Previsul.Components.Logging.Domain.Model;
using System;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Previsul.Components.LoggingRepository
{
    public class SqlLogRepository : ILogRepository
    {
        public string ConnectionString { get; set; }

        public SqlLogRepository(string connectionString)
        {
            ConnectionString = string.IsNullOrEmpty(connectionString) ? throw new ArgumentException() : connectionString;
        }
        
        public async Task<bool> InsertSync(LogEntry log)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                await connection.OpenAsync();

                var sqlCommandQueryBuilder = SqlCommandQueryBuilder(log);
                sqlCommandQueryBuilder.Connection = connection;

                var affectedRows = await sqlCommandQueryBuilder.ExecuteNonQueryAsync();
                
                return affectedRows > 0;
            }
        }

        public bool Insert(LogEntry log)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                var sqlCommandQueryBuilder = SqlCommandQueryBuilder(log);
                sqlCommandQueryBuilder.Connection = connection;

                var affectedRows = sqlCommandQueryBuilder.ExecuteNonQuery();

                return affectedRows > 0;
            }
        }

        #region [Private Methods]

        private SqlCommand SqlCommandQueryBuilder(LogEntry log)
        {
            var sqlCommand = new SqlCommand
            {
                CommandText = @"INSERT INTO DBO.[LOG] (TIMESTAMP, 
                                        MACHINE_NAME, 
                                        SEVERITY, 
                                        SOURCE, 
                                        MESSAGE, 
                                        REQUEST_ID, 
                                        IP_ADDRESS,
                                        APPLICATION)
                                    VALUES(
                                        @TimeStamp,
                                        @MachineName,
                                        @Severity,
                                        @Source,
                                        @Message,
                                        @RequestId,
                                        @IpAddress,
                                        @Application)"
            };

            sqlCommand.Parameters.AddWithValue("@TimeStamp", log.TimeStamp);
            sqlCommand.Parameters.AddWithValue("@MachineName", string.IsNullOrEmpty(log.MachineName) ? (object)DBNull.Value : log.MachineName?.Truncate(32));
            sqlCommand.Parameters.AddWithValue("@Severity", log.Severity);
            sqlCommand.Parameters.AddWithValue("@Source", string.IsNullOrEmpty(log.Source) ? (object)DBNull.Value : log.Source?.Truncate(255));
            sqlCommand.Parameters.AddWithValue("@Message", string.IsNullOrEmpty(log.Message) ? (object)DBNull.Value : log.Message?.Truncate(8000));
            sqlCommand.Parameters.AddWithValue("@RequestId", log.RequestId ?? (object)DBNull.Value );
            sqlCommand.Parameters.AddWithValue("@IpAddress", string.IsNullOrEmpty(log.IpAddress) ? (object)DBNull.Value : log.IpAddress?.Truncate(15));
            sqlCommand.Parameters.AddWithValue("@Application", log.Application);

            return sqlCommand;
        }

        #endregion
    }
}
