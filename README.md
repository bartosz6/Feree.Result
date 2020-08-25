# Result type for C#

Simple implementation of result monad based on C# pattern matching. Makes developers to check operation status in order to access result. Does not allows nulls, makes code more self explainatory than boolean flags.

# Usage

## Success

```c#
var result = ResultFactory.CreateSuccess("howdy!");
var resultTask = ResultFactory.CreateSuccessAsync("mate");

if(result is Success)
  Console.WriteLine("yay, operation was successful!");

if(result is Success<string> success)
  Console.WriteLine(success.Payload);

if(await resultTask is Success<string> success)
  Console.WriteLine($"hello {success.Payload}");
```

## Failure

```c#
var result = ResultFactory.CreateFailure("very serious error");
var resultTask = ResultFactory.CreateFailureAsync("asynchronous error");

if(result is Failure)
  Console.WriteLine("error :(");

if(result is Failure<string> failure)
  Console.WriteLine(failure.Error.Message);

if(await resultTask is Failure<string> failure)
  Console.WriteLine(failure.Error.Message);
```

## Unit

Unfortunately you cannot assign void to a variable. Unit type is commonly used walkaround for this issue in C#. It means exactly the same as void is. Useful if operation may either succeed or fail, but contains no payload - for example in CQRS command handler should not return any data, but operation itself may fail or succeed. It's safer to return result type than throwing an exception.

```c#
var unit = new Unit();
```

## Custom errors

```c#
class NameIsRequiredError : IError 
{
  public string Message {get;}
  public NameIsRequiredError() => Message = "name is required";
}

IResult<Unit> ValidateName(string name) =>
  string.IsNullOrEmpty(name)
    ? ResultFactory.CreateFailure(new NameIsRequiredError())
    : ResultFactory.CreateSuccess();
```

# Binding results

```c#
public class UserName 
{
  public Value {get;}

  public IResult<UserName> Create(string name) =>
    ValidateName(name).Bind(() => new UserName(name).AsResult());

  private UserName(string name) => Value = name;
  
  private IResult<Unit> ValidateName(string name) =>
    string.IsNullOrEmpty(name)
      ? ResultFactory.CreateFailure(new NameIsRequiredError())
      : ResultFactory.CreateSuccess();
}

class NameIsRequiredError : IError 
{
  public string Message {get;}
  public NameIsRequiredError() => Message = "name is required";
}
```

### Build status

[![CircleCI](https://circleci.com/gh/bartosz6/Feree.Result/tree/master.svg?style=svg)](https://circleci.com/gh/bartosz6/Feree.Result/tree/master)
