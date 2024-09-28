
using Mst.Net;

namespace Mst.Test.Net;

public class UnitTestIP
{
    #region Fix
   
    [Fact]
    public void Fix_InputIsNull_ReturnsNull()
    {
        //Arrange
        string input = null;

        //Act
        var result = Mst.Net.IpAddress.Fix(input);

        //Assert
        Assert.Null(result);
    }

    [Fact]
    public void Fix_EmptyInput_ReturnsNull()
    {
        //Arrange
        string input = " ";

        //Act
        var result = Mst.Net.IpAddress.Fix(input);

        //Assert
        Assert.Null(result);
    }

    [Fact]
    public void Fix_WhitespaceInput_ReturnsNull()
    {
        //Arrange
        string input = "    ";

        //Act
        var result = Mst.Net.IpAddress.Fix(input);

        //Assert
        Assert.Null(result);
    }

    [Fact]
    public void Fix_InvalidFormat_ReturnsNull()
    {
        //Arrange
        string input = "192:168:1";

        //Act
        var result = Mst.Net.IpAddress.Fix(input);

        //Assert
        Assert.Null(result);
    }

    [Fact]
    public void Fix_InvalidCharacters_ReturnsNull()
    {
        //Arrange
        string input = "192.168.1.abc";

        //Act
        var result = Mst.Net.IpAddress.Fix(input);

        //Assert
        Assert.Null(result);
    }

    [Fact]
    public void Fix_OutOfRangeValues_ReturnsNull()
    {
        //Arrange
        string input = "192.168.256.1";

        //Act
        var result = Mst.Net.IpAddress.Fix(input);

        //Assert
        Assert.Null(result);
    }

    [Fact]
    public void Fix_ProperlyFormattedInput_ReturnsSameString()
    {
        // Arrange  
        string input = "192.168.1.1";

        // Act  
        var result = Mst.Net.IpAddress.Fix(input);

        // Assert  
        Assert.Equal(input, result);
    }

    [Fact]
    public void Fix_InputWithColons_ReturnsProperIPv4()
    {
        // Arrange  
        string input = "192:168:1:1";

        // Act  
        var result = IpAddress.Fix(input);

        // Assert  
        Assert.Equal("192.168.1.1", result);
    }

    [Fact]
    public void Fix_InputWithSpaces_ReturnsProperIPv4()
    {
        // Arrange  
        string input = "   10  .  0  .  0  .  1   ";

        // Act  
        var result = IpAddress.Fix(input);

        // Assert  
        Assert.Equal("10.0.0.1", result);
    }

    [Fact]
    public void Fix_InputWithTooManyParts_ReturnsNull()
    {
        // Arrange  
        string input = "192.168.1.1.1.1";

        // Act  
        var result = IpAddress.Fix(input);

        // Assert  
        Assert.Null(result);
    }

    [Fact]
    public void Fix_MaxLengthExceeds_ReturnsNull()
    {
        // Arrange  
        string input = "123.45.67.89.0";

        // Act  
        var result = IpAddress.Fix(input);

        // Assert  
        Assert.Null(result);
    }

    #endregion

    #region Format  

    [Fact]
    public void Format_NullInput_ReturnsNull()
    {
        // Arrange  
        string input = null;

        // Act  
        var result = IpAddress.Format(input);

        // Assert  
        Assert.Null(result);
    }

    [Fact]
    public void Format_InvalidIPv4_ReturnsNull()
    {
        // Arrange  
        string input = "256.0.0.1";

        // Act  
        var result = IpAddress.Format(input);

        // Assert  
        Assert.Null(result);
    }

    [Fact]
    public void Format_ProperlyFormattedInput_ReturnsFormattedString()
    {
        // Arrange  
        string input = "192.168.1.1";
        string expected = "192.168.001.001";

        // Act  
        var result = IpAddress.Format(input);

        // Assert  
        Assert.Equal(expected, result);
    }

    [Fact]
    public void Format_InputWithColons_ReturnsFormattedIPv4()
    {
        // Arrange  
        string input = "192:168:1:1";
        string expected = "192.168.001.001";

        // Act  
        var result = IpAddress.Format(input);

        // Assert  
        Assert.Equal(expected, result);
    }

    [Fact]
    public void Format_InputWithSpaces_ReturnsFormattedIPv4()
    {
        // Arrange  
        string input = "   10  .  0  .  0  .  1   ";
        string expected = "010.000.000.001";

        // Act  
        var result = IpAddress.Format(input);

        // Assert  
        Assert.Equal(expected, result);
    }

    #endregion

    #region ToNumber  

    [Fact]
    public void ToNumber_NullInput_ReturnsNull()
    {
        // Arrange  
        string input = null;

        // Act  
        var result = IpAddress.ToNumber(input);

        // Assert  
        Assert.Null(result);
    }

    [Fact]
    public void ToNumber_EmptyInput_ReturnsNull()
    {
        // Arrange  
        string input = "";

        // Act  
        var result = IpAddress.ToNumber(input);

        // Assert  
        Assert.Null(result);
    }

    [Fact]
    public void ToNumber_OutOfRange_ReturnsNull()
    {
        // Arrange  
        string input = "256.256.256.256";

        // Act  
        var result = IpAddress.ToNumber(input);

        // Assert  
        Assert.Null(result);
    }

    [Fact]
    public void ToNumber_ValidIPv4_ReturnsProperUInt()
    {
        // Arrange  
        string input = "192.168.1.1";
        uint expected = 3232235777;

        // Act  
        var result = IpAddress.ToNumber(input);

        // Assert  
        Assert.Equal(expected, result);
    }

    [Fact]
    public void ToNumber_InValidIPv4_ReturnsProperUInt()
    {
        // Arrange  
        string input = "192.168.1.1";
        uint expected = 3232235771;

        // Act  
        var result = IpAddress.ToNumber(input);

        // Assert  
        Assert.NotEqual(expected, result);
    }

    [Fact]
    public void ToNumber_ValidIPv4WithSpaces_ReturnsProperUInt()
    {
        // Arrange  
        string input = "   192.  168.  1.  1   ";
        uint expected = 3232235777;

        // Act  
        var result = IpAddress.ToNumber(input);

        // Assert  
        Assert.Equal(expected, result);
    }


    [Fact]
    public void ToNumber_InvalidCharacters_ReturnsNull()
    {
        // Arrange  
        string input = "192.168.1.abc";

        // Act  
        var result = IpAddress.ToNumber(input);

        // Assert  
        Assert.Null(result);
    }

    #endregion

    #region ToString  

    [Fact]
    public void ToString_ValidUInt_ReturnsCorrectIPv4()
    {
        // Arrange  
        uint input = 3232235777; // 192.168.1.1  
        string expected = "192.168.1.1";

        // Act  
        var result = IpAddress.ToString(input);

        // Assert  
        Assert.Equal(expected, result);
    }

    [Fact]
    public void Test_ToString_With_LittleEndian()
    {
        // Arrange  
        uint ipV4Address = 0x12345678; // Expected as 120.86.52.18 in Little Endian  
        string expected = "18.52.86.120"; // Result in human-readable format  

        // Act  
        string result = IpAddress.ToString(ipV4Address);

        // Assert  
        Assert.Equal(expected, result);
    }

    [Fact]
    public void Test_ToString_With_BigEndian()
    {
        // Arrange  
        uint ipV4Address = 0x78563412; // Expected as 120.86.52.18 in Big Endian  
        string expected = "120.86.52.18"; // Result in human-readable format  

        // Act  
        string result = IpAddress.ToString(ipV4Address);

        // Assert  
        Assert.Equal(expected, result);
    }

    [Fact]
    public void ToString_Zero_ReturnsZeroIPv4()
    {
        // Arrange  
        uint input = 0; // 0.0.0.0  
        string expected = "0.0.0.0";

        // Act  
        var result = IpAddress.ToString(input);

        // Assert  
        Assert.Equal(expected, result);
    }

    [Fact]
    public void ToString_MaxValue_ReturnsMaxIPv4()
    {
        // Arrange  
        uint input = uint.MaxValue; // 255.255.255.255  
        string expected = "255.255.255.255";

        // Act  
        var result = IpAddress.ToString(input);

        // Assert  
        Assert.Equal(expected, result);
    }


    #endregion
}
