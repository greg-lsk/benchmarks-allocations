namespace StructWithIFacePatternMatching;


public interface IShortName
{
    public string FirstName { get; }
    public string LastName { get; }
}

public interface ILongName
{
    public string FirstName { get; }
    public string MiddleName { get; }
    public string LastName { get; }
}

public readonly record struct ShortName(string FirstName, string LastName) : IShortName;
public readonly record struct LongName(string FirstName, string MiddleName, string LastName) : ILongName;