using System.Data;
using System.Data.OleDb;

namespace BnB.WinForms.Services;

/// <summary>
/// Reads data from legacy Microsoft Access database (bnb1.mdb)
/// </summary>
public class AccessDataReader : IDisposable
{
    private readonly string _connectionString;
    private OleDbConnection? _connection;

    public AccessDataReader(string mdbFilePath)
    {
        // Use Jet 4.0 for older Access 97/2000 databases (requires 32-bit mode)
        _connectionString = $"Provider=Microsoft.Jet.OLEDB.4.0;Data Source={mdbFilePath};";
    }

    public void Open()
    {
        _connection = new OleDbConnection(_connectionString);
        _connection.Open();
    }

    public void Close()
    {
        _connection?.Close();
    }

    /// <summary>
    /// Gets all table names in the database
    /// </summary>
    public List<string> GetTableNames()
    {
        if (_connection == null) throw new InvalidOperationException("Connection not open");

        var tables = new List<string>();
        var schema = _connection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object?[] { null, null, null, "TABLE" });

        if (schema != null)
        {
            foreach (DataRow row in schema.Rows)
            {
                tables.Add(row["TABLE_NAME"].ToString() ?? "");
            }
        }

        return tables;
    }

    /// <summary>
    /// Gets the count of records in a table
    /// </summary>
    public int GetRecordCount(string tableName)
    {
        if (_connection == null) throw new InvalidOperationException("Connection not open");

        using var cmd = new OleDbCommand($"SELECT COUNT(*) FROM [{tableName}]", _connection);
        return Convert.ToInt32(cmd.ExecuteScalar());
    }

    /// <summary>
    /// Reads all rows from a table
    /// </summary>
    public DataTable ReadTable(string tableName)
    {
        if (_connection == null) throw new InvalidOperationException("Connection not open");

        using var adapter = new OleDbDataAdapter($"SELECT * FROM [{tableName}]", _connection);
        var table = new DataTable();
        adapter.Fill(table);
        return table;
    }

    /// <summary>
    /// Reads all rows from a table with a specific query
    /// </summary>
    public DataTable ReadQuery(string sql)
    {
        if (_connection == null) throw new InvalidOperationException("Connection not open");

        using var adapter = new OleDbDataAdapter(sql, _connection);
        var table = new DataTable();
        adapter.Fill(table);
        return table;
    }

    /// <summary>
    /// Safely gets a string value from a DataRow
    /// </summary>
    public static string? GetString(DataRow row, string columnName)
    {
        if (!row.Table.Columns.Contains(columnName)) return null;
        var value = row[columnName];
        return value == DBNull.Value ? null : value?.ToString()?.Trim();
    }

    /// <summary>
    /// Safely gets an integer value from a DataRow
    /// </summary>
    public static int GetInt(DataRow row, string columnName, int defaultValue = 0)
    {
        if (!row.Table.Columns.Contains(columnName)) return defaultValue;
        var value = row[columnName];
        if (value == DBNull.Value) return defaultValue;
        return Convert.ToInt32(value);
    }

    /// <summary>
    /// Safely gets a long value from a DataRow
    /// </summary>
    public static long GetLong(DataRow row, string columnName, long defaultValue = 0)
    {
        if (!row.Table.Columns.Contains(columnName)) return defaultValue;
        var value = row[columnName];
        if (value == DBNull.Value) return defaultValue;
        return Convert.ToInt64(value);
    }

    /// <summary>
    /// Safely gets a decimal value from a DataRow
    /// </summary>
    public static decimal GetDecimal(DataRow row, string columnName, decimal defaultValue = 0)
    {
        if (!row.Table.Columns.Contains(columnName)) return defaultValue;
        var value = row[columnName];
        if (value == DBNull.Value) return defaultValue;
        return Convert.ToDecimal(value);
    }

    /// <summary>
    /// Safely gets a nullable decimal value from a DataRow
    /// </summary>
    public static decimal? GetNullableDecimal(DataRow row, string columnName)
    {
        if (!row.Table.Columns.Contains(columnName)) return null;
        var value = row[columnName];
        return value == DBNull.Value ? null : Convert.ToDecimal(value);
    }

    /// <summary>
    /// Safely gets a DateTime value from a DataRow
    /// </summary>
    public static DateTime? GetDateTime(DataRow row, string columnName)
    {
        if (!row.Table.Columns.Contains(columnName)) return null;
        var value = row[columnName];
        return value == DBNull.Value ? null : Convert.ToDateTime(value);
    }

    /// <summary>
    /// Safely gets a boolean value from a DataRow
    /// </summary>
    public static bool GetBool(DataRow row, string columnName, bool defaultValue = false)
    {
        if (!row.Table.Columns.Contains(columnName)) return defaultValue;
        var value = row[columnName];
        if (value == DBNull.Value) return defaultValue;

        // Handle various boolean representations
        if (value is bool b) return b;
        if (value is int i) return i != 0;
        if (value is short s) return s != 0;
        if (value is string str) return str.Equals("True", StringComparison.OrdinalIgnoreCase) || str == "1" || str == "-1";

        return Convert.ToBoolean(value);
    }

    public void Dispose()
    {
        _connection?.Close();
        _connection?.Dispose();
    }
}
