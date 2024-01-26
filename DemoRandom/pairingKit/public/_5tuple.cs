/// <summary>
/// Description: public functions for 5 tuple pairing
/// Programmer: Bryan Cancel
/// Combine Sequence [(a,b) , (c,d,e)] -> z
/// 
/// note: currently using 2tuple pairing multiple times
/// could simplify by using 2tupe(2tuple(a,b), 3tuple(c,d,e))
/// </summary>
/*
 * C# Integral Types
 * 
 * -------------------------using BYTES
 * sbyte	-128 to 127	Signed 8-bit integer
 * byte	    0 to 255	Unsigned 8-bit integer
 * COMBOS: (25_6)^2 = 65,536 [exactly what ushort can store]
 * 
 * using SZUDZIK: 
 *      (byte,byte) -> [ushort]
 *      (byte,byte) -> [ushort]
 *      ([ushort],[ushort]) -> [uint]
 *      ([uint],uint) -> [ulong]
 * 
 * -------------------------using SHORTS-------------------------STOP(I dont want to use BigInteger)-------------------------
 * short	-32,768 to 32,767	Signed 16-bit integer
 * ushort	0 to 65,535	Unsigned 16-bit integer
 * COMBOS: (65,53_6)^2 = 4,294,967,296 [exactly what uint can store]
 * 
 * using SZUDZIK:
 *      (ushort,ushort) -> [uint]
 *      (ushort,ushort) -> [uint]
 *      ([uint],[uint]) -> [ulong]
 *      ([ulong],ulong) -> [BigInteger]                 
 * 
 * -------------------------using INTS
 * int	    -2,147,483,648 to 2,147,483,647	Signed 32-bit integer
 * uint	    0 to 4,294,967,295	Unsigned 32-bit integer
 * COMBOS: (4,294,967,29_6)^2 = 18,446,744,073,709,551,616 [exactly what ulong can store]
 * 
 * using SZUDZIK:
 *      (uint,uint) -> [ulong]
 *      (uint,uint) -> [ulong]
 *      ([ulong],[ulong]) -> [BigInteger]           
 *      ([BigInteger],BigInteger) -> [BigInteger]               
 * 
 * -------------------------using LONGS
 * long	    -9,223,372,036,854,775,808 to 9,223,372,036,854,775,807	Signed 64-bit integer
 * ulong	0 to 18,446,744,073,709,551,615	Unsigned 64-bit integer
 * COMBOS: (18,446,744,073,709,551,61_6)^2 = 340,282,366,920,938,463,463,374,607,431,768,211,456 [perhaps using Big Integer]
 * 
 * using SZUDZIK:
 *      (ulong,ulong) -> [BigInteger]
 *      (ulong,ulong) -> [BigInteger]
 *      ([BigInteger],[BigInteger]) -> [BigInteger]
 *      ([BigInteger],BigInteger) -> [BigInteger]          
 */
public static class _5tuple //1 type range [(byte/sbyte)]
{
    #region Combine

    //(sbyte/byte) [2]
    //[2]^5 = 32 possible combos [sets of 16]

    #region byte [16]

    #region byte, byte [8]

    #region byte, byte, byte [4]

    #region byte, byte, byte, byte [2]

    //5th byte
    public static ulong combine(byte a, byte b, byte c, byte d, byte e)
    {
        return _2tuple.combine(_2tuple.combine(a, b), _3tuple.combine(c, d, e));
    }

    //5th sbyte
    public static ulong combine(byte a, byte b, byte c, byte d, sbyte e)
    {
        return _2tuple.combine(_2tuple.combine(a, b), _3tuple.combine(c, d, e));
    }

    #endregion

    #region byte, byte, byte, sbyte [2]

    //5th byte
    public static ulong combine(byte a, byte b, byte c, sbyte d, byte e)
    {
        return _2tuple.combine(_2tuple.combine(a, b), _3tuple.combine(c, d, e));
    }

    //5th sbyte
    public static ulong combine(byte a, byte b, byte c, sbyte d, sbyte e)
    {
        return _2tuple.combine(_2tuple.combine(a, b), _3tuple.combine(c, d, e));
    }

    #endregion

    #endregion

    #region byte, byte, sbyte [4]

    #region byte, byte, sbyte, byte [2]

    //5th byte
    public static ulong combine(byte a, byte b, sbyte c, byte d, byte e)
    {
        return _2tuple.combine(_2tuple.combine(a, b), _3tuple.combine(c, d, e));
    }

    //5th sbyte
    public static ulong combine(byte a, byte b, sbyte c, byte d, sbyte e)
    {
        return _2tuple.combine(_2tuple.combine(a, b), _3tuple.combine(c, d, e));
    }

    #endregion

    #region byte, byte, sbyte, sbyte [2]

    //5th byte
    public static ulong combine(byte a, byte b, sbyte c, sbyte d, byte e)
    {
        return _2tuple.combine(_2tuple.combine(a, b), _3tuple.combine(c, d, e));
    }

    //5th sbyte
    public static ulong combine(byte a, byte b, sbyte c, sbyte d, sbyte e)
    {
        return _2tuple.combine(_2tuple.combine(a, b), _3tuple.combine(c, d, e));
    }

    #endregion

    #endregion

    #endregion

    #region byte, sbyte [8]

    #region byte, sbyte, byte [4]

    #region byte, sbyte, byte, byte [2]

    //5th byte
    public static ulong combine(byte a, sbyte b, byte c, byte d, byte e)
    {
        return _2tuple.combine(_2tuple.combine(a, b), _3tuple.combine(c, d, e));
    }

    //5th sbyte
    public static ulong combine(byte a, sbyte b, byte c, byte d, sbyte e)
    {
        return _2tuple.combine(_2tuple.combine(a, b), _3tuple.combine(c, d, e));
    }

    #endregion

    #region byte, sbyte, byte, sbyte [2]

    //5th byte
    public static ulong combine(byte a, sbyte b, byte c, sbyte d, byte e)
    {
        return _2tuple.combine(_2tuple.combine(a, b), _3tuple.combine(c, d, e));
    }

    //5th sbyte
    public static ulong combine(byte a, sbyte b, byte c, sbyte d, sbyte e)
    {
        return _2tuple.combine(_2tuple.combine(a, b), _3tuple.combine(c, d, e));
    }

    #endregion

    #endregion

    #region byte, sbyte, sbyte [4]

    #region byte, sbyte, sbyte, byte [2]

    //5th byte
    public static ulong combine(byte a, sbyte b, sbyte c, byte d, byte e)
    {
        return _2tuple.combine(_2tuple.combine(a, b), _3tuple.combine(c, d, e));
    }

    //5th sbyte
    public static ulong combine(byte a, sbyte b, sbyte c, byte d, sbyte e)
    {
        return _2tuple.combine(_2tuple.combine(a, b), _3tuple.combine(c, d, e));
    }

    #endregion

    #region byte, sbyte, sbyte, sbyte [2]

    //5th byte
    public static ulong combine(byte a, sbyte b, sbyte c, sbyte d, byte e)
    {
        return _2tuple.combine(_2tuple.combine(a, b), _3tuple.combine(c, d, e));
    }

    //5th sbyte
    public static ulong combine(byte a, sbyte b, sbyte c, sbyte d, sbyte e)
    {
        return _2tuple.combine(_2tuple.combine(a, b), _3tuple.combine(c, d, e));
    }

    #endregion

    #endregion

    #endregion

    #endregion

    #region sbyte [16]

    #region sbyte byte [8]

    #region sbyte byte byte [4]

    #region sbyte byte byte byte [2]

    //5th byte
    public static ulong combine(sbyte a, byte b, byte c, byte d, byte e)
    {
        return _2tuple.combine(_2tuple.combine(a, b), _3tuple.combine(c, d, e));
    }

    //5th sbyte
    public static ulong combine(sbyte a, byte b, byte c, byte d, sbyte e)
    {
        return _2tuple.combine(_2tuple.combine(a, b), _3tuple.combine(c, d, e));
    }

    #endregion

    #region sbyte byte byte sbyte [2]

    //5th byte
    public static ulong combine(sbyte a, byte b, byte c, sbyte d, byte e)
    {
        return _2tuple.combine(_2tuple.combine(a, b), _3tuple.combine(c, d, e));
    }

    //5th sbyte
    public static ulong combine(sbyte a, byte b, byte c, sbyte d, sbyte e)
    {
        return _2tuple.combine(_2tuple.combine(a, b), _3tuple.combine(c, d, e));
    }

    #endregion

    #endregion

    #region sbyte byte sbyte [4]

    #region sbyte byte sbyte byte [2]

    //5th byte
    public static ulong combine(sbyte a, byte b, sbyte c, byte d, byte e)
    {
        return _2tuple.combine(_2tuple.combine(a, b), _3tuple.combine(c, d, e));
    }

    //5th sbyte
    public static ulong combine(sbyte a, byte b, sbyte c, byte d, sbyte e)
    {
        return _2tuple.combine(_2tuple.combine(a, b), _3tuple.combine(c, d, e));
    }

    #endregion

    #region sbyte byte sbyte sbyte [2]

    //5th byte
    public static ulong combine(sbyte a, byte b, sbyte c, sbyte d, byte e)
    {
        return _2tuple.combine(_2tuple.combine(a, b), _3tuple.combine(c, d, e));
    }

    //5th sbyte
    public static ulong combine(sbyte a, byte b, sbyte c, sbyte d, sbyte e)
    {
        return _2tuple.combine(_2tuple.combine(a, b), _3tuple.combine(c, d, e));
    }

    #endregion

    #endregion

    #endregion

    #region sbyte sbyte [8]

    #region sbyte sbyte byte [4]

    #region sbyte sbyte byte byte [2]

    //5th byte
    public static ulong combine(sbyte a, sbyte b, byte c, byte d, byte e)
    {
        return _2tuple.combine(_2tuple.combine(a, b), _3tuple.combine(c, d, e));
    }

    //5th sbyte
    public static ulong combine(sbyte a, sbyte b, byte c, byte d, sbyte e)
    {
        return _2tuple.combine(_2tuple.combine(a, b), _3tuple.combine(c, d, e));
    }

    #endregion

    #region sbyte sbyte byte sbyte [2]

    //5th byte
    public static ulong combine(sbyte a, sbyte b, byte c, sbyte d, byte e)
    {
        return _2tuple.combine(_2tuple.combine(a, b), _3tuple.combine(c, d, e));
    }

    //5th sbyte
    public static ulong combine(sbyte a, sbyte b, byte c, sbyte d, sbyte e)
    {
        return _2tuple.combine(_2tuple.combine(a, b), _3tuple.combine(c, d, e));
    }

    #endregion

    #endregion

    #region sbyte sbyte sbyte [4]

    #region sbyte sbyte sbyte byte [2]

    //5th byte
    public static ulong combine(sbyte a, sbyte b, sbyte c, byte d, byte e)
    {
        return _2tuple.combine(_2tuple.combine(a, b), _3tuple.combine(c, d, e));
    }

    //5th sbyte
    public static ulong combine(sbyte a, sbyte b, sbyte c, byte d, sbyte e)
    {
        return _2tuple.combine(_2tuple.combine(a, b), _3tuple.combine(c, d, e));
    }

    #endregion

    #region sbyte sbyte sbyte sbyte [2]

    //5th byte
    public static ulong combine(sbyte a, sbyte b, sbyte c, sbyte d, byte e)
    {
        return _2tuple.combine(_2tuple.combine(a, b), _3tuple.combine(c, d, e));
    }

    //5th sbyte
    public static ulong combine(sbyte a, sbyte b, sbyte c, sbyte d, sbyte e)
    {
        return _2tuple.combine(_2tuple.combine(a, b), _3tuple.combine(c, d, e));
    }

    #endregion

    #endregion

    #endregion

    #endregion

    #endregion

    #region Reverse

    //[(a,b) , (c,d,e)]
    public static byte[] reverse(ulong z) //5 bytes... rounds to 8 bytes = 4 ushorts = 2 uints = 1 ulong
    {
        uint[] P1_P2 = _2tuple.reverse(z);
        ushort[] ab = _2tuple.reverse(P1_P2[0]);
        byte[] cde = _3tuple.reverse(P1_P2[1]);
        return [(byte) ab[0], (byte) ab[1], (byte) cde[0], (byte) cde[1], (byte) cde[2]];
    }

    #endregion
}