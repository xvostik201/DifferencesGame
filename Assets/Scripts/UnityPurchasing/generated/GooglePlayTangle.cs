// WARNING: Do not modify! Generated file.

namespace UnityEngine.Purchasing.Security {
    public class GooglePlayTangle
    {
        private static byte[] data = System.Convert.FromBase64String("QhnMk+sllhg8PP/y3MSkxYSzfhn/o5SSyOvU+LZ70Rb3/x1n6ydKDc48LoDGkA5d2QzWAy6eUyh3lDUXFTt3KYZpk+8yn15jmiB+CQq2lVDFRkhHd8VGTUXFRkZH2DFbabWzw642Qfv5xaJ/XH0lZwjyWu7ViTnt+g0XwdmWXlU1j5bqYvnw5x9h8zlQkct94Nqe0sMgX1RkiCG+UsooThlppvtnXgxTSE7ZIekaY0E6nsNomjFmtKuwKRKWlECS/0PdlN0l4LspqcKBungQRY51DuWyjUQM+LGo43fFRmV3SkFObcEPwbBKRkZGQkdEQRbRVl45xzsd2DtovHVRTTdWTCQDAkscmygxRgshXB0gl6Cwh1UV+cvEONz4xEIHhkVERkdG");
        private static int[] order = new int[] { 3,2,4,6,4,7,9,10,10,12,10,12,13,13,14 };
        private static int key = 71;

        public static readonly bool IsPopulated = true;

        public static byte[] Data() {
        	if (IsPopulated == false)
        		return null;
            return Obfuscator.DeObfuscate(data, order, key);
        }
    }
}
