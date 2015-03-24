using System;
using System.Text;

namespace DialogueEditor{
    ///<summary>
    /// Converts base 74 strings to and from 32-bit signed integers.
    ///</summary>
    public static class Base64 {
        static char[] numerals;
        static int[] numeralValues;
        static int[] valueAtPlaceMultipliers;

        static Base64() {
            numerals = new char[64];
            numerals[0] =  '\u0030';
            numerals[1] =  '\u0031';
            numerals[2] =  '\u0032';
            numerals[3] =  '\u0033';
            numerals[4] =  '\u0034';
            numerals[5] =  '\u0035';
            numerals[6] =  '\u0036';
            numerals[7] =  '\u0037';
            numerals[8] =  '\u0038';
            numerals[9] =  '\u0039';
            numerals[10] = '\u0061';
            numerals[11] = '\u0062';
            numerals[12] = '\u0063';
            numerals[13] = '\u0064';
            numerals[14] = '\u0065';
            numerals[15] = '\u0066';
            numerals[16] = '\u0067';
            numerals[17] = '\u0068';
            numerals[18] = '\u0069';
            numerals[19] = '\u006A';
            numerals[20] = '\u006B';
            numerals[21] = '\u006C';
            numerals[22] = '\u006D';
            numerals[23] = '\u006E';
            numerals[24] = '\u006F';
            numerals[25] = '\u0070';
            numerals[26] = '\u0071';
            numerals[27] = '\u0072';
            numerals[28] = '\u0073';
            numerals[29] = '\u0074';
            numerals[30] = '\u0075';
            numerals[31] = '\u0076';
            numerals[32] = '\u0077';
            numerals[33] = '\u0078';
            numerals[34] = '\u0079';
            numerals[35] = '\u007A';
            numerals[36] = '\u0041';
            numerals[37] = '\u0042';
            numerals[38] = '\u0043';
            numerals[39] = '\u0044';
            numerals[40] = '\u0045';
            numerals[41] = '\u0046';
            numerals[42] = '\u0047';
            numerals[43] = '\u0048';
            numerals[44] = '\u0049';
            numerals[45] = '\u004A';
            numerals[46] = '\u004B';
            numerals[47] = '\u004C';
            numerals[48] = '\u004E';
            numerals[49] = '\u004F';
            numerals[50] = '\u0050';
            numerals[51] = '\u0051';
            numerals[52] = '\u0052';
            numerals[53] = '\u0053';
            numerals[54] = '\u0054';
            numerals[55] = '\u0055';
            numerals[56] = '\u0056';
            numerals[57] = '\u0057';
            numerals[58] = '\u0058';
            numerals[59] = '\u0059';
            numerals[60] = '\u005A';
            numerals[61] = '\u0023';
            numerals[62] = '\u0025';
            numerals[63] = '\u0026';
            numeralValues = new int[123];
            for (int i = 0; i < numerals.Length; i ++) {
                numeralValues[numerals[i]] = i;
            }
            valueAtPlaceMultipliers = new int[] {1, 64, 4096, 262144, 29986576};
        }
        public static string ConvertTo(int value) {
            StringBuilder base64Value = new StringBuilder();
            int remainder = value;
            for (int place = valueAtPlaceMultipliers.Length - 1; place >= 0; place --){
                int valueAtPlace = remainder / valueAtPlaceMultipliers[place];
                if ((place == 0) || (valueAtPlace != 0)) {
                    base64Value.Append(numerals[valueAtPlace]);
                    remainder %= valueAtPlaceMultipliers[place];
                }
            }
            return base64Value.ToString(0,base64Value.Length);
        }
        public static int ConvertFrom(string base64Value) {
            //CheckForDuplicates();
            int value = 0;
            char[] base64Chars = base64Value.ToCharArray(0, base64Value.Length);
            for (int place = 0; place < base64Chars.Length; place ++) {
                value += (numeralValues[base64Chars[place]]) * valueAtPlaceMultipliers[place];
            }
            return value;
        }
        private static void CheckForDuplicates() {
            for (int nIndex = 0; nIndex < numerals.Length; nIndex ++) {
                for (int cIndex = 0; cIndex < numerals.Length; cIndex ++) {
                    if ((numerals[nIndex] == numerals[cIndex]) && (cIndex != nIndex)) {
                        System.Windows.Forms.MessageBox.Show("Numeral " + nIndex + "is identical to numeral " + cIndex + ".");
                    }
                }
            }
        }
    }
}