namespace RabbitMQ.Consumer
{
    using RabbitMQ.Client;
    using System;
    class Program
    {
        static void Main(string[] args)
        {
            var factory = new ConnectionFactory
            {
                Uri = new Uri("amqp://guest:guest@localhost:5672")
            };
            using var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();

            //BasicConsumer.Consume(channel);

            //DirectExchangeConsumer.Consume(channel);

            //TopicExchangeConsumer.Consume(channel);

            //HeaderExchangeConsumer.Consume(channel);

            FanoutExchangeConsumer.Consume(channel);
        }
    }
}
