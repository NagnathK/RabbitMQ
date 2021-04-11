namespace RabbitMQ.Publisher
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
            Console.WriteLine(" Publishing messages start!!!");

            //BasicPublisher.Publish(channel);
            //DirectExchangePublisher.Publish(channel);
            //TopicExchangePublisher.Publish(channel);
            //HeaderExchangePublisher.Publish(channel);
            FanoutExchangePublisher.Publish(channel);
        }
    }
}
