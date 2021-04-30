using System;
using Confluent.Kafka;

namespace Greeter.Producers
{
    public class KafkaProducer
    {
        private readonly ProducerConfig config = new ProducerConfig 
            { BootstrapServers = "localhost:9092" };
        
        public KafkaProducer()
        {
            
        }
        public Object SendToKafka(string topic, string message)
        {
            using (var producer = 
                new ProducerBuilder<Null, string>(config).Build())
            {
                try
                {
                    return producer.ProduceAsync(topic, new Message<Null, string> { Value = message })
                        .GetAwaiter()
                        .GetResult();
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Oops, something went wrong: {e}");
                }
            }
            return null;
        }
    }
}