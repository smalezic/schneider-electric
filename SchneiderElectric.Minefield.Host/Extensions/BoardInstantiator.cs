namespace SchneiderElectric.Minefield.Host.Extensions;

using Microsoft.Extensions.DependencyInjection;
using SchneiderElectric.Minefield.Host.Field;
using SchneiderElectric.Minefield.Host.Presentation;

public static class BoardInstantiator
{
    public static IServiceProvider Initialize(
        this IServiceCollection services,
        int boardSize,
        int numberOfMines)
    {
        services.AddSingleton<IBoardRenderer, ConsoleBoardRenderer>();
        services.AddTransient<IBoard>(provider =>
            Board.Create(provider.GetRequiredService<IBoardRenderer>(), boardSize, numberOfMines));

        return services.BuildServiceProvider();
    }
}