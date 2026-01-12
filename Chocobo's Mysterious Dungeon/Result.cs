using System;


public struct Result
{
    public bool Moved;

    public static Result Fail() => new Result() { Moved = false };
    public static Result Success() => new Result() { Moved = true };
}
