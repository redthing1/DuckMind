using System.Collections.Generic;

namespace Ducia.Utils {
    public class DebugStore {
        public static Dictionary<string, Table> tables;

        static DebugStore() {
            initialize();
        }

        public static void initialize() {
            tables = new Dictionary<string, Table>();
        }

        public static void point(string table, string[] vals) {
            if (!tables.ContainsKey(table)) tables[table] = new Table();
            tables[table].add(vals);
        }

        public class Table {
            public List<string[]> data = new List<string[]>();

            public void add(string[] vals) {
                data.Add(vals);
            }
        }
    }
}