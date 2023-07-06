# Generics Methods

Intermediate level task for practice generic methods and interfaces. 

Estimated time to complete the task - 1.5h.  

The task requires .NET 6 SDK installed.  
 
## Task Description

* Implement the generic methods of the [ArrayExtension](GenericMethods/ArrayExtension.cs#L10) class.
* To test the generic methods that was implemented do the following :
    *   to test the [Transform](GenericMethods/ArrayExtension.cs#L36) generic method implement the [GetIeee754Format.Transform](DoubleTransformer/GetIeee754Format.cs#L16) method that results a binary representation of a real double-precision number in IEEE 754 format. **Don't use Framework's converter classes**.     
    _The detailed explanations of the method are provided in the XML-comments for the methods and in [test cases](GenericMethods.Tests/NUnitTests/ArrayExtensionTests.cs#L37) of unit tests_       
    _Hint:  Use C# structs to create a union type (similar to C unions)._     
    * to test the [Filter](GenericMethods/ArrayExtension.cs#L21) generic method implement the [ContainsDigitPredicate.IsMatch](IntegerPredicate/ContainsDigitPredicate.cs#L25) method that checks if a number contains a given digit. **Don't use strings and arrays.**      
_The detailed explanations of the method are provided in the XML-comments for the methods and in [test cases](GenericMethods.Tests/NUnitTests/ArrayExtensionTests.cs#L14) of unit tests._
    * to test the [SortBy](GenericMethods/ArrayExtension.cs#L52) generic method implement
        - the [IntegerByAbsComparer.Compare](Comparators/IntegerByAbsComparer.cs#L9) method to compare absolute values of the two integers.  
        - the [StringByLengthComparer.Compare](Comparators/StringByLengthComparer.cs#L9) method to compare two strings by length of them. 

## Additional Materials
- [IEEE 754](https://www.wikiwand.com/en/IEEE_754) 
- [Math.Abs method](https://docs.microsoft.com/en-us/dotnet/api/system.math.abs) 
- [`IComparer<T>` Interface](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.icomparer-1)

