# CSharp_Cantor_and_Szudzik_Pairing
<h5>If this project helped you reduce developement time or you just want to help me continue making useful tools</h5>
<h5>Feel free to buy me a cup of coffee! :)</h5>
<a href="https://www.paypal.com/cgi-bin/webscr?cmd=_donations&business=bryan%2eo%2ecancel%40gmail%2ecom&lc=US&item_name=Cup%20Of%20Coffee&item_number=0000&no_note=0&currency_code=USD&bn=PP%2dDonationsBF%3abtn_donateCC_LG%2egif%3aNonHostedGuest">
  <img src="https://www.paypalobjects.com/en_US/i/btn/btn_donateCC_LG.gif" alt="PayPal Donate Button">
</a>
<h4> </h4>

<h2><strong>Overview</strong></h2>
<p><span style="font-weight: 400;">This kit was created so programmers could encode a </span><strong>SEQUENCE </strong><span style="font-weight: 400;">of numbers (n-tuple) into 1 by using the Szudzik Pairing function (a space saving version of the Cantor Pairing Function [explained below in "Cantor VS Szudik"]) with effective use of C# integral types.</span></p>
<p><span style="font-weight: 400;">Note that if you want to encode a </span><strong>SET </strong><span style="font-weight: 400;">of numbers you can still use this Kit but you would need to do some preliminary steps. Either you</span></p>
<ol>
<li style="font-weight: 400;"><span style="font-weight: 400;">Encode the Set as a Sequence</span></li>
<ul>
<li style="font-weight: 400;"><span style="font-weight: 400;">by sorting your numbers [O(nlogn)]</span></li>
</ul>
<li style="font-weight: 400;"><span style="font-weight: 400;">Encode every possible Sequence that can be created from this Set</span></li>
<ul>
<li style="font-weight: 400;"><span style="font-weight: 400;">by creating every possible sequence [O(2^n)]</span></li>
</ul>
</ol>
<p><span style="font-weight: 400;">Additionally, it expands the capability of both the Szudzik and Cantor Pairing function so you can</span></p>
<ol>
<li style="font-weight: 400;"><span style="font-weight: 400;">combine up to 8 numbers in a sequence into 1 (even though these 2 originally only worked to encode 2 numbers) </span></li>
<ul>
<li style="font-weight: 400;"><span style="font-weight: 400;">using repetition [explained below]</span></li>
</ul>
<li style="font-weight: 400;"><span style="font-weight: 400;">Encode Natural numbers, Integers, and Rational numbers into 1 (even though these 2 originally only worked to encode natural numbers) </span></li>
<ul>
<li style="font-weight: 400;"><span style="font-weight: 400;">using bijections between sets [explained below]</span></li>
</ul>
</ol>
<h2>&nbsp;</h2>
<h2><strong>Documentation</strong></h2>
<p><strong>Namespace: </strong></p>
<ul>
<li><strong>pairingKit </strong><span style="font-weight: 400;">(at the beginning of your script type 'using pairingKit')</span></li>
</ul>
<p><strong>Public Classes</strong></p>
<ul>
<li style="font-weight: 400;"><strong>tupleBase </strong><span style="font-weight: 400;">(holds the base code used by _2tuple)</span></li>
<li style="font-weight: 400;"><strong>_2tuple</strong><span style="font-weight: 400;"> [for 2 numbers of types (uint or int) or (ushort or short) or (byte or sbyte)]</span></li>
<li style="font-weight: 400;"><strong>_3tuple</strong><span style="font-weight: 400;"> [for 3 numbers of types (ushort or short) or (byte or sbyte)]</span></li>
<li style="font-weight: 400;"><strong>_4tuple</strong><span style="font-weight: 400;"> [for 4 numbers of types (ushort or short) or (byte or sbyte)]</span></li>
<li style="font-weight: 400;"><strong>_5tuple</strong><span style="font-weight: 400;"> [for 5 numbers of types (byte or sbyte)]</span></li>
<li style="font-weight: 400;"><strong>_6tuple</strong><span style="font-weight: 400;"> [for 6 numbers of types (byte or sbyte)]</span></li>
<li style="font-weight: 400;"><strong>_7tuple</strong><span style="font-weight: 400;"> [for 7 numbers of types (byte or sbyte)]</span></li>
<li style="font-weight: 400;"><strong>_8tuple</strong><span style="font-weight: 400;"> [for 8 numbers of types (byte or sbyte)]</span></li>
</ul>
<p><span style="font-weight: 400;">Every </span><strong>_nTuple </strong><span style="font-weight: 400;">Public Class has many different versions of 2 functions</span></p>
<ul>
<li style="font-weight: 400;"><span style="font-weight: 400;">combine(a,b,...)</span></li>
<ul>
<li style="font-weight: 400;"><span style="font-weight: 400;">combines a sequence of numbers indicated by the class into 1 number</span></li>
<li style="font-weight: 400;"><span style="font-weight: 400;">NOTE: the different versions are so that you can encode numbers of different Integral types with each other (within the limits explained below)</span></li>
</ul>
<li style="font-weight: 400;"><span style="font-weight: 400;">reverse(z)</span></li>
<ul>
<li style="font-weight: 400;"><span style="font-weight: 400;">returns the sequence of numbers indicated by the class from 1 number</span></li>
<li style="font-weight: 400;"><span style="font-weight: 400;">NOTE: the sequence returned will be an array of the same unsigned type</span></li>
<ul>
<li style="font-weight: 400;"><span style="font-weight: 400;">in some cases you will have to do some unsigned to signed conversion OR some type casting to get back your original numbers (using tupleBase)</span></li>
</ul>
</ul>
</ul>
<p><span style="font-weight: 400;">Additionally...</span></p>
<ul>
<li style="font-weight: 400;"><span style="font-weight: 400;">ALL </span><strong>(signed or unsigned)</strong><span style="font-weight: 400;"> nTuples will map to ONE </span><strong>unsigned </strong><span style="font-weight: 400;">Integral</span></li>
<li style="font-weight: 400;"><span style="font-weight: 400;">ALL </span><strong>unsigned </strong><span style="font-weight: 400;">Integrals will map to a </span><strong>unsigned </strong><span style="font-weight: 400;">nTuple of the largest size possible</span></li>
<ul>
<li style="font-weight: 400;"><span style="font-weight: 400;">so if your original mapping used either (1) signed numbers (2) different types, you will have to use casting to get back your exact numbers</span></li>
</ul>
</ul>
<h2>&nbsp;</h2>
<h2><strong>Encoding and Decoding</strong></h2>
<h3><strong>Natural Numbers, Integers, and Rational Numbers</strong></h3>
<p><span style="font-weight: 400;">The Original Cantor and Szudzik Functions only map 2 Natural Numbers to another Natural Number. (Natural Numbers in this case numbers 0,1,2,3,...) [[N]] </span><strong>(original)</strong></p>
<p><span style="font-weight: 400;">We can also Map 2 Integers to another Integer by simply converting the Integer into a Natural number given its type. So In other words if we want to convert an sbyte (with range -128 to 127) into a byte (with range 0 to 255) we simply add 128 to our sbyte and we are guaranteed to get something within byte range. (integers are numbers &hellip;,-2,-1,0,1,2,...) [[I]] </span><strong>(automatic)</strong></p>
<p><span style="font-weight: 400;">Rational Numbers are numbers that can be formed by dividing 2 Integers. Instead of mapping 2 Rational Numbers we could simply map 4 Integers into 1. [[R]] </span><strong>(using _4tuple)</strong></p>
<h2>&nbsp;</h2>
<h2><strong>KIT EXPLANATION</strong></h2>
<p><strong>Cantor VS Szudik</strong></p>
<p><span style="font-weight: 400;">The Cantor Pairing Function maps 2 Natural Numbers to a Natural Number but it wasn't specifically created to work with computers. Consequently, </span></p>
<p><span style="font-weight: 400;">mapping 2 [8 bit] numbers requires 1 [32 bit] number </span></p>
<p><span style="font-weight: 400;">even though all possible combinations of 8 bit numbers sum to 65536 combinations </span></p>
<p><span style="font-weight: 400;">which is exactly the amount of different numbers a [16 bit] number can represent.</span></p>
<p>&nbsp;</p>
<p><span style="font-weight: 400;">The Szudik Pairing Function is a modification of the Cantor Pairing function where </span></p>
<p><span style="font-weight: 400;">2 [8 bit] numbers can map to 1 [16 bit] number</span></p>
<p><span style="font-weight: 400;">2 [16 bit] numbers can map to 1 [32 bit] number</span></p>
<p><span style="font-weight: 400;">2 [32 bit] numbers can map to 1 [64 bit] number</span></p>
<p><span style="font-weight: 400;">and so on if a larger integral types existed (but I decided to not use BigInteger)</span></p>
<p><span style="font-weight: 400;">It was created to use space effectively. </span></p>
<p>&nbsp;</p>
<p><span style="font-weight: 400;">Additionally, performance testing revealed that on Average Cantor Pairing and Szudzik Pairing takes the same amount of Ticks (using the C# "Stopwatch" Class from "System.Diagnostics")</span></p>
<p><span style="font-weight: 400;">On Average </span></p>
<ul>
<li style="font-weight: 400;"><span style="font-weight: 400;">mapping 2 numbers to 1 takes 3 ticks </span></li>
<li style="font-weight: 400;"><span style="font-weight: 400;">mapping 1 number to 2 takes 30 ticks</span></li>
</ul>
<p><span style="font-weight: 400;">For that reason even though there is an implementation of Cantor Pairing in the tupleBase class we use Szudzik Pairing for all the main _</span><strong>n</strong><span style="font-weight: 400;">Tuple Public Classes.</span></p>
<p>&nbsp;</p>
<p><span style="font-weight: 400;">More on this below </span></p>
<ul>
<li style="font-weight: 400;"><a href="http://szudzik.com/ElegantPairing.pdf"><span style="font-weight: 400;">http://szudzik.com/ElegantPairing.pdf</span></a></li>
<li style="font-weight: 400;"><a href="https://stackoverflow.com/questions/919612/mapping-two-integers-to-one-in-a-unique-and-deterministic-way"><span style="font-weight: 400;">https://stackoverflow.com/questions/919612/mapping-two-integers-to-one-in-a-unique-and-deterministic-way</span></a></li>
</ul>
<p>&nbsp;</p>
<p>&nbsp;</p>
<h2><strong>Why It's Useful</strong></h2>
<p><span style="font-weight: 400;">This is useful in many scenarios but for the sake of simplicity I will explain how It is useful in a specific scenario. </span></p>
<p><strong>Scenario:</strong></p>
<ul>
<li style="font-weight: 400;"><span style="font-weight: 400;">We have a space of N^K. </span></li>
<ul>
<li style="font-weight: 400;"><span style="font-weight: 400;">Note: a 3D space of 100 by 100 by 100&hellip; would be a space of 100^3 where N=100, and K=3</span></li>
</ul>
<li style="font-weight: 400;"><span style="font-weight: 400;">Every Location is a Sequence of Integers and has a set of data assigned to it. </span></li>
<li style="font-weight: 400;"><span style="font-weight: 400;">We want to access this information given the location.</span></li>
</ul>
<p><span style="font-weight: 400;">There are multiple solutions</span></p>
<ol>
<li style="font-weight: 400;"><span style="font-weight: 400;">Use a Multi-Dimensional Array</span></li>
<li style="font-weight: 400;"><span style="font-weight: 400;">Use a nested dictionaries</span></li>
<li style="font-weight: 400;"><span style="font-weight: 400;">Use pairing functions multiple times</span></li>
<li style="font-weight: 400;"><span style="font-weight: 400;">feel free to suggest another...</span></li>
</ol>
<p><span style="font-weight: 400;">As long as (</span><strong>N is small</strong><span style="font-weight: 400;"> &amp;&amp; </span><strong>K is small)</strong><span style="font-weight: 400;"> Multi-dimensional Arrays work great because they are easy to use, and have constant access time. However when (</span><strong>N is large</strong><span style="font-weight: 400;"> || </span><strong>K is large</strong><span style="font-weight: 400;">) the amount of memory required to store this Multi-dimensional Array becomes ridiculous. </span></p>
<p><span style="font-weight: 400;">If your N and K are both something ridiculous AND everything in those N^K locations is different&hellip; the there is not much you can do&hellip; you need a ridiculous amount of memory regardless.</span></p>
<p><span style="font-weight: 400;">However, if any of those mappings are the same then why would you have a structure with duplicate data or empty data slots? That is where you would use (2) or (3).</span></p>
<p><strong>Scenario Extended:</strong></p>
<ul>
<li style="font-weight: 400;"><span style="font-weight: 400;">some quantity of your data is repeated</span></li>
</ul>
<p><span style="font-weight: 400;">Similar to Arrays, Nested Dictionaries have constant access time and are also easy to use. But they are great because even though your N and K are something ridiculous you don't need to have N^K different memory locations. You only need to have 1 copy of every piece of data that is different which is of course is a tremendous space saver. (assuming you only had ([N^K] / 2) different types of data&hellip; you only store that much data and not N^K chunks of data&hellip; where half of it is either empty or a duplicate)</span></p>
<p><span style="font-weight: 400;">However, note that I am giving you the K dimensional location that should map to a piece of data for that location but it is not a requirement to save that K dimensional location.</span></p>
<p><strong>Scenario Extended Again:</strong></p>
<ul>
<li style="font-weight: 400;"><span style="font-weight: 400;">don't store data you don't require</span></li>
</ul>
<p><span style="font-weight: 400;">Once again, similar to previous solutions, we have ease of use and constant access time but now we can store "less data" by combining the K dimensional location into 1 number when we are given a new K dimensional location and then simply get what the 1 numbers maps to by using the </span><strong>pairingKit</strong><span style="font-weight: 400;">.</span></p>
<p><span style="font-weight: 400;">More Details Below in "Nested Dictionaries VS Pairing Kit"</span></p>
<p>&nbsp;</p>
<h2><strong>Nested Dictionaries VS Pairing Kit</strong></h2>
<p><span style="font-weight: 400;">Nested Dictionaries are a better option If</span></p>
<ol>
<li style="font-weight: 400;"><span style="font-weight: 400;">your sequence is longer than 8</span></li>
<li style="font-weight: 400;"><span style="font-weight: 400;">or if even 1 number in the sequence is larger than the kit allows for that size of sequence</span></li>
<ol>
<li style="font-weight: 400;"><span style="font-weight: 400;">EX 1: you need a sequence of 8 uints or ints</span></li>
<li style="font-weight: 400;"><span style="font-weight: 400;">EX 2: you need a sequence of 2 ulongs</span></li>
</ol>
</ol>
<p><span style="font-weight: 400;">Pairing Kit is a better option otherwise because</span></p>
<ul>
<li style="font-weight: 400;"><span style="font-weight: 400;">nested Dictionaries can be a bigger hassle to use</span></li>
<li style="font-weight: 400;"><span style="font-weight: 400;">nested Dictionaries would take up more space than just mapping all values into 1 and storing 1 Dictionary with that mapping (based on my limited knowledge)</span></li>
<ul>
<li style="font-weight: 400;"><span style="font-weight: 400;">Note that I believe this is the case for C# but it might not be for another language</span></li>
</ul>
</ul>
<p><br /><br /></p>
<h2><strong>How Encoding a Sequence of 2 to 8 Integrals Works</strong></h2>
<h2><strong>and Custom Encoding</strong></h2>
<p><span style="font-weight: 400;">Note that If I am encoding 2 [8 bit] numbers I require a [16 bit] number to store all possible combinations. This is because each 8 bit number can store 256 numbers (0 -&gt; 255). And every possible combination of two [8 bit] numbers is 256*256 = 65,536 combinations which is exactly how many numbers a [16 bit] number can store (0 -&gt; 65,535). So as mentioned previously we can see that...</span></p>
<ul>
<li style="font-weight: 400;"><span style="font-weight: 400;">to encode 2, [8 bit] numbers we need a [16 bit] number</span></li>
<li style="font-weight: 400;"><span style="font-weight: 400;">to encode 2, [16 bit] numbers we need a [32 bit] number</span></li>
<li style="font-weight: 400;"><span style="font-weight: 400;">to encode 2, [32 bit] numbers we need a [64 bit] number</span></li>
<li style="font-weight: 400;"><span style="font-weight: 400;">and so on...</span></li>
</ul>
<p><span style="font-weight: 400;">I avoided the use of BigInteger anywhere because:</span></p>
<ol>
<li style="font-weight: 400;"><span style="font-weight: 400;">It would have made this already large simple kit even larger </span></li>
<li style="font-weight: 400;"><span style="font-weight: 400;">Technically (from my limited understanding) BigInteger can store arbitrarily large numbers without losing precision so the users of this kit might use it and not realize that in their particular scenario using nested dictionaries would work better</span></li>
</ol>
<p><span style="font-weight: 400;">Since I am not using BigInteger, the larger the sequence, the smaller each number in the sequence must be. This is because the largest number I am allowing all the 2-&gt;8 numbers to encode into is a ulong which can store a max of 2^64 possibilities.</span></p>
<p><span style="font-weight: 400;">I illustrate this visually below...</span></p>
<p><span style="font-weight: 400;"> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ulong&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; </span><span style="font-weight: 400;">64 bits</span></p>
<p><span style="font-weight: 400;"> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;uint&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;</span><span style="font-weight: 400;">|</span> <span style="font-weight: 400;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span style="font-weight: 400;">&nbsp;&nbsp;uint&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;</span><span style="font-weight: 400;">64 bits = 32 bit + 32 bits</span></p>
<p><span style="font-weight: 400;"> &nbsp;&nbsp;ushort &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span style="font-weight: 400;">|</span><span style="font-weight: 400;"> &nbsp;&nbsp;&nbsp;ushort &nbsp;&nbsp;&nbsp;</span><span style="font-weight: 400;">|</span><span style="font-weight: 400;"> &nbsp;&nbsp;&nbsp;ushort &nbsp;&nbsp;&nbsp;&nbsp;</span><span style="font-weight: 400;">|</span><span style="font-weight: 400;"> &nbsp;&nbsp;&nbsp;ushort&nbsp;&nbsp;</span><span style="font-weight: 400;">&nbsp;&nbsp;</span><span style="font-weight: 400;">&nbsp;&nbsp;&nbsp;</span>&nbsp;&nbsp;<span style="font-weight: 400;">64 bits = 16 bits + 16 bits + 16 bits + 16 bits</span></p>
<p><span style="font-weight: 400;"> byte </span><span style="font-weight: 400;">|</span><span style="font-weight: 400;"> byte </span><span style="font-weight: 400;">|</span><span style="font-weight: 400;"> byte </span><span style="font-weight: 400;">|</span><span style="font-weight: 400;"> byte </span><span style="font-weight: 400;">|</span><span style="font-weight: 400;"> byte </span><span style="font-weight: 400;">|</span><span style="font-weight: 400;"> byte </span><span style="font-weight: 400;">|</span><span style="font-weight: 400;"> byte </span><span style="font-weight: 400;">|</span><span style="font-weight: 400;"> byte&nbsp; &nbsp; &nbsp;</span><span style="font-weight: 400;">64 bits = 8 bits * 8</span></p>
<p>&nbsp;</p>
<p><span style="font-weight: 400;">Since our largest number after the encoding must fit into 64 bits.</span></p>
<ul>
<li style="font-weight: 400;"><span style="font-weight: 400;">To combine 2 numbers each number</span></li>
<ul>
<li style="font-weight: 400;"><span style="font-weight: 400;">must be of type: (uint or int) or (ushort or short) or (byte or sbyte)</span></li>
<li style="font-weight: 400;"><span style="font-weight: 400;">not of type: (ulong or long)</span></li>
</ul>
<li style="font-weight: 400;"><span style="font-weight: 400;">To combine 3 numbers each number</span></li>
<ul>
<li style="font-weight: 400;"><span style="font-weight: 400;">must be of type: (ushort or short) or (byte or sbyte)</span></li>
<li style="font-weight: 400;"><span style="font-weight: 400;">not of type: (uint or int) or (ulong or long)</span></li>
</ul>
<li style="font-weight: 400;"><span style="font-weight: 400;">To combine 4 numbers each number</span></li>
<ul>
<li style="font-weight: 400;"><span style="font-weight: 400;">must be of type: (ushort or short) or (byte or sbyte)</span></li>
<li style="font-weight: 400;"><span style="font-weight: 400;">not of type: (uint or int) or (ulong or long)</span></li>
</ul>
<li style="font-weight: 400;"><span style="font-weight: 400;">To combine 5 numbers each number</span></li>
<ul>
<li style="font-weight: 400;"><span style="font-weight: 400;">must be of type: (byte or sbyte)</span></li>
<li style="font-weight: 400;"><span style="font-weight: 400;">not of type: (uint or int) or (ushort or short) or(ulong or long)</span></li>
</ul>
<li style="font-weight: 400;"><span style="font-weight: 400;">To combine 6 numbers each number</span></li>
<ul>
<li style="font-weight: 400;"><span style="font-weight: 400;">must be of type: (byte or sbyte)</span></li>
<li style="font-weight: 400;"><span style="font-weight: 400;">not of type: (uint or int) or (ushort or short) or(ulong or long)</span></li>
</ul>
<li style="font-weight: 400;"><span style="font-weight: 400;">To combine 7 numbers each number</span></li>
<ul>
<li style="font-weight: 400;"><span style="font-weight: 400;">must be of type: (byte or sbyte)</span></li>
<li style="font-weight: 400;"><span style="font-weight: 400;">not of type: (uint or int) or (ushort or short) or(ulong or long)</span></li>
</ul>
<li style="font-weight: 400;"><span style="font-weight: 400;">To combine 8 numbers each number</span></li>
<ul>
<li style="font-weight: 400;"><span style="font-weight: 400;">must be of type: (byte or sbyte)</span></li>
<li style="font-weight: 400;"><span style="font-weight: 400;">not of type: (uint or int) or (ushort or short) or(ulong or long)</span></li>
</ul>
</ul>
<p><span style="font-weight: 400;">Note that these functions provide what is needed for </span><strong>most </strong><span style="font-weight: 400;">scenarios but you can make your own </span><strong>custom </strong><span style="font-weight: 400;">functions to handle all kinds of weird scenarios.</span></p>
<p><span style="font-weight: 400;">For example _4tuple(uint a, byte b, byte c, byte d). For this to work you have to keep in mind how the mappings work. First you can map 'c' and 'd' into a ushort, then you can map 'b' and 'cd' into a uint, then you map 'a' 'bcd' into a ulong. You cannot however map 'a' with 'b' first because 'ab' will be a ulong and a ulong and another other type paired together would require BigInteger.</span></p>
<p><span style="font-weight: 400;">Additionally, you will have to make a reverse method that unwraps the numbers in the reverse way in which you combined them.</span><br /><br /></p>
<h2><strong>What Is Tested</strong></h2>
<ul>
<li style="font-weight: 400;"><span style="font-weight: 400;">all automatic casting</span></li>
<ul>
<li style="font-weight: 400;"><span style="font-weight: 400;">between integrals of different size</span></li>
<li style="font-weight: 400;"><span style="font-weight: 400;">between signed and unsigned integrals</span></li>
</ul>
<li style="font-weight: 400;"><span style="font-weight: 400;">2 number pairings using sbyte and byte types</span></li>
</ul>
<h2>&nbsp;</h2>
<h2><strong>Implications</strong></h2>
<p><span style="font-weight: 400;">Given that everything is based on 2 pairing, unless I made a typo (which is unlikely since I checked the functions thoroughly) everything should work.</span>&nbsp;</p>
<p><span style="font-weight: 400;">In Either case, encoding random numbers and decoding them and checking if the result is the same as the original given you specific types and such is enough to confirm that it all works.</span></p>
