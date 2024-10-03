using System;

namespace LevelUpCSharp.Concurrency
{
    public interface IVault<TSecret>
    {
        void Put(TSecret secret);
        TSecret Get();
    }

    public class Vault<TSecret> : IVault<TSecret>
    {
        private TSecret _secret;

        public void Put(TSecret secret)
        {
            _secret = secret;
        }

        public TSecret Get()
        {
            var result = _secret;
            _secret = default(TSecret);
            return result;
        }
    }

	public class ConcurrentVault<TSecret>
    {
        private TSecret _secret;

        public void Put(TSecret secret)
        {
			lock (this)
			{
                _secret = secret;
            }
        }

        public TSecret Get()
        {
			lock (this)
			{
				var result = _secret;
				_secret = default(TSecret);
				return result; 
			}
        }
    }
}