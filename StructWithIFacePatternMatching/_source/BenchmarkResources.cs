namespace StructWithIFacePatternMatching;

public interface IMayHasMiddleName
{
    public bool HasMiddleName();
}

public interface IShortName : IMayHasMiddleName
{
    public string FirstName { get; }
    public string LastName { get; }
}

public interface ILongName : IMayHasMiddleName
{
    public string FirstName { get; }
    public string MiddleName { get; }
    public string LastName { get; }
}

public readonly record struct ShortName(string FirstName, string LastName) : IShortName
{
    bool IMayHasMiddleName.HasMiddleName() => false;
}


public readonly record struct LongName(string FirstName, string MiddleName, string LastName) : ILongName
{
    bool IMayHasMiddleName.HasMiddleName() => true;
}