using System;

/// <summary>
/// Description: pairingKit using the Cantor Pairing & Szudzik Pairing Functions
/// Programmer: Bryan Cancel
/// Reason For Existance: Provides the BASE For all the _Ntuple classes (Refer to the Documentation for Details)
/// </summary>
public class tupleBase
{
    #region pairingFunctions

    #region Cantor Pairing

    /*
     * C# Integral Types
     * 
     * -------------------------using BYTES
     * sbyte	-128 to 127	Signed 8-bit integer
     * byte	    0 to 255	Unsigned 8-bit integer
     * COMBOS: (25_6)^2 = 65,536 [exactly what ushort can store]
     * 
     * CANTOR PAIR MAX: (using largest byte)
     *      cantor(255,255) = ((((255 + 255) * (255 + 255 + 1)) / 2) + 255) 
     *      = ((((2*255) * ((2*255) + 1)) / 2) + 255) = [130,560] (REQUIRES uint)
     * 
     * -------------------------using SHORTS
     * short	-32,768 to 32,767	Signed 16-bit integer
     * ushort	0 to 65,535	Unsigned 16-bit integer
     * COMBOS: (65,53_6)^2 = 4,294,967,296 [exactly what uint can store]
     * 
     * CANTOR PAIR MAX: (using largest ushort)
     *      cantor([65,535],[65,535]) = (((([65,535] + [65,535]) * ([65,535] + [65,535] + 1)) / 2) + [65,535]) 
     *      = ((((2*[65,535]) * ((2*[65,535]) + 1)) / 2) + [65,535]) = [8,589,803,520] (REQUIRES ulong)
     * 
     * -------------------------using INTS
     * int	    -2,147,483,648 to 2,147,483,647	Signed 32-bit integer
     * uint	    0 to 4,294,967,295	Unsigned 32-bit integer
     * COMBOS: (4,294,967,29_6)^2 = 18,446,744,073,709,551,616 [exactly what ulong can store]
     * 
     * CANTOR PAIR MAX: (using largest uint)
     *      cantor([4,294,967,295],[4,294,967,295]) 
     *      = (((([4,294,967,295] + [4,294,967,295]) * ([4,294,967,295] + [4,294,967,295] + 1)) / 2) + [4,294,967,295]) 
     *      = ((((2*[4,294,967,295]) * ((2*[4,294,967,295]) + 1)) / 2) + [4,294,967,295])
     *      = [36,893,488,138,829,168,640] (REQUIRES larger than ulong -OR- limitation)
     *      LIMITED SIZE -> LIMITED CANTOR PAIR MAX (just smaller than ulong)
     *      3037000499 -> 18,446,744,067,926,499,000 [smaller than ulong]
     *      3037000500 -> 18,446,744,080,074,501,000 [larger than ulong]
     * 
     * -------------------------using LONGS
     * long	    -9,223,372,036,854,775,808 to 9,223,372,036,854,775,807	Signed 64-bit integer
     * ulong	0 to 18,446,744,073,709,551,615	Unsigned 64-bit integer
     * COMBOS: (18,446,744,073,709,551,61_6)^2 = 340,282,366,920,938,463,463,374,607,431,768,211,456 [maybe Big Integer]
     * 
     * CANTOR PAIR MAX: (using largest ulong)
     *      cantor([18,446,744,073,709,551,615],[18,446,744,073,709,551,615]) 
     *      = (((([18,446,744,073,709,551,615] + [18,446,744,073,709,551,615]) * ([18,446,744,073,709,551,615] + [18,446,744,073,709,551,615] + 1)) / 2) + [18,446,744,073,709,551,615]) 
     *      = ((((2*[18,446,744,073,709,551,615]) * ((2*[18,446,744,073,709,551,615]) + 1)) / 2) + [18,446,744,073,709,551,615])
     *      = [680,564,733,841,876,926,889,855,726,716,117,319,680] (REQUIRES larger than ulong -OR- limitation)
     *      LIMITATION would be pointless since it would cover the same numbers as ints and uints
     */

    #region For 8 Bit Integers

    internal static uint byteCantor2tupleCombine(byte x, byte y)
    {
        return (uint) ((((x + y) * (x + y + 1)) / 2) + y);
    }

    internal static byte[] byteCantor2tupleReverse(uint z) //this number will be POSITIVE
    {
        //Assuming z is uint.MAXVALUE -> max of 185363.80005 (we don't need decimals)
        //ushort w = (ushort)Math.Sqrt((8 * z) + 1); //this number will be POSITIVE [PLACE INTO FUNC BELOW]
        //Assuming largest value 185363.80005 -> max of 92681 (ushort is too small) (use int)
        ushort
            W = (ushort) Math.Floor((double) (((Math.Sqrt((8 * z) + 1)) - 1) /
                                              2)); //this number wILL be POSITIVE [if w >= 1 (which is always true)] (returns an integer)
        //Assuming largest vlaue 92681 -> 4,294,930,221 (ushort is too small) (use int)
        ushort T = (ushort) (((W * W) + W) / 2);

        byte y = (byte) (z - T);
        byte x = (byte) (W - y);

        return [x, y];
    }

    #endregion

    #region For 16,32,64 [Szudik is Better]

    #region For 16 Bit Integers

    //-----using SHORT

    //-----using USHORT

    #endregion

    #region For 32 Bit Integers

    //-----using INT

    //-----using UINT

    #endregion

    #region For 64 Bit Integers

    //-----using LONG

    //-----using ULONG

    #endregion

    #endregion

    #endregion

    #region Szudzik Pairing

    /*
     * C# Integral Types
     * 
     * -------------------------using BYTES
     * sbyte	-128 to 127	Signed 8-bit integer
     * byte	    0 to 255	Unsigned 8-bit integer
     * COMBOS: (25_6)^2 = 65,536 [exactly what ushort can store]
     * 
     * SZUDZIK PAIR MAX: (25_6)^2 = 65,536 [exactly what ushort can store]
     * 
     * -------------------------using SHORTS
     * short	-32,768 to 32,767	Signed 16-bit integer
     * ushort	0 to 65,535	Unsigned 16-bit integer
     * COMBOS: (65,53_6)^2 = 4,294,967,296 [exactly what uint can store]
     * 
     * SZUDZIK PAIR MAX: (65,53_6)^2 = 4,294,967,296 [exactly what uint can store]
     * 
     * -------------------------using INTS
     * int	    -2,147,483,648 to 2,147,483,647	Signed 32-bit integer
     * uint	    0 to 4,294,967,295	Unsigned 32-bit integer
     * COMBOS: (4,294,967,29_6)^2 = 18,446,744,073,709,551,616 [exactly what ulong can store]
     * 
     * SZUDZIK PAIR MAX: (4,294,967,29_6)^2 = 18,446,744,073,709,551,616 [exactly what ulong can store]
     * 
     * -------------------------using LONGS
     * long	    -9,223,372,036,854,775,808 to 9,223,372,036,854,775,807	Signed 64-bit integer
     * ulong	0 to 18,446,744,073,709,551,615	Unsigned 64-bit integer
     * COMBOS: (18,446,744,073,709,551,61_6)^2 = 340,282,366,920,938,463,463,374,607,431,768,211,456 [perhaps using Big Integer]
     * 
     * SZUDZIK PAIR MAX: (18,446,744,073,709,551,61_6)^2 = 340,282,366,920,938,463,463,374,607,431,768,211,456 [perhaps using Big Integer]
     */

    #region For 8 Bit Integers

    internal static ushort byteSzudzik2tupleCombine(byte x, byte y)
    {
        if (x != Math.Max(x, y))
            return (ushort) ((y * y) + x);
        else
            return (ushort) ((x * x) + x + y);
    }

    internal static byte[] byteSzudzik2tupleReverse(ushort z) //this number WILL be positive
    {
        //Assuming z is ushort.MAXVALUE -> max of 255 (use byte)
        byte zSpecial1 = (byte) Math.Floor(Math.Sqrt(z)); //this number WILL be positive (returns integer)
        //Assuming largest values -> max of 510 (byte is too small) (use short)
        ushort zSpecial2 = (ushort) (z - (zSpecial1 * zSpecial1)); //this number WILL be positive (returns integer)

        if (zSpecial2 < zSpecial1)
            return [(byte) zSpecial2, (byte) zSpecial1];
        else
            return [(byte) zSpecial1, (byte) (zSpecial2 - zSpecial1)];
    }

    #endregion

    #region For 16 Bit Integers

    internal static uint ushortSzudzik2tupleCombine(ushort x, ushort y)
    {
        if (x != Math.Max(x, y))
            return (uint) ((y * y) + x);
        else
            return (uint) ((x * x) + x + y);
    }

    internal static ushort[] ushortSzudzik2tupleReverse(uint z) //this number WILL be positive
    {
        ushort zSpecial1 = (ushort) Math.Floor(Math.Sqrt(z)); //this number WILL be positive (returns integer)
        uint zSpecial2 = (uint) (z - (zSpecial1 * zSpecial1)); //this number WILL be positive (returns integer)

        if (zSpecial2 < zSpecial1)
            return [(ushort) zSpecial2, (ushort) zSpecial1];
        else
            return [(ushort) zSpecial1, (ushort) (zSpecial2 - zSpecial1)];
    }

    #endregion

    #region For 32 Bit Integers

    internal static ulong uintSzudzik2tupleCombine(uint x, uint y)
    {
        if (x != Math.Max(x, y))
            return (ulong) ((y * y) + x);
        else
            return (ulong) ((x * x) + x + y);
    }

    internal static uint[] uintSzudzik2tupleReverse(ulong z) //this number WILL be positive
    {
        uint zSpecial1 = (uint) Math.Floor(Math.Sqrt(z)); //this number WILL be positive (returns integer)
        ulong zSpecial2 = (ulong) (z - (zSpecial1 * zSpecial1)); //this number WILL be positive (returns integer)

        if (zSpecial2 < zSpecial1)
            return [(uint) zSpecial2, (uint) zSpecial1];
        else
            return [(uint) zSpecial1, (uint) (zSpecial2 - zSpecial1)];
    }

    #endregion

    #region For 64 Bit Integers [requires BigInteger]

    //-----using ULONG

    //-----using LONG

    #endregion

    #endregion

    #endregion
}