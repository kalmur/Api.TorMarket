namespace Api.TorMarket.Application.Unions;

public readonly struct ResultOrError<TResult, TError>
{
    private readonly bool _isResult;
    private readonly TResult _result;
    private readonly TError _error;

    private ResultOrError(
        bool isResult,
        TResult result,
        TError error
    )
    {
        _isResult = isResult;
        _result = result;
        _error = error;
    }

    public bool IsResult => _isResult;
    public bool IsError => !IsResult;

    public TResult Result => IsResult
        ? _result
        : throw new InvalidOperationException($"Cannot return error as result");

    public TError Error => IsError
        ? _error
        : throw new InvalidOperationException($"Cannot return result as error");


    public static implicit operator ResultOrError<TResult, TError>(
        TResult result
    ) => new(
        true,
        result,
        default!
    );

    public static implicit operator ResultOrError<TResult, TError>(
        TError error
    ) => new(
        false,
        default!,
        error
    );
}