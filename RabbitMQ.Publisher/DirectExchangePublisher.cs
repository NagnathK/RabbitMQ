namespace RabbitMQ.Publisher
{
    using Newtonsoft.Json;
    using RabbitMQ.Client;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading;
    public static class DirectExchangePublisher
    {
        public static void Publish(IModel channel)
        {

            var ttl = new Dictionary<string, object>()
            {
                {"x-message-ttl", 30000 }
            };

            channel.ExchangeDeclare(exchange: "demo-direct-exchange",
                type: ExchangeType.Direct,
                durable: false,
                autoDelete: false,
                arguments: ttl);

            var count = 0;

            while(true)
            {
                var message = new { Name = "Producer", Message = $"Hello! Count: {count}" };
                var body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(message));

                channel.BasicPublish("demo-direct-exchange", "account.init", null, body);
                count++;
                Thread.Sleep(1000);
            }
        }
    }
}
