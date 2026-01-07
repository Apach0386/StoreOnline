
using System.Collections.Concurrent;

class Program
{
    public static void Main()
    {
        Guid[] Ids = new Guid[1000];
        int ThreadCount = 5;

        Parallel.For(0, ThreadCount, async (i) =>
        {
            for (int j = 0; j < Ids.Length / ThreadCount; j++)
            {
                Guid id = Ids[i * (Ids.Length / ThreadCount) + j];
                CustomerData data = await GetCustomerDataById(id);
            }
        });
    }


    class Program01
    {
        public static async Task Main()
        {
            Guid[] ids = new Guid[1000];
            int maxConcurrency = 5;

            var results = new ConcurrentBag<CustomerData>();

            await Parallel.ForEachAsync(
                ids,
                new ParallelOptions { MaxDegreeOfParallelism = maxConcurrency },
                async (id, ct) =>
                {
                    var data = await GetCustomerDataById(id);
                    results.Add(data);
                });

            
        }

        public class CustomerData { }

        public static Task<CustomerData> GetCustomerDataById(Guid id)
            => Task.FromResult(new CustomerData());
    }

    class Program02
    {
        public static async Task Main()
        {
            Guid[] ids = new Guid[1000];
            int maxConcurrency = 5;

            var semaphore = new SemaphoreSlim(maxConcurrency);
            var results = new ConcurrentBag<CustomerData>();

            var tasks = ids.Select(async id =>
            {
                await semaphore.WaitAsync();
                try
                {
                    var data = await GetCustomerDataById(id);
                    results.Add(data);
                }
                finally
                {
                    semaphore.Release();
                }
            });

            await Task.WhenAll(tasks);
        }

        public class CustomerData { }

        public static Task<CustomerData> GetCustomerDataById(Guid id)
            => Task.FromResult(new CustomerData());
    }




    public class CustomerData
    {
    }

    public static Task<CustomerData> GetCustomerDataById(Guid id)
    {
        return Task.FromResult(new CustomerData());


    }




    public async Task<IReadOnlyCollection<CustomerData>> GetCustomersByIdList(Guid[] idList)
    {
        return new List<CustomerData>();
    }
}