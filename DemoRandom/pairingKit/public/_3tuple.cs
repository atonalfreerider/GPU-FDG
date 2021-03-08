/// <summary>
/// Description: public functions for 3 tuple pairing
/// Programmer: Bryan Cancel
/// Combine Sequence [(a,b) , c] -> z
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
 *      ([ushort],ushort) -> [uint]
 * 
 * -------------------------using SHORTS
 * short	-32,768 to 32,767	Signed 16-bit integer
 * ushort	0 to 65,535	Unsigned 16-bit integer
 * COMBOS: (65,53_6)^2 = 4,294,967,296 [exactly what uint can store]
 * 
 * using SZUDZIK:
 *      (ushort,ushort) -> [uint]
 *      ([uint],uint) -> [ulong]
 * 
 * -------------------------using INTS-------------------------STOP(I dont want to use BigInteger)-------------------------
 * int	    -2,147,483,648 to 2,147,483,647	Signed 32-bit integer
 * uint	    0 to 4,294,967,295	Unsigned 32-bit integer
 * COMBOS: (4,294,967,29_6)^2 = 18,446,744,073,709,551,616 [exactly what ulong can store]
 * 
 * using SZUDZIK:
 *      (uint,uint) -> [ulong]
 *      ([ulong],ulong) -> [BigInteger]         
 * 
 * -------------------------using LONGS
 * long	    -9,223,372,036,854,775,808 to 9,223,372,036,854,775,807	Signed 64-bit integer
 * ulong	0 to 18,446,744,073,709,551,615	Unsigned 64-bit integer
 * COMBOS: (18,446,744,073,709,551,61_6)^2 = 340,282,366,920,938,463,463,374,607,431,768,211,456 [perhaps using Big Integer]
 * 
 * using SZUDZIK:
 *      (ulong,ulong) -> [BigInteger]
 *      ([BigInteger],BigInteger) -> [BigInteger]           
 */
public static class _3tuple //2 type ranges [(byte/sbyte)|(ushort/short)]
{
    #region Combine

    //(sbyte/byte),(short/ushort) [4]
    //[4]^3 = 64 possible combos [sets of 16]

    #region starting with sbyte

    //---2nd sbyte

    public static uint combine(sbyte a, sbyte b, sbyte c)
    {
        return _2tuple.combine(_2tuple.combine(a, b), c);
    } //return (uint)

    public static uint combine(sbyte a, sbyte b, byte c)
    {
        return _2tuple.combine(_2tuple.combine(a, b), c);
    } //return (uint) 

    public static uint combine(sbyte a, sbyte b, short c)
    {
        return _2tuple.combine(_2tuple.combine(a, b), c);
    } //return (uint) 

    public static uint combine(sbyte a, sbyte b, ushort c)
    {
        return _2tuple.combine(_2tuple.combine(a, b), c);
    } //return (uint) 

    //---2nd byte

    public static uint combine(sbyte a, byte b, sbyte c)
    {
        return _2tuple.combine(_2tuple.combine(a, b), c);
    } //return (uint)

    public static uint combine(sbyte a, byte b, byte c)
    {
        return _2tuple.combine(_2tuple.combine(a, b), c);
    } //return (uint)

    public static uint combine(sbyte a, byte b, short c)
    {
        return _2tuple.combine(_2tuple.combine(a, b), c);
    } //return (uint)

    public static uint combine(sbyte a, byte b, ushort c)
    {
        return _2tuple.combine(_2tuple.combine(a, b), c);
    } //return (uint)

    //---2nd short

    public static ulong combine(sbyte a, short b, sbyte c)
    {
        return _2tuple.combine(_2tuple.combine(a, b), c);
    } //return (ulong)

    public static ulong combine(sbyte a, short b, byte c)
    {
        return _2tuple.combine(_2tuple.combine(a, b), c);
    } //return (ulong)

    public static ulong combine(sbyte a, short b, short c)
    {
        return _2tuple.combine(_2tuple.combine(a, b), c);
    } //return (ulong)

    public static ulong combine(sbyte a, short b, ushort c)
    {
        return _2tuple.combine(_2tuple.combine(a, b), c);
    } //return (ulong)

    //---2nd ushort

    public static ulong combine(sbyte a, ushort b, sbyte c)
    {
        return _2tuple.combine(_2tuple.combine(a, b), c);
    } //return (ulong)

    public static ulong combine(sbyte a, ushort b, byte c)
    {
        return _2tuple.combine(_2tuple.combine(a, b), c);
    } //return (ulong)

    public static ulong combine(sbyte a, ushort b, short c)
    {
        return _2tuple.combine(_2tuple.combine(a, b), c);
    } //return (ulong)

    public static ulong combine(sbyte a, ushort b, ushort c)
    {
        return _2tuple.combine(_2tuple.combine(a, b), c);
    } //return (ulong)

    #endregion

    #region starting with byte

    //---2nd sbyte

    public static uint combine(byte a, sbyte b, sbyte c)
    {
        return _2tuple.combine(_2tuple.combine(a, b), c);
    } //return (uint)

    public static uint combine(byte a, sbyte b, byte c)
    {
        return _2tuple.combine(_2tuple.combine(a, b), c);
    } //return (uint) 

    public static uint combine(byte a, sbyte b, short c)
    {
        return _2tuple.combine(_2tuple.combine(a, b), c);
    } //return (uint) 

    public static uint combine(byte a, sbyte b, ushort c)
    {
        return _2tuple.combine(_2tuple.combine(a, b), c);
    } //return (uint) 

    //---2nd byte

    public static uint combine(byte a, byte b, sbyte c)
    {
        return _2tuple.combine(_2tuple.combine(a, b), c);
    } //return (uint)

    public static uint combine(byte a, byte b, byte c)
    {
        return _2tuple.combine(_2tuple.combine(a, b), c);
    } //return (uint)

    public static uint combine(byte a, byte b, short c)
    {
        return _2tuple.combine(_2tuple.combine(a, b), c);
    } //return (uint)

    public static uint combine(byte a, byte b, ushort c)
    {
        return _2tuple.combine(_2tuple.combine(a, b), c);
    } //return (uint)

    //---2nd short

    public static ulong combine(byte a, short b, sbyte c)
    {
        return _2tuple.combine(_2tuple.combine(a, b), c);
    } //return (ulong)

    public static ulong combine(byte a, short b, byte c)
    {
        return _2tuple.combine(_2tuple.combine(a, b), c);
    } //return (ulong)

    public static ulong combine(byte a, short b, short c)
    {
        return _2tuple.combine(_2tuple.combine(a, b), c);
    } //return (ulong)

    public static ulong combine(byte a, short b, ushort c)
    {
        return _2tuple.combine(_2tuple.combine(a, b), c);
    } //return (ulong)

    //---2nd ushort

    public static ulong combine(byte a, ushort b, sbyte c)
    {
        return _2tuple.combine(_2tuple.combine(a, b), c);
    } //return (ulong)

    public static ulong combine(byte a, ushort b, byte c)
    {
        return _2tuple.combine(_2tuple.combine(a, b), c);
    } //return (ulong)

    public static ulong combine(byte a, ushort b, short c)
    {
        return _2tuple.combine(_2tuple.combine(a, b), c);
    } //return (ulong)

    public static ulong combine(byte a, ushort b, ushort c)
    {
        return _2tuple.combine(_2tuple.combine(a, b), c);
    } //return (ulong)

    #endregion

    #region starting with short

    //---2nd sbyte

    public static ulong combine(short a, sbyte b, sbyte c)
    {
        return _2tuple.combine(_2tuple.combine(a, b), c);
    } //return (ulong)

    public static ulong combine(short a, sbyte b, byte c)
    {
        return _2tuple.combine(_2tuple.combine(a, b), c);
    } //return (ulong) 

    public static ulong combine(short a, sbyte b, short c)
    {
        return _2tuple.combine(_2tuple.combine(a, b), c);
    } //return (ulong) 

    public static ulong combine(short a, sbyte b, ushort c)
    {
        return _2tuple.combine(_2tuple.combine(a, b), c);
    } //return (ulong) 

    //---2nd byte

    public static ulong combine(short a, byte b, sbyte c)
    {
        return _2tuple.combine(_2tuple.combine(a, b), c);
    } //return (ulong)

    public static ulong combine(short a, byte b, byte c)
    {
        return _2tuple.combine(_2tuple.combine(a, b), c);
    } //return (ulong)

    public static ulong combine(short a, byte b, short c)
    {
        return _2tuple.combine(_2tuple.combine(a, b), c);
    } //return (ulong)

    public static ulong combine(short a, byte b, ushort c)
    {
        return _2tuple.combine(_2tuple.combine(a, b), c);
    } //return (ulong)

    //---2nd short

    public static ulong combine(short a, short b, sbyte c)
    {
        return _2tuple.combine(_2tuple.combine(a, b), c);
    } //return (ulong)

    public static ulong combine(short a, short b, byte c)
    {
        return _2tuple.combine(_2tuple.combine(a, b), c);
    } //return (ulong)

    public static ulong combine(short a, short b, short c)
    {
        return _2tuple.combine(_2tuple.combine(a, b), c);
    } //return (ulong)

    public static ulong combine(short a, short b, ushort c)
    {
        return _2tuple.combine(_2tuple.combine(a, b), c);
    } //return (ulong)

    //---2nd ushort

    public static ulong combine(short a, ushort b, sbyte c)
    {
        return _2tuple.combine(_2tuple.combine(a, b), c);
    } //return (ulong)

    public static ulong combine(short a, ushort b, byte c)
    {
        return _2tuple.combine(_2tuple.combine(a, b), c);
    } //return (ulong)

    public static ulong combine(short a, ushort b, short c)
    {
        return _2tuple.combine(_2tuple.combine(a, b), c);
    } //return (ulong)

    public static ulong combine(short a, ushort b, ushort c)
    {
        return _2tuple.combine(_2tuple.combine(a, b), c);
    } //return (ulong)

    #endregion

    #region starting with ushort

    //---2nd sbyte

    public static ulong combine(ushort a, sbyte b, sbyte c)
    {
        return _2tuple.combine(_2tuple.combine(a, b), c);
    } //return (ulong)

    public static ulong combine(ushort a, sbyte b, byte c)
    {
        return _2tuple.combine(_2tuple.combine(a, b), c);
    } //return (ulong) 

    public static ulong combine(ushort a, sbyte b, short c)
    {
        return _2tuple.combine(_2tuple.combine(a, b), c);
    } //return (ulong) 

    public static ulong combine(ushort a, sbyte b, ushort c)
    {
        return _2tuple.combine(_2tuple.combine(a, b), c);
    } //return (ulong) 

    //---2nd byte

    public static ulong combine(ushort a, byte b, sbyte c)
    {
        return _2tuple.combine(_2tuple.combine(a, b), c);
    } //return (ulong)

    public static ulong combine(ushort a, byte b, byte c)
    {
        return _2tuple.combine(_2tuple.combine(a, b), c);
    } //return (ulong)

    public static ulong combine(ushort a, byte b, short c)
    {
        return _2tuple.combine(_2tuple.combine(a, b), c);
    } //return (ulong)

    public static ulong combine(ushort a, byte b, ushort c)
    {
        return _2tuple.combine(_2tuple.combine(a, b), c);
    } //return (ulong)

    //---2nd short

    public static ulong combine(ushort a, short b, sbyte c)
    {
        return _2tuple.combine(_2tuple.combine(a, b), c);
    } //return (ulong)

    public static ulong combine(ushort a, short b, byte c)
    {
        return _2tuple.combine(_2tuple.combine(a, b), c);
    } //return (ulong)

    public static ulong combine(ushort a, short b, short c)
    {
        return _2tuple.combine(_2tuple.combine(a, b), c);
    } //return (ulong)

    public static ulong combine(ushort a, short b, ushort c)
    {
        return _2tuple.combine(_2tuple.combine(a, b), c);
    } //return (ulong)

    //---2nd ushort

    public static ulong combine(ushort a, ushort b, sbyte c)
    {
        return _2tuple.combine(_2tuple.combine(a, b), c);
    } //return (ulong)

    public static ulong combine(ushort a, ushort b, byte c)
    {
        return _2tuple.combine(_2tuple.combine(a, b), c);
    } //return (ulong)

    public static ulong combine(ushort a, ushort b, short c)
    {
        return _2tuple.combine(_2tuple.combine(a, b), c);
    } //return (ulong)

    public static ulong combine(ushort a, ushort b, ushort c)
    {
        return _2tuple.combine(_2tuple.combine(a, b), c);
    } //return (ulong)

    #endregion

    #endregion

    #region Reverse

    //[(a,b) , c]
    public static byte[] reverse(uint z) //3 bytes... rounds to 4 bytes = 2 ushorts = 1 uint
    {
        ushort[] ABc = _2tuple.reverse(z);
        byte[] ab = _2tuple.reverse(ABc[0]);
        return new byte[] {ab[0], ab[1], (byte) ABc[1]};
    }

    //[(a,b) , c]
    public static ushort[] reverse(ulong z) //2 ushorts... round to 4 ushorts = 2 uints = 1 ulong
    {
        uint[] ABc = _2tuple.reverse(z);
        ushort[] ab = _2tuple.reverse(ABc[0]);
        return new ushort[] {ab[0], ab[1], (ushort) ABc[1]};
    }

    #endregion
}