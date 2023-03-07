﻿
namespace WebApplication_Atlantis
{
    public interface ICacheService
    {
        T GetData<T>(string key);
        bool SetData<T>(string key, T value, DateTimeOffset dateTimeOffset);
    }
}
