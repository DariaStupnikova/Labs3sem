using Task1;
using Task2;
using Xunit;

namespace Lab1Tests;

public class FirstTaskTests
{

    [Fact]
    public void ProcessArray_ShouldSortArrayByAbsoluteValues()
    {
        // Arrange
        int[] array = { -3, 2, -5, 0, 1 };

        // Act
        FirstTask.ProcessArray(array);

        // Assert
        Assert.Equal(new int[] { 0, 1, 2, -3, -5 }, array);
    }
    
    [Fact]
    public void ProcessArray_ShouldSortArrayByAbsoluteValues2()
    {
        // Arrange
        int[] array = { 0, -3, 20, -50, 9, 10 };

        // Act
        FirstTask.ProcessArray(array);

        // Assert
        Assert.Equal(new int[] { 0, -3, 9, 10, 20, -50 }, array);
    }
}

public class SecondTaskTests
{
    [Fact]
    public void RotateMatrix_ShouldRotateMatrixCorrectly()
    {
        // Arrange
        int[,] matrix = { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };
        var k = 1;

        // Act
        SecondTask.RotateMatrix(matrix, k);

        // Assert
        Assert.Equal(new int[,] { { 4, 1, 2 }, { 7, 5, 3 }, { 8, 9, 6 } }, matrix);
    }
    
    [Fact]
    public void RotateMatrix_ShouldRotateMatrixCorrectly2()
    {
        // Arrange
        int[,] matrix = { { 11, 22, 33 }, { 44, 55, 66 }, { 77, 88, 99 } };
        var k = 1;

        // Act
        SecondTask.RotateMatrix(matrix, k);

        // Assert
        Assert.Equal(new int[,] { { 44, 11, 22 }, { 77, 55, 33 }, { 88, 99, 66 } }, matrix);
    }
}