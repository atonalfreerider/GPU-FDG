/// <summary>
/// Description: public functions for 7 tuple pairing
/// Programmer: Bryan Cancel
/// Combine Sequence [(a,b,c,d) , (e,f,g)] -> z
/// 
/// note: currently using 2tuple pairing multiple times
/// could simplify by using 2tupe(4tuple(a,b,c,d), 3tuple(e,f,g))
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
 *      (byte,byte) -> [ushort] -> (AB)
 *      (byte,byte) -> [ushort] -> (CD)
 *      ([ushort],[ushort]) -> [uint] -> [(AB),(CD)]
 *      (byte,byte) -> [ushort] (EF)
 *      ([ushort],ushort) -> [uint] [(EF),(G)]
 *      ([uint],[uint]) -> [ulong] ([(AB),(CD)],[(EF),(G)])
 * 
 * -------------------------using SHORTS-------------------------STOP(I dont want to use BigInteger)-------------------------
 * short	-32,768 to 32,767	Signed 16-bit integer
 * ushort	0 to 65,535	Unsigned 16-bit integer
 * COMBOS: (65,53_6)^2 = 4,294,967,296 [exactly what uint can store]
 * 
 * using SZUDZIK:
 *      (ushort,ushort) -> [uint] -> (AB)
 *      (ushort,ushort) -> [uint] -> (CD)
 *      ([uint],[uint]) -> [ulong] -> [(AB),(CD)]
 *      (ushort,ushort) -> [uint] -> (EF)
 *      ([uint],uint) -> [ulong] -> [(EF),(G)]
 *      ([ulong],[ulong]) -> [BigInteger] -> ([(AB),(CD)],[(EF),(G)])          
 * 
 * -------------------------using INTS
 * int	    -2,147,483,648 to 2,147,483,647	Signed 32-bit integer
 * uint	    0 to 4,294,967,295	Unsigned 32-bit integer
 * COMBOS: (4,294,967,29_6)^2 = 18,446,744,073,709,551,616 [exactly what ulong can store]
 * 
 * using SZUDZIK:
 *      (uint,uint) -> [ulong] (AB)
 *      (uint,uint) -> [ulong] (CD)
 *      ([ulong],[ulong]) -> [BigInteger] [(AB),(CD)]
 *      (uint,uint) -> [ulong] (EF)
 *      ([ulong],ulong) -> [BigInteger] [(EF),(G)]
 *      ([BigInteger],[BigInteger]) -> [BigInteger] ([(AB),(CD)],[(EF),(G)])          
 * 
 * -------------------------using LONGS
 * long	    -9,223,372,036,854,775,808 to 9,223,372,036,854,775,807	Signed 64-bit integer
 * ulong	0 to 18,446,744,073,709,551,615	Unsigned 64-bit integer
 * COMBOS: (18,446,744,073,709,551,61_6)^2 = 340,282,366,920,938,463,463,374,607,431,768,211,456 [perhaps using Big Integer]
 * 
 * using SZUDZIK:
 *      (ulong,ulong) -> [BigInteger] (AB)
 *      (ulong,ulong) -> [BigInteger] (CD)
 *      ([BigInteger],[BigInteger]) -> [BigInteger] [(AB),(CD)]
 *      (ulong,ulong) -> [BigInteger] (EF)
 *      ([BigInteger],BigInteger) -> [BigInteger] [(EF),(G)]
 *      ([BigInteger],[BigInteger]) -> [BigInteger] ([(AB),(CD)],[(EF),(G)])           
 */
public static class _7tuple //1 type range [(byte/sbyte)]
{
    #region Combine

    //(sbyte/byte) [2]
    //[2]^7 = 128 possible combos [sets of 64]

    #region byte

    #region byte byte

    #region byte byte byte [16]

    #region byte byte byte byte [8]

    #region byte byte byte byte byte [4]

    #region byte byte byte byte byte byte [2]

    //last byte 
    public static ulong combine(byte a, byte b, byte c, byte d, byte e, byte f, byte g)
    {
        return _2tuple.combine(_4tuple.combine(a, b, c, d), _3tuple.combine(e, f, g));
    }

    //last sbyte
    public static ulong combine(byte a, byte b, byte c, byte d, byte e, byte f, sbyte g)
    {
        return _2tuple.combine(_4tuple.combine(a, b, c, d), _3tuple.combine(e, f, g));
    }

    #endregion

    #region byte byte byte byte byte sbyte [2]

    //last byte
    public static ulong combine(byte a, byte b, byte c, byte d, byte e, sbyte f, byte g)
    {
        return _2tuple.combine(_4tuple.combine(a, b, c, d), _3tuple.combine(e, f, g));
    }

    //last sbyte
    public static ulong combine(byte a, byte b, byte c, byte d, byte e, sbyte f, sbyte g)
    {
        return _2tuple.combine(_4tuple.combine(a, b, c, d), _3tuple.combine(e, f, g));
    }

    #endregion

    #endregion

    #region byte byte byte byte sbyte [4]

    #region byte byte byte byte sbyte byte [2]

    //last byte
    public static ulong combine(byte a, byte b, byte c, byte d, sbyte e, byte f, byte g)
    {
        return _2tuple.combine(_4tuple.combine(a, b, c, d), _3tuple.combine(e, f, g));
    }

    //last sbyte
    public static ulong combine(byte a, byte b, byte c, byte d, sbyte e, byte f, sbyte g)
    {
        return _2tuple.combine(_4tuple.combine(a, b, c, d), _3tuple.combine(e, f, g));
    }

    #endregion

    #region byte byte byte byte sbyte sbyte [2]

    //last byte
    public static ulong combine(byte a, byte b, byte c, byte d, sbyte e, sbyte f, byte g)
    {
        return _2tuple.combine(_4tuple.combine(a, b, c, d), _3tuple.combine(e, f, g));
    }

    //last sbyte
    public static ulong combine(byte a, byte b, byte c, byte d, sbyte e, sbyte f, sbyte g)
    {
        return _2tuple.combine(_4tuple.combine(a, b, c, d), _3tuple.combine(e, f, g));
    }

    #endregion

    #endregion

    #endregion

    #region byte byte byte sbyte [8]

    #region byte byte byte sbyte byte [4]

    #region byte byte byte sbyte byte byte [2]

    //last byte
    public static ulong combine(byte a, byte b, byte c, sbyte d, byte e, byte f, byte g)
    {
        return _2tuple.combine(_4tuple.combine(a, b, c, d), _3tuple.combine(e, f, g));
    }

    //last sbyte
    public static ulong combine(byte a, byte b, byte c, sbyte d, byte e, byte f, sbyte g)
    {
        return _2tuple.combine(_4tuple.combine(a, b, c, d), _3tuple.combine(e, f, g));
    }

    #endregion

    #region byte byte byte sbyte byte sbyte [2]

    //last byte
    public static ulong combine(byte a, byte b, byte c, sbyte d, byte e, sbyte f, byte g)
    {
        return _2tuple.combine(_4tuple.combine(a, b, c, d), _3tuple.combine(e, f, g));
    }

    //last sbyte
    public static ulong combine(byte a, byte b, byte c, sbyte d, byte e, sbyte f, sbyte g)
    {
        return _2tuple.combine(_4tuple.combine(a, b, c, d), _3tuple.combine(e, f, g));
    }

    #endregion

    #endregion

    #region byte byte byte sbyte sbyte [4]

    #region byte byte byte sbyte sbyte byte [2]

    //last byte
    public static ulong combine(byte a, byte b, byte c, sbyte d, sbyte e, byte f, byte g)
    {
        return _2tuple.combine(_4tuple.combine(a, b, c, d), _3tuple.combine(e, f, g));
    }

    //last sbyte
    public static ulong combine(byte a, byte b, byte c, sbyte d, sbyte e, byte f, sbyte g)
    {
        return _2tuple.combine(_4tuple.combine(a, b, c, d), _3tuple.combine(e, f, g));
    }

    #endregion

    #region byte byte byte sbyte sbyte sbyte [2]

    //last byte
    public static ulong combine(byte a, byte b, byte c, sbyte d, sbyte e, sbyte f, byte g)
    {
        return _2tuple.combine(_4tuple.combine(a, b, c, d), _3tuple.combine(e, f, g));
    }

    //last sbyte
    public static ulong combine(byte a, byte b, byte c, sbyte d, sbyte e, sbyte f, sbyte g)
    {
        return _2tuple.combine(_4tuple.combine(a, b, c, d), _3tuple.combine(e, f, g));
    }

    #endregion

    #endregion

    #endregion

    #endregion

    #region byte byte sbyte [16]

    #region byte byte sbyte byte [8]

    #region byte byte sbyte byte byte [4]

    #region byte byte sbyte byte byte byte [2]

    //last byte
    public static ulong combine(byte a, byte b, sbyte c, byte d, byte e, byte f, byte g)
    {
        return _2tuple.combine(_4tuple.combine(a, b, c, d), _3tuple.combine(e, f, g));
    }

    //last sbyte
    public static ulong combine(byte a, byte b, sbyte c, byte d, byte e, byte f, sbyte g)
    {
        return _2tuple.combine(_4tuple.combine(a, b, c, d), _3tuple.combine(e, f, g));
    }

    #endregion

    #region byte byte sbyte byte byte sbyte [2]

    //last byte
    public static ulong combine(byte a, byte b, sbyte c, byte d, byte e, sbyte f, byte g)
    {
        return _2tuple.combine(_4tuple.combine(a, b, c, d), _3tuple.combine(e, f, g));
    }

    //last sbyte
    public static ulong combine(byte a, byte b, sbyte c, byte d, byte e, sbyte f, sbyte g)
    {
        return _2tuple.combine(_4tuple.combine(a, b, c, d), _3tuple.combine(e, f, g));
    }

    #endregion

    #endregion

    #region byte byte sbyte byte sbyte [4]

    #region byte byte sbyte byte sbyte byte [2]

    //last byte
    public static ulong combine(byte a, byte b, sbyte c, byte d, sbyte e, byte f, byte g)
    {
        return _2tuple.combine(_4tuple.combine(a, b, c, d), _3tuple.combine(e, f, g));
    }

    //last sbyte
    public static ulong combine(byte a, byte b, sbyte c, byte d, sbyte e, byte f, sbyte g)
    {
        return _2tuple.combine(_4tuple.combine(a, b, c, d), _3tuple.combine(e, f, g));
    }

    #endregion

    #region byte byte sbyte byte sbyte sbyte [2]

    //last byte
    public static ulong combine(byte a, byte b, sbyte c, byte d, sbyte e, sbyte f, byte g)
    {
        return _2tuple.combine(_4tuple.combine(a, b, c, d), _3tuple.combine(e, f, g));
    }

    //last sbyte
    public static ulong combine(byte a, byte b, sbyte c, byte d, sbyte e, sbyte f, sbyte g)
    {
        return _2tuple.combine(_4tuple.combine(a, b, c, d), _3tuple.combine(e, f, g));
    }

    #endregion

    #endregion

    #endregion

    #region byte byte sbyte sbyte [8]

    #region byte byte sbyte sbyte byte [4]

    #region byte byte sbyte sbyte byte byte [2]

    //last byte
    public static ulong combine(byte a, byte b, sbyte c, sbyte d, byte e, byte f, byte g)
    {
        return _2tuple.combine(_4tuple.combine(a, b, c, d), _3tuple.combine(e, f, g));
    }

    //last sbyte
    public static ulong combine(byte a, byte b, sbyte c, sbyte d, byte e, byte f, sbyte g)
    {
        return _2tuple.combine(_4tuple.combine(a, b, c, d), _3tuple.combine(e, f, g));
    }

    #endregion

    #region byte byte sbyte sbyte byte sbyte [2]

    //last byte
    public static ulong combine(byte a, byte b, sbyte c, sbyte d, byte e, sbyte f, byte g)
    {
        return _2tuple.combine(_4tuple.combine(a, b, c, d), _3tuple.combine(e, f, g));
    }

    //last sbyte
    public static ulong combine(byte a, byte b, sbyte c, sbyte d, byte e, sbyte f, sbyte g)
    {
        return _2tuple.combine(_4tuple.combine(a, b, c, d), _3tuple.combine(e, f, g));
    }

    #endregion

    #endregion

    #region byte byte sbyte sbyte sbyte [4]

    #region byte byte sbyte sbyte sbyte byte [2]

    //last byte
    public static ulong combine(byte a, byte b, sbyte c, sbyte d, sbyte e, byte f, byte g)
    {
        return _2tuple.combine(_4tuple.combine(a, b, c, d), _3tuple.combine(e, f, g));
    }

    //last sbyte
    public static ulong combine(byte a, byte b, sbyte c, sbyte d, sbyte e, byte f, sbyte g)
    {
        return _2tuple.combine(_4tuple.combine(a, b, c, d), _3tuple.combine(e, f, g));
    }

    #endregion

    #region byte byte sbyte sbyte sbyte sbyte [2]

    //last byte
    public static ulong combine(byte a, byte b, sbyte c, sbyte d, sbyte e, sbyte f, byte g)
    {
        return _2tuple.combine(_4tuple.combine(a, b, c, d), _3tuple.combine(e, f, g));
    }

    //last sbyte
    public static ulong combine(byte a, byte b, sbyte c, sbyte d, sbyte e, sbyte f, sbyte g)
    {
        return _2tuple.combine(_4tuple.combine(a, b, c, d), _3tuple.combine(e, f, g));
    }

    #endregion

    #endregion

    #endregion

    #endregion

    #endregion

    #region byte sbyte

    #region byte sbyte byte [16]

    #region byte sbyte byte byte [8]

    #region byte sbyte byte byte byte [4]

    #region byte sbyte byte byte byte byte [2]

    //last byte
    public static ulong combine(byte a, sbyte b, byte c, byte d, byte e, byte f, byte g)
    {
        return _2tuple.combine(_4tuple.combine(a, b, c, d), _3tuple.combine(e, f, g));
    }

    //last sbyte
    public static ulong combine(byte a, sbyte b, byte c, byte d, byte e, byte f, sbyte g)
    {
        return _2tuple.combine(_4tuple.combine(a, b, c, d), _3tuple.combine(e, f, g));
    }

    #endregion

    #region byte sbyte byte byte byte sbyte [2]

    //last byte
    public static ulong combine(byte a, sbyte b, byte c, byte d, byte e, sbyte f, byte g)
    {
        return _2tuple.combine(_4tuple.combine(a, b, c, d), _3tuple.combine(e, f, g));
    }

    //last sbyte
    public static ulong combine(byte a, sbyte b, byte c, byte d, byte e, sbyte f, sbyte g)
    {
        return _2tuple.combine(_4tuple.combine(a, b, c, d), _3tuple.combine(e, f, g));
    }

    #endregion

    #endregion

    #region byte sbyte byte byte sbyte [4]

    #region byte sbyte byte byte sbyte byte [2]

    //last byte
    public static ulong combine(byte a, sbyte b, byte c, byte d, sbyte e, byte f, byte g)
    {
        return _2tuple.combine(_4tuple.combine(a, b, c, d), _3tuple.combine(e, f, g));
    }

    //last sbyte
    public static ulong combine(byte a, sbyte b, byte c, byte d, sbyte e, byte f, sbyte g)
    {
        return _2tuple.combine(_4tuple.combine(a, b, c, d), _3tuple.combine(e, f, g));
    }

    #endregion

    #region byte sbyte byte byte sbyte sbyte [2]

    //last byte
    public static ulong combine(byte a, sbyte b, byte c, byte d, sbyte e, sbyte f, byte g)
    {
        return _2tuple.combine(_4tuple.combine(a, b, c, d), _3tuple.combine(e, f, g));
    }

    //last sbyte
    public static ulong combine(byte a, sbyte b, byte c, byte d, sbyte e, sbyte f, sbyte g)
    {
        return _2tuple.combine(_4tuple.combine(a, b, c, d), _3tuple.combine(e, f, g));
    }

    #endregion

    #endregion

    #endregion

    #region byte sbyte byte sbyte [8]

    #region byte sbyte byte sbyte byte [4]

    #region byte sbyte byte sbyte byte byte [2]

    //last byte
    public static ulong combine(byte a, sbyte b, byte c, sbyte d, byte e, byte f, byte g)
    {
        return _2tuple.combine(_4tuple.combine(a, b, c, d), _3tuple.combine(e, f, g));
    }

    //last sbyte
    public static ulong combine(byte a, sbyte b, byte c, sbyte d, byte e, byte f, sbyte g)
    {
        return _2tuple.combine(_4tuple.combine(a, b, c, d), _3tuple.combine(e, f, g));
    }

    #endregion

    #region byte sbyte byte sbyte byte sbyte [2]

    //last byte
    public static ulong combine(byte a, sbyte b, byte c, sbyte d, byte e, sbyte f, byte g)
    {
        return _2tuple.combine(_4tuple.combine(a, b, c, d), _3tuple.combine(e, f, g));
    }

    //last sbyte
    public static ulong combine(byte a, sbyte b, byte c, sbyte d, byte e, sbyte f, sbyte g)
    {
        return _2tuple.combine(_4tuple.combine(a, b, c, d), _3tuple.combine(e, f, g));
    }

    #endregion

    #endregion

    #region byte sbyte byte sbyte sbyte [4]

    #region byte sbyte byte sbyte sbyte byte [2]

    //last byte
    public static ulong combine(byte a, sbyte b, byte c, sbyte d, sbyte e, byte f, byte g)
    {
        return _2tuple.combine(_4tuple.combine(a, b, c, d), _3tuple.combine(e, f, g));
    }

    //last sbyte
    public static ulong combine(byte a, sbyte b, byte c, sbyte d, sbyte e, byte f, sbyte g)
    {
        return _2tuple.combine(_4tuple.combine(a, b, c, d), _3tuple.combine(e, f, g));
    }

    #endregion

    #region byte sbyte byte sbyte sbyte sbyte [2]

    //last byte
    public static ulong combine(byte a, sbyte b, byte c, sbyte d, sbyte e, sbyte f, byte g)
    {
        return _2tuple.combine(_4tuple.combine(a, b, c, d), _3tuple.combine(e, f, g));
    }

    //last sbyte
    public static ulong combine(byte a, sbyte b, byte c, sbyte d, sbyte e, sbyte f, sbyte g)
    {
        return _2tuple.combine(_4tuple.combine(a, b, c, d), _3tuple.combine(e, f, g));
    }

    #endregion

    #endregion

    #endregion

    #endregion

    #region byte sbyte sbyte [16]

    #region byte sbyte sbyte byte [8]

    #region byte sbyte sbyte byte byte [4]

    #region byte sbyte sbyte byte byte byte [2]

    //last byte
    public static ulong combine(byte a, sbyte b, sbyte c, byte d, byte e, byte f, byte g)
    {
        return _2tuple.combine(_4tuple.combine(a, b, c, d), _3tuple.combine(e, f, g));
    }

    //last sbyte
    public static ulong combine(byte a, sbyte b, sbyte c, byte d, byte e, byte f, sbyte g)
    {
        return _2tuple.combine(_4tuple.combine(a, b, c, d), _3tuple.combine(e, f, g));
    }

    #endregion

    #region byte sbyte sbyte byte byte sbyte [2]

    //last byte
    public static ulong combine(byte a, sbyte b, sbyte c, byte d, byte e, sbyte f, byte g)
    {
        return _2tuple.combine(_4tuple.combine(a, b, c, d), _3tuple.combine(e, f, g));
    }

    //last sbyte
    public static ulong combine(byte a, sbyte b, sbyte c, byte d, byte e, sbyte f, sbyte g)
    {
        return _2tuple.combine(_4tuple.combine(a, b, c, d), _3tuple.combine(e, f, g));
    }

    #endregion

    #endregion

    #region byte sbyte sbyte byte sbyte [4]

    #region byte sbyte sbyte byte sbyte byte [2]

    //last byte
    public static ulong combine(byte a, sbyte b, sbyte c, byte d, sbyte e, byte f, byte g)
    {
        return _2tuple.combine(_4tuple.combine(a, b, c, d), _3tuple.combine(e, f, g));
    }

    //last sbyte
    public static ulong combine(byte a, sbyte b, sbyte c, byte d, sbyte e, byte f, sbyte g)
    {
        return _2tuple.combine(_4tuple.combine(a, b, c, d), _3tuple.combine(e, f, g));
    }

    #endregion

    #region byte sbyte sbyte byte sbyte sbyte [2]

    //last byte
    public static ulong combine(byte a, sbyte b, sbyte c, byte d, sbyte e, sbyte f, byte g)
    {
        return _2tuple.combine(_4tuple.combine(a, b, c, d), _3tuple.combine(e, f, g));
    }

    //last sbyte
    public static ulong combine(byte a, sbyte b, sbyte c, byte d, sbyte e, sbyte f, sbyte g)
    {
        return _2tuple.combine(_4tuple.combine(a, b, c, d), _3tuple.combine(e, f, g));
    }

    #endregion

    #endregion

    #endregion

    #region byte sbyte sbyte sbyte [8]

    #region byte sbyte sbyte sbyte byte [4]

    #region byte sbyte sbyte sbyte byte byte [2]

    //last byte
    public static ulong combine(byte a, sbyte b, sbyte c, sbyte d, byte e, byte f, byte g)
    {
        return _2tuple.combine(_4tuple.combine(a, b, c, d), _3tuple.combine(e, f, g));
    }

    //last sbyte
    public static ulong combine(byte a, sbyte b, sbyte c, sbyte d, byte e, byte f, sbyte g)
    {
        return _2tuple.combine(_4tuple.combine(a, b, c, d), _3tuple.combine(e, f, g));
    }

    #endregion

    #region byte sbyte sbyte sbyte byte sbyte [2]

    //last byte
    public static ulong combine(byte a, sbyte b, sbyte c, sbyte d, byte e, sbyte f, byte g)
    {
        return _2tuple.combine(_4tuple.combine(a, b, c, d), _3tuple.combine(e, f, g));
    }

    //last sbyte
    public static ulong combine(byte a, sbyte b, sbyte c, sbyte d, byte e, sbyte f, sbyte g)
    {
        return _2tuple.combine(_4tuple.combine(a, b, c, d), _3tuple.combine(e, f, g));
    }

    #endregion

    #endregion

    #region byte sbyte sbyte sbyte sbyte [4]

    #region byte sbyte sbyte sbyte sbyte byte [2]

    //last byte
    public static ulong combine(byte a, sbyte b, sbyte c, sbyte d, sbyte e, byte f, byte g)
    {
        return _2tuple.combine(_4tuple.combine(a, b, c, d), _3tuple.combine(e, f, g));
    }

    //last sbyte
    public static ulong combine(byte a, sbyte b, sbyte c, sbyte d, sbyte e, byte f, sbyte g)
    {
        return _2tuple.combine(_4tuple.combine(a, b, c, d), _3tuple.combine(e, f, g));
    }

    #endregion

    #region byte sbyte sbyte sbyte sbyte sbyte [2]

    //last byte
    public static ulong combine(byte a, sbyte b, sbyte c, sbyte d, sbyte e, sbyte f, byte g)
    {
        return _2tuple.combine(_4tuple.combine(a, b, c, d), _3tuple.combine(e, f, g));
    }

    //last sbyte
    public static ulong combine(byte a, sbyte b, sbyte c, sbyte d, sbyte e, sbyte f, sbyte g)
    {
        return _2tuple.combine(_4tuple.combine(a, b, c, d), _3tuple.combine(e, f, g));
    }

    #endregion

    #endregion

    #endregion

    #endregion

    #endregion

    #endregion

    #region sbyte

    #region sbyte byte

    #region sbyte byte byte [16]

    #region sbyte byte byte byte [8]

    #region sbyte byte byte byte byte [4]

    #region sbyte byte byte byte byte byte [2]

    //last byte 
    public static ulong combine(sbyte a, byte b, byte c, byte d, byte e, byte f, byte g)
    {
        return _2tuple.combine(_4tuple.combine(a, b, c, d), _3tuple.combine(e, f, g));
    }

    //last sbyte
    public static ulong combine(sbyte a, byte b, byte c, byte d, byte e, byte f, sbyte g)
    {
        return _2tuple.combine(_4tuple.combine(a, b, c, d), _3tuple.combine(e, f, g));
    }

    #endregion

    #region sbyte byte byte byte byte sbyte [2]

    //last byte
    public static ulong combine(sbyte a, byte b, byte c, byte d, byte e, sbyte f, byte g)
    {
        return _2tuple.combine(_4tuple.combine(a, b, c, d), _3tuple.combine(e, f, g));
    }

    //last sbyte
    public static ulong combine(sbyte a, byte b, byte c, byte d, byte e, sbyte f, sbyte g)
    {
        return _2tuple.combine(_4tuple.combine(a, b, c, d), _3tuple.combine(e, f, g));
    }

    #endregion

    #endregion

    #region sbyte byte byte byte sbyte [4]

    #region sbyte byte byte byte sbyte byte [2]

    //last byte
    public static ulong combine(sbyte a, byte b, byte c, byte d, sbyte e, byte f, byte g)
    {
        return _2tuple.combine(_4tuple.combine(a, b, c, d), _3tuple.combine(e, f, g));
    }

    //last sbyte
    public static ulong combine(sbyte a, byte b, byte c, byte d, sbyte e, byte f, sbyte g)
    {
        return _2tuple.combine(_4tuple.combine(a, b, c, d), _3tuple.combine(e, f, g));
    }

    #endregion

    #region sbyte byte byte byte sbyte sbyte [2]

    //last byte
    public static ulong combine(sbyte a, byte b, byte c, byte d, sbyte e, sbyte f, byte g)
    {
        return _2tuple.combine(_4tuple.combine(a, b, c, d), _3tuple.combine(e, f, g));
    }

    //last sbyte
    public static ulong combine(sbyte a, byte b, byte c, byte d, sbyte e, sbyte f, sbyte g)
    {
        return _2tuple.combine(_4tuple.combine(a, b, c, d), _3tuple.combine(e, f, g));
    }

    #endregion

    #endregion

    #endregion

    #region sbyte byte byte sbyte [8]

    #region sbyte byte byte sbyte byte [4]

    #region sbyte byte byte sbyte byte byte [2]

    //last byte
    public static ulong combine(sbyte a, byte b, byte c, sbyte d, byte e, byte f, byte g)
    {
        return _2tuple.combine(_4tuple.combine(a, b, c, d), _3tuple.combine(e, f, g));
    }

    //last sbyte
    public static ulong combine(sbyte a, byte b, byte c, sbyte d, byte e, byte f, sbyte g)
    {
        return _2tuple.combine(_4tuple.combine(a, b, c, d), _3tuple.combine(e, f, g));
    }

    #endregion

    #region sbyte byte byte sbyte byte sbyte [2]

    //last byte
    public static ulong combine(sbyte a, byte b, byte c, sbyte d, byte e, sbyte f, byte g)
    {
        return _2tuple.combine(_4tuple.combine(a, b, c, d), _3tuple.combine(e, f, g));
    }

    //last sbyte
    public static ulong combine(sbyte a, byte b, byte c, sbyte d, byte e, sbyte f, sbyte g)
    {
        return _2tuple.combine(_4tuple.combine(a, b, c, d), _3tuple.combine(e, f, g));
    }

    #endregion

    #endregion

    #region sbyte byte byte sbyte sbyte [4]

    #region sbyte byte byte sbyte sbyte byte [2]

    //last byte
    public static ulong combine(sbyte a, byte b, byte c, sbyte d, sbyte e, byte f, byte g)
    {
        return _2tuple.combine(_4tuple.combine(a, b, c, d), _3tuple.combine(e, f, g));
    }

    //last sbyte
    public static ulong combine(sbyte a, byte b, byte c, sbyte d, sbyte e, byte f, sbyte g)
    {
        return _2tuple.combine(_4tuple.combine(a, b, c, d), _3tuple.combine(e, f, g));
    }

    #endregion

    #region sbyte byte byte sbyte sbyte sbyte [2]

    //last byte
    public static ulong combine(sbyte a, byte b, byte c, sbyte d, sbyte e, sbyte f, byte g)
    {
        return _2tuple.combine(_4tuple.combine(a, b, c, d), _3tuple.combine(e, f, g));
    }

    //last sbyte
    public static ulong combine(sbyte a, byte b, byte c, sbyte d, sbyte e, sbyte f, sbyte g)
    {
        return _2tuple.combine(_4tuple.combine(a, b, c, d), _3tuple.combine(e, f, g));
    }

    #endregion

    #endregion

    #endregion

    #endregion

    #region sbyte byte sbyte [16]

    #region sbyte byte sbyte byte [8]

    #region sbyte byte sbyte byte byte [4]

    #region sbyte byte sbyte byte byte byte [2]

    //last byte
    public static ulong combine(sbyte a, byte b, sbyte c, byte d, byte e, byte f, byte g)
    {
        return _2tuple.combine(_4tuple.combine(a, b, c, d), _3tuple.combine(e, f, g));
    }

    //last sbyte
    public static ulong combine(sbyte a, byte b, sbyte c, byte d, byte e, byte f, sbyte g)
    {
        return _2tuple.combine(_4tuple.combine(a, b, c, d), _3tuple.combine(e, f, g));
    }

    #endregion

    #region sbyte byte sbyte byte byte sbyte [2]

    //last byte
    public static ulong combine(sbyte a, byte b, sbyte c, byte d, byte e, sbyte f, byte g)
    {
        return _2tuple.combine(_4tuple.combine(a, b, c, d), _3tuple.combine(e, f, g));
    }

    //last sbyte
    public static ulong combine(sbyte a, byte b, sbyte c, byte d, byte e, sbyte f, sbyte g)
    {
        return _2tuple.combine(_4tuple.combine(a, b, c, d), _3tuple.combine(e, f, g));
    }

    #endregion

    #endregion

    #region sbyte byte sbyte byte sbyte [4]

    #region sbyte byte sbyte byte sbyte byte [2]

    //last byte
    public static ulong combine(sbyte a, byte b, sbyte c, byte d, sbyte e, byte f, byte g)
    {
        return _2tuple.combine(_4tuple.combine(a, b, c, d), _3tuple.combine(e, f, g));
    }

    //last sbyte
    public static ulong combine(sbyte a, byte b, sbyte c, byte d, sbyte e, byte f, sbyte g)
    {
        return _2tuple.combine(_4tuple.combine(a, b, c, d), _3tuple.combine(e, f, g));
    }

    #endregion

    #region sbyte byte sbyte byte sbyte sbyte [2]

    //last byte
    public static ulong combine(sbyte a, byte b, sbyte c, byte d, sbyte e, sbyte f, byte g)
    {
        return _2tuple.combine(_4tuple.combine(a, b, c, d), _3tuple.combine(e, f, g));
    }

    //last sbyte
    public static ulong combine(sbyte a, byte b, sbyte c, byte d, sbyte e, sbyte f, sbyte g)
    {
        return _2tuple.combine(_4tuple.combine(a, b, c, d), _3tuple.combine(e, f, g));
    }

    #endregion

    #endregion

    #endregion

    #region sbyte byte sbyte sbyte [8]

    #region sbyte byte sbyte sbyte byte [4]

    #region sbyte byte sbyte sbyte byte byte [2]

    //last byte
    public static ulong combine(sbyte a, byte b, sbyte c, sbyte d, byte e, byte f, byte g)
    {
        return _2tuple.combine(_4tuple.combine(a, b, c, d), _3tuple.combine(e, f, g));
    }

    //last sbyte
    public static ulong combine(sbyte a, byte b, sbyte c, sbyte d, byte e, byte f, sbyte g)
    {
        return _2tuple.combine(_4tuple.combine(a, b, c, d), _3tuple.combine(e, f, g));
    }

    #endregion

    #region sbyte byte sbyte sbyte byte sbyte [2]

    //last byte
    public static ulong combine(sbyte a, byte b, sbyte c, sbyte d, byte e, sbyte f, byte g)
    {
        return _2tuple.combine(_4tuple.combine(a, b, c, d), _3tuple.combine(e, f, g));
    }

    //last sbyte
    public static ulong combine(sbyte a, byte b, sbyte c, sbyte d, byte e, sbyte f, sbyte g)
    {
        return _2tuple.combine(_4tuple.combine(a, b, c, d), _3tuple.combine(e, f, g));
    }

    #endregion

    #endregion

    #region sbyte byte sbyte sbyte sbyte [4]

    #region sbyte byte sbyte sbyte sbyte byte [2]

    //last byte
    public static ulong combine(sbyte a, byte b, sbyte c, sbyte d, sbyte e, byte f, byte g)
    {
        return _2tuple.combine(_4tuple.combine(a, b, c, d), _3tuple.combine(e, f, g));
    }

    //last sbyte
    public static ulong combine(sbyte a, byte b, sbyte c, sbyte d, sbyte e, byte f, sbyte g)
    {
        return _2tuple.combine(_4tuple.combine(a, b, c, d), _3tuple.combine(e, f, g));
    }

    #endregion

    #region sbyte byte sbyte sbyte sbyte sbyte [2]

    //last byte
    public static ulong combine(sbyte a, byte b, sbyte c, sbyte d, sbyte e, sbyte f, byte g)
    {
        return _2tuple.combine(_4tuple.combine(a, b, c, d), _3tuple.combine(e, f, g));
    }

    //last sbyte
    public static ulong combine(sbyte a, byte b, sbyte c, sbyte d, sbyte e, sbyte f, sbyte g)
    {
        return _2tuple.combine(_4tuple.combine(a, b, c, d), _3tuple.combine(e, f, g));
    }

    #endregion

    #endregion

    #endregion

    #endregion

    #endregion

    #region sbyte sbyte

    #region sbyte sbyte byte [16]

    #region sbyte sbyte byte byte [8]

    #region sbyte sbyte byte byte byte [4]

    #region sbyte sbyte byte byte byte byte [2]

    //last byte
    public static ulong combine(sbyte a, sbyte b, byte c, byte d, byte e, byte f, byte g)
    {
        return _2tuple.combine(_4tuple.combine(a, b, c, d), _3tuple.combine(e, f, g));
    }

    //last sbyte
    public static ulong combine(sbyte a, sbyte b, byte c, byte d, byte e, byte f, sbyte g)
    {
        return _2tuple.combine(_4tuple.combine(a, b, c, d), _3tuple.combine(e, f, g));
    }

    #endregion

    #region sbyte sbyte byte byte byte sbyte [2]

    //last byte
    public static ulong combine(sbyte a, sbyte b, byte c, byte d, byte e, sbyte f, byte g)
    {
        return _2tuple.combine(_4tuple.combine(a, b, c, d), _3tuple.combine(e, f, g));
    }

    //last sbyte
    public static ulong combine(sbyte a, sbyte b, byte c, byte d, byte e, sbyte f, sbyte g)
    {
        return _2tuple.combine(_4tuple.combine(a, b, c, d), _3tuple.combine(e, f, g));
    }

    #endregion

    #endregion

    #region sbyte sbyte byte byte sbyte [4]

    #region sbyte sbyte byte byte sbyte byte [2]

    //last byte
    public static ulong combine(sbyte a, sbyte b, byte c, byte d, sbyte e, byte f, byte g)
    {
        return _2tuple.combine(_4tuple.combine(a, b, c, d), _3tuple.combine(e, f, g));
    }

    //last sbyte
    public static ulong combine(sbyte a, sbyte b, byte c, byte d, sbyte e, byte f, sbyte g)
    {
        return _2tuple.combine(_4tuple.combine(a, b, c, d), _3tuple.combine(e, f, g));
    }

    #endregion

    #region sbyte sbyte byte byte sbyte sbyte [2]

    //last byte
    public static ulong combine(sbyte a, sbyte b, byte c, byte d, sbyte e, sbyte f, byte g)
    {
        return _2tuple.combine(_4tuple.combine(a, b, c, d), _3tuple.combine(e, f, g));
    }

    //last sbyte
    public static ulong combine(sbyte a, sbyte b, byte c, byte d, sbyte e, sbyte f, sbyte g)
    {
        return _2tuple.combine(_4tuple.combine(a, b, c, d), _3tuple.combine(e, f, g));
    }

    #endregion

    #endregion

    #endregion

    #region sbyte sbyte byte sbyte [8]

    #region sbyte sbyte byte sbyte byte [4]

    #region sbyte sbyte byte sbyte byte byte [2]

    //last byte
    public static ulong combine(sbyte a, sbyte b, byte c, sbyte d, byte e, byte f, byte g)
    {
        return _2tuple.combine(_4tuple.combine(a, b, c, d), _3tuple.combine(e, f, g));
    }

    //last sbyte
    public static ulong combine(sbyte a, sbyte b, byte c, sbyte d, byte e, byte f, sbyte g)
    {
        return _2tuple.combine(_4tuple.combine(a, b, c, d), _3tuple.combine(e, f, g));
    }

    #endregion

    #region sbyte sbyte byte sbyte byte sbyte [2]

    //last byte
    public static ulong combine(sbyte a, sbyte b, byte c, sbyte d, byte e, sbyte f, byte g)
    {
        return _2tuple.combine(_4tuple.combine(a, b, c, d), _3tuple.combine(e, f, g));
    }

    //last sbyte
    public static ulong combine(sbyte a, sbyte b, byte c, sbyte d, byte e, sbyte f, sbyte g)
    {
        return _2tuple.combine(_4tuple.combine(a, b, c, d), _3tuple.combine(e, f, g));
    }

    #endregion

    #endregion

    #region sbyte sbyte byte sbyte sbyte [4]

    #region sbyte sbyte byte sbyte sbyte byte [2]

    //last byte
    public static ulong combine(sbyte a, sbyte b, byte c, sbyte d, sbyte e, byte f, byte g)
    {
        return _2tuple.combine(_4tuple.combine(a, b, c, d), _3tuple.combine(e, f, g));
    }

    //last sbyte
    public static ulong combine(sbyte a, sbyte b, byte c, sbyte d, sbyte e, byte f, sbyte g)
    {
        return _2tuple.combine(_4tuple.combine(a, b, c, d), _3tuple.combine(e, f, g));
    }

    #endregion

    #region sbyte sbyte byte sbyte sbyte sbyte [2]

    //last byte
    public static ulong combine(sbyte a, sbyte b, byte c, sbyte d, sbyte e, sbyte f, byte g)
    {
        return _2tuple.combine(_4tuple.combine(a, b, c, d), _3tuple.combine(e, f, g));
    }

    //last sbyte
    public static ulong combine(sbyte a, sbyte b, byte c, sbyte d, sbyte e, sbyte f, sbyte g)
    {
        return _2tuple.combine(_4tuple.combine(a, b, c, d), _3tuple.combine(e, f, g));
    }

    #endregion

    #endregion

    #endregion

    #endregion

    #region sbyte sbyte sbyte [16]

    #region sbyte sbyte sbyte byte [8]

    #region sbyte sbyte sbyte byte byte [4]

    #region sbyte sbyte sbyte byte byte byte [2]

    //last byte
    public static ulong combine(sbyte a, sbyte b, sbyte c, byte d, byte e, byte f, byte g)
    {
        return _2tuple.combine(_4tuple.combine(a, b, c, d), _3tuple.combine(e, f, g));
    }

    //last sbyte
    public static ulong combine(sbyte a, sbyte b, sbyte c, byte d, byte e, byte f, sbyte g)
    {
        return _2tuple.combine(_4tuple.combine(a, b, c, d), _3tuple.combine(e, f, g));
    }

    #endregion

    #region sbyte sbyte sbyte byte byte sbyte [2]

    //last byte
    public static ulong combine(sbyte a, sbyte b, sbyte c, byte d, byte e, sbyte f, byte g)
    {
        return _2tuple.combine(_4tuple.combine(a, b, c, d), _3tuple.combine(e, f, g));
    }

    //last sbyte
    public static ulong combine(sbyte a, sbyte b, sbyte c, byte d, byte e, sbyte f, sbyte g)
    {
        return _2tuple.combine(_4tuple.combine(a, b, c, d), _3tuple.combine(e, f, g));
    }

    #endregion

    #endregion

    #region sbyte sbyte sbyte byte sbyte [4]

    #region sbyte sbyte sbyte byte sbyte byte [2]

    //last byte
    public static ulong combine(sbyte a, sbyte b, sbyte c, byte d, sbyte e, byte f, byte g)
    {
        return _2tuple.combine(_4tuple.combine(a, b, c, d), _3tuple.combine(e, f, g));
    }

    //last sbyte
    public static ulong combine(sbyte a, sbyte b, sbyte c, byte d, sbyte e, byte f, sbyte g)
    {
        return _2tuple.combine(_4tuple.combine(a, b, c, d), _3tuple.combine(e, f, g));
    }

    #endregion

    #region sbyte sbyte sbyte byte sbyte sbyte [2]

    //last byte
    public static ulong combine(sbyte a, sbyte b, sbyte c, byte d, sbyte e, sbyte f, byte g)
    {
        return _2tuple.combine(_4tuple.combine(a, b, c, d), _3tuple.combine(e, f, g));
    }

    //last sbyte
    public static ulong combine(sbyte a, sbyte b, sbyte c, byte d, sbyte e, sbyte f, sbyte g)
    {
        return _2tuple.combine(_4tuple.combine(a, b, c, d), _3tuple.combine(e, f, g));
    }

    #endregion

    #endregion

    #endregion

    #region sbyte sbyte sbyte sbyte [8]

    #region sbyte sbyte sbyte sbyte byte [4]

    #region sbyte sbyte sbyte sbyte byte byte [2]

    //last byte
    public static ulong combine(sbyte a, sbyte b, sbyte c, sbyte d, byte e, byte f, byte g)
    {
        return _2tuple.combine(_4tuple.combine(a, b, c, d), _3tuple.combine(e, f, g));
    }

    //last sbyte
    public static ulong combine(sbyte a, sbyte b, sbyte c, sbyte d, byte e, byte f, sbyte g)
    {
        return _2tuple.combine(_4tuple.combine(a, b, c, d), _3tuple.combine(e, f, g));
    }

    #endregion

    #region sbyte sbyte sbyte sbyte byte sbyte [2]

    //last byte
    public static ulong combine(sbyte a, sbyte b, sbyte c, sbyte d, byte e, sbyte f, byte g)
    {
        return _2tuple.combine(_4tuple.combine(a, b, c, d), _3tuple.combine(e, f, g));
    }

    //last sbyte
    public static ulong combine(sbyte a, sbyte b, sbyte c, sbyte d, byte e, sbyte f, sbyte g)
    {
        return _2tuple.combine(_4tuple.combine(a, b, c, d), _3tuple.combine(e, f, g));
    }

    #endregion

    #endregion

    #region sbyte sbyte sbyte sbyte sbyte [4]

    #region sbyte sbyte sbyte sbyte sbyte byte [2]

    //last byte
    public static ulong combine(sbyte a, sbyte b, sbyte c, sbyte d, sbyte e, byte f, byte g)
    {
        return _2tuple.combine(_4tuple.combine(a, b, c, d), _3tuple.combine(e, f, g));
    }

    //last sbyte
    public static ulong combine(sbyte a, sbyte b, sbyte c, sbyte d, sbyte e, byte f, sbyte g)
    {
        return _2tuple.combine(_4tuple.combine(a, b, c, d), _3tuple.combine(e, f, g));
    }

    #endregion

    #region sbyte sbyte sbyte sbyte sbyte sbyte [2]

    //last byte
    public static ulong combine(sbyte a, sbyte b, sbyte c, sbyte d, sbyte e, sbyte f, byte g)
    {
        return _2tuple.combine(_4tuple.combine(a, b, c, d), _3tuple.combine(e, f, g));
    }

    //last sbyte
    public static ulong combine(sbyte a, sbyte b, sbyte c, sbyte d, sbyte e, sbyte f, sbyte g)
    {
        return _2tuple.combine(_4tuple.combine(a, b, c, d), _3tuple.combine(e, f, g));
    }

    #endregion

    #endregion

    #endregion

    #endregion

    #endregion

    #endregion

    #endregion

    #region Reverse

    //[(a,b,c,d) , (e,f,g)]
    public static byte[] reverse(ulong z) //7 bytes... rounds to 8 bytes = 4 ushorts = 2 uints = 1 ulong
    {
        uint[] P1_P2 = _2tuple.reverse(z);
        byte[] abcd = _4tuple.reverse(P1_P2[0]);
        byte[] efg = _3tuple.reverse(P1_P2[1]);
        return new byte[] {abcd[0], abcd[1], abcd[2], abcd[3], efg[0], efg[1], efg[2]};
    }

    #endregion
}