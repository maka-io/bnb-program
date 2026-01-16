import java.io.*;
import java.nio.file.*;
import java.sql.*;
import java.util.*;
import java.math.BigDecimal;
import java.text.SimpleDateFormat;

/**
 * Exports Microsoft Access (.mdb) database tables to JSON files.
 * Uses UCanAccess JDBC driver to read Access databases.
 *
 * Usage: java -cp ".;lib/*" ExportMdb <path-to-mdb-file>
 */
public class ExportMdb {

    private static final SimpleDateFormat DATE_FORMAT = new SimpleDateFormat("yyyy-MM-dd'T'HH:mm:ss");

    public static void main(String[] args) {
        if (args.length < 1) {
            System.err.println("Usage: java ExportMdb <mdb-file-path>");
            System.exit(1);
        }

        String mdbPath = args[0];
        File mdbFile = new File(mdbPath);

        if (!mdbFile.exists()) {
            System.err.println("ERROR: File not found: " + mdbPath);
            System.exit(1);
        }

        // Create output directory next to the tools folder
        Path toolsDir = Paths.get(System.getProperty("user.dir"));
        Path exportDir = toolsDir.resolve("exported_data");

        try {
            Files.createDirectories(exportDir);
            System.out.println("Exporting to: " + exportDir.toAbsolutePath());

            // Connect to Access database using UCanAccess
            String connUrl = "jdbc:ucanaccess://" + mdbFile.getAbsolutePath() + ";memory=false";

            try (Connection conn = DriverManager.getConnection(connUrl)) {
                System.out.println("Connected to database");

                // Get list of tables
                DatabaseMetaData meta = conn.getMetaData();
                List<String> tables = new ArrayList<>();

                try (ResultSet rs = meta.getTables(null, null, "%", new String[]{"TABLE"})) {
                    while (rs.next()) {
                        String tableName = rs.getString("TABLE_NAME");
                        // Skip system tables
                        if (!tableName.startsWith("~") && !tableName.startsWith("MSys")) {
                            tables.add(tableName);
                        }
                    }
                }

                System.out.println("Found " + tables.size() + " tables");

                // Export each table
                for (String table : tables) {
                    exportTable(conn, table, exportDir);
                }

                System.out.println("Export complete!");
            }

        } catch (Exception e) {
            System.err.println("ERROR: " + e.getMessage());
            e.printStackTrace();
            System.exit(1);
        }
    }

    private static void exportTable(Connection conn, String tableName, Path exportDir) {
        System.out.println("Exporting table: " + tableName);

        try {
            String query = "SELECT * FROM [" + tableName + "]";
            try (Statement stmt = conn.createStatement();
                 ResultSet rs = stmt.executeQuery(query)) {

                ResultSetMetaData meta = rs.getMetaData();
                int columnCount = meta.getColumnCount();

                // Get column names and types
                List<String> columnNames = new ArrayList<>();
                List<Integer> columnTypes = new ArrayList<>();
                for (int i = 1; i <= columnCount; i++) {
                    columnNames.add(meta.getColumnName(i));
                    columnTypes.add(meta.getColumnType(i));
                }

                // Build JSON array
                StringBuilder json = new StringBuilder();
                json.append("[\n");

                boolean first = true;
                int rowCount = 0;

                while (rs.next()) {
                    if (!first) {
                        json.append(",\n");
                    }
                    first = false;

                    json.append("  {");

                    for (int i = 0; i < columnCount; i++) {
                        if (i > 0) {
                            json.append(", ");
                        }

                        String colName = columnNames.get(i);
                        int colType = columnTypes.get(i);
                        Object value = rs.getObject(i + 1);

                        json.append("\"").append(escapeJson(colName)).append("\": ");
                        json.append(formatJsonValue(value, colType));
                    }

                    json.append("}");
                    rowCount++;
                }

                json.append("\n]");

                // Write to file
                String fileName = tableName.toLowerCase().replace(" ", "_") + ".json";
                Path filePath = exportDir.resolve(fileName);
                Files.writeString(filePath, json.toString());

                System.out.println("  - " + rowCount + " rows exported to " + fileName);
            }

        } catch (Exception e) {
            System.err.println("  WARNING: Failed to export " + tableName + ": " + e.getMessage());
        }
    }

    private static String formatJsonValue(Object value, int sqlType) {
        if (value == null) {
            return "null";
        }

        if (value instanceof Boolean) {
            return value.toString();
        }

        if (value instanceof Number) {
            if (value instanceof BigDecimal) {
                return ((BigDecimal) value).toPlainString();
            }
            return value.toString();
        }

        if (value instanceof java.util.Date) {
            synchronized (DATE_FORMAT) {
                return "\"" + DATE_FORMAT.format((java.util.Date) value) + "\"";
            }
        }

        if (value instanceof byte[]) {
            // Binary data - encode as base64 or skip
            return "null";
        }

        // Default: treat as string
        return "\"" + escapeJson(value.toString()) + "\"";
    }

    private static String escapeJson(String s) {
        if (s == null) return "";

        StringBuilder sb = new StringBuilder();
        for (char c : s.toCharArray()) {
            switch (c) {
                case '"':  sb.append("\\\""); break;
                case '\\': sb.append("\\\\"); break;
                case '\b': sb.append("\\b"); break;
                case '\f': sb.append("\\f"); break;
                case '\n': sb.append("\\n"); break;
                case '\r': sb.append("\\r"); break;
                case '\t': sb.append("\\t"); break;
                default:
                    if (c < ' ') {
                        sb.append(String.format("\\u%04x", (int) c));
                    } else {
                        sb.append(c);
                    }
            }
        }
        return sb.toString();
    }
}
