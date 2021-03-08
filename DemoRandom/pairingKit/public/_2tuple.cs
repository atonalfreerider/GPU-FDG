/// <summary>
/// Description: public functions for 2 tuple pairing
/// Programmer: Bryan Cancel
/// Combine Sequence (a , b) -> z
/// </summary>
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
* -------------------------using LONGS-------------------------STOP(I dont want to use BigInteger)-------------------------
* long	    -9,223,372,036,854,775,808 to 9,223,372,036,854,775,807	Signed 64-bit integer
* ulong	0 to 18,446,744,073,709,551,615	Unsigned 64-bit integer
* COMBOS: (18,446,744,073,709,551,61_6)^2 = 340,282,366,920,938,463,463,374,607,431,768,211,456 [perhaps using Big Integer]
* 
* SZUDZIK PAIR MAX: (18,446,744,073,709,551,61_6)^2 = 340,282,366,920,938,463,463,374,607,431,768,211,456 [perhaps using Big Integer]
*/
public static class _2tuple //3 type ranges [(byte/sbyte)|(ushort/short)|(uint,int)]
{
    #region Combine

    //(sbyte/byte),(short/ushort),(int/uint) [6]
    //[6]^2 = 36 possible combos [sets of 6]

    #region starting with sbyte

    public static ushort combine(sbyte a, sbyte b)
    {
        return tupleBase.byteSzudzik2tupleCombine((byte) a, (byte) b);
    } //return (ushort)

    public static ushort combine(sbyte a, byte b)
    {
        return tupleBase.byteSzudzik2tupleCombine((byte) a, b);
    } //return (ushort)

    public static uint combine(sbyte a, short b)
    {
        return tupleBase.ushortSzudzik2tupleCombine((ushort) a, (ushort) b);
    } //return (uint)

    public static uint combine(sbyte a, ushort b)
    {
        return tupleBase.ushortSzudzik2tupleCombine((ushort) a, b);
    } //return (uint)

    public static ulong combine(sbyte a, int b)
    {
        return tupleBase.uintSzudzik2tupleCombine((uint) a, (uint) b);
    } //return (ulong)

    public static ulong combine(sbyte a, uint b)
    {
        return tupleBase.uintSzudzik2tupleCombine((uint) a, b);
    } //return (ulong)

    #endregion

    #region starting with byte

    public static ushort combine(byte a, sbyte b)
    {
        return tupleBase.byteSzudzik2tupleCombine(a, (byte) b);
    } //return (ushort)

    public static ushort combine(byte a, byte b)
    {
        return tupleBase.byteSzudzik2tupleCombine(a, b);
    } //return (ushort)

    public static uint combine(byte a, short b)
    {
        return tupleBase.ushortSzudzik2tupleCombine(a, (ushort) b);
    } //return (uint)

    public static uint combine(byte a, ushort b)
    {
        return tupleBase.ushortSzudzik2tupleCombine(a, b);
    } //return (uint)

    public static ulong combine(byte a, int b)
    {
        return tupleBase.uintSzudzik2tupleCombine(a, (uint) b);
    } //return (ulong)

    public static ulong combine(byte a, uint b)
    {
        return tupleBase.uintSzudzik2tupleCombine(a, b);
    } //return (ulong)

    #endregion

    #region starting with short

    public static uint combine(short a, sbyte b)
    {
        return tupleBase.ushortSzudzik2tupleCombine((ushort) a, (ushort) b);
    } //return (uint)

    public static uint combine(short a, byte b)
    {
        return tupleBase.ushortSzudzik2tupleCombine((ushort) a, b);
    } //return (uint)

    public static uint combine(short a, short b)
    {
        return tupleBase.ushortSzudzik2tupleCombine((ushort) a, (ushort) b);
    } //return (uint)

    public static uint combine(short a, ushort b)
    {
        return tupleBase.ushortSzudzik2tupleCombine((ushort) a, b);
    } //return (uint)

    public static ulong combine(short a, int b)
    {
        return tupleBase.uintSzudzik2tupleCombine((uint) a, (uint) b);
    } //return (ulong)

    public static ulong combine(short a, uint b)
    {
        return tupleBase.uintSzudzik2tupleCombine((uint) a, b);
    } //return (ulong)

    #endregion

    #region starting with ushort

    public static uint combine(ushort a, sbyte b)
    {
        return tupleBase.ushortSzudzik2tupleCombine(a, (ushort) b);
    } //return (uint)

    public static uint combine(ushort a, byte b)
    {
        return tupleBase.ushortSzudzik2tupleCombine(a, b);
    } //return (uint)

    public static uint combine(ushort a, short b)
    {
        return tupleBase.ushortSzudzik2tupleCombine(a, (ushort) b);
    } //return (uint)

    public static uint combine(ushort a, ushort b)
    {
        return tupleBase.ushortSzudzik2tupleCombine(a, b);
    } //return (uint)

    public static ulong combine(ushort a, int b)
    {
        return tupleBase.uintSzudzik2tupleCombine(a, (uint) b);
    } //return (ulong)

    public static ulong combine(ushort a, uint b)
    {
        return tupleBase.uintSzudzik2tupleCombine(a, b);
    } //return (ulong)

    #endregion

    #region starting with int

    public static ulong combine(int a, sbyte b)
    {
        return tupleBase.uintSzudzik2tupleCombine((uint) a, (uint) b);
    } //return (ulong)

    public static ulong combine(int a, byte b)
    {
        return tupleBase.uintSzudzik2tupleCombine((uint) a, b);
    } //return (ulong)

    public static ulong combine(int a, short b)
    {
        return tupleBase.uintSzudzik2tupleCombine((uint) a, (uint) b);
    } //return (ulong)

    public static ulong combine(int a, ushort b)
    {
        return tupleBase.uintSzudzik2tupleCombine((uint) a, b);
    } //return (ulong)

    public static ulong combine(int a, int b)
    {
        return tupleBase.uintSzudzik2tupleCombine((uint) a, (uint) b);
    } //return (ulong)

    public static ulong combine(int a, uint b)
    {
        return tupleBase.uintSzudzik2tupleCombine((uint) a, b);
    } //return (ulong)

    #endregion

    #region starting with uint

    public static ulong combine(uint a, sbyte b)
    {
        return tupleBase.uintSzudzik2tupleCombine(a, (uint) b);
    } //return (ulong)

    public static ulong combine(uint a, byte b)
    {
        return tupleBase.uintSzudzik2tupleCombine(a, b);
    } //return (ulong)

    public static ulong combine(uint a, short b)
    {
        return tupleBase.uintSzudzik2tupleCombine(a, (uint) b);
    } //return (ulong)

    public static ulong combine(uint a, ushort b)
    {
        return tupleBase.uintSzudzik2tupleCombine(a, b);
    } //return (ulong)

    public static ulong combine(uint a, int b)
    {
        return tupleBase.uintSzudzik2tupleCombine(a, (uint) b);
    } //return (ulong)

    public static ulong combine(uint a, uint b)
    {
        return tupleBase.uintSzudzik2tupleCombine(a, b);
    } //return (ulong)

    #endregion

    #endregion

    #region Reverse

    //(a , b) -> z
    public static byte[] reverse(ushort z)
    {
        return tupleBase.byteSzudzik2tupleReverse(z);
    }

    //(a , b) -> z
    public static ushort[] reverse(uint z)
    {
        return tupleBase.ushortSzudzik2tupleReverse(z);
    }

    //(a , b) -> z
    public static uint[] reverse(ulong z)
    {
        return tupleBase.uintSzudzik2tupleReverse(z);
    }

    #endregion
}