using System.Text;
using System.Text.Json;
using HA.LightningService.ConBeeConnector.Interfaces;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace HA.LightningService.RabbitMq.Consumers
{
    public class BaseConsumer<T> : IMessageSubscriber<T>
    {
        protected BaseConsumer(string exchangeName)
        {
            CreateQueueAndConnection(exchangeName);
        }

        public Action<T>? _action;
        private static ConnectionFactory? _connectionFactory;
        private static IConnection? _connection;
        private static IModel? _channel;
        private static string? _queueName;


        private void CreateQueueAndConnection(string exchangeName)
        {
            try
            {
                _connectionFactory = new ConnectionFactory() { HostName = "localhost"};
                using (_connection = _connectionFactory.CreateConnection())
                using (_channel = _connection.CreateModel())
                {
                    _channel.ExchangeDeclare(exchange: exchangeName, type: ExchangeType.Fanout);
                    _queueName = _channel.QueueDeclare().QueueName;
                    _channel.QueueBind(queue: _queueName, exchange: exchangeName, routingKey: "");
                    ReceiveMessage(_queueName);
                };
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }

        }

        //TODO: NOT WORKING! Figure out how the EventingBasicConsumer is working in RabbitMQ.
        private void ReceiveMessage(string queueName)
        {
            var consumer = new EventingBasicConsumer(_channel);
            consumer.Received +=Consumer_Received;
            _channel.BasicConsume(queue: queueName,
                autoAck: true,
                consumer: consumer);
        }

        private void Consumer_Received(object? sender, BasicDeliverEventArgs e)
        {
            var msg = JsonSerializer.Deserialize<T>(Encoding.UTF8.GetString(e.Body.ToArray()));

            if (_action != null && msg != null) _action(msg);
        }

        public void Subscribe(Action<T> action)
        {
            _action = action;
        }
    }
}
