using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhaHang.Helpers {
    public class Color {
        public static System.Drawing.Color Black { get; internal set; }

        public static List<string> GetColors() {
            // Create empty list
            List<string> colorList = new List<string>();

            // Get type of KnownColor enum
            var color = typeof(System.Drawing.KnownColor);

            // Enumerate all known color names in enum
            var colors = Enum.GetValues(color);

            // Remove 27 from beginning
            var from = 27;

            // Remove 7 elements from the end
            var to = colors.Length - 7;

            // Only keep color names and not user interface colors
            for (int i = from; i < to; i++) {
                colorList.Add(colors.GetValue(i).ToString());
            }

            // Return filtered color list
            return colorList;
        }
    }
}
