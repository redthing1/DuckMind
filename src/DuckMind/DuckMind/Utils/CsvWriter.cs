using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DuckMind.Utils {
    public class CsvWriter {
        private Stream outStream;
        private StreamWriter sw;

        public CsvWriter(Stream outStream) {
            this.outStream = outStream;
            sw = new StreamWriter(outStream);
        }

        public void header(params string[] columns) {
            var sb = new StringBuilder();
            for (var i = 0; i < columns.Length; i++) {
                sb.Append(columns[i]);
                sb.Append(",");
            }
            sw.WriteLine(sb.ToString());
            sw.Flush();
        }

        public void data(IEnumerable<string[]> data) {
            foreach (var row in data) {
                foreach (var point in row) {
                    sw.Write(point + ",");
                }
                sw.WriteLine();
            }
            sw.Flush();
        }
    }
}