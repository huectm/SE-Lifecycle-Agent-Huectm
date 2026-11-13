using NUnit.Framework;

namespace FreshFood.Backend.UnitTests;

// Typed checks return values used by the arrange/act/assert fixtures.
internal static class TestChecks
{
    internal static T IsType<T>(object? value)
    {
        Assert.That(value, Is.TypeOf<T>());
        return (T)value!;
    }

    internal static void IsType(Type type, object? value) => Assert.That(value, Is.TypeOf(type));

    internal static T Single<T>(IEnumerable<T> values)
    {
        var items = values.ToList();
        Assert.That(items, Has.Count.EqualTo(1));
        return items[0];
    }

    internal static T Throws<T>(Action action) where T : Exception => Assert.Throws<T>(() => action())!;

    internal static Task<T> ThrowsAsync<T>(Func<Task> action) where T : Exception =>
        Task.FromResult(Assert.ThrowsAsync<T>(async () => await action())!);
}
