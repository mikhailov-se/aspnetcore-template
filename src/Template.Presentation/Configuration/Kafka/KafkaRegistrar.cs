namespace Template.Presentation.Configuration.Kafka;

internal sealed class KafkaRegistrar
{
    public static void Configure(IServiceCollection services)
    {
        AddProducers();
        AddConsumers();
    }

    private static void AddConsumers()
    {
    }

    private static void AddProducers()
    {
    }
}