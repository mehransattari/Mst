namespace Mst.Test;

public class StringTests
{
    [Fact]
    public void Fix_InputIsNull_ReturnsNull()
    {
        // Arrange  
        string input = null;

        // Act  
        var result = String.Fix(input);

        // Assert  
        Assert.Null(result);
    }

    [Fact]
    public void Fix_InputIsWhiteSpace_ReturnsNull()
    {
        // Arrange  
        string input = "   ";

        // Act  
        var result = String.Fix(input);

        // Assert  
        Assert.Null(result);
    }

    [Fact]
    public void Fix_InputHasLeadingAndTrailingSpaces_ReturnsTrimmedString()
    {
        // Arrange  
        string input = "   Hello, World!   ";

        // Act  
        var result = String.Fix(input);

        // Assert  
        Assert.Equal("Hello, World!", result);
    }

    [Fact]
    public void Fix_InputHasExtraSpaces_ReturnsSingleSpaces()
    {
        // Arrange  
        string input = "This   is   a   test.";

        // Act  
        var result = String.Fix(input);

        // Assert  
        Assert.Equal("This is a test.", result);
    }

    [Fact]
    public void Fix_InputIsAlreadyFormatted_ReturnsSameString()
    {
        // Arrange  
        string input = "This is a properly formatted test.";

        // Act  
        var result = String.Fix(input);

        // Assert  
        Assert.Equal(input, result);
    }
}